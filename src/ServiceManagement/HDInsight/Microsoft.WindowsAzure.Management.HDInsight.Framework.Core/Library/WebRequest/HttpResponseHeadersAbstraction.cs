// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Headers;

    /// <summary>
    /// Abstracts HttpResponseHeaders when using the Http abstraction for http comunication.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "This name is correct for the context of abstracting a previously named class. [tgs]")]
    internal class HttpResponseHeadersAbstraction : IHttpResponseHeadersAbstraction
    {
        private Dictionary<string, IEnumerable<string>> headers = new Dictionary<string, IEnumerable<string>>();

        /// <summary>
        /// Initializes a new instance of the HttpResponseHeadersAbstraction class.
        /// </summary>
        public HttpResponseHeadersAbstraction()
        {
        }

        /// <summary>
        /// Initializes a new instance of the HttpResponseHeadersAbstraction class.
        /// </summary>
        /// <param name="headers">
        /// An actual HttpResponseHeaders from which this class should get its values.
        /// </param>
        public HttpResponseHeadersAbstraction(HttpResponseHeaders headers)
        {
            this.headers.AddRange(headers);
        }

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.headers.GetEnumerator();
        }

        /// <inheritdoc />
        public void Add(string name, IEnumerable<string> values)
        {
            this.headers.Add(name, values);
        }

        /// <inheritdoc />
        public void Add(string name, string value)
        {
            this.headers.Add(name, value.MakeEnumeration());
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.headers.Clear();
        }

        /// <inheritdoc />
        public bool Contains(string name)
        {
            return this.headers.ContainsKey(name);
        }

        /// <inheritdoc />
        public void Remove(string name)
        {
            this.headers.Remove(name);
        }

        /// <inheritdoc />
        public bool TryGetValue(string name, out IEnumerable<string> values)
        {
            return this.headers.TryGetValue(name, out values);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetValues(string name)
        {
            return this.headers[name];
        }

        /// <inheritdoc />
        public IEnumerable<string> this[string name]
        {
            get { return this.headers[name]; }
            set { this.headers[name] = value; }
        }
    }
}
