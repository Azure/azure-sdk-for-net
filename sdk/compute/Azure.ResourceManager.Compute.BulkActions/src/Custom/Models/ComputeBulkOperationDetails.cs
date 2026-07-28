// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    /// <summary> The details of a response from an operation on a resource. </summary>
    public partial class ComputeBulkOperationDetails
    {
        /// <summary> Type of deadline of the operation. </summary>
        [CodeGenMember("DeadlineType")]
        public BulkActionDeadlineKind? DeadlineKind { get; }
    }
}
