using System.Collections.Generic;

namespace PatientContext
{
    public interface ISearchStrategy
    {
        List<PatientDataModel> Search(List<PatientDataModel> items);
    }
}
