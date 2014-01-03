using System.Xml;
using System.Web.Mvc;

namespace MvcSitemapBuilder
{
    /// <summary>
    /// Returns XML an result
    /// </summary>
    public class XmlViewResult : ActionResult
    {
        private XmlDocument _doc { get; set; }
        public XmlViewResult(XmlDocument doc) { this._doc = doc; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/xml";
            context.HttpContext.Response.ContentEncoding = System.Text.Encoding.UTF8;
            using (XmlWriter xml = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                _doc.WriteTo(xml);
            }
        }
    }
}
