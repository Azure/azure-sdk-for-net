// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.TrafficManager.Models
{
    /// <summary> The result of the request or operation. </summary>
    public partial class TrafficManagerDeleteOperationResult
    {
        /// <summary> The result of the operation or request. </summary>
        [CodeGenMember("OperationResult")]
        public bool? IsSuccessful { get; }
    }
}
