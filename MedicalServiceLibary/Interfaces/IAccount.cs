namespace MedicalsServiceLibary.Interfaces
{
    /// <summary>
    /// Интерфейс управления аккаунтом: аутинтификация, регистрация, 
    /// </summary>
    public interface IAccount
    {
        AutorizeResult Login(string login, string password);
        AutorizeResult Logout();
        string Register(string registerModel);
    }

    public class AutorizeResult
    {
        public string AutorizeData { get; set; }
    }

    public class RegisterResult
    {
        public string AutorizeData { get; set; }
    }

}