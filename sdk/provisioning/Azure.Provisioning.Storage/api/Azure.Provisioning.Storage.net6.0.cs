namespace Azure.Provisioning.Storage
{
    public partial class BlobService : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.BlobServiceData>
    {
        public BlobService(Azure.Provisioning.IConstruct scope, Azure.Provisioning.Storage.StorageAccount? parent = null, string version = "2022-09-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.BlobServiceData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Storage.BlobService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.Storage.StorageAccount parent) { throw null; }
    }
    public partial class StorageAccount : Azure.Provisioning.Resource<Azure.ResourceManager.Storage.StorageAccountData>
    {
        public StorageAccount(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa", string version = "2022-09-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Storage.StorageAccountData>), default(bool)) { }
        public static Azure.Provisioning.Storage.StorageAccount FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public static partial class StorageExtensions
    {
        public static Azure.Provisioning.Storage.BlobService AddBlobService(this Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.Storage.StorageAccount AddStorageAccount(this Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Storage.Models.StorageKind kind, Azure.ResourceManager.Storage.Models.StorageSkuName sku, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sa") { throw null; }
    }
}
