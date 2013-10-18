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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Microsoft.WindowsAzure.Common
{
    /// <summary>
    /// Base class used to describe HTTP requests and responses associated with
    /// error conditions.
    /// </summary>
    public abstract class CloudHttpErrorInfo
    {
        /// <summary>
        /// Gets the contents of the HTTP message.
        /// </summary>
        public string Content { get; protected set; }

        /// <summary>
        /// Gets the collection of HTTP headers.
        /// </summary>
        public IDictionary<string, IEnumerable<string>> Headers { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP message version.
        /// </summary>
        public Version Version { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the CloudHttpErrorInfo class.
        /// </summary>
        protected CloudHttpErrorInfo()
        {
            Headers = new Dictionary<string, IEnumerable<string>>();
        }

        /// <summary>
        /// Add the HTTP message headers to the error info.
        /// </summary>
        /// <param name="headers">Collection of HTTP header.</param>
        protected void CopyHeaders(HttpHeaders headers)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
                {
                    IEnumerable<string> values = null;
                    if (Headers.TryGetValue(header.Key, out values))
                    {
                        values = Enumerable.Concat(values, header.Value);
                    }
                    else
                    {
                        values = header.Value;
                    }
                    Headers[header.Key] = values;
                }
            }
        }
    }
}
