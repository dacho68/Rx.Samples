using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class TimeSerie<T>
  {
    public T Value { get; set; }
    public TimeSpan ElapsedTime { get; set; }
  }
}
