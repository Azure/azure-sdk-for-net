// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class DocumentIndexResult
    {
        /// <summary>
        /// Gets the list of status information for each document in the
        /// indexing request.
        /// </summary>
        [JsonIgnore]
        public IList<IndexingResult> Results
        {
            get { return this.Value; }
            set { this.Value = value; }
        }
    }
}
