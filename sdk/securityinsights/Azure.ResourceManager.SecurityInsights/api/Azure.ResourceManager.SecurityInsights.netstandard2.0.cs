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
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.BookmarkEntityMappings> EntityMappings { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentInfo IncidentInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.DateTimeOffset? QueryEndOn { get { throw null; } set { } }
        public string QueryResult { get { throw null; } set { } }
        public System.DateTimeOffset? QueryStartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo UpdatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class BookmarkRelationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>, System.Collections.IEnumerable
    {
        protected BookmarkRelationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> Get(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>> GetAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BookmarkRelationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BookmarkRelationResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.RelationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string bookmarkId, string relationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.BookmarkExpandResponse> Expand(Azure.ResourceManager.SecurityInsights.Models.BookmarkExpandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.BookmarkExpandResponse>> ExpandAsync(Azure.ResourceManager.SecurityInsights.Models.BookmarkExpandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource> GetBookmarkRelation(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.BookmarkRelationResource>> GetBookmarkRelationAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.BookmarkRelationCollection GetBookmarkRelations() { throw null; }
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
        public virtual Azure.Response Connect(Azure.ResourceManager.SecurityInsights.Models.DataConnectorConnectBody connectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ConnectAsync(Azure.ResourceManager.SecurityInsights.Models.DataConnectorConnectBody connectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dataConnectorId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disconnect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisconnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.DataConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityResource>, System.Collections.IEnumerable
    {
        protected EntityCollection() { }
        public virtual Azure.Response<bool> Exists(string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource> Get(string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.EntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.EntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource>> GetAsync(string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.EntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.EntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EntityData : Azure.ResourceManager.Models.ResourceData
    {
        public EntityData() { }
    }
    public partial class EntityQueryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryResource>, System.Collections.IEnumerable
    {
        protected EntityQueryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.EntityQueryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string entityQueryId, Azure.ResourceManager.SecurityInsights.Models.EntityQueryCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.EntityQueryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string entityQueryId, Azure.ResourceManager.SecurityInsights.Models.EntityQueryCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource> Get(string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.EntityQueryResource> GetAll(Azure.ResourceManager.SecurityInsights.Models.Enum13? kind = default(Azure.ResourceManager.SecurityInsights.Models.Enum13?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.EntityQueryResource> GetAllAsync(Azure.ResourceManager.SecurityInsights.Models.Enum13? kind = default(Azure.ResourceManager.SecurityInsights.Models.Enum13?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource>> GetAsync(string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.EntityQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.EntityQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EntityQueryData : Azure.ResourceManager.Models.ResourceData
    {
        public EntityQueryData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class EntityQueryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EntityQueryResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.EntityQueryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string entityQueryId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.EntityQueryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.EntityQueryCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.EntityQueryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.Models.EntityQueryCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityQueryTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>, System.Collections.IEnumerable
    {
        protected EntityQueryTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> Get(string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> GetAll(Azure.ResourceManager.SecurityInsights.Models.Enum15? kind = default(Azure.ResourceManager.SecurityInsights.Models.Enum15?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> GetAllAsync(Azure.ResourceManager.SecurityInsights.Models.Enum15? kind = default(Azure.ResourceManager.SecurityInsights.Models.Enum15?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>> GetAsync(string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EntityQueryTemplateData : Azure.ResourceManager.Models.ResourceData
    {
        public EntityQueryTemplateData() { }
    }
    public partial class EntityQueryTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EntityQueryTemplateResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.EntityQueryTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string entityQueryTemplateId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityRelationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityRelationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityRelationResource>, System.Collections.IEnumerable
    {
        protected EntityRelationCollection() { }
        public virtual Azure.Response<bool> Exists(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource> Get(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.EntityRelationResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.EntityRelationResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource>> GetAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.EntityRelationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.EntityRelationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.EntityRelationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.EntityRelationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EntityRelationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EntityRelationResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.RelationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string entityId, string relationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EntityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EntityResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.EntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string entityId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EntityExpandResponse> Expand(Azure.ResourceManager.SecurityInsights.Models.EntityExpandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EntityExpandResponse>> ExpandAsync(Azure.ResourceManager.SecurityInsights.Models.EntityExpandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem> GetEntitiesGetTimelines(Azure.ResourceManager.SecurityInsights.Models.EntityTimelineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem> GetEntitiesGetTimelinesAsync(Azure.ResourceManager.SecurityInsights.Models.EntityTimelineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource> GetEntityRelation(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityRelationResource>> GetEntityRelationAsync(string relationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityInsights.EntityRelationCollection GetEntityRelations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.EntityInsightItem> GetInsights(Azure.ResourceManager.SecurityInsights.Models.EntityGetInsightsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.EntityInsightItem> GetInsightsAsync(Azure.ResourceManager.SecurityInsights.Models.EntityGetInsightsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.EntityQueryItem> Queries(Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind kind, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.EntityQueryItem> QueriesAsync(Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind kind, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileImportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.FileImportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.FileImportResource>, System.Collections.IEnumerable
    {
        protected FileImportCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.FileImportResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fileImportId, Azure.ResourceManager.SecurityInsights.FileImportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.FileImportResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fileImportId, Azure.ResourceManager.SecurityInsights.FileImportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource> Get(string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.FileImportResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.FileImportResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource>> GetAsync(string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.FileImportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.FileImportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.FileImportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.FileImportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FileImportData : Azure.ResourceManager.Models.ResourceData
    {
        public FileImportData() { }
        public Azure.ResourceManager.SecurityInsights.Models.FileImportContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimeUTC { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.FileMetadata ErrorFile { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ValidationError> ErrorsPreview { get { throw null; } }
        public System.DateTimeOffset? FilesValidUntilTimeUTC { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.FileMetadata ImportFile { get { throw null; } set { } }
        public System.DateTimeOffset? ImportValidUntilTimeUTC { get { throw null; } }
        public int? IngestedRecordCount { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IngestionMode? IngestionMode { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.FileImportState? State { get { throw null; } }
        public int? TotalRecordCount { get { throw null; } }
        public int? ValidRecordCount { get { throw null; } }
    }
    public partial class FileImportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FileImportResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.FileImportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string fileImportId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.FileImportResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.FileImportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.FileImportResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.FileImportData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string ProviderIncidentId { get { throw null; } set { } }
        public string ProviderName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> RelatedAnalyticRuleIds { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TeamInformation TeamInformation { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class IncidentRelationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>, System.Collections.IEnumerable
    {
        protected IncidentRelationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationName, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class IncidentRelationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IncidentRelationResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.RelationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId, string relationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentRelationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.RelationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IncidentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IncidentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.IncidentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.TeamInformation> CreateTeam(Azure.ResourceManager.SecurityInsights.Models.TeamProperties teamProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.TeamInformation>> CreateTeamAsync(Azure.ResourceManager.SecurityInsights.Models.TeamProperties teamProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<System.BinaryData> RunPlaybook(Azure.ResourceManager.SecurityInsights.Models.ManualTriggerRequestBody requestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> RunPlaybookAsync(Azure.ResourceManager.SecurityInsights.Models.ManualTriggerRequestBody requestBody = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.IncidentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.IncidentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetadataModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.MetadataModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.MetadataModelResource>, System.Collections.IEnumerable
    {
        protected MetadataModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.MetadataModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metadataName, Azure.ResourceManager.SecurityInsights.MetadataModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.MetadataModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metadataName, Azure.ResourceManager.SecurityInsights.MetadataModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource> Get(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.MetadataModelResource> GetAll(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.MetadataModelResource> GetAllAsync(string filter = null, string orderby = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource>> GetAsync(string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.MetadataModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.MetadataModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.MetadataModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.MetadataModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetadataModelData : Azure.ResourceManager.Models.ResourceData
    {
        public MetadataModelData() { }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataAuthor Author { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataCategories Categories { get { throw null; } set { } }
        public string ContentId { get { throw null; } set { } }
        public string ContentSchemaVersion { get { throw null; } set { } }
        public string CustomVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataDependencies Dependencies { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? FirstPublishOn { get { throw null; } set { } }
        public string Icon { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind? Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastPublishOn { get { throw null; } set { } }
        public string ParentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreviewImages { get { throw null; } }
        public System.Collections.Generic.IList<string> PreviewImagesDark { get { throw null; } }
        public System.Collections.Generic.IList<string> Providers { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataSource Source { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataSupport Support { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ThreatAnalysisTactics { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatAnalysisTechniques { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class MetadataModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataModelResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.MetadataModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string metadataName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource> Update(Azure.ResourceManager.SecurityInsights.Models.MetadataModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource>> UpdateAsync(Azure.ResourceManager.SecurityInsights.Models.MetadataModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OfficeConsentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>, System.Collections.IEnumerable
    {
        protected OfficeConsentCollection() { }
        public virtual Azure.Response<bool> Exists(string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> Get(string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>> GetAsync(string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfficeConsentData : Azure.ResourceManager.Models.ResourceData
    {
        public OfficeConsentData() { }
        public string ConsentId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeConsentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfficeConsentResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.OfficeConsentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string consentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelationData : Azure.ResourceManager.Models.ResourceData
    {
        public RelationData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string RelatedResourceId { get { throw null; } set { } }
        public string RelatedResourceKind { get { throw null; } }
        public string RelatedResourceName { get { throw null; } }
        public string RelatedResourceType { get { throw null; } }
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
        public static Azure.ResourceManager.SecurityInsights.BookmarkRelationResource GetBookmarkRelationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.BookmarkResource GetBookmarkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.BookmarkCollection GetBookmarks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource> GetDataConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.DataConnectorResource>> GetDataConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string dataConnectorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.DataConnectorResource GetDataConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.DataConnectorCollection GetDataConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhois> GetDomainWhoisInformation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhois>> GetDomainWhoisInformationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domain, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityCollection GetEntities(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource> GetEntity(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityResource>> GetEntityAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityQueryCollection GetEntityQueries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource> GetEntityQuery(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryResource>> GetEntityQueryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityQueryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityQueryResource GetEntityQueryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource> GetEntityQueryTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource>> GetEntityQueryTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string entityQueryTemplateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityQueryTemplateResource GetEntityQueryTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityQueryTemplateCollection GetEntityQueryTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityRelationResource GetEntityRelationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.EntityResource GetEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource> GetFileImport(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.FileImportResource>> GetFileImportAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string fileImportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.FileImportResource GetFileImportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.FileImportCollection GetFileImports(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource> GetIncident(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.IncidentResource>> GetIncidentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentCommentResource GetIncidentCommentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentRelationResource GetIncidentRelationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentResource GetIncidentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.IncidentCollection GetIncidents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EnrichmentIPGeodata> GetIPGeodatum(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.EnrichmentIPGeodata>> GetIPGeodatumAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource> GetMetadataModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.MetadataModelResource>> GetMetadataModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string metadataName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.MetadataModelResource GetMetadataModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.MetadataModelCollection GetMetadataModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetMetricsThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceMetrics> GetMetricsThreatIntelligenceIndicatorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource> GetOfficeConsent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.OfficeConsentResource>> GetOfficeConsentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string consentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.OfficeConsentResource GetOfficeConsentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.OfficeConsentCollection GetOfficeConsents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.Repo> GetRepositoriesSourceControls(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.RepoType repoType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.Repo> GetRepositoriesSourceControlsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.RepoType repoType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource> GetSecurityInsightsAlertRule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource>> GetSecurityInsightsAlertRuleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string ruleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleResource GetSecurityInsightsAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleCollection GetSecurityInsightsAlertRules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetSecurityMLAnalyticsSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetSecurityMLAnalyticsSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource GetSecurityMLAnalyticsSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingCollection GetSecurityMLAnalyticsSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource> GetSentinelOnboardingState(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource>> GetSentinelOnboardingStateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sentinelOnboardingStateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateResource GetSentinelOnboardingStateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SentinelOnboardingStateCollection GetSentinelOnboardingStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource> GetSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource>> GetSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SettingResource GetSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SettingCollection GetSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource> GetSourceControl(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource>> GetSourceControlAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SourceControlResource GetSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.SourceControlCollection GetSourceControls(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetThreatIntelligenceIndicator(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> GetThreatIntelligenceIndicatorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorResource GetThreatIntelligenceIndicatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorCollection GetThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource> GetWatchlist(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.WatchlistResource>> GetWatchlistAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, string watchlistAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistItemResource GetWatchlistItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistResource GetWatchlistResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.WatchlistCollection GetWatchlists(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityInsights.Models.DataConnectorRequirementsState> PostDataConnectorsCheckRequirement(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.Models.DataConnectorRequirementsState>> PostDataConnectorsCheckRequirementAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> QueryThreatIntelligenceIndicators(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> QueryThreatIntelligenceIndicatorsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>, System.Collections.IEnumerable
    {
        protected SecurityMLAnalyticsSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string settingsResourceName, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string settingsResourceName, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Get(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetAsync(string settingsResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SecurityMLAnalyticsSettingData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SecurityMLAnalyticsSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecurityMLAnalyticsSettingResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string settingsResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class SettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SettingResource>, System.Collections.IEnumerable
    {
        protected SettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string settingsName, Azure.ResourceManager.SecurityInsights.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string settingsName, Azure.ResourceManager.SecurityInsights.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource> Get(string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource>> GetAsync(string settingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SettingData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public partial class SettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SettingResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string settingsName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SourceControlResource>, System.Collections.IEnumerable
    {
        protected SourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlId, Azure.ResourceManager.SecurityInsights.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlId, Azure.ResourceManager.SecurityInsights.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource> Get(string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.SourceControlResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.SourceControlResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource>> GetAsync(string sourceControlId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityInsights.SourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityInsights.SourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityInsights.SourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.SourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public SourceControlData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ContentType> ContentTypes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeploymentInfo LastDeploymentInfo { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Repository Repository { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.RepositoryResourceInfo RepositoryResourceInfo { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.RepoType? RepoType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Version? Version { get { throw null; } set { } }
    }
    public partial class SourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SourceControlResource() { }
        public virtual Azure.ResourceManager.SecurityInsights.SourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sourceControlId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityInsights.SourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SourceControlResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.SourceControlResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityInsights.SourceControlData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThreatIntelligenceIndicatorCollection : Azure.ResourceManager.ArmCollection
    {
        protected ThreatIntelligenceIndicatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, string name, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, string name, Azure.ResourceManager.SecurityInsights.ThreatIntelligenceIndicatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> Get(string workspaceName, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetAll(string workspaceName, string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceInformation> GetAllAsync(string workspaceName, string filter = null, string orderby = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string Source { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SourceType? SourceType { get { throw null; } set { } }
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
        public System.Collections.Generic.IDictionary<string, System.BinaryData> EntityMapping { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsDeleted { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ItemsKeyValue { get { throw null; } }
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
    public partial class AADCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public AADCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AADDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AADDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AatpCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public AatpCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AatpDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class AccountEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class ActivityCustomEntityQuery : Azure.ResourceManager.SecurityInsights.Models.EntityQueryCreateOrUpdateContent
    {
        public ActivityCustomEntityQuery() { }
        public string Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> EntitiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityType? InputEntityType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RequiredInputFieldsSets { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ActivityEntityQuery : Azure.ResourceManager.SecurityInsights.EntityQueryData
    {
        public ActivityEntityQuery() { }
        public string Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimeUtc { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> EntitiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityType? InputEntityType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTimeUtc { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RequiredInputFieldsSets { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ActivityEntityQueryTemplate : Azure.ResourceManager.SecurityInsights.EntityQueryTemplateData
    {
        public ActivityEntityQueryTemplate() { }
        public string Content { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.DataTypeDefinitions> DataTypes { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> EntitiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityType? InputEntityType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ActivityEntityQueryTemplatePropertiesQueryDefinitions QueryDefinitions { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> RequiredInputFieldsSets { get { throw null; } }
        public string Title { get { throw null; } set { } }
    }
    public partial class ActivityEntityQueryTemplatePropertiesQueryDefinitions
    {
        public ActivityEntityQueryTemplatePropertiesQueryDefinitions() { }
        public string Query { get { throw null; } set { } }
        public string SummarizeBy { get { throw null; } set { } }
    }
    public partial class ActivityTimelineItem : Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem
    {
        internal ActivityTimelineItem() { }
        public System.DateTimeOffset BucketEndTimeUTC { get { throw null; } }
        public System.DateTimeOffset BucketStartTimeUTC { get { throw null; } }
        public string Content { get { throw null; } }
        public System.DateTimeOffset FirstActivityTimeUTC { get { throw null; } }
        public System.DateTimeOffset LastActivityTimeUTC { get { throw null; } }
        public string QueryId { get { throw null; } }
        public string Title { get { throw null; } }
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
    public partial class Anomalies : Azure.ResourceManager.SecurityInsights.SettingData
    {
        public Anomalies() { }
        public bool? IsEnabled { get { throw null; } }
    }
    public partial class AnomalySecurityMLAnalyticsSettings : Azure.ResourceManager.SecurityInsights.SecurityMLAnalyticsSettingData
    {
        public AnomalySecurityMLAnalyticsSettings() { }
        public int? AnomalySettingsVersion { get { throw null; } set { } }
        public string AnomalyVersion { get { throw null; } set { } }
        public System.BinaryData CustomizableObservations { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.TimeSpan? Frequency { get { throw null; } set { } }
        public bool? IsDefaultSettings { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.SecurityMLAnalyticsSettingsDataSource> RequiredDataConnectors { get { throw null; } }
        public System.Guid? SettingsDefinitionId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SettingsStatus? SettingsStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
    }
    public partial class AnomalyTimelineItem : Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem
    {
        internal AnomalyTimelineItem() { }
        public string AzureResourceId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset EndTimeUtc { get { throw null; } }
        public string Intent { get { throw null; } }
        public string ProductName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Reasons { get { throw null; } }
        public System.DateTimeOffset StartTimeUtc { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
        public System.DateTimeOffset TimeGenerated { get { throw null; } }
        public string Vendor { get { throw null; } }
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
    public partial class ASCCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public ASCCheckRequirements() { }
        public string SubscriptionId { get { throw null; } set { } }
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
    public readonly partial struct AutomationRulePropertyArrayChangedConditionSupportedArrayType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyArrayChangedConditionSupportedArrayType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Alerts { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Comments { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Labels { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType Tactics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyArrayChangedConditionSupportedChangeType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyArrayChangedConditionSupportedChangeType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType Added { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationRulePropertyArrayChangedValuesCondition
    {
        public AutomationRulePropertyArrayChangedValuesCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedArrayType? ArrayType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedConditionSupportedChangeType? ChangeType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyChangedConditionSupportedChangedType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyChangedConditionSupportedChangedType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType ChangedFrom { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType ChangedTo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRulePropertyChangedConditionSupportedPropertyType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRulePropertyChangedConditionSupportedPropertyType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentOwner { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentSeverity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType IncidentStatus { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType left, Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedProperty AlertAnalyticRuleIds { get { throw null; } }
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
    public partial class AutomationRulePropertyValuesChangedCondition
    {
        public AutomationRulePropertyValuesChangedCondition() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedChangedType? ChangeType { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyConditionSupportedOperator? Operator { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyChangedConditionSupportedPropertyType? PropertyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PropertyValues { get { throw null; } }
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
    public partial class Availability
    {
        public Availability() { }
        public bool? IsPreview { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus>
    {
        private readonly int _dummyPrimitive;
        public AvailabilityStatus(int value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus _1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus left, Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus left, Azure.ResourceManager.SecurityInsights.Models.AvailabilityStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AwsCloudTrailCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public AwsCloudTrailCheckRequirements() { }
    }
    public partial class AwsCloudTrailDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AwsCloudTrailDataConnector() { }
        public string AwsRoleArn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? LogsState { get { throw null; } set { } }
    }
    public partial class AwsS3CheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public AwsS3CheckRequirements() { }
    }
    public partial class AwsS3DataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public AwsS3DataConnector() { }
        public string DestinationTable { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? LogsState { get { throw null; } set { } }
        public string RoleArn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SqsUrls { get { throw null; } }
    }
    public partial class AzureDevOpsResourceInfo
    {
        public AzureDevOpsResourceInfo() { }
        public string PipelineId { get { throw null; } set { } }
        public string ServiceConnectionId { get { throw null; } set { } }
    }
    public partial class AzureResourceEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public AzureResourceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class BookmarkEntityMappings
    {
        public BookmarkEntityMappings() { }
        public string EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityFieldMapping> FieldMappings { get { throw null; } }
    }
    public partial class BookmarkExpandContent
    {
        public BookmarkExpandContent() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Guid? ExpansionId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class BookmarkExpandResponse
    {
        internal BookmarkExpandResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ExpansionResultAggregation> MetaDataAggregations { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.BookmarkExpandResponseValue Value { get { throw null; } }
    }
    public partial class BookmarkExpandResponseValue
    {
        internal BookmarkExpandResponseValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ConnectedEntity> Edges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.EntityData> Entities { get { throw null; } }
    }
    public partial class BookmarkTimelineItem : Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem
    {
        internal BookmarkTimelineItem() { }
        public string AzureResourceId { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.UserInfo CreatedBy { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? EventOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Labels { get { throw null; } }
        public string Notes { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
    }
    public partial class ClientInfo
    {
        internal ClientInfo() { }
        public string Email { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
    }
    public partial class CloudApplicationEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public CloudApplicationEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public int? AppId { get { throw null; } }
        public string AppName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string InstanceName { get { throw null; } }
    }
    public partial class CodelessApiPollingDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public CodelessApiPollingDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigProperties ConnectorUiConfig { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingConfigProperties PollingConfig { get { throw null; } set { } }
    }
    public partial class CodelessConnectorPollingAuthProperties
    {
        public CodelessConnectorPollingAuthProperties(string authType) { }
        public string ApiKeyIdentifier { get { throw null; } set { } }
        public string ApiKeyName { get { throw null; } set { } }
        public string AuthorizationEndpoint { get { throw null; } set { } }
        public System.BinaryData AuthorizationEndpointQueryParameters { get { throw null; } set { } }
        public string AuthType { get { throw null; } set { } }
        public string FlowName { get { throw null; } set { } }
        public string IsApiKeyInPostPayload { get { throw null; } set { } }
        public bool? IsClientSecretInHeader { get { throw null; } set { } }
        public string RedirectionEndpoint { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string TokenEndpoint { get { throw null; } set { } }
        public System.BinaryData TokenEndpointHeaders { get { throw null; } set { } }
        public System.BinaryData TokenEndpointQueryParameters { get { throw null; } set { } }
    }
    public partial class CodelessConnectorPollingConfigProperties
    {
        public CodelessConnectorPollingConfigProperties(Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingAuthProperties auth, Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingRequestProperties request) { }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingAuthProperties Auth { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingPagingProperties Paging { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingRequestProperties Request { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessConnectorPollingResponseProperties Response { get { throw null; } set { } }
    }
    public partial class CodelessConnectorPollingPagingProperties
    {
        public CodelessConnectorPollingPagingProperties(string pagingType) { }
        public string NextPageParaName { get { throw null; } set { } }
        public string NextPageTokenJsonPath { get { throw null; } set { } }
        public string PageCountAttributePath { get { throw null; } set { } }
        public int? PageSize { get { throw null; } set { } }
        public string PageSizeParaName { get { throw null; } set { } }
        public string PageTimeStampAttributePath { get { throw null; } set { } }
        public string PageTotalCountAttributePath { get { throw null; } set { } }
        public string PagingType { get { throw null; } set { } }
        public string SearchTheLatestTimeStampFromEventsList { get { throw null; } set { } }
    }
    public partial class CodelessConnectorPollingRequestProperties
    {
        public CodelessConnectorPollingRequestProperties(string apiEndpoint, int queryWindowInMin, string httpMethod, string queryTimeFormat) { }
        public string ApiEndpoint { get { throw null; } set { } }
        public string EndTimeAttributeName { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public string HttpMethod { get { throw null; } set { } }
        public System.BinaryData QueryParameters { get { throw null; } set { } }
        public string QueryParametersTemplate { get { throw null; } set { } }
        public string QueryTimeFormat { get { throw null; } set { } }
        public int QueryWindowInMin { get { throw null; } set { } }
        public int? RateLimitQps { get { throw null; } set { } }
        public int? RetryCount { get { throw null; } set { } }
        public string StartTimeAttributeName { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class CodelessConnectorPollingResponseProperties
    {
        public CodelessConnectorPollingResponseProperties(System.Collections.Generic.IEnumerable<string> eventsJsonPaths) { }
        public System.Collections.Generic.IList<string> EventsJsonPaths { get { throw null; } }
        public bool? IsGzipCompressed { get { throw null; } set { } }
        public string SuccessStatusJsonPath { get { throw null; } set { } }
        public string SuccessStatusValue { get { throw null; } set { } }
    }
    public partial class CodelessUiConnectorConfigProperties
    {
        public CodelessUiConnectorConfigProperties(string title, string publisher, string descriptionMarkdown, string graphQueriesTableName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesGraphQueriesItem> graphQueries, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesSampleQueriesItem> sampleQueries, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesDataTypesItem> dataTypes, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesConnectivityCriteriaItem> connectivityCriteria, Azure.ResourceManager.SecurityInsights.Models.Availability availability, Azure.ResourceManager.SecurityInsights.Models.Permissions permissions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesInstructionStepsItem> instructionSteps) { }
        public Azure.ResourceManager.SecurityInsights.Models.Availability Availability { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesConnectivityCriteriaItem> ConnectivityCriteria { get { throw null; } }
        public string CustomImage { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesDataTypesItem> DataTypes { get { throw null; } }
        public string DescriptionMarkdown { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesGraphQueriesItem> GraphQueries { get { throw null; } }
        public string GraphQueriesTableName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesInstructionStepsItem> InstructionSteps { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.Permissions Permissions { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigPropertiesSampleQueriesItem> SampleQueries { get { throw null; } }
        public string Title { get { throw null; } set { } }
    }
    public partial class CodelessUiConnectorConfigPropertiesConnectivityCriteriaItem : Azure.ResourceManager.SecurityInsights.Models.ConnectivityCriteria
    {
        public CodelessUiConnectorConfigPropertiesConnectivityCriteriaItem() { }
    }
    public partial class CodelessUiConnectorConfigPropertiesDataTypesItem : Azure.ResourceManager.SecurityInsights.Models.LastDataReceivedDataType
    {
        public CodelessUiConnectorConfigPropertiesDataTypesItem() { }
    }
    public partial class CodelessUiConnectorConfigPropertiesGraphQueriesItem : Azure.ResourceManager.SecurityInsights.Models.GraphQueries
    {
        public CodelessUiConnectorConfigPropertiesGraphQueriesItem() { }
    }
    public partial class CodelessUiConnectorConfigPropertiesInstructionStepsItem : Azure.ResourceManager.SecurityInsights.Models.InstructionSteps
    {
        public CodelessUiConnectorConfigPropertiesInstructionStepsItem() { }
    }
    public partial class CodelessUiConnectorConfigPropertiesSampleQueriesItem : Azure.ResourceManager.SecurityInsights.Models.SampleQueries
    {
        public CodelessUiConnectorConfigPropertiesSampleQueriesItem() { }
    }
    public partial class CodelessUiDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public CodelessUiDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.CodelessUiConnectorConfigProperties ConnectorUiConfig { get { throw null; } set { } }
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
    public readonly partial struct ConnectAuthKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectAuthKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind APIKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind Basic { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind OAuth2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind left, Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind left, Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedEntity
    {
        internal ConnectedEntity() { }
        public System.BinaryData AdditionalData { get { throw null; } }
        public string TargetEntityId { get { throw null; } }
    }
    public partial class ConnectivityCriteria
    {
        public ConnectivityCriteria() { }
        public Azure.ResourceManager.SecurityInsights.Models.ConnectivityType? ConnectivityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectivityType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ConnectivityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectivityType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ConnectivityType IsConnectedQuery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ConnectivityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ConnectivityType left, Azure.ResourceManager.SecurityInsights.Models.ConnectivityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ConnectivityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ConnectivityType left, Azure.ResourceManager.SecurityInsights.Models.ConnectivityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectorInstructionModelBase
    {
        public ConnectorInstructionModelBase(Azure.ResourceManager.SecurityInsights.Models.SettingType settingType) { }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SettingType SettingType { get { throw null; } set { } }
    }
    public partial class ContentPathMap
    {
        public ContentPathMap() { }
        public Azure.ResourceManager.SecurityInsights.Models.ContentType? ContentType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ContentType AnalyticRule { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ContentType Workbook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ContentType left, Azure.ResourceManager.SecurityInsights.Models.ContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ContentType left, Azure.ResourceManager.SecurityInsights.Models.ContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Customs : Azure.ResourceManager.SecurityInsights.Models.CustomsPermission
    {
        public Customs() { }
    }
    public partial class CustomsPermission
    {
        public CustomsPermission() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectorAuthorizationState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectorAuthorizationState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState Invalid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState left, Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState left, Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectorConnectBody
    {
        public DataConnectorConnectBody() { }
        public string ApiKey { get { throw null; } set { } }
        public string AuthorizationCode { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public string DataCollectionEndpoint { get { throw null; } set { } }
        public string DataCollectionRuleImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ConnectAuthKind? Kind { get { throw null; } set { } }
        public string OutputStream { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> RequestConfigUserInputValues { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class DataConnectorDataTypeCommon
    {
        public DataConnectorDataTypeCommon(Azure.ResourceManager.SecurityInsights.Models.DataTypeState state) { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectorLicenseState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectorLicenseState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState Invalid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState Unknown { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState left, Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState left, Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectorRequirementsState
    {
        internal DataConnectorRequirementsState() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataConnectorAuthorizationState? AuthorizationState { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.DataConnectorLicenseState? LicenseState { get { throw null; } }
    }
    public abstract partial class DataConnectorsCheckRequirements
    {
        protected DataConnectorsCheckRequirements() { }
    }
    public partial class DataTypeDefinitions
    {
        public DataTypeDefinitions() { }
        public string DataType { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DeleteStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DeleteStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeleteStatus NotDeleted { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeleteStatus Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DeleteStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DeleteStatus left, Azure.ResourceManager.SecurityInsights.Models.DeleteStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DeleteStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DeleteStatus left, Azure.ResourceManager.SecurityInsights.Models.DeleteStatus right) { throw null; }
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
    public partial class Deployment
    {
        public Deployment() { }
        public string DeploymentId { get { throw null; } set { } }
        public System.Uri DeploymentLogsUri { get { throw null; } set { } }
        public System.DateTimeOffset? DeploymentOn { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeploymentResult? DeploymentResult { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeploymentState? DeploymentState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentFetchStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentFetchStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus NotFound { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus Success { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus Unauthorized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus left, Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus left, Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentInfo
    {
        public DeploymentInfo() { }
        public Azure.ResourceManager.SecurityInsights.Models.Deployment Deployment { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DeploymentFetchStatus? DeploymentFetchStatus { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentResult : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DeploymentResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentResult(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentResult Canceled { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentResult Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentResult Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DeploymentResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DeploymentResult left, Azure.ResourceManager.SecurityInsights.Models.DeploymentResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DeploymentResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DeploymentResult left, Azure.ResourceManager.SecurityInsights.Models.DeploymentResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentState Canceling { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentState Completed { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeploymentState Queued { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DeploymentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DeploymentState left, Azure.ResourceManager.SecurityInsights.Models.DeploymentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DeploymentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DeploymentState left, Azure.ResourceManager.SecurityInsights.Models.DeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceImportance : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.DeviceImportance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceImportance(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.DeviceImportance High { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeviceImportance Low { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeviceImportance Normal { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.DeviceImportance Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.DeviceImportance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.DeviceImportance left, Azure.ResourceManager.SecurityInsights.Models.DeviceImportance right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.DeviceImportance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.DeviceImportance left, Azure.ResourceManager.SecurityInsights.Models.DeviceImportance right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public DnsEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DnsServerIPEntityId { get { throw null; } }
        public string DomainName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostIPAddressEntityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddressEntityIds { get { throw null; } }
    }
    public partial class Dynamics365CheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public Dynamics365CheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class Dynamics365DataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public Dynamics365DataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? Dynamics365CdsActivitiesState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public enum ElevationToken
    {
        Default = 0,
        Full = 1,
        Limited = 2,
    }
    public partial class EnrichmentDomainWhois
    {
        internal EnrichmentDomainWhois() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Domain { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisDetails ParsedWhois { get { throw null; } }
        public string Server { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class EnrichmentDomainWhoisContact
    {
        internal EnrichmentDomainWhoisContact() { }
        public string City { get { throw null; } }
        public string Country { get { throw null; } }
        public string Email { get { throw null; } }
        public string Fax { get { throw null; } }
        public string Name { get { throw null; } }
        public string Org { get { throw null; } }
        public string Phone { get { throw null; } }
        public string Postal { get { throw null; } }
        public string State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Street { get { throw null; } }
    }
    public partial class EnrichmentDomainWhoisContacts
    {
        internal EnrichmentDomainWhoisContacts() { }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisContact Admin { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisContact Billing { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisContact Registrant { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisContact Tech { get { throw null; } }
    }
    public partial class EnrichmentDomainWhoisDetails
    {
        internal EnrichmentDomainWhoisDetails() { }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisContacts Contacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NameServers { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EnrichmentDomainWhoisRegistrarDetails Registrar { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Statuses { get { throw null; } }
    }
    public partial class EnrichmentDomainWhoisRegistrarDetails
    {
        internal EnrichmentDomainWhoisRegistrarDetails() { }
        public string AbuseContactEmail { get { throw null; } }
        public string AbuseContactPhone { get { throw null; } }
        public string IanaId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string WhoisServer { get { throw null; } }
    }
    public partial class EnrichmentIPGeodata
    {
        internal EnrichmentIPGeodata() { }
        public string Asn { get { throw null; } }
        public string Carrier { get { throw null; } }
        public string City { get { throw null; } }
        public int? CityCf { get { throw null; } }
        public string Continent { get { throw null; } }
        public string Country { get { throw null; } }
        public int? CountryCf { get { throw null; } }
        public string IPAddr { get { throw null; } }
        public string IPRoutingType { get { throw null; } }
        public string Latitude { get { throw null; } }
        public string Longitude { get { throw null; } }
        public string Organization { get { throw null; } }
        public string OrganizationType { get { throw null; } }
        public string Region { get { throw null; } }
        public string State { get { throw null; } }
        public int? StateCf { get { throw null; } }
        public string StateCode { get { throw null; } }
    }
    public partial class EntityAnalytics : Azure.ResourceManager.SecurityInsights.SettingData
    {
        public EntityAnalytics() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityProvider> EntityProviders { get { throw null; } }
    }
    public partial class EntityEdges
    {
        internal EntityEdges() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string TargetEntityId { get { throw null; } }
    }
    public partial class EntityExpandContent
    {
        public EntityExpandContent() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Guid? ExpansionId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class EntityExpandResponse
    {
        internal EntityExpandResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ExpansionResultAggregation> MetaDataAggregations { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityExpandResponseValue Value { get { throw null; } }
    }
    public partial class EntityExpandResponseValue
    {
        internal EntityExpandResponseValue() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.EntityEdges> Edges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.EntityData> Entities { get { throw null; } }
    }
    public partial class EntityFieldMapping
    {
        public EntityFieldMapping() { }
        public string Identifier { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class EntityGetInsightsContent
    {
        public EntityGetInsightsContent(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public bool? AddDefaultExtendedTimeRange { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> InsightQueryIds { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
    }
    public partial class EntityInsightItem
    {
        internal EntityInsightItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.InsightsTableResult> ChartQueryResults { get { throw null; } }
        public string QueryId { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityInsightItemQueryTimeInterval QueryTimeInterval { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.InsightsTableResult TableQueryResults { get { throw null; } }
    }
    public partial class EntityInsightItemQueryTimeInterval
    {
        internal EntityInsightItemQueryTimeInterval() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityItemQueryKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityItemQueryKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind Insight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind left, Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind left, Azure.ResourceManager.SecurityInsights.Models.EntityItemQueryKind right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.SecurityInsights.Models.EntityKind Nic { get { throw null; } }
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
    public readonly partial struct EntityProvider : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityProvider(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityProvider ActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityProvider AzureActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityProvider other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityProvider left, Azure.ResourceManager.SecurityInsights.Models.EntityProvider right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityProvider (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityProvider left, Azure.ResourceManager.SecurityInsights.Models.EntityProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityQueryCreateOrUpdateContent : Azure.ResourceManager.Models.ResourceData
    {
        public EntityQueryCreateOrUpdateContent() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
    }
    public abstract partial class EntityQueryItem : Azure.ResourceManager.Models.ResourceData
    {
        protected EntityQueryItem() { }
    }
    public partial class EntityQueryItemProperties
    {
        internal EntityQueryItemProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.EntityQueryItemPropertiesDataTypesItem> DataTypes { get { throw null; } }
        public System.BinaryData EntitiesFilter { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityType? InputEntityType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> RequiredInputFieldsSets { get { throw null; } }
    }
    public partial class EntityQueryItemPropertiesDataTypesItem
    {
        internal EntityQueryItemPropertiesDataTypesItem() { }
        public string DataType { get { throw null; } }
    }
    public partial class EntityTimelineContent
    {
        public EntityTimelineContent(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind> Kinds { get { throw null; } }
        public int? NumberOfBucket { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } }
    }
    public abstract partial class EntityTimelineItem
    {
        protected EntityTimelineItem() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityTimelineKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityTimelineKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind Activity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind Anomaly { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind Bookmark { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind SecurityAlert { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind left, Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind left, Azure.ResourceManager.SecurityInsights.Models.EntityTimelineKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EntityType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.EntityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EntityType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Account { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType AzureResource { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType CloudApplication { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Dns { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType File { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType FileHash { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Host { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType HuntingBookmark { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType IoTDevice { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType IP { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Mailbox { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType MailCluster { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType MailMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Malware { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Nic { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType Process { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType RegistryKey { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType RegistryValue { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType SecurityAlert { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType SecurityGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType SubmissionMail { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.EntityType URL { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.EntityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.EntityType left, Azure.ResourceManager.SecurityInsights.Models.EntityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.EntityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.EntityType left, Azure.ResourceManager.SecurityInsights.Models.EntityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum13 : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Enum13>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum13(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Enum13 Activity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.Enum13 Expansion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Enum13 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Enum13 left, Azure.ResourceManager.SecurityInsights.Models.Enum13 right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Enum13 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Enum13 left, Azure.ResourceManager.SecurityInsights.Models.Enum13 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum15 : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Enum15>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum15(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Enum15 Activity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Enum15 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Enum15 left, Azure.ResourceManager.SecurityInsights.Models.Enum15 right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Enum15 (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Enum15 left, Azure.ResourceManager.SecurityInsights.Models.Enum15 right) { throw null; }
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
    public partial class ExpansionEntityQuery : Azure.ResourceManager.SecurityInsights.EntityQueryData
    {
        public ExpansionEntityQuery() { }
        public System.Collections.Generic.IList<string> DataSources { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityType? InputEntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputFields { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityType> OutputEntityTypes { get { throw null; } }
        public string QueryTemplate { get { throw null; } set { } }
    }
    public partial class ExpansionResultAggregation
    {
        internal ExpansionResultAggregation() { }
        public string AggregationType { get { throw null; } }
        public int Count { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.EntityKind EntityKind { get { throw null; } }
    }
    public partial class EyesOn : Azure.ResourceManager.SecurityInsights.SettingData
    {
        public EyesOn() { }
        public bool? IsEnabled { get { throw null; } }
    }
    public partial class FieldMapping
    {
        public FieldMapping() { }
        public string ColumnName { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
    }
    public partial class FileEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public readonly partial struct FileFormat : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.FileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileFormat(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.FileFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileFormat Json { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileFormat Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.FileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.FileFormat left, Azure.ResourceManager.SecurityInsights.Models.FileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.FileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.FileFormat left, Azure.ResourceManager.SecurityInsights.Models.FileFormat right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class FileHashEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public FileHashEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.FileHashAlgorithm? Algorithm { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HashValue { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileImportContentType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.FileImportContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileImportContentType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportContentType BasicIndicator { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportContentType StixIndicator { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportContentType Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.FileImportContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.FileImportContentType left, Azure.ResourceManager.SecurityInsights.Models.FileImportContentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.FileImportContentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.FileImportContentType left, Azure.ResourceManager.SecurityInsights.Models.FileImportContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileImportState : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.FileImportState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileImportState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState FatalError { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState Ingested { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState IngestedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState Invalid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState Unspecified { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.FileImportState WaitingForUpload { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.FileImportState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.FileImportState left, Azure.ResourceManager.SecurityInsights.Models.FileImportState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.FileImportState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.FileImportState left, Azure.ResourceManager.SecurityInsights.Models.FileImportState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileMetadata
    {
        public FileMetadata() { }
        public Azure.ResourceManager.SecurityInsights.Models.DeleteStatus? DeleteStatus { get { throw null; } }
        public System.Uri FileContentUri { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.FileFormat? FileFormat { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public int? FileSize { get { throw null; } set { } }
    }
    public partial class FusionAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public FusionAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionScenarioExclusionPattern> ScenarioExclusionPatterns { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionSourceSettings> SourceSettings { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionTemplateSourceSetting> SourceSettings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.TemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
    }
    public partial class FusionScenarioExclusionPattern
    {
        public FusionScenarioExclusionPattern(string exclusionPattern, string dateAddedInUTC) { }
        public string DateAddedInUTC { get { throw null; } set { } }
        public string ExclusionPattern { get { throw null; } set { } }
    }
    public partial class FusionSourceSettings
    {
        public FusionSourceSettings(bool enabled, string sourceName) { }
        public bool Enabled { get { throw null; } set { } }
        public string SourceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionSourceSubTypeSetting> SourceSubTypes { get { throw null; } }
    }
    public partial class FusionSourceSubTypeSetting
    {
        public FusionSourceSubTypeSetting(bool enabled, string sourceSubTypeName, Azure.ResourceManager.SecurityInsights.Models.FusionSubTypeSeverityFilter severityFilters) { }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.FusionSubTypeSeverityFilter SeverityFilters { get { throw null; } set { } }
        public string SourceSubTypeDisplayName { get { throw null; } }
        public string SourceSubTypeName { get { throw null; } set { } }
    }
    public partial class FusionSubTypeSeverityFilter
    {
        public FusionSubTypeSeverityFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionSubTypeSeverityFiltersItem> Filters { get { throw null; } }
        public bool? IsSupported { get { throw null; } }
    }
    public partial class FusionSubTypeSeverityFiltersItem
    {
        public FusionSubTypeSeverityFiltersItem(Azure.ResourceManager.SecurityInsights.Models.AlertSeverity severity, bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity Severity { get { throw null; } set { } }
    }
    public partial class FusionTemplateSourceSetting
    {
        public FusionTemplateSourceSetting(string sourceName) { }
        public string SourceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.FusionTemplateSourceSubType> SourceSubTypes { get { throw null; } }
    }
    public partial class FusionTemplateSourceSubType
    {
        public FusionTemplateSourceSubType(string sourceSubTypeName, Azure.ResourceManager.SecurityInsights.Models.FusionTemplateSubTypeSeverityFilter severityFilter) { }
        public Azure.ResourceManager.SecurityInsights.Models.FusionTemplateSubTypeSeverityFilter SeverityFilter { get { throw null; } set { } }
        public string SourceSubTypeDisplayName { get { throw null; } }
        public string SourceSubTypeName { get { throw null; } set { } }
    }
    public partial class FusionTemplateSubTypeSeverityFilter
    {
        public FusionTemplateSubTypeSeverityFilter(bool isSupported) { }
        public bool IsSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertSeverity> SeverityFilters { get { throw null; } }
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
    public partial class GraphQueries
    {
        public GraphQueries() { }
        public string BaseQuery { get { throw null; } set { } }
        public string Legend { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
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
    public partial class HostEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class HuntingBookmark : Azure.ResourceManager.SecurityInsights.EntityData
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
        public System.Uri ProviderIncidentUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.EntityData> Entities { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionMode : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.IngestionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionMode(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.IngestionMode IngestAnyValidRecords { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IngestionMode IngestOnlyIfAllAreValid { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.IngestionMode Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.IngestionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.IngestionMode left, Azure.ResourceManager.SecurityInsights.Models.IngestionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.IngestionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.IngestionMode left, Azure.ResourceManager.SecurityInsights.Models.IngestionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InsightQueryItem : Azure.ResourceManager.SecurityInsights.Models.EntityQueryItem
    {
        internal InsightQueryItem() { }
        public Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemProperties Properties { get { throw null; } }
    }
    public partial class InsightQueryItemProperties : Azure.ResourceManager.SecurityInsights.Models.EntityQueryItemProperties
    {
        internal InsightQueryItemProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesAdditionalQuery AdditionalQuery { get { throw null; } }
        public string BaseQuery { get { throw null; } }
        public string BeforeRange { get { throw null; } }
        public System.BinaryData ChartQuery { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesDefaultTimeRange DefaultTimeRange { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesTableQuery TableQuery { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesAdditionalQuery
    {
        internal InsightQueryItemPropertiesAdditionalQuery() { }
        public string Query { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesDefaultTimeRange
    {
        internal InsightQueryItemPropertiesDefaultTimeRange() { }
        public string AfterRange { get { throw null; } }
        public string BeforeRange { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesTableQuery
    {
        internal InsightQueryItemPropertiesTableQuery() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesTableQueryColumnsDefinitionsItem> ColumnsDefinitions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesTableQueryQueriesDefinitionsItem> QueriesDefinitions { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesTableQueryColumnsDefinitionsItem
    {
        internal InsightQueryItemPropertiesTableQueryColumnsDefinitionsItem() { }
        public string Header { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.OutputType? OutputType { get { throw null; } }
        public bool? SupportDeepLink { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesTableQueryQueriesDefinitionsItem
    {
        internal InsightQueryItemPropertiesTableQueryQueriesDefinitionsItem() { }
        public string Filter { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.InsightQueryItemPropertiesTableQueryQueriesDefinitionsPropertiesItemsItem> LinkColumnsDefinitions { get { throw null; } }
        public string Project { get { throw null; } }
        public string Summarize { get { throw null; } }
    }
    public partial class InsightQueryItemPropertiesTableQueryQueriesDefinitionsPropertiesItemsItem
    {
        internal InsightQueryItemPropertiesTableQueryQueriesDefinitionsPropertiesItemsItem() { }
        public string ProjectedName { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class InsightsTableResult
    {
        internal InsightsTableResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.InsightsTableResultColumnsItem> Columns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> Rows { get { throw null; } }
    }
    public partial class InsightsTableResultColumnsItem
    {
        internal InsightsTableResultColumnsItem() { }
        public string InsightsTableResultColumnsItemType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class InstructionSteps
    {
        public InstructionSteps() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.InstructionStepsInstructionsItem> Instructions { get { throw null; } }
        public string Title { get { throw null; } set { } }
    }
    public partial class InstructionStepsInstructionsItem : Azure.ResourceManager.SecurityInsights.Models.ConnectorInstructionModelBase
    {
        public InstructionStepsInstructionsItem(Azure.ResourceManager.SecurityInsights.Models.SettingType settingType) : base (default(Azure.ResourceManager.SecurityInsights.Models.SettingType)) { }
    }
    public partial class IoTCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public IoTCheckRequirements() { }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class IoTDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public IoTDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class IoTDeviceEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public IoTDeviceEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string DeviceName { get { throw null; } }
        public string DeviceSubType { get { throw null; } }
        public string DeviceType { get { throw null; } }
        public string EdgeId { get { throw null; } }
        public string FirmwareVersion { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string HostEntityId { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.DeviceImportance? Importance { get { throw null; } set { } }
        public string IotHubEntityId { get { throw null; } }
        public System.Guid? IotSecurityAgentId { get { throw null; } }
        public string IPAddressEntityId { get { throw null; } }
        public bool? IsAuthorized { get { throw null; } }
        public bool? IsProgramming { get { throw null; } }
        public bool? IsScanner { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Model { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NicEntityIds { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Owners { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Protocols { get { throw null; } }
        public string PurdueLayer { get { throw null; } }
        public string Sensor { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string Site { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligence> ThreatIntelligence { get { throw null; } }
        public string Vendor { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    public partial class IPEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class LastDataReceivedDataType
    {
        public LastDataReceivedDataType() { }
        public string LastDataReceivedQuery { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MailboxEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public MailboxEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Guid? ExternalDirectoryObjectId { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MailboxPrimaryAddress { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class MailClusterEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class MailMessageEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class MalwareEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public MalwareEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileEntityIds { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string MalwareName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProcessEntityIds { get { throw null; } }
    }
    public partial class ManualTriggerRequestBody
    {
        public ManualTriggerRequestBody() { }
        public string LogicAppsResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
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
    public partial class McasCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public McasCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class McasDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public McasDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? DiscoveryLogsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MdatpCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public MdatpCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MdatpDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public MdatpDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MetadataAuthor
    {
        public MetadataAuthor() { }
        public string Email { get { throw null; } set { } }
        public string Link { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MetadataCategories
    {
        public MetadataCategories() { }
        public System.Collections.Generic.IList<string> Domains { get { throw null; } }
        public System.Collections.Generic.IList<string> Verticals { get { throw null; } }
    }
    public partial class MetadataDependencies
    {
        public MetadataDependencies() { }
        public string ContentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.MetadataDependencies> Criteria { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Operator? Operator { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class MetadataModelPatch : Azure.ResourceManager.Models.ResourceData
    {
        public MetadataModelPatch() { }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataAuthor Author { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataCategories Categories { get { throw null; } set { } }
        public string ContentId { get { throw null; } set { } }
        public string ContentSchemaVersion { get { throw null; } set { } }
        public string CustomVersion { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataDependencies Dependencies { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? FirstPublishOn { get { throw null; } set { } }
        public string Icon { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind? Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastPublishOn { get { throw null; } set { } }
        public string ParentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreviewImages { get { throw null; } }
        public System.Collections.Generic.IList<string> PreviewImagesDark { get { throw null; } }
        public System.Collections.Generic.IList<string> Providers { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataSource Source { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MetadataSupport Support { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ThreatAnalysisTactics { get { throw null; } }
        public System.Collections.Generic.IList<string> ThreatAnalysisTechniques { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class MetadataSource
    {
        public MetadataSource(Azure.ResourceManager.SecurityInsights.Models.SourceKind kind) { }
        public Azure.ResourceManager.SecurityInsights.Models.SourceKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SourceId { get { throw null; } set { } }
    }
    public partial class MetadataSupport
    {
        public MetadataSupport(Azure.ResourceManager.SecurityInsights.Models.SupportTier tier) { }
        public string Email { get { throw null; } set { } }
        public string Link { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.SupportTier Tier { get { throw null; } set { } }
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
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName MicrosoftDefenderAdvancedThreatProtection { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.MicrosoftSecurityProductName Office365AdvancedThreatProtection { get { throw null; } }
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
    public partial class MLBehaviorAnalyticsAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public MLBehaviorAnalyticsAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
    }
    public partial class MLBehaviorAnalyticsAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public MLBehaviorAnalyticsAlertRuleTemplate() { }
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
    public partial class MstiCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public MstiCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MstiDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public MstiDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.MstiDataConnectorDataTypesBingSafetyPhishingURL BingSafetyPhishingURL { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.MstiDataConnectorDataTypesMicrosoftEmergingThreatFeed MicrosoftEmergingThreatFeed { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MstiDataConnectorDataTypesBingSafetyPhishingURL : Azure.ResourceManager.SecurityInsights.Models.DataConnectorDataTypeCommon
    {
        public MstiDataConnectorDataTypesBingSafetyPhishingURL(Azure.ResourceManager.SecurityInsights.Models.DataTypeState state, string lookbackPeriod) : base (default(Azure.ResourceManager.SecurityInsights.Models.DataTypeState)) { }
        public string LookbackPeriod { get { throw null; } set { } }
    }
    public partial class MstiDataConnectorDataTypesMicrosoftEmergingThreatFeed : Azure.ResourceManager.SecurityInsights.Models.DataConnectorDataTypeCommon
    {
        public MstiDataConnectorDataTypesMicrosoftEmergingThreatFeed(Azure.ResourceManager.SecurityInsights.Models.DataTypeState state, string lookbackPeriod) : base (default(Azure.ResourceManager.SecurityInsights.Models.DataTypeState)) { }
        public string LookbackPeriod { get { throw null; } set { } }
    }
    public partial class MtpCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public MtpCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MTPDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public MTPDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? IncidentsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class NicEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public NicEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public string IPAddressEntityId { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Vlans { get { throw null; } }
    }
    public partial class NrtAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public NrtAlertRule() { }
        public Azure.ResourceManager.SecurityInsights.Models.AlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityMapping> EntityMappings { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.IncidentConfiguration IncidentConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public System.TimeSpan? SuppressionDuration { get { throw null; } set { } }
        public bool? SuppressionEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public string TemplateVersion { get { throw null; } set { } }
    }
    public partial class NrtAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public NrtAlertRuleTemplate() { }
        public Azure.ResourceManager.SecurityInsights.Models.AlertDetailsOverride AlertDetailsOverride { get { throw null; } set { } }
        public int? AlertRulesCreatedByTemplateCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDateUTC { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomDetails { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.EntityMapping> EntityMappings { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedDateUTC { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AlertRuleTemplateDataSource> RequiredDataConnectors { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.TemplateStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IList<string> Techniques { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class Office365ProjectCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public Office365ProjectCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class Office365ProjectDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public Office365ProjectDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? LogsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeATPCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public OfficeATPCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeATPDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public OfficeATPDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public OfficeDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? ExchangeState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? SharePointState { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? TeamsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeIRMCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public OfficeIRMCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficeIRMDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public OfficeIRMDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? AlertsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficePowerBICheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public OfficePowerBICheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class OfficePowerBIDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public OfficePowerBIDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? LogsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Operator AND { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.Operator OR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Operator left, Azure.ResourceManager.SecurityInsights.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Operator left, Azure.ResourceManager.SecurityInsights.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct OutputType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.OutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.OutputType Date { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.OutputType Entity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.OutputType Number { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.OutputType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.OutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.OutputType left, Azure.ResourceManager.SecurityInsights.Models.OutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.OutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.OutputType left, Azure.ResourceManager.SecurityInsights.Models.OutputType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionProviderScope : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionProviderScope(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope Subscription { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope Workspace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope left, Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope left, Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Permissions
    {
        public Permissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.PermissionsCustomsItem> Customs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.PermissionsResourceProviderItem> ResourceProvider { get { throw null; } }
    }
    public partial class PermissionsCustomsItem : Azure.ResourceManager.SecurityInsights.Models.Customs
    {
        public PermissionsCustomsItem() { }
    }
    public partial class PermissionsResourceProviderItem : Azure.ResourceManager.SecurityInsights.Models.ResourceProvider
    {
        public PermissionsResourceProviderItem() { }
    }
    public partial class PlaybookActionProperties
    {
        public PlaybookActionProperties() { }
        public string LogicAppResourceId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PollingFrequency : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.PollingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PollingFrequency(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.PollingFrequency OnceADay { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.PollingFrequency OnceAMinute { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.PollingFrequency OnceAnHour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.PollingFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.PollingFrequency left, Azure.ResourceManager.SecurityInsights.Models.PollingFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.PollingFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.PollingFrequency left, Azure.ResourceManager.SecurityInsights.Models.PollingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProcessEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class PropertyArrayChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleCondition
    {
        public PropertyArrayChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyArrayChangedValuesCondition ConditionProperties { get { throw null; } set { } }
    }
    public partial class PropertyChangedConditionProperties : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleCondition
    {
        public PropertyChangedConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesChangedCondition ConditionProperties { get { throw null; } set { } }
    }
    public partial class PropertyConditionProperties : Azure.ResourceManager.SecurityInsights.Models.AutomationRuleCondition
    {
        public PropertyConditionProperties() { }
        public Azure.ResourceManager.SecurityInsights.Models.AutomationRulePropertyValuesCondition ConditionProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderName : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ProviderName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderName(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftAadiamDiagnosticSettings { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftAuthorizationPolicyAssignments { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftOperationalInsightsSolutions { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftOperationalInsightsWorkspaces { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftOperationalInsightsWorkspacesDatasources { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ProviderName MicrosoftOperationalInsightsWorkspacesSharedKeys { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ProviderName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ProviderName left, Azure.ResourceManager.SecurityInsights.Models.ProviderName right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ProviderName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ProviderName left, Azure.ResourceManager.SecurityInsights.Models.ProviderName right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RegistryKeyEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public RegistryKeyEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.RegistryHive? Hive { get { throw null; } }
        public string Key { get { throw null; } }
    }
    public partial class RegistryValueEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class Repo
    {
        internal Repo() { }
        public System.Collections.Generic.IReadOnlyList<string> Branches { get { throw null; } }
        public string FullName { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class Repository
    {
        public Repository() { }
        public string Branch { get { throw null; } set { } }
        public System.Uri DeploymentLogsUri { get { throw null; } set { } }
        public System.Uri DisplayUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.ContentPathMap> PathMapping { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class RepositoryResourceInfo
    {
        public RepositoryResourceInfo() { }
        public Azure.ResourceManager.SecurityInsights.Models.AzureDevOpsResourceInfo AzureDevOpsResourceInfo { get { throw null; } set { } }
        public string GitHubResourceInfoAppInstallationId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.Webhook Webhook { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RepoType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.RepoType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RepoType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.RepoType DevOps { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.RepoType Github { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.RepoType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.RepoType left, Azure.ResourceManager.SecurityInsights.Models.RepoType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.RepoType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.RepoType left, Azure.ResourceManager.SecurityInsights.Models.RepoType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequiredPermissions
    {
        public RequiredPermissions() { }
        public bool? Action { get { throw null; } set { } }
        public bool? Delete { get { throw null; } set { } }
        public bool? Read { get { throw null; } set { } }
        public bool? Write { get { throw null; } set { } }
    }
    public partial class ResourceProvider
    {
        public ResourceProvider() { }
        public string PermissionsDisplayText { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.ProviderName? Provider { get { throw null; } set { } }
        public string ProviderDisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.RequiredPermissions RequiredPermissions { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.PermissionProviderScope? Scope { get { throw null; } set { } }
    }
    public partial class SampleQueries
    {
        public SampleQueries() { }
        public string Description { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
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
    public partial class SecurityAlert : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class SecurityAlertTimelineItem : Azure.ResourceManager.SecurityInsights.Models.EntityTimelineItem
    {
        internal SecurityAlertTimelineItem() { }
        public string AlertType { get { throw null; } }
        public string AzureResourceId { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset EndTimeUtc { get { throw null; } }
        public string ProductName { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity Severity { get { throw null; } }
        public System.DateTimeOffset StartTimeUtc { get { throw null; } }
        public System.DateTimeOffset TimeGenerated { get { throw null; } }
    }
    public partial class SecurityGroupEntity : Azure.ResourceManager.SecurityInsights.EntityData
    {
        public SecurityGroupEntity() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalData { get { throw null; } }
        public string DistinguishedName { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public System.Guid? ObjectGuid { get { throw null; } }
        public string Sid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityInsightsKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityInsightsKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind AnalyticsRule { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind AnalyticsRuleTemplate { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind AutomationRule { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind AzureFunction { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind DataConnector { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind DataType { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind HuntingQuery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind InvestigationQuery { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind LogicAppsCustomConnector { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind Parser { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind Playbook { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind PlaybookTemplate { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind Solution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind Watchlist { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind WatchlistTemplate { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind Workbook { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind WorkbookTemplate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind left, Azure.ResourceManager.SecurityInsights.Models.SecurityInsightsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityMLAnalyticsSettingsDataSource
    {
        public SecurityMLAnalyticsSettingsDataSource() { }
        public string ConnectorId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingsStatus : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SettingsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingsStatus(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SettingsStatus Flighting { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SettingsStatus Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SettingsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SettingsStatus left, Azure.ResourceManager.SecurityInsights.Models.SettingsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SettingsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SettingsStatus left, Azure.ResourceManager.SecurityInsights.Models.SettingsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SettingType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SettingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SettingType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SettingType CopyableLabel { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SettingType InfoMessage { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SettingType InstructionStepsGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SettingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SettingType left, Azure.ResourceManager.SecurityInsights.Models.SettingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SettingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SettingType left, Azure.ResourceManager.SecurityInsights.Models.SettingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceKind : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceKind(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceKind Community { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceKind LocalWorkspace { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceKind Solution { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceKind SourceRepository { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SourceKind left, Azure.ResourceManager.SecurityInsights.Models.SourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SourceKind left, Azure.ResourceManager.SecurityInsights.Models.SourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceType LocalFile { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SourceType RemoteStorage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SourceType left, Azure.ResourceManager.SecurityInsights.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SourceType left, Azure.ResourceManager.SecurityInsights.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubmissionMailEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public readonly partial struct SupportTier : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.SupportTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportTier(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.SupportTier Community { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SupportTier Microsoft { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.SupportTier Partner { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.SupportTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.SupportTier left, Azure.ResourceManager.SecurityInsights.Models.SupportTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.SupportTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.SupportTier left, Azure.ResourceManager.SecurityInsights.Models.SupportTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamInformation
    {
        public TeamInformation() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri PrimaryChannelUri { get { throw null; } }
        public System.DateTimeOffset? TeamCreationTimeUtc { get { throw null; } }
        public string TeamId { get { throw null; } }
    }
    public partial class TeamProperties
    {
        public TeamProperties(string teamName) { }
        public System.Collections.Generic.IList<System.Guid> GroupIds { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> MemberIds { get { throw null; } }
        public string TeamDescription { get { throw null; } set { } }
        public string TeamName { get { throw null; } }
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
    public partial class ThreatIntelligenceAlertRule : Azure.ResourceManager.SecurityInsights.SecurityInsightsAlertRuleData
    {
        public ThreatIntelligenceAlertRule() { }
        public string AlertRuleTemplateName { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public Azure.ResourceManager.SecurityInsights.Models.AlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityInsights.Models.AttackTactic> Tactics { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Techniques { get { throw null; } }
    }
    public partial class ThreatIntelligenceAlertRuleTemplate : Azure.ResourceManager.SecurityInsights.AlertRuleTemplateData
    {
        public ThreatIntelligenceAlertRuleTemplate() { }
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
        public Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum? SortOrder { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreatIntelligenceSortingCriteriaEnum : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreatIntelligenceSortingCriteriaEnum(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum Ascending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum Descending { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum Unsorted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum left, Azure.ResourceManager.SecurityInsights.Models.ThreatIntelligenceSortingCriteriaEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TICheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public TICheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class TIDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public TIDataConnector() { }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? IndicatorsState { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public System.DateTimeOffset? TipLookbackPeriod { get { throw null; } set { } }
    }
    public partial class TiTaxiiCheckRequirements : Azure.ResourceManager.SecurityInsights.Models.DataConnectorsCheckRequirements
    {
        public TiTaxiiCheckRequirements() { }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class TiTaxiiDataConnector : Azure.ResourceManager.SecurityInsights.DataConnectorData
    {
        public TiTaxiiDataConnector() { }
        public string CollectionId { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.PollingFrequency? PollingFrequency { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityInsights.Models.DataTypeState? TaxiiClientState { get { throw null; } set { } }
        public System.DateTimeOffset? TaxiiLookbackPeriod { get { throw null; } set { } }
        public string TaxiiServer { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
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
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersOn Alerts { get { throw null; } }
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
        public static Azure.ResourceManager.SecurityInsights.Models.TriggersWhen Updated { get { throw null; } }
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
    public partial class Ueba : Azure.ResourceManager.SecurityInsights.SettingData
    {
        public Ueba() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityInsights.Models.UebaDataSource> DataSources { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UebaDataSource : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.UebaDataSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UebaDataSource(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.UebaDataSource AuditLogs { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.UebaDataSource AzureActivity { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.UebaDataSource SecurityEvent { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.UebaDataSource SigninLogs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.UebaDataSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.UebaDataSource left, Azure.ResourceManager.SecurityInsights.Models.UebaDataSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.UebaDataSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.UebaDataSource left, Azure.ResourceManager.SecurityInsights.Models.UebaDataSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UrlEntity : Azure.ResourceManager.SecurityInsights.EntityData
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
    public partial class ValidationError
    {
        internal ValidationError() { }
        public System.Collections.Generic.IReadOnlyList<string> ErrorMessages { get { throw null; } }
        public int? RecordIndex { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Version : System.IEquatable<Azure.ResourceManager.SecurityInsights.Models.Version>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Version(string value) { throw null; }
        public static Azure.ResourceManager.SecurityInsights.Models.Version V1 { get { throw null; } }
        public static Azure.ResourceManager.SecurityInsights.Models.Version V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityInsights.Models.Version other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityInsights.Models.Version left, Azure.ResourceManager.SecurityInsights.Models.Version right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityInsights.Models.Version (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityInsights.Models.Version left, Azure.ResourceManager.SecurityInsights.Models.Version right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Webhook
    {
        public Webhook() { }
        public bool? RotateWebhookSecret { get { throw null; } set { } }
        public string WebhookId { get { throw null; } set { } }
        public string WebhookSecretUpdateTime { get { throw null; } set { } }
        public System.Uri WebhookUri { get { throw null; } set { } }
    }
}
