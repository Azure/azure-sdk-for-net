// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: baseline exposed protected BenefitRecommendationProperties().
    // Generator now only emits private protected BenefitRecommendationProperties(BenefitRecommendationScope scope),
    // which breaks user subclasses that call base(). Restore the protected parameterless ctor.
    public abstract partial class BenefitRecommendationProperties
    {
        /// <summary> Initializes a new instance of <see cref="BenefitRecommendationProperties"/>. </summary>
        protected BenefitRecommendationProperties()
        {
        }
    }
}
