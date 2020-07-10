// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParameters
    {
        /// <summary>
        /// A dictionary of indexer-specific configuration properties.
        /// Each name is the name of a <see href="https://docs.microsoft.com/rest/api/searchservice/create-indexer#parameters">specific property</see>.
        /// Each value must be of a primitive type.
        /// See the <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/samples/IndexingParametersExtensions.md">IndexingParametersExtensions</see>
        /// sample for code you can include in your own projects to set these values intuitively.
        /// </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IDictionary<string, object> Configuration { get; }
    }
}
