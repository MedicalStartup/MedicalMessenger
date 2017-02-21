namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс управления аккаунтом: аутинтификация, регистрация, 
    /// </summary>
    public interface IAccount
    {
        AutorizeResult Login(string login, string password);
        AutorizeResult Logout(string login);
        RegisterResult Register(string login, string password);

       /// <summary>
       /// Запрос на изменение пароля. (В результате высылается СМС с паролем)
       /// </summary>
       /// <param name="login"></param>
        void RequestChangePassword(string login);

        /// <summary>
        /// Подтверждение изменения пароля.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="confirmCode"></param>
        void ConfirmChangePassword(string login, string password, string confirmCode);

    }

    public class AutorizeResult
    {
        public AutorizeResult(string status)
        {
            AutorizeData = "";
            Status = status;
        }

        public string Status { get; private set; }

        public string AutorizeData { get; set; }
    }

    public class RegisterResult
    {
        public RegisterResult(string status)
        {
            RegisterData = "";
            Status = status;
        }

        public string Status { get; private set; }
        public string RegisterData { get; set; }
    }

}