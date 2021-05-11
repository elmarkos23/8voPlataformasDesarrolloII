using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace LabSemana3
{
  /// <summary>
  /// Descripción breve de ClienteWS
  /// </summary>
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
  // [System.Web.Script.Services.ScriptService]
  public class ClienteWS : System.Web.Services.WebService
  {
    private List<Cliente> clientes;
    public CabeceraSoapAcceso cabeceraSoapAcceso;
    public CabeceraSoapToken cabeceraSoapToken;
    public ClienteWS()
    {
      clientes = new List<Cliente>{
      new Cliente(){ IdCliente=1,Nombre="Marco",Empresa="GEMA",Mail="elmarkos23@gmail.com",Telefono="0932827829" },
      new Cliente(){ IdCliente=2,Nombre="Maria",Empresa="EnGLISH KIDS",Mail="belen@gmail.com",Telefono="0987654321" }
    };
    }
    [WebMethod]
    [SoapHeader("cabeceraSoapAcceso")]
    public TokenAcceso GetTokenAcceso()
    {
      string usuario;
      string password;
      string token = string.Empty;
      TokenAcceso tokenAcceso;
      if (cabeceraSoapAcceso == null || string.IsNullOrEmpty(cabeceraSoapAcceso?.Usuario) || string.IsNullOrEmpty(cabeceraSoapAcceso?.Password))
      {
        throw new SoapException("Acceso no Autorizado", SoapException.ClientFaultCode, new Exception(@"ERROR"));
      }
      else
      {
        usuario = cabeceraSoapAcceso.Usuario;
        password = cabeceraSoapAcceso.Password;
      }
      tokenAcceso = cabeceraSoapAcceso.validarUsuario(usuario, password);
      if (token != null)
      {
        tokenAcceso.Token = Guid.NewGuid();
        HttpRuntime.Cache.Add(tokenAcceso.Token.ToString(), tokenAcceso, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(2), System.Web.Caching.CacheItemPriority.NotRemovable, null);
      }
      else
      {
        throw new SoapException("Error", SoapException.ClientFaultCode, new Exception(@"ERROR"));
      }
      if (!string.IsNullOrEmpty(tokenAcceso.Token.ToString()))
      {
        return tokenAcceso;
      }
      else
      {
        return null;
      }
    }
  }
}
