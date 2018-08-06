// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Error type and information
    /// </summary>
    public class TypedErrorInfo
    {
        /// <summary>
        /// The error type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The error information
        /// </summary>
        public JObject Info { get; set; }
    }
}