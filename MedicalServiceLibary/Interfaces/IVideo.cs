using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс для получения видео.
    /// </summary>
    interface IVideoDataService
    {
        /// <summary>
        /// Получить видео по ID.
        /// </summary>
        /// <param name="videoId"></param>
        /// <returns></returns>
        VideoResult GetVideo(string videoId);
    }

    public class VideoResult
    {
        public string VideoData { get; set; }
    }
}
