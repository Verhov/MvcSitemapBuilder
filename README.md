MvcSitemapBuilder (C#)
====================

Building XML Sitemap in Asp .Net Mvc Applications.


Usage
-----------
```
using MvcSitemapBuilder;

public ActionResult Sitemap()
{
    SitemapBuilder builder = new SitemapBuilder();
    
    builder.AppendUrl(Url.Action("Index", "Home", null, this.Request.Url.Scheme), ChangefreqEnum.weekly);
    builder.AppendUrl(Url.Action("About", "Home", null, this.Request.Url.Scheme));
    builder.AppendUrl("http://example.com/Home/Contact", ChangefreqEnum.never, 0.9d);

return new XmlViewResult(builder.XmlDocument);
}
```


Example
-----------
Code:
<img src="https://github.com/Verhov/MvcSitemapBuilder/blob/master/sitemap_builder_example.png?raw=true" />

Result:
<img src="https://github.com/Verhov/MvcSitemapBuilder/blob/master/sitemap_builder_result.png?raw=true" />

Attention
-----------
 - Provided "AS IS", under MIT License.
 - Without support of exceeding 50,000 entries and size of 10 MB (use Sitemap index files: http://www.sitemaps.org/protocol.html#index).

Tips
-----------
The location of the sitemap can also be included in the robots.txt file:
```
User-agent: *
Disallow:

Sitemap: http://example.com/Home/Sitemap
```

**Protocol specification**: http://www.sitemaps.org/protocol.html

**Home website**: http://michael.verhov.com/en/post/asp_mvc_sitemap_builder

The MIT License (MIT)
-----------
Copyright (c) 2014 michael verhov

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
