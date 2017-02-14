using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalsServiceLibary.Entity;

namespace MedicalsServiceLibary.Interfaces
{
    public interface IDoctors
    {
        Doctor GetDoctor(Guid doctorId);
        Doctor GetDoctor(string clientPhone);
        IEnumerable<Doctor> GetDoctorsBySpecialization(string specialization);
    }
    
}
