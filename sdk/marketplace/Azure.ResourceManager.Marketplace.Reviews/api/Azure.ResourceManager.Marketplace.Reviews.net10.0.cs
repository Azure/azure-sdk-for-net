namespace Azure.ResourceManager.Marketplace.Reviews
{
    public partial class AzureResourceManagerMarketplaceReviewsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMarketplaceReviewsContext() { }
        public static Azure.ResourceManager.Marketplace.Reviews.AzureResourceManagerMarketplaceReviewsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MarketplaceReviewsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview> CheckUserHasReview(this Azure.ResourceManager.Resources.TenantResource tenantResource, string uniqueProductId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>> CheckUserHasReviewAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string uniqueProductId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Marketplace.Reviews.Mocking
{
    public partial class MockableMarketplaceReviewsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMarketplaceReviewsTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview> CheckUserHasReview(string uniqueProductId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>> CheckUserHasReviewAsync(string uniqueProductId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Marketplace.Reviews.Models
{
    public static partial class ArmMarketplaceReviewsModelFactory
    {
        public static Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview UserHasReview(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties UserHasReviewProperties(bool hasReview = false, System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class UserHasReview : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>
    {
        internal UserHasReview() { }
        public Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserHasReviewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>
    {
        internal UserHasReviewProperties() { }
        public bool HasReview { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Marketplace.Reviews.Models.UserHasReviewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
