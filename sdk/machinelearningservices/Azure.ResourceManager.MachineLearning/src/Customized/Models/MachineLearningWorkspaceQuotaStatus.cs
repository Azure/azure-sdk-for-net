// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.MachineLearning.Models
{
    public readonly partial struct MachineLearningWorkspaceQuotaStatus
    {
        /// <summary> Gets the InvalidVmFamilyName. </summary>
        public static MachineLearningWorkspaceQuotaStatus InvalidVmFamilyName { get; } = new MachineLearningWorkspaceQuotaStatus("InvalidVMFamilyName");
    }
}
