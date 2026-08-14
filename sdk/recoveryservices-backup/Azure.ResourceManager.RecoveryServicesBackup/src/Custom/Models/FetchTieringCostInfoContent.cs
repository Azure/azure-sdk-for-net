// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    public abstract partial class FetchTieringCostInfoContent
    {
        /// <summary> Initializes a new instance of <see cref="FetchTieringCostInfoContent"/>. </summary>
        /// <param name="sourceTierType"> Source tier for the request. </param>
        /// <param name="targetTierType"> target tier for the request. </param>
        protected FetchTieringCostInfoContent(RecoveryPointTierType sourceTierType, RecoveryPointTierType targetTierType)
        {
            SourceTierType = sourceTierType;
            TargetTierType = targetTierType;
        }
    }
}
