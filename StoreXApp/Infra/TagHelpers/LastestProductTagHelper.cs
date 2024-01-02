using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using System.Runtime.CompilerServices;

namespace StoreXApp.Infra.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("div", Attributes="products")]
   
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IManagerService _manager;

        [HtmlAttributeName("number")]
        public int Number { get; set; }

        public LastestProductTagHelper(IManagerService manager)
        {
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class", "my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class", "lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class", "bi bi-archive-fill text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");

            TagBuilder ul = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProducts(Number, false);
            foreach (Product product in products)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href",$"/product/get/{product.ProductName}");
                a.InnerHtml.AppendHtml(product.ProductName);
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }
         

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);
        }
    }
}
