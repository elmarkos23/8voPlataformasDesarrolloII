using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace LabSemana2.Pages
{
  public class IndexModel : PageModel
  {
    public string Time { get; set; }
    public void OnGet()
    {
      Time = DateTime.Now.ToString("dd/MM/yyyy");
    }
  }
}
