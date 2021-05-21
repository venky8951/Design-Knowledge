using System.Collections.Generic;
using System.Linq;

namespace PatientContext
{
    public class SearchByName : ISearchStrategy
    {
        public string Name;
        public List<PatientDataModel> Search(List<PatientDataModel> items)
        {
            return items.Where(x => x.Name == Name).ToList();
        }
    }
}
