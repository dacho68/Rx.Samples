using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace ConsoleApp.Modules
{
  public class ConverterGate : LogicalGate
  {
     private IObservable<TimeSerie<double>>[] mInputs;
     public ConverterGate(IObservable<TimeSerie<double>>[] iInputs)
      : base()
    {
      mInputs = iInputs;
      SetupInputList(iInputs);
    }
    /// <summary>
    /// This the generic multiple inputs
    /// </summary>
    /// <param name="iParams"></param>
    private void SetupInputList(IObservable<TimeSerie<double>>[] iParams)
    {
      //// IObservable<TResult> CombineLatest<TSource, TResult>(IEnumerable<IObservable<TSource>> sources, Func<IList<TSource>, TResult> resultSelector);
      ////var o = new Subject<TimeSerie<bool>>();
      //var wList = new List<IObservable<TimeSerie<double>>>();
      //wList.AddRange(iParams);
      ////o.CombineLatest()

      mValueStream = iParams.CombineLatest<TimeSerie<double>, TimeSerie<bool>>(ResultSelector);


    }

    private TimeSerie<bool> ResultSelector(IList<TimeSerie<double>> timeSeries)
    {
      throw new NotImplementedException();
    }

  }
}
