using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class AndGate : LogicalGate
  {
   // private AndGate mAndGate; 
    public AndGate() : base() 
    {
    }

    /// <summary>
    /// This the generic multiple inputs
    /// </summary>
    /// <param name="iParams"></param>
    public override void SetupInputList(IObservable<bool>[] iParams)
    {
      base.SetupInputList(iParams);
      var wAndGate = new AndGate(iParams[0], iParams[1]);
      for (int i = 2; i < iParams.Length; i++)
      {
        wAndGate = new AndGate(iParams[i], wAndGate.Value);
      }
      mValueStream = wAndGate.Value;
      mValueStream.Subscribe(z => LastValue = z);
    }

    public AndGate(IObservable<bool> x, IObservable<bool> y) : base(x, y) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3) : base(p1, p2, p3) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4) : base(p1, p2, p3,p4) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5) : base(p1, p2, p3, p4, p5) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6) : base(p1, p2, p3, p4, p5, p6) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7) : base(p1, p2, p3, p4, p5, p6,p7) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8) : base(p1, p2, p3, p4, p5, p6, p7,p8) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12, IObservable<bool> p13) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12, IObservable<bool> p13, IObservable<bool> p14) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14) { }
    public AndGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12, IObservable<bool> p13, IObservable<bool> p14, IObservable<bool> p15) : base(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15) { }


    protected override bool Evaluate(bool x, bool y)
    {
      return LastValue = (x && y);

    }
    protected override bool Evaluate(bool p1, bool p2, bool p3)
    {
      return LastValue = (p1 && p2 && p3);
    }
    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4)
    {
      return LastValue = (p1 && p2 && p3 && p4);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13, bool p14)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13 && p14);
    }

    protected override bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13, bool p14, bool p15)
    {
      return LastValue = (p1 && p2 && p3 && p4 && p5 && p6 && p7 && p8 && p9 && p10 && p11 && p12 && p13 && p14 && p15);
    }
  }
}
