namespace Azure.ResourceManager.Support
{
    public partial class CommunicationDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.CommunicationDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.CommunicationDetailResource>, System.Collections.IEnumerable
    {
        protected CommunicationDetailCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.CommunicationDetailResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.CommunicationDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.CommunicationDetailResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationName, Azure.ResourceManager.Support.CommunicationDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource> Get(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.CommunicationDetailResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.CommunicationDetailResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource>> GetAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.CommunicationDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.CommunicationDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.CommunicationDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.CommunicationDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunicationDetailData : Azure.ResourceManager.Models.ResourceData
    {
        public CommunicationDetailData() { }
        public string Body { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.CommunicationDirection? CommunicationDirection { get { throw null; } }
        public Azure.ResourceManager.Support.Models.CommunicationType? CommunicationType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Sender { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
    }
    public partial class CommunicationDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunicationDetailResource() { }
        public virtual Azure.ResourceManager.Support.CommunicationDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName, string communicationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.CommunicationDetailResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.CommunicationDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.CommunicationDetailResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Support.CommunicationDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
    public partial class ServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ServiceResource>, System.Collections.IEnumerable
    {
        protected ServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.ServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.ServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.ServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.ServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.ServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.ServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceData : Azure.ResourceManager.Models.ResourceData
    {
        internal ServiceData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
    }
    public partial class ServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceResource() { }
        public virtual Azure.ResourceManager.Support.ServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource> GetProblemClassification(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ProblemClassificationResource>> GetProblemClassificationAsync(string problemClassificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.ProblemClassificationCollection GetProblemClassifications() { throw null; }
    }
    public static partial class SupportExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Support.Models.CheckNameAvailabilityOutput> CheckNameAvailabilitySupportTicket(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.CheckNameAvailabilityOutput>> CheckNameAvailabilitySupportTicketAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Support.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.CommunicationDetailResource GetCommunicationDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.ProblemClassificationResource GetProblemClassificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.ServiceResource> GetService(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.ServiceResource>> GetServiceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.ServiceResource GetServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.ServiceCollection GetServices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource> GetSupportTicketDetail(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource>> GetSupportTicketDetailAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketDetailResource GetSupportTicketDetailResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Support.SupportTicketDetailCollection GetSupportTicketDetails(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class SupportTicketDetailCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketDetailResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketDetailResource>, System.Collections.IEnumerable
    {
        protected SupportTicketDetailCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketDetailResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Support.SupportTicketDetailResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supportTicketName, Azure.ResourceManager.Support.SupportTicketDetailData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource> Get(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Support.SupportTicketDetailResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Support.SupportTicketDetailResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource>> GetAsync(string supportTicketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Support.SupportTicketDetailResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Support.SupportTicketDetailResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Support.SupportTicketDetailResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Support.SupportTicketDetailResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportTicketDetailData : Azure.ResourceManager.Models.ResourceData
    {
        public SupportTicketDetailData() { }
        public Azure.ResourceManager.Support.Models.ContactProfile ContactDetails { get { throw null; } set { } }
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
        public Azure.ResourceManager.Support.Models.ServiceLevelAgreement ServiceLevelAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SeverityLevel? Severity { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string SupportEngineerEmailAddress { get { throw null; } }
        public string SupportPlanType { get { throw null; } }
        public string SupportTicketId { get { throw null; } set { } }
        public string TechnicalTicketDetailsResourceId { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class SupportTicketDetailResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportTicketDetailResource() { }
        public virtual Azure.ResourceManager.Support.SupportTicketDetailData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Support.Models.CheckNameAvailabilityOutput> CheckNameAvailabilityCommunication(Azure.ResourceManager.Support.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.Models.CheckNameAvailabilityOutput>> CheckNameAvailabilityCommunicationAsync(Azure.ResourceManager.Support.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string supportTicketName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource> GetCommunicationDetail(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.CommunicationDetailResource>> GetCommunicationDetailAsync(string communicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Support.CommunicationDetailCollection GetCommunicationDetails() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource> Update(Azure.ResourceManager.Support.Models.SupportTicketDetailPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Support.SupportTicketDetailResource>> UpdateAsync(Azure.ResourceManager.Support.Models.SupportTicketDetailPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Support.Models
{
    public partial class CheckNameAvailabilityInput
    {
        public CheckNameAvailabilityInput(string name, Azure.ResourceManager.Support.Models.Type resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Support.Models.Type ResourceType { get { throw null; } }
    }
    public partial class CheckNameAvailabilityOutput
    {
        internal CheckNameAvailabilityOutput() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationDirection : System.IEquatable<Azure.ResourceManager.Support.Models.CommunicationDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationDirection(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.CommunicationDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.CommunicationDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.CommunicationDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.CommunicationDirection left, Azure.ResourceManager.Support.Models.CommunicationDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.CommunicationDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.CommunicationDirection left, Azure.ResourceManager.Support.Models.CommunicationDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationType : System.IEquatable<Azure.ResourceManager.Support.Models.CommunicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationType(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.CommunicationType Phone { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.CommunicationType Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.CommunicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.CommunicationType left, Azure.ResourceManager.Support.Models.CommunicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.CommunicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.CommunicationType left, Azure.ResourceManager.Support.Models.CommunicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContactProfile
    {
        public ContactProfile(string firstName, string lastName, Azure.ResourceManager.Support.Models.PreferredContactMethod preferredContactMethod, string primaryEmailAddress, string preferredTimeZone, string country, string preferredSupportLanguage) { }
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
    public partial class QuotaChangeRequest
    {
        public QuotaChangeRequest() { }
        public string Payload { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
    }
    public partial class QuotaTicketDetails
    {
        public QuotaTicketDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Support.Models.QuotaChangeRequest> QuotaChangeRequests { get { throw null; } }
        public string QuotaChangeRequestSubType { get { throw null; } set { } }
        public string QuotaChangeRequestVersion { get { throw null; } set { } }
    }
    public partial class ServiceLevelAgreement
    {
        public ServiceLevelAgreement() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public int? SlaMinutes { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeverityLevel : System.IEquatable<Azure.ResourceManager.Support.Models.SeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.SeverityLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SeverityLevel Highestcriticalimpact { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SeverityLevel Minimal { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.SeverityLevel Moderate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.SeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.SeverityLevel left, Azure.ResourceManager.Support.Models.SeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.SeverityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.SeverityLevel left, Azure.ResourceManager.Support.Models.SeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Support.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Support.Models.Status Closed { get { throw null; } }
        public static Azure.ResourceManager.Support.Models.Status Open { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Support.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Support.Models.Status left, Azure.ResourceManager.Support.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Support.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Support.Models.Status left, Azure.ResourceManager.Support.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportTicketDetailPatch
    {
        public SupportTicketDetailPatch() { }
        public Azure.ResourceManager.Support.Models.UpdateContactProfile ContactDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.SeverityLevel? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.Support.Models.Status? Status { get { throw null; } set { } }
    }
    public enum Type
    {
        MicrosoftSupportSupportTickets = 0,
        MicrosoftSupportCommunications = 1,
    }
    public partial class UpdateContactProfile
    {
        public UpdateContactProfile() { }
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
}
