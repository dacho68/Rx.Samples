using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Modules
{
  public class LogicalInput : Input<bool>
  {
    public override void SetValue(bool value)
    {
      //if (!mIsInitialized)
      //{
      //  valueStream.OnNext(value);
      //  mPreviousValue = value;
      //  mIsInitialized = true;
      //  return;
      //}

  //    if (mPreviousValue != value )
      {
        valueStream.OnNext(value);
        mPreviousValue = value;
      }
    }
  }
}
