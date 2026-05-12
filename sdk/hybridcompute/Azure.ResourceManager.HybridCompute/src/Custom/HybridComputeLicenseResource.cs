// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.HybridCompute.Models;

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputeLicenseResource
    {
        /// <summary>
        /// Updates a license resource.
        /// This overload accepts <see cref="HybridComputeLicenseData"/> for backward compatibility.
        /// Use <see cref="Update(WaitUntil, HybridComputeLicensePatch, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<HybridComputeLicenseResource> Update(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, ConvertToPatch(data), cancellationToken);

        /// <summary>
        /// Updates a license resource.
        /// This overload accepts <see cref="HybridComputeLicenseData"/> for backward compatibility.
        /// Use <see cref="UpdateAsync(WaitUntil, HybridComputeLicensePatch, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<HybridComputeLicenseResource>> UpdateAsync(WaitUntil waitUntil, HybridComputeLicenseData data, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, ConvertToPatch(data), cancellationToken);

        private static HybridComputeLicensePatch ConvertToPatch(HybridComputeLicenseData data)
        {
            var patch = new HybridComputeLicensePatch();
            if (data == null)
                return patch;
            patch.LicenseType = data.LicenseType;
            if (data.LicenseDetails != null)
            {
                patch.State = data.LicenseDetails.State;
                patch.Target = data.LicenseDetails.Target;
                patch.Edition = data.LicenseDetails.Edition;
                patch.Type = data.LicenseDetails.LicenseCoreType;
                patch.Processors = data.LicenseDetails.Processors;
            }
            if (data.Tags != null)
            {
                foreach (var tag in data.Tags)
                {
                    patch.Tags[tag.Key] = tag.Value;
                }
            }
            return patch;
        }
    }
}
