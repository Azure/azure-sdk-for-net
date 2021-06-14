// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    internal sealed class UriQueryParamsCollection : Dictionary<string, string>
    {
        public UriQueryParamsCollection() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <summary>
        /// Takes encoded query params string, output decoded params map
        /// </summary>
        /// <param name="encodedQueryParamString"></param>
		public UriQueryParamsCollection(string encodedQueryParamString)
        {
            encodedQueryParamString = encodedQueryParamString ?? throw Errors.ArgumentNull(nameof(encodedQueryParamString));

            if (encodedQueryParamString.StartsWith("?", true, CultureInfo.InvariantCulture))
            {
                encodedQueryParamString = encodedQueryParamString.Substring(1);
            }

            var keysAndValues = encodedQueryParamString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var qp in keysAndValues)
            {
                var keyAndValue = qp.Split(new[] { '=' }, 2);
                if (keyAndValue.Length == 1)
                {
                    Add(WebUtility.UrlDecode(keyAndValue[0]), default); // The map's keys/values are url-decoded
                }
                else
                {
                    Add(WebUtility.UrlDecode(keyAndValue[0]), WebUtility.UrlDecode(keyAndValue[1])); // The map's keys/values are url-decoded
                }
            }
        }

        // Returns the url-encoded query parameter string
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, string> kv in this)
            {
                if (sb.Length > 0)
                {
                    sb.Append('&');
                }

                sb.Append(WebUtility.UrlEncode(kv.Key)).Append('=').Append(WebUtility.UrlEncode(kv.Value));   // Query param strings are url-encoded
            }
            return sb.ToString();
        }
    }
}
