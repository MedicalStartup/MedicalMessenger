using MedicalService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalServiceLibary.Exceptions;
using MedicalServiceLibary.Services;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Web;
using System.Web.Http.Results;

namespace MedicalService.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        #region Внутреняя кухня ASP.NET WebApi Authintification OWIN

        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // Ошибки ModelState для отправки отсутствуют, поэтому просто возвращается пустой BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion


        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                AccountService accountService = new AccountService();
                accountService.Register(model.PhoneLogin, model.Password);


                #region Кухня OAuthAutorization

#warning Внимание КОСТЫЛЬ! пришлось сделать так  "Email = model.PhoneLogin + "@loginphone", так как по другому не работает встроенная аутинтификация. Позже можно прикрутить другую, но пока так.
                var user = new ApplicationUser() { UserName = model.PhoneLogin, Email = model.PhoneLogin + "@loginphone" };

                IdentityResult result = UserManager.Create(user, model.Password);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                #endregion


                return Ok();
            }
            catch (AccountMedicalServiceException ex)
            {
                // TODO Добавить логгирование
                // Возвращаем ошибку с текстовым описанием.
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Войти в систему.
        /// </summary> 
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginModel login)
        {
            AccountService accountService = new AccountService();
            accountService.Login(login.PhoneLogin,login.Password);
            
            return Ok();
        }

        /// <summary>
        /// Выйти из системы.
        /// </summary>
        /// <param name="model"></param> 
        /// <returns></returns>
        [Route("Logout")]
        [HttpPost]
        public IHttpActionResult Logoff(LogoutModel phoneLogin)
        {
            AccountService accountService = new AccountService();
            accountService.Logout(phoneLogin.PhoneLogin);
            
            var authentication = this.Request.GetOwinContext().Authentication;
            authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            return Ok();
        }
    }
}
