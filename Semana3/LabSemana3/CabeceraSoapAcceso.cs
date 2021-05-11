using System;
namespace LabSemana3
{
  public class CabeceraSoapAcceso : System.Web.Services.Protocols.SoapHeader
  {
    public string Usuario { get; set; }
    public string Password { get; set; }
    public TokenAcceso validarUsuario(String usuario, String password)
    {
      if (usuario.ToLower() == "admin" && password.ToLower() == "admin")
      {
        TokenAcceso tokenAcceso = new TokenAcceso()
        {
          Id = Guid.NewGuid(),
          Nombre = "Marco",
          Apellido = "Ayala",
          Email = "elmarkos23@gmail.com",
          Rol = "Administrador",
          Token = Guid.NewGuid()
        };
        return tokenAcceso;
      }
      else
      {
        return null;
      }
    }
  }
}