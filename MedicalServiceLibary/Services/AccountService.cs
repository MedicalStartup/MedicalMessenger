using DataLayer.MedicalDatabase;
using MedicalsServiceLibary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataLayer.StatusDatabase;
using MedicalServiceLibary.Exceptions;

namespace MedicalServiceLibary.Services
{
    public class AccountService : IAccount
    {
        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AutorizeResult Login(string login, string password)
        {
            try
            {
                CheckRegisterUser(login);
                CheckLoginPassword(login, password);
                SetStatusOnline(login);
                //LogingAuthintification(login);

                return new AutorizeResult("OK");
            }
            catch (AccountMedicalServiceException ex)
            {
                // TODO добавить логгирование
                throw;
            }
        }

        #region Login implimintation

        /// <summary>
        /// Запись лога аутинтификации.
        /// </summary>
        /// <param name="login"></param>
        private void LogingAuthintification(string login)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Проверка логина и пароля пользователя.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        private void CheckLoginPassword(string login, string password)
        {
            using (MedicalDataProvider dp = new MedicalDataProvider())
            {
                // Поиск аккаунта
                var userAccount = dp.Accounts.FirstOrDefault(i => i.phone_number == login);
                if (userAccount == null)
                    throw new AccountMedicalServiceException("User not registered");

                // Проверка пароля
                if (userAccount.password_hash != AccountHelper.Hash(password))
                    throw new AccountMedicalServiceException("User password is not correct.");

            }
        }

        /// <summary>
        /// Установть пользователю статус online.
        /// </summary>
        /// <param name="login"></param>
        private void SetStatusOnline(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new AccountMedicalServiceException("Incorrect login. Argument login is null or empty.");
            }

            using (StatusDataProvider db = new StatusDataProvider())
            {
                // Проверка, что пользователь не онлайн.
                if (db.OnlineUsers.Any(i => i.phone_number == login))
                    throw new NotImplementedException("User already logged in.");

                var user = db.OnlineUsers.Create();

                user.phone_number = login;
                user.connection_date = DateTime.Now;

                db.OnlineUsers.Add(user);

                db.SaveChanges();
            }


        }

        /// <summary>
        /// Проверка на наличия зарегистрированного пользователя в системе.
        /// </summary>
        /// <param name="login"></param>
        private void CheckRegisterUser(string login)
        {
            using (MedicalDataProvider dp = new MedicalDataProvider())
            {
                if (!dp.Accounts.Any(i => i.phone_number == login))
                    throw new AccountMedicalServiceException("User not registered");
            }
        }

        #endregion


        public AutorizeResult Logout(string login)
        {
            if (CheckIsUserOnline(login))
            {
                SetStatusOffline(login);
                return new AutorizeResult("OK");
            }
            else
                throw new AccountMedicalServiceException("User already offline");
        }

        private bool CheckIsUserOnline(string login)
        {
            using (StatusDataProvider db = new StatusDataProvider())
            {
                // Проверка, что пользователь не онлайн.
                return db.OnlineUsers.Any(i => i.phone_number == login);

            }
        }

        #region  Logout implimintation

        private void SetStatusOffline(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new AccountMedicalServiceException("Incorrect login. Argument login is null or empty.");
            }

            try
            {
                using (StatusDataProvider db = new StatusDataProvider())
                {
                    var user = db.OnlineUsers.First(i => i.phone_number == login);
                    db.OnlineUsers.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new AccountMedicalServiceException("Error setting ststus offline", ex);
            }

        }
        #endregion

        public RegisterResult Register(string login, string password)
        {
            try
            {
                CheckCorrectLogin(login);
                CheckCorrectPassword(password);

                CreateAccount(login, password);
                return new RegisterResult("OK");
            }
            catch (AccountMedicalServiceException ex)
            {
                // TODO добавить логгирование
                throw;
            }
        }



        #region Register implimintation
        private void CreateAccount(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Incorrect login or password.");
            }

            try
            {  
                using (var db = new MedicalDataProvider())
                {
                    if (db.Accounts.Any(i => i.phone_number == login))
                        throw new AccountMedicalServiceException("User already registered");

                    var newAccount = db.Accounts.Create();
                    newAccount.phone_number = login;
                    newAccount.password_hash = AccountHelper.Hash(password);

                    db.Accounts.Add(newAccount);

                    db.SaveChanges();
                }
            }
            catch (AccountMedicalServiceException ex)
            {
                // TODO добавть логгирование 
                throw;
            }
        }

        /// <summary>
        /// Проерка корректности логина.
        /// </summary>
        /// <param name="login"></param>
        private void CheckCorrectLogin(string login)
        {
            Regex regex = new Regex("[0-9]{11}");

            if (!regex.IsMatch(login))
                throw new AccountMedicalServiceException("User login has incorrect format. Example: 88005553535");

        }

        /// <summary>
        /// Проерка корректности пароля.
        /// </summary>
        /// <param name="password"></param>
        private void CheckCorrectPassword(string password)
        {
            const int MINLENGTHPASSWORD = 6;
            if (string.IsNullOrEmpty(password) && password.Length < MINLENGTHPASSWORD)
                throw new AccountMedicalServiceException("The password is not in the correct format. Example: Any string greater than 6 characters");
        }
        #endregion



        public void RequestChangePassword(string login)
        {
            throw new NotImplementedException();
        }

        #region RequestChangePassword implimintation

        #endregion

        public void ConfirmChangePassword(string login, string password, string confirmCode)
        {
            throw new NotImplementedException();
        }
        #region ConfirmChangePassword implimintation

        #endregion

    }


    class AccountHelper
    {
        public static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}
