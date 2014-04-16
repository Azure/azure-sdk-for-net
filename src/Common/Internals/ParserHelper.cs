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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure.Common.Internals
{
    /// <summary>
    /// Parser helper.
    /// </summary>
    public static class ParserHelper
    {
        /// <summary>
        /// Checks if content is possibly an XML.
        /// </summary>
        /// <param name="content">String to check.</param>
        /// <param name="validate">If set to true will validate entire XML for validity 
        /// otherwise will just check the first character.</param>
        /// <returns>True is content is possibly an XML otherwise false.</returns>
        public static bool IsXml(string content, bool validate = false)
        {
            var firstCharacter = FirstNonWhitespaceCharacter(content);
            if (!validate)
            {
                return firstCharacter == '<';
            }
            else
            {
                if (firstCharacter != '<')
                {
                    return false;
                }

                try
                {
                    XDocument.Parse(content);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks if content is possibly a JSON.
        /// </summary>
        /// <param name="content">String to check.</param>
        /// <param name="validate">If set to true will validate entire JSON for validity 
        /// otherwise will just check the first character.</param>
        /// <returns>True is content is possibly an JSON otherwise false.</returns>
        public static bool IsJson(string content, bool validate = false)
        {
            var firstCharacter = FirstNonWhitespaceCharacter(content);
            if (!validate)
            {
                return firstCharacter == '{';
            }
            else
            {
                if (firstCharacter != '{')
                {
                    return false;
                }

                try
                {
                    JObject.Parse(content);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns first non whitespace character
        /// </summary>
        /// <param name="content">Text to search in</param>
        /// <returns>Non whitespace or default char</returns>
        private static char FirstNonWhitespaceCharacter(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return default(char);
            }

            for (int i = 0; i < content.Length; i++)
            {
                if (!char.IsWhiteSpace(content[i]))
                {
                    return content[i];
                }
            }

            return default(char);
        }
    }
}
