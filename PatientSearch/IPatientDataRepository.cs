using System;
using System.Collections.Generic;
using System.Text;

namespace PatientContext
{
    public interface IPatientDataRepository
    {
        void Create();
        void Delete();
    }
}
