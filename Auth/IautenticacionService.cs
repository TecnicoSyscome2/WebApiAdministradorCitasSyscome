using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApi.Citas.Administrador.Modelos;

namespace WebApi.Citas.Administrador.Auth
{
    public interface IautenticacionService
    {
        string Authenticate(userModel pUsuario);
    }
}
