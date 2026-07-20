namespace Azure.ResourceManager.Authorization
{
    public partial class AccessReviewDecisionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>, System.Collections.IEnumerable
    {
        protected AccessReviewDecisionCollection() { }
        public virtual Azure.Response<bool> Exists(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> Get(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>> GetAsync(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetIfExists(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>> GetIfExistsAsync(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessReviewDecisionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>
    {
        internal AccessReviewDecisionData() { }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity AppliedBy { get { throw null; } }
        public System.DateTimeOffset? AppliedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult? ApplyResult { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewResult? Decision { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight> Insights { get { throw null; } }
        public string Justification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType> MembershipTypes { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity Principal { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessRecommendationType? Recommendation { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource Resource { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity ReviewedBy { get { throw null; } }
        public System.DateTimeOffset? ReviewedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewDecisionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewDecisionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewDecisionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDecisionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scheduleDefinitionId, string id, string decisionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewDecisionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewDecisionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDecisionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> Update(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>> UpdateAsync(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessReviewDefaultSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewDefaultSettingResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDefaultSettingsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>
    {
        internal AccessReviewDefaultSettingsData() { }
        public bool? AutoApplyDecisionsEnabled { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.DefaultDecisionType? DefaultDecision { get { throw null; } }
        public bool? DefaultDecisionEnabled { get { throw null; } }
        public int? InstanceDurationInDays { get { throw null; } }
        public bool? JustificationRequiredOnApproval { get { throw null; } }
        public bool? MailNotificationsEnabled { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } }
        public System.TimeSpan? RecommendationLookBackDuration { get { throw null; } }
        public bool? RecommendationsEnabled { get { throw null; } }
        public bool? ReminderNotificationsEnabled { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewHistoryDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>, System.Collections.IEnumerable
    {
        protected AccessReviewHistoryDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string historyDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string historyDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> Get(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> GetAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> GetIfExists(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> GetIfExistsAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessReviewHistoryDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>
    {
        internal AccessReviewHistoryDefinitionData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewResult> Decisions { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? PrincipalType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } }
        public System.DateTimeOffset? ReviewHistoryPeriodEndOn { get { throw null; } }
        public System.DateTimeOffset? ReviewHistoryPeriodStartOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewScope> Scopes { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? Status { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewHistoryDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewHistoryDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string historyDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GenerateDownloadUri(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>> GenerateDownloadUriAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessReviewInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>, System.Collections.IEnumerable
    {
        protected AccessReviewInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessReviewInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>
    {
        public AccessReviewInstanceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> BackupReviewers { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> Reviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType? ReviewersType { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ApplyDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplyDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string scheduleDefinitionId, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendReminders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendRemindersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AccessReviewInstancesAssignedForMyApprovalCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>, System.Collections.IEnumerable
    {
        protected AccessReviewInstancesAssignedForMyApprovalCollection() { }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessReviewInstancesAssignedForMyApprovalResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewInstancesAssignedForMyApprovalResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response AcceptRecommendations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcceptRecommendationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scheduleDefinitionId, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAccessReviewDecision(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewDecisionResource>> GetAccessReviewDecisionAsync(string decisionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDecisionCollection GetAccessReviewDecisions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewScheduleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>, System.Collections.IEnumerable
    {
        protected AccessReviewScheduleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> Get(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> GetAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> GetIfExists(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> GetIfExistsAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessReviewScheduleDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>
    {
        internal AccessReviewScheduleDefinitionData() { }
        public bool? AutoApplyDecisionsEnabled { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> BackupReviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.DefaultDecisionType? DefaultDecision { get { throw null; } }
        public bool? DefaultDecisionEnabled { get { throw null; } }
        public string DescriptionForAdmins { get { throw null; } }
        public string DescriptionForReviewers { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public int? InstanceDurationInDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.AccessReviewInstanceData> Instances { get { throw null; } }
        public bool? JustificationRequiredOnApproval { get { throw null; } }
        public bool? MailNotificationsEnabled { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? PrincipalType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } }
        public System.TimeSpan? RecommendationLookBackDuration { get { throw null; } }
        public bool? RecommendationsEnabled { get { throw null; } }
        public bool? ReminderNotificationsEnabled { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> Reviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType? ReviewersType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScope Scope { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus? Status { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewScheduleDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessReviewScheduleDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string scheduleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource> GetAccessReviewInstance(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstanceResource>> GetAccessReviewInstanceAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstanceCollection GetAccessReviewInstances() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertResource>, System.Collections.IEnumerable
    {
        protected AlertCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AlertResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AlertResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertResource> GetIfExists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertResource>> GetIfExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AlertResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AlertResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertConfigurationResource>, System.Collections.IEnumerable
    {
        protected AlertConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource> Get(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AlertConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AlertConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource>> GetAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertConfigurationResource> GetIfExists(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertConfigurationResource>> GetIfExistsAsync(string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AlertConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AlertConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>
    {
        public AlertConfigurationData() { }
        public Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AlertConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertConfigurationResource() { }
        public virtual Azure.ResourceManager.Authorization.AlertConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AlertConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.Authorization.AlertConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.Authorization.AlertConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>
    {
        public AlertData() { }
        public Azure.ResourceManager.Authorization.AlertConfigurationData AlertConfiguration { get { throw null; } }
        public Azure.ResourceManager.Authorization.AlertDefinitionData AlertDefinition { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.AlertIncidentData> AlertIncidents { get { throw null; } }
        public int? IncidentCount { get { throw null; } }
        public bool? IsActive { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastScannedOn { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertDefinitionResource>, System.Collections.IEnumerable
    {
        protected AlertDefinitionCollection() { }
        public virtual Azure.Response<bool> Exists(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource> Get(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AlertDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AlertDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource>> GetAsync(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertDefinitionResource> GetIfExists(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertDefinitionResource>> GetIfExistsAsync(string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AlertDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AlertDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>
    {
        internal AlertDefinitionData() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string HowToPrevent { get { throw null; } }
        public bool? IsConfigurable { get { throw null; } }
        public bool? IsRemediatable { get { throw null; } }
        public string MitigationSteps { get { throw null; } }
        public string Scope { get { throw null; } }
        public string SecurityImpact { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.SeverityLevel? SeverityLevel { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AlertDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AlertDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertDefinitionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AlertDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertIncidentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertIncidentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertIncidentResource>, System.Collections.IEnumerable
    {
        protected AlertIncidentCollection() { }
        public virtual Azure.Response<bool> Exists(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource> Get(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AlertIncidentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AlertIncidentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetAsync(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertIncidentResource> GetIfExists(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetIfExistsAsync(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AlertIncidentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AlertIncidentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AlertIncidentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertIncidentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertIncidentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>
    {
        internal AlertIncidentData() { }
        public Azure.ResourceManager.Authorization.Models.AlertIncidentProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AlertIncidentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertIncidentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertIncidentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertIncidentResource() { }
        public virtual Azure.ResourceManager.Authorization.AlertIncidentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId, string alertIncidentId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Remediate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemediateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AlertIncidentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertIncidentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertIncidentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertResource() { }
        public virtual Azure.ResourceManager.Authorization.AlertData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string alertId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource> GetAlertIncident(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetAlertIncidentAsync(string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertIncidentCollection GetAlertIncidents() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult> Refresh(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult>> RefreshAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AlertData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AlertData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AlertData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AlertData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.Authorization.AlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.Authorization.AlertData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttributeNamespaceCollection : Azure.ResourceManager.ArmCollection
    {
        protected AttributeNamespaceCollection() { }
        public virtual Azure.Response<bool> Exists(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource> Get(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> GetAsync(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AttributeNamespaceResource> GetIfExists(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> GetIfExistsAsync(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AttributeNamespaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>
    {
        internal AttributeNamespaceData() { }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AttributeNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AttributeNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttributeNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttributeNamespaceResource() { }
        public virtual Azure.ResourceManager.Authorization.AttributeNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource> Create(Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> CreateAsync(Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string attributeNamespace) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AttributeNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AttributeNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AttributeNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AuthorizationExtensions
    {
        public static Azure.Response ElevateAccessGlobalAdministrator(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ElevateAccessGlobalAdministratorAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewDecisionResource GetAccessReviewDecisionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource GetAccessReviewDefaultSetting(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource GetAccessReviewDefaultSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> GetAccessReviewHistoryDefinition(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> GetAccessReviewHistoryDefinitionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource GetAccessReviewHistoryDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionCollection GetAccessReviewHistoryDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewInstanceResource GetAccessReviewInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> GetAccessReviewInstancesAssignedForMyApproval(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scheduleDefinitionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>> GetAccessReviewInstancesAssignedForMyApprovalAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scheduleDefinitionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource GetAccessReviewInstancesAssignedForMyApprovalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalCollection GetAccessReviewInstancesAssignedForMyApprovals(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scheduleDefinitionId) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> GetAccessReviewScheduleDefinition(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> GetAccessReviewScheduleDefinitionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource GetAccessReviewScheduleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionCollection GetAccessReviewScheduleDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AlertResource> GetAlert(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertResource>> GetAlertAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource> GetAlertConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource>> GetAlertConfigurationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertConfigurationResource GetAlertConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertConfigurationCollection GetAlertConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource> GetAlertDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource>> GetAlertDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertDefinitionResource GetAlertDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertDefinitionCollection GetAlertDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource> GetAlertIncident(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetAlertIncidentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertIncidentResource GetAlertIncidentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertIncidentCollection GetAlertIncidents(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.Models.AlertOperationResult> GetAlertOperation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.Models.AlertOperationResult>> GetAlertOperationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertResource GetAlertResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertCollection GetAlerts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataCollection GetAllAuthorizationProviderOperationsMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource> GetAttributeNamespace(this Azure.ResourceManager.Resources.TenantResource tenantResource, string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> GetAttributeNamespaceAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AttributeNamespaceResource GetAttributeNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AttributeNamespaceCollection GetAttributeNamespaces(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAuthorizationProviderOperationsMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAuthorizationProviderOperationsMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource GetAuthorizationProviderOperationsMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinition(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(this Azure.ResourceManager.ArmResource armResource, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinitionAsync(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(this Azure.ResourceManager.ArmResource armResource, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource GetAuthorizationRoleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroupsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministrators(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministratorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(this Azure.ResourceManager.ArmResource armResource, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentResource GetDenyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResourcesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentResource GetRoleAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource GetRoleAssignmentScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource GetRoleAssignmentScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource GetRoleAssignmentScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource GetRoleEligibilityScheduleInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(this Azure.ResourceManager.ArmResource armResource, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource GetRoleEligibilityScheduleRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource GetRoleEligibilityScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource GetRoleManagementPolicyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(this Azure.ResourceManager.ArmResource armResource) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(this Azure.ResourceManager.ArmResource armResource, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyResource GetRoleManagementPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource GetScopeAccessReviewDefaultSetting(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource GetScopeAccessReviewDefaultSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> GetScopeAccessReviewHistoryDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> GetScopeAccessReviewHistoryDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource GetScopeAccessReviewHistoryDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionCollection GetScopeAccessReviewHistoryDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetScopeAccessReviewInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetScopeAccessReviewInstanceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource GetScopeAccessReviewInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceCollection GetScopeAccessReviewInstances(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> GetScopeAccessReviewScheduleDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> GetScopeAccessReviewScheduleDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource GetScopeAccessReviewScheduleDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionCollection GetScopeAccessReviewScheduleDefinitions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult> RefreshAll(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult>> RefreshAllAsync(this Azure.ResourceManager.ArmClient client, Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>, System.Collections.IEnumerable
    {
        protected AuthorizationProviderOperationsMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> Get(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetIfExists(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetIfExistsAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>
    {
        internal AuthorizationProviderOperationsMetadataData() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> Operations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderOperationsMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationProviderOperationsMetadataResource() { }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceProviderNamespace) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationRoleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>, System.Collections.IEnumerable
    {
        protected AuthorizationRoleDefinitionCollection() { }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use CreateOrUpdate(WaitUntil waitUntil, string roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default) instead.")]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use CreateOrUpdateAsync(WaitUntil waitUntil, string roleDefinitionId, AuthorizationRoleDefinitionData data, CancellationToken cancellationToken = default) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleDefinitionId, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use Exists(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Azure.Response<bool> Exists(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use ExistsAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use Get(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Get(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Get(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetIfExists(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetIfExists(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetIfExists(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetIfExistsAsync(string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetIfExistsAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetIfExistsAsync(string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationRoleDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>
    {
        public AuthorizationRoleDefinitionData() { }
        public System.Collections.Generic.IList<string> AssignableScopes { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> Permissions { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } set { } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationRoleDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationRoleDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use CreateResourceIdentifier(string scope, string roleDefinitionId) instead.")]
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, Azure.Core.ResourceIdentifier roleDefinitionId) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAuthorizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAuthorizationContext() { }
        public static Azure.ResourceManager.Authorization.AzureResourceManagerAuthorizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DenyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>, System.Collections.IEnumerable
    {
        protected DenyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.DenyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string denyAssignmentId, Azure.ResourceManager.Authorization.DenyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.DenyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string denyAssignmentId, Azure.ResourceManager.Authorization.DenyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> Get(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetIfExists(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetIfExistsAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.DenyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.DenyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.DenyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DenyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>
    {
        public DenyAssignmentData() { }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect? DenyAssignmentEffect { get { throw null; } set { } }
        public string DenyAssignmentName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> ExcludePrincipals { get { throw null; } }
        public bool? IsAppliedToChildScopes { get { throw null; } set { } }
        public bool? IsSystemProtected { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission> Permissions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> Principals { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenyAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DenyAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string denyAssignmentId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.DenyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.DenyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.DenyAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.DenyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.DenyAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.DenyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentName, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAll(string filter = null, string tenantId = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetAllAsync(string filter = null, string tenantId = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetIfExists(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetIfExistsAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>
    {
        internal RoleAssignmentData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DelegatedManagedIdentityResourceId { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> Get(string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetAsync(string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> Get(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetIfExists(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetIfExistsAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>
    {
        internal RoleAssignmentScheduleData() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleRequestId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> Get(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetIfExists(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetIfExistsAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>
    {
        internal RoleAssignmentScheduleInstanceData() { }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? AssignmentType { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleInstanceId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public Azure.Core.ResourceIdentifier OriginRoleAssignmentId { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleAssignmentScheduleId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentScheduleRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleAssignmentScheduleRequestName, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleAssignmentScheduleRequestName, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Get(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetIfExists(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetIfExistsAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>
    {
        public RoleAssignmentScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? ExpirationType { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LinkedRoleEligibilityScheduleId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public System.Guid? RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetRoleAssignmentScheduleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetRoleAssignmentScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo TicketInfo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentScheduleRequestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleRequestResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleRequestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> Validate(Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> ValidateAsync(Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentScheduleResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleAssignmentScheduleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleAssignmentScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleAssignmentScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleCollection() { }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> Get(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetIfExists(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetIfExistsAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>
    {
        internal RoleEligibilityScheduleData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleRequestId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> Get(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetIfExists(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetIfExistsAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>
    {
        internal RoleEligibilityScheduleInstanceData() { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? MemberType { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleEligibilityScheduleId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>, System.Collections.IEnumerable
    {
        protected RoleEligibilityScheduleRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleEligibilityScheduleRequestName, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleEligibilityScheduleRequestName, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Get(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetIfExists(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetIfExistsAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>
    {
        public RoleEligibilityScheduleRequestData() { }
        public string ApprovalId { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties ExpandedProperties { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? ExpirationType { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public System.Guid? RequestorId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? RequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetRoleEligibilityScheduleId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetRoleEligibilityScheduleInstanceId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo TicketInfo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleRequestResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleRequestName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> Validate(Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> ValidateAsync(Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleEligibilityScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleEligibilityScheduleResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleEligibilityScheduleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleEligibilityScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleEligibilityScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>, System.Collections.IEnumerable
    {
        protected RoleManagementPolicyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string roleManagementPolicyAssignmentName, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string roleManagementPolicyAssignmentName, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Get(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetIfExists(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetIfExistsAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>
    {
        public RoleManagementPolicyAssignmentData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyAssignmentName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleManagementPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>, System.Collections.IEnumerable
    {
        protected RoleManagementPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Get(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetIfExists(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetIfExistsAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleManagementPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>
    {
        public RoleManagementPolicyData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> EffectiveRules { get { throw null; } }
        public bool? IsOrganizationDefault { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties PolicyProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> Rules { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleManagementPolicyResource() { }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string roleManagementPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.RoleManagementPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.RoleManagementPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> Update(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> UpdateAsync(Azure.ResourceManager.Authorization.RoleManagementPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeAccessReviewDefaultSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeAccessReviewDefaultSettingResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeAccessReviewHistoryDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>, System.Collections.IEnumerable
    {
        protected ScopeAccessReviewHistoryDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string historyDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string historyDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> Get(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> GetAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> GetIfExists(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> GetIfExistsAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeAccessReviewHistoryDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeAccessReviewHistoryDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string historyDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GenerateDownloadUri(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>> GenerateDownloadUriAsync(string instanceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeAccessReviewInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>, System.Collections.IEnumerable
    {
        protected ScopeAccessReviewInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string id, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetIfExists(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetIfExistsAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeAccessReviewInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeAccessReviewInstanceResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ApplyDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplyDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string scheduleDefinitionId, string id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewDecisionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RecordAllDecisions(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RecordAllDecisionsAsync(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendReminders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendRemindersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeAccessReviewScheduleDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>, System.Collections.IEnumerable
    {
        protected ScopeAccessReviewScheduleDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleDefinitionId, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> Get(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> GetAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> GetIfExists(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> GetIfExistsAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeAccessReviewScheduleDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeAccessReviewScheduleDefinitionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string scheduleDefinitionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetScopeAccessReviewInstance(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetScopeAccessReviewInstanceAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceCollection GetScopeAccessReviewInstances() { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Authorization.Mocking
{
    public partial class MockableAuthorizationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationArmClient() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDecisionResource GetAccessReviewDecisionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource GetAccessReviewDefaultSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource GetAccessReviewHistoryDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstanceResource GetAccessReviewInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource GetAccessReviewInstancesAssignedForMyApprovalResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource GetAccessReviewScheduleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertResource> GetAlert(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertResource>> GetAlertAsync(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource> GetAlertConfiguration(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertConfigurationResource>> GetAlertConfigurationAsync(Azure.Core.ResourceIdentifier scope, string alertId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertConfigurationResource GetAlertConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertConfigurationCollection GetAlertConfigurations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource> GetAlertDefinition(Azure.Core.ResourceIdentifier scope, string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertDefinitionResource>> GetAlertDefinitionAsync(Azure.Core.ResourceIdentifier scope, string alertDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertDefinitionResource GetAlertDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertDefinitionCollection GetAlertDefinitions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource> GetAlertIncident(Azure.Core.ResourceIdentifier scope, string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AlertIncidentResource>> GetAlertIncidentAsync(Azure.Core.ResourceIdentifier scope, string alertIncidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertIncidentResource GetAlertIncidentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertIncidentCollection GetAlertIncidents(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.Models.AlertOperationResult> GetAlertOperation(Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.Models.AlertOperationResult>> GetAlertOperationAsync(Azure.Core.ResourceIdentifier scope, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertResource GetAlertResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AlertCollection GetAlerts(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AttributeNamespaceResource GetAttributeNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource GetAuthorizationProviderOperationsMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinition(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(Azure.Core.ResourceIdentifier scope, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("this method is deprecated and will be removed in a future version, please use GetAuthorizationRoleDefinitionAsync(ResourceIdentifier scope, string roleDefinitionId, CancellationToken cancellationToken = default) instead.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(Azure.Core.ResourceIdentifier scope, string roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource GetAuthorizationRoleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResource(Azure.Core.ResourceIdentifier scope, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceAsync(Azure.Core.ResourceIdentifier scope, string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentResource GetDenyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResources(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.EligibleChildResource> GetEligibleChildResourcesAsync(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentResource GetRoleAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource GetRoleAssignmentScheduleInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(Azure.Core.ResourceIdentifier scope, string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource GetRoleAssignmentScheduleRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource GetRoleAssignmentScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource GetRoleEligibilityScheduleInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(Azure.Core.ResourceIdentifier scope, string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource GetRoleEligibilityScheduleRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource GetRoleEligibilityScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource GetRoleManagementPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(Azure.Core.ResourceIdentifier scope, string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyResource GetRoleManagementPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource GetScopeAccessReviewDefaultSetting(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewDefaultSettingResource GetScopeAccessReviewDefaultSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource> GetScopeAccessReviewHistoryDefinition(Azure.Core.ResourceIdentifier scope, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource>> GetScopeAccessReviewHistoryDefinitionAsync(Azure.Core.ResourceIdentifier scope, string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionResource GetScopeAccessReviewHistoryDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewHistoryDefinitionCollection GetScopeAccessReviewHistoryDefinitions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource> GetScopeAccessReviewInstance(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource>> GetScopeAccessReviewInstanceAsync(Azure.Core.ResourceIdentifier scope, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceResource GetScopeAccessReviewInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewInstanceCollection GetScopeAccessReviewInstances(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource> GetScopeAccessReviewScheduleDefinition(Azure.Core.ResourceIdentifier scope, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource>> GetScopeAccessReviewScheduleDefinitionAsync(Azure.Core.ResourceIdentifier scope, string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionResource GetScopeAccessReviewScheduleDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Authorization.ScopeAccessReviewScheduleDefinitionCollection GetScopeAccessReviewScheduleDefinitions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult> RefreshAll(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Authorization.Models.AlertOperationResult>> RefreshAllAsync(Azure.WaitUntil waitUntil, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationArmResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationArmResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource> GetAuthorizationRoleDefinition(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionResource>> GetAuthorizationRoleDefinitionAsync(Azure.Core.ResourceIdentifier roleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionCollection GetAuthorizationRoleDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource> GetDenyAssignment(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.DenyAssignmentResource>> GetDenyAssignmentAsync(string denyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.DenyAssignmentCollection GetDenyAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource> GetRoleAssignment(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentResource>> GetRoleAssignmentAsync(string roleAssignmentName, string tenantId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentCollection GetRoleAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource> GetRoleAssignmentSchedule(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleResource>> GetRoleAssignmentScheduleAsync(string roleAssignmentScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource> GetRoleAssignmentScheduleInstance(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceResource>> GetRoleAssignmentScheduleInstanceAsync(string roleAssignmentScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceCollection GetRoleAssignmentScheduleInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource> GetRoleAssignmentScheduleRequest(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestResource>> GetRoleAssignmentScheduleRequestAsync(string roleAssignmentScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestCollection GetRoleAssignmentScheduleRequests() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleAssignmentScheduleCollection GetRoleAssignmentSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource> GetRoleEligibilitySchedule(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleResource>> GetRoleEligibilityScheduleAsync(string roleEligibilityScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource> GetRoleEligibilityScheduleInstance(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceResource>> GetRoleEligibilityScheduleInstanceAsync(string roleEligibilityScheduleInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceCollection GetRoleEligibilityScheduleInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource> GetRoleEligibilityScheduleRequest(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestResource>> GetRoleEligibilityScheduleRequestAsync(string roleEligibilityScheduleRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestCollection GetRoleEligibilityScheduleRequests() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleEligibilityScheduleCollection GetRoleEligibilitySchedules() { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyCollection GetRoleManagementPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource> GetRoleManagementPolicy(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource> GetRoleManagementPolicyAssignment(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentResource>> GetRoleManagementPolicyAssignmentAsync(string roleManagementPolicyAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentCollection GetRoleManagementPolicyAssignments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.RoleManagementPolicyResource>> GetRoleManagementPolicyAsync(string roleManagementPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourceGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResources(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> GetAzurePermissionsForResourcesAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationSubscriptionResource() { }
        public virtual Azure.ResourceManager.Authorization.AccessReviewDefaultSettingResource GetAccessReviewDefaultSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource> GetAccessReviewHistoryDefinition(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionResource>> GetAccessReviewHistoryDefinitionAsync(string historyDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionCollection GetAccessReviewHistoryDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource> GetAccessReviewScheduleDefinition(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionResource>> GetAccessReviewScheduleDefinitionAsync(string scheduleDefinitionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionCollection GetAccessReviewScheduleDefinitions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministrators(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator> GetClassicAdministratorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAuthorizationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAuthorizationTenantResource() { }
        public virtual Azure.Response ElevateAccessGlobalAdministrator(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ElevateAccessGlobalAdministratorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource> GetAccessReviewInstancesAssignedForMyApproval(string scheduleDefinitionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalResource>> GetAccessReviewInstancesAssignedForMyApprovalAsync(string scheduleDefinitionId, string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AccessReviewInstancesAssignedForMyApprovalCollection GetAccessReviewInstancesAssignedForMyApprovals(string scheduleDefinitionId) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataCollection GetAllAuthorizationProviderOperationsMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource> GetAttributeNamespace(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AttributeNamespaceResource>> GetAttributeNamespaceAsync(string attributeNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Authorization.AttributeNamespaceCollection GetAttributeNamespaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource> GetAuthorizationProviderOperationsMetadata(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataResource>> GetAuthorizationProviderOperationsMetadataAsync(string resourceProviderNamespace, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Authorization.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessRecommendationType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessRecommendationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessRecommendationType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessRecommendationType Approve { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessRecommendationType Deny { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessRecommendationType NoInfoAvailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessRecommendationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessRecommendationType left, Azure.ResourceManager.Authorization.Models.AccessRecommendationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessRecommendationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessRecommendationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessRecommendationType left, Azure.ResourceManager.Authorization.Models.AccessRecommendationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewActorIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>
    {
        internal AccessReviewActorIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? PrincipalType { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewActorIdentityType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewActorIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType left, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType left, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewApplyResult : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewApplyResult(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult AppliedSuccessfully { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult AppliedSuccessfullyButObjectNotFound { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult AppliedWithUnknownFailure { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult Applying { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult ApplyNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult left, Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult left, Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewContactedReviewer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>
    {
        internal AccessReviewContactedReviewer() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public string UserDisplayName { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AccessReviewDecisionIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>
    {
        internal AccessReviewDecisionIdentity() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionInsight : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>
    {
        public AccessReviewDecisionInsight() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties Properties { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AccessReviewDecisionInsightProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>
    {
        internal AccessReviewDecisionInsightProperties() { }
        public System.DateTimeOffset? InsightCreatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>
    {
        public AccessReviewDecisionPatch() { }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity AppliedBy { get { throw null; } }
        public System.DateTimeOffset? AppliedOn { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult? ApplyResult { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewResult? Decision { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight> Insights { get { throw null; } }
        public string Justification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType> MembershipTypes { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity Principal { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessRecommendationType? Recommendation { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource Resource { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity ReviewedBy { get { throw null; } }
        public System.DateTimeOffset? ReviewedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewDecisionPrincipalResourceMembershipType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewDecisionPrincipalResourceMembershipType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType Direct { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType Indirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType left, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType left, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewDecisionResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>
    {
        internal AccessReviewDecisionResource() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.DecisionResourceType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionServicePrincipalIdentity : Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>
    {
        internal AccessReviewDecisionServicePrincipalIdentity() { }
        public string AppId { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionUserIdentity : Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>
    {
        internal AccessReviewDecisionUserIdentity() { }
        public string UserPrincipalName { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewDecisionUserSignInInsightProperties : Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>
    {
        public AccessReviewDecisionUserSignInInsightProperties() { }
        public System.DateTimeOffset? LastSignInOn { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewHistoryDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>
    {
        public AccessReviewHistoryDefinitionProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewResult> Decisions { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? PrincipalType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewHistoryPeriodEndOn { get { throw null; } }
        public System.DateTimeOffset? ReviewHistoryPeriodStartOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewScope> Scopes { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? Status { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewHistoryDefinitionStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewHistoryDefinitionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus Done { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus Error { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus Requested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewHistoryInstance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>
    {
        public AccessReviewHistoryInstance() { }
        public string DisplayName { get { throw null; } set { } }
        public string DownloadUri { get { throw null; } }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public System.DateTimeOffset? FulfilledOn { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? ReviewHistoryPeriodEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? ReviewHistoryPeriodStartOn { get { throw null; } set { } }
        public System.DateTimeOffset? RunOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? Status { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>
    {
        public AccessReviewInstanceProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> BackupReviewers { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> Reviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType? ReviewersType { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewInstanceReviewersType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewInstanceReviewersType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType Assigned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType Managers { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType Self { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType left, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType left, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewInstanceStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewInstanceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Applied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Applying { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus AutoReviewed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus AutoReviewing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Completing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus Starting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewRecurrencePattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>
    {
        public AccessReviewRecurrencePattern() { }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewRecurrencePatternType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewRecurrencePatternType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType AbsoluteMonthly { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType left, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType left, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewRecurrenceRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>
    {
        public AccessReviewRecurrenceRange() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public int? NumberOfOccurrences { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewRecurrenceRangeType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewRecurrenceRangeType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType EndDate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType NoEnd { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType Numbered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType left, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType left, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewResult : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewResult(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewResult Approve { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewResult Deny { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewResult DontKnow { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewResult NotNotified { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewResult NotReviewed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewResult left, Azure.ResourceManager.Authorization.Models.AccessReviewResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewResult left, Azure.ResourceManager.Authorization.Models.AccessReviewResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewReviewer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>
    {
        public AccessReviewReviewer() { }
        public string PrincipalId { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType? PrincipalType { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewReviewer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewReviewer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewReviewer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewReviewer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewReviewerType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewReviewerType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType left, Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType left, Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewScheduleDefinitionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>
    {
        public AccessReviewScheduleDefinitionProperties() { }
        public bool? AutoApplyDecisionsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> BackupReviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.DefaultDecisionType? DefaultDecision { get { throw null; } set { } }
        public bool? DefaultDecisionEnabled { get { throw null; } set { } }
        public string DescriptionForAdmins { get { throw null; } set { } }
        public string DescriptionForReviewers { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public int? InstanceDurationInDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.AccessReviewInstanceData> Instances { get { throw null; } }
        public bool? JustificationRequiredOnApproval { get { throw null; } set { } }
        public bool? MailNotificationsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? PrincipalType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } set { } }
        public System.TimeSpan? RecommendationLookBackDuration { get { throw null; } set { } }
        public bool? RecommendationsEnabled { get { throw null; } set { } }
        public bool? ReminderNotificationsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> Reviewers { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType? ReviewersType { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScope Scope { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus? Status { get { throw null; } }
        public string UserPrincipalName { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewScheduleDefinitionReviewersType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewScheduleDefinitionReviewersType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType Assigned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType Managers { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType Self { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType left, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType left, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewScheduleDefinitionStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewScheduleDefinitionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Applied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Applying { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus AutoReviewed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus AutoReviewing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Completing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus Starting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus left, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessReviewScheduleSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>
    {
        public AccessReviewScheduleSettings() { }
        public bool? AutoApplyDecisionsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.DefaultDecisionType? DefaultDecision { get { throw null; } set { } }
        public bool? DefaultDecisionEnabled { get { throw null; } set { } }
        public int? InstanceDurationInDays { get { throw null; } set { } }
        public bool? JustificationRequiredOnApproval { get { throw null; } set { } }
        public bool? MailNotificationsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern Pattern { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange Range { get { throw null; } set { } }
        public System.TimeSpan? RecommendationLookBackDuration { get { throw null; } set { } }
        public bool? RecommendationsEnabled { get { throw null; } set { } }
        public bool? ReminderNotificationsEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessReviewScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>
    {
        public AccessReviewScope() { }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState? AssignmentState { get { throw null; } }
        public string ExcludeResourceId { get { throw null; } set { } }
        public string ExcludeRoleDefinitionId { get { throw null; } set { } }
        public bool? ExpandNestedMemberships { get { throw null; } set { } }
        public System.TimeSpan? InactiveDuration { get { throw null; } set { } }
        public bool? IncludeAccessBelowResource { get { throw null; } set { } }
        public bool? IncludeInheritedAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType? PrincipalType { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AccessReviewScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AccessReviewScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AccessReviewScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AccessReviewScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewScopeAssignmentState : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewScopeAssignmentState(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState Active { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState Eligible { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState left, Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState left, Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessReviewScopePrincipalType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessReviewScopePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType GuestUser { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType RedeemedGuestUser { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType User { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType UserGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType left, Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType left, Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AlertConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>
    {
        internal AlertConfigurationProperties() { }
        public Azure.ResourceManager.Authorization.AlertDefinitionData AlertDefinition { get { throw null; } }
        public string AlertDefinitionId { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AlertIncidentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>
    {
        internal AlertIncidentProperties() { }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertIncidentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertIncidentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AlertIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AlertIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlertOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>
    {
        internal AlertOperationResult() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActionOn { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusDetail { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AlertOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AlertOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AlertOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AlertOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAuthorizationModelFactory
    {
        public static Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity AccessReviewActorIdentity(string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType?), string principalName = null, string userPrincipalName = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewContactedReviewer AccessReviewContactedReviewer(string id = null, string name = null, string type = null, string userDisplayName = null, string userPrincipalName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewDecisionData AccessReviewDecisionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity principal = null, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource resource = null, Azure.ResourceManager.Authorization.Models.AccessRecommendationType? recommendation = default(Azure.ResourceManager.Authorization.Models.AccessRecommendationType?), Azure.ResourceManager.Authorization.Models.AccessReviewResult? decision = default(Azure.ResourceManager.Authorization.Models.AccessReviewResult?), string justification = null, System.DateTimeOffset? reviewedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity reviewedBy = null, Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult? applyResult = default(Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult?), System.DateTimeOffset? appliedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity appliedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight> insights = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType> membershipTypes = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity AccessReviewDecisionIdentity(string type = null, string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight AccessReviewDecisionInsight(string id = null, string name = null, string type = null, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsightProperties AccessReviewDecisionInsightProperties(string type = null, System.DateTimeOffset? insightCreatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPatch AccessReviewDecisionPatch(Azure.ResourceManager.Authorization.Models.AccessReviewDecisionIdentity principal = null, Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource resource = null, Azure.ResourceManager.Authorization.Models.AccessRecommendationType? recommendation = default(Azure.ResourceManager.Authorization.Models.AccessRecommendationType?), Azure.ResourceManager.Authorization.Models.AccessReviewResult? decision = default(Azure.ResourceManager.Authorization.Models.AccessReviewResult?), string justification = null, System.DateTimeOffset? reviewedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity reviewedBy = null, Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult? applyResult = default(Azure.ResourceManager.Authorization.Models.AccessReviewApplyResult?), System.DateTimeOffset? appliedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentity appliedBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionInsight> insights = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewDecisionPrincipalResourceMembershipType> membershipTypes = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionResource AccessReviewDecisionResource(Azure.ResourceManager.Authorization.Models.DecisionResourceType type = default(Azure.ResourceManager.Authorization.Models.DecisionResourceType), string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionServicePrincipalIdentity AccessReviewDecisionServicePrincipalIdentity(string id = null, string displayName = null, string appId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserIdentity AccessReviewDecisionUserIdentity(string id = null, string displayName = null, string userPrincipalName = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewDecisionUserSignInInsightProperties AccessReviewDecisionUserSignInInsightProperties(System.DateTimeOffset? insightCreatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSignInOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewDefaultSettingsData AccessReviewDefaultSettingsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? mailNotificationsEnabled = default(bool?), bool? reminderNotificationsEnabled = default(bool?), bool? defaultDecisionEnabled = default(bool?), bool? justificationRequiredOnApproval = default(bool?), Azure.ResourceManager.Authorization.Models.DefaultDecisionType? defaultDecision = default(Azure.ResourceManager.Authorization.Models.DefaultDecisionType?), bool? autoApplyDecisionsEnabled = default(bool?), bool? recommendationsEnabled = default(bool?), System.TimeSpan? recommendationLookBackDuration = default(System.TimeSpan?), int? instanceDurationInDays = default(int?), Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewHistoryDefinitionData AccessReviewHistoryDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.DateTimeOffset? reviewHistoryPeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reviewHistoryPeriodEndOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewResult> decisions = null, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewScope> scopes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> instances = null, string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType?), string principalName = null, string userPrincipalName = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionProperties AccessReviewHistoryDefinitionProperties(string displayName = null, System.DateTimeOffset? reviewHistoryPeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reviewHistoryPeriodEndOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewResult> decisions = null, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType?), string principalName = null, string userPrincipalName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewScope> scopes = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance> instances = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewHistoryInstance AccessReviewHistoryInstance(string id = null, string name = null, string type = null, System.DateTimeOffset? reviewHistoryPeriodStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? reviewHistoryPeriodEndOn = default(System.DateTimeOffset?), string displayName = null, Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewHistoryDefinitionStatus?), System.DateTimeOffset? runOn = default(System.DateTimeOffset?), System.DateTimeOffset? fulfilledOn = default(System.DateTimeOffset?), string downloadUri = null, System.DateTimeOffset? expiration = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewInstanceData AccessReviewInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> reviewers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> backupReviewers = null, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType? reviewersType = default(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewInstanceProperties AccessReviewInstanceProperties(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> reviewers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> backupReviewers = null, Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType? reviewersType = default(Azure.ResourceManager.Authorization.Models.AccessReviewInstanceReviewersType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern AccessReviewRecurrencePattern(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType? type = default(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePatternType?), int? interval = default(int?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange AccessReviewRecurrenceRange(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType? type = default(Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRangeType?), int? numberOfOccurrences = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewReviewer AccessReviewReviewer(string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewReviewerType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AccessReviewScheduleDefinitionData AccessReviewScheduleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus?), string descriptionForAdmins = null, string descriptionForReviewers = null, Azure.ResourceManager.Authorization.Models.AccessReviewScope scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> reviewers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> backupReviewers = null, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType? reviewersType = default(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceData> instances = null, string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType?), string principalName = null, string userPrincipalName = null, bool? mailNotificationsEnabled = default(bool?), bool? reminderNotificationsEnabled = default(bool?), bool? defaultDecisionEnabled = default(bool?), bool? justificationRequiredOnApproval = default(bool?), Azure.ResourceManager.Authorization.Models.DefaultDecisionType? defaultDecision = default(Azure.ResourceManager.Authorization.Models.DefaultDecisionType?), bool? autoApplyDecisionsEnabled = default(bool?), bool? recommendationsEnabled = default(bool?), System.TimeSpan? recommendationLookBackDuration = default(System.TimeSpan?), int? instanceDurationInDays = default(int?), Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionProperties AccessReviewScheduleDefinitionProperties(string displayName = null, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus? status = default(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionStatus?), string descriptionForAdmins = null, string descriptionForReviewers = null, string principalId = null, Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewActorIdentityType?), string principalName = null, string userPrincipalName = null, bool? mailNotificationsEnabled = default(bool?), bool? reminderNotificationsEnabled = default(bool?), bool? defaultDecisionEnabled = default(bool?), bool? justificationRequiredOnApproval = default(bool?), Azure.ResourceManager.Authorization.Models.DefaultDecisionType? defaultDecision = default(Azure.ResourceManager.Authorization.Models.DefaultDecisionType?), bool? autoApplyDecisionsEnabled = default(bool?), bool? recommendationsEnabled = default(bool?), System.TimeSpan? recommendationLookBackDuration = default(System.TimeSpan?), int? instanceDurationInDays = default(int?), Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null, Azure.ResourceManager.Authorization.Models.AccessReviewScope scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> reviewers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AccessReviewReviewer> backupReviewers = null, Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType? reviewersType = default(Azure.ResourceManager.Authorization.Models.AccessReviewScheduleDefinitionReviewersType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AccessReviewInstanceData> instances = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScheduleSettings AccessReviewScheduleSettings(bool? mailNotificationsEnabled = default(bool?), bool? reminderNotificationsEnabled = default(bool?), bool? defaultDecisionEnabled = default(bool?), bool? justificationRequiredOnApproval = default(bool?), Azure.ResourceManager.Authorization.Models.DefaultDecisionType? defaultDecision = default(Azure.ResourceManager.Authorization.Models.DefaultDecisionType?), bool? autoApplyDecisionsEnabled = default(bool?), bool? recommendationsEnabled = default(bool?), System.TimeSpan? recommendationLookBackDuration = default(System.TimeSpan?), int? instanceDurationInDays = default(int?), Azure.ResourceManager.Authorization.Models.AccessReviewRecurrencePattern pattern = null, Azure.ResourceManager.Authorization.Models.AccessReviewRecurrenceRange range = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AccessReviewScope AccessReviewScope(string resourceId = null, string roleDefinitionId = null, Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.AccessReviewScopePrincipalType?), Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState? assignmentState = default(Azure.ResourceManager.Authorization.Models.AccessReviewScopeAssignmentState?), System.TimeSpan? inactiveDuration = default(System.TimeSpan?), bool? expandNestedMemberships = default(bool?), bool? includeInheritedAccess = default(bool?), bool? includeAccessBelowResource = default(bool?), string excludeResourceId = null, string excludeRoleDefinitionId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertConfigurationData AlertConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties AlertConfigurationProperties(string alertDefinitionId = null, string scope = null, bool? isEnabled = default(bool?), string alertConfigurationType = null, Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertData AlertData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, bool? isActive = default(bool?), int? incidentCount = default(int?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastScannedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.AlertIncidentData> alertIncidents = null, Azure.ResourceManager.Authorization.AlertConfigurationData alertConfiguration = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertDefinitionData AlertDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string scope = null, string description = null, Azure.ResourceManager.Authorization.Models.SeverityLevel? severityLevel = default(Azure.ResourceManager.Authorization.Models.SeverityLevel?), string securityImpact = null, string mitigationSteps = null, string howToPrevent = null, bool? isRemediatable = default(bool?), bool? isConfigurable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AlertIncidentData AlertIncidentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Authorization.Models.AlertIncidentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AlertIncidentProperties AlertIncidentProperties(string alertIncidentType = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AlertOperationResult AlertOperationResult(string id = null, string status = null, string statusDetail = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastActionOn = default(System.DateTimeOffset?), string resourceLocation = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent AttributeNamespaceCreateContent(string namespaceOwnerPrincipalId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AttributeNamespaceData AttributeNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator AuthorizationClassicAdministrator(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string emailAddress = null, string role = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo AuthorizationProviderOperationInfo(string name = null, string displayName = null, string description = null, string origin = null, System.BinaryData properties = null, bool? isDataAction = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationProviderOperationsMetadataData AuthorizationProviderOperationsMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType> resourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType AuthorizationProviderResourceType(string name = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> operations = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData AuthorizationRoleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, string description = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> permissions = null, System.Collections.Generic.IEnumerable<string> assignableScopes = null) { throw null; }
        public static Azure.ResourceManager.Authorization.AuthorizationRoleDefinitionData AuthorizationRoleDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, string description = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission> permissions = null, System.Collections.Generic.IEnumerable<string> assignableScopes = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties AzureRolesAssignedOutsidePimAlertConfigurationProperties(string alertDefinitionId = null, string scope = null, bool? isEnabled = default(bool?), Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties AzureRolesAssignedOutsidePimAlertIncidentProperties(string assigneeDisplayName = null, string assigneeUserPrincipalName = null, string assigneeId = null, string roleDisplayName = null, string roleTemplateId = null, string roleDefinitionId = null, System.DateTimeOffset? assignmentActivatedOn = default(System.DateTimeOffset?), string requestorId = null, string requestorDisplayName = null, string requestorUserPrincipalName = null) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentData DenyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string denyAssignmentName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission> permissions = null, string scope = null, bool? isAppliedToChildScopes = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> principals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> excludePrincipals = null, bool? isSystemProtected = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.DenyAssignmentData DenyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string denyAssignmentName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission> permissions = null, string scope = null, bool? isAppliedToChildScopes = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> principals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal> excludePrincipals = null, bool? isSystemProtected = default(bool?), Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect? denyAssignmentEffect = default(Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission DenyAssignmentPermission(System.Collections.Generic.IEnumerable<string> actions = null, System.Collections.Generic.IEnumerable<string> notActions = null, System.Collections.Generic.IEnumerable<string> dataActions = null, System.Collections.Generic.IEnumerable<string> notDataActions = null, string condition = null, string conditionVersion = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties DuplicateRoleCreatedAlertConfigurationProperties(string alertDefinitionId = null, string scope = null, bool? isEnabled = default(bool?), Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties DuplicateRoleCreatedAlertIncidentProperties(string roleName = null, string duplicateRoles = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.EligibleChildResource EligibleChildResource(string id = null, string name = null, string resourceType = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings PIMOnlyModeSettings(Azure.ResourceManager.Authorization.Models.PIMOnlyMode? mode = default(Azure.ResourceManager.Authorization.Models.PIMOnlyMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet> excludes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes> excludedAssignmentTypes = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyId = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal lastModifiedBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties PolicyAssignmentProperties(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), Azure.Core.ResourceIdentifier policyId = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal lastModifiedBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties RecordAllDecisionsProperties(string principalId = null, string resourceId = null, Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult? decision = default(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult?), string justification = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent RoleAssignmentCreateOrUpdateContent(string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid principalId = default(System.Guid), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string description = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null, Azure.Core.ResourceIdentifier delegatedManagedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentData RoleAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string description = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string createdBy = null, string updatedBy = null, Azure.Core.ResourceIdentifier delegatedManagedIdentityResourceId = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleData RoleAssignmentScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleAssignmentScheduleRequestId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? assignmentType = default(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleInstanceData RoleAssignmentScheduleInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleAssignmentScheduleId = null, Azure.Core.ResourceIdentifier originRoleAssignmentId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleInstanceId = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? assignmentType = default(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleAssignmentScheduleRequestData RoleAssignmentScheduleRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? requestType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), string approvalId = null, Azure.Core.ResourceIdentifier targetRoleAssignmentScheduleId = null, Azure.Core.ResourceIdentifier targetRoleAssignmentScheduleInstanceId = null, Azure.Core.ResourceIdentifier linkedRoleEligibilityScheduleId = null, string justification = null, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo ticketInfo = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? requestorId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? expirationType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo RoleAssignmentScheduleTicketInfo(string ticketNumber = null, string ticketSystem = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission RoleDefinitionPermission(System.Collections.Generic.IEnumerable<string> actions = null, System.Collections.Generic.IEnumerable<string> notActions = null, System.Collections.Generic.IEnumerable<string> dataActions = null, System.Collections.Generic.IEnumerable<string> notDataActions = null, string condition = null, string conditionVersion = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleData RoleEligibilityScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleEligibilityScheduleRequestId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleInstanceData RoleEligibilityScheduleInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleEligibilityScheduleId = null, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? memberType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType?), string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleEligibilityScheduleRequestData RoleEligibilityScheduleRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, System.Guid? principalId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? requestType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? status = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus?), string approvalId = null, Azure.Core.ResourceIdentifier targetRoleEligibilityScheduleId = null, Azure.Core.ResourceIdentifier targetRoleEligibilityScheduleInstanceId = null, string justification = null, Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo ticketInfo = null, string condition = null, string conditionVersion = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Guid? requestorId = default(System.Guid?), Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties expandedProperties = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? expirationType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo RoleEligibilityScheduleRequestPropertiesTicketInfo(string ticketNumber = null, string ticketSystem = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings RoleManagementApprovalSettings(bool? isApprovalRequired = default(bool?), bool? isApprovalRequiredForExtension = default(bool?), bool? isRequestorJustificationRequired = default(bool?), Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode? approvalMode = default(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage> approvalStages = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage RoleManagementApprovalStage(int? approvalStageTimeOutInDays = default(int?), bool? isApproverJustificationRequired = default(bool?), int? escalationTimeInMinutes = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> primaryApprovers = null, bool? isEscalationEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> escalationApprovers = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties RoleManagementExpandedProperties(Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), System.Guid? principalId = default(System.Guid?), string principalDisplayName = null, string email = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties RoleManagementExpandedProperties(System.Guid? principalId = default(System.Guid?), string principalDisplayName = null, string email = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), Azure.Core.ResourceIdentifier roleDefinitionId = null, string roleDefinitionDisplayName = null, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? roleType = default(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType?), Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule RoleManagementPolicyApprovalRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings settings = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyAssignmentData RoleManagementPolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, Azure.Core.ResourceIdentifier roleDefinitionId = null, Azure.Core.ResourceIdentifier policyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> effectiveRules = null, Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties policyAssignmentProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule RoleManagementPolicyAuthenticationContextRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, bool? isEnabled = default(bool?), string claimValue = null) { throw null; }
        public static Azure.ResourceManager.Authorization.RoleManagementPolicyData RoleManagementPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scope = null, string displayName = null, string description = null, bool? isOrganizationDefault = default(bool?), Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal lastModifiedBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> rules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule> effectiveRules = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties policyProperties = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule RoleManagementPolicyEnablementRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType> enablementRules = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule RoleManagementPolicyExpirationRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, bool? isExpirationRequired = default(bool?), System.TimeSpan? maximumDuration = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> exceptionMembers = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule RoleManagementPolicyNotificationRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, Azure.ResourceManager.Authorization.Models.NotificationDeliveryType? notificationDeliveryType = default(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType?), Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel? notificationLevel = default(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel?), Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType? recipientType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType?), System.Collections.Generic.IEnumerable<string> notificationRecipients = null, bool? areDefaultRecipientsEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule RoleManagementPolicyPimOnlyModeRule(string id = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null, Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings pimOnlyModeSettings = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties RoleManagementPolicyProperties(Azure.Core.ResourceIdentifier scopeId = null, string scopeDisplayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? scopeType = default(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule RoleManagementPolicyRule(string id = null, string ruleType = null, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget target = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget RoleManagementPolicyRuleTarget(string caller = null, System.Collections.Generic.IEnumerable<string> operations = null, Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel? level = default(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel?), System.Collections.Generic.IEnumerable<string> targetObjects = null, System.Collections.Generic.IEnumerable<string> inheritableSettings = null, System.Collections.Generic.IEnumerable<string> enforcedSettings = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal RoleManagementPrincipal(string id = null, string displayName = null, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? principalType = default(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType?), string email = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo RoleManagementUserInfo(Azure.ResourceManager.Authorization.Models.RoleManagementUserType? userType = default(Azure.ResourceManager.Authorization.Models.RoleManagementUserType?), bool? isBackup = default(bool?), string id = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties TooManyOwnersAssignedToResourceAlertConfigurationProperties(string alertDefinitionId = null, string scope = null, bool? isEnabled = default(bool?), Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null, int? thresholdNumberOfOwners = default(int?), int? thresholdPercentageOfOwnersOutOfAllRoleMembers = default(int?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties TooManyOwnersAssignedToResourceAlertIncidentProperties(string assigneeName = null, string assigneeType = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties(string alertDefinitionId = null, string scope = null, bool? isEnabled = default(bool?), Azure.ResourceManager.Authorization.AlertDefinitionData alertDefinition = null, int? thresholdNumberOfPermanentOwners = default(int?), int? thresholdPercentageOfPermanentOwnersOutOfAllOwners = default(int?)) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties(string assigneeName = null, string assigneeType = null) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet UsersOrServicePrincipalSet(Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType? type = default(Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType?), string id = null, string displayName = null) { throw null; }
    }
    public partial class AttributeNamespaceCreateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>
    {
        public AttributeNamespaceCreateContent(string namespaceOwnerPrincipalId) { }
        public string NamespaceOwnerPrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AttributeNamespaceCreateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationClassicAdministrator : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>
    {
        internal AuthorizationClassicAdministrator() { }
        public string EmailAddress { get { throw null; } }
        public string Role { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationClassicAdministrator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>
    {
        internal AuthorizationProviderOperationInfo() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>
    {
        internal AuthorizationProviderResourceType() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Authorization.Models.AuthorizationProviderOperationInfo> Operations { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AuthorizationProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthorizationRoleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.AuthorizationRoleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthorizationRoleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationRoleType BuiltInRole { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.AuthorizationRoleType CustomRole { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType left, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AuthorizationRoleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.AuthorizationRoleType left, Azure.ResourceManager.Authorization.Models.AuthorizationRoleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureRolesAssignedOutsidePimAlertConfigurationProperties : Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>
    {
        public AzureRolesAssignedOutsidePimAlertConfigurationProperties() { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureRolesAssignedOutsidePimAlertIncidentProperties : Azure.ResourceManager.Authorization.Models.AlertIncidentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>
    {
        internal AzureRolesAssignedOutsidePimAlertIncidentProperties() { }
        public string AssigneeDisplayName { get { throw null; } }
        public string AssigneeId { get { throw null; } }
        public string AssigneeUserPrincipalName { get { throw null; } }
        public System.DateTimeOffset? AssignmentActivatedOn { get { throw null; } }
        public string RequestorDisplayName { get { throw null; } }
        public string RequestorId { get { throw null; } }
        public string RequestorUserPrincipalName { get { throw null; } }
        public string RoleDefinitionId { get { throw null; } }
        public string RoleDisplayName { get { throw null; } }
        public string RoleTemplateId { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.AzureRolesAssignedOutsidePimAlertIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DecisionResourceType : System.IEquatable<Azure.ResourceManager.Authorization.Models.DecisionResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DecisionResourceType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DecisionResourceType AzureRole { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.DecisionResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.DecisionResourceType left, Azure.ResourceManager.Authorization.Models.DecisionResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DecisionResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DecisionResourceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.DecisionResourceType left, Azure.ResourceManager.Authorization.Models.DecisionResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultDecisionType : System.IEquatable<Azure.ResourceManager.Authorization.Models.DefaultDecisionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultDecisionType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DefaultDecisionType Approve { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.DefaultDecisionType Deny { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.DefaultDecisionType Recommendation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.DefaultDecisionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.DefaultDecisionType left, Azure.ResourceManager.Authorization.Models.DefaultDecisionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DefaultDecisionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DefaultDecisionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.DefaultDecisionType left, Azure.ResourceManager.Authorization.Models.DefaultDecisionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenyAssignmentEffect : System.IEquatable<Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenyAssignmentEffect(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect Audit { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect Enforced { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect left, Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect left, Azure.ResourceManager.Authorization.Models.DenyAssignmentEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DenyAssignmentPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>
    {
        public DenyAssignmentPermission() { }
        public System.Collections.Generic.IReadOnlyList<string> Actions { get { throw null; } }
        public string Condition { get { throw null; } set { } }
        public string ConditionVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NotDataActions { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DenyAssignmentPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DuplicateRoleCreatedAlertConfigurationProperties : Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>
    {
        public DuplicateRoleCreatedAlertConfigurationProperties() { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DuplicateRoleCreatedAlertIncidentProperties : Azure.ResourceManager.Authorization.Models.AlertIncidentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>
    {
        internal DuplicateRoleCreatedAlertIncidentProperties() { }
        public string DuplicateRoles { get { throw null; } }
        public string Reason { get { throw null; } }
        public string RoleName { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.DuplicateRoleCreatedAlertIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EligibleChildResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>
    {
        internal EligibleChildResource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.EligibleChildResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.EligibleChildResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.EligibleChildResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.EligibleChildResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.EligibleChildResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExcludedPrincipalTypes : System.IEquatable<Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExcludedPrincipalTypes(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes ServicePrincipalsAsRequestor { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes ServicePrincipalsAsTarget { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes left, Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes left, Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationDeliveryType : System.IEquatable<Azure.ResourceManager.Authorization.Models.NotificationDeliveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationDeliveryType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.NotificationDeliveryType Email { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.NotificationDeliveryType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.NotificationDeliveryType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.NotificationDeliveryType left, Azure.ResourceManager.Authorization.Models.NotificationDeliveryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PIMOnlyMode : System.IEquatable<Azure.ResourceManager.Authorization.Models.PIMOnlyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PIMOnlyMode(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.PIMOnlyMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PIMOnlyMode Enabled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.PIMOnlyMode ReportOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.PIMOnlyMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.PIMOnlyMode left, Azure.ResourceManager.Authorization.Models.PIMOnlyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.PIMOnlyMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.PIMOnlyMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.PIMOnlyMode left, Azure.ResourceManager.Authorization.Models.PIMOnlyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PIMOnlyModeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>
    {
        public PIMOnlyModeSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.ExcludedPrincipalTypes> ExcludedAssignmentTypes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet> Excludes { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.PIMOnlyMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentProperties : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>
    {
        internal PolicyAssignmentProperties() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } }
        public string RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.PolicyAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecordAllDecisionsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>
    {
        public RecordAllDecisionsProperties() { }
        public Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult? Decision { get { throw null; } set { } }
        public string Justification { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordAllDecisionsResult : System.IEquatable<Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordAllDecisionsResult(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult Approve { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult left, Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult left, Azure.ResourceManager.Authorization.Models.RecordAllDecisionsResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>
    {
        public RoleAssignmentCreateOrUpdateContent(Azure.Core.ResourceIdentifier roleDefinitionId, System.Guid principalId) { }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DelegatedManagedIdentityResourceId { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Guid PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UpdatedBy { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentEnablementRuleType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentEnablementRuleType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType Justification { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType MultiFactorAuthentication { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType Ticketing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleAssignmentScheduleAssignmentType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleAssignmentScheduleAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType Activated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType Assigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType left, Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleAssignmentScheduleTicketInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>
    {
        public RoleAssignmentScheduleTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleAssignmentScheduleTicketInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleDefinitionPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>
    {
        public RoleDefinitionPermission() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public string Condition { get { throw null; } }
        public string ConditionVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> DataActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotActions { get { throw null; } }
        public System.Collections.Generic.IList<string> NotDataActions { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleDefinitionPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleEligibilityScheduleRequestPropertiesTicketInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>
    {
        public RoleEligibilityScheduleRequestPropertiesTicketInfo() { }
        public string TicketNumber { get { throw null; } set { } }
        public string TicketSystem { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleEligibilityScheduleRequestPropertiesTicketInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementApprovalMode : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementApprovalMode(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode NoApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode Parallel { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode Serial { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode SingleStage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode left, Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode left, Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementApprovalSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>
    {
        public RoleManagementApprovalSettings() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementApprovalMode? ApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage> ApprovalStages { get { throw null; } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        public bool? IsApprovalRequiredForExtension { get { throw null; } set { } }
        public bool? IsRequestorJustificationRequired { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementApprovalStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>
    {
        public RoleManagementApprovalStage() { }
        public int? ApprovalStageTimeOutInDays { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> EscalationApprovers { get { throw null; } }
        public int? EscalationTimeInMinutes { get { throw null; } set { } }
        public bool? IsApproverJustificationRequired { get { throw null; } set { } }
        public bool? IsEscalationEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> PrimaryApprovers { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementApprovalStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementAssignmentLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementAssignmentLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel Assignment { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel Eligibility { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementExpandedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>
    {
        internal RoleManagementExpandedProperties() { }
        public string Email { get { throw null; } }
        public string PrincipalDisplayName { get { throw null; } }
        public System.Guid? PrincipalId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } }
        public string RoleDefinitionDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier RoleDefinitionId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.AuthorizationRoleType? RoleType { get { throw null; } }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementExpandedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyApprovalRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>
    {
        public RoleManagementPolicyApprovalRule() { }
        public Azure.ResourceManager.Authorization.Models.RoleManagementApprovalSettings Settings { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyApprovalRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyAuthenticationContextRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>
    {
        public RoleManagementPolicyAuthenticationContextRule() { }
        public string ClaimValue { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyAuthenticationContextRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyEnablementRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>
    {
        public RoleManagementPolicyEnablementRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleAssignmentEnablementRuleType> EnablementRules { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyEnablementRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyExpirationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>
    {
        public RoleManagementPolicyExpirationRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo> ExceptionMembers { get { throw null; } }
        public bool? IsExpirationRequired { get { throw null; } set { } }
        public System.TimeSpan? MaximumDuration { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyExpirationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPolicyNotificationLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPolicyNotificationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel All { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel Critical { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementPolicyNotificationRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>
    {
        public RoleManagementPolicyNotificationRule() { }
        public bool? AreDefaultRecipientsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.NotificationDeliveryType? NotificationDeliveryType { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationLevel? NotificationLevel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationRecipients { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType? RecipientType { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyNotificationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyPimOnlyModeRule : Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>
    {
        public RoleManagementPolicyPimOnlyModeRule() { }
        public Azure.ResourceManager.Authorization.Models.PIMOnlyModeSettings PimOnlyModeSettings { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyPimOnlyModeRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>
    {
        internal RoleManagementPolicyProperties() { }
        public string ScopeDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeId { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? ScopeType { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPolicyRecipientType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPolicyRecipientType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Admin { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Approver { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType Requestor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType left, Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRecipientType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RoleManagementPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>
    {
        protected RoleManagementPolicyRule() { }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPolicyRuleTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>
    {
        public RoleManagementPolicyRuleTarget() { }
        public string Caller { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnforcedSettings { get { throw null; } }
        public System.Collections.Generic.IList<string> InheritableSettings { get { throw null; } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementAssignmentLevel? Level { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Operations { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetObjects { get { throw null; } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPolicyRuleTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleManagementPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>
    {
        public RoleManagementPrincipal() { }
        public string DisplayName { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? PrincipalType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementPrincipalType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType Device { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType ForeignGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType left, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType left, Azure.ResourceManager.Authorization.Models.RoleManagementPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleExpirationType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleExpirationType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType AfterDateTime { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType AfterDuration { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType NoExpiration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleExpirationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleMemberType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleMemberType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Direct { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType Inherited { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleMemberType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleRequestType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleRequestType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminAssign { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminRemove { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminRenew { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType AdminUpdate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfActivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfDeactivate { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfExtend { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType SelfRenew { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScheduleStatus : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScheduleStatus(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus AdminApproved { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus AdminDenied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus FailedAsResourceIsLocked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Granted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingAdminDecision { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingApproval { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingApprovalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingExternalProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingProvisioning { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingRevocation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus PendingScheduleCreation { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus ProvisioningStarted { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus ScheduleCreated { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus left, Azure.ResourceManager.Authorization.Models.RoleManagementScheduleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementScopeType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementScopeType Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType left, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementScopeType left, Azure.ResourceManager.Authorization.Models.RoleManagementScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoleManagementUserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>
    {
        public RoleManagementUserInfo() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool? IsBackup { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.RoleManagementUserType? UserType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.RoleManagementUserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoleManagementUserType : System.IEquatable<Azure.ResourceManager.Authorization.Models.RoleManagementUserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoleManagementUserType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementUserType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.RoleManagementUserType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.RoleManagementUserType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.RoleManagementUserType left, Azure.ResourceManager.Authorization.Models.RoleManagementUserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementUserType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.RoleManagementUserType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.RoleManagementUserType left, Azure.ResourceManager.Authorization.Models.RoleManagementUserType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeverityLevel : System.IEquatable<Azure.ResourceManager.Authorization.Models.SeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.SeverityLevel High { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.SeverityLevel Low { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.SeverityLevel Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.SeverityLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.SeverityLevel left, Azure.ResourceManager.Authorization.Models.SeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.SeverityLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.SeverityLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.SeverityLevel left, Azure.ResourceManager.Authorization.Models.SeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TooManyOwnersAssignedToResourceAlertConfigurationProperties : Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>
    {
        public TooManyOwnersAssignedToResourceAlertConfigurationProperties() { }
        public int? ThresholdNumberOfOwners { get { throw null; } set { } }
        public int? ThresholdPercentageOfOwnersOutOfAllRoleMembers { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TooManyOwnersAssignedToResourceAlertIncidentProperties : Azure.ResourceManager.Authorization.Models.AlertIncidentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>
    {
        internal TooManyOwnersAssignedToResourceAlertIncidentProperties() { }
        public string AssigneeName { get { throw null; } }
        public string AssigneeType { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyOwnersAssignedToResourceAlertIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties : Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>
    {
        public TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties() { }
        public int? ThresholdNumberOfPermanentOwners { get { throw null; } set { } }
        public int? ThresholdPercentageOfPermanentOwnersOutOfAllOwners { get { throw null; } set { } }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties : Azure.ResourceManager.Authorization.Models.AlertIncidentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>
    {
        internal TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties() { }
        public string AssigneeName { get { throw null; } }
        public string AssigneeType { get { throw null; } }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Authorization.Models.AlertIncidentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.TooManyPermanentOwnersAssignedToResourceAlertIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsersOrServicePrincipalSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>
    {
        public UsersOrServicePrincipalSet() { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsersOrServicePrincipalSetUserType : System.IEquatable<Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsersOrServicePrincipalSetUserType(string value) { throw null; }
        public static Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType Group { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType left, Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType left, Azure.ResourceManager.Authorization.Models.UsersOrServicePrincipalSetUserType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
