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
    protected bool LastValue 
    {
      get; set;
    }

    protected IObservable<bool>[] mParams;

    public LogicalGate(IObservable<bool> x)
    {
      mValueStream = x.Select(Evaluate);
    }

    public LogicalGate(IObservable<bool> x, IObservable<bool> y)
    {
      mValueStream = x.CombineLatest(y, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3)
    {
      mValueStream = p1.CombineLatest(p2, p3, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6,p7, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7,p8, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9,p10, Evaluate);
    }
    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, Evaluate);
    }
    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6, 
    IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12,
    IObservable<bool> p13)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12,p13, Evaluate);
    }
    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6,
      IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12,
      IObservable<bool> p13, IObservable<bool> p14)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, Evaluate);
    }

    public LogicalGate(IObservable<bool> p1, IObservable<bool> p2, IObservable<bool> p3, IObservable<bool> p4, IObservable<bool> p5, IObservable<bool> p6,
      IObservable<bool> p7, IObservable<bool> p8, IObservable<bool> p9, IObservable<bool> p10, IObservable<bool> p11, IObservable<bool> p12,
      IObservable<bool> p13, IObservable<bool> p14, IObservable<bool> p15)
    {
      mValueStream = p1.CombineLatest(p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, Evaluate);
    }
    public LogicalGate()
    {
    }
    public virtual void SetupInputList(IObservable<bool>[] iParams)
    {
      mParams = iParams;
    }

    protected IObservable<bool> mValueStream;
    public IObservable<bool> Value { get { return mValueStream; } }

    protected virtual bool Evaluate()
    {
      return false;
    }

    protected virtual bool Evaluate(bool x)
    {
      return false;
    }


    protected virtual bool Evaluate(bool x, bool y)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3)
    {
      return false;
    }
    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7,bool p8, bool p9, bool p10)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13, bool p14)
    {
      return false;
    }

    protected virtual bool Evaluate(bool p1, bool p2, bool p3, bool p4, bool p5, bool p6, bool p7, bool p8, bool p9, bool p10, bool p11, bool p12, bool p13, bool p14, bool p15)
    {
      return false;
    }


  }
}
