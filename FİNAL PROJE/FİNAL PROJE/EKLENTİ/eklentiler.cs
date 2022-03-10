using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FİNAL_PROJE.EKLENTİ
{
    public static class eklentiler
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string text, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("button")
            {
                InnerHtml = text
            };

            tagBuilder.MergeAttribute("type", "submit");

            tagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}