// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// A list of keys of a function.
    /// </summary>
    public class FunctionKeyListResult
    {
        /// <summary>
        /// Initializes a new instance of the FunctionKeyListResult class.
        /// </summary>
        public FunctionKeyListResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the FunctionKeyListResult class.
        /// </summary>
        /// <param name="keys">the function keys</param>
        public FunctionKeyListResult(IList<NameValuePair> keys = default(IList<NameValuePair>))
        {
        }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        [JsonProperty(PropertyName = "keys")]
        public IList<NameValuePair> keys { get; set; }
    }
}
