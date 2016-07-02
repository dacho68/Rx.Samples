using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class AndGate : LogicalGate
  {
    public AndGate(params IObservable<TimeSerie<bool>>[] iParams) : base(iParams) 
    {
      SetupInputList(iParams);
    }

    /// <summary>
    /// This the generic multiple inputs
    /// </summary>
    /// <param name="iParams"></param>
    private void SetupInputList(IObservable<TimeSerie<bool>>[] iParams)
    {
      var wAndGate = new AndGate(iParams[0], iParams[1]);
      for (int i = 2; i < iParams.Length; i++)
      {
        wAndGate = new AndGate(iParams[i], wAndGate.Value);
      }
      mValueStream = wAndGate.Value;
      mValueStream.Subscribe(z => LastValue = z);
    }

    public AndGate(IObservable<TimeSerie<bool>> x, IObservable<TimeSerie<bool>> y) : base(x, y) { }
    /*
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3) : base(p1, p2, p3) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4) : base(p1, p2, p3,p4) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5) : base(p1, p2, p3, p4, p5) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6) : base(p1, p2, p3, p4, p5, p6) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7) : base(p1, p2, p3, p4, p5, p6,p7) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8) : base(p1, p2, p3, p4, p5, p6, p7,p8) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12, IObservable<TimeSerie<bool>> p13) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12, IObservable<TimeSerie<bool>> p13, IObservable<TimeSerie<bool>> p14) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) { }
    public AndGate(IObservable<TimeSerie<bool>> p1, IObservable<TimeSerie<bool>> p2, IObservable<TimeSerie<bool>> p3, IObservable<TimeSerie<bool>> p4, IObservable<TimeSerie<bool>> p5, IObservable<TimeSerie<bool>> p6, IObservable<TimeSerie<bool>> p7, IObservable<TimeSerie<bool>> p8, IObservable<TimeSerie<bool>> p9, IObservable<TimeSerie<bool>> p10, IObservable<TimeSerie<bool>> p11, IObservable<TimeSerie<bool>> p12, IObservable<TimeSerie<bool>> p13, IObservable<TimeSerie<bool>> p14, IObservable<TimeSerie<bool>> p15) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) { }

    */
    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> x, TimeSerie<bool> y)
    {
      var wTs = new TimeSerie<bool>();
      wTs.Value = (x.Value && y.Value);
      wTs.ElapsedTime = x.ElapsedTime.Ticks > y.ElapsedTime.Ticks ? x.ElapsedTime : y.ElapsedTime;
      return LastValue = wTs;
    }
    /*
    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3)
    {
      return LastValue = (p1 && p2 && p3);
    }
    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4)
    {
      return LastValue = (p1 && p2 && p3 && p4);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13, TimeSerie<bool> p14)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13 && p14);
    }

    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> p1, TimeSerie<bool> p2, TimeSerie<bool> p3, TimeSerie<bool> p4, TimeSerie<bool> p5, TimeSerie<bool> p6, TimeSerie<bool> p7, TimeSerie<bool> p8, TimeSerie<bool> p9, TimeSerie<bool> p10, TimeSerie<bool> p11, TimeSerie<bool> p12, TimeSerie<bool> p13, TimeSerie<bool> p14, TimeSerie<bool> p15)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13 && p14 && p15);
    }
     * */
  }
}
