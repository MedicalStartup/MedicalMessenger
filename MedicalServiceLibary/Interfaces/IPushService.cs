using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс получения уведомлений.
    /// </summary>
    interface IPushService
    {
        /// <summary>
        /// События поступления нового уведомления.
        /// </summary>
        event PushServiceHandler OnNewNotification;
    }

    /// <summary>
    /// Делегат для сервиса уведомлений.
    /// </summary>
    /// <param name="args"></param>
    public delegate void PushServiceHandler(PushServiceEventArgs args);
    public class PushServiceEventArgs : EventArgs
    {
        /// <summary>
        /// Сообщение и сопутсвующая информация.
        /// </summary>
        public string PushServiceData { get; set; }
    }
}
