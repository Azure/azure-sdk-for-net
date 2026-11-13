// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class WebApiSkill
    {
        /// <summary> The headers required to make the http request. </summary>
        public IDictionary<string, string> HttpHeaders { get; }
    }
}
