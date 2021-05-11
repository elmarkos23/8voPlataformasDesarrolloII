using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabSemana3
{
  public class CabeceraSoapToken
  {
    public string Token { get; set; }
    public bool validaTokenAcceso(string tokenAcceso)
    {
      if (!string.IsNullOrEmpty(tokenAcceso))
      {
        TokenAcceso _tokenAcceso = HttpRuntime.Cache[tokenAcceso] as TokenAcceso;
        if (_tokenAcceso?.Token.ToString() == tokenAcceso)
          return true;
        else
          return false;
      }
      else
        return false;
    }
  }
}