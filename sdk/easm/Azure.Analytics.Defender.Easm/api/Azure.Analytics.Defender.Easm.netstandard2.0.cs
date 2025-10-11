namespace Azure.Analytics.Defender.Easm
{
    public partial class ActionParameters : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ActionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ActionParameters>
    {
        public ActionParameters() { }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ActionParameters System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ActionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ActionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ActionParameters System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ActionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ActionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ActionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AlexaInfo : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AlexaInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AlexaInfo>
    {
        internal AlexaInfo() { }
        public long? AlexaRank { get { throw null; } }
        public string Category { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AlexaInfo System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AlexaInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AlexaInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AlexaInfo System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AlexaInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AlexaInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AlexaInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AnalyticsDefenderEasmModelFactory
    {
        public static Azure.Analytics.Defender.Easm.AlexaInfo AlexaInfo(long? alexaRank = default(long?), string category = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AsAsset AsAsset(long? asn = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> asNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> orgNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> orgIds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> countries = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registries = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrarNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AsAssetResource AsAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.AsAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult AssetChainKindSummaryResult(Azure.Analytics.Defender.Easm.AssetKind kind = default(Azure.Analytics.Defender.Easm.AssetKind), long affectedCount = (long)0) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetChainSummaryResult AssetChainSummaryResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult> affectedAssetsSummary = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult> affectedGroupsSummary = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ErrorResponse> errors = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetPageResult AssetPageResult(long? totalElements = default(long?), string mark = null, string nextLink = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetResource> value = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetResource AssetResource(string kind = null, string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetSecurityPolicy AssetSecurityPolicy(string policyName = null, bool? isAffected = default(bool?), string description = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetService AssetService(string scheme = null, int? port = default(int?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> exceptions = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedPortState> portStates = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetSummaryResult AssetSummaryResult(string displayName = null, string description = null, System.DateTimeOffset? updatedAt = default(System.DateTimeOffset?), string metricCategory = null, string metric = null, string filter = null, string labelName = null, long? count = default(long?), string link = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSummaryResult> children = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AttributeDetails AttributeDetails(string attributeType = null, string attributeValue = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AuditTrailItem AuditTrailItem(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.AuditTrailItemKind? kind = default(Azure.Analytics.Defender.Easm.AuditTrailItemKind?), string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection AzureDataExplorerDataConnection(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null, Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload AzureDataExplorerDataConnectionPayload(string name = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.BannerDetails BannerDetails(int? port = default(int?), string bannerName = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string scanType = null, string bannerMetadata = null, bool? recent = default(bool?), string sha256 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.CisaCveResult CisaCveResult(string cveId = null, string vendorProject = null, string product = null, string vulnerabilityName = null, string shortDescription = null, string requiredAction = null, string notes = null, System.DateTimeOffset dateAdded = default(System.DateTimeOffset), System.DateTimeOffset dueDate = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), long count = (long)0) { throw null; }
        public static Azure.Analytics.Defender.Easm.ContactAsset ContactAsset(string email = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> names = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> organizations = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ContactAssetResource ContactAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.ContactAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.CookieDetails CookieDetails(string cookieName = null, string cookieDomain = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.DateTimeOffset? cookieExpiryDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.CveDetails CveDetails(string name = null, string cweId = null, float? cvssScore = default(float?), Azure.Analytics.Defender.Easm.Cvss3Summary cvss3Summary = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Cvss3Summary Cvss3Summary(string version = null, string vectorString = null, string attackVector = null, string attackComplexity = null, string privilegesRequired = null, string userInteraction = null, string scope = null, string confidentialityImpact = null, string integrityImpact = null, string availabilityImpact = null, float? baseScore = default(float?), string baseSeverity = null, string exploitCodeMaturity = null, string remediationLevel = null, string reportConfidence = null, float? exploitabilityScore = default(float?), float? impactScore = default(float?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse DailyDeltaTypeResponse(Azure.Analytics.Defender.Easm.GlobalAssetType kind = default(Azure.Analytics.Defender.Easm.GlobalAssetType), long removed = (long)0, long added = (long)0, long difference = (long)0, long count = (long)0) { throw null; }
        public static Azure.Analytics.Defender.Easm.DataConnection DataConnection(string kind = null, string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaDateResult DeltaDateResult(System.DateTimeOffset date = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse> deltas = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaDetailsRequest DeltaDetailsRequest(Azure.Analytics.Defender.Easm.DeltaDetailType deltaDetailType = default(Azure.Analytics.Defender.Easm.DeltaDetailType), int? priorDays = default(int?), Azure.Analytics.Defender.Easm.GlobalAssetType kind = default(Azure.Analytics.Defender.Easm.GlobalAssetType), string date = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaRangeResult DeltaRangeResult(long range = (long)0, long removed = (long)0, long added = (long)0, long difference = (long)0, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DeltaTypeResponse> kindSummaries = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaResult DeltaResult(Azure.Analytics.Defender.Easm.GlobalAssetType kind = default(Azure.Analytics.Defender.Easm.GlobalAssetType), string name = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), Azure.Analytics.Defender.Easm.GlobalInventoryState state = default(Azure.Analytics.Defender.Easm.GlobalInventoryState)) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaSummaryResult DeltaSummaryResult(Azure.Analytics.Defender.Easm.DeltaRangeResult summary = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DeltaDateResult> daily = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaTypeResponse DeltaTypeResponse(Azure.Analytics.Defender.Easm.GlobalAssetType kind = default(Azure.Analytics.Defender.Easm.GlobalAssetType), long removed = (long)0, long added = (long)0, long difference = (long)0) { throw null; }
        public static Azure.Analytics.Defender.Easm.DependentResource DependentResource(string md5 = null, long? responseBodySize = default(long?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string firstSeenCrawlGuid = null, string firstSeenPageGuid = null, string firstSeenResourceGuid = null, string lastSeenCrawlGuid = null, string lastSeenPageGuid = null, string lastSeenResourceGuid = null, System.Collections.Generic.IEnumerable<int> responseBodyMinhash = null, string contentType = null, string sha256 = null, string sha384 = null, string sha512 = null, System.Uri url = null, bool? cached = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck> sriChecks = null, string host = null, System.DateTimeOffset? lastObservedViolation = default(System.DateTimeOffset?), System.DateTimeOffset? lastObservedValidation = default(System.DateTimeOffset?), string lastObservedActualSriHash = null, string lastObservedExpectedSriHash = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult DiscoGroupSummaryResult(string id = null, string name = null, string displayName = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoveryGroup DiscoveryGroup(string id = null, string name = null, string displayName = null, string description = null, string tier = null, long? frequencyMilliseconds = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoverySource> seeds = null, System.Collections.Generic.IEnumerable<string> names = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoverySource> excludes = null, Azure.Analytics.Defender.Easm.DiscoveryRunResult latestRun = null, System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), string templateId = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoveryRunResult DiscoveryRunResult(System.DateTimeOffset? submittedDate = default(System.DateTimeOffset?), System.DateTimeOffset? startedDate = default(System.DateTimeOffset?), System.DateTimeOffset? completedDate = default(System.DateTimeOffset?), string tier = null, Azure.Analytics.Defender.Easm.DiscoRunState? state = default(Azure.Analytics.Defender.Easm.DiscoRunState?), long? totalAssetsFoundCount = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoverySource> seeds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoverySource> excludes = null, System.Collections.Generic.IEnumerable<string> names = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoveryTemplate DiscoveryTemplate(string id = null, string name = null, string displayName = null, string industry = null, string region = null, string countryCode = null, string stateCode = null, string city = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoverySource> seeds = null, System.Collections.Generic.IEnumerable<string> names = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DomainAsset DomainAsset(string domain = null, long? whoisId = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> registrarIanaIds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AlexaInfo> alexaInfos = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> nameServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> mailServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> whoisServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> domainStatuses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarExpiresAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SoaRecord> soaRecords = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrarNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> parkedDomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DomainAssetResource DomainAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.DomainAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ErrorDetail ErrorDetail(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ErrorDetail> details = null, Azure.Analytics.Defender.Easm.InnerError innererror = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ErrorResponse ErrorResponse(Azure.ResponseError error = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.GuidPair GuidPair(string pageGuid = null, string crawlStateGuid = null, System.DateTimeOffset? loadDate = default(System.DateTimeOffset?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostAsset HostAsset(string host = null, string domain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> ipAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> headers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AttributeDetails> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.CookieDetails> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> parentHosts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> childHosts = null, Azure.Analytics.Defender.Easm.HostCore hostCore = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetService> services = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cnames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ResourceUri> resourceUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ScanMetadata> scanMetadata = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodies = null, Azure.Analytics.Defender.Easm.DomainAsset domainAsset = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nsRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> mxRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> webserver = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nxdomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> isWildcard = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.BannerDetails> banners = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv4 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv6 = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostAssetResource HostAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.HostAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostCore HostCore(string host = null, string domain = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.DateTimeOffset? blacklistCauseFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistCauseLastSeen = default(System.DateTimeOffset?), long? blacklistCauseCount = default(long?), System.DateTimeOffset? blacklistResourceFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistResourceLastSeen = default(System.DateTimeOffset?), long? blacklistResourceCount = default(long?), System.DateTimeOffset? blacklistSequenceFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistSequenceLastSeen = default(System.DateTimeOffset?), long? blacklistSequenceCount = default(long?), long? phishCauseCount = default(long?), long? malwareCauseCount = default(long?), long? spamCauseCount = default(long?), long? scamCauseCount = default(long?), long? phishResourceCount = default(long?), long? malwareResourceCount = default(long?), long? spamResourceCount = default(long?), long? scamResourceCount = default(long?), long? phishSequenceCount = default(long?), long? malwareSequenceCount = default(long?), long? spamSequenceCount = default(long?), long? scamSequenceCount = default(long?), int? alexaRank = default(int?), int? hostReputationScore = default(int?), int? hostPhishReputationScore = default(int?), int? hostMalwareReputationScore = default(int?), int? hostSpamReputationScore = default(int?), int? hostScamReputationScore = default(int?), int? domainReputationScore = default(int?), int? domainPhishReputationScore = default(int?), int? domainMalwareReputationScore = default(int?), int? domainSpamReputationScore = default(int?), int? domainScamReputationScore = default(int?), string uuid = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.InnerError InnerError(string code = null, Azure.Analytics.Defender.Easm.InnerError innererror = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpAddressAsset IpAddressAsset(string ipAddress = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReputationDetails> reputations = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netRanges = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> headers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AttributeDetails> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.CookieDetails> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetService> services = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.BannerDetails> banners = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ScanMetadata> scanMetadata = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nsRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> mxRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> hosts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nxdomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, bool? ipv4 = default(bool?), bool? ipv6 = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpAddressAssetResource IpAddressAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.IpAddressAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlock IpBlock(string ipBlockName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlockAsset IpBlockAsset(string ipBlock = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> bgpPrefixes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netRanges = null, string startIp = null, string endIp = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReputationDetails> reputations = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarExpiresAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null, bool? ipv4 = default(bool?), bool? ipv6 = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlockAssetResource IpBlockAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.IpBlockAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection LogAnalyticsDataConnection(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null, Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload LogAnalyticsDataConnectionPayload(string name = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationPageResult ObservationPageResult(long totalElements = (long)0, System.Collections.Generic.IReadOnlyDictionary<string, int> prioritySummary = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservationResult> value = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationResult ObservationResult(string name = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservationType> types = null, Azure.Analytics.Defender.Easm.ObservationPriority priority = default(Azure.Analytics.Defender.Easm.ObservationPriority), double cvssScoreV2 = 0, double cvssScoreV3 = 0, Azure.Analytics.Defender.Easm.ObservationRemediationState remediationState = default(Azure.Analytics.Defender.Easm.ObservationRemediationState), Azure.Analytics.Defender.Easm.ObservationRemediationSource remediationSource = default(Azure.Analytics.Defender.Easm.ObservationRemediationSource)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedBoolean ObservedBoolean(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), bool? value = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedHeader ObservedHeader(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), string headerName = null, string headerValue = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedInteger ObservedInteger(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), int? value = default(int?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedIntegers ObservedIntegers(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<int> values = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedLocation ObservedLocation(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), Azure.Analytics.Defender.Easm.ObservedLocationDetails value = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedLocationDetails ObservedLocationDetails(string countryCode = null, string countryName = null, string region = null, string regionName = null, string city = null, int? areaCode = default(int?), string postalCode = null, float? latitude = default(float?), float? longitude = default(float?), int? dmaCode = default(int?), int? metroCodeId = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedLong ObservedLong(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), long? value = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedPortState ObservedPortState(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), Azure.Analytics.Defender.Easm.ObservedPortStateValue? value = default(Azure.Analytics.Defender.Easm.ObservedPortStateValue?), int? port = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedString ObservedString(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), string value = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedValue ObservedValue(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageAsset PageAsset(System.Uri url = null, string httpMethod = null, string service = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> ipAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> successful = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> httpResponseCodes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> httpResponseMessages = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> responseTimes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> frames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> windows = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nonHtmlFrames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> undirectedContent = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> contentTypes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> contentLengths = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> windowNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> charsets = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> titles = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> languages = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> responseHeaders = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.CookieDetails> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AttributeDetails> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> assetSecurityPolicies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedIntegers> responseBodyMinhashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedIntegers> fullDomMinhashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodyHashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> errors = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), Azure.Analytics.Defender.Easm.PageCause cause = null, string referrer = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> redirectUrls = null, Azure.Analytics.Defender.Easm.PageAssetRedirectType? redirectType = default(Azure.Analytics.Defender.Easm.PageAssetRedirectType?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> finalUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> finalResponseCodes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> parkedPage = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ResourceUri> resourceUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.GuidPair> guids = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> finalIpAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> finalAsns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> finalIpBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodies = null, Azure.Analytics.Defender.Easm.DomainAsset domainAsset = null, Azure.Analytics.Defender.Easm.ObservedBoolean rootUrl = null, bool? isRootUrl = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetService> services = null, string siteStatus = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cnames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cdns = null, string host = null, string domain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> gdprAssetSecurityPolicies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv4 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv6 = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageAssetResource PageAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.PageAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageCause PageCause(string cause = null, string causeElementXPath = null, string location = null, int? possibleMatches = default(int?), bool? loopDetected = default(bool?), int? version = default(int?), int? domChangeIndex = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.Policy Policy(string id = null, string name = null, string displayName = null, string description = null, string filterName = null, Azure.Analytics.Defender.Easm.PolicyAction action = default(Azure.Analytics.Defender.Easm.PolicyAction), long? updatedAssetsCount = default(long?), string user = null, System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.ActionParameters actionParameters = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PortDetails PortDetails(int? portName = default(int?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult ReportAssetSnapshotResult(string displayName = null, string metric = null, string labelName = null, System.DateTimeOffset? updatedAt = default(System.DateTimeOffset?), string description = null, Azure.Analytics.Defender.Easm.AssetPageResult assets = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportAssetSummaryResult ReportAssetSummaryResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSummaryResult> assetSummaries = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown ReportBillableAssetBreakdown(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind? kind = default(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult ReportBillableAssetSnapshotResult(System.DateTimeOffset? date = default(System.DateTimeOffset?), long? total = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown> assetBreakdown = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult ReportBillableAssetSummaryResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult> assetSummaries = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReputationDetails ReputationDetails(string listName = null, string threatType = null, bool? trusted = default(bool?), string cidr = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), System.DateTimeOffset? listUpdatedAt = default(System.DateTimeOffset?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ResourceUri ResourceUri(System.Uri url = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DependentResource> resources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SavedFilter SavedFilter(string id = null, string name = null, string displayName = null, string filter = null, string description = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ScanMetadata ScanMetadata(int? port = default(int?), string bannerMetadata = null, System.DateTimeOffset? startScan = default(System.DateTimeOffset?), System.DateTimeOffset? endScan = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SoaRecord SoaRecord(string nameServer = null, string email = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), long? serialNumber = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SourceDetails SourceDetails(string sourceName = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslCertAsset SslCertAsset(string sha1 = null, System.Collections.Generic.IEnumerable<string> subjectCommonNames = null, System.Collections.Generic.IEnumerable<string> organizations = null, System.Collections.Generic.IEnumerable<string> organizationalUnits = null, System.Collections.Generic.IEnumerable<string> issuerCommonNames = null, string sigAlgName = null, System.DateTimeOffset? invalidAfter = default(System.DateTimeOffset?), string serialNumber = null, System.Collections.Generic.IEnumerable<string> subjectAlternativeNames = null, System.Collections.Generic.IEnumerable<string> issuerAlternativeNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.DateTimeOffset? invalidBefore = default(System.DateTimeOffset?), int? keySize = default(int?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> subjectLocality = null, System.Collections.Generic.IEnumerable<string> subjectState = null, System.Collections.Generic.IEnumerable<string> subjectCountry = null, System.Collections.Generic.IEnumerable<string> issuerLocality = null, System.Collections.Generic.IEnumerable<string> issuerState = null, System.Collections.Generic.IEnumerable<string> issuerCountry = null, System.Collections.Generic.IEnumerable<string> subjectOrganizations = null, System.Collections.Generic.IEnumerable<string> subjectOrganizationalUnits = null, System.Collections.Generic.IEnumerable<string> issuerOrganizations = null, System.Collections.Generic.IEnumerable<string> issuerOrganizationalUnits = null, int? version = default(int?), bool? certificateAuthority = default(bool?), bool? selfSigned = default(bool?), string sigAlgOid = null, bool? recent = default(bool?), Azure.Analytics.Defender.Easm.SslCertAssetValidationType? validationType = default(Azure.Analytics.Defender.Easm.SslCertAssetValidationType?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslCertAssetResource SslCertAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.SslCertAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslServerConfig SslServerConfig(System.Collections.Generic.IEnumerable<string> tlsVersions = null, System.Collections.Generic.IEnumerable<string> cipherSuites = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck SubResourceIntegrityCheck(bool? violation = default(bool?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string causePageUrl = null, string crawlGuid = null, string pageGuid = null, string resourceGuid = null, string expectedHash = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.TaskResource TaskResource(string id = null, System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastPolledAt = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.TaskResourceState? state = default(Azure.Analytics.Defender.Easm.TaskResourceState?), Azure.Analytics.Defender.Easm.TaskResourcePhase? phase = default(Azure.Analytics.Defender.Easm.TaskResourcePhase?), string reason = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> metadata = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ValidateResult ValidateResult(Azure.Analytics.Defender.Easm.ErrorDetail error = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.WebComponent WebComponent(string name = null, string type = null, string version = null, System.Collections.Generic.IEnumerable<string> ruleId = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.CveDetails> cve = null, long? endOfLife = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.PortDetails> ports = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SourceDetails> sources = null, string service = null) { throw null; }
    }
    public partial class AsAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAsset>
    {
        internal AsAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminPhones { get { throw null; } }
        public long? Asn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AsNames { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Countries { get { throw null; } }
        public System.DateTimeOffset? DetailedFromWhoisAt { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> OrgIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> OrgNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantPhones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarCreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrarNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarUpdatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Registries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AsAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AsAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AsAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAssetResource>
    {
        internal AsAssetResource() { }
        public Azure.Analytics.Defender.Easm.AsAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AsAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AsAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AsAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AsAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetChainKindSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>
    {
        internal AssetChainKindSummaryResult() { }
        public long AffectedCount { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AssetKind Kind { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetChainRequest : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainRequest>
    {
        public AssetChainRequest(Azure.Analytics.Defender.Easm.AssetChainSource assetChainSource, System.Collections.Generic.IEnumerable<string> sourceIds) { }
        public Azure.Analytics.Defender.Easm.AssetChainSource AssetChainSource { get { throw null; } }
        public System.Collections.Generic.IList<string> SourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainRequest System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainRequest System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetChainSource : System.IEquatable<Azure.Analytics.Defender.Easm.AssetChainSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetChainSource(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetChainSource ASSET { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetChainSource DISCOGROUP { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetChainSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetChainSource left, Azure.Analytics.Defender.Easm.AssetChainSource right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetChainSource (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetChainSource left, Azure.Analytics.Defender.Easm.AssetChainSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetChainSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>
    {
        internal AssetChainSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetChainKindSummaryResult> AffectedAssetsSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult> AffectedGroupsSummary { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ErrorResponse> Errors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetChainSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetKind : System.IEquatable<Azure.Analytics.Defender.Easm.AssetKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetKind(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetKind As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind IpAddress { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind IpBlock { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind Page { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetKind SslCert { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetKind left, Azure.Analytics.Defender.Easm.AssetKind right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetKind (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetKind left, Azure.Analytics.Defender.Easm.AssetKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetPageResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetPageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetPageResult>
    {
        internal AssetPageResult() { }
        public string Mark { get { throw null; } }
        public string NextLink { get { throw null; } }
        public long? TotalElements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetResource> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetPageResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetPageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetPageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetPageResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetPageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetPageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetPageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AssetResource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetResource>
    {
        protected AssetResource() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AuditTrailItem> AuditTrail { get { throw null; } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string DiscoGroupName { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ExternalId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AssetState? State { get { throw null; } }
        public System.DateTimeOffset? UpdatedDate { get { throw null; } }
        public System.Guid? Uuid { get { throw null; } }
        public bool? Wildcard { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetResponseType : System.IEquatable<Azure.Analytics.Defender.Easm.AssetResponseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetResponseType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetResponseType Full { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetResponseType Id { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetResponseType Reduced { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetResponseType Standard { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetResponseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetResponseType left, Azure.Analytics.Defender.Easm.AssetResponseType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetResponseType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetResponseType left, Azure.Analytics.Defender.Easm.AssetResponseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetSecurityPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>
    {
        internal AssetSecurityPolicy() { }
        public long? Count { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public bool? IsAffected { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetSecurityPolicy System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetSecurityPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSecurityPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetService : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetService>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetService>
    {
        internal AssetService() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Exceptions { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedPortState> PortStates { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string Scheme { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetService System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetService System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetsExportRequest : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>
    {
        public AssetsExportRequest(string fileName, System.Collections.Generic.IEnumerable<string> columns) { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string FileName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetsExportRequest System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetsExportRequest System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetsExportRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetState : System.IEquatable<Azure.Analytics.Defender.Easm.AssetState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetState Archived { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState AssociatedPartner { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState AssociatedThirdparty { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState Candidate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState CandidateInvestigate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState Confirmed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetState Dismissed { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetState left, Azure.Analytics.Defender.Easm.AssetState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetState left, Azure.Analytics.Defender.Easm.AssetState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssetSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>
    {
        internal AssetSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSummaryResult> Children { get { throw null; } }
        public long? Count { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Filter { get { throw null; } }
        public string LabelName { get { throw null; } }
        public string Link { get { throw null; } }
        public string Metric { get { throw null; } }
        public string MetricCategory { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssetUpdatePayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>
    {
        public AssetUpdatePayload() { }
        public string ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, bool> Labels { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Defender.Easm.ObservationRemediationItem> Remediations { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AssetUpdateState? State { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.AssetUpdateTransfers? Transfers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetUpdatePayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AssetUpdatePayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AssetUpdatePayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetUpdateState : System.IEquatable<Azure.Analytics.Defender.Easm.AssetUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetUpdateState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState AssociatedPartner { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState AssociatedThirdparty { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState Candidate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState CandidateInvestigate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState Confirmed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateState Dismissed { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetUpdateState left, Azure.Analytics.Defender.Easm.AssetUpdateState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetUpdateState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetUpdateState left, Azure.Analytics.Defender.Easm.AssetUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssetUpdateTransfers : System.IEquatable<Azure.Analytics.Defender.Easm.AssetUpdateTransfers>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssetUpdateTransfers(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers IpAddress { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers IpBlock { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers Page { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AssetUpdateTransfers SslCert { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AssetUpdateTransfers other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AssetUpdateTransfers left, Azure.Analytics.Defender.Easm.AssetUpdateTransfers right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AssetUpdateTransfers (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AssetUpdateTransfers left, Azure.Analytics.Defender.Easm.AssetUpdateTransfers right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AttributeDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AttributeDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AttributeDetails>
    {
        internal AttributeDetails() { }
        public string AttributeType { get { throw null; } }
        public string AttributeValue { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AttributeDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AttributeDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AttributeDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AttributeDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AttributeDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AttributeDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AttributeDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuditTrailItem : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AuditTrailItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AuditTrailItem>
    {
        internal AuditTrailItem() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AuditTrailItemKind? Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AuditTrailItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AuditTrailItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AuditTrailItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AuditTrailItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AuditTrailItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AuditTrailItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AuditTrailItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuditTrailItemKind : System.IEquatable<Azure.Analytics.Defender.Easm.AuditTrailItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuditTrailItemKind(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind IpAddress { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind IpBlock { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind Page { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.AuditTrailItemKind SslCert { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.AuditTrailItemKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.AuditTrailItemKind left, Azure.Analytics.Defender.Easm.AuditTrailItemKind right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.AuditTrailItemKind (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.AuditTrailItemKind left, Azure.Analytics.Defender.Easm.AuditTrailItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAnalyticsDefenderEasmContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsDefenderEasmContext() { }
        public static Azure.Analytics.Defender.Easm.AzureAnalyticsDefenderEasmContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureDataExplorerDataConnection : Azure.Analytics.Defender.Easm.DataConnection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>
    {
        internal AzureDataExplorerDataConnection() { }
        public Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDataExplorerDataConnectionPayload : Azure.Analytics.Defender.Easm.DataConnectionPayload, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>
    {
        public AzureDataExplorerDataConnectionPayload(Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties properties) { }
        public Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDataExplorerDataConnectionProperties : Azure.Analytics.Defender.Easm.DataConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>
    {
        public AzureDataExplorerDataConnectionProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BannerDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.BannerDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.BannerDetails>
    {
        internal BannerDetails() { }
        public string BannerMetadata { get { throw null; } }
        public string BannerName { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? Port { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string ScanType { get { throw null; } }
        public string Sha256 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.BannerDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.BannerDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.BannerDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.BannerDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.BannerDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.BannerDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.BannerDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CisaCveResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CisaCveResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CisaCveResult>
    {
        internal CisaCveResult() { }
        public long Count { get { throw null; } }
        public string CveId { get { throw null; } }
        public System.DateTimeOffset DateAdded { get { throw null; } }
        public System.DateTimeOffset DueDate { get { throw null; } }
        public string Notes { get { throw null; } }
        public string Product { get { throw null; } }
        public string RequiredAction { get { throw null; } }
        public string ShortDescription { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        public string VendorProject { get { throw null; } }
        public string VulnerabilityName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CisaCveResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CisaCveResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CisaCveResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CisaCveResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CisaCveResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CisaCveResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CisaCveResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContactAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAsset>
    {
        internal ContactAsset() { }
        public long? Count { get { throw null; } }
        public string Email { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Organizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ContactAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ContactAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContactAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAssetResource>
    {
        internal ContactAssetResource() { }
        public Azure.Analytics.Defender.Easm.ContactAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ContactAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ContactAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ContactAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ContactAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CookieDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CookieDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CookieDetails>
    {
        internal CookieDetails() { }
        public string CookieDomain { get { throw null; } }
        public System.DateTimeOffset? CookieExpiryDate { get { throw null; } }
        public string CookieName { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CookieDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CookieDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CookieDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CookieDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CookieDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CookieDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CookieDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CveDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CveDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CveDetails>
    {
        internal CveDetails() { }
        public Azure.Analytics.Defender.Easm.Cvss3Summary Cvss3Summary { get { throw null; } }
        public float? CvssScore { get { throw null; } }
        public string CweId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CveDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CveDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.CveDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.CveDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CveDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CveDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.CveDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Cvss3Summary : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Cvss3Summary>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Cvss3Summary>
    {
        internal Cvss3Summary() { }
        public string AttackComplexity { get { throw null; } }
        public string AttackVector { get { throw null; } }
        public string AvailabilityImpact { get { throw null; } }
        public float? BaseScore { get { throw null; } }
        public string BaseSeverity { get { throw null; } }
        public string ConfidentialityImpact { get { throw null; } }
        public float? ExploitabilityScore { get { throw null; } }
        public string ExploitCodeMaturity { get { throw null; } }
        public float? ImpactScore { get { throw null; } }
        public string IntegrityImpact { get { throw null; } }
        public string PrivilegesRequired { get { throw null; } }
        public string RemediationLevel { get { throw null; } }
        public string ReportConfidence { get { throw null; } }
        public string Scope { get { throw null; } }
        public string UserInteraction { get { throw null; } }
        public string VectorString { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.Cvss3Summary System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Cvss3Summary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Cvss3Summary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.Cvss3Summary System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Cvss3Summary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Cvss3Summary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Cvss3Summary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DailyDeltaTypeResponse : Azure.Analytics.Defender.Easm.DeltaTypeResponse, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>
    {
        internal DailyDeltaTypeResponse() { }
        public long Count { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataConnection : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnection>
    {
        protected DataConnection() { }
        public bool? Active { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DataConnectionContent? Content { get { throw null; } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DataConnectionFrequency? Frequency { get { throw null; } }
        public int? FrequencyOffset { get { throw null; } }
        public string Id { get { throw null; } }
        public string InactiveMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? UpdatedDate { get { throw null; } }
        public System.DateTimeOffset? UserUpdatedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectionContent : System.IEquatable<Azure.Analytics.Defender.Easm.DataConnectionContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectionContent(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DataConnectionContent Assets { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DataConnectionContent AttackSurfaceInsights { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DataConnectionContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DataConnectionContent left, Azure.Analytics.Defender.Easm.DataConnectionContent right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DataConnectionContent (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DataConnectionContent left, Azure.Analytics.Defender.Easm.DataConnectionContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectionFrequency : System.IEquatable<Azure.Analytics.Defender.Easm.DataConnectionFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectionFrequency(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DataConnectionFrequency Daily { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DataConnectionFrequency Monthly { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DataConnectionFrequency Weekly { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DataConnectionFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DataConnectionFrequency left, Azure.Analytics.Defender.Easm.DataConnectionFrequency right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DataConnectionFrequency (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DataConnectionFrequency left, Azure.Analytics.Defender.Easm.DataConnectionFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataConnectionPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>
    {
        protected DataConnectionPayload() { }
        public Azure.Analytics.Defender.Easm.DataConnectionContent? Content { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.DataConnectionFrequency? Frequency { get { throw null; } set { } }
        public int? FrequencyOffset { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnectionPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnectionPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>
    {
        public DataConnectionProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DataConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DataConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaDateResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDateResult>
    {
        internal DeltaDateResult() { }
        public System.DateTimeOffset Date { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DailyDeltaTypeResponse> Deltas { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaDateResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaDateResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaDetailsRequest : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>
    {
        public DeltaDetailsRequest(Azure.Analytics.Defender.Easm.DeltaDetailType deltaDetailType, Azure.Analytics.Defender.Easm.GlobalAssetType kind) { }
        public string Date { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.DeltaDetailType DeltaDetailType { get { throw null; } }
        public Azure.Analytics.Defender.Easm.GlobalAssetType Kind { get { throw null; } }
        public int? PriorDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaDetailsRequest System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaDetailsRequest System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaDetailsRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeltaDetailType : System.IEquatable<Azure.Analytics.Defender.Easm.DeltaDetailType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeltaDetailType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DeltaDetailType Added { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DeltaDetailType Removed { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DeltaDetailType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DeltaDetailType left, Azure.Analytics.Defender.Easm.DeltaDetailType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DeltaDetailType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DeltaDetailType left, Azure.Analytics.Defender.Easm.DeltaDetailType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeltaRangeResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>
    {
        internal DeltaRangeResult() { }
        public long Added { get { throw null; } }
        public long Difference { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DeltaTypeResponse> KindSummaries { get { throw null; } }
        public long Range { get { throw null; } }
        public long Removed { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaRangeResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaRangeResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaRangeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaResult>
    {
        internal DeltaResult() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.Analytics.Defender.Easm.GlobalAssetType Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Defender.Easm.GlobalInventoryState State { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaSummaryRequest : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>
    {
        public DeltaSummaryRequest() { }
        public string Date { get { throw null; } set { } }
        public int? PriorDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaSummaryRequest System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaSummaryRequest System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>
    {
        internal DeltaSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DeltaDateResult> Daily { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DeltaRangeResult Summary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeltaTypeResponse : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>
    {
        internal DeltaTypeResponse() { }
        public long Added { get { throw null; } }
        public long Difference { get { throw null; } }
        public Azure.Analytics.Defender.Easm.GlobalAssetType Kind { get { throw null; } }
        public long Removed { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaTypeResponse System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DeltaTypeResponse System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DeltaTypeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependentResource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DependentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DependentResource>
    {
        internal DependentResource() { }
        public bool? Cached { get { throw null; } }
        public string ContentType { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public string FirstSeenCrawlGuid { get { throw null; } }
        public string FirstSeenPageGuid { get { throw null; } }
        public string FirstSeenResourceGuid { get { throw null; } }
        public string Host { get { throw null; } }
        public string LastObservedActualSriHash { get { throw null; } }
        public string LastObservedExpectedSriHash { get { throw null; } }
        public System.DateTimeOffset? LastObservedValidation { get { throw null; } }
        public System.DateTimeOffset? LastObservedViolation { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string LastSeenCrawlGuid { get { throw null; } }
        public string LastSeenPageGuid { get { throw null; } }
        public string LastSeenResourceGuid { get { throw null; } }
        public string Md5 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> ResponseBodyMinhash { get { throw null; } }
        public long? ResponseBodySize { get { throw null; } }
        public string Sha256 { get { throw null; } }
        public string Sha384 { get { throw null; } }
        public string Sha512 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck> SriChecks { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DependentResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DependentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DependentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DependentResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DependentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DependentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DependentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoGroupSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>
    {
        internal DiscoGroupSummaryResult() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoGroupSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoRunState : System.IEquatable<Azure.Analytics.Defender.Easm.DiscoRunState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoRunState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoRunState Completed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoRunState Failed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoRunState Pending { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoRunState Running { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DiscoRunState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DiscoRunState left, Azure.Analytics.Defender.Easm.DiscoRunState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DiscoRunState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DiscoRunState left, Azure.Analytics.Defender.Easm.DiscoRunState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryGroup : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>
    {
        internal DiscoveryGroup() { }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoverySource> Excludes { get { throw null; } }
        public long? FrequencyMilliseconds { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DiscoveryRunResult LatestRun { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoverySource> Seeds { get { throw null; } }
        public string TemplateId { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryGroup System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryGroup System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryGroupPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>
    {
        public DiscoveryGroupPayload() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Defender.Easm.DiscoverySource> Excludes { get { throw null; } }
        public long? FrequencyMilliseconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Defender.Easm.DiscoverySource> Seeds { get { throw null; } }
        public string TemplateId { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryGroupPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryGroupPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryGroupPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryRunResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>
    {
        internal DiscoveryRunResult() { }
        public System.DateTimeOffset? CompletedDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoverySource> Excludes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoverySource> Seeds { get { throw null; } }
        public System.DateTimeOffset? StartedDate { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DiscoRunState? State { get { throw null; } }
        public System.DateTimeOffset? SubmittedDate { get { throw null; } }
        public string Tier { get { throw null; } }
        public long? TotalAssetsFoundCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryRunResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryRunResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryRunResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoverySource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoverySource>
    {
        public DiscoverySource() { }
        public Azure.Analytics.Defender.Easm.DiscoverySourceKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoverySource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoverySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoverySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoverySource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoverySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoverySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoverySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoverySourceKind : System.IEquatable<Azure.Analytics.Defender.Easm.DiscoverySourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoverySourceKind(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind Attribute { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoverySourceKind IpBlock { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DiscoverySourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DiscoverySourceKind left, Azure.Analytics.Defender.Easm.DiscoverySourceKind right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DiscoverySourceKind (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DiscoverySourceKind left, Azure.Analytics.Defender.Easm.DiscoverySourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryTemplate : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>
    {
        internal DiscoveryTemplate() { }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Industry { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public string Region { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoverySource> Seeds { get { throw null; } }
        public string StateCode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryTemplate System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DiscoveryTemplate System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DiscoveryTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAsset>
    {
        internal DomainAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminPhones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AlexaInfo> AlexaInfos { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? DetailedFromWhoisAt { get { throw null; } }
        public string Domain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> DomainStatuses { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> MailServers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> NameServers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> ParkedDomain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantPhones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarCreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarExpiresAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedInteger> RegistrarIanaIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrarNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarUpdatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SoaRecord> SoaRecords { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
        public long? WhoisId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> WhoisServers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DomainAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DomainAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAssetResource>
    {
        internal DomainAssetResource() { }
        public Azure.Analytics.Defender.Easm.DomainAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DomainAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.DomainAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.DomainAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.DomainAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EasmClient
    {
        protected EasmClient() { }
        public EasmClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public EasmClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Defender.Easm.EasmClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> CancelTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> CancelTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DataConnection> CreateOrReplaceDataConnection(string dataConnectionName, Azure.Analytics.Defender.Easm.DataConnectionPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceDataConnection(string dataConnectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DataConnection>> CreateOrReplaceDataConnectionAsync(string dataConnectionName, Azure.Analytics.Defender.Easm.DataConnectionPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceDataConnectionAsync(string dataConnectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryGroup> CreateOrReplaceDiscoGroup(string groupName, Azure.Analytics.Defender.Easm.DiscoveryGroupPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceDiscoGroup(string groupName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryGroup>> CreateOrReplaceDiscoGroupAsync(string groupName, Azure.Analytics.Defender.Easm.DiscoveryGroupPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceDiscoGroupAsync(string groupName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.Policy> CreateOrReplacePolicy(string policyName, Azure.Analytics.Defender.Easm.Policy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplacePolicy(string policyName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.Policy>> CreateOrReplacePolicyAsync(string policyName, Azure.Analytics.Defender.Easm.Policy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplacePolicyAsync(string policyName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter> CreateOrReplaceSavedFilter(string filterName, Azure.Analytics.Defender.Easm.SavedFilterPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSavedFilter(string filterName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter>> CreateOrReplaceSavedFilterAsync(string filterName, Azure.Analytics.Defender.Easm.SavedFilterPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceSavedFilterAsync(string filterName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDataConnection(string dataConnectionName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataConnectionAsync(string dataConnectionName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDiscoGroup(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiscoGroupAsync(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeletePolicy(string policyName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePolicyAsync(string policyName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSavedFilter(string filterName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSavedFilterAsync(string filterName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> DismissAssetChain(Azure.Analytics.Defender.Easm.AssetChainRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DismissAssetChain(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> DismissAssetChainAsync(Azure.Analytics.Defender.Easm.AssetChainRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DismissAssetChainAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DownloadTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> DownloadTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> DownloadTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.AssetChainSummaryResult> GetAssetChainSummary(Azure.Analytics.Defender.Easm.AssetChainRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAssetChainSummary(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.AssetChainSummaryResult>> GetAssetChainSummaryAsync(Azure.Analytics.Defender.Easm.AssetChainRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetChainSummaryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAssetResource(string assetId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResource(string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetResourceAsync(string assetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.AssetResource>> GetAssetResourceAsync(string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResources(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), string mark = null, Azure.Analytics.Defender.Easm.AssetResponseType? responseType = default(Azure.Analytics.Defender.Easm.AssetResponseType?), System.Collections.Generic.IEnumerable<string> responseIncludes = null, bool? recentOnly = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssetResources(string filter, string orderby, int? skip, int? maxpagesize, string mark, string responseType, System.Collections.Generic.IEnumerable<string> responseIncludes, bool? recentOnly, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResourcesAsync(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), string mark = null, Azure.Analytics.Defender.Easm.AssetResponseType? responseType = default(Azure.Analytics.Defender.Easm.AssetResponseType?), System.Collections.Generic.IEnumerable<string> responseIncludes = null, bool? recentOnly = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetResourcesAsync(string filter, string orderby, int? skip, int? maxpagesize, string mark, string responseType, System.Collections.Generic.IEnumerable<string> responseIncludes, bool? recentOnly, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> GetAssetsExport(Azure.Analytics.Defender.Easm.AssetsExportRequest body, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAssetsExport(Azure.Core.RequestContent content, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> GetAssetsExportAsync(Azure.Analytics.Defender.Easm.AssetsExportRequest body, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetsExportAsync(Azure.Core.RequestContent content, string filter = null, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBillable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult> GetBillable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBillableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>> GetBillableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCisaCve(string cveId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.CisaCveResult> GetCisaCve(string cveId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCisaCveAsync(string cveId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.CisaCveResult>> GetCisaCveAsync(string cveId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCisaCves(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.CisaCveResult> GetCisaCves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCisaCvesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.CisaCveResult> GetCisaCvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDataConnection(string dataConnectionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataConnectionAsync(string dataConnectionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DataConnection>> GetDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDataConnections(int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnections(int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDataConnectionsAsync(int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnectionsAsync(int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DeltaResult> GetDeltaDetails(Azure.Analytics.Defender.Easm.DeltaDetailsRequest body, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeltaDetails(Azure.Core.RequestContent content, int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DeltaResult> GetDeltaDetailsAsync(Azure.Analytics.Defender.Easm.DeltaDetailsRequest body, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeltaDetailsAsync(Azure.Core.RequestContent content, int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DeltaSummaryResult> GetDeltaSummary(Azure.Analytics.Defender.Easm.DeltaSummaryRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDeltaSummary(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DeltaSummaryResult>> GetDeltaSummaryAsync(Azure.Analytics.Defender.Easm.DeltaSummaryRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeltaSummaryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDiscoGroup(string groupName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryGroup> GetDiscoGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoGroupAsync(string groupName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryGroup>> GetDiscoGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiscoGroups(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoveryGroup> GetDiscoGroups(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiscoGroupsAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoveryGroup> GetDiscoGroupsAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiscoTemplate(string templateId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryTemplate> GetDiscoTemplate(string templateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoTemplateAsync(string templateId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoveryTemplate>> GetDiscoTemplateAsync(string templateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiscoTemplates(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoveryTemplate> GetDiscoTemplates(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiscoTemplatesAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoveryTemplate> GetDiscoTemplatesAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetObservations(string assetId, string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ObservationPageResult> GetObservations(string assetId, string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetObservationsAsync(string assetId, string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ObservationPageResult>> GetObservationsAsync(string assetId, string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPolicies(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.Policy> GetPolicies(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoliciesAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.Policy> GetPoliciesAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPolicy(string policyName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.Policy> GetPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPolicyAsync(string policyName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.Policy>> GetPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(string groupName, string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoveryRunResult> GetRuns(string groupName, string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(string groupName, string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoveryRunResult> GetRunsAsync(string groupName, string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSavedFilter(string filterName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSavedFilterAsync(string filterName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter>> GetSavedFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSavedFilters(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFilters(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSavedFiltersAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFiltersAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult> GetSnapshot(Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>> GetSnapshotAsync(Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> GetSnapshotExport(Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshotExport(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> GetSnapshotExportAsync(Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotExportAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult> GetSummary(Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSummary(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>> GetSummaryAsync(Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSummaryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> GetTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> GetTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTasks(string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.TaskResource> GetTasks(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTasksAsync(string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.TaskResource> GetTasksAsync(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunDiscoGroup(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunDiscoGroupAsync(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RunTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> RunTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> RunTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.TaskResource> UpdateAssets(string filter, Azure.Analytics.Defender.Easm.AssetUpdatePayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAssets(string filter, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.TaskResource>> UpdateAssetsAsync(string filter, Azure.Analytics.Defender.Easm.AssetUpdatePayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAssetsAsync(string filter, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult> ValidateDataConnection(Azure.Analytics.Defender.Easm.DataConnectionPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateDataConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult>> ValidateDataConnectionAsync(Azure.Analytics.Defender.Easm.DataConnectionPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateDataConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult> ValidateDiscoGroup(Azure.Analytics.Defender.Easm.DiscoveryGroupPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateDiscoGroup(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult>> ValidateDiscoGroupAsync(Azure.Analytics.Defender.Easm.DiscoveryGroupPayload body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateDiscoGroupAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EasmClientOptions : Azure.Core.ClientOptions
    {
        public EasmClientOptions(Azure.Analytics.Defender.Easm.EasmClientOptions.ServiceVersion version = Azure.Analytics.Defender.Easm.EasmClientOptions.ServiceVersion.V2024_10_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
            V2024_03_01_Preview = 2,
            V2024_10_01_Preview = 3,
        }
    }
    public partial class ErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorDetail>
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ErrorDetail> Details { get { throw null; } }
        public Azure.Analytics.Defender.Easm.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorResponse>
    {
        internal ErrorResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalAssetType : System.IEquatable<Azure.Analytics.Defender.Easm.GlobalAssetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalAssetType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType IpAddress { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType IpBlock { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType MailServer { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType NameServer { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType Page { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType Resource { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalAssetType SslCert { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.GlobalAssetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.GlobalAssetType left, Azure.Analytics.Defender.Easm.GlobalAssetType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.GlobalAssetType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.GlobalAssetType left, Azure.Analytics.Defender.Easm.GlobalAssetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GlobalInventoryState : System.IEquatable<Azure.Analytics.Defender.Easm.GlobalInventoryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GlobalInventoryState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Archived { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Associated { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState AssociatedPartner { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState AssociatedThirdParty { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Autoconfirmed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Candidate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState CandidateInvestigate { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Confirmed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.GlobalInventoryState Dismissed { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.GlobalInventoryState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.GlobalInventoryState left, Azure.Analytics.Defender.Easm.GlobalInventoryState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.GlobalInventoryState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.GlobalInventoryState left, Azure.Analytics.Defender.Easm.GlobalInventoryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GuidPair : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.GuidPair>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.GuidPair>
    {
        internal GuidPair() { }
        public string CrawlStateGuid { get { throw null; } }
        public System.DateTimeOffset? LoadDate { get { throw null; } }
        public string PageGuid { get { throw null; } }
        public bool? Recent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.GuidPair System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.GuidPair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.GuidPair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.GuidPair System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.GuidPair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.GuidPair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.GuidPair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAsset>
    {
        internal HostAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AttributeDetails> Attributes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.BannerDetails> Banners { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ChildHosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cnames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.CookieDetails> Cookies { get { throw null; } }
        public long? Count { get { throw null; } }
        public string Domain { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DomainAsset DomainAsset { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedHeader> Headers { get { throw null; } }
        public string Host { get { throw null; } }
        public Azure.Analytics.Defender.Easm.HostCore HostCore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> IpAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.IpBlock> IpBlocks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Ipv4 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Ipv6 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> IsWildcard { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLocation> Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> MxRecord { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> NsRecord { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Nxdomain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ParentHosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ResourceUri> ResourceUrls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ScanMetadata> ScanMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetService> Services { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Webserver { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAssetResource>
    {
        internal HostAssetResource() { }
        public Azure.Analytics.Defender.Easm.HostAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostCore : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostCore>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostCore>
    {
        internal HostCore() { }
        public int? AlexaRank { get { throw null; } }
        public long? BlacklistCauseCount { get { throw null; } }
        public System.DateTimeOffset? BlacklistCauseFirstSeen { get { throw null; } }
        public System.DateTimeOffset? BlacklistCauseLastSeen { get { throw null; } }
        public long? BlacklistResourceCount { get { throw null; } }
        public System.DateTimeOffset? BlacklistResourceFirstSeen { get { throw null; } }
        public System.DateTimeOffset? BlacklistResourceLastSeen { get { throw null; } }
        public long? BlacklistSequenceCount { get { throw null; } }
        public System.DateTimeOffset? BlacklistSequenceFirstSeen { get { throw null; } }
        public System.DateTimeOffset? BlacklistSequenceLastSeen { get { throw null; } }
        public long? Count { get { throw null; } }
        public string Domain { get { throw null; } }
        public int? DomainMalwareReputationScore { get { throw null; } }
        public int? DomainPhishReputationScore { get { throw null; } }
        public int? DomainReputationScore { get { throw null; } }
        public int? DomainScamReputationScore { get { throw null; } }
        public int? DomainSpamReputationScore { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public string Host { get { throw null; } }
        public int? HostMalwareReputationScore { get { throw null; } }
        public int? HostPhishReputationScore { get { throw null; } }
        public int? HostReputationScore { get { throw null; } }
        public int? HostScamReputationScore { get { throw null; } }
        public int? HostSpamReputationScore { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public long? MalwareCauseCount { get { throw null; } }
        public long? MalwareResourceCount { get { throw null; } }
        public long? MalwareSequenceCount { get { throw null; } }
        public long? PhishCauseCount { get { throw null; } }
        public long? PhishResourceCount { get { throw null; } }
        public long? PhishSequenceCount { get { throw null; } }
        public long? ScamCauseCount { get { throw null; } }
        public long? ScamResourceCount { get { throw null; } }
        public long? ScamSequenceCount { get { throw null; } }
        public long? SpamCauseCount { get { throw null; } }
        public long? SpamResourceCount { get { throw null; } }
        public long? SpamSequenceCount { get { throw null; } }
        public string Uuid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostCore System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostCore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.HostCore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.HostCore System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostCore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostCore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.HostCore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InnerError>
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.Analytics.Defender.Easm.InnerError Innererror { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.InnerError System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InventoryAsset : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InventoryAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InventoryAsset>
    {
        internal InventoryAsset() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.InventoryAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InventoryAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.InventoryAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.InventoryAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InventoryAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InventoryAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.InventoryAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpAddressAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAsset>
    {
        internal IpAddressAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AttributeDetails> Attributes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.BannerDetails> Banners { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.CookieDetails> Cookies { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedHeader> Headers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Hosts { get { throw null; } }
        public string IpAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.IpBlock> IpBlocks { get { throw null; } }
        public bool? Ipv4 { get { throw null; } }
        public bool? Ipv6 { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLocation> Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> MxRecord { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> NetRanges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> NsRecord { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Nxdomain { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReputationDetails> Reputations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ScanMetadata> ScanMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetService> Services { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpAddressAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpAddressAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpAddressAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>
    {
        internal IpAddressAssetResource() { }
        public Azure.Analytics.Defender.Easm.IpAddressAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpAddressAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpAddressAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpAddressAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpBlock : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlock>
    {
        internal IpBlock() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public string IpBlockName { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlock System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlock System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpBlockAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAsset>
    {
        internal IpBlockAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> AdminPhones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> BgpPrefixes { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? DetailedFromWhoisAt { get { throw null; } }
        public string EndIp { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public string IpBlock { get { throw null; } }
        public bool? Ipv4 { get { throw null; } }
        public bool? Ipv6 { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLocation> Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> NetNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> NetRanges { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RegistrantPhones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarCreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarExpiresAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> RegistrarUpdatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReputationDetails> Reputations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public string StartIp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlockAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlockAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IpBlockAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>
    {
        internal IpBlockAssetResource() { }
        public Azure.Analytics.Defender.Easm.IpBlockAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlockAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.IpBlockAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.IpBlockAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsDataConnection : Azure.Analytics.Defender.Easm.DataConnection, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>
    {
        internal LogAnalyticsDataConnection() { }
        public Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsDataConnectionPayload : Azure.Analytics.Defender.Easm.DataConnectionPayload, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>
    {
        public LogAnalyticsDataConnectionPayload(Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties properties) { }
        public Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsDataConnectionProperties : Azure.Analytics.Defender.Easm.DataConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>
    {
        public LogAnalyticsDataConnectionProperties() { }
        public string ApiKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservationPageResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationPageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationPageResult>
    {
        internal ObservationPageResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, int> PrioritySummary { get { throw null; } }
        public long TotalElements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservationResult> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationPageResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationPageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationPageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationPageResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationPageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationPageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationPageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservationPriority : System.IEquatable<Azure.Analytics.Defender.Easm.ObservationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservationPriority(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationPriority High { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationPriority Low { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationPriority Medium { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationPriority None { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ObservationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ObservationPriority left, Azure.Analytics.Defender.Easm.ObservationPriority right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ObservationPriority (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ObservationPriority left, Azure.Analytics.Defender.Easm.ObservationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservationRemediationItem : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>
    {
        public ObservationRemediationItem(Azure.Analytics.Defender.Easm.ObservationType kind, string name, Azure.Analytics.Defender.Easm.ObservationRemediationState state) { }
        public Azure.Analytics.Defender.Easm.ObservationType Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservationRemediationState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationRemediationItem System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationRemediationItem System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationRemediationItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservationRemediationSource : System.IEquatable<Azure.Analytics.Defender.Easm.ObservationRemediationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservationRemediationSource(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationRemediationSource System { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationRemediationSource User { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ObservationRemediationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ObservationRemediationSource left, Azure.Analytics.Defender.Easm.ObservationRemediationSource right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ObservationRemediationSource (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ObservationRemediationSource left, Azure.Analytics.Defender.Easm.ObservationRemediationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservationRemediationState : System.IEquatable<Azure.Analytics.Defender.Easm.ObservationRemediationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservationRemediationState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationRemediationState Active { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationRemediationState NonApplicable { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ObservationRemediationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ObservationRemediationState left, Azure.Analytics.Defender.Easm.ObservationRemediationState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ObservationRemediationState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ObservationRemediationState left, Azure.Analytics.Defender.Easm.ObservationRemediationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservationResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationResult>
    {
        internal ObservationResult() { }
        public double CvssScoreV2 { get { throw null; } }
        public double CvssScoreV3 { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservationPriority Priority { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservationRemediationSource RemediationSource { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservationRemediationState RemediationState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservationType> Types { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservationResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservationType : System.IEquatable<Azure.Analytics.Defender.Easm.ObservationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservationType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservationType Cve { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservationType Insight { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ObservationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ObservationType left, Azure.Analytics.Defender.Easm.ObservationType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ObservationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ObservationType left, Azure.Analytics.Defender.Easm.ObservationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservedBoolean : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedBoolean>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedBoolean>
    {
        internal ObservedBoolean() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public bool? Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedBoolean System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedBoolean>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedBoolean>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedBoolean System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedBoolean>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedBoolean>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedBoolean>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedHeader : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedHeader>
    {
        internal ObservedHeader() { }
        public string HeaderName { get { throw null; } }
        public string HeaderValue { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedHeader System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedHeader System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedInteger : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedInteger>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedInteger>
    {
        internal ObservedInteger() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public int? Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedInteger System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedInteger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedInteger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedInteger System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedInteger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedInteger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedInteger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedIntegers : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedIntegers>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedIntegers>
    {
        internal ObservedIntegers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedIntegers System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedIntegers>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedIntegers>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedIntegers System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedIntegers>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedIntegers>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedIntegers>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedLocation : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocation>
    {
        internal ObservedLocation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservedLocationDetails Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLocation System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLocation System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedLocationDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>
    {
        internal ObservedLocationDetails() { }
        public int? AreaCode { get { throw null; } }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string CountryName { get { throw null; } }
        public int? DmaCode { get { throw null; } }
        public float? Latitude { get { throw null; } }
        public float? Longitude { get { throw null; } }
        public int? MetroCodeId { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public string Region { get { throw null; } }
        public string RegionName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLocationDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLocationDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLocationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedLong : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLong>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLong>
    {
        internal ObservedLong() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public long? Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLong System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLong>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedLong>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedLong System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLong>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLong>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedLong>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedPortState : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedPortState>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedPortState>
    {
        internal ObservedPortState() { }
        public int? Port { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservedPortStateValue? Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedPortState System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedPortState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedPortState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedPortState System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedPortState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedPortState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedPortState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ObservedPortStateValue : System.IEquatable<Azure.Analytics.Defender.Easm.ObservedPortStateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ObservedPortStateValue(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedPortStateValue Closed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservedPortStateValue Filtered { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ObservedPortStateValue Open { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ObservedPortStateValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ObservedPortStateValue left, Azure.Analytics.Defender.Easm.ObservedPortStateValue right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ObservedPortStateValue (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ObservedPortStateValue left, Azure.Analytics.Defender.Easm.ObservedPortStateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservedString : Azure.Analytics.Defender.Easm.ObservedValue, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedString>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedString>
    {
        internal ObservedString() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public string Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedString System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedString>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedString>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedString System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedString>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedString>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedString>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObservedValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedValue>
    {
        internal ObservedValue() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ObservedValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ObservedValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ObservedValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PageAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAsset>
    {
        internal PageAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> AssetSecurityPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AttributeDetails> Attributes { get { throw null; } }
        public Azure.Analytics.Defender.Easm.PageCause Cause { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cdns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Charsets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cnames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> ContentLengths { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ContentTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.CookieDetails> Cookies { get { throw null; } }
        public long? Count { get { throw null; } }
        public string Domain { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DomainAsset DomainAsset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Errors { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> FinalAsns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> FinalIpAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.IpBlock> FinalIpBlocks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedInteger> FinalResponseCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> FinalUrls { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Frames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedIntegers> FullDomMinhashSignatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> GdprAssetSecurityPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.GuidPair> Guids { get { throw null; } }
        public string Host { get { throw null; } }
        public string HttpMethod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedInteger> HttpResponseCodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> HttpResponseMessages { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> IpAddresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.IpBlock> IpBlocks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Ipv4 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Ipv6 { get { throw null; } }
        public bool? IsRootUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Languages { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLocation> Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> NonHtmlFrames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> ParkedPage { get { throw null; } }
        public Azure.Analytics.Defender.Easm.PageAssetRedirectType? RedirectType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> RedirectUrls { get { throw null; } }
        public string Referrer { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ResourceUri> ResourceUrls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodyHashSignatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedIntegers> ResponseBodyMinhashSignatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedHeader> ResponseHeaders { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> ResponseTimes { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservedBoolean RootUrl { get { throw null; } }
        public string Service { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetService> Services { get { throw null; } }
        public string SiteStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Successful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Titles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> UndirectedContent { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> WindowNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Windows { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PageAssetRedirectType : System.IEquatable<Azure.Analytics.Defender.Easm.PageAssetRedirectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PageAssetRedirectType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageAssetRedirectType Final { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PageAssetRedirectType HttpHeader { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PageAssetRedirectType Javascript { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PageAssetRedirectType MetaRefresh { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.PageAssetRedirectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.PageAssetRedirectType left, Azure.Analytics.Defender.Easm.PageAssetRedirectType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.PageAssetRedirectType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.PageAssetRedirectType left, Azure.Analytics.Defender.Easm.PageAssetRedirectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PageAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAssetResource>
    {
        internal PageAssetResource() { }
        public Azure.Analytics.Defender.Easm.PageAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PageCause : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageCause>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageCause>
    {
        internal PageCause() { }
        public string Cause { get { throw null; } }
        public string CauseElementXPath { get { throw null; } }
        public int? DomChangeIndex { get { throw null; } }
        public string Location { get { throw null; } }
        public bool? LoopDetected { get { throw null; } }
        public int? PossibleMatches { get { throw null; } }
        public int? Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageCause System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageCause>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PageCause>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PageCause System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageCause>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageCause>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PageCause>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Policy : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Policy>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Policy>
    {
        public Policy(string filterName, Azure.Analytics.Defender.Easm.PolicyAction action, Azure.Analytics.Defender.Easm.ActionParameters actionParameters) { }
        public Azure.Analytics.Defender.Easm.PolicyAction Action { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.ActionParameters ActionParameters { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } }
        public string FilterName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public long? UpdatedAssetsCount { get { throw null; } }
        public System.DateTimeOffset? UpdatedDate { get { throw null; } }
        public string User { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.Policy System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Policy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.Policy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.Policy System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Policy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Policy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.Policy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyAction : System.IEquatable<Azure.Analytics.Defender.Easm.PolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyAction(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.PolicyAction AddResource { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PolicyAction RemoveFromInventory { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PolicyAction RemoveResource { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PolicyAction SetExternalID { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.PolicyAction SetState { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.PolicyAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.PolicyAction left, Azure.Analytics.Defender.Easm.PolicyAction right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.PolicyAction (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.PolicyAction left, Azure.Analytics.Defender.Easm.PolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PortDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PortDetails>
    {
        internal PortDetails() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? PortName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PortDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PortDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.PortDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.PortDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PortDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PortDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.PortDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportAssetSnapshotExportPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>
    {
        public ReportAssetSnapshotExportPayload() { }
        public System.Collections.Generic.IList<string> Columns { get { throw null; } }
        public string FileName { get { throw null; } set { } }
        public string Metric { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotExportPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportAssetSnapshotPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>
    {
        public ReportAssetSnapshotPayload() { }
        public string LabelName { get { throw null; } set { } }
        public string Metric { get { throw null; } set { } }
        public int? Page { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportAssetSnapshotResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>
    {
        internal ReportAssetSnapshotResult() { }
        public Azure.Analytics.Defender.Easm.AssetPageResult Assets { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string LabelName { get { throw null; } }
        public string Metric { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportAssetSummaryPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>
    {
        public ReportAssetSummaryPayload() { }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public string GroupBy { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MetricCategories { get { throw null; } }
        public System.Collections.Generic.IList<string> Metrics { get { throw null; } }
        public string SegmentBy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportAssetSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>
    {
        internal ReportAssetSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSummaryResult> AssetSummaries { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportAssetSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportBillableAssetBreakdown : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>
    {
        internal ReportBillableAssetBreakdown() { }
        public long? Count { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind? Kind { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportBillableAssetBreakdownKind : System.IEquatable<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportBillableAssetBreakdownKind(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind IpAddress { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind left, Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind left, Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReportBillableAssetSnapshotResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>
    {
        internal ReportBillableAssetSnapshotResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown> AssetBreakdown { get { throw null; } }
        public System.DateTimeOffset? Date { get { throw null; } }
        public long? Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReportBillableAssetSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>
    {
        internal ReportBillableAssetSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult> AssetSummaries { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReputationDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReputationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReputationDetails>
    {
        internal ReputationDetails() { }
        public string Cidr { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string ListName { get { throw null; } }
        public System.DateTimeOffset? ListUpdatedAt { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string ThreatType { get { throw null; } }
        public bool? Trusted { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReputationDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReputationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ReputationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ReputationDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReputationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReputationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ReputationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceUri : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ResourceUri>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ResourceUri>
    {
        internal ResourceUri() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DependentResource> Resources { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ResourceUri System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ResourceUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ResourceUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ResourceUri System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ResourceUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ResourceUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ResourceUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavedFilter : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilter>
    {
        internal SavedFilter() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Filter { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SavedFilter System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SavedFilter System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SavedFilterPayload : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>
    {
        public SavedFilterPayload(string filter, string description) { }
        public string Description { get { throw null; } }
        public string Filter { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SavedFilterPayload System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SavedFilterPayload System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SavedFilterPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScanMetadata : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ScanMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ScanMetadata>
    {
        internal ScanMetadata() { }
        public string BannerMetadata { get { throw null; } }
        public System.DateTimeOffset? EndScan { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.DateTimeOffset? StartScan { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ScanMetadata System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ScanMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ScanMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ScanMetadata System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ScanMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ScanMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ScanMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SoaRecord : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SoaRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SoaRecord>
    {
        internal SoaRecord() { }
        public long? Count { get { throw null; } }
        public string Email { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string NameServer { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public long? SerialNumber { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SoaRecord System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SoaRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SoaRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SoaRecord System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SoaRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SoaRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SoaRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SourceDetails>
    {
        internal SourceDetails() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SourceName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SourceDetails System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SslCertAsset : Azure.Analytics.Defender.Easm.InventoryAsset, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAsset>
    {
        internal SslCertAsset() { }
        public bool? CertificateAuthority { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? InvalidAfter { get { throw null; } }
        public System.DateTimeOffset? InvalidBefore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerAlternativeNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerCommonNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerCountry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerLocality { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerOrganizationalUnits { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerOrganizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IssuerState { get { throw null; } }
        public string KeyAlgorithm { get { throw null; } }
        public int? KeySize { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OrganizationalUnits { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Organizations { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public bool? SelfSigned { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public string Sha1 { get { throw null; } }
        public string SigAlgName { get { throw null; } }
        public string SigAlgOid { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectAlternativeNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectCommonNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectCountry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectLocality { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectOrganizationalUnits { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectOrganizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectState { get { throw null; } }
        public Azure.Analytics.Defender.Easm.SslCertAssetValidationType? ValidationType { get { throw null; } }
        public int? Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslCertAsset System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslCertAsset System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SslCertAssetResource : Azure.Analytics.Defender.Easm.AssetResource, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>
    {
        internal SslCertAssetResource() { }
        public Azure.Analytics.Defender.Easm.SslCertAsset Asset { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslCertAssetResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslCertAssetResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslCertAssetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SslCertAssetValidationType : System.IEquatable<Azure.Analytics.Defender.Easm.SslCertAssetValidationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SslCertAssetValidationType(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslCertAssetValidationType DomainValidation { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.SslCertAssetValidationType ExtendedValidation { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.SslCertAssetValidationType OrganizationValidation { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.SslCertAssetValidationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.SslCertAssetValidationType left, Azure.Analytics.Defender.Easm.SslCertAssetValidationType right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.SslCertAssetValidationType (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.SslCertAssetValidationType left, Azure.Analytics.Defender.Easm.SslCertAssetValidationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SslServerConfig : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslServerConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslServerConfig>
    {
        internal SslServerConfig() { }
        public System.Collections.Generic.IReadOnlyList<string> CipherSuites { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TlsVersions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslServerConfig System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslServerConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SslServerConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SslServerConfig System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslServerConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslServerConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SslServerConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubResourceIntegrityCheck : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>
    {
        internal SubResourceIntegrityCheck() { }
        public string CausePageUrl { get { throw null; } }
        public long? Count { get { throw null; } }
        public string CrawlGuid { get { throw null; } }
        public string ExpectedHash { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string PageGuid { get { throw null; } }
        public string ResourceGuid { get { throw null; } }
        public bool? Violation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskResource : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.TaskResource>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.TaskResource>
    {
        internal TaskResource() { }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastPolledAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public Azure.Analytics.Defender.Easm.TaskResourcePhase? Phase { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.Analytics.Defender.Easm.TaskResourceState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.TaskResource System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.TaskResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.TaskResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.TaskResource System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.TaskResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.TaskResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.TaskResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskResourcePhase : System.IEquatable<Azure.Analytics.Defender.Easm.TaskResourcePhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskResourcePhase(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.TaskResourcePhase Complete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourcePhase Polling { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourcePhase Running { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.TaskResourcePhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.TaskResourcePhase left, Azure.Analytics.Defender.Easm.TaskResourcePhase right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.TaskResourcePhase (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.TaskResourcePhase left, Azure.Analytics.Defender.Easm.TaskResourcePhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskResourceState : System.IEquatable<Azure.Analytics.Defender.Easm.TaskResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskResourceState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Complete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Failed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Incomplete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Paused { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Pending { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Running { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskResourceState Warning { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.TaskResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.TaskResourceState left, Azure.Analytics.Defender.Easm.TaskResourceState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.TaskResourceState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.TaskResourceState left, Azure.Analytics.Defender.Easm.TaskResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ValidateResult>
    {
        internal ValidateResult() { }
        public Azure.Analytics.Defender.Easm.ErrorDetail Error { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ValidateResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.ValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.ValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.ValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebComponent : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.WebComponent>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.WebComponent>
    {
        internal WebComponent() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.CveDetails> Cve { get { throw null; } }
        public long? EndOfLife { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.PortDetails> Ports { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RuleId { get { throw null; } }
        public string Service { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SourceDetails> Sources { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.WebComponent System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.WebComponent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.Defender.Easm.WebComponent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.Defender.Easm.WebComponent System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.WebComponent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.WebComponent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.Defender.Easm.WebComponent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsDefenderEasmClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Defender.Easm.EasmClient, Azure.Analytics.Defender.Easm.EasmClientOptions> AddEasmClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.Defender.Easm.EasmClient, Azure.Analytics.Defender.Easm.EasmClientOptions> AddEasmClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
