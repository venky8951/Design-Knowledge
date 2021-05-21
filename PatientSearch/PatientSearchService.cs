using System;
using System.Collections.Generic;
using System.Text;

namespace PatientContext
{
    public class PatientSearchService
    {
        IPatientDataRepository _repo;
        public PatientSearchService(IPatientDataRepository repo)
        {
            this._repo = repo;
        }
        public List<PatientDataModel> Search(ISearchStrategy strategy)
        {
            return strategy.Search(new List<PatientDataModel>());
        }
    }
}
