using Azure.Core;

namespace Azure.Storage.Blobs.Models
{
    public class BlobContainerItem
    {
        public string Group { get; internal set; }
        
        public string Name { get; internal set; }

        public bool? IsDeleted { get; internal set; }
        
        public string VersionId { get; internal set; }

        public BlobContainerProperties Properties { get; internal set; }

        internal BlobContainerItem() {}
    }
}
