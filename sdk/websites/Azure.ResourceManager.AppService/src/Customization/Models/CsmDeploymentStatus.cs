// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class CsmDeploymentStatus
    {
        // Remove this customization when this issue is fixed: https://github.com/Azure/autorest.csharp/issues/4798
        /// <summary> List of errors. </summary>
        [WirePath("properties.errors")]
        public IList<ResponseError> Errors { get; }
    }
}
