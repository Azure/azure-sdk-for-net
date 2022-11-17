namespace Azure.ResourceManager.SecurityInsights
{
    public partial class ActionResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.ActionResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.ActionResponseResource>, System.Collections.IEnumerable
    {
        protected ActionResponseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.ActionResponseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string actionId, Azure.ResourceManager.SecurityInsights.Models.ActionResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.ActionResponseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string actionId, Azure.ResourceManager.SecurityInsights.Models.ActionResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource> Get(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.ActionResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.ActionResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource>> GetAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.ActionResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.ActionResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.ActionResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.ActionResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ActionResponseData : Azure.ResourceManager.Models.ResourceData
    {
        public ActionResponseData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string LogicAppResourceId { get { throw null; } set { } }
        public string WorkflowId { get { throw null; } set { } }
    }
    public partial class ActionResponseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActionResponseResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.ActionResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleId, string actionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.ActionResponseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.ActionResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.ActionResponseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.ActionResponseCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>, System.Collections.IEnumerable
    {
        protected AlertRuleTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> Get(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>> GetAsync(string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertRuleTemplateData : Azure.ResourceManager.Models.ResourceData
    {
        public AlertRuleTemplateData() { }
    }
    public partial class AlertRuleTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertRuleTemplateResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string alertRuleTemplateId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>, System.Collections.IEnumerable
    {
        protected AutomationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string automationRuleId, Azure.ResourceManager.SecurityInsights.AutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string automationRuleId, Azure.ResourceManager.SecurityInsights.AutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> Get(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>> GetAsync(string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationRuleData(string displayName, int order, Azure.ResourceManager.SecurityInsights.Models.AutomationRuleTriggeringLogic triggeringLogic, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleAction> actions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleAction> Actions { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.ClientInfo CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ClientInfo LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public int Order { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRuleTriggeringLogic TriggeringLogic { get { throw null; } set { } }
    }
    public partial class AutomationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationRuleResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.AutomationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string automationRuleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.AutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.AutomationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BookmarkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkResource>, System.Collections.IEnumerable
    {
        protected BookmarkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bookmarkId, Azure.ResourceManager.SecurityInsights.BookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bookmarkId, Azure.ResourceManager.SecurityInsights.BookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource> Get(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.BookmarkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.BookmarkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource>> GetAsync(string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.BookmarkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.BookmarkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BookmarkData : Azure.ResourceManager.Models.ResourceData
    {
        public BookmarkData() { }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo CreatedBy { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentInfo IncidentInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.DateTimeOffset? QueryEndOn { get { throw null; } set { } }
        public string QueryResult { get { throw null; } set { } }
        public System.DateTimeOffset? QueryStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class BookmarkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BookmarkResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.BookmarkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string bookmarkId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.BookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.BookmarkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.DataConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.DataConnectorResource>, System.Collections.IEnumerable
    {
        protected DataConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectorId, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectorId, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource> Get(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.DataConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.DataConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> GetAsync(string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.DataConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.DataConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.DataConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.DataConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataConnectorData : Azure.ResourceManager.Models.ResourceData
    {
        public DataConnectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class DataConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.DataConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataConnectorId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IncidentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentResource>, System.Collections.IEnumerable
    {
        protected IncidentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string incidentId, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string incidentId, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource> Get(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.IncidentResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.IncidentResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource>> GetAsync(string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.IncidentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.IncidentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IncidentCommentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>, System.Collections.IEnumerable
    {
        protected IncidentCommentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string incidentCommentId, Azure.ResourceManager.SecurityInsights.IncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string incidentCommentId, Azure.ResourceManager.SecurityInsights.IncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> Get(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>> GetAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IncidentCommentData : Azure.ResourceManager.Models.ResourceData
    {
        public IncidentCommentData() { }
        public Azure.ResourceManager.SecurityInsights.Models.ClientInfo Author { get { throw null; } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public string Message { get { throw null; } set { } }
    }
    public partial class IncidentCommentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IncidentCommentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentCommentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId, string incidentCommentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentCommentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IncidentData : Azure.ResourceManager.Models.ResourceData
    {
        public IncidentData() { }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentAdditionalData AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentClassification? Classification { get { throw null; } set { } }
        public string ClassificationComment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason? ClassificationReason { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? FirstActivityTimeUtc { get { throw null; } set { } }
        public int? IncidentNumber { get { throw null; } }
        public System.Uri IncidentUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.IncidentLabel> Labels { get { throw null; } }
        public System.DateTimeOffset? LastActivityTimeUtc { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentOwnerInfo Owner { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RelatedAnalyticRuleIds { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentStatus? Status { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class IncidentRelationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>, System.Collections.IEnumerable
    {
        protected IncidentRelationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.IncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.IncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> Get(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> GetAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IncidentRelationData : Azure.ResourceManager.Models.ResourceData
    {
        public IncidentRelationData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string RelatedResourceId { get { throw null; } set { } }
        public string RelatedResourceKind { get { throw null; } }
        public string RelatedResourceName { get { throw null; } }
        public string RelatedResourceType { get { throw null; } }
    }
    public partial class IncidentRelationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IncidentRelationResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentRelationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId, string relationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentRelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IncidentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IncidentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.SecurityAlert> GetAlerts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.SecurityAlert> GetAlertsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.HuntingBookmark> GetBookmarks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.HuntingBookmark> GetBookmarksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.IncidentEntitiesResponse> GetEntities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.IncidentEntitiesResponse>> GetEntitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource> GetIncidentComment(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentCommentResource>> GetIncidentCommentAsync(string incidentCommentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentCommentCollection GetIncidentComments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> GetIncidentRelation(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> GetIncidentRelationAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentRelationCollection GetIncidentRelations() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityInsightsAlertRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>, System.Collections.IEnumerable
    {
        protected SecurityInsightsAlertRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Get(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetAsync(string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityInsightsAlertRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityInsightsAlertRuleData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityInsightsAlertRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityInsightsAlertRuleResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource> GetActionResponse(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.ActionResponseResource>> GetActionResponseAsync(string actionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.ActionResponseCollection GetActionResponses() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SecurityInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> CreateThreatIntelligenceIndicator(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> CreateThreatIntelligenceIndicatorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.ActionResponseResource GetActionResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource> GetAlertRuleTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource>> GetAlertRuleTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string alertRuleTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.AlertRuleTemplateResource GetAlertRuleTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.AlertRuleTemplateCollection GetAlertRuleTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource> GetAutomationRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.AutomationRuleResource>> GetAutomationRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string automationRuleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.AutomationRuleResource GetAutomationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.AutomationRuleCollection GetAutomationRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource> GetBookmark(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource>> GetBookmarkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string bookmarkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.BookmarkResource GetBookmarkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.BookmarkCollection GetBookmarks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource> GetDataConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> GetDataConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.DataConnectorResource GetDataConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.DataConnectorCollection GetDataConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource> GetIncident(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource>> GetIncidentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentCommentResource GetIncidentCommentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentRelationResource GetIncidentRelationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentResource GetIncidentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentCollection GetIncidents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetMetricsThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetMetricsThreatIntelligenceIndicatorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetSecurityInsightsAlertRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetSecurityInsightsAlertRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource GetSecurityInsightsAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> GetSentinelOnboardingState(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> GetSentinelOnboardingStateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource GetSentinelOnboardingStateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateCollection GetSentinelOnboardingStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetThreatIntelligenceIndicator(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> GetThreatIntelligenceIndicatorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorResource GetThreatIntelligenceIndicatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorCollection GetThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource> GetWatchlist(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource>> GetWatchlistAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistItemResource GetWatchlistItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistResource GetWatchlistResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistCollection GetWatchlists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> QueryThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> QueryThreatIntelligenceIndicatorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SentinelOnboardingStateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>, System.Collections.IEnumerable
    {
        protected SentinelOnboardingStateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sentinelOnboardingStateName, Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sentinelOnboardingStateName, Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> Get(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> GetAsync(string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SentinelOnboardingStateData : Azure.ResourceManager.Models.ResourceData
    {
        public SentinelOnboardingStateData() { }
        public bool? CustomerManagedKey { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SentinelOnboardingStateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SentinelOnboardingStateResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sentinelOnboardingStateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThreatIntelligenceIndicatorCollection : Azure.ResourceManager.ArmCollection
    {
        protected ThreatIntelligenceIndicatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, string name, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, string name, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> Get(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetAll(string workspaceName, string filter = null, int? top = default(int?), string skipToken = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetAllAsync(string workspaceName, string filter = null, int? top = default(int?), string skipToken = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> GetAsync(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThreatIntelligenceIndicatorData : Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation
    {
        public ThreatIntelligenceIndicatorData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? Confidence { get { throw null; } set { } }
        public string Created { get { throw null; } set { } }
        public string CreatedByRef { get { throw null; } set { } }
        public bool? Defanged { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public string ExternalId { get { throw null; } set { } }
        public string ExternalLastUpdatedTimeUtc { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceExternalReference> ExternalReferences { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceGranularMarkingModel> GranularMarkings { get { throw null; } }
        public System.Collections.Generic.IList<string> IndicatorTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceKillChainPhase> KillChainPhases { get { throw null; } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string LastUpdatedTimeUtc { get { throw null; } set { } }
        public string Modified { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectMarkingRefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPattern> ParsedPattern { get { throw null; } }
        public string Pattern { get { throw null; } set { } }
        public string PatternType { get { throw null; } set { } }
        public string PatternVersion { get { throw null; } set { } }
        public bool? Revoked { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ThreatIntelligenceTags { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatTypes { get { throw null; } }
        public string ValidFrom { get { throw null; } set { } }
        public string ValidUntil { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceIndicatorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ThreatIntelligenceIndicatorResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AppendTags(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags threatIntelligenceAppendTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AppendTagsAsync(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceAppendTags threatIntelligenceAppendTags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> ReplaceTags(Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> ReplaceTagsAsync(Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WatchlistCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistResource>, System.Collections.IEnumerable
    {
        protected WatchlistCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watchlistAlias, Azure.ResourceManager.SecurityInsights.WatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watchlistAlias, Azure.ResourceManager.SecurityInsights.WatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource> Get(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.WatchlistResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.WatchlistResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource>> GetAsync(string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.WatchlistResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.WatchlistResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WatchlistData : Azure.ResourceManager.Models.ResourceData
    {
        public WatchlistData() { }
        public string ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo CreatedBy { get { throw null; } set { } }
        public System.TimeSpan? DefaultDuration { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } set { } }
        public string ItemsSearchKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public int? NumberOfLinesToSkip { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string RawContent { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Source? Source { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public string UploadStatus { get { throw null; } set { } }
        public string WatchlistAlias { get { throw null; } set { } }
        public string WatchlistId { get { throw null; } set { } }
        public string WatchlistType { get { throw null; } set { } }
    }
    public partial class WatchlistItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>, System.Collections.IEnumerable
    {
        protected WatchlistItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watchlistItemId, Azure.ResourceManager.SecurityInsights.WatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watchlistItemId, Azure.ResourceManager.SecurityInsights.WatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> Get(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>> GetAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WatchlistItemData : Azure.ResourceManager.Models.ResourceData
    {
        public WatchlistItemData() { }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo CreatedBy { get { throw null; } set { } }
        public System.BinaryData EntityMapping { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } set { } }
        public System.BinaryData ItemsKeyValue { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public string WatchlistItemId { get { throw null; } set { } }
        public string WatchlistItemType { get { throw null; } set { } }
    }
    public partial class WatchlistItemResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WatchlistItemResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.WatchlistItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string watchlistAlias, string watchlistItemId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.WatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.WatchlistItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WatchlistResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WatchlistResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.WatchlistData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string watchlistAlias) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource> GetWatchlistItem(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistItemResource>> GetWatchlistItemAsync(string watchlistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.WatchlistItemCollection GetWatchlistItems() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.WatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.WatchlistResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.WatchlistData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityInsights.Models
{
    public partial class AADDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AADDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AatpDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AccountEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public AccountEntity() { }
        public string AadTenantId { get { throw null; } }
        public string AadUserId { get { throw null; } }
        public string AccountName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DnsDomain { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public bool? IsDomainJoined { get { throw null; } }
        public string NtDomain { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Puid { get { throw null; } }
        public string Sid { get { throw null; } }
        public string UpnSuffix { get { throw null; } }
    }
    public partial class ActionResponseCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public ActionResponseCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string LogicAppResourceId { get { throw null; } set { } }
        public System.Uri TriggerUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertDetail : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AlertDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertDetail(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertDetail DisplayName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertDetail Severity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AlertDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AlertDetail left, Azure.ResourceManager.SecurityInsights.Models.AlertDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AlertDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AlertDetail left, Azure.ResourceManager.SecurityInsights.Models.AlertDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertDetailsOverride
    {
        public AlertDetailsOverride() { }
        public string AlertDescriptionFormat { get { throw null; } set { } }
        public string AlertDisplayNameFormat { get { throw null; } set { } }
        public string AlertSeverityColumnName { get { throw null; } set { } }
        public string AlertTacticsColumnName { get { throw null; } set { } }
    }
    public partial class AlertRuleTemplateDataSource
    {
        public AlertRuleTemplateDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
    }
    public partial class AlertsDataTypeOfDataConnector
    {
        public AlertsDataTypeOfDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AlertSeverity left, Azure.ResourceManager.SecurityInsights.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AlertSeverity left, Azure.ResourceManager.SecurityInsights.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AlertStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertStatus Dismissed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertStatus New { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertStatus Resolved { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AlertStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AlertStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AlertStatus left, Azure.ResourceManager.SecurityInsights.Models.AlertStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AlertStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AlertStatus left, Azure.ResourceManager.SecurityInsights.Models.AlertStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AntispamMailDirection : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AntispamMailDirection(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Intraorg { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Outbound { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection left, Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection left, Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ASCDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public ASCDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttackTactic : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AttackTactic>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttackTactic(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic ImpairProcessControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic InhibitResponseFunction { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic InitialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic PreAttack { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic Reconnaissance { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AttackTactic ResourceDevelopment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AttackTactic other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AttackTactic left, Azure.ResourceManager.SecurityInsights.Models.AttackTactic right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AttackTactic (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AttackTactic left, Azure.ResourceManager.SecurityInsights.Models.AttackTactic right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AutomationRuleAction
    {
        protected AutomationRuleAction(int order) { }
        public int Order { get { throw null; } set { } }
    }
    public abstract partial class AutomationRuleCondition
    {
        protected AutomationRuleCondition() { }
    }
    public partial class AutomationRuleModifyPropertiesAction : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleAction
    {
        public AutomationRuleModifyPropertiesAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentPropertiesAction ActionConfiguration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyConditionSupportedOperator : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyConditionSupportedOperator(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotContains { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotEndsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotEquals { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator NotStartsWith { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyConditionSupportedProperty : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyConditionSupportedProperty(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountAadTenantId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountAadUserId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountNTDomain { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountObjectGuid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountPuid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountSid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AccountUPNSuffix { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AlertProductNames { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AzureResourceResourceId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AzureResourceSubscriptionId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty CloudApplicationAppId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty CloudApplicationAppName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty DnsDomainName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileDirectory { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileHashValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty FileName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostAzureId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostNetBiosName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostNTDomain { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty HostOSVersion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentDescription { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentLabel { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentProviderName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentRelatedAnalyticRuleIds { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentSeverity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentStatus { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentTactics { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IncidentTitle { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceModel { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceOperatingSystem { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceType { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IoTDeviceVendor { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty IPAddress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxDisplayName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxPrimaryAddress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailboxUPN { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageDeliveryAction { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageDeliveryLocation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageP1Sender { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageP2Sender { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageRecipient { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageSenderIP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MailMessageSubject { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MalwareCategory { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty MalwareName { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty ProcessCommandLine { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty ProcessId { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty RegistryValueData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty Url { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRulePropertyValuesCondition
    {
        public AutomationRulePropertyValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
    }
    public partial class AutomationRuleRunPlaybookAction : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleAction
    {
        public AutomationRuleRunPlaybookAction(int order) : base (default(int)) { }
        public Azure.ResourceManager.SecurityInsights.Models.PlaybookActionProperties ActionConfiguration { get { throw null; } set { } }
    }
    public partial class AutomationRuleTriggeringLogic
    {
        public AutomationRuleTriggeringLogic(bool isEnabled, Azure.ResourceManager.SecurityInsights.Models.TriggersOn triggersOn, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen triggersWhen) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AutomationRuleCondition> Conditions { get { throw null; } }
        public System.DateTimeOffset? ExpirationTimeUtc { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersOn TriggersOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggersWhen TriggersWhen { get { throw null; } set { } }
    }
    public partial class AwsCloudTrailDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AwsCloudTrailDataConnector() { }
        public string AwsRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? LogsState { get { throw null; } set { } }
    }
    public partial class AzureResourceEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public AzureResourceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class ClientInfo
    {
        internal ClientInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
    }
    public partial class CloudApplicationEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public CloudApplicationEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? AppId { get { throw null; } }
        public string AppName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InstanceName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidenceLevel : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidenceLevel(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel left, Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel left, Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidenceScoreStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidenceScoreStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus Final { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus InProcess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus NotFinal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus left, Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus left, Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataTypeState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DataTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataTypeState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DataTypeState Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DataTypeState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DataTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DataTypeState left, Azure.ResourceManager.SecurityInsights.Models.DataTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DataTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DataTypeState left, Azure.ResourceManager.SecurityInsights.Models.DataTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DeliveryAction
    {
        Unknown = 0,
        DeliveredAsSpam = 1,
        Delivered = 2,
        Blocked = 3,
        Replaced = 4,
    }
    public enum DeliveryLocation
    {
        Unknown = 0,
        Inbox = 1,
        JunkFolder = 2,
        DeletedFolder = 3,
        Quarantine = 4,
        External = 5,
        Failed = 6,
        Dropped = 7,
        Forwarded = 8,
    }
    public partial class DnsEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public DnsEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DnsServerIPEntityId { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostIPAddressEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddressEntityIds { get { throw null; } }
    }
    public enum ElevationToken
    {
        Default = 0,
        Full = 1,
        Limited = 2,
    }
    public partial class EntityData : Azure.ResourceManager.Models.ResourceData
    {
        public EntityData() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Account { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind AzureResource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Bookmark { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind CloudApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind DnsResolution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind File { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind FileHash { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Host { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind IoTDevice { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind IP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Mailbox { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind MailCluster { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind MailMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Malware { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Process { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind RegistryValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind SecurityAlert { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind SecurityGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind SubmissionMail { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Url { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityKind left, Azure.ResourceManager.SecurityInsights.Models.EntityKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityKind left, Azure.ResourceManager.SecurityInsights.Models.EntityKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityMapping
    {
        public EntityMapping() { }
        public Azure.ResourceManager.SecurityInsights.Models.EntityMappingType? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FieldMapping> FieldMappings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityMappingType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityMappingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityMappingType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Account { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType AzureResource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType CloudApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Dns { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType File { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType FileHash { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Host { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType IP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Mailbox { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType MailCluster { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType MailMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Malware { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType Process { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType RegistryValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType SecurityGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType SubmissionMail { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityMappingType URL { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityMappingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityMappingType left, Azure.ResourceManager.SecurityInsights.Models.EntityMappingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityMappingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityMappingType left, Azure.ResourceManager.SecurityInsights.Models.EntityMappingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGroupingAggregationKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGroupingAggregationKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind AlertPerResult { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind SingleAlert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind left, Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind left, Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FieldMapping
    {
        public FieldMapping() { }
        public string ColumnName { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
    }
    public partial class FileEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public FileEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Directory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileHashEntityIds { get { throw null; } }
        public string FileName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileHashAlgorithm : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileHashAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm MD5 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm SHA1 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm SHA256 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm SHA256AC { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm left, Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm left, Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileHashEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public FileHashEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm? Algorithm { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HashValue { get { throw null; } }
    }
    public partial class FusionAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public FusionAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
    }
    public partial class FusionAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public FusionAlertRuleTemplate() { }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateUTC { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedDateUTC { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
    }
    public partial class GeoLocation
    {
        internal GeoLocation() { }
        public int? Asn { get { throw null; } }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string CountryName { get { throw null; } }
        public double? Latitude { get { throw null; } }
        public double? Longitude { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class GroupingConfiguration
    {
        public GroupingConfiguration(bool enabled, bool reopenClosedIncident, System.TimeSpan lookbackDuration, Azure.ResourceManager.SecurityInsights.Models.MatchingMethod matchingMethod) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertDetail> GroupByAlertDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupByCustomDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityMappingType> GroupByEntities { get { throw null; } }
        public System.TimeSpan LookbackDuration { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MatchingMethod MatchingMethod { get { throw null; } set { } }
        public bool ReopenClosedIncident { get { throw null; } set { } }
    }
    public partial class HostEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public HostEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string AzureId { get { throw null; } }
        public string DnsDomain { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostName { get { throw null; } }
        public bool? IsDomainJoined { get { throw null; } }
        public string NetBiosName { get { throw null; } }
        public string NtDomain { get { throw null; } }
        public string OmsAgentId { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.OSFamily? OSFamily { get { throw null; } set { } }
        public string OSVersion { get { throw null; } }
    }
    public partial class HuntingBookmark : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public HuntingBookmark() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo CreatedBy { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentInfo IncidentInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string QueryResult { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class IncidentAdditionalData
    {
        internal IncidentAdditionalData() { }
        public System.Collections.Generic.IReadOnlyList<string> AlertProductNames { get { throw null; } }
        public int? AlertsCount { get { throw null; } }
        public int? BookmarksCount { get { throw null; } }
        public int? CommentsCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentClassification : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IncidentClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentClassification(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassification BenignPositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassification FalsePositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassification TruePositive { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassification Undetermined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IncidentClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IncidentClassification left, Azure.ResourceManager.SecurityInsights.Models.IncidentClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IncidentClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IncidentClassification left, Azure.ResourceManager.SecurityInsights.Models.IncidentClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentClassificationReason : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentClassificationReason(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason InaccurateData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason IncorrectAlertLogic { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason SuspiciousActivity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason SuspiciousButExpected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason left, Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason left, Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncidentConfiguration
    {
        public IncidentConfiguration(bool createIncident) { }
        public bool CreateIncident { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.GroupingConfiguration GroupingConfiguration { get { throw null; } set { } }
    }
    public partial class IncidentEntitiesResponse
    {
        internal IncidentEntitiesResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.EntityData> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.IncidentEntitiesResultsMetadata> MetaData { get { throw null; } }
    }
    public partial class IncidentEntitiesResultsMetadata
    {
        internal IncidentEntitiesResultsMetadata() { }
        public int Count { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityKind EntityKind { get { throw null; } }
    }
    public partial class IncidentInfo
    {
        public IncidentInfo() { }
        public string IncidentId { get { throw null; } set { } }
        public string RelationName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity? Severity { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class IncidentLabel
    {
        public IncidentLabel(string labelName) { }
        public string LabelName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType? LabelType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentLabelType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentLabelType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType AutoAssigned { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType left, Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType left, Azure.ResourceManager.SecurityInsights.Models.IncidentLabelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncidentOwnerInfo
    {
        public IncidentOwnerInfo() { }
        public string AssignedTo { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.OwnerType? OwnerType { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
    }
    public partial class IncidentPropertiesAction
    {
        public IncidentPropertiesAction() { }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentClassification? Classification { get { throw null; } set { } }
        public string ClassificationComment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentClassificationReason? ClassificationReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.IncidentLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentOwnerInfo Owner { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentSeverity : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentSeverity(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity Informational { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity left, Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity left, Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IncidentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentStatus Active { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentStatus Closed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IncidentStatus New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IncidentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IncidentStatus left, Azure.ResourceManager.SecurityInsights.Models.IncidentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IncidentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IncidentStatus left, Azure.ResourceManager.SecurityInsights.Models.IncidentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IoTDeviceEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public IoTDeviceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string DeviceName { get { throw null; } }
        public string DeviceType { get { throw null; } }
        public string EdgeId { get { throw null; } }
        public string FirmwareVersion { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public string IotHubEntityId { get { throw null; } }
        public System.Guid? IotSecurityAgentId { get { throw null; } }
        public string IPAddressEntityId { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Model { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Protocols { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligence> ThreatIntelligence { get { throw null; } }
        public string Vendor { get { throw null; } }
    }
    public partial class IPEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public IPEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Address { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.GeoLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligence> ThreatIntelligence { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KillChainIntent : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.KillChainIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KillChainIntent(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Collection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent CommandAndControl { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent CredentialAccess { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent DefenseEvasion { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Discovery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Execution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Exfiltration { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Exploitation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Impact { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent LateralMovement { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Persistence { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent PrivilegeEscalation { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Probing { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.KillChainIntent Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.KillChainIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.KillChainIntent left, Azure.ResourceManager.SecurityInsights.Models.KillChainIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.KillChainIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.KillChainIntent left, Azure.ResourceManager.SecurityInsights.Models.KillChainIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MailboxEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public MailboxEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? ExternalDirectoryObjectId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MailboxPrimaryAddress { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class MailClusterEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public MailClusterEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string ClusterGroup { get { throw null; } }
        public System.DateTimeOffset? ClusterQueryEndOn { get { throw null; } }
        public System.DateTimeOffset? ClusterQueryStartOn { get { throw null; } }
        public string ClusterSourceIdentifier { get { throw null; } }
        public string ClusterSourceType { get { throw null; } }
        public System.BinaryData CountByDeliveryStatus { get { throw null; } }
        public System.BinaryData CountByProtectionStatus { get { throw null; } }
        public System.BinaryData CountByThreatType { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public bool? IsVolumeAnomaly { get { throw null; } }
        public int? MailCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NetworkMessageIds { get { throw null; } }
        public string Query { get { throw null; } }
        public System.DateTimeOffset? QueryOn { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Threats { get { throw null; } }
    }
    public partial class MailMessageEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public MailMessageEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AntispamMailDirection? AntispamDirection { get { throw null; } set { } }
        public int? BodyFingerprintBin1 { get { throw null; } set { } }
        public int? BodyFingerprintBin2 { get { throw null; } set { } }
        public int? BodyFingerprintBin3 { get { throw null; } set { } }
        public int? BodyFingerprintBin4 { get { throw null; } set { } }
        public int? BodyFingerprintBin5 { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeliveryAction? DeliveryAction { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeliveryLocation? DeliveryLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InternetMessageId { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Guid? NetworkMessageId { get { throw null; } }
        public string P1Sender { get { throw null; } }
        public string P1SenderDisplayName { get { throw null; } }
        public string P1SenderDomain { get { throw null; } }
        public string P2Sender { get { throw null; } }
        public string P2SenderDisplayName { get { throw null; } }
        public string P2SenderDomain { get { throw null; } }
        public System.DateTimeOffset? ReceiveOn { get { throw null; } }
        public string Recipient { get { throw null; } }
        public string SenderIP { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ThreatDetectionMethods { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Threats { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Urls { get { throw null; } }
    }
    public partial class MalwareEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public MalwareEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MalwareName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProcessEntityIds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchingMethod : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.MatchingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchingMethod(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MatchingMethod AllEntities { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MatchingMethod AnyAlert { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MatchingMethod Selected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.MatchingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.MatchingMethod left, Azure.ResourceManager.SecurityInsights.Models.MatchingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.MatchingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.MatchingMethod left, Azure.ResourceManager.SecurityInsights.Models.MatchingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McasDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public McasDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.McasDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class McasDataConnectorDataTypes : Azure.ResourceManager.SecurityInsights.Models.AlertsDataTypeOfDataConnector
    {
        public McasDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? DiscoveryLogsState { get { throw null; } set { } }
    }
    public partial class MdatpDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public MdatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public MicrosoftSecurityIncidentCreationAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisplayNamesExcludeFilter { get { throw null; } }
        public System.Collections.Generic.IList<string> DisplayNamesFilter { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? ProductFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertSeverity> SeveritiesFilter { get { throw null; } }
    }
    public partial class MicrosoftSecurityIncidentCreationAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public MicrosoftSecurityIncidentCreationAlertRuleTemplate() { }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateUTC { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisplayNamesExcludeFilter { get { throw null; } }
        public System.Collections.Generic.IList<string> DisplayNamesFilter { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateUTC { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName? ProductFilter { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertSeverity> SeveritiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.TemplateStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MicrosoftSecurityProductName : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MicrosoftSecurityProductName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureActiveDirectoryIdentityProtection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureAdvancedThreatProtection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureSecurityCenter { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName AzureSecurityCenterForIoT { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName MicrosoftCloudAppSecurity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName left, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName left, Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfficeDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public OfficeDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.OfficeDataConnectorDataTypes DataTypes { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeDataConnectorDataTypes
    {
        public OfficeDataConnectorDataTypes() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? ExchangeState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? SharePointState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? TeamsState { get { throw null; } set { } }
    }
    public enum OSFamily
    {
        Unknown = 0,
        Linux = 1,
        Windows = 2,
        Android = 3,
        IOS = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OwnerType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.OwnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OwnerType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.OwnerType Group { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.OwnerType Unknown { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.OwnerType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.OwnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.OwnerType left, Azure.ResourceManager.SecurityInsights.Models.OwnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.OwnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.OwnerType left, Azure.ResourceManager.SecurityInsights.Models.OwnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaybookActionProperties
    {
        public PlaybookActionProperties(string logicAppResourceId) { }
        public string LogicAppResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ProcessEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public ProcessEntity() { }
        public string AccountEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string CommandLine { get { throw null; } }
        public System.DateTimeOffset? CreationTimeUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.ElevationToken? ElevationToken { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public string HostLogonSessionEntityId { get { throw null; } }
        public string ImageFileEntityId { get { throw null; } }
        public string ParentProcessEntityId { get { throw null; } }
        public string ProcessId { get { throw null; } }
    }
    public partial class PropertyConditionProperties : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleCondition
    {
        public PropertyConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition ConditionProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistryHive : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.RegistryHive>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistryHive(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyA { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyClassesRoot { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyCurrentConfig { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyCurrentUser { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyCurrentUserLocalSettings { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyLocalMachine { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyPerformanceData { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyPerformanceNlstext { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyPerformanceText { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryHive HkeyUsers { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.RegistryHive other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.RegistryHive left, Azure.ResourceManager.SecurityInsights.Models.RegistryHive right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.RegistryHive (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.RegistryHive left, Azure.ResourceManager.SecurityInsights.Models.RegistryHive right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryKeyEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public RegistryKeyEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.RegistryHive? Hive { get { throw null; } }
        public string Key { get { throw null; } }
    }
    public partial class RegistryValueEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public RegistryValueEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string KeyEntityId { get { throw null; } }
        public string ValueData { get { throw null; } }
        public string ValueName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind? ValueType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistryValueKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistryValueKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind Binary { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind DWord { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind ExpandString { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind MultiString { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind None { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind QWord { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind String { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind left, Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind left, Azure.ResourceManager.SecurityInsights.Models.RegistryValueKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public ScheduledAlertRule() { }
        public Azure.ResourceManager.SecurityInsights.Models.AlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityMapping> EntityMappings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? EventGroupingAggregationKind { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentConfiguration IncidentConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.TimeSpan? QueryFrequency { get { throw null; } set { } }
        public System.TimeSpan? QueryPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public System.TimeSpan? SuppressionDuration { get { throw null; } set { } }
        public bool? SuppressionEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public string TemplateVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggerOperator? TriggerOperator { get { throw null; } set { } }
        public int? TriggerThreshold { get { throw null; } set { } }
    }
    public partial class ScheduledAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public ScheduledAlertRuleTemplate() { }
        public Azure.ResourceManager.SecurityInsights.Models.AlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateUTC { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityMapping> EntityMappings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EventGroupingAggregationKind? EventGroupingAggregationKind { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedDateUTC { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.TimeSpan? QueryFrequency { get { throw null; } set { } }
        public System.TimeSpan? QueryPeriod { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.TriggerOperator? TriggerOperator { get { throw null; } set { } }
        public int? TriggerThreshold { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class SecurityAlert : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public SecurityAlert() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string AlertDisplayName { get { throw null; } }
        public string AlertLink { get { throw null; } }
        public string AlertType { get { throw null; } }
        public string CompromisedEntity { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.ConfidenceLevel? ConfidenceLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.SecurityAlertPropertiesConfidenceReasonsItem> ConfidenceReasons { get { throw null; } }
        public double? ConfidenceScore { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.ConfidenceScoreStatus? ConfidenceScoreStatus { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.KillChainIntent? Intent { get { throw null; } }
        public System.DateTimeOffset? ProcessingEndOn { get { throw null; } }
        public string ProductComponentName { get { throw null; } }
        public string ProductName { get { throw null; } }
        public string ProductVersion { get { throw null; } }
        public string ProviderAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RemediationSteps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> ResourceIdentifiers { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertStatus? Status { get { throw null; } }
        public string SystemAlertId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.DateTimeOffset? TimeGenerated { get { throw null; } }
        public string VendorName { get { throw null; } }
    }
    public partial class SecurityAlertPropertiesConfidenceReasonsItem
    {
        internal SecurityAlertPropertiesConfidenceReasonsItem() { }
        public string Reason { get { throw null; } }
        public string ReasonType { get { throw null; } }
    }
    public partial class SecurityGroupEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public SecurityGroupEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DistinguishedName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Sid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Source : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Source>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Source(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Source LocalFile { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.Source RemoteStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Source other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Source left, Azure.ResourceManager.SecurityInsights.Models.Source right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Source (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Source left, Azure.ResourceManager.SecurityInsights.Models.Source right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubmissionMailEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public SubmissionMailEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Guid? NetworkMessageId { get { throw null; } }
        public string Recipient { get { throw null; } }
        public string ReportType { get { throw null; } }
        public string Sender { get { throw null; } }
        public string SenderIP { get { throw null; } }
        public string Subject { get { throw null; } }
        public System.Guid? SubmissionId { get { throw null; } }
        public System.DateTimeOffset? SubmissionOn { get { throw null; } }
        public string Submitter { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.TemplateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.TemplateStatus Available { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.TemplateStatus Installed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.TemplateStatus NotAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.TemplateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.TemplateStatus left, Azure.ResourceManager.SecurityInsights.Models.TemplateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.TemplateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.TemplateStatus left, Azure.ResourceManager.SecurityInsights.Models.TemplateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreatIntelligence
    {
        internal ThreatIntelligence() { }
        public double? Confidence { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ReportLink { get { throw null; } }
        public string ThreatDescription { get { throw null; } }
        public string ThreatName { get { throw null; } }
        public string ThreatType { get { throw null; } }
    }
    public partial class ThreatIntelligenceAppendTags
    {
        public ThreatIntelligenceAppendTags() { }
        public System.Collections.Generic.IList<string> ThreatIntelligenceTags { get { throw null; } }
    }
    public partial class ThreatIntelligenceExternalReference
    {
        public ThreatIntelligenceExternalReference() { }
        public string Description { get { throw null; } set { } }
        public string ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public string SourceName { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceFilteringCriteria
    {
        public ThreatIntelligenceFilteringCriteria() { }
        public System.Collections.Generic.IList<string> Ids { get { throw null; } }
        public bool? IncludeDisabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public int? MaxConfidence { get { throw null; } set { } }
        public string MaxValidUntil { get { throw null; } set { } }
        public int? MinConfidence { get { throw null; } set { } }
        public string MinValidUntil { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternTypes { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteria> SortBy { get { throw null; } }
        public System.Collections.Generic.IList<string> Sources { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatTypes { get { throw null; } }
    }
    public partial class ThreatIntelligenceGranularMarkingModel
    {
        public ThreatIntelligenceGranularMarkingModel() { }
        public string Language { get { throw null; } set { } }
        public int? MarkingRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Selectors { get { throw null; } }
    }
    public partial class ThreatIntelligenceInformation : Azure.ResourceManager.Models.ResourceData
    {
        public ThreatIntelligenceInformation() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceKillChainPhase
    {
        public ThreatIntelligenceKillChainPhase() { }
        public string KillChainName { get { throw null; } set { } }
        public string PhaseName { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceMetric
    {
        internal ThreatIntelligenceMetric() { }
        public string LastUpdatedTimeUtc { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> PatternTypeMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> SourceMetrics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetricEntity> ThreatTypeMetrics { get { throw null; } }
    }
    public partial class ThreatIntelligenceMetricEntity
    {
        internal ThreatIntelligenceMetricEntity() { }
        public string MetricName { get { throw null; } }
        public int? MetricValue { get { throw null; } }
    }
    public partial class ThreatIntelligenceMetrics
    {
        internal ThreatIntelligenceMetrics() { }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetric Properties { get { throw null; } }
    }
    public partial class ThreatIntelligenceParsedPattern
    {
        public ThreatIntelligenceParsedPattern() { }
        public string PatternTypeKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceParsedPatternTypeValue> PatternTypeValues { get { throw null; } }
    }
    public partial class ThreatIntelligenceParsedPatternTypeValue
    {
        public ThreatIntelligenceParsedPatternTypeValue() { }
        public string Value { get { throw null; } set { } }
        public string ValueType { get { throw null; } set { } }
    }
    public partial class ThreatIntelligenceSortingCriteria
    {
        public ThreatIntelligenceSortingCriteria() { }
        public string ItemKey { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder? SortOrder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreatIntelligenceSortingOrder : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreatIntelligenceSortingOrder(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Ascending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Descending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder Unsorted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TIDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public TIDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? IndicatorsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.DateTimeOffset? TipLookbackPeriod { get { throw null; } set { } }
    }
    public enum TriggerOperator
    {
        GreaterThan = 0,
        LessThan = 1,
        Equal = 2,
        NotEqual = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggersOn : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.TriggersOn>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggersOn(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersOn Incidents { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.TriggersOn other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.TriggersOn left, Azure.ResourceManager.SecurityInsights.Models.TriggersOn right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.TriggersOn (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.TriggersOn left, Azure.ResourceManager.SecurityInsights.Models.TriggersOn right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggersWhen : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.TriggersWhen>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggersWhen(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersWhen Created { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen left, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.TriggersWhen (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.TriggersWhen left, Azure.ResourceManager.SecurityInsights.Models.TriggersWhen right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UrlEntity : Azure.ResourceManager.SecurityInsights.Models.EntityData
    {
        public UrlEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class UserInfo
    {
        public UserInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
    }
}
