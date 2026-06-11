// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class MachineLearningEndpointAuthToken
    {
        /// <summary> Access token expiry time. </summary>
        [WirePath("expiryTimeUtc")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpireOn => ExpiryTimeUtc.HasValue ? DateTimeOffset.FromUnixTimeSeconds(ExpiryTimeUtc.Value) : null;

        /// <summary> Refresh access token after time. </summary>
        [WirePath("refreshAfterTimeUtc")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? RefreshOn => RefreshAfterTimeUtc.HasValue ? DateTimeOffset.FromUnixTimeSeconds(RefreshAfterTimeUtc.Value) : null;
    }
}
