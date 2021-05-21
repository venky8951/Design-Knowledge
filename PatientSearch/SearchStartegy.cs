using System.Collections.Generic;

namespace PatientContext
{
    public class SearchStartegy : ISearchStrategy
    {
        List<ISearchStrategy> searchStrategies = new List<ISearchStrategy>();
        public List<PatientDataModel> Search(List<PatientDataModel> items)
        {
            List<PatientDataModel> result = new List<PatientDataModel>();
            foreach (var strategy in searchStrategies)
            {
                foreach(var item in strategy.Search(items))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public void Add(ISearchStrategy strategy)
        {
            searchStrategies.Add(strategy);
        }
        public void Remove(ISearchStrategy strategy)
        {
            searchStrategies.Remove(strategy);
        }
    }
}
