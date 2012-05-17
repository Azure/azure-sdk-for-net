//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Services.ServiceBus.Http
{
    /// <summary>
    /// Helper class for processing HTTP query strings.
    /// </summary>
    internal class HttpQueryStringParser
    {
        /// <summary>
        /// Parses the HTTP query string.
        /// </summary>
        /// <param name="queryString">Query string to parse.</param>
        /// <returns>Collection of key/value pairs from the query string.</returns>
        internal static Dictionary<string, string> Parse(string queryString)
        {
            Dictionary<string, string> values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] pairs = queryString.Split('&');

            foreach (string pair in pairs)
            {
                int pos = pair.IndexOf('=');
                string name = pair.Substring(0, pos);
                string value = pair.Substring(pos + 1);
                values.Add(name, value);
            }
            return values;
        }
    }
}
