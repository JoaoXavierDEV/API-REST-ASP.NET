using ASPNET.Api.Controllers;
using ASPNET.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/NovosTestes")]
    public class NovosTesteController : MainController
    {
        public NovosTesteController(INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
        }
         
        [HttpGet]
        public string VersaoApi()
        {
            throw new Exception("We're done when I say we're done");
            // return "Disponível apenas na Versão v2\nDefault " + ApiVersion.Default  + "\nNeutral: " +ApiVersion.Neutral;
        }
    }
}
