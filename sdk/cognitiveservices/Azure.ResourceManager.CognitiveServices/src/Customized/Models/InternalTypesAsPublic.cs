// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    // Backward compatibility: these types were public in the autorest-generated SDK
    // but the TypeSpec generator marks them as internal.

    [CodeGenType("AbusePenalty")]
    public partial class AbusePenalty { }

    [CodeGenType("CognitiveServicesKeyVaultProperties")]
    public partial class CognitiveServicesKeyVaultProperties { }

    [CodeGenType("CognitiveServicesMultiRegionSettings")]
    public partial class CognitiveServicesMultiRegionSettings { }

    [CodeGenType("CognitiveServicesNetworkRuleSet")]
    public partial class CognitiveServicesNetworkRuleSet { }

    [CodeGenType("CognitiveServicesSku")]
    public partial class CognitiveServicesSku { }

    [CodeGenType("CognitiveServicesSkuCapability")]
    public partial class CognitiveServicesSkuCapability { }

    [CodeGenType("CognitiveServicesSkuChangeInfo")]
    public partial class CognitiveServicesSkuChangeInfo { }

    [CodeGenType("CommitmentPlanAssociation")]
    public partial class CommitmentPlanAssociation { }

    [CodeGenType("RaiMonitorConfig")]
    public partial class RaiMonitorConfig { }

    [CodeGenType("ServiceAccountApiProperties")]
    public partial class ServiceAccountApiProperties { }

    [CodeGenType("ServiceAccountCallRateLimit")]
    public partial class ServiceAccountCallRateLimit { }

    [CodeGenType("ServiceAccountQuotaLimit")]
    public partial class ServiceAccountQuotaLimit { }

    [CodeGenType("ServiceAccountUserOwnedStorage")]
    public partial class ServiceAccountUserOwnedStorage { }

    [CodeGenType("UserOwnedAmlWorkspace")]
    public partial class UserOwnedAmlWorkspace { }
}
