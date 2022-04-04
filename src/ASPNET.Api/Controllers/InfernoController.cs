using ASPNET.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Api.Controllers
{
    [Route("api/v{version:apiVersion}/Inferno")]
    public class InfernoController : MainController
    {
        public InfernoController(INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
        }
        [HttpGet]
        public int Inferno()
        {
            return 1;
        }
    }
}
