// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("IndexingResult")]
    public partial class IndexingResult
    {
        /// <summary>
        /// The status code of the indexing operation. Possible values include:
        /// 200 for a successful update or delete, 201 for successful document
        /// creation, 400 for a malformed input document, 404 for document not
        /// found, 409 for a version conflict, 422 when the index is
        /// temporarily unavailable, or 503 for when the service is too busy.
        /// </summary>
        [CodeGenMember("StatusCode")]
        public int Status { get; internal set; }
    }
}
