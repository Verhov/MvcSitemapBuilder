using System;
using System.Xml;

namespace MvcSitemapBuilder
{
    /// <summary>
    /// Xml Sitemap builder.
    /// Attention: Without support of exceeding 50,000 entries and size of 10 MB.
    /// </summary>
    public class SitemapBuilder
    {
        #region fields, constructor
        private const string SITEMAP_NAMESPACE = "http://www.sitemaps.org/schemas/sitemap/0.9"; // Protocol: http://www.sitemaps.org/protocol.html
        private const string DATETIME_PATTERN = "yyyy-MM-ddTHH:mm:sszzz";                       // W3.org (http://www.w3.org/TR/NOTE-datetime) pattern: YYYY-MM-DDThh:mm:ssTZD
        private XmlDocument _doc;

        /// <summary>
        /// Gets Sitemap XmlDocument
        /// </summary>
        public XmlDocument XmlDocument
        {
            get { return _doc; }
        }

        /// <summary>
        /// New instance of Sitemap builder
        /// </summary>
        public SitemapBuilder()
        {
            _doc = new XmlDocument();

            // declaration
            XmlDeclaration xmldecl;
            xmldecl = _doc.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "UTF-8";
            _doc.AppendChild(xmldecl);

            // root document node
            _doc.AppendChild(_doc.CreateElement("urlset", SITEMAP_NAMESPACE));
        } 
        #endregion


        /// <summary>
        /// Append new Url into Sitemap.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        public void AppendUrl(string loc)
        {
            _doc.DocumentElement.AppendChild(CreateUrlElement(loc));
        }


        /// <summary>
        /// Append new Url into Sitemap with last modification date.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="lastmod">The date of last modification of the file.</param>
        public void AppendUrl(string loc, DateTime lastmod)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateLastmodElement(lastmod));

            _doc.DocumentElement.AppendChild(url_node);
        }

        /// <summary>
        /// Append new Url into Sitemap with refresh rate.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="changefreq">How frequently the page is likely to change.</param>
        public void AppendUrl(string loc, ChangefreqEnum changefreq)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateChangefreqElement(changefreq));

            _doc.DocumentElement.AppendChild(url_node);
        }

        /// <summary>
        /// Append new Url into Sitemap with priority.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="priority">The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0.</param>
        public void AppendUrl(string loc, double priority)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreatePriorityElement(priority));

            _doc.DocumentElement.AppendChild(url_node);
        }



        /// <summary>
        /// Append new Url into Sitemap with last modification date and refresh rate.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="lastmod">The date of last modification of the file.</param>
        /// <param name="changefreq">How frequently the page is likely to change.</param>
        public void AppendUrl(string loc, DateTime lastmod, ChangefreqEnum changefreq)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateLastmodElement(lastmod));
            url_node.AppendChild(CreateChangefreqElement(changefreq));

            _doc.DocumentElement.AppendChild(url_node);
        }

        /// <summary>
        /// Append new Url into Sitemap with last modification date and priority.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="lastmod">The date of last modification of the file.</param>
        /// <param name="priority">The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0.</param>
        public void AppendUrl(string loc, DateTime lastmod, double priority)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateLastmodElement(lastmod));
            url_node.AppendChild(CreatePriorityElement(priority));

            _doc.DocumentElement.AppendChild(url_node);
        }

        /// <summary>
        /// Append new Url into Sitemap with refresh rate and priority.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="changefreq">How frequently the page is likely to change.</param>
        /// <param name="priority">The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0.</param>
        public void AppendUrl(string loc, ChangefreqEnum changefreq, double priority)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateChangefreqElement(changefreq));
            url_node.AppendChild(CreatePriorityElement(priority));

            _doc.DocumentElement.AppendChild(url_node);
        }



        /// <summary>
        /// Append new Url into Sitemap with refresh rate, priority and last modification date.
        /// </summary>
        /// <param name="loc">URL of the page.</param>
        /// <param name="changefreq">How frequently the page is likely to change.</param>
        /// <param name="priority">The priority of this URL relative to other URLs on your site. Valid values range from 0.0 to 1.0.</param>
        /// <param name="lastmod">The date of last modification of the file.</param>
        public void AppendUrl(string loc, ChangefreqEnum changefreq, double priority, DateTime lastmod)
        {
            XmlElement url_node = CreateUrlElement(loc);
            url_node.AppendChild(CreateChangefreqElement(changefreq));
            url_node.AppendChild(CreatePriorityElement(priority));
            url_node.AppendChild(CreateLastmodElement(lastmod));

            _doc.DocumentElement.AppendChild(url_node);
        }



        #region helpers
        private XmlElement CreateUrlElement(string loc)
        {
            XmlElement url_node = _doc.CreateElement("url", SITEMAP_NAMESPACE);
            XmlElement loc_node = _doc.CreateElement("loc", SITEMAP_NAMESPACE);

            loc_node.InnerText = loc;
            url_node.AppendChild(loc_node);

            return url_node;
        }
        private XmlElement CreateLastmodElement(DateTime lastmod)
        {
            XmlElement lastmod_node = _doc.CreateElement("lastmod", SITEMAP_NAMESPACE);
            lastmod_node.InnerText = lastmod.ToString(DATETIME_PATTERN);
            return lastmod_node;
        }
        private XmlElement CreateChangefreqElement(ChangefreqEnum changefreq)
        {
            XmlElement changefreq_node = _doc.CreateElement("changefreq", SITEMAP_NAMESPACE);
            changefreq_node.InnerText = changefreq.ToString();
            return changefreq_node;
        }
        private XmlElement CreatePriorityElement(double priority)
        {
            XmlElement changefreq_node = _doc.CreateElement("priority", SITEMAP_NAMESPACE);
            changefreq_node.InnerText = priority.ToString(System.Globalization.CultureInfo.InvariantCulture);
            return changefreq_node;
        }
        #endregion
    }
}