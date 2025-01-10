using Common.Utils.Resources;

using Proveedor.Models;

using Dominio.Servicio.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Dominio.Servicio.Servicios.Interfaces;
using Dominio.Servicio.Servicios;


namespace Proveedor.Controllers
{

    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginServices;

        public LoginController(ILoginService loginServices)
        {
            _loginServices = loginServices;

        }


        /// <summary>
        /// Login para obtener el Token
        /// </summary>
        /// <param name="user">Objeto User</param>
        /// <returns>El token</returns>

        [HttpPost("Autentication")]
        public async Task<IActionResult> Autentication(AutenticaDto user)
        {

            Task<AutenticationDto> result = _loginServices.autentication(user);

            ResponseModel<Task<AutenticationDto>> response = new ResponseModel<Task<AutenticationDto>>()
            {
                IsSuccess = result.Result.IsSuccess,
                Messages = result.Result.Messages,
                Result = result
            };

            return Ok(response);


        }
    }
}
