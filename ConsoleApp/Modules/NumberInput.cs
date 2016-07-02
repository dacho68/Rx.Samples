using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class NumberInput : Input<TimeSerie<double>>
  {
    public override void SetValue(TimeSerie<double> value)
    {
      valueStream.OnNext(value);
    }

    public void SetValue(TimeSpan iElapsedTime, double value)
    {
      var wTs = new TimeSerie<double>();
      wTs.ElapsedTime = iElapsedTime;
      wTs.Value = value;
      valueStream.OnNext(wTs);
    }
  }
}
