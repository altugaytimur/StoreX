using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreXApp.Infra.Extensions;

namespace StoreXApp.Pages
{
    public class DemoModel : PageModel
    {
        public string? FullName => HttpContext?.Session?.GetString("name") ?? "";
     
        public void OnGet()
        {

        }
        public void OnPost([FromForm] string name)
        {
            //sessionda byte[], int ve string veri tiplerini tutabiliriz. Class tutmak için serialize etmek gerekir.
            HttpContext.Session.SetString("name", name);
           
        }
    }
}
