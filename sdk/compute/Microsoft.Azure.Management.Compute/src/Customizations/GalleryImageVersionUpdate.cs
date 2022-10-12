using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class GalleryImageVersionUpdate
    {
        public GalleryImageVersionUpdate(
            GalleryImageVersionStorageProfile storageProfile,
            string id,
            string name,
            string type,
            IDictionary<string, string> tags,
            GalleryImageVersionPublishingProfile publishingProfile,
            string provisioningState,
            ReplicationStatus replicationStatus)
        : base(id, name, type, tags)
        {
            PublishingProfile = publishingProfile;
            ProvisioningState = provisioningState;
            StorageProfile = storageProfile;
            ReplicationStatus = replicationStatus;
            CustomInit();
        }
    }
}
