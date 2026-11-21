// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.HorizonDB.Models
{
    public static partial class ArmHorizonDBModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="HorizonDBProvisionedComputeModelCapability"/> for mocking. </summary>
        /// <param name="recommendedVCoreCount"> The recommended provisioned vCore count. </param>
        /// <param name="supportedComputeSizes"> The supported provisioned compute sizes. </param>
        /// <returns> A new provisioned compute model capability. </returns>
        public static HorizonDBProvisionedComputeModelCapability HorizonDBProvisionedComputeModelCapability(
            int recommendedVCoreCount = default,
            IEnumerable<HorizonDBComputeSizeCapability> supportedComputeSizes = default)
        {
            return new HorizonDBProvisionedComputeModelCapability(
                PoolComputeModelType.Provisioned,
                default,
                recommendedVCoreCount,
                supportedComputeSizes?.ToList() ?? new List<HorizonDBComputeSizeCapability>());
        }
    }
}
