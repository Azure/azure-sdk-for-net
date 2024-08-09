// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.HealthDataAIServices.Models
{
    public partial class DeidServiceProperties
    {
        /// <summary> Deid service url. </summary>
        [CodeGenMember("DeidServicePropertiei")]
        public Uri ServiceUri { get; }
    }
}
