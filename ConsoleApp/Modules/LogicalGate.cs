using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ConsoleApp.Modules
{
  public class LogicalGate
  {
    protected TimeSerie<bool> LastValue 
    {
      get; set;
    }

    protected IObservable<TimeSerie<bool>>[] mParams;

    public LogicalGate(IObservable<TimeSerie<bool>> x)
    {
      mValueStream = x.Select(Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> x, IObservable<TimeSerie<bool>> y)
    {
      mValueStream = x.CombineLatest(y, Evaluate);
    }

    /*
    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3)
    {
      mValueStream = p1.CombineLatest(p2, p3, Evaluate);
    }
    
    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6,p7, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7,p8, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9,p10, Evaluate);
    }
    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Evaluate);
    }
    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, 
    IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12,
    IObservable<TimeSerie<bool>> p13)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12,p13, Evaluate);
    }
    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6,
      IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12,
      IObservable<TimeSerie<bool>> p13, IObservable<TimeSerie<bool>> p14)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Evaluate);
    }

    public LogicalGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6,
      IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12,
      IObservable<TimeSerie<bool>> p13, IObservable<TimeSerie<bool>> p14, IObservable<TimeSerie<bool>> p15)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Evaluate);
    }
    */

    public LogicalGate(params IObservable<TimeSerie<bool>>[] iParams)
    {
      mParams = iParams;
    }
  
    //public virtual void SetupInputList(IObservable<TimeSerie<bool>>[] iParams)
    //{
    //  mParams = iParams;
    //}

    protected IObservable<TimeSerie<bool>> mValueStream;
    public IObservable<TimeSerie<bool>> Value { get { return mValueStream; } }

    protected virtual TimeSerie<bool> Evaluate()
    {
      return new TimeSerie<bool>() ;
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> x)
    {
      return new TimeSerie<bool>();
    }


    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> x, TimeSerie<bool> y)
    {
      return new TimeSerie<bool>();
    }
    /*
    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3)
    {
      return new TimeSerie<bool>();
    }
    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7,TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13, TimeSerie<bool> p14)
    {
      return new TimeSerie<bool>();
    }

    protected virtual TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13, TimeSerie<bool> p14, TimeSerie<bool> p15)
    {
      return new TimeSerie<bool>();
    }
    */

  }
}
