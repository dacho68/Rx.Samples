﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class LogicalInput : Input<TimeSerie<bool>>
  {
    public override void SetValue(TimeSerie<bool> value)
    {
      valueStream.OnNext(value);
    }

    public void SetValue(TimeSpan iElapsedTime , bool value)
    {
      var wTs = new TimeSerie<bool>();
      wTs.ElapsedTime = iElapsedTime;
      wTs.Value = value;
      valueStream.OnNext(wTs);
    }

  }
}
