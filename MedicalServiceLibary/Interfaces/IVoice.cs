using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс для полуения голосовой записи.
    /// </summary>
    interface IVoiceDataService
    {
        /// <summary>
        /// Получить аудиозапись по ID.
        /// </summary>
        /// <param name="voiceId"></param>
        /// <returns></returns>
        VoiceResult GetVoice(string voiceId);
    }

    public class VoiceResult
    {
        public string VoiceData { get; set; }
    }

}
