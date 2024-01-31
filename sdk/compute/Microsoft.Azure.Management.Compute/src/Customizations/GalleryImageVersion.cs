using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class GalleryImageVersion
    {
        public GalleryImageVersion(
            string location,
            GalleryImageVersionStorageProfile storageProfile,
            string id,
            string name,
            string type,
            IDictionary<string, string> tags,
            GalleryImageVersionPublishingProfile publishingProfile,
            string provisioningState,
            ReplicationStatus replicationStatus)
        : base(location, id, name, type, tags)
        {
            PublishingProfile = publishingProfile;
            ProvisioningState = provisioningState;
            StorageProfile = storageProfile;
            ReplicationStatus = replicationStatus;
            CustomInit();
        }
    }
}
