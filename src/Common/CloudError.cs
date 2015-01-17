//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;

namespace Microsoft.Azure
{
    public class CloudError
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public static bool TryParseJsonOrXml(string content, out CloudError error)
        {
            return TryParseJsonError(content, out error) || TryParseXmlError(content, out error);
        }

        private static bool TryParseXmlError(string content, out CloudError error)
        {
            bool result = false;
            error = null;
            if (TypeConversion.IsXml(content, true))
            {
                string code = null;
                string message = null;

                try
                {
                    XElement root = XDocument.Parse(content).Root;
                    foreach (XElement element in root.Elements())
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
                    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(message))
                    {
                        error = new CloudError
                        {
                            Code = code,
                            Message = message
                        };

                        result = true;
                    }
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            return result;
        }

        private static bool TryParseJsonError(string content, out CloudError error)
        {
            bool result = false;
            error = null;
            if (TypeConversion.IsJson(content, true))
            {
                string code = null;
                string message = null;
                try
                {
                    var response = JObject.Parse(content);

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

                    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(message))
                    {
                        error = new CloudError
                        {
                            Code = code,
                            Message = message
                        };

                        result = true;
                    }
                }
                catch
                {
                    // Ignore any and all failures
                }
            }

            return result;
        }
    }
}
