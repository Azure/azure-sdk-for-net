// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> An operation on a resource. </summary>
    public partial class AppServiceOperation
    {
        // Remove this customization when this issue is fixed: https://github.com/Azure/autorest.csharp/issues/4798
        /// <summary> Any errors associate with the operation. </summary>
        [WirePath("errors")]
        public IReadOnlyList<ResponseError> Errors { get; }
    }
}
