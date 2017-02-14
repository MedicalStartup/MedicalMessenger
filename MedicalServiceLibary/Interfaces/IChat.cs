using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MedicalsServiceLibary.Interfaces
{
    interface IChat
    {
        /// <summary>
        /// Отправить сообщение.
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="receivingPhone">Номер телефона или ID пользовтеля.</param>
        /// <returns>Статус отправки.</returns>
        string Send(string message, string receivingPhone);

        /// <summary>
        /// Сообщить о начале набора сообщения.
        /// </summary>
        /// <returns>Статусное сообщение.</returns>
        void ReportTypingStatus();

        /// <summary>
        /// Событие прихода сообщения.
        /// </summary>
        event MessageReciveHandler OnMessageRecive;

        // <summary>
        //
        // </summary>
        // event StatusChangedHandler OnStatusChanged;

        /// <summary>
        /// Событие начала набора сообщения.
        /// </summary>
        event MessageReciveHandler OnTyping;
    }

    #region Обертка для ответов

    public enum Status
    {
        Online,
        Offline
    }

    #endregion

    #region Делегаты событий

    /// <summary>
    /// делегат для события приёма сообщения
    /// </summary>
    /// <param name="args">Аргументы с сообщением.</param>
    public delegate void MessageReciveHandler(MessageReciveEventArgs args);

    public class MessageReciveEventArgs : EventArgs
    {
        /// <summary>
        /// Сообщение и сопутсвующая информация.
        /// </summary>
        public string MessageData { get; set; }
    }

    /// <summary>
    /// делегат для события изменения статуса.
    /// </summary>
    /// <param name="args">Аргументы с сообщением.</param>
    public delegate void StatusChangedHandler(StatusChangedEventArgs args);

    public class StatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Информация о изменении статуса.
        /// </summary>
        public string StatusData { get; set; }
    }
    

    /// <summary>
    /// Делегат для события изменения статуса.
    /// </summary>
    /// <param name="args">Аргументы с сообщением.</param>
    public delegate void TypingHandler(TypingEventArgs args);


    public class TypingEventArgs : EventArgs
    {
        /// <summary>
        /// Флаг набора сообщения удаленного пользователя.
        /// </summary>
        public bool IsTyping { get; set; }

        public string TypingData { get; set; }
    }


    #endregion
}
