// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.BulkActions.Models
{
    [CodeGenSuppress("ExecutionParametersRetryPolicy")]
    public partial class ExecuteStartContent
    {
        /// <summary> Retry policy the user can pass. </summary>
        public BulkOperationRetryPolicy ExecutionParametersRetryPolicy => ExecutionParameters?.RetryPolicy;
    }
}
