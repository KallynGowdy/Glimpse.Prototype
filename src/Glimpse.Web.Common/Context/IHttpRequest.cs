﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Glimpse.Web
{ 
    public interface IHttpRequest
    {
        Stream Body { get; }

        string Accept { get; }

        string Method { get; }

        string RemoteIpAddress { get; }

        int? RemotePort { get; }

        bool IsLocal { get; }

        string Scheme { get; }

        string Host { get; }

        string PathBase { get; }

        string Path { get; }

        string QueryString { get; }

        string GetQueryString(string key);

        IList<string> GetQueryStringValues(string key);

        string GetHeader(string key);

        IList<string> GetHeaderValues(string key);

        IEnumerable<string> HeaderKeys { get; }

        string GetCookie(string key);

        IList<string> GetCookieValues(string key);

        IEnumerable<string> CookieKeys { get; }
    } 
}