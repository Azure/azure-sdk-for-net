// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class WebApiSkill
    {
        /// <summary> The headers required to make the http request. </summary>
        [CodeGenMember(EmptyAsUndefined = true,  Initialize = true)]
        public IDictionary<string, string> HttpHeaders { get; }
    }
}
