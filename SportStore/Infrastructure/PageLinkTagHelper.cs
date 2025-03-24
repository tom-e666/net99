using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportStore.Models.ViewModels;

namespace SportStore.Infrastructure;
[HtmlTargetElement("div", Attributes = "page-model, page-action")]

public class PageLinkTagHelper : TagHelper
{
    private IUrlHelperFactory _urlHelperFactory;

    public PageLinkTagHelper(IUrlHelperFactory helperFactory)
    {
        _urlHelperFactory = helperFactory;
    }

    [ViewContext] [HtmlAttributeNotBound] public ViewContext? ViewContext { get; set; }
    public PagingInfo? PageModel { get; set; }
    public string? PageAction { get; set; }
    public bool PageClassesEnabled { get; set; } = false;
    public string PageClass { get; set; } = string.Empty;
    public string PageClassNormal { get; set; } = string.Empty;
    public string PageClassSelected { get; set; } = string.Empty;
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ViewContext != null && PageModel != null)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.Attributes["href"] = urlHelper.Action(new UrlActionContext{Action=PageAction,Values= new {productPage=i}});;
                tagBuilder.InnerHtml.Append(i.ToString());
                if (PageClassesEnabled == true)
                {
                    tagBuilder.AddCssClass(PageClass);
                    tagBuilder.AddCssClass(i==PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    tagBuilder.InnerHtml.AppendHtml(i.ToString());
                }
                result.InnerHtml.AppendHtml(tagBuilder);
            }

            
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}