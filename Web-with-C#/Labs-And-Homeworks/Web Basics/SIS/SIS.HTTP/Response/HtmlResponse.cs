﻿namespace SIS.HTTP.Response
{
    using System.Text;

    using Enumerations;

    public class HtmlResponse : HttpResponse
    {
        public HtmlResponse(string html)
            : base()
        {
            this.StatusCode = HttpResponseCode.Ok;
            byte[] byteData = Encoding.UTF8.GetBytes(html);
            this.Body = byteData;
            this.Headers.Add(new Header("Content-Type", "text/html"));
            this.Headers.Add(new Header("Content-Length", this.Body.Length.ToString()));
        }
    }
}
