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

    public ForDurationGate(IObservable<TimeSerie<bool>> iInput): base(iInput)
    {

    }


    protected override TimeSerie<bool> Evaluate(TimeSerie<bool> x)
    {
      var wTimeSerie = new TimeSerie<bool>();
      wTimeSerie.Value = true;
      LastValue = wTimeSerie;
      return wTimeSerie;
    }
  }
}
