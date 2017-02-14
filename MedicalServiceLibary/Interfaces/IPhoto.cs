using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    interface IPhotoDataService
    {
        PhotoResult GetPhoto(string photoId);
    }

    public class PhotoResult
    {
        public string PhotoData { get; set; }
    }
}
