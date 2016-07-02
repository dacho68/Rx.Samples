﻿namespace ConsoleApp
{
  using System;
  using System.Reactive.Concurrency;
  using System.Reactive.Disposables;
  using System.Reactive.Linq;
  using System.Threading;
  using System.Diagnostics;
  using ConsoleApp.Modules;
  using System.Collections.Generic;

  class Program
  {
  

    public static void TwoOrInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();

      var a1 = new OrGate(a.Value, b.Value);
      var a2 = new OrGate(a1.Value, c.Value);
      a2.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);  // 
      b.SetValue(false); // 
      c.SetValue(true); // T + F + T = T
      a.SetValue(false); // F + T + T= T
      c.SetValue(false); // F + F + F = F
      b.SetValue(true); // T
      b.SetValue(false); // F
    }


    public static void ThreeOrInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();

      var a1 = new OrGate(a.Value, b.Value, c.Value);
      a1.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);  // 
      b.SetValue(false); // 
      c.SetValue(true); // T + F + T = T
      a.SetValue(false); // F + T + T= T
      c.SetValue(false); // F + F + F = F
      b.SetValue(true); // T
      b.SetValue(false); // F
    }


    public static void MultiOrInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();
      var wInputList = new List<IObservable<bool>>();
      wInputList.Add(a.Value); wInputList.Add(b.Value); wInputList.Add(c.Value);

      var multiInputs = new OrGate();
      multiInputs.SetupInputList(wInputList.ToArray());
      multiInputs.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);  // 
      b.SetValue(false); // 
      c.SetValue(true); // T + F + T = T
      a.SetValue(false); // F + T + T= T
      c.SetValue(false); // F + F + F = F
      b.SetValue(true); // T
      b.SetValue(false); // F
    }


    public static void TwoAndInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();

      var a1 = new AndGate(a.Value, b.Value);
      var a2 = new AndGate(a1.Value, c.Value);
      a2.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);
      b.SetValue(true);
      c.SetValue(true); // High + High +High = High
      b.SetValue(false); // High + Low +High= Low
      b.SetValue(true); // High + High +High= High
      a.SetValue(false); // Low + High +High= Low
      b.SetValue(false); // Low + Low +High= Low
    }


    public static void TripleAndInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();

      var gate3Inputs = new AndGate(a.Value, b.Value, c.Value);
      gate3Inputs.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);
      b.SetValue(true);
      c.SetValue(true); // High + High +High = High
      b.SetValue(false); // High + Low +High= Low
      b.SetValue(true); // High + High +High= High
      a.SetValue(false); // Low + High +High= Low
      b.SetValue(false); // Low + Low +High= Low
    }

    public static void MultiAndInputs()
    {
      var a = new LogicalInput();
      var b = new LogicalInput();
      var c = new LogicalInput();
      var wInputList = new List<IObservable<bool>>();
      wInputList.Add(a.Value); wInputList.Add(b.Value);  wInputList.Add(c.Value);

      var multiInputs = new AndGate();
      multiInputs.SetupInputList(wInputList.ToArray());
      multiInputs.Value.Subscribe(z => Console.WriteLine(z.ToString()));

      a.SetValue(true);
      b.SetValue(true);
      c.SetValue(true); // High + High +High = High
      b.SetValue(false); // High + Low +High= Low
      b.SetValue(true); // High + High +High= High
      a.SetValue(false); // Low + High +High= Low
      b.SetValue(false); // Low + Low +High= Low
    }

    static void TestInterval()
    {
      IObservable<long> intervalSubject = Observable.Interval(TimeSpan.FromMilliseconds(125));

      var stopwatch = new Stopwatch();

      // Begin timing.
      stopwatch.Start();

      var wHandle = intervalSubject
           // .Sample(TimeSpan.FromMilliseconds(100))
           .Subscribe(x =>
           {
             if (x % 2 == 0)
             {
               Console.WriteLine("Received: {0} {1}", DateTime.UtcNow, x);
             }
           });

      Thread.Sleep(TimeSpan.FromSeconds(2));
      stopwatch.Stop();
      Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
      wHandle.Dispose();

    }

    static void TestInterval()
    {
      IObservable<long> intervalSubject = Observable.Interval(TimeSpan.FromMilliseconds(125));

      var stopwatch = new Stopwatch();

      // Begin timing.
      stopwatch.Start();

      var wHandle = intervalSubject
        // .Sample(TimeSpan.FromMilliseconds(100))
           .Subscribe(x =>
           {
               Console.WriteLine("Received: {0} {1}", DateTime.UtcNow, x);
           });

      Thread.Sleep(TimeSpan.FromSeconds(20));
      stopwatch.Stop();
      Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
      wHandle.Dispose();

    }


    public static void TestDuration()
    {
      Console.WriteLine("Test Duration");

      var a = new LogicalInput();
      var wDur = new ForDurationGate(a.Value);
      wDur.Value.Subscribe(z => Console.WriteLine(z.ToString()));
      a.SetValue(true); 
      a.SetValue(true);
      a.SetValue(false);
      a.SetValue(true);
      a.SetValue(false);
      a.SetValue(false);
      a.SetValue(true);
    }
    static void Main(string[] args)
    {
      TestDuration();

      TestInterval();

      Console.WriteLine("Test on next");

      var wListener = new SampleListener<int>();
      var wSender = new SampleNumberSender();
      wSender.Subscribe(wListener);




      Console.WriteLine("-----");
      TwoOrInputs();
      Console.WriteLine("-----");
      ThreeOrInputs();
      Console.WriteLine("-----");
      MultiOrInputs();
      Console.WriteLine("--- And --");
      TwoAndInputs();
      Console.WriteLine("-----"); 
      TripleAndInputs();
      Console.WriteLine("-----");
      MultiAndInputs();

      Console.ReadKey();
    }
  }

  public class SampleListener<T> : IObserver<T>
  {
    public void OnNext(T value)
    {
      Console.WriteLine("Received: {0}", value);
    }

    public void OnError(Exception error)
    {
      Console.WriteLine("Error: {0}", error);
    }

    public void OnCompleted()
    {
      Console.WriteLine("Completed!");
    }
  }

  public class SampleNumberSender : IObservable<int>
  {
    public IDisposable Subscribe(IObserver<int> observer)
    {
      observer.OnNext(1);
      observer.OnNext(2);
      observer.OnNext(3);
      observer.OnCompleted();
      return Disposable.Empty;
    }
  }

}
