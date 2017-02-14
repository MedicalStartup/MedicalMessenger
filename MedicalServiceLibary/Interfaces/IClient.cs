using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalsServiceLibary.Entity;

namespace MedicalsServiceLibary.Interfaces
{
    public interface IClient
    {
        Client GetClient(Guid clientId);
        Client GetClient(string clientPhone);
    }
}