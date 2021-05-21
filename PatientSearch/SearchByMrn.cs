using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientContext
{
    public class SearchByMrn : ISearchStrategy
    {
        public string MrnKey;
        public List<PatientDataModel> Search(List<PatientDataModel> items)
        {
            return items.Where(x => x.MRN == MrnKey).ToList();
        }
    }
}
