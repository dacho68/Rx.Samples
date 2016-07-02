using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ConsoleApp.Modules
{
  public class AverageFx
  {
    protected IObservable<TimeSerie<double>> mValueStream;

    public IObservable<TimeSerie<double>> Value { get { return mValueStream; } }

    protected TimeSerie<double> LastValue
    {
      get;
      set;
    }

    private TimeSpan mTimeDuration;

    private LinkedList<TimeSerie<double>> mBuffer; 

    public AverageFx(IObservable<TimeSerie<double>> x, TimeSpan iTimeDuration)
    {
      mTimeDuration = iTimeDuration;
      mBuffer = new LinkedList<TimeSerie<double>>();
      mValueStream = x.Select(Evaluate);
    }


    private TimeSerie<double> FastAverageAlgo(TimeSerie<double> x)
    {
      var wSumValue = new TimeSerie<double>();
      wSumValue.ElapsedTime = x.ElapsedTime;
      if (mBuffer.Count==0)
      {
        wSumValue.Value = x.Value;
        mBuffer.AddLast(wSumValue);
      }
      else
      {
        wSumValue.Value = mBuffer.Last.Value.Value+x.Value;
        mBuffer.AddLast(wSumValue);
      }
     /********/
      var wRet = new TimeSerie<double>();
      wRet.ElapsedTime = x.ElapsedTime;
      if (mBuffer.Last.Value.ElapsedTime.Seconds - mBuffer.First.Value.ElapsedTime.Seconds >= mTimeDuration.Seconds)
      {
     
        if (mBuffer.Last.Value.ElapsedTime.Seconds - mBuffer.First.Next.Value.ElapsedTime.Seconds >= mTimeDuration.Seconds)
        {
          wRet.Value = (mBuffer.Last.Value.Value - mBuffer.First.Value.Value) / (mBuffer.Count-1);
          mBuffer.RemoveFirst();
        }
        else
        {
          wRet.Value = mBuffer.Last.Value.Value  / mBuffer.Count;
        }
      }
      else
      {
        wRet.Value = double.NegativeInfinity;
      }
      return wRet;
    }

    private TimeSerie<double> SlowAverageAlgo(TimeSerie<double> x)
    {
      var wReturnValue = new TimeSerie<double>();
      wReturnValue.ElapsedTime = x.ElapsedTime;
      mBuffer.AddLast(x);
      if (mBuffer.Last.Value.ElapsedTime.Seconds - mBuffer.First.Value.ElapsedTime.Seconds >= mTimeDuration.Seconds)
      {
        int wCnt = 0;
        double wSum = 0; ;
        foreach (var wItem in mBuffer)
        {
          wSum += wItem.Value;
          wCnt++;
        }
        wReturnValue.Value = wSum / wCnt;
        if (mBuffer.Last.Value.ElapsedTime.Seconds - mBuffer.First.Next.Value.ElapsedTime.Seconds >= mTimeDuration.Seconds)
        {
          mBuffer.RemoveFirst();
        }
      }
      else
      {
        wReturnValue.Value = double.NegativeInfinity;
      }
      return wReturnValue;
    }
    protected virtual TimeSerie<double> Evaluate(TimeSerie<double> x)
    {
      return LastValue = FastAverageAlgo(x);
    }

  }
}
