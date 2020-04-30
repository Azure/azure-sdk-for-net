// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Search.Documents.Models
{
    public partial class Skillset
    {
        [CodeGenMember("etag")]
        private string _etag;

        /// <summary>
        /// The <see cref="Azure.ETag"/> of the <see cref="Skillset"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }
    }
}
