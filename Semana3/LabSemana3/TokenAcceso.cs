using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSemana3
{
  public class TokenAcceso
  {
    public Guid Id { get; set; }
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public String Email { get; set; }
    public String Rol { get; set; }
    public Guid Token { get; set; }
  }
}