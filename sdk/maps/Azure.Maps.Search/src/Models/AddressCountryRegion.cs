// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    public partial class AddressCountryRegion
    {
        /// <summary> ISO of country/region. </summary>
        [CodeGenMember("ISO")]
        public string Iso { get; }
    }
}
