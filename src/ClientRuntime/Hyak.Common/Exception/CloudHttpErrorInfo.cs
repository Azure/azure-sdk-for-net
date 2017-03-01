// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hyak.Common
{
    /// <summary>
    /// Base class used to describe HTTP requests and responses associated with
    /// error conditions.
    /// </summary>
    public abstract class CloudHttpErrorInfo
    {
        /// <summary>
        /// Gets or sets the contents of the HTTP message.
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
