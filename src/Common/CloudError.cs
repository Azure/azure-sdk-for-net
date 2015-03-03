// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;

namespace Microsoft.Azure
{
    /// <summary>
    /// Provides additional information about an http error response
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// Initializes a new instance of CloudError.
        /// </summary>
        public CloudError()
        { }

        /// <summary>
        /// Initializes a new instance of CloudError from a HTTP message content.
        /// </summary>
        /// <param name="content">HTTP message content</param>
        public CloudError(string content)
        {
            Deserialize(content);
        }

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
            JToken code = null;
            JToken message = null;
            var response = content as JObject;
            if (response != null)
            {
                if (response.GetValue("error", StringComparison.CurrentCultureIgnoreCase) != null)
                {
                    JToken errorToken;
                    response.TryGetValue("error", StringComparison.CurrentCultureIgnoreCase, out errorToken);
                    if (errorToken is JObject)
                    {
                        ((JObject)errorToken).TryGetValue("message", StringComparison.CurrentCultureIgnoreCase, out message);
                        ((JObject)errorToken).TryGetValue("code", StringComparison.CurrentCultureIgnoreCase, out code);
                    }
                }
                else
                {
                    response.TryGetValue("message", StringComparison.CurrentCultureIgnoreCase, out message);
                    response.TryGetValue("code", StringComparison.CurrentCultureIgnoreCase, out code);
                }
            }

            string codeString = null;
            string messageString = null;
            if (code != null && code.Type != JTokenType.Null)
            {
                codeString = code.ToString();
            }

            if (message != null && message.Type != JTokenType.Null)
            {
                messageString = message.ToString();
            }

            if (codeString == null && messageString == null)
            {
                throw new ArgumentException("content");
            }
            this.Code = codeString;
            this.Message = messageString;

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

        /// <summary>
        /// Try to parse an error response body as Json or Xml.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <returns>True if the model was successfully parsed, otherwise false</returns>
        public void Deserialize(string responseContent)
        {
            CloudError errorModel;
            if (!TryParseJsonModel(responseContent, out errorModel))
            {
                TryParseXmlModel(responseContent, out errorModel);   
            }

            if (string.IsNullOrEmpty(errorModel.Message))
            {
                errorModel.Message = errorModel.Code;
            }

            if (string.IsNullOrEmpty(errorModel.Message))
            {
                errorModel.Message = responseContent;
            }


            this.Code = errorModel.Code;
            this.Message = errorModel.Message;
        }

        /// <summary>
        /// Try to parse an error response body as Json.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <param name="errorModel">The model, if parsing was successful.</param>
        /// <returns>True if the content was successfully parsed, otherwise false.</returns>
        private bool TryParseJsonModel(string responseContent, out CloudError errorModel)
        {
            try
            {
                var jsonToken = JToken.Parse(responseContent);
                errorModel = new CloudError();
                errorModel.DeserializeJson(jsonToken);
                return true;
            }
            catch (Exception)
            {
            }

            errorModel = new CloudError();
            return false;
        }

        /// <summary>
        /// Try to parse an error response body as Xml.
        /// </summary>
        /// <param name="responseContent">The response body.</param>
        /// <param name="errorModel">The model, if parsing was successful.</param>
        /// <returns>True if the content was successfully parsed, otherwise false.</returns>
        private bool TryParseXmlModel(string responseContent, out CloudError errorModel)
        {
            try
            {
                var xmlDocument = System.Xml.Linq.XDocument.Parse(responseContent);
                errorModel = new CloudError();
                errorModel.DeserializeXml(xmlDocument);
                return true;
            }
            catch (Exception)
            {
            }

            errorModel = new CloudError();
            return false;
        }
    }
}
