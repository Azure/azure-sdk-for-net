// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchAddressResultItem")]
    public partial class SearchAddressResultItem
    {
        /// <summary> Information about the original data source of the Result. Used for support requests. </summary>
        [CodeGenMember("Info")]
        public string DataSourceInfo { get; }
    }
}
