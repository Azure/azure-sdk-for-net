// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn
{
    public partial class CdnEndpointData
    {
        /// <summary> The custom domains under the endpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<CdnCustomDomainData> CustomDomains { get; }
    }
}
