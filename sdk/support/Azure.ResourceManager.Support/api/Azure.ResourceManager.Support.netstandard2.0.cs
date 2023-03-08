namespace Azure.ResourceManager.Support
{
    public partial class ProblemClassificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>, System.Collections.IEnumerable
    {
        protected ProblemClassificationCollection() { }
        public virtual Azure.Response<bool> Exists(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> Get(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.ProblemClassificationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.ProblemClassificationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.ProblemClassificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.ProblemClassificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ProblemClassificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProblemClassificationData : Azure.ResourceManager.Models.ResourceData
    {
        internal ProblemClassificationData() { }
        public string DisplayName { get { throw null; } }
    }
    public partial class ProblemClassificationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProblemClassificationResource() { }
        public virtual Azure.ResourceManager.Support.ProblemClassificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceName, string problemClassificationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportAzureServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>, System.Collections.IEnumerable
    {
        protected SupportAzureServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportAzureServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportAzureServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportAzureServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportAzureServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportAzureServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportAzureServiceData : Azure.ResourceManager.Models.ResourceData
    {
        internal SupportAzureServiceData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
    }
    public partial class SupportAzureServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportAzureServiceResource() { }
        public virtual Azure.ResourceManager.Support.SupportAzureServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> GetProblemClassification(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetProblemClassificationAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.ProblemClassificationCollection GetProblemClassifications() { throw null; }
    }
    public static partial class SupportExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckSupportTicketNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckSupportTicketNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.ProblemClassificationResource GetProblemClassificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource> GetSupportAzureService(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportAzureServiceResource>> GetSupportAzureServiceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SupportAzureServiceResource GetSupportAzureServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportAzureServiceCollection GetSupportAzureServices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SupportTicketResource> GetSupportTicket(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketResource>> GetSupportTicketAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketCommunicationResource GetSupportTicketCommunicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketResource GetSupportTicketResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketCollection GetSupportTickets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class SupportTicketCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketResource>, System.Collections.IEnumerable
    {
        protected SupportTicketCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketResource> Get(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketResource>> GetAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketCommunicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>, System.Collections.IEnumerable
    {
        protected SupportTicketCommunicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Get(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketCommunicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketCommunicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketCommunicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketCommunicationData : Azure.ResourceManager.Models.ResourceData
    {
        public SupportTicketCommunicationData() { }
        public string Body { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection? CommunicationDirection { get { throw null; } }
        public Azure.ResourceManager.Support.Models.SupportTicketCommunicationType? CommunicationType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Sender { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class SupportTicketCommunicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketCommunicationResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName, string communicationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.SupportTicketCommunicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportTicketData : Azure.ResourceManager.Models.ResourceData
    {
        public SupportTicketData() { }
        public Azure.ResourceManager.Support.Models.SupportContactProfile ContactDetails { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EnrollmentId { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ProblemClassificationDisplayName { get { throw null; } }
        public string ProblemClassificationId { get { throw null; } set { } }
        public System.DateTimeOffset? ProblemStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.QuotaTicketDetails QuotaTicketDetails { get { throw null; } set { } }
        public bool? Require24X7Response { get { throw null; } set { } }
        public string ServiceDisplayName { get { throw null; } }
        public string ServiceId { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportServiceLevelAgreement ServiceLevelAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportSeverityLevel? Severity { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string SupportEngineerEmailAddress { get { throw null; } }
        public string SupportPlanType { get { throw null; } }
        public string SupportTicketId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TechnicalTicketDetailsResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class SupportTicketResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckCommunicationNameAvailability(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckCommunicationNameAvailabilityAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource> GetSupportTicketCommunication(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketCommunicationResource>> GetSupportTicketCommunicationAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.SupportTicketCommunicationCollection GetSupportTicketCommunications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketResource> Update(Azure.ResourceManager.Support.Models.SupportTicketPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketResource>> UpdateAsync(Azure.ResourceManager.Support.Models.SupportTicketPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Support.Mock
{
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Support.SupportTicketCollection GetSupportTickets() { throw null; }
    }
    public partial class SupportTicketResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SupportTicketResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult> CheckSupportTicketNameAvailability(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.SupportNameAvailabilityResult>> CheckSupportTicketNameAvailabilityAsync(Azure.ResourceManager.Support.Models.SupportNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected TenantResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Support.SupportAzureServiceCollection GetSupportAzureServices() { throw null; }
    }
}
namespace Azure.ResourceManager.Support.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredContactMethod : System.IEquatable<Azure.ResourceManager.Support.Models.PreferredContactMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredContactMethod(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.PreferredContactMethod Email { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.PreferredContactMethod Phone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.PreferredContactMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.PreferredContactMethod left, Azure.ResourceManager.Support.Models.PreferredContactMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.PreferredContactMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.PreferredContactMethod left, Azure.ResourceManager.Support.Models.PreferredContactMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaTicketDetails
    {
        public QuotaTicketDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.SupportQuotaChangeContent> QuotaChangeRequests { get { throw null; } }
        public string QuotaChangeRequestSubType { get { throw null; } set { } }
        public string QuotaChangeRequestVersion { get { throw null; } set { } }
    }
    public partial class SupportContactProfile
    {
        public SupportContactProfile(string firstName, string lastName, Azure.ResourceManager.Support.Models.PreferredContactMethod preferredContactMethod, string primaryEmailAddress, string preferredTimeZone, string country, string preferredSupportLanguage) { }
        public System.Collections.Generic.IList<string> AdditionalEmailAddresses { get { throw null; } }
        public string Country { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.PreferredContactMethod PreferredContactMethod { get { throw null; } set { } }
        public string PreferredSupportLanguage { get { throw null; } set { } }
        public string PreferredTimeZone { get { throw null; } set { } }
        public string PrimaryEmailAddress { get { throw null; } set { } }
    }
    public partial class SupportContactProfileContent
    {
        public SupportContactProfileContent() { }
        public System.Collections.Generic.IList<string> AdditionalEmailAddresses { get { throw null; } }
        public string Country { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.PreferredContactMethod? PreferredContactMethod { get { throw null; } set { } }
        public string PreferredSupportLanguage { get { throw null; } set { } }
        public string PreferredTimeZone { get { throw null; } set { } }
        public string PrimaryEmailAddress { get { throw null; } set { } }
    }
    public partial class SupportNameAvailabilityContent
    {
        public SupportNameAvailabilityContent(string name, Azure.ResourceManager.Support.Models.SupportResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Support.Models.SupportResourceType ResourceType { get { throw null; } }
    }
    public partial class SupportNameAvailabilityResult
    {
        internal SupportNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class SupportQuotaChangeContent
    {
        public SupportQuotaChangeContent() { }
        public string Payload { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
    }
    public enum SupportResourceType
    {
        MicrosoftSupportSupportTickets = 0,
        MicrosoftSupportCommunications = 1,
    }
    public partial class SupportServiceLevelAgreement
    {
        public SupportServiceLevelAgreement() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public int? SlaInMinutes { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportSeverityLevel : System.IEquatable<Azure.ResourceManager.Support.Models.SupportSeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportSeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Highestcriticalimpact { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Minimal { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportSeverityLevel Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportSeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportSeverityLevel left, Azure.ResourceManager.Support.Models.SupportSeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportSeverityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportSeverityLevel left, Azure.ResourceManager.Support.Models.SupportSeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketCommunicationDirection : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketCommunicationDirection(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketCommunicationType : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketCommunicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketCommunicationType(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationType Phone { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketCommunicationType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketCommunicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketCommunicationType left, Azure.ResourceManager.Support.Models.SupportTicketCommunicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportTicketPatch
    {
        public SupportTicketPatch() { }
        public Azure.ResourceManager.Support.Models.SupportContactProfileContent ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportSeverityLevel? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SupportTicketStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportTicketStatus : System.IEquatable<Azure.ResourceManager.Support.Models.SupportTicketStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTicketStatus(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SupportTicketStatus Closed { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SupportTicketStatus Open { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SupportTicketStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SupportTicketStatus left, Azure.ResourceManager.Support.Models.SupportTicketStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SupportTicketStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SupportTicketStatus left, Azure.ResourceManager.Support.Models.SupportTicketStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
