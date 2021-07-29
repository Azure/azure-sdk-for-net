// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class WebPubSubConnection
    {
        public WebPubSubConnection(Uri url)
        {
            Url = url.AbsoluteUri;
            BaseUrl = $"{url.Scheme}://{url.Authority}{url.AbsolutePath}";
            AccessToken = HttpUtility.ParseQueryString(url.Query)["access_token"];
        }

        public string BaseUrl { get;}

        public string Url { get;}

        public string AccessToken { get;}
    }
}
