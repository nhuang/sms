using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FVTS.KendoHtmlHelp
{
    public static class UIHelper
    {
        public static MvcHtmlString Email(this HtmlHelper helper, string name)
        {
            var builer = new TagBuilder("input");
            builer.MergeAttribute("type", "email");
            builer.MergeAttribute("id", name);
            builer.MergeAttribute("name", name);
            builer.MergeAttribute("class", "k-textbox");
            builer.MergeAttribute("placeholder", "e.g. myname@example.net");
            builer.MergeAttribute("data-email-msg", "Email format is not valid");
            return MvcHtmlString.Create(builer.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString EmailFor(this HtmlHelper helper, string name, string value)
        {
            var builer = new TagBuilder("input");
            builer.MergeAttribute("type", "email");
            builer.MergeAttribute("id", name);
            builer.MergeAttribute("name", name);
            builer.MergeAttribute("value", value);
            builer.MergeAttribute("class", "k-textbox");
            builer.MergeAttribute("placeholder", "e.g. myname@example.net");
            builer.MergeAttribute("data-email-msg", "Email format is not valid");
            return MvcHtmlString.Create(builer.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString Phone(this HtmlHelper helper, string name)
        {
            var builer = new TagBuilder("input");
            builer.MergeAttribute("type", "tel");
            builer.MergeAttribute("id", name);
            builer.MergeAttribute("name", name);
            builer.MergeAttribute("class", "k-textbox");
            builer.MergeAttribute("pattern", "[\\(]\\d{3}[\\)]\\d{3}[\\-]\\d{4}");
            builer.MergeAttribute("placeholder", "Please enter a ten digit phone number");
            builer.MergeAttribute("data-email-msg", "Please enter a ten digit phone number");
            return MvcHtmlString.Create(builer.ToString(TagRenderMode.SelfClosing));
        }
         public static MvcHtmlString PhoneFor(this HtmlHelper helper, string name, string value)
        {
            var builer = new TagBuilder("input");
            builer.MergeAttribute("type", "tel");
            builer.MergeAttribute("id", name);
            builer.MergeAttribute("name", name);
            builer.MergeAttribute("value", value);
            builer.MergeAttribute("class", "k-textbox");
            builer.MergeAttribute("pattern", "[\\(]\\d{3}[\\)]\\d{3}[\\-]\\d{4}");
            builer.MergeAttribute("placeholder", "Please enter a ten digit phone number");
            builer.MergeAttribute("data-email-msg", "Please enter a ten digit phone number");
            return MvcHtmlString.Create(builer.ToString(TagRenderMode.SelfClosing));
        }
    }
}