namespace Azure.ResourceManager.EdgeMarketPlace
{
    public static partial class EdgeMarketPlaceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource> GetOffer(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource>> GetOfferAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.OfferResource GetOfferResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.OfferCollection GetOffers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> GetPublisher(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>> GetPublisherAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.PublisherResource GetPublisherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.PublisherCollection GetPublishers(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class OfferCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeMarketPlace.OfferResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.OfferResource>, System.Collections.IEnumerable
    {
        protected OfferCollection() { }
        public virtual Azure.Response<bool> Exists(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource> Get(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeMarketPlace.OfferResource> GetAll(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeMarketPlace.OfferResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource>> GetAsync(string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeMarketPlace.OfferResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeMarketPlace.OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeMarketPlace.OfferResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.OfferResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfferData : Azure.ResourceManager.Models.ResourceData
    {
        internal OfferData() { }
        public System.Uri ContentUri { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSku> MarketplaceSkus { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.OfferContent OfferContent { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class OfferResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferResource() { }
        public virtual Azure.ResourceManager.EdgeMarketPlace.OfferData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string offerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeMarketPlace.Models.DiskAccessToken> GenerateAccessToken(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeMarketPlace.Models.AccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeMarketPlace.Models.DiskAccessToken>> GenerateAccessTokenAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeMarketPlace.Models.AccessTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeMarketPlace.Models.DiskAccessToken> GetAccessToken(Azure.ResourceManager.EdgeMarketPlace.Models.AccessTokenReadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.Models.DiskAccessToken>> GetAccessTokenAsync(Azure.ResourceManager.EdgeMarketPlace.Models.AccessTokenReadContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.OfferResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublisherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>, System.Collections.IEnumerable
    {
        protected PublisherCollection() { }
        public virtual Azure.Response<bool> Exists(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> Get(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> GetAll(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>> GetAsync(string publisherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublisherData : Azure.ResourceManager.Models.ResourceData
    {
        internal PublisherData() { }
        public Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PublisherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublisherResource() { }
        public virtual Azure.ResourceManager.EdgeMarketPlace.PublisherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string publisherName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeMarketPlace.PublisherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeMarketPlace.Models
{
    public partial class AccessTokenContent
    {
        public AccessTokenContent(string edgeMarketPlaceRegion) { }
        public string DeviceSku { get { throw null; } set { } }
        public string DeviceVersion { get { throw null; } set { } }
        public string EdgeMarketPlaceRegion { get { throw null; } }
        public string EgeMarketPlaceResourceId { get { throw null; } set { } }
        public string HypervGeneration { get { throw null; } set { } }
        public string MarketPlaceSku { get { throw null; } set { } }
        public string MarketPlaceSkuVersion { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
    }
    public partial class AccessTokenReadContent
    {
        public AccessTokenReadContent(string requestId) { }
        public string RequestId { get { throw null; } }
    }
    public static partial class ArmEdgeMarketPlaceModelFactory
    {
        public static Azure.ResourceManager.EdgeMarketPlace.Models.DiskAccessToken DiskAccessToken(string diskId = null, string status = null, string accessToken = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.IconFileUris IconFileUris(string small = null, string medium = null, string wide = null, string large = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSku MarketplaceSku(string catalogPlanId = null, string marketplaceSkuId = null, string marketplaceSkuType = null, string displayName = null, string summary = null, string longSummary = null, string description = null, string generation = null, int? displayRank = default(int?), Azure.ResourceManager.EdgeMarketPlace.Models.SkuOperatingSystem operatingSystem = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSkuVersion> marketplaceSkuVersions = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSkuVersion MarketplaceSkuVersion(string name = null, int? sizeOnDiskInMb = default(int?), int? minimumDownloadSizeInMb = default(int?), string stageName = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferContent OfferContent(string displayName = null, string summary = null, string longSummary = null, string description = null, string offerId = null, string offerType = null, System.Uri supportUri = null, int? popularity = default(int?), Azure.ResourceManager.EdgeMarketPlace.Models.OfferPublisher offerPublisher = null, Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability? availability = default(Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability?), Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType? releaseType = default(Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType?), Azure.ResourceManager.EdgeMarketPlace.Models.IconFileUris iconFileUris = null, Azure.ResourceManager.EdgeMarketPlace.Models.TermsAndConditions termsAndConditions = null, System.Collections.Generic.IEnumerable<string> categoryIds = null, System.Collections.Generic.IEnumerable<string> operatingSystems = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.OfferData OfferData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string contentVersion = null, System.Uri contentUri = null, Azure.ResourceManager.EdgeMarketPlace.Models.OfferContent offerContent = null, Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSku> marketplaceSkus = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferPublisher OfferPublisher(string publisherId = null, string publisherDisplayName = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.PublisherData PublisherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.SkuOperatingSystem SkuOperatingSystem(string family = null, string skuOperatingSystemType = null, string name = null) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.TermsAndConditions TermsAndConditions(System.Uri legalTermsUri = null, string legalTermsType = null, System.Uri privacyPolicyUri = null) { throw null; }
    }
    public partial class DiskAccessToken
    {
        internal DiskAccessToken() { }
        public string AccessToken { get { throw null; } }
        public string DiskId { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class IconFileUris
    {
        internal IconFileUris() { }
        public string Large { get { throw null; } }
        public string Medium { get { throw null; } }
        public string Small { get { throw null; } }
        public string Wide { get { throw null; } }
    }
    public partial class MarketplaceSku
    {
        internal MarketplaceSku() { }
        public string CatalogPlanId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? DisplayRank { get { throw null; } }
        public string Generation { get { throw null; } }
        public string LongSummary { get { throw null; } }
        public string MarketplaceSkuId { get { throw null; } }
        public string MarketplaceSkuType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeMarketPlace.Models.MarketplaceSkuVersion> MarketplaceSkuVersions { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.SkuOperatingSystem OperatingSystem { get { throw null; } }
        public string Summary { get { throw null; } }
    }
    public partial class MarketplaceSkuVersion
    {
        internal MarketplaceSkuVersion() { }
        public int? MinimumDownloadSizeInMb { get { throw null; } }
        public string Name { get { throw null; } }
        public int? SizeOnDiskInMb { get { throw null; } }
        public string StageName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OfferAvailability : System.IEquatable<Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OfferAvailability(string value) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability Private { get { throw null; } }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability left, Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability left, Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferContent
    {
        internal OfferContent() { }
        public Azure.ResourceManager.EdgeMarketPlace.Models.OfferAvailability? Availability { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryIds { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.IconFileUris IconFileUris { get { throw null; } }
        public string LongSummary { get { throw null; } }
        public string OfferId { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.OfferPublisher OfferPublisher { get { throw null; } }
        public string OfferType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OperatingSystems { get { throw null; } }
        public int? Popularity { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType? ReleaseType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.Uri SupportUri { get { throw null; } }
        public Azure.ResourceManager.EdgeMarketPlace.Models.TermsAndConditions TermsAndConditions { get { throw null; } }
    }
    public partial class OfferPublisher
    {
        internal OfferPublisher() { }
        public string PublisherDisplayName { get { throw null; } }
        public string PublisherId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OfferReleaseType : System.IEquatable<Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OfferReleaseType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType GA { get { throw null; } }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType left, Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType left, Azure.ResourceManager.EdgeMarketPlace.Models.OfferReleaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState left, Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState left, Azure.ResourceManager.EdgeMarketPlace.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuOperatingSystem
    {
        internal SkuOperatingSystem() { }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string SkuOperatingSystemType { get { throw null; } }
    }
    public partial class TermsAndConditions
    {
        internal TermsAndConditions() { }
        public string LegalTermsType { get { throw null; } }
        public System.Uri LegalTermsUri { get { throw null; } }
        public System.Uri PrivacyPolicyUri { get { throw null; } }
    }
}
