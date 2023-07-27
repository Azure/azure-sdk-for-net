using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class GalleryApplicationVersion
    {
        public GalleryApplicationVersion(
            string location,
            GalleryApplicationVersionPublishingProfile publishingProfile,
            string id,
            string name,
            string type,
            IDictionary<string, string> tags,
            string provisioningState,
            ReplicationStatus replicationStatus = default(ReplicationStatus))
        : base(location, id, name, type, tags)
        {
            PublishingProfile = publishingProfile;
            ProvisioningState = provisioningState;
            ReplicationStatus = replicationStatus;
            CustomInit();
        }
    }
}
