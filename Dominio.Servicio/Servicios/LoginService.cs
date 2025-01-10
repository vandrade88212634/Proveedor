using Common.Utils.Resources;
using Common.Utils.Utils.Interface;
using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios.Interfaces;
using EnviaMail;

using Infraestructura.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicio.Servicios
{
    public  class LoginService: ILoginService
    {

        #region Members
        //  private readonly ISecurityService securityService;
        //private readonly IRestService restService;
       
        private readonly IUtils utils;
        private readonly ITokenService tokenService;
        //private readonly IAuthService AuthService;

        #endregion Members
        #region Builder
        public LoginService(

              IUtils utils, ITokenService tokenService)
        {


            
            this.utils = utils;
            this.tokenService = tokenService;

        }

        public async Task<AutenticationDto> autentication(AutenticaDto autenticado)
        {
            AutenticationDto autenticacion = new AutenticationDto();

   
            autenticacion.usuario = "Prueba";
            autenticacion.Nombre = "Prueba";
            autenticacion.idUser = 0;
          
            autenticacion.IsSuccess = true;
            autenticacion.Messages = GeneralMessages.SussefullyProcess;
            autenticacion.cedula = 999;


            autenticacion.Token = this.tokenService.GetToken(autenticacion);

    
           



            return autenticacion;
        }
       

        #endregion Builder



    }
}
