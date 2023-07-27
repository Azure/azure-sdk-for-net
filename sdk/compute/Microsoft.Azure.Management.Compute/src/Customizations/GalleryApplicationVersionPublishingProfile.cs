namespace Microsoft.Azure.Management.Compute.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The publishing profile of a gallery image version.
    /// </summary>
    public partial class GalleryApplicationVersionPublishingProfile : GalleryArtifactPublishingProfileBase
    {
        public GalleryApplicationVersionPublishingProfile(UserArtifactSource source, IList<TargetRegion> targetRegions, int? replicaCount, bool? excludeFromLatest, System.DateTime? publishedDate, System.DateTime? endOfLifeDate, string storageAccountType, string replicationMode, UserArtifactManage manageActions, bool? enableHealthCheck = default(bool?))
            : base(targetRegions, replicaCount, excludeFromLatest, publishedDate, endOfLifeDate, storageAccountType, replicationMode)
        {
            Source = source;
            ManageActions = manageActions;
            EnableHealthCheck = enableHealthCheck;
            CustomInit();
        }

        public GalleryApplicationVersionPublishingProfile(UserArtifactSource source, IList<TargetRegion> targetRegions, int? replicaCount, bool? excludeFromLatest, System.DateTime? publishedDate, System.DateTime? endOfLifeDate, string storageAccountType, string replicationMode, IList<GalleryTargetExtendedLocation> targetExtendedLocations, UserArtifactManage manageActions, bool? enableHealthCheck = default(bool?))
            : base(targetRegions, replicaCount, excludeFromLatest, publishedDate, endOfLifeDate, storageAccountType, replicationMode, targetExtendedLocations)
        {
            Source = source;
            ManageActions = manageActions;
            EnableHealthCheck = enableHealthCheck;
            CustomInit();
        }
    }
}
