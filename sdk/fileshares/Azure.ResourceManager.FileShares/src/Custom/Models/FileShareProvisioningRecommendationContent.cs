// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.FileShares.Models
{
    public partial class FileShareProvisioningRecommendationContent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="FileShareProvisioningRecommendationContent"/>.
        /// </summary>
        /// <param name="fileShareProvisioningRecommendationInputProvisionedStorageInGiB"> The desired provisioned storage size of the share in GiB. Will be used to calculate the values of remaining provisioning parameters. </param>
        /// <remarks>
        /// Back-compatibility overload: in api-version 2026-06-01 the recommendation input exposed only
        /// <c>provisionedStorageInGiB</c>, so the generated constructor took the value directly. 2026-09-01 added
        /// optional protocol/media-tier/scale-mode fields, so the value now lives on
        /// <see cref="FileShareProvisioningRecommendationInputProperties"/>. This overload is preserved so existing
        /// callers continue to compile.
        /// </remarks>
        public FileShareProvisioningRecommendationContent(int fileShareProvisioningRecommendationInputProvisionedStorageInGiB)
            : this(new FileShareProvisioningRecommendationInputProperties(fileShareProvisioningRecommendationInputProvisionedStorageInGiB))
        {
        }

        /// <summary>
        /// The desired provisioned storage size of the share in GiB. Will be used to calculate the values of remaining provisioning parameters.
        /// </summary>
        /// <remarks>
        /// Back-compatibility accessor for the value flattened directly onto this type in api-version 2026-06-01. It
        /// now forwards to <see cref="FileShareProvisioningRecommendationInputProperties.ProvisionedStorageInGiB"/>,
        /// and returns 0 when <see cref="Properties"/> is not set, as the 1.0.0 property did for an unset value.
        /// </remarks>
        public int FileShareProvisioningRecommendationInputProvisionedStorageInGiB => Properties?.ProvisionedStorageInGiB ?? 0;
    }
}
