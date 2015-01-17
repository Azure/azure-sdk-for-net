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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a set of Http response headers returned from an http request.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "This name is correct for the context of abstracting a previously named class. [tgs]")]
#if Non_Public_SDK
    public interface IHttpResponseHeadersAbstraction : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
#else
    internal interface IHttpResponseHeadersAbstraction : IEnumerable<KeyValuePair<string, IEnumerable<string>>>
#endif
    {
        /// <summary>
        /// Adds a set of values for a header.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <param name="values">
        /// The values to associate with the header.
        /// </param>
        void Add(string name, IEnumerable<string> values);

        /// <summary>
        /// Adds a single value to a header.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <param name="value">
        /// The value to add as the only element in the headers enumeration of values.
        /// </param>
        void Add(string name, string value);

        /// <summary>
        /// Clears the list of headers.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines if a header exists in the collection.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <returns>
        /// True if the header exists otherwise false.
        /// </returns>
        bool Contains(string name);

        /// <summary>
        /// Removes a header from the collection.
        /// </summary>
        /// <param name="name">
        /// The name of the header to remove.
        /// </param>
        void Remove(string name);

        /// <summary>
        /// Tries to get the values associated with a header name.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <param name="values">
        /// An out parameter into which the header values will be placed.
        /// </param>
        /// <returns>
        /// True if the header exists in the collection otherwise false.
        /// </returns>
        bool TryGetValue(string name, out IEnumerable<string> values);

        /// <summary>
        /// Gets the values associated with a specific header.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <returns>
        /// The values associated with the header.
        /// </returns>
        IEnumerable<string> GetValues(string name);

        /// <summary>
        /// Gets the headers values associated with a header name.
        /// </summary>
        /// <param name="name">
        /// The name of the header.
        /// </param>
        /// <returns>
        /// The values associated with the header.
        /// </returns>
        IEnumerable<string> this[string name] { get; set; }
    }
}
