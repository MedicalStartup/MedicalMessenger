using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс для получения и управления историей сообщений.
    /// </summary>
    public interface IHistory
    {
        /// <summary>
        /// Получить историю сообщений.
        /// </summary>
        /// <param name="userPhone">Телефон или ID пользователя.</param>
        /// <param name="startDate">Начальная дата, от которой берется история.</param>
        /// <param name="deeph">Количество сообщений, которые берутся от начальной даты.</param>
        /// <returns>История сообщений.</returns>
        HistoryResult GetMessageHistory(string userPhone, DateTime startDate, int deeph);
    }

    public class HistoryResult
    {
        public string HistoryData { get; set; }
    }
}
