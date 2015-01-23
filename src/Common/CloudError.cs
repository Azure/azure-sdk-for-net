// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Hyak.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;

namespace Microsoft.Azure
{
    /// <summary>
    /// Provides additional information about an http error response
    /// </summary>
    public class CloudError : IDeserializationModel
    {
        /// <summary>
        /// The error code parsed from the body of the http error response
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The error message parsed from the body of the http error response
        /// </summary>
        public string Message { get; set; }

        public void DeserializeJson(JToken content)
        {
            string code = null;
            string message = null;
            var response = content as JObject;
            if (response.GetValue("error", StringComparison.CurrentCultureIgnoreCase) != null)
            {
                var errorToken =
                    response.GetValue("error", StringComparison.CurrentCultureIgnoreCase) as JObject;
                message = errorToken.GetValue("message", StringComparison.CurrentCultureIgnoreCase).ToString();
                code = errorToken.GetValue("code", StringComparison.CurrentCultureIgnoreCase).ToString();
            }
            else
            {
                message = response.GetValue("message", StringComparison.CurrentCultureIgnoreCase).ToString();
                code = response.GetValue("code", StringComparison.CurrentCultureIgnoreCase).ToString();
            }

            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("content");
            }
            this.Code = code;
            this.Message = message;

        }

        public void DeserializeXml(XContainer content)
        {
            string code = null;
            string message = null;
            var doc = content as XDocument;
            foreach (XElement element in doc.Root.Elements())
            {
                // Check local names only because some services will
                // use different namespaces or no namespace at all
                if ("Code".Equals(element.Name.LocalName, StringComparison.CurrentCultureIgnoreCase))
                {
                    code = element.Value;
                }
                else if ("Message".Equals(element.Name.LocalName, StringComparison.CurrentCultureIgnoreCase))
                {
                    message = element.Value;
                }
            }
            if (string.IsNullOrEmpty(code) && string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("content");
            }

            this.Code = code;
            this.Message = message;

        }
    }
}
