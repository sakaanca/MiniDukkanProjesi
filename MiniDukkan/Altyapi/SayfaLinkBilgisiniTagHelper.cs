using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MiniDukkan.Models.ViewModels;
using System.Collections.Generic;

namespace MiniDukkan.Altyapi
{
    [HtmlTargetElement("div", Attributes = "sayfa-model")]
    public class SayfaLinkBilgisiniTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public SayfaLinkBilgisiniTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public SayfalamaBilgi SayfaModel { get; set; }
        public string SayfaAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
        = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder sonuc = new TagBuilder("div");
            for (int i = 1; i <= SayfaModel.ToplamSayfalar; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["urunSayfa"] = i;
                tag.Attributes["href"] = urlHelper.Action(SayfaAction, PageUrlValues);
                tag.Attributes["href"] = urlHelper.Action(SayfaAction, new { urunSayfa = i });
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == SayfaModel.GuncelSayfa ? PageClassSelected : PageClassNormal);

                }
                tag.InnerHtml.Append(i.ToString());
                sonuc.InnerHtml.AppendHtml(tag);

            }
            output.Content.AppendHtml(sonuc.InnerHtml);
        }


    }
}
