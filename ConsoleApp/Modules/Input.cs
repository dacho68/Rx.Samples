using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace ConsoleApp.Modules
{
 // public enum Bit { Low = 0, High = 1 }

  public abstract class Input<T>
  {
    protected bool mIsInitialized = false;
    protected T mPreviousValue = default(T);
    protected Subject<T> valueStream = new Subject<T>();
    public IObservable<T> Value { get { return valueStream; } }
    public abstract void SetValue(T value);
    
  }
}
