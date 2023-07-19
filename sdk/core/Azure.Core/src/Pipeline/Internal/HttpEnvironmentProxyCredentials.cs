// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://raw.githubusercontent.com/dotnet/corefx/master/src/System.Net.Http/src/System/Net/Http/SocketsHttpHandler/HttpEnvironmentProxy.cs

#nullable disable

using System;
using System.Net;

namespace Azure.Core.Pipeline
{
    internal sealed class HttpEnvironmentProxyCredentials : ICredentials
    {
        // Wrapper class for cases when http and https have different authentication.
        private readonly NetworkCredential _httpCred;
        private readonly NetworkCredential _httpsCred;
        private readonly Uri _httpProxy;
        private readonly Uri _httpsProxy;

        public HttpEnvironmentProxyCredentials(Uri httpProxy, NetworkCredential httpCred,
                                               Uri httpsProxy, NetworkCredential httpsCred)
        {
            _httpCred = httpCred;
            _httpsCred = httpsCred;
            _httpProxy = httpProxy;
            _httpsProxy = httpsProxy;
        }

        public NetworkCredential GetCredential(Uri uri, string authType)
        {
            if (uri == null)
            {
                return null;
            }
            return uri.Equals(_httpProxy) ? _httpCred :
                   uri.Equals(_httpsProxy) ? _httpsCred : null;
        }

        public static HttpEnvironmentProxyCredentials TryCreate(Uri httpProxy, Uri httpsProxy)
        {
            NetworkCredential httpCred = null;
            NetworkCredential httpsCred = null;

            if (httpProxy != null)
            {
                httpCred = GetCredentialsFromString(httpProxy.UserInfo);
            }
            if (httpsProxy != null)
            {
                httpsCred = GetCredentialsFromString(httpsProxy.UserInfo);
            }
            if (httpCred == null && httpsCred == null)
            {
                return null;
            }
            return new HttpEnvironmentProxyCredentials(httpProxy, httpCred, httpsProxy, httpsCred);
        }

        /// <summary>
        /// Converts string containing user:password to NetworkCredential object.
        /// </summary>
        private static NetworkCredential GetCredentialsFromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            value = Uri.UnescapeDataString(value);

            string password = "";
            string domain = null;
            int idx = value.IndexOfOrdinal(':');
            if (idx != -1)
            {
                password = value.Substring(idx + 1);
                value = value.Substring(0, idx);
            }

            idx = value.IndexOfOrdinal('\\');
            if (idx != -1)
            {
                domain = value.Substring(0, idx);
                value = value.Substring(idx + 1);
            }

            return new NetworkCredential(value, password, domain);
        }
    }
}
