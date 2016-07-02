using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ConsoleApp.Modules
{
  public class ForDurationGate:LogicalGate
  {
    public ForDurationGate(IObservable<bool> iInput): base(iInput)
    {
    }


    protected virtual bool Evaluate(bool x)
    {
      return true;
    }
  }
}
