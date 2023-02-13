namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiResource>, System.Collections.IEnumerable
    {
        protected ApiCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiId, Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiId, Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource> Get(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, bool? expandApiVersionSet = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource>> GetAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiData() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class ApiDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>, System.Collections.IEnumerable
    {
        protected ApiDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiDiagnosticResource() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueAttachmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>, System.Collections.IEnumerable
    {
        protected ApiIssueAttachmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachmentId, Azure.ResourceManager.ApiManagement.ApiIssueAttachmentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachmentId, Azure.ResourceManager.ApiManagement.ApiIssueAttachmentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> Get(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>> GetAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiIssueAttachmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiIssueAttachmentData() { }
        public string Content { get { throw null; } set { } }
        public string ContentFormat { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ApiIssueAttachmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiIssueAttachmentResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiIssueAttachmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string attachmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiIssueAttachmentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiIssueAttachmentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueResource>, System.Collections.IEnumerable
    {
        protected ApiIssueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string issueId, Azure.ResourceManager.ApiManagement.IssueContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string issueId, Azure.ResourceManager.ApiManagement.IssueContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource> Get(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiIssueResource> GetAll(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiIssueResource> GetAllAsync(string filter = null, bool? expandCommentsAttachments = default(bool?), int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource>> GetAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiIssueCommentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>, System.Collections.IEnumerable
    {
        protected ApiIssueCommentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commentId, Azure.ResourceManager.ApiManagement.ApiIssueCommentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commentId, Azure.ResourceManager.ApiManagement.ApiIssueCommentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> Get(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>> GetAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiIssueCommentData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiIssueCommentData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserId { get { throw null; } set { } }
    }
    public partial class ApiIssueCommentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiIssueCommentResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiIssueCommentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId, string commentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiIssueCommentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiIssueCommentData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiIssueResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string issueId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource> Get(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource> GetApiIssueAttachment(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource>> GetApiIssueAttachmentAsync(string attachmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiIssueAttachmentCollection GetApiIssueAttachments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource> GetApiIssueComment(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueCommentResource>> GetApiIssueCommentAsync(string commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiIssueCommentCollection GetApiIssueComments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource>> GetAsync(bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementAuthorizationServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>, System.Collections.IEnumerable
    {
        protected ApiManagementAuthorizationServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authsid, Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authsid, Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> Get(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> GetAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementAuthorizationServerData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementAuthorizationServerData() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod> ClientAuthenticationMethods { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ClientRegistrationEndpoint { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DefaultScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? DoesSupportState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.GrantType> GrantTypes { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } set { } }
        public string ResourceOwnerUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.TokenBodyParameterContract> TokenBodyParameters { get { throw null; } }
        public string TokenEndpoint { get { throw null; } set { } }
    }
    public partial class ApiManagementAuthorizationServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementAuthorizationServerResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string authsid) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.AuthorizationServerSecretsContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementAuthorizationServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementAuthorizationServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementBackendCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>, System.Collections.IEnumerable
    {
        protected ApiManagementBackendCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backendId, Azure.ResourceManager.ApiManagement.ApiManagementBackendData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backendId, Azure.ResourceManager.ApiManagement.ApiManagementBackendData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> Get(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> GetAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementBackendData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementBackendData() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiManagementBackendResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementBackendResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementBackendData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string backendId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reconnect(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract backendReconnectContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReconnectAsync(Azure.ResourceManager.ApiManagement.Models.BackendReconnectContract backendReconnectContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementCacheCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>, System.Collections.IEnumerable
    {
        protected ApiManagementCacheCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheId, Azure.ResourceManager.ApiManagement.ApiManagementCacheData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheId, Azure.ResourceManager.ApiManagement.ApiManagementCacheData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> Get(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> GetAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementCacheData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementCacheData() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string UseFromLocation { get { throw null; } set { } }
    }
    public partial class ApiManagementCacheResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementCacheResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementCacheData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string cacheId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementCachePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementCachePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>, System.Collections.IEnumerable
    {
        protected ApiManagementCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.Models.ApiManagementCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.Models.ApiManagementCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementCertificateData() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVaultDetails { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class ApiManagementCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementCertificateResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> RefreshSecret(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> RefreshSecretAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementCertificateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementDeletedServiceCollection : Azure.ResourceManager.ArmCollection
    {
        protected ApiManagementDeletedServiceCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource> Get(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource>> GetAsync(Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementDeletedServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementDeletedServiceData() { }
        public System.DateTimeOffset? DeletedOn { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceId { get { throw null; } set { } }
    }
    public partial class ApiManagementDeletedServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementDeletedServiceResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>, System.Collections.IEnumerable
    {
        protected ApiManagementDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticId, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> Get(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> GetAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementDiagnosticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementDiagnosticResource() { }
        public virtual Azure.ResourceManager.ApiManagement.DiagnosticContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string diagnosticId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementEmailTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>, System.Collections.IEnumerable
    {
        protected ApiManagementEmailTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> Get(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementEmailTemplateData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementEmailTemplateData() { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsDefault { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.EmailTemplateParametersContractProperties> Parameters { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ApiManagementEmailTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementEmailTemplateResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.TemplateName templateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ApiManagementExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult> CheckApiManagementServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityResult>> CheckApiManagementServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiDiagnosticResource GetApiDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiIssueAttachmentResource GetApiIssueAttachmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiIssueCommentResource GetApiIssueCommentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiIssueResource GetApiIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource GetApiManagementAuthorizationServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementBackendResource GetApiManagementBackendResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementCacheResource GetApiManagementCacheResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource GetApiManagementCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource> GetApiManagementDeletedService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource>> GetApiManagementDeletedServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource GetApiManagementDeletedServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceCollection GetApiManagementDeletedServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource> GetApiManagementDeletedServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementDeletedServiceResource> GetApiManagementDeletedServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource GetApiManagementDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource GetApiManagementEmailTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource GetApiManagementGatewayCertificateAuthorityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource GetApiManagementGatewayHostnameConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource GetApiManagementGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource GetApiManagementGlobalSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementGroupResource GetApiManagementGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource GetApiManagementIdentityProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementIssueResource GetApiManagementIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource GetApiManagementLoggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource GetApiManagementNamedValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource GetApiManagementNotificationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource GetApiManagementOpenIdConnectProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource GetApiManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource GetApiManagementPortalDelegationSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource GetApiManagementPortalRevisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource GetApiManagementPortalSignInSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource GetApiManagementPortalSignUpSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource GetApiManagementPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource GetApiManagementPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource GetApiManagementProductPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementProductResource GetApiManagementProductResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource GetApiManagementProductTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetApiManagementServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult> GetApiManagementServiceDomainOwnershipIdentifier(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetDomainOwnershipIdentifierResult>> GetApiManagementServiceDomainOwnershipIdentifierAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceResource GetApiManagementServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementServiceCollection GetApiManagementServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetApiManagementServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementSku> GetApiManagementSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource GetApiManagementSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementTagResource GetApiManagementTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource GetApiManagementTenantSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementUserResource GetApiManagementUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource GetApiManagementUserSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource GetApiOperationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiOperationResource GetApiOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiOperationTagResource GetApiOperationTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiPolicyResource GetApiPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiReleaseResource GetApiReleaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiResource GetApiResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiSchemaResource GetApiSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource GetApiTagDescriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiTagResource GetApiTagResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.ApiVersionSetResource GetApiVersionSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ApiManagement.TenantAccessInfoResource GetTenantAccessInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ApiManagementGatewayCertificateAuthorityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>, System.Collections.IEnumerable
    {
        protected ApiManagementGatewayCertificateAuthorityCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> Get(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>> GetAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementGatewayCertificateAuthorityData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGatewayCertificateAuthorityData() { }
        public bool? IsTrusted { get { throw null; } set { } }
    }
    public partial class ApiManagementGatewayCertificateAuthorityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementGatewayCertificateAuthorityResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string certificateId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>, System.Collections.IEnumerable
    {
        protected ApiManagementGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> Get(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> GetAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementGatewayData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGatewayData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ResourceLocationDataContract LocationData { get { throw null; } set { } }
    }
    public partial class ApiManagementGatewayHostnameConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>, System.Collections.IEnumerable
    {
        protected ApiManagementGatewayHostnameConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hcId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hcId, Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> Get(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>> GetAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementGatewayHostnameConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGatewayHostnameConfigurationData() { }
        public string CertificateId { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public bool? IsClientCertificateRequired { get { throw null; } set { } }
        public bool? IsHttp2_0Enabled { get { throw null; } set { } }
        public bool? IsTls1_0Enabled { get { throw null; } set { } }
        public bool? IsTls1_1Enabled { get { throw null; } set { } }
    }
    public partial class ApiManagementGatewayHostnameConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementGatewayHostnameConfigurationResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId, string hcId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementGatewayResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayApiData> CreateOrUpdateGatewayApi(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract associationContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayApiData>> CreateOrUpdateGatewayApiAsync(string apiId, Azure.ResourceManager.ApiManagement.Models.AssociationContract associationContract = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGatewayApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGatewayApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract> GenerateToken(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract gatewayTokenRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayTokenContract>> GenerateTokenAsync(Azure.ResourceManager.ApiManagement.Models.GatewayTokenRequestContract gatewayTokenRequestContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityCollection GetApiManagementGatewayCertificateAuthorities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource> GetApiManagementGatewayCertificateAuthority(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayCertificateAuthorityResource>> GetApiManagementGatewayCertificateAuthorityAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource> GetApiManagementGatewayHostnameConfiguration(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationResource>> GetApiManagementGatewayHostnameConfigurationAsync(string hcId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayHostnameConfigurationCollection GetApiManagementGatewayHostnameConfigurations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetGatewayApiEntityTag(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetGatewayApiEntityTagAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.GatewayApiData> GetGatewayApisByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.GatewayApiData> GetGatewayApisByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GatewayKeysContract>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateKey(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateKeyAsync(Azure.ResourceManager.ApiManagement.Models.GatewayKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementGlobalSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>, System.Collections.IEnumerable
    {
        protected ApiManagementGlobalSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementGlobalSchemaData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGlobalSchemaData() { }
        public string Description { get { throw null; } set { } }
        public System.BinaryData Document { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiSchemaType? SchemaType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class ApiManagementGlobalSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementGlobalSchemaResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>, System.Collections.IEnumerable
    {
        protected ApiManagementGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupId, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGroupData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupType? GroupType { get { throw null; } set { } }
        public bool? IsBuiltIn { get { throw null; } }
    }
    public partial class ApiManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementGroupResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckGroupUserEntityExists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckGroupUserEntityExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupUserData> CreateGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupUserData>> CreateGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string groupId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGroupUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupUserData> GetGroupUsers(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupUserData> GetGroupUsersAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementIdentityProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>, System.Collections.IEnumerable
    {
        protected ApiManagementIdentityProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> Get(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementIdentityProviderData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementIdentityProviderData() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? IdentityProviderType { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SignInPolicyName { get { throw null; } set { } }
        public string SignInTenant { get { throw null; } set { } }
        public string SignUpPolicyName { get { throw null; } set { } }
    }
    public partial class ApiManagementIdentityProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementIdentityProviderResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>, System.Collections.IEnumerable
    {
        protected ApiManagementIssueCollection() { }
        public virtual Azure.Response<bool> Exists(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> Get(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>> GetAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementIssueResource() { }
        public virtual Azure.ResourceManager.ApiManagement.IssueContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string issueId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementLoggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>, System.Collections.IEnumerable
    {
        protected ApiManagementLoggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string loggerId, Azure.ResourceManager.ApiManagement.ApiManagementLoggerData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string loggerId, Azure.ResourceManager.ApiManagement.ApiManagementLoggerData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> Get(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> GetAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementLoggerData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementLoggerData() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class ApiManagementLoggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementLoggerResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementLoggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string loggerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementNamedValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>, System.Collections.IEnumerable
    {
        protected ApiManagementNamedValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namedValueId, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValueCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namedValueId, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValueCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> Get(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? isKeyVaultRefreshFailed = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> GetAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementNamedValueData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementNamedValueData() { }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractProperties KeyVaultDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ApiManagementNamedValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementNamedValueResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementNamedValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string namedValueId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract> GetValue(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NamedValueSecretContract>> GetValueAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> RefreshSecret(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> RefreshSecretAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> Update(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementNotificationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>, System.Collections.IEnumerable
    {
        protected ApiManagementNotificationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> Get(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementNotificationData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementNotificationData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RecipientsContractProperties Recipients { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ApiManagementNotificationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementNotificationResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementNotificationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckNotificationRecipientEmailEntityExists(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckNotificationRecipientEmailEntityExistsAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckNotificationRecipientUserEntityExists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckNotificationRecipientUserEntityExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> CreateOrUpdateNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract>> CreateOrUpdateNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> CreateOrUpdateNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract>> CreateOrUpdateNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientEmail(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientEmailAsync(string email, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteNotificationRecipientUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteNotificationRecipientUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> GetNotificationRecipientEmails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RecipientEmailContract> GetNotificationRecipientEmailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> GetNotificationRecipientUsers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RecipientUserContract> GetNotificationRecipientUsersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> Update(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementOpenIdConnectProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>, System.Collections.IEnumerable
    {
        protected ApiManagementOpenIdConnectProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string openId, Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string openId, Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> Get(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> GetAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementOpenIdConnectProviderData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementOpenIdConnectProviderData() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class ApiManagementOpenIdConnectProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementOpenIdConnectProviderResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string openId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ClientSecretContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementOpenIdConnectProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementOpenIdConnectProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPortalDelegationSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPortalDelegationSettingData() { }
        public bool? IsSubscriptionDelegationEnabled { get { throw null; } set { } }
        public bool? IsUserRegistrationDelegationEnabled { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string ValidationKey { get { throw null; } set { } }
    }
    public partial class ApiManagementPortalDelegationSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPortalDelegationSettingResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.PortalSettingValidationKeyContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPortalRevisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPortalRevisionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portalRevisionId, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portalRevisionId, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> Get(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> GetAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPortalRevisionData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPortalRevisionData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class ApiManagementPortalRevisionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPortalRevisionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string portalRevisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> Update(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPortalSignInSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPortalSignInSettingData() { }
        public bool? IsRedirectEnabled { get { throw null; } set { } }
    }
    public partial class ApiManagementPortalSignInSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPortalSignInSettingResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPortalSignUpSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPortalSignUpSettingData() { }
        public bool? IsSignUpDeveloperPortalEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
    }
    public partial class ApiManagementPortalSignUpSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPortalSignUpSettingResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ApiManagementPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementPrivateLinkResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string privateLinkSubResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ApiManagementPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> Get(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ApiManagementProductCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>, System.Collections.IEnumerable
    {
        protected ApiManagementProductCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string productId, Azure.ResourceManager.ApiManagement.ApiManagementProductData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string productId, Azure.ResourceManager.ApiManagement.ApiManagementProductData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> Get(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> GetAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementProductData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementProductData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementProductState? State { get { throw null; } set { } }
        public int? SubscriptionsLimit { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
    }
    public partial class ApiManagementProductPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>, System.Collections.IEnumerable
    {
        protected ApiManagementProductPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementProductPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementProductPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementProductResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementProductResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementProductData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<bool> CheckProductApiEntityExists(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckProductApiEntityExistsAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> CheckProductGroupEntityExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckProductGroupEntityExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ProductApiData> CreateOrUpdateProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ProductApiData>> CreateOrUpdateProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ProductGroupData> CreateOrUpdateProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ProductGroupData>> CreateOrUpdateProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteProductGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteProductGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.SubscriptionContractData> GetAllProductSubscriptionData(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.SubscriptionContractData> GetAllProductSubscriptionDataAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyCollection GetApiManagementProductPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource> GetApiManagementProductPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductPolicyResource>> GetApiManagementProductPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> GetApiManagementProductTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>> GetApiManagementProductTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementProductTagCollection GetApiManagementProductTags() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ProductApiData> GetProductApis(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ProductApiData> GetProductApisAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ProductGroupData> GetProductGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ProductGroupData> GetProductGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementProductTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>, System.Collections.IEnumerable
    {
        protected ApiManagementProductTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementProductTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementProductTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string productId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByProduct(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByProductAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementProductTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>, System.Collections.IEnumerable
    {
        protected ApiManagementServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.ApiManagement.ApiManagementServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementServiceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApiManagementServiceData(Azure.Core.AzureLocation location, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku, string publisherEmail, string publisherName) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.Uri DeveloperPortalUri { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public System.Uri GatewayUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri ManagementApiUri { get { throw null; } }
        public string MinApiVersion { get { throw null; } set { } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Uri PortalUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PublicIPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementServiceResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> ApplyNetworkConfigurationUpdates(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> ApplyNetworkConfigurationUpdatesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceApplyNetworkConfigurationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Backup(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> BackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem> CreateOrUpdateContentItem(string contentTypeId, string contentItemId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem>> CreateOrUpdateContentItemAsync(string contentTypeId, string contentItemId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType> CreateOrUpdateContentType(string contentTypeId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType>> CreateOrUpdateContentTypeAsync(string contentTypeId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteContentItem(string contentTypeId, string contentItemId, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentItemAsync(string contentTypeId, string contentItemId, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteContentType(string contentTypeId, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentTypeAsync(string contentTypeId, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData> DeployTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationDeployContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData>> DeployTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationDeployContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource> GetApi(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource>> GetApiAsync(string apiId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> GetApiManagementAuthorizationServer(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> GetApiManagementAuthorizationServerAsync(string authsid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerCollection GetApiManagementAuthorizationServers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> GetApiManagementBackend(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> GetApiManagementBackendAsync(string backendId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementBackendCollection GetApiManagementBackends() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> GetApiManagementCache(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> GetApiManagementCacheAsync(string cacheId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementCacheCollection GetApiManagementCaches() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource> GetApiManagementCertificate(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCertificateResource>> GetApiManagementCertificateAsync(string certificateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementCertificateCollection GetApiManagementCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> GetApiManagementDiagnostic(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> GetApiManagementDiagnosticAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticCollection GetApiManagementDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> GetApiManagementEmailTemplate(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> GetApiManagementEmailTemplateAsync(Azure.ResourceManager.ApiManagement.Models.TemplateName templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateCollection GetApiManagementEmailTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> GetApiManagementGateway(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> GetApiManagementGatewayAsync(string gatewayId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGatewayCollection GetApiManagementGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource> GetApiManagementGlobalSchema(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaResource>> GetApiManagementGlobalSchemaAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGlobalSchemaCollection GetApiManagementGlobalSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> GetApiManagementGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> GetApiManagementGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementGroupCollection GetApiManagementGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> GetApiManagementIdentityProvider(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> GetApiManagementIdentityProviderAsync(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType identityProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderCollection GetApiManagementIdentityProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource> GetApiManagementIssue(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIssueResource>> GetApiManagementIssueAsync(string issueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementIssueCollection GetApiManagementIssues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> GetApiManagementLogger(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> GetApiManagementLoggerAsync(string loggerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementLoggerCollection GetApiManagementLoggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> GetApiManagementNamedValue(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> GetApiManagementNamedValueAsync(string namedValueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementNamedValueCollection GetApiManagementNamedValues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource> GetApiManagementNotification(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementNotificationResource>> GetApiManagementNotificationAsync(Azure.ResourceManager.ApiManagement.Models.NotificationName notificationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementNotificationCollection GetApiManagementNotifications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> GetApiManagementOpenIdConnectProvider(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> GetApiManagementOpenIdConnectProviderAsync(string openId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderCollection GetApiManagementOpenIdConnectProviders() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPolicyCollection GetApiManagementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource> GetApiManagementPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPolicyResource>> GetApiManagementPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingResource GetApiManagementPortalDelegationSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> GetApiManagementPortalRevision(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> GetApiManagementPortalRevisionAsync(string portalRevisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionCollection GetApiManagementPortalRevisions() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingResource GetApiManagementPortalSignInSetting() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingResource GetApiManagementPortalSignUpSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource> GetApiManagementPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionResource>> GetApiManagementPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateEndpointConnectionCollection GetApiManagementPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource> GetApiManagementPrivateLinkResource(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResource>> GetApiManagementPrivateLinkResourceAsync(string privateLinkSubResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementPrivateLinkResourceCollection GetApiManagementPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> GetApiManagementProduct(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> GetApiManagementProductAsync(string productId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementProductCollection GetApiManagementProducts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> GetApiManagementSubscription(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> GetApiManagementSubscriptionAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionCollection GetApiManagementSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> GetApiManagementTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> GetApiManagementTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementTagCollection GetApiManagementTags() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> GetApiManagementTenantSetting(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>> GetApiManagementTenantSettingAsync(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingCollection GetApiManagementTenantSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> GetApiManagementUser(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> GetApiManagementUserAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementUserCollection GetApiManagementUsers() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiCollection GetApis() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetApisByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetApisByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedApis = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> GetApiVersionSet(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> GetApiVersionSetAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiVersionSetCollection GetApiVersionSets() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.AvailableApiManagementServiceSkuResult> GetAvailableApiManagementServiceSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.AvailableApiManagementServiceSkuResult> GetAvailableApiManagementServiceSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem> GetContentItem(string contentTypeId, string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem>> GetContentItemAsync(string contentTypeId, string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetContentItemEntityTag(string contentTypeId, string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetContentItemEntityTagAsync(string contentTypeId, string contentItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem> GetContentItems(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentItem> GetContentItemsAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType> GetContentType(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType>> GetContentTypeAsync(string contentTypeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType> GetContentTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiManagementContentType> GetContentTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract> GetNetworkStatusByLocation(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract>> GetNetworkStatusByLocationAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractWithLocation> GetNetworkStatuses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.NetworkStatusContractWithLocation> GetNetworkStatusesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContractData> GetPolicyDescriptions(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.PolicyDescriptionContractData> GetPolicyDescriptionsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract? scope = default(Azure.ResourceManager.ApiManagement.Models.PolicyScopeContract?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContractData> GetPortalSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.PortalSettingsContractData> GetPortalSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetProductsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetProductsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedProducts = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByCounterKeys(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByCounterKeysAsync(string quotaCounterKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> GetQuotaByPeriodKey(string quotaCounterKey, string quotaPeriodKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> GetQuotaByPeriodKeyAsync(string quotaCounterKey, string quotaPeriodKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RegionContract> GetRegions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RegionContract> GetRegionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByApi(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByApiAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByGeo(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByGeoAsync(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByOperation(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByOperationAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByProduct(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByProductAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.RequestReportRecordContract> GetReportsByRequest(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.RequestReportRecordContract> GetReportsByRequestAsync(string filter, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsBySubscription(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsBySubscriptionAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByTime(string filter, System.TimeSpan interval, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByTimeAsync(string filter, System.TimeSpan interval, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByUser(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ReportRecordContract> GetReportsByUserAsync(string filter, int? top = default(int?), int? skip = default(int?), string orderBy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult> GetSsoToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceGetSsoTokenResult>> GetSsoTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetTagResources(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetTagResourcesAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> GetTenantAccessInfo(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> GetTenantAccessInfoAsync(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.TenantAccessInfoCollection GetTenantAccessInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract> GetTenantConfigurationSyncState(Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantConfigurationSyncStateContract>> GetTenantConfigurationSyncStateAsync(Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResult> PerformConnectivityCheckAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckResult>> PerformConnectivityCheckAsyncAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceBackupRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData> SaveTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationSaveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData>> SaveTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationSaveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiManagementServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByCounterKeys(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByCounterKeysAsync(string quotaCounterKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract> UpdateQuotaByPeriodKey(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.QuotaCounterContract>> UpdateQuotaByPeriodKeyAsync(string quotaCounterKey, string quotaPeriodKey, Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData> ValidateTenantConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationDeployContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.Models.GitOperationResultContractData>> ValidateTenantConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ConfigurationName configurationName, Azure.ResourceManager.ApiManagement.Models.ConfigurationDeployContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ApiManagementSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sid, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionCreateOrUpdateContent content, bool? notify = default(bool?), Azure.ETag? ifMatch = default(Azure.ETag?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sid, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionCreateOrUpdateContent content, bool? notify = default(bool?), Azure.ETag? ifMatch = default(Azure.ETag?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementSubscriptionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string sid) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.SubscriptionKeysContract>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>, System.Collections.IEnumerable
    {
        protected ApiManagementTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityState(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementTenantSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>, System.Collections.IEnumerable
    {
        protected ApiManagementTenantSettingCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> Get(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementTenantSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementTenantSettingData() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
    }
    public partial class ApiManagementTenantSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementTenantSettingResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.SettingsType settingsType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTenantSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>, System.Collections.IEnumerable
    {
        protected ApiManagementUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string userId, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserCreateOrUpdateContent content, bool? notify = default(bool?), Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string userId, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserCreateOrUpdateContent content, bool? notify = default(bool?), Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> Get(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? expandGroups = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> GetAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementUserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementUserResource() { }
        public virtual Azure.ResourceManager.ApiManagement.UserContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUriResult> GenerateSsoUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.GenerateSsoUriResult>> GenerateSsoUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> GetApiManagementUserSubscription(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>> GetApiManagementUserSubscriptionAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionCollection GetApiManagementUserSubscriptions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult> GetSharedAccessToken(Azure.ResourceManager.ApiManagement.Models.UserTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.UserTokenResult>> GetSharedAccessTokenAsync(Azure.ResourceManager.ApiManagement.Models.UserTokenContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> GetUserGroups(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> GetUserGroupsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> GetUserIdentitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendUserConfirmationPassword(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendUserConfirmationPasswordAsync(Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiManagementUserSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ApiManagementUserSubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> Get(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>> GetAsync(string sid, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiManagementUserSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiManagementUserSubscriptionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.SubscriptionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string userId, string sid) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationResource>, System.Collections.IEnumerable
    {
        protected ApiOperationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ApiManagement.ApiOperationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string operationId, Azure.ResourceManager.ApiManagement.ApiOperationData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiOperationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiOperationResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiOperationData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiOperationData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public string Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RequestContract Request { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ResponseContract> Responses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> TemplateParameters { get { throw null; } }
        public string UriTemplate { get { throw null; } set { } }
    }
    public partial class ApiOperationPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>, System.Collections.IEnumerable
    {
        protected ApiOperationPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiOperationPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiOperationPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiOperationResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiOperationPolicyCollection GetApiOperationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource> GetApiOperationPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationPolicyResource>> GetApiOperationPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> GetApiOperationTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>> GetApiOperationTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiOperationTagCollection GetApiOperationTags() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiOperationTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>, System.Collections.IEnumerable
    {
        protected ApiOperationTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiOperationTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiOperationTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string operationId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByOperation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByOperationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiOperationTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiPolicyResource>, System.Collections.IEnumerable
    {
        protected ApiPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiPolicyResource() { }
        public virtual Azure.ResourceManager.ApiManagement.PolicyContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, Azure.ResourceManager.ApiManagement.Models.PolicyName policyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource> Get(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.PolicyContractData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiReleaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseResource>, System.Collections.IEnumerable
    {
        protected ApiReleaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiReleaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string releaseId, Azure.ResourceManager.ApiManagement.ApiReleaseData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource> Get(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiReleaseResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiReleaseResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> GetAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiReleaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiReleaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiReleaseData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiReleaseData() { }
        public Azure.Core.ResourceIdentifier ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class ApiReleaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiReleaseResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiReleaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string releaseId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> GetApiDiagnostic(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> GetApiDiagnosticAsync(string diagnosticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiDiagnosticCollection GetApiDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource> GetApiIssue(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource>> GetApiIssueAsync(string issueId, bool? expandCommentsAttachments = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiIssueCollection GetApiIssues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource> GetApiOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource>> GetApiOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiOperationCollection GetApiOperations() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiPolicyCollection GetApiPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource> GetApiPolicy(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiPolicyResource>> GetApiPolicyAsync(Azure.ResourceManager.ApiManagement.Models.PolicyName policyId, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat? format = default(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> GetApiProducts(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> GetApiProductsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource> GetApiRelease(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> GetApiReleaseAsync(string releaseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiReleaseCollection GetApiReleases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByService(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.ApiRevisionContract> GetApiRevisionsByServiceAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource> GetApiSchema(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource>> GetApiSchemaAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiSchemaCollection GetApiSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource> GetApiTag(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource>> GetApiTagAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> GetApiTagDescription(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>> GetApiTagDescriptionAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiTagDescriptionCollection GetApiTagDescriptions() { throw null; }
        public virtual Azure.ResourceManager.ApiManagement.ApiTagCollection GetApiTags() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetOperationsByTags(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.Models.TagResourceContractDetails> GetOperationsByTagsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), bool? includeNotTaggedOperations = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiSchemaResource>, System.Collections.IEnumerable
    {
        protected ApiSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.ApiSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaId, Azure.ResourceManager.ApiManagement.ApiSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource> Get(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiSchemaResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiSchemaResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource>> GetAsync(string schemaId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiSchemaData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiSchemaData() { }
        public System.BinaryData Components { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.BinaryData Definitions { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ApiSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiSchemaResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string schemaId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.ApiSchemaData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiTagCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiTagResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiTagResource>, System.Collections.IEnumerable
    {
        protected ApiTagCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource> Get(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiTagResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiTagResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource>> GetAsync(string tagId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiTagResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiTagResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiTagResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiTagResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiTagDescriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>, System.Collections.IEnumerable
    {
        protected ApiTagDescriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tagDescriptionId, Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> Get(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>> GetAsync(string tagDescriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiTagDescriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiTagDescriptionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public System.Uri ExternalDocsUri { get { throw null; } set { } }
        public string TagId { get { throw null; } set { } }
    }
    public partial class ApiTagDescriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiTagDescriptionResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiTagDescriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagDescriptionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagDescriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.ApiTagDescriptionCreateOrUpdateContent content, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiTagResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiTagResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TagContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiId, string tagId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiTagResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityStateByApi(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityStateByApiAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiTagResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiVersionSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>, System.Collections.IEnumerable
    {
        protected ApiVersionSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionSetId, Azure.ResourceManager.ApiManagement.ApiVersionSetData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> Get(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> GetAsync(string versionSetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiVersionSetData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiVersionSetData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    public partial class ApiVersionSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiVersionSetResource() { }
        public virtual Azure.ResourceManager.ApiManagement.ApiVersionSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string versionSetId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticContractData : Azure.ResourceManager.Models.ResourceData
    {
        public DiagnosticContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.AlwaysLog? AlwaysLog { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Backend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PipelineDiagnosticSettings Frontend { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol? HttpCorrelationProtocol { get { throw null; } set { } }
        public bool? IsLogClientIPEnabled { get { throw null; } set { } }
        public string LoggerId { get { throw null; } set { } }
        public bool? Metrics { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.OperationNameFormat? OperationNameFormat { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SamplingSettings Sampling { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel? Verbosity { get { throw null; } set { } }
    }
    public partial class IssueContractData : Azure.ResourceManager.Models.ResourceData
    {
        public IssueContractData() { }
        public Azure.Core.ResourceIdentifier ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IssueState? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserId { get { throw null; } set { } }
    }
    public partial class PolicyContractData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyContractData() { }
        public Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat? Format { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SubscriptionContractData : Azure.ResourceManager.Models.ResourceData
    {
        public SubscriptionContractData() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotifiesOn { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    public partial class TagContractData : Azure.ResourceManager.Models.ResourceData
    {
        public TagContractData() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class TenantAccessInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>, System.Collections.IEnumerable
    {
        protected TenantAccessInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessName accessName, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessName accessName, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> Get(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> GetAsync(Azure.ResourceManager.ApiManagement.Models.AccessName accessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantAccessInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public TenantAccessInfoData() { }
        public string AccessInfoType { get { throw null; } set { } }
        public bool? IsDirectAccessEnabled { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
    }
    public partial class TenantAccessInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantAccessInfoResource() { }
        public virtual Azure.ResourceManager.ApiManagement.TenantAccessInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, Azure.ResourceManager.ApiManagement.Models.AccessName accessName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> GetEntityTag(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> GetEntityTagAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoSecretsDetails> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoSecretsDetails>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegeneratePrimaryKeyForGit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegeneratePrimaryKeyForGitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateSecondaryKeyForGit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateSecondaryKeyForGitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserContractData : Azure.ResourceManager.Models.ResourceData
    {
        public UserContractData() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.GroupContractProperties> Groups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public System.DateTimeOffset? RegistriesOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState? State { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ApiManagement.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AccessName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AccessName TenantAccess { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AccessName TenantGitAccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AccessName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AccessName left, Azure.ResourceManager.ApiManagement.Models.AccessName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AccessName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AccessName left, Azure.ResourceManager.ApiManagement.Models.AccessName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalLocation
    {
        public AdditionalLocation(Azure.Core.AzureLocation location, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties sku) { }
        public bool? DisableGateway { get { throw null; } set { } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PublicIPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlwaysLog : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AlwaysLog>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlwaysLog(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AlwaysLog AllErrors { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AlwaysLog other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AlwaysLog left, Azure.ResourceManager.ApiManagement.Models.AlwaysLog right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AlwaysLog (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AlwaysLog left, Azure.ResourceManager.ApiManagement.Models.AlwaysLog right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiContactInformation
    {
        public ApiContactInformation() { }
        public string Email { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiCreateOrUpdateContent
    {
        public ApiCreateOrUpdateContent() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ContentFormat? Format { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SoapApiType? SoapApiType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiCreateOrUpdatePropertiesWsdlSelector WsdlSelector { get { throw null; } set { } }
    }
    public partial class ApiCreateOrUpdatePropertiesWsdlSelector
    {
        public ApiCreateOrUpdatePropertiesWsdlSelector() { }
        public string WsdlEndpointName { get { throw null; } set { } }
        public string WsdlServiceName { get { throw null; } set { } }
    }
    public partial class ApiEntityBaseContract
    {
        internal ApiEntityBaseContract() { }
        public string ApiRevision { get { throw null; } }
        public string ApiRevisionDescription { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } }
        public string ApiVersion { get { throw null; } }
        public string ApiVersionDescription { get { throw null; } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsCurrent { get { throw null; } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } }
        public System.Uri TermsOfServiceUri { get { throw null; } }
    }
    public partial class ApiIssuePatch
    {
        public ApiIssuePatch() { }
        public Azure.Core.ResourceIdentifier ApiId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IssueState? State { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string UserId { get { throw null; } set { } }
    }
    public partial class ApiLicenseInformation
    {
        public ApiLicenseInformation() { }
        public string Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiManagementAuthorizationServerPatch : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementAuthorizationServerPatch() { }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AuthorizationMethod> AuthorizationMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod> ClientAuthenticationMethods { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ClientRegistrationEndpoint { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DefaultScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? DoesSupportState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.GrantType> GrantTypes { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } set { } }
        public string ResourceOwnerUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.TokenBodyParameterContract> TokenBodyParameters { get { throw null; } }
        public string TokenEndpoint { get { throw null; } set { } }
    }
    public partial class ApiManagementBackendPatch
    {
        public ApiManagementBackendPatch() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendServiceFabricClusterProperties BackendServiceFabricCluster { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendCredentialsContract Credentials { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendProxyContract Proxy { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.BackendTlsProperties Tls { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApiManagementCachePatch
    {
        public ApiManagementCachePatch() { }
        public string ConnectionString { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Uri ResourceUri { get { throw null; } set { } }
        public string UseFromLocation { get { throw null; } set { } }
    }
    public partial class ApiManagementCertificateCreateOrUpdateContent
    {
        public ApiManagementCertificateCreateOrUpdateContent() { }
        public string Data { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVaultDetails { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
    }
    public partial class ApiManagementContentItem
    {
        public ApiManagementContentItem() { }
        public string ContentItemId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Properties { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
    }
    public partial class ApiManagementContentType
    {
        public ApiManagementContentType() { }
        public string ContentTypeId { get { throw null; } }
        public string ContentTypeIdentifier { get { throw null; } set { } }
        public string ContentTypeName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ApiManagementEmailTemplateCreateOrUpdateContent
    {
        public ApiManagementEmailTemplateCreateOrUpdateContent() { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.EmailTemplateParametersContractProperties> Parameters { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ApiManagementGroupCreateOrUpdateContent
    {
        public ApiManagementGroupCreateOrUpdateContent() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupType? ApiManagementGroupType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
    }
    public partial class ApiManagementGroupPatch
    {
        public ApiManagementGroupPatch() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupType? ApiManagementGroupType { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
    }
    public enum ApiManagementGroupType
    {
        Custom = 0,
        System = 1,
        External = 2,
    }
    public partial class ApiManagementGroupUserData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementGroupUserData() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.GroupContractProperties> Groups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public System.DateTimeOffset? RegistriesOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState? State { get { throw null; } set { } }
    }
    public partial class ApiManagementIdentityProviderCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementIdentityProviderCreateOrUpdateContent() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? IdentityProviderType { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SignInPolicyName { get { throw null; } set { } }
        public string SignInTenant { get { throw null; } set { } }
        public string SignUpPolicyName { get { throw null; } set { } }
    }
    public partial class ApiManagementIdentityProviderPatch
    {
        public ApiManagementIdentityProviderPatch() { }
        public System.Collections.Generic.IList<string> AllowedTenants { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.IdentityProviderType? IdentityProviderType { get { throw null; } set { } }
        public string PasswordResetPolicyName { get { throw null; } set { } }
        public string ProfileEditingPolicyName { get { throw null; } set { } }
        public string SignInPolicyName { get { throw null; } set { } }
        public string SignInTenant { get { throw null; } set { } }
        public string SignUpPolicyName { get { throw null; } set { } }
    }
    public partial class ApiManagementLoggerPatch
    {
        public ApiManagementLoggerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Credentials { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsBuffered { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.LoggerType? LoggerType { get { throw null; } set { } }
    }
    public partial class ApiManagementNamedValueCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementNamedValueCreateOrUpdateContent() { }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ApiManagementNamedValuePatch
    {
        public ApiManagementNamedValuePatch() { }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsSecret { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties KeyVault { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ApiManagementOpenIdConnectProviderPatch
    {
        public ApiManagementOpenIdConnectProviderPatch() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string MetadataEndpoint { get { throw null; } set { } }
    }
    public partial class ApiManagementPrivateEndpointConnectionCreateOrUpdateContent
    {
        public ApiManagementPrivateEndpointConnectionCreateOrUpdateContent() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiManagementPrivateLinkServiceConnectionState
    {
        public ApiManagementPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class ApiManagementProductPatch
    {
        public ApiManagementProductPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementProductState? State { get { throw null; } set { } }
        public int? SubscriptionsLimit { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
    }
    public enum ApiManagementProductState
    {
        NotPublished = 0,
        Published = 1,
    }
    public partial class ApiManagementResourceSkuCapacity
    {
        internal ApiManagementResourceSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementResourceSkuCapacityScaleType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementResourceSkuCapacityScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType left, Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType left, Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacityScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiManagementServiceApplyNetworkConfigurationContent
    {
        public ApiManagementServiceApplyNetworkConfigurationContent() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class ApiManagementServiceBackupRestoreContent
    {
        public ApiManagementServiceBackupRestoreContent(string storageAccount, string containerName, string backupName) { }
        public string AccessKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType? AccessType { get { throw null; } set { } }
        public string BackupName { get { throw null; } }
        public string ClientId { get { throw null; } set { } }
        public string ContainerName { get { throw null; } }
        public string StorageAccount { get { throw null; } }
    }
    public partial class ApiManagementServiceGetDomainOwnershipIdentifierResult
    {
        internal ApiManagementServiceGetDomainOwnershipIdentifierResult() { }
        public string DomainOwnershipIdentifier { get { throw null; } }
    }
    public partial class ApiManagementServiceGetSsoTokenResult
    {
        internal ApiManagementServiceGetSsoTokenResult() { }
        public System.Uri RedirectUri { get { throw null; } }
    }
    public partial class ApiManagementServiceNameAvailabilityContent
    {
        public ApiManagementServiceNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class ApiManagementServiceNameAvailabilityResult
    {
        internal ApiManagementServiceNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum ApiManagementServiceNameUnavailableReason
    {
        Valid = 0,
        Invalid = 1,
        AlreadyExists = 2,
    }
    public partial class ApiManagementServicePatch : Azure.ResourceManager.Models.ResourceData
    {
        public ApiManagementServicePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.AdditionalLocation> AdditionalLocations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.CertificateConfiguration> Certificates { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomProperties { get { throw null; } }
        public System.Uri DeveloperPortalUri { get { throw null; } }
        public bool? DisableGateway { get { throw null; } set { } }
        public bool? EnableClientCertificate { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Uri GatewayRegionalUri { get { throw null; } }
        public System.Uri GatewayUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HostnameConfiguration> HostnameConfigurations { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Uri ManagementApiUri { get { throw null; } }
        public string MinApiVersion { get { throw null; } set { } }
        public string NotificationSenderEmail { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PlatformVersion? PlatformVersion { get { throw null; } }
        public System.Uri PortalUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RemotePrivateEndpointConnectionWrapper> PrivateEndpointConnections { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PrivateIPAddresses { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Net.IPAddress> PublicIPAddresses { get { throw null; } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PublisherEmail { get { throw null; } set { } }
        public string PublisherName { get { throw null; } set { } }
        public bool? Restore { get { throw null; } set { } }
        public System.Uri ScmUri { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuProperties Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType? VirtualNetworkType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementServiceSkuProperties
    {
        public ApiManagementServiceSkuProperties(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType name, int capacity) { }
        public int Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementServiceSkuType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementServiceSkuType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Basic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Consumption { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Developer { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Isolated { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Premium { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType left, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType left, Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiManagementSku
    {
        internal ApiManagementSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ApiManagementSkuCapabilities
    {
        internal ApiManagementSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ApiManagementSkuCapacity
    {
        internal ApiManagementSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapacityScaleType? ScaleType { get { throw null; } }
    }
    public enum ApiManagementSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class ApiManagementSkuCosts
    {
        internal ApiManagementSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
    }
    public partial class ApiManagementSkuLocationInfo
    {
        internal ApiManagementSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementSkuRestrictionInfo
    {
        internal ApiManagementSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ApiManagementSkuRestrictions
    {
        internal ApiManagementSkuRestrictions() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum ApiManagementSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ApiManagementSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ApiManagementSkuZoneDetails
    {
        internal ApiManagementSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiManagementSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class ApiManagementSubscriptionCreateOrUpdateContent
    {
        public ApiManagementSubscriptionCreateOrUpdateContent() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
    }
    public partial class ApiManagementSubscriptionPatch
    {
        public ApiManagementSubscriptionPatch() { }
        public bool? AllowTracing { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string OwnerId { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionState? State { get { throw null; } set { } }
        public string StateComment { get { throw null; } set { } }
    }
    public partial class ApiManagementTagCreateOrUpdateContent
    {
        public ApiManagementTagCreateOrUpdateContent() { }
        public string DisplayName { get { throw null; } set { } }
    }
    public partial class ApiManagementUserCreateOrUpdateContent
    {
        public ApiManagementUserCreateOrUpdateContent() { }
        public Azure.ResourceManager.ApiManagement.Models.AppType? AppType { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType? Confirmation { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState? State { get { throw null; } set { } }
    }
    public partial class ApiManagementUserPatch
    {
        public ApiManagementUserPatch() { }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.UserIdentityContract> Identities { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiManagementUserState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiManagementUserState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState Active { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState Blocked { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState left, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiOperationInvokableProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiOperationInvokableProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol Ws { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol Wss { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol left, Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol left, Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiOperationPatch
    {
        public ApiOperationPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public string Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.RequestContract Request { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ResponseContract> Responses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> TemplateParameters { get { throw null; } }
        public string UriTemplate { get { throw null; } set { } }
    }
    public partial class ApiPatch
    {
        public ApiPatch() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class ApiRevisionContract
    {
        internal ApiRevisionContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRevision { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsCurrent { get { throw null; } }
        public bool? IsOnline { get { throw null; } }
        public System.Uri PrivateUri { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiSchemaType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiSchemaType Json { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiSchemaType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiSchemaType left, Azure.ResourceManager.ApiManagement.Models.ApiSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiSchemaType left, Azure.ResourceManager.ApiManagement.Models.ApiSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiTagDescriptionCreateOrUpdateContent
    {
        public ApiTagDescriptionCreateOrUpdateContent() { }
        public string Description { get { throw null; } set { } }
        public string ExternalDocsDescription { get { throw null; } set { } }
        public System.Uri ExternalDocsUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType GraphQL { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType Soap { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ApiType WebSocket { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ApiType left, Azure.ResourceManager.ApiManagement.Models.ApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ApiType left, Azure.ResourceManager.ApiManagement.Models.ApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiVersionSetContractDetails
    {
        public ApiVersionSetContractDetails() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    public partial class ApiVersionSetPatch
    {
        public ApiVersionSetPatch() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string VersionHeaderName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.VersioningScheme? VersioningScheme { get { throw null; } set { } }
        public string VersionQueryName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AppType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AppType DeveloperPortal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.AppType Portal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AppType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AppType left, Azure.ResourceManager.ApiManagement.Models.AppType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AppType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AppType left, Azure.ResourceManager.ApiManagement.Models.AppType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssociatedApiProperties : Azure.ResourceManager.ApiManagement.Models.ApiEntityBaseContract
    {
        internal AssociatedApiProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
    }
    public partial class AssociatedOperationProperties
    {
        internal AssociatedOperationProperties() { }
        public string ApiName { get { throw null; } }
        public string ApiRevision { get { throw null; } }
        public string ApiVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Name { get { throw null; } }
        public string UriTemplate { get { throw null; } }
    }
    public partial class AssociatedProductProperties : Azure.ResourceManager.ApiManagement.Models.ProductEntityBaseProperties
    {
        internal AssociatedProductProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class AssociatedTagProperties
    {
        internal AssociatedTagProperties() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class AssociationContract : Azure.ResourceManager.Models.ResourceData
    {
        public AssociationContract() { }
        public Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssociationEntityProvisioningState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssociationEntityProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState Created { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState left, Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState left, Azure.ResourceManager.ApiManagement.Models.AssociationEntityProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AsyncOperationStatus
    {
        Started = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public partial class AuthenticationSettingsContract
    {
        public AuthenticationSettingsContract() { }
        public Azure.ResourceManager.ApiManagement.Models.OAuth2AuthenticationSettingsContract OAuth2 { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.OpenIdAuthenticationSettingsContract OpenId { get { throw null; } set { } }
    }
    public enum AuthorizationMethod
    {
        Head = 0,
        Options = 1,
        Trace = 2,
        Get = 3,
        Post = 4,
        Put = 5,
        Patch = 6,
        Delete = 7,
    }
    public partial class AuthorizationServerSecretsContract
    {
        internal AuthorizationServerSecretsContract() { }
        public string ClientSecret { get { throw null; } }
        public string ResourceOwnerPassword { get { throw null; } }
        public string ResourceOwnerUsername { get { throw null; } }
    }
    public partial class AvailableApiManagementServiceSkuResult
    {
        internal AvailableApiManagementServiceSkuResult() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementResourceSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementServiceSkuType? SkuName { get { throw null; } }
    }
    public partial class BackendAuthorizationHeaderCredentials
    {
        public BackendAuthorizationHeaderCredentials(string scheme, string parameter) { }
        public string Parameter { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
    }
    public partial class BackendCredentialsContract
    {
        public BackendCredentialsContract() { }
        public Azure.ResourceManager.ApiManagement.Models.BackendAuthorizationHeaderCredentials Authorization { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Certificate { get { throw null; } }
        public System.Collections.Generic.IList<string> CertificateIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Header { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Query { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackendProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BackendProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackendProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BackendProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BackendProtocol Soap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BackendProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BackendProtocol left, Azure.ResourceManager.ApiManagement.Models.BackendProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BackendProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BackendProtocol left, Azure.ResourceManager.ApiManagement.Models.BackendProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackendProxyContract
    {
        public BackendProxyContract(System.Uri uri) { }
        public string Password { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class BackendReconnectContract : Azure.ResourceManager.Models.ResourceData
    {
        public BackendReconnectContract() { }
        public System.TimeSpan? After { get { throw null; } set { } }
    }
    public partial class BackendServiceFabricClusterProperties
    {
        public BackendServiceFabricClusterProperties(System.Collections.Generic.IEnumerable<string> managementEndpoints) { }
        public string ClientCertificateId { get { throw null; } set { } }
        public string ClientCertificatethumbprint { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManagementEndpoints { get { throw null; } }
        public int? MaxPartitionResolutionRetries { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServerCertificateThumbprints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.X509CertificateName> ServerX509Names { get { throw null; } }
    }
    public partial class BackendTlsProperties
    {
        public BackendTlsProperties() { }
        public bool? ShouldValidateCertificateChain { get { throw null; } set { } }
        public bool? ShouldValidateCertificateName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BearerTokenSendingMethod : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BearerTokenSendingMethod(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod AuthorizationHeader { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod Query { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod left, Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateConfiguration
    {
        public CertificateConfiguration(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName storeName) { }
        public Azure.ResourceManager.ApiManagement.Models.CertificateInformation Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName StoreName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateConfigurationStoreName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateConfigurationStoreName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName CertificateAuthority { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName Root { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName left, Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName left, Azure.ResourceManager.ApiManagement.Models.CertificateConfigurationStoreName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertificateInformation
    {
        public CertificateInformation(System.DateTimeOffset expireOn, string thumbprint, string subject) { }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateSource : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateSource(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource Custom { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource KeyVault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateSource Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateSource left, Azure.ResourceManager.ApiManagement.Models.CertificateSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateSource left, Azure.ResourceManager.ApiManagement.Models.CertificateSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificateStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.CertificateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificateStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.CertificateStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.CertificateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.CertificateStatus left, Azure.ResourceManager.ApiManagement.Models.CertificateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.CertificateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.CertificateStatus left, Azure.ResourceManager.ApiManagement.Models.CertificateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientAuthenticationMethod : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod Basic { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod Body { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod left, Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod left, Azure.ResourceManager.ApiManagement.Models.ClientAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientSecretContract
    {
        internal ClientSecretContract() { }
        public string ClientSecret { get { throw null; } }
    }
    public partial class ConfigurationDeployContent
    {
        public ConfigurationDeployContent() { }
        public string Branch { get { throw null; } set { } }
        public bool? ForceDelete { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConfigurationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConfigurationName Configuration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConfigurationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConfigurationName left, Azure.ResourceManager.ApiManagement.Models.ConfigurationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConfigurationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConfigurationName left, Azure.ResourceManager.ApiManagement.Models.ConfigurationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationSaveContent
    {
        public ConfigurationSaveContent() { }
        public string Branch { get { throw null; } set { } }
        public bool? ForceUpdate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfirmationEmailType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfirmationEmailType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType Invite { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType SignUp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType left, Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType left, Azure.ResourceManager.ApiManagement.Models.ConfirmationEmailType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectionStatus left, Azure.ResourceManager.ApiManagement.Models.ConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectivityCheckContent
    {
        public ConnectivityCheckContent(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource source, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination destination) { }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestDestination Destination { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion? PreferredIPVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestHttpConfiguration ProtocolHttpConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckRequestSource Source { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityCheckProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityCheckProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol left, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol left, Azure.ResourceManager.ApiManagement.Models.ConnectivityCheckProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectivityCheckRequestDestination
    {
        public ConnectivityCheckRequestDestination(string address, long port) { }
        public string Address { get { throw null; } }
        public long Port { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestHttpConfiguration
    {
        public ConnectivityCheckRequestHttpConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.HttpHeaderConfiguration> Headers { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration? Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<long> ValidStatusCodes { get { throw null; } }
    }
    public partial class ConnectivityCheckRequestSource
    {
        public ConnectivityCheckRequestSource(string region) { }
        public long? Instance { get { throw null; } set { } }
        public string Region { get { throw null; } }
    }
    public partial class ConnectivityCheckResult
    {
        internal ConnectivityCheckResult() { }
        public long? AvgLatencyInMs { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectionStatus? ConnectionStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityHop> Hops { get { throw null; } }
        public long? MaxLatencyInMs { get { throw null; } }
        public long? MinLatencyInMs { get { throw null; } }
        public long? ProbesFailed { get { throw null; } }
        public long? ProbesSent { get { throw null; } }
    }
    public partial class ConnectivityHop
    {
        internal ConnectivityHop() { }
        public System.Net.IPAddress Address { get { throw null; } }
        public string ConnectivityHopType { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityIssue> Issues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NextHopIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
    }
    public partial class ConnectivityIssue
    {
        internal ConnectivityIssue() { }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, string>> Context { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.IssueType? IssueType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.IssueOrigin? Origin { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.IssueSeverity? Severity { get { throw null; } }
    }
    public partial class ConnectivityStatusContract
    {
        internal ConnectivityStatusContract() { }
        public string Error { get { throw null; } }
        public bool IsOptional { get { throw null; } }
        public System.DateTimeOffset LastStatusChangedOn { get { throw null; } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityStatusType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityStatusType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Failure { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Initializing { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType left, Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType left, Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.ContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat GraphQLLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenApi { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenApiJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenApiJsonLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat OpenApiLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat SwaggerJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat SwaggerLinkJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WadlLinkJson { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WadlXml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat Wsdl { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.ContentFormat WsdlLink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.ContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.ContentFormat left, Azure.ResourceManager.ApiManagement.Models.ContentFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.ContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.ContentFormat left, Azure.ResourceManager.ApiManagement.Models.ContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataMasking
    {
        public DataMasking() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.DataMaskingEntity> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.DataMaskingEntity> QueryParams { get { throw null; } }
    }
    public partial class DataMaskingEntity
    {
        public DataMaskingEntity() { }
        public Azure.ResourceManager.ApiManagement.Models.DataMaskingMode? Mode { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMaskingMode : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.DataMaskingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMaskingMode(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.DataMaskingMode Hide { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.DataMaskingMode Mask { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode left, Azure.ResourceManager.ApiManagement.Models.DataMaskingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.DataMaskingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.DataMaskingMode left, Azure.ResourceManager.ApiManagement.Models.DataMaskingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmailTemplateParametersContractProperties
    {
        public EmailTemplateParametersContractProperties() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class EndpointDependency
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        internal EndpointDetail() { }
        public int? Port { get { throw null; } }
        public string Region { get { throw null; } }
    }
    public partial class ErrorFieldContract
    {
        public ErrorFieldContract() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class ErrorResponseBody
    {
        public ErrorResponseBody() { }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ErrorFieldContract> Details { get { throw null; } }
        public string Message { get { throw null; } set { } }
    }
    public partial class GatewayApiData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayApiData() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class GatewayKeyRegenerateContent
    {
        public GatewayKeyRegenerateContent(Azure.ResourceManager.ApiManagement.Models.GatewayRegenerateKeyType keyType) { }
        public Azure.ResourceManager.ApiManagement.Models.GatewayRegenerateKeyType KeyType { get { throw null; } }
    }
    public partial class GatewayKeysContract
    {
        internal GatewayKeysContract() { }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
    }
    public enum GatewayRegenerateKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class GatewayTokenContract
    {
        internal GatewayTokenContract() { }
        public string Value { get { throw null; } }
    }
    public partial class GatewayTokenRequestContract
    {
        public GatewayTokenRequestContract(Azure.ResourceManager.ApiManagement.Models.TokenGenerationUsedKeyType keyType, System.DateTimeOffset expiry) { }
        public System.DateTimeOffset Expiry { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.TokenGenerationUsedKeyType KeyType { get { throw null; } }
    }
    public partial class GenerateSsoUriResult
    {
        internal GenerateSsoUriResult() { }
        public string Value { get { throw null; } }
    }
    public partial class GitOperationResultContractData : Azure.ResourceManager.Models.ResourceData
    {
        public GitOperationResultContractData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.OperationResultLogItemContract> ActionLog { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ErrorResponseBody Error { get { throw null; } set { } }
        public string OperationResultIdentifier { get { throw null; } set { } }
        public string ResultInfo { get { throw null; } set { } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AsyncOperationStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrantType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.GrantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrantType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType AuthorizationCode { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType ClientCredentials { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType Implicit { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.GrantType ResourceOwnerPassword { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.GrantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.GrantType left, Azure.ResourceManager.ApiManagement.Models.GrantType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.GrantType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.GrantType left, Azure.ResourceManager.ApiManagement.Models.GrantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupContractProperties
    {
        internal GroupContractProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupType? ApiManagementGroupType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExternalId { get { throw null; } }
        public bool? IsBuiltIn { get { throw null; } }
    }
    public partial class HostnameConfiguration
    {
        public HostnameConfiguration(Azure.ResourceManager.ApiManagement.Models.HostnameType hostnameType, string hostName) { }
        public Azure.ResourceManager.ApiManagement.Models.CertificateInformation Certificate { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateSource? CertificateSource { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.CertificateStatus? CertificateStatus { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HostnameType HostnameType { get { throw null; } set { } }
        public string IdentityClientId { get { throw null; } set { } }
        public bool? IsClientCertificateNegotiationEnabled { get { throw null; } set { } }
        public bool? IsDefaultSslBindingEnabled { get { throw null; } set { } }
        public System.Uri KeyVaultSecretUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostnameType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.HostnameType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostnameType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType DeveloperPortal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Management { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Portal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Proxy { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HostnameType Scm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.HostnameType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.HostnameType left, Azure.ResourceManager.ApiManagement.Models.HostnameType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.HostnameType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.HostnameType left, Azure.ResourceManager.ApiManagement.Models.HostnameType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpCorrelationProtocol : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpCorrelationProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol Legacy { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol None { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol W3C { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol left, Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol left, Azure.ResourceManager.ApiManagement.Models.HttpCorrelationProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpHeaderConfiguration
    {
        public HttpHeaderConfiguration(string name, string value) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class HttpMessageDiagnostic
    {
        public HttpMessageDiagnostic() { }
        public int? BodyBytes { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.DataMasking DataMasking { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpMethodConfiguration : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpMethodConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration Get { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration Post { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration left, Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration left, Azure.ResourceManager.ApiManagement.Models.HttpMethodConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityProviderType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IdentityProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityProviderType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Aad { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType AadB2C { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Facebook { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Google { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Microsoft { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IdentityProviderType Twitter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType left, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IdentityProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IdentityProviderType left, Azure.ResourceManager.ApiManagement.Models.IdentityProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueOrigin : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IssueOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueOrigin(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IssueOrigin Inbound { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueOrigin Local { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueOrigin Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IssueOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IssueOrigin left, Azure.ResourceManager.ApiManagement.Models.IssueOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IssueOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IssueOrigin left, Azure.ResourceManager.ApiManagement.Models.IssueOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueSeverity : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IssueSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueSeverity(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IssueSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IssueSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IssueSeverity left, Azure.ResourceManager.ApiManagement.Models.IssueSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IssueSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IssueSeverity left, Azure.ResourceManager.ApiManagement.Models.IssueSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueState : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IssueState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueState(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IssueState Closed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueState Open { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueState Proposed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueState Removed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueState Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IssueState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IssueState left, Azure.ResourceManager.ApiManagement.Models.IssueState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IssueState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IssueState left, Azure.ResourceManager.ApiManagement.Models.IssueState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.IssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType AgentStopped { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType DnsResolution { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType GuestFirewall { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType NetworkSecurityRule { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType Platform { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType PortThrottled { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType SocketBind { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType Unknown { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.IssueType UserDefinedRoute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.IssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.IssueType left, Azure.ResourceManager.ApiManagement.Models.IssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.IssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.IssueType left, Azure.ResourceManager.ApiManagement.Models.IssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultContractCreateProperties
    {
        public KeyVaultContractCreateProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string SecretIdentifier { get { throw null; } set { } }
    }
    public partial class KeyVaultContractProperties : Azure.ResourceManager.ApiManagement.Models.KeyVaultContractCreateProperties
    {
        public KeyVaultContractProperties() { }
        public Azure.ResourceManager.ApiManagement.Models.KeyVaultLastAccessStatusContractProperties LastStatus { get { throw null; } set { } }
    }
    public partial class KeyVaultLastAccessStatusContractProperties
    {
        public KeyVaultLastAccessStatusContractProperties() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? TimeStampUtc { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggerType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.LoggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggerType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType AzureEventHub { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.LoggerType AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.LoggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.LoggerType left, Azure.ResourceManager.ApiManagement.Models.LoggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.LoggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.LoggerType left, Azure.ResourceManager.ApiManagement.Models.LoggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamedValueSecretContract
    {
        internal NamedValueSecretContract() { }
        public string Value { get { throw null; } }
    }
    public partial class NetworkStatusContract
    {
        internal NetworkStatusContract() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.ConnectivityStatusContract> ConnectivityStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsServers { get { throw null; } }
    }
    public partial class NetworkStatusContractWithLocation
    {
        internal NetworkStatusContractWithLocation() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.NetworkStatusContract NetworkStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.NotificationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName AccountClosedPublisher { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName Bcc { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName NewApplicationNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName NewIssuePublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName PurchasePublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName QuotaLimitApproachingPublisherNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.NotificationName RequestPublisherNotificationMessage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.NotificationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.NotificationName left, Azure.ResourceManager.ApiManagement.Models.NotificationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.NotificationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.NotificationName left, Azure.ResourceManager.ApiManagement.Models.NotificationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OAuth2AuthenticationSettingsContract
    {
        public OAuth2AuthenticationSettingsContract() { }
        public string AuthorizationServerId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class OpenIdAuthenticationSettingsContract
    {
        public OpenIdAuthenticationSettingsContract() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.BearerTokenSendingMethod> BearerTokenSendingMethods { get { throw null; } }
        public string OpenIdProviderId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationNameFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.OperationNameFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationNameFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.OperationNameFormat Name { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.OperationNameFormat Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat left, Azure.ResourceManager.ApiManagement.Models.OperationNameFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.OperationNameFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.OperationNameFormat left, Azure.ResourceManager.ApiManagement.Models.OperationNameFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationResultLogItemContract
    {
        internal OperationResultLogItemContract() { }
        public string Action { get { throw null; } }
        public string ObjectKey { get { throw null; } }
        public string ObjectType { get { throw null; } }
    }
    public partial class OutboundEnvironmentEndpoint
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ApiManagement.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class ParameterContract
    {
        public ParameterContract(string name, string parameterContractType) { }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ApiManagement.Models.ParameterExampleContract> Examples { get { throw null; } }
        public bool? IsRequired { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ParameterContractType { get { throw null; } set { } }
        public string SchemaId { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class ParameterExampleContract
    {
        public ParameterExampleContract() { }
        public string Description { get { throw null; } set { } }
        public string ExternalValue { get { throw null; } set { } }
        public string Summary { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class PipelineDiagnosticSettings
    {
        public PipelineDiagnosticSettings() { }
        public Azure.ResourceManager.ApiManagement.Models.HttpMessageDiagnostic Request { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.HttpMessageDiagnostic Response { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlatformVersion : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PlatformVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlatformVersion(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Mtv1 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Stv1 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Stv2 { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PlatformVersion Undetermined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PlatformVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PlatformVersion left, Azure.ResourceManager.ApiManagement.Models.PlatformVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PlatformVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PlatformVersion left, Azure.ResourceManager.ApiManagement.Models.PlatformVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyContentFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyContentFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat RawXml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat RawXmlLink { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat Xml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat XmlLink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyContentFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyDescriptionContractData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyDescriptionContractData() { }
        public string Description { get { throw null; } }
        public System.BinaryData Scope { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyExportFormat : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyExportFormat(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat RawXml { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat left, Azure.ResourceManager.ApiManagement.Models.PolicyExportFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PolicyName Policy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PolicyName left, Azure.ResourceManager.ApiManagement.Models.PolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PolicyName left, Azure.ResourceManager.ApiManagement.Models.PolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PolicyScopeContract
    {
        Tenant = 0,
        Product = 1,
        Api = 2,
        Operation = 3,
        All = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortalRevisionStatus : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortalRevisionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus Publishing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus left, Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus left, Azure.ResourceManager.ApiManagement.Models.PortalRevisionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortalSettingsContractData : Azure.ResourceManager.Models.ResourceData
    {
        public PortalSettingsContractData() { }
        public bool? IsRedirectEnabled { get { throw null; } set { } }
        public bool? IsSubscriptionDelegationEnabled { get { throw null; } set { } }
        public bool? IsUserRegistrationDelegationEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TermsOfServiceProperties TermsOfService { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string ValidationKey { get { throw null; } set { } }
    }
    public partial class PortalSettingValidationKeyContract
    {
        internal PortalSettingValidationKeyContract() { }
        public string ValidationKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredIPVersion : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredIPVersion(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion IPv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion left, Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion left, Azure.ResourceManager.ApiManagement.Models.PreferredIPVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProductApiData : Azure.ResourceManager.Models.ResourceData
    {
        public ProductApiData() { }
        public string ApiRevision { get { throw null; } set { } }
        public string ApiRevisionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiType? ApiType { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public string ApiVersionDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiVersionSetContractDetails ApiVersionSet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ApiVersionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.AuthenticationSettingsContract AuthenticationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiContactInformation Contact { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsCurrent { get { throw null; } set { } }
        public bool? IsOnline { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiLicenseInformation License { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ApiOperationInvokableProtocol> Protocols { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceApiId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SubscriptionKeyParameterNamesContract SubscriptionKeyParameterNames { get { throw null; } set { } }
        public System.Uri TermsOfServiceUri { get { throw null; } set { } }
    }
    public partial class ProductEntityBaseProperties
    {
        internal ProductEntityBaseProperties() { }
        public string Description { get { throw null; } }
        public bool? IsApprovalRequired { get { throw null; } }
        public bool? IsSubscriptionRequired { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementProductState? State { get { throw null; } }
        public int? SubscriptionsLimit { get { throw null; } }
        public string Terms { get { throw null; } }
    }
    public partial class ProductGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public ProductGroupData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupType? GroupType { get { throw null; } set { } }
        public bool? IsBuiltIn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess left, Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess left, Azure.ResourceManager.ApiManagement.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaCounterContract
    {
        internal QuotaCounterContract() { }
        public string CounterKey { get { throw null; } }
        public System.DateTimeOffset PeriodEndOn { get { throw null; } }
        public string PeriodKey { get { throw null; } }
        public System.DateTimeOffset PeriodStartOn { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.QuotaCounterValueContractProperties Value { get { throw null; } }
    }
    public partial class QuotaCounterValueContractProperties
    {
        internal QuotaCounterValueContractProperties() { }
        public int? CallsCount { get { throw null; } }
        public double? KbTransferred { get { throw null; } }
    }
    public partial class QuotaCounterValueUpdateContent
    {
        public QuotaCounterValueUpdateContent() { }
        public int? CallsCount { get { throw null; } set { } }
        public double? KbTransferred { get { throw null; } set { } }
    }
    public partial class RecipientEmailContract : Azure.ResourceManager.Models.ResourceData
    {
        public RecipientEmailContract() { }
        public string Email { get { throw null; } set { } }
    }
    public partial class RecipientsContractProperties
    {
        public RecipientsContractProperties() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> Users { get { throw null; } }
    }
    public partial class RecipientUserContract : Azure.ResourceManager.Models.ResourceData
    {
        public RecipientUserContract() { }
        public string UserId { get { throw null; } set { } }
    }
    public partial class RegionContract
    {
        internal RegionContract() { }
        public bool? IsDeleted { get { throw null; } }
        public bool? IsMasterRegion { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RemotePrivateEndpointConnectionWrapper
    {
        public RemotePrivateEndpointConnectionWrapper() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.ApiManagementPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class ReportRecordContract
    {
        internal ReportRecordContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRegion { get { throw null; } }
        public double? ApiTimeAvg { get { throw null; } }
        public double? ApiTimeMax { get { throw null; } }
        public double? ApiTimeMin { get { throw null; } }
        public long? Bandwidth { get { throw null; } }
        public int? CacheHitCount { get { throw null; } }
        public int? CacheMissCount { get { throw null; } }
        public int? CallCountBlocked { get { throw null; } }
        public int? CallCountFailed { get { throw null; } }
        public int? CallCountOther { get { throw null; } }
        public int? CallCountSuccess { get { throw null; } }
        public int? CallCountTotal { get { throw null; } }
        public string Country { get { throw null; } }
        public string Interval { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string Region { get { throw null; } }
        public double? ServiceTimeAvg { get { throw null; } }
        public double? ServiceTimeMax { get { throw null; } }
        public double? ServiceTimeMin { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubscriptionResourceId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
        public string Zip { get { throw null; } }
    }
    public partial class RepresentationContract
    {
        public RepresentationContract(string contentType) { }
        public string ContentType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ApiManagement.Models.ParameterExampleContract> Examples { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> FormParameters { get { throw null; } }
        public string SchemaId { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
    }
    public partial class RequestContract
    {
        public RequestContract() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> QueryParameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RepresentationContract> Representations { get { throw null; } }
    }
    public partial class RequestReportRecordContract
    {
        internal RequestReportRecordContract() { }
        public string ApiId { get { throw null; } }
        public string ApiRegion { get { throw null; } }
        public double? ApiTime { get { throw null; } }
        public string BackendResponseCode { get { throw null; } }
        public string Cache { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public Azure.Core.RequestMethod? Method { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ProductId { get { throw null; } }
        public string RequestId { get { throw null; } }
        public int? RequestSize { get { throw null; } }
        public int? ResponseCode { get { throw null; } }
        public int? ResponseSize { get { throw null; } }
        public double? ServiceTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubscriptionResourceId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class ResourceLocationDataContract
    {
        public ResourceLocationDataContract(string name) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string District { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ResponseContract
    {
        public ResponseContract(int statusCode) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.ParameterContract> Headers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ApiManagement.Models.RepresentationContract> Representations { get { throw null; } }
        public int StatusCode { get { throw null; } set { } }
    }
    public partial class SamplingSettings
    {
        public SamplingSettings() { }
        public double? Percentage { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.SamplingType? SamplingType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SamplingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SamplingType Fixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SamplingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SamplingType left, Azure.ResourceManager.ApiManagement.Models.SamplingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SamplingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SamplingType left, Azure.ResourceManager.ApiManagement.Models.SamplingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingsType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SettingsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingsType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SettingsType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SettingsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SettingsType left, Azure.ResourceManager.ApiManagement.Models.SettingsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SettingsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SettingsType left, Azure.ResourceManager.ApiManagement.Models.SettingsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoapApiType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.SoapApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoapApiType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType GraphQL { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType SoapPassThrough { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType SoapToRest { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.SoapApiType WebSocket { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.SoapApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.SoapApiType left, Azure.ResourceManager.ApiManagement.Models.SoapApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.SoapApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.SoapApiType left, Azure.ResourceManager.ApiManagement.Models.SoapApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountAccessType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountAccessType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType AccessKey { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType left, Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType left, Azure.ResourceManager.ApiManagement.Models.StorageAccountAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionKeyParameterNamesContract
    {
        public SubscriptionKeyParameterNamesContract() { }
        public string Header { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class SubscriptionKeysContract
    {
        internal SubscriptionKeysContract() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public enum SubscriptionState
    {
        Suspended = 0,
        Active = 1,
        Expired = 2,
        Submitted = 3,
        Rejected = 4,
        Cancelled = 5,
    }
    public partial class TagResourceContractDetails
    {
        internal TagResourceContractDetails() { }
        public Azure.ResourceManager.ApiManagement.Models.AssociatedApiProperties Api { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.AssociatedOperationProperties Operation { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.AssociatedProductProperties Product { get { throw null; } }
        public Azure.ResourceManager.ApiManagement.Models.AssociatedTagProperties Tag { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateName : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.TemplateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateName(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName AccountClosedDeveloper { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName ApplicationApprovedNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName ConfirmSignUpIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName EmailChangeIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName InviteUserNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewCommentNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName NewIssueNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PasswordResetByAdminNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PasswordResetIdentityDefault { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName PurchaseDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName QuotaLimitApproachingDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName RejectDeveloperNotificationMessage { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TemplateName RequestDeveloperNotificationMessage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.TemplateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.TemplateName left, Azure.ResourceManager.ApiManagement.Models.TemplateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.TemplateName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.TemplateName left, Azure.ResourceManager.ApiManagement.Models.TemplateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TenantAccessInfoCreateOrUpdateContent
    {
        public TenantAccessInfoCreateOrUpdateContent() { }
        public bool? IsDirectAccessEnabled { get { throw null; } set { } }
        public string PrimaryKey { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
    }
    public partial class TenantAccessInfoPatch
    {
        public TenantAccessInfoPatch() { }
        public bool? IsDirectAccessEnabled { get { throw null; } set { } }
    }
    public partial class TenantAccessInfoSecretsDetails
    {
        internal TenantAccessInfoSecretsDetails() { }
        public string AccessInfoType { get { throw null; } }
        public bool? IsDirectAccessEnabled { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class TenantConfigurationSyncStateContract : Azure.ResourceManager.Models.ResourceData
    {
        public TenantConfigurationSyncStateContract() { }
        public string Branch { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public System.DateTimeOffset? ConfigurationChangeOn { get { throw null; } set { } }
        public bool? IsExported { get { throw null; } set { } }
        public bool? IsGitEnabled { get { throw null; } set { } }
        public bool? IsSynced { get { throw null; } set { } }
        public string LastOperationId { get { throw null; } set { } }
        public System.DateTimeOffset? SyncOn { get { throw null; } set { } }
    }
    public partial class TermsOfServiceProperties
    {
        public TermsOfServiceProperties() { }
        public bool? IsConsentRequired { get { throw null; } set { } }
        public bool? IsDisplayEnabled { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class TokenBodyParameterContract
    {
        public TokenBodyParameterContract(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public enum TokenGenerationUsedKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TraceVerbosityLevel : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TraceVerbosityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel Error { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel Information { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel Verbose { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel left, Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel left, Azure.ResourceManager.ApiManagement.Models.TraceVerbosityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserIdentityContract
    {
        public UserIdentityContract() { }
        public string Id { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
    }
    public partial class UserTokenContent
    {
        public UserTokenContent() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.ApiManagement.Models.TokenGenerationUsedKeyType? KeyType { get { throw null; } set { } }
    }
    public partial class UserTokenResult
    {
        internal UserTokenResult() { }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VersioningScheme : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.VersioningScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VersioningScheme(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Header { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Query { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VersioningScheme Segment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.VersioningScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.VersioningScheme left, Azure.ResourceManager.ApiManagement.Models.VersioningScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.VersioningScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.VersioningScheme left, Azure.ResourceManager.ApiManagement.Models.VersioningScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkConfiguration
    {
        public VirtualNetworkConfiguration() { }
        public string Subnetname { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        public System.Guid? VnetId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkType : System.IEquatable<Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkType(string value) { throw null; }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType External { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType Internal { get { throw null; } }
        public static Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType left, Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType left, Azure.ResourceManager.ApiManagement.Models.VirtualNetworkType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X509CertificateName
    {
        public X509CertificateName() { }
        public string IssuerCertificateThumbprint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
}
