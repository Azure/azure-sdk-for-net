// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal sealed class UriQueryParamsCollection : Dictionary<string, string>
    {
        public UriQueryParamsCollection() : base(StringComparer.OrdinalIgnoreCase) { }

        /// <summary>
        /// Takes encoded query params string, output decoded params map.
        /// </summary>
        /// <param name="encodedQueryParamString"></param>
		public UriQueryParamsCollection(string encodedQueryParamString)
        {
            Argument.AssertNotNull(encodedQueryParamString, nameof(encodedQueryParamString));

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
                if (kv.Value != null)
                {
                    sb.Append(WebUtility.UrlEncode(kv.Key)).Append('=').Append(WebUtility.UrlEncode(kv.Value));   // Query param strings are url-encoded
                }
            }
            return sb.ToString();
        }
    }
}
