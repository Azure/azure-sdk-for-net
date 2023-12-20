namespace Azure.Analytics.Defender.Easm
{
    public partial class AlexaInfo
    {
        internal AlexaInfo() { }
        public long? AlexaRank { get { throw null; } }
        public string Category { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
    }
    public static partial class AnalyticsDefenderEasmModelFactory
    {
        public static Azure.Analytics.Defender.Easm.AlexaInfo AlexaInfo(long? alexaRank = default(long?), string category = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AsAsset AsAsset(long? asn = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> asNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> orgNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> orgIds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> countries = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registries = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrarNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AsAssetResource AsAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.AsAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetPageResult AssetPageResult(long? totalElements = default(long?), string mark = null, string nextLink = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetResource> value = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetResource AssetResource(string kind = null, string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetSecurityPolicy AssetSecurityPolicy(string policyName = null, bool? isAffected = default(bool?), string description = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AssetSummaryResult AssetSummaryResult(string displayName = null, string description = null, System.DateTimeOffset? updatedAt = default(System.DateTimeOffset?), string metricCategory = null, string metric = null, string filter = null, string labelName = null, long? count = default(long?), string link = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSummaryResult> children = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Attribute Attribute(string attributeType = null, string attributeValue = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.AuditTrailItem AuditTrailItem(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.AuditTrailItemKind? kind = default(Azure.Analytics.Defender.Easm.AuditTrailItemKind?), string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnection AzureDataExplorerDataConnection(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null, Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Banner Banner(int? port = default(int?), string bannerProperty = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string scanType = null, string bannerMetadata = null, bool? recent = default(bool?), string sha256 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ContactAsset ContactAsset(string email = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> names = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> organizations = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ContactAssetResource ContactAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.ContactAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Cookie Cookie(string cookieName = null, string cookieDomain = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.DateTimeOffset? cookieExpiryDate = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.Cve Cve(string name = null, string cweId = null, float? cvssScore = default(float?), Azure.Analytics.Defender.Easm.Cvss3Summary cvss3Summary = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Cvss3Summary Cvss3Summary(string version = null, string vectorString = null, string attackVector = null, string attackComplexity = null, string privilegesRequired = null, string userInteraction = null, string scope = null, string confidentialityImpact = null, string integrityImpact = null, string availabilityImpact = null, float? baseScore = default(float?), string baseSeverity = null, string exploitCodeMaturity = null, string remediationLevel = null, string reportConfidence = null, float? exploitabilityScore = default(float?), float? impactScore = default(float?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.DataConnection DataConnection(string kind = null, string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DependentResource DependentResource(string md5 = null, long? responseBodySize = default(long?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string firstSeenCrawlGuid = null, string firstSeenPageGuid = null, string firstSeenResourceGuid = null, string lastSeenCrawlGuid = null, string lastSeenPageGuid = null, string lastSeenResourceGuid = null, System.Collections.Generic.IEnumerable<int> responseBodyMinhash = null, string contentType = null, string sha256 = null, string sha384 = null, string sha512 = null, System.Uri url = null, bool? cached = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck> sriChecks = null, string host = null, System.DateTimeOffset? lastObservedViolation = default(System.DateTimeOffset?), System.DateTimeOffset? lastObservedValidation = default(System.DateTimeOffset?), string lastObservedActualSriHash = null, string lastObservedExpectedSriHash = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoGroup DiscoGroup(string id = null, string name = null, string displayName = null, string description = null, string tier = null, long? frequencyMilliseconds = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoSource> seeds = null, System.Collections.Generic.IEnumerable<string> names = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoSource> excludes = null, Azure.Analytics.Defender.Easm.DiscoRunResult latestRun = null, System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), string templateId = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoRunResult DiscoRunResult(System.DateTimeOffset? submittedDate = default(System.DateTimeOffset?), System.DateTimeOffset? startedDate = default(System.DateTimeOffset?), System.DateTimeOffset? completedDate = default(System.DateTimeOffset?), string tier = null, Azure.Analytics.Defender.Easm.DiscoRunState? state = default(Azure.Analytics.Defender.Easm.DiscoRunState?), long? totalAssetsFoundCount = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoSource> seeds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoSource> excludes = null, System.Collections.Generic.IEnumerable<string> names = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoTemplate DiscoTemplate(string id = null, string name = null, string displayName = null, string industry = null, string region = null, string countryCode = null, string stateCode = null, string city = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DiscoSource> seeds = null, System.Collections.Generic.IEnumerable<string> names = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DomainAsset DomainAsset(string domain = null, long? whoisId = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> registrarIanaIds = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AlexaInfo> alexaInfos = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> nameServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> mailServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> whoisServers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> domainStatuses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarExpiresAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SoaRecord> soaRecords = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrarNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> parkedDomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.DomainAssetResource DomainAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.DomainAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ErrorDetail ErrorDetail(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ErrorDetail> details = null, Azure.Analytics.Defender.Easm.InnerError innererror = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.GuidPair GuidPair(string pageGuid = null, string crawlStateGuid = null, System.DateTimeOffset? loadDate = default(System.DateTimeOffset?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostAsset HostAsset(string host = null, string domain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> ipAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> headers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Attribute> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Cookie> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> parentHosts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> childHosts = null, Azure.Analytics.Defender.Easm.HostCore hostCore = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Service> services = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cnames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ResourceUrl> resourceUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ScanMetadata> scanMetadata = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodies = null, Azure.Analytics.Defender.Easm.DomainAsset domainAsset = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nsRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> mxRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> webserver = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nxdomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> isWildcard = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Banner> banners = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv4 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv6 = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostAssetResource HostAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.HostAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.HostCore HostCore(string host = null, string domain = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.DateTimeOffset? blacklistCauseFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistCauseLastSeen = default(System.DateTimeOffset?), long? blacklistCauseCount = default(long?), System.DateTimeOffset? blacklistResourceFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistResourceLastSeen = default(System.DateTimeOffset?), long? blacklistResourceCount = default(long?), System.DateTimeOffset? blacklistSequenceFirstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? blacklistSequenceLastSeen = default(System.DateTimeOffset?), long? blacklistSequenceCount = default(long?), long? phishCauseCount = default(long?), long? malwareCauseCount = default(long?), long? spamCauseCount = default(long?), long? scamCauseCount = default(long?), long? phishResourceCount = default(long?), long? malwareResourceCount = default(long?), long? spamResourceCount = default(long?), long? scamResourceCount = default(long?), long? phishSequenceCount = default(long?), long? malwareSequenceCount = default(long?), long? spamSequenceCount = default(long?), long? scamSequenceCount = default(long?), int? alexaRank = default(int?), int? hostReputationScore = default(int?), int? hostPhishReputationScore = default(int?), int? hostMalwareReputationScore = default(int?), int? hostSpamReputationScore = default(int?), int? hostScamReputationScore = default(int?), int? domainReputationScore = default(int?), int? domainPhishReputationScore = default(int?), int? domainMalwareReputationScore = default(int?), int? domainSpamReputationScore = default(int?), int? domainScamReputationScore = default(int?), string uuid = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.InnerError InnerError(string code = null, System.BinaryData value = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpAddressAsset IpAddressAsset(string ipAddress = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Reputation> reputations = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netRanges = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> headers = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Attribute> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Cookie> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Service> services = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Banner> banners = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ScanMetadata> scanMetadata = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nsRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> mxRecord = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> hosts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nxdomain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, bool? ipv4 = default(bool?), bool? ipv6 = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpAddressAssetResource IpAddressAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.IpAddressAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlock IpBlock(string ipBlockProperty = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlockAsset IpBlockAsset(string ipBlock = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> bgpPrefixes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalContacts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarCreatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarUpdatedAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> netRanges = null, string startIp = null, string endIp = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Reputation> reputations = null, System.DateTimeOffset? detailedFromWhoisAt = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> registrarExpiresAt = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalOrgs = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> registrantPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> adminPhones = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> technicalPhones = null, bool? ipv4 = default(bool?), bool? ipv6 = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.IpBlockAssetResource IpBlockAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.IpBlockAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Location Location(string countryCode = null, string countryName = null, string region = null, string regionName = null, string city = null, int? areaCode = default(int?), string postalCode = null, float? latitude = default(float?), float? longitude = default(float?), int? dmaCode = default(int?), int? metroCodeId = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.LogAnalyticsDataConnection LogAnalyticsDataConnection(string id = null, string name = null, string displayName = null, Azure.Analytics.Defender.Easm.DataConnectionContent? content = default(Azure.Analytics.Defender.Easm.DataConnectionContent?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.DataConnectionFrequency? frequency = default(Azure.Analytics.Defender.Easm.DataConnectionFrequency?), int? frequencyOffset = default(int?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), System.DateTimeOffset? userUpdatedAt = default(System.DateTimeOffset?), bool? active = default(bool?), string inactiveMessage = null, Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties properties = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedBoolean ObservedBoolean(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), bool? value = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedHeader ObservedHeader(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), string headerName = null, string headerValue = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedInteger ObservedInteger(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), int? value = default(int?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedIntegers ObservedIntegers(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<int> values = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedLocation ObservedLocation(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), Azure.Analytics.Defender.Easm.Location value = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedLong ObservedLong(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), long? value = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedPortState ObservedPortState(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), Azure.Analytics.Defender.Easm.ObservedPortStateValue? value = default(Azure.Analytics.Defender.Easm.ObservedPortStateValue?), int? port = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ObservedString ObservedString(System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), string value = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageAsset PageAsset(System.Uri url = null, string httpMethod = null, string service = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> ipAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> successful = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> httpResponseCodes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> httpResponseMessages = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> responseTimes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> frames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> windows = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> nonHtmlFrames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> undirectedContent = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> contentTypes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> contentLengths = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> windowNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> charsets = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> titles = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> languages = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedHeader> responseHeaders = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Cookie> cookies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Attribute> attributes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> assetSecurityPolicies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedIntegers> responseBodyMinhashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedIntegers> fullDomMinhashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodyHashSignatures = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> errors = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), Azure.Analytics.Defender.Easm.PageCause cause = null, string referrer = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> redirectUrls = null, Azure.Analytics.Defender.Easm.PageAssetRedirectType? redirectType = default(Azure.Analytics.Defender.Easm.PageAssetRedirectType?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> finalUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedInteger> finalResponseCodes = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> parkedPage = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ResourceUrl> resourceUrls = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.GuidPair> guids = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> finalIpAddresses = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> asns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> ipBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLong> finalAsns = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.IpBlock> finalIpBlocks = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> responseBodies = null, Azure.Analytics.Defender.Easm.DomainAsset domainAsset = null, Azure.Analytics.Defender.Easm.ObservedBoolean rootUrl = null, bool? isRootUrl = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedLocation> location = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Service> services = null, string siteStatus = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cnames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> cdns = null, string host = null, string domain = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslServerConfig> sslServerConfig = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> gdprAssetSecurityPolicies = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv4 = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedBoolean> ipv6 = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageAssetResource PageAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.PageAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.PageCause PageCause(string cause = null, string causeElementXPath = null, string location = null, int? possibleMatches = default(int?), bool? loopDetected = default(bool?), int? version = default(int?), int? domChangeIndex = default(int?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.Port Port(int? portProperty = default(int?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult ReportAssetSnapshotResult(string displayName = null, string metric = null, string labelName = null, System.DateTimeOffset? updatedAt = default(System.DateTimeOffset?), string description = null, Azure.Analytics.Defender.Easm.AssetPageResult assets = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportAssetSummaryResult ReportAssetSummaryResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AssetSummaryResult> assetSummaries = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown ReportBillableAssetBreakdown(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind? kind = default(Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind?), long? count = default(long?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult ReportBillableAssetSnapshotResult(System.DateTimeOffset? date = default(System.DateTimeOffset?), long? total = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown> assetBreakdown = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult ReportBillableAssetSummaryResult(System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult> assetSummaries = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Reputation Reputation(string listName = null, string threatType = null, bool? trusted = default(bool?), string cidr = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), System.DateTimeOffset? listUpdatedAt = default(System.DateTimeOffset?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.ResourceUrl ResourceUrl(System.Uri url = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.DependentResource> resources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SavedFilter SavedFilter(string id = null, string name = null, string displayName = null, string filter = null, string description = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ScanMetadata ScanMetadata(int? port = default(int?), string bannerMetadata = null, System.DateTimeOffset? startScan = default(System.DateTimeOffset?), System.DateTimeOffset? endScan = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.Service Service(string scheme = null, int? port = default(int?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.WebComponent> webComponents = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.SslCertAsset> sslCerts = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedString> exceptions = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.ObservedPortState> portStates = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SoaRecord SoaRecord(string nameServer = null, string email = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), long? serialNumber = default(long?), bool? recent = default(bool?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.Source Source(string sourceProperty = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string reason = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslCertAsset SslCertAsset(string sha1 = null, System.Collections.Generic.IEnumerable<string> subjectCommonNames = null, System.Collections.Generic.IEnumerable<string> organizations = null, System.Collections.Generic.IEnumerable<string> organizationalUnits = null, System.Collections.Generic.IEnumerable<string> issuerCommonNames = null, string sigAlgName = null, System.DateTimeOffset? invalidAfter = default(System.DateTimeOffset?), string serialNumber = null, System.Collections.Generic.IEnumerable<string> subjectAlternativeNames = null, System.Collections.Generic.IEnumerable<string> issuerAlternativeNames = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.DateTimeOffset? invalidBefore = default(System.DateTimeOffset?), int? keySize = default(int?), string keyAlgorithm = null, System.Collections.Generic.IEnumerable<string> subjectLocality = null, System.Collections.Generic.IEnumerable<string> subjectState = null, System.Collections.Generic.IEnumerable<string> subjectCountry = null, System.Collections.Generic.IEnumerable<string> issuerLocality = null, System.Collections.Generic.IEnumerable<string> issuerState = null, System.Collections.Generic.IEnumerable<string> issuerCountry = null, System.Collections.Generic.IEnumerable<string> subjectOrganizations = null, System.Collections.Generic.IEnumerable<string> subjectOrganizationalUnits = null, System.Collections.Generic.IEnumerable<string> issuerOrganizations = null, System.Collections.Generic.IEnumerable<string> issuerOrganizationalUnits = null, int? version = default(int?), bool? certificateAuthority = default(bool?), bool? selfSigned = default(bool?), string sigAlgOid = null, bool? recent = default(bool?), Azure.Analytics.Defender.Easm.SslCertAssetValidationType? validationType = default(Azure.Analytics.Defender.Easm.SslCertAssetValidationType?)) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslCertAssetResource SslCertAssetResource(string id = null, string name = null, string displayName = null, System.Guid? uuid = default(System.Guid?), System.DateTimeOffset? createdDate = default(System.DateTimeOffset?), System.DateTimeOffset? updatedDate = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.AssetState? state = default(Azure.Analytics.Defender.Easm.AssetState?), string externalId = null, System.Collections.Generic.IEnumerable<string> labels = null, bool? wildcard = default(bool?), string discoGroupName = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.AuditTrailItem> auditTrail = null, string reason = null, Azure.Analytics.Defender.Easm.SslCertAsset asset = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SslServerConfig SslServerConfig(System.Collections.Generic.IEnumerable<string> tlsVersions = null, System.Collections.Generic.IEnumerable<string> cipherSuites = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.SubResourceIntegrityCheck SubResourceIntegrityCheck(bool? violation = default(bool?), System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), string causePageUrl = null, string crawlGuid = null, string pageGuid = null, string resourceGuid = null, string expectedHash = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.Task Task(string id = null, System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastPolledAt = default(System.DateTimeOffset?), Azure.Analytics.Defender.Easm.TaskState? state = default(Azure.Analytics.Defender.Easm.TaskState?), Azure.Analytics.Defender.Easm.TaskPhase? phase = default(Azure.Analytics.Defender.Easm.TaskPhase?), string reason = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> metadata = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.ValidateResult ValidateResult(Azure.Analytics.Defender.Easm.ErrorDetail error = null) { throw null; }
        public static Azure.Analytics.Defender.Easm.WebComponent WebComponent(string name = null, string type = null, string version = null, System.Collections.Generic.IEnumerable<string> ruleId = null, System.DateTimeOffset? firstSeen = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeen = default(System.DateTimeOffset?), long? count = default(long?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Cve> cve = null, long? endOfLife = default(long?), bool? recent = default(bool?), System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Port> ports = null, System.Collections.Generic.IEnumerable<Azure.Analytics.Defender.Easm.Source> sources = null, string service = null) { throw null; }
    }
    public partial class AsAsset : Azure.Analytics.Defender.Easm.InventoryAsset
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
    }
    public partial class AsAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal AsAssetResource() { }
        public Azure.Analytics.Defender.Easm.AsAsset Asset { get { throw null; } }
    }
    public partial class AssetPageResult
    {
        internal AssetPageResult() { }
        public string Mark { get { throw null; } }
        public string NextLink { get { throw null; } }
        public long? TotalElements { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetResource> Value { get { throw null; } }
    }
    public abstract partial class AssetResource
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
    }
    public partial class Assets
    {
        protected Assets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetAssetResource(string assetId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResource(string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssetResourceAsync(string assetId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.AssetResource>> GetAssetResourceAsync(string assetId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAssetResources(string filter, string orderby, int? skip, int? maxpagesize, string mark, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResources(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), string mark = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAssetResourcesAsync(string filter, string orderby, int? skip, int? maxpagesize, string mark, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.AssetResource> GetAssetResourcesAsync(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), string mark = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.Task> UpdateAssets(string filter, Azure.Analytics.Defender.Easm.AssetUpdateData assetUpdateData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAssets(string filter, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.Task>> UpdateAssetsAsync(string filter, Azure.Analytics.Defender.Easm.AssetUpdateData assetUpdateData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAssetsAsync(string filter, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AssetSecurityPolicy
    {
        internal AssetSecurityPolicy() { }
        public long? Count { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public bool? IsAffected { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
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
    public partial class AssetSummaryResult
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
    }
    public partial class AssetUpdateData
    {
        public AssetUpdateData() { }
        public string ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, bool> Labels { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AssetUpdateState? State { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.AssetUpdateTransfers? Transfers { get { throw null; } set { } }
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
    public partial class Attribute
    {
        internal Attribute() { }
        public string AttributeType { get { throw null; } }
        public string AttributeValue { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
    }
    public partial class AuditTrailItem
    {
        internal AuditTrailItem() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Analytics.Defender.Easm.AuditTrailItemKind? Kind { get { throw null; } }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
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
    public partial class AzureDataExplorerDataConnection : Azure.Analytics.Defender.Easm.DataConnection
    {
        internal AzureDataExplorerDataConnection() { }
        public Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties Properties { get { throw null; } }
    }
    public partial class AzureDataExplorerDataConnectionData : Azure.Analytics.Defender.Easm.DataConnectionData
    {
        public AzureDataExplorerDataConnectionData(Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties properties) { }
        public Azure.Analytics.Defender.Easm.AzureDataExplorerDataConnectionProperties Properties { get { throw null; } }
    }
    public partial class AzureDataExplorerDataConnectionProperties : Azure.Analytics.Defender.Easm.DataConnectionProperties
    {
        public AzureDataExplorerDataConnectionProperties() { }
        public string ClusterName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
    }
    public partial class Banner
    {
        internal Banner() { }
        public string BannerMetadata { get { throw null; } }
        public string BannerProperty { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? Port { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string ScanType { get { throw null; } }
        public string Sha256 { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
    }
    public partial class ContactAsset : Azure.Analytics.Defender.Easm.InventoryAsset
    {
        internal ContactAsset() { }
        public long? Count { get { throw null; } }
        public string Email { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Organizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
    }
    public partial class ContactAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal ContactAssetResource() { }
        public Azure.Analytics.Defender.Easm.ContactAsset Asset { get { throw null; } }
    }
    public partial class Cookie
    {
        internal Cookie() { }
        public string CookieDomain { get { throw null; } }
        public System.DateTimeOffset? CookieExpiryDate { get { throw null; } }
        public string CookieName { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
    }
    public partial class Cve
    {
        internal Cve() { }
        public Azure.Analytics.Defender.Easm.Cvss3Summary Cvss3Summary { get { throw null; } }
        public float? CvssScore { get { throw null; } }
        public string CweId { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class Cvss3Summary
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
    }
    public abstract partial class DataConnection
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
    public abstract partial class DataConnectionData
    {
        protected DataConnectionData() { }
        public Azure.Analytics.Defender.Easm.DataConnectionContent? Content { get { throw null; } set { } }
        public Azure.Analytics.Defender.Easm.DataConnectionFrequency? Frequency { get { throw null; } set { } }
        public int? FrequencyOffset { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
    public partial class DataConnectionProperties
    {
        internal DataConnectionProperties() { }
    }
    public partial class DataConnections
    {
        protected DataConnections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DataConnection> CreateOrReplaceDataConnection(string dataConnectionName, Azure.Analytics.Defender.Easm.DataConnectionData dataConnectionData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceDataConnection(string dataConnectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DataConnection>> CreateOrReplaceDataConnectionAsync(string dataConnectionName, Azure.Analytics.Defender.Easm.DataConnectionData dataConnectionData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceDataConnectionAsync(string dataConnectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDataConnection(string dataConnectionName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataConnectionAsync(string dataConnectionName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDataConnection(string dataConnectionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDataConnectionAsync(string dataConnectionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DataConnection>> GetDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDataConnections(int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnections(int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDataConnectionsAsync(int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DataConnection> GetDataConnectionsAsync(int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult> ValidateDataConnection(Azure.Analytics.Defender.Easm.DataConnectionData dataConnectionData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateDataConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult>> ValidateDataConnectionAsync(Azure.Analytics.Defender.Easm.DataConnectionData dataConnectionData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateDataConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DependentResource
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
    }
    public partial class DiscoGroup
    {
        internal DiscoGroup() { }
        public System.DateTimeOffset? CreatedDate { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoSource> Excludes { get { throw null; } }
        public long? FrequencyMilliseconds { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DiscoRunResult LatestRun { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoSource> Seeds { get { throw null; } }
        public string TemplateId { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class DiscoGroupData
    {
        public DiscoGroupData() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Analytics.Defender.Easm.DiscoSource> Excludes { get { throw null; } }
        public long? FrequencyMilliseconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Names { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Analytics.Defender.Easm.DiscoSource> Seeds { get { throw null; } }
        public string TemplateId { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class DiscoRunResult
    {
        internal DiscoRunResult() { }
        public System.DateTimeOffset? CompletedDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoSource> Excludes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoSource> Seeds { get { throw null; } }
        public System.DateTimeOffset? StartedDate { get { throw null; } }
        public Azure.Analytics.Defender.Easm.DiscoRunState? State { get { throw null; } }
        public System.DateTimeOffset? SubmittedDate { get { throw null; } }
        public string Tier { get { throw null; } }
        public long? TotalAssetsFoundCount { get { throw null; } }
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
    public partial class DiscoSource
    {
        public DiscoSource() { }
        public Azure.Analytics.Defender.Easm.DiscoSourceKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoSourceKind : System.IEquatable<Azure.Analytics.Defender.Easm.DiscoSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoSourceKind(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind As { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind Attribute { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind Contact { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind Domain { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind Host { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.DiscoSourceKind IpBlock { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.DiscoSourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.DiscoSourceKind left, Azure.Analytics.Defender.Easm.DiscoSourceKind right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.DiscoSourceKind (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.DiscoSourceKind left, Azure.Analytics.Defender.Easm.DiscoSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoTemplate
    {
        internal DiscoTemplate() { }
        public string City { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public string Industry { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
        public string Region { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DiscoSource> Seeds { get { throw null; } }
        public string StateCode { get { throw null; } }
    }
    public partial class DiscoveryGroups
    {
        protected DiscoveryGroups() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoGroup> CreateOrReplaceDiscoGroup(string groupName, Azure.Analytics.Defender.Easm.DiscoGroupData discoGroupData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceDiscoGroup(string groupName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoGroup>> CreateOrReplaceDiscoGroupAsync(string groupName, Azure.Analytics.Defender.Easm.DiscoGroupData discoGroupData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceDiscoGroupAsync(string groupName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDiscoGroup(string groupName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoGroup> GetDiscoGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoGroupAsync(string groupName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoGroup>> GetDiscoGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiscoGroups(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoGroup> GetDiscoGroups(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiscoGroupsAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoGroup> GetDiscoGroupsAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetRuns(string groupName, string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoRunResult> GetRuns(string groupName, string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetRunsAsync(string groupName, string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoRunResult> GetRunsAsync(string groupName, string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RunDiscoGroup(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunDiscoGroupAsync(string groupName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult> ValidateDiscoGroup(Azure.Analytics.Defender.Easm.DiscoGroupData discoGroupData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateDiscoGroup(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ValidateResult>> ValidateDiscoGroupAsync(Azure.Analytics.Defender.Easm.DiscoGroupData discoGroupData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateDiscoGroupAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiscoveryTemplates
    {
        protected DiscoveryTemplates() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetDiscoTemplate(string templateId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.DiscoTemplate> GetDiscoTemplate(string templateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoTemplateAsync(string templateId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.DiscoTemplate>> GetDiscoTemplateAsync(string templateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiscoTemplates(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.DiscoTemplate> GetDiscoTemplates(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiscoTemplatesAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.DiscoTemplate> GetDiscoTemplatesAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainAsset : Azure.Analytics.Defender.Easm.InventoryAsset
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
        public long? WhoisId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> WhoisServers { get { throw null; } }
    }
    public partial class DomainAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal DomainAssetResource() { }
        public Azure.Analytics.Defender.Easm.DomainAsset Asset { get { throw null; } }
    }
    public partial class EasmClient
    {
        protected EasmClient() { }
        public EasmClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public EasmClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.Defender.Easm.EasmClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Analytics.Defender.Easm.Assets GetAssetsClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.DataConnections GetDataConnectionsClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.DiscoveryGroups GetDiscoveryGroupsClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.DiscoveryTemplates GetDiscoveryTemplatesClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.Reports GetReportsClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.SavedFilters GetSavedFiltersClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
        public virtual Azure.Analytics.Defender.Easm.Tasks GetTasksClient(string subscriptionId, string resourceGroupName, string workspaceName, string apiVersion = "2023-03-01-preview") { throw null; }
    }
    public partial class EasmClientOptions : Azure.Core.ClientOptions
    {
        public EasmClientOptions(Azure.Analytics.Defender.Easm.EasmClientOptions.ServiceVersion version = Azure.Analytics.Defender.Easm.EasmClientOptions.ServiceVersion.V2023_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2023_03_01_Preview = 1,
        }
    }
    public partial class ErrorDetail
    {
        internal ErrorDetail() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ErrorDetail> Details { get { throw null; } }
        public Azure.Analytics.Defender.Easm.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class GuidPair
    {
        internal GuidPair() { }
        public string CrawlStateGuid { get { throw null; } }
        public System.DateTimeOffset? LoadDate { get { throw null; } }
        public string PageGuid { get { throw null; } }
        public bool? Recent { get { throw null; } }
    }
    public partial class HostAsset : Azure.Analytics.Defender.Easm.InventoryAsset
    {
        internal HostAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Attribute> Attributes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Banner> Banners { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ChildHosts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cnames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Cookie> Cookies { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ResourceUrl> ResourceUrls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ScanMetadata> ScanMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Service> Services { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Webserver { get { throw null; } }
    }
    public partial class HostAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal HostAssetResource() { }
        public Azure.Analytics.Defender.Easm.HostAsset Asset { get { throw null; } }
    }
    public partial class HostCore
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
    }
    public partial class InnerError
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
    }
    public partial class InventoryAsset
    {
        internal InventoryAsset() { }
    }
    public partial class IpAddressAsset : Azure.Analytics.Defender.Easm.InventoryAsset
    {
        internal IpAddressAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Attribute> Attributes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Banner> Banners { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Cookie> Cookies { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Reputation> Reputations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ScanMetadata> ScanMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Service> Services { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
    }
    public partial class IpAddressAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal IpAddressAssetResource() { }
        public Azure.Analytics.Defender.Easm.IpAddressAsset Asset { get { throw null; } }
    }
    public partial class IpBlock
    {
        internal IpBlock() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public string IpBlockProperty { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
    }
    public partial class IpBlockAsset : Azure.Analytics.Defender.Easm.InventoryAsset
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Reputation> Reputations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public string StartIp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalContacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalOrgs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> TechnicalPhones { get { throw null; } }
    }
    public partial class IpBlockAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal IpBlockAssetResource() { }
        public Azure.Analytics.Defender.Easm.IpBlockAsset Asset { get { throw null; } }
    }
    public partial class Location
    {
        internal Location() { }
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
    }
    public partial class LogAnalyticsDataConnection : Azure.Analytics.Defender.Easm.DataConnection
    {
        internal LogAnalyticsDataConnection() { }
        public Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties Properties { get { throw null; } }
    }
    public partial class LogAnalyticsDataConnectionData : Azure.Analytics.Defender.Easm.DataConnectionData
    {
        public LogAnalyticsDataConnectionData(Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties properties) { }
        public Azure.Analytics.Defender.Easm.LogAnalyticsDataConnectionProperties Properties { get { throw null; } }
    }
    public partial class LogAnalyticsDataConnectionProperties : Azure.Analytics.Defender.Easm.DataConnectionProperties
    {
        public LogAnalyticsDataConnectionProperties() { }
        public string ApiKey { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class ObservedBoolean : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedBoolean() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public bool? Value { get { throw null; } }
    }
    public partial class ObservedHeader : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedHeader() { }
        public string HeaderName { get { throw null; } }
        public string HeaderValue { get { throw null; } }
    }
    public partial class ObservedInteger : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedInteger() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public int? Value { get { throw null; } }
    }
    public partial class ObservedIntegers : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedIntegers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Values { get { throw null; } }
    }
    public partial class ObservedLocation : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedLocation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public Azure.Analytics.Defender.Easm.Location Value { get { throw null; } }
    }
    public partial class ObservedLong : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedLong() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public long? Value { get { throw null; } }
    }
    public partial class ObservedPortState : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedPortState() { }
        public int? Port { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservedPortStateValue? Value { get { throw null; } }
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
    public partial class ObservedString : Azure.Analytics.Defender.Easm.ObservedValue
    {
        internal ObservedString() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ObservedValue
    {
        internal ObservedValue() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
    }
    public partial class PageAsset : Azure.Analytics.Defender.Easm.InventoryAsset
    {
        internal PageAsset() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> Asns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSecurityPolicy> AssetSecurityPolicies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Attribute> Attributes { get { throw null; } }
        public Azure.Analytics.Defender.Easm.PageCause Cause { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cdns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Charsets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Cnames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> ContentLengths { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ContentTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Cookie> Cookies { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ResourceUrl> ResourceUrls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> ResponseBodyHashSignatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedIntegers> ResponseBodyMinhashSignatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedHeader> ResponseHeaders { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedLong> ResponseTimes { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ObservedBoolean RootUrl { get { throw null; } }
        public string Service { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Service> Services { get { throw null; } }
        public string SiteStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslServerConfig> SslServerConfig { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Successful { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Titles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> UndirectedContent { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> WindowNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedBoolean> Windows { get { throw null; } }
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
    public partial class PageAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal PageAssetResource() { }
        public Azure.Analytics.Defender.Easm.PageAsset Asset { get { throw null; } }
    }
    public partial class PageCause
    {
        internal PageCause() { }
        public string Cause { get { throw null; } }
        public string CauseElementXPath { get { throw null; } }
        public int? DomChangeIndex { get { throw null; } }
        public string Location { get { throw null; } }
        public bool? LoopDetected { get { throw null; } }
        public int? PossibleMatches { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class Port
    {
        internal Port() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? PortProperty { get { throw null; } }
    }
    public partial class ReportAssetSnapshotRequest
    {
        public ReportAssetSnapshotRequest() { }
        public string LabelName { get { throw null; } set { } }
        public string Metric { get { throw null; } set { } }
        public int? Page { get { throw null; } set { } }
        public int? Size { get { throw null; } set { } }
    }
    public partial class ReportAssetSnapshotResult
    {
        internal ReportAssetSnapshotResult() { }
        public Azure.Analytics.Defender.Easm.AssetPageResult Assets { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string LabelName { get { throw null; } }
        public string Metric { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class ReportAssetSummaryRequest
    {
        public ReportAssetSummaryRequest() { }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public string GroupBy { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MetricCategories { get { throw null; } }
        public System.Collections.Generic.IList<string> Metrics { get { throw null; } }
        public string SegmentBy { get { throw null; } set { } }
    }
    public partial class ReportAssetSummaryResult
    {
        internal ReportAssetSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.AssetSummaryResult> AssetSummaries { get { throw null; } }
    }
    public partial class ReportBillableAssetBreakdown
    {
        internal ReportBillableAssetBreakdown() { }
        public long? Count { get { throw null; } }
        public Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdownKind? Kind { get { throw null; } }
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
    public partial class ReportBillableAssetSnapshotResult
    {
        internal ReportBillableAssetSnapshotResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReportBillableAssetBreakdown> AssetBreakdown { get { throw null; } }
        public System.DateTimeOffset? Date { get { throw null; } }
        public long? Total { get { throw null; } }
    }
    public partial class ReportBillableAssetSummaryResult
    {
        internal ReportBillableAssetSummaryResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ReportBillableAssetSnapshotResult> AssetSummaries { get { throw null; } }
    }
    public partial class Reports
    {
        protected Reports() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetBillable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult> GetBillable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBillableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportBillableAssetSummaryResult>> GetBillableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult> GetSnapshot(Azure.Analytics.Defender.Easm.ReportAssetSnapshotRequest reportAssetSnapshotRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSnapshotResult>> GetSnapshotAsync(Azure.Analytics.Defender.Easm.ReportAssetSnapshotRequest reportAssetSnapshotRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult> GetSummary(Azure.Analytics.Defender.Easm.ReportAssetSummaryRequest reportAssetSummaryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSummary(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.ReportAssetSummaryResult>> GetSummaryAsync(Azure.Analytics.Defender.Easm.ReportAssetSummaryRequest reportAssetSummaryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSummaryAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class Reputation
    {
        internal Reputation() { }
        public string Cidr { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string ListName { get { throw null; } }
        public System.DateTimeOffset? ListUpdatedAt { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string ThreatType { get { throw null; } }
        public bool? Trusted { get { throw null; } }
    }
    public partial class ResourceUrl
    {
        internal ResourceUrl() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.DependentResource> Resources { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class SavedFilter
    {
        internal SavedFilter() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Filter { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SavedFilterData
    {
        public SavedFilterData(string filter, string description) { }
        public string Description { get { throw null; } }
        public string Filter { get { throw null; } }
    }
    public partial class SavedFilters
    {
        protected SavedFilters() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter> CreateOrReplaceSavedFilter(string filterName, Azure.Analytics.Defender.Easm.SavedFilterData savedFilterData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSavedFilter(string filterName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter>> CreateOrReplaceSavedFilterAsync(string filterName, Azure.Analytics.Defender.Easm.SavedFilterData savedFilterData, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceSavedFilterAsync(string filterName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSavedFilter(string filterName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSavedFilterAsync(string filterName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSavedFilter(string filterName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFilter(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSavedFilterAsync(string filterName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.SavedFilter>> GetSavedFilterAsync(string filterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSavedFilters(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFilters(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSavedFiltersAsync(string filter, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.SavedFilter> GetSavedFiltersAsync(string filter = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScanMetadata
    {
        internal ScanMetadata() { }
        public string BannerMetadata { get { throw null; } }
        public System.DateTimeOffset? EndScan { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.DateTimeOffset? StartScan { get { throw null; } }
    }
    public partial class Service
    {
        internal Service() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedString> Exceptions { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public int? Port { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.ObservedPortState> PortStates { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public string Scheme { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.SslCertAsset> SslCerts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.WebComponent> WebComponents { get { throw null; } }
    }
    public partial class SoaRecord
    {
        internal SoaRecord() { }
        public long? Count { get { throw null; } }
        public string Email { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string NameServer { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public long? SerialNumber { get { throw null; } }
    }
    public partial class Source
    {
        internal Source() { }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SourceProperty { get { throw null; } }
    }
    public partial class SslCertAsset : Azure.Analytics.Defender.Easm.InventoryAsset
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
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectAlternativeNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectCommonNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectCountry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectLocality { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectOrganizationalUnits { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectOrganizations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SubjectState { get { throw null; } }
        public Azure.Analytics.Defender.Easm.SslCertAssetValidationType? ValidationType { get { throw null; } }
        public int? Version { get { throw null; } }
    }
    public partial class SslCertAssetResource : Azure.Analytics.Defender.Easm.AssetResource
    {
        internal SslCertAssetResource() { }
        public Azure.Analytics.Defender.Easm.SslCertAsset Asset { get { throw null; } }
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
    public partial class SslServerConfig
    {
        internal SslServerConfig() { }
        public System.Collections.Generic.IReadOnlyList<string> CipherSuites { get { throw null; } }
        public long? Count { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TlsVersions { get { throw null; } }
    }
    public partial class SubResourceIntegrityCheck
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
    }
    public partial class Task
    {
        internal Task() { }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastPolledAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public Azure.Analytics.Defender.Easm.TaskPhase? Phase { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.Analytics.Defender.Easm.TaskState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskPhase : System.IEquatable<Azure.Analytics.Defender.Easm.TaskPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskPhase(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.TaskPhase Complete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskPhase Polling { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskPhase Running { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.TaskPhase other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.TaskPhase left, Azure.Analytics.Defender.Easm.TaskPhase right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.TaskPhase (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.TaskPhase left, Azure.Analytics.Defender.Easm.TaskPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Tasks
    {
        protected Tasks() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.Task> CancelTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.Task>> CancelTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTask(string taskId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.Defender.Easm.Task> GetTask(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTaskAsync(string taskId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.Defender.Easm.Task>> GetTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTasks(string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.Defender.Easm.Task> GetTasks(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTasksAsync(string filter, string orderby, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.Defender.Easm.Task> GetTasksAsync(string filter = null, string orderby = null, int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskState : System.IEquatable<Azure.Analytics.Defender.Easm.TaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskState(string value) { throw null; }
        public static Azure.Analytics.Defender.Easm.TaskState Complete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Failed { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Incomplete { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Paused { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Pending { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Running { get { throw null; } }
        public static Azure.Analytics.Defender.Easm.TaskState Warning { get { throw null; } }
        public bool Equals(Azure.Analytics.Defender.Easm.TaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.Defender.Easm.TaskState left, Azure.Analytics.Defender.Easm.TaskState right) { throw null; }
        public static implicit operator Azure.Analytics.Defender.Easm.TaskState (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.Defender.Easm.TaskState left, Azure.Analytics.Defender.Easm.TaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateResult
    {
        internal ValidateResult() { }
        public Azure.Analytics.Defender.Easm.ErrorDetail Error { get { throw null; } }
    }
    public partial class WebComponent
    {
        internal WebComponent() { }
        public long? Count { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Cve> Cve { get { throw null; } }
        public long? EndOfLife { get { throw null; } }
        public System.DateTimeOffset? FirstSeen { get { throw null; } }
        public System.DateTimeOffset? LastSeen { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Port> Ports { get { throw null; } }
        public bool? Recent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RuleId { get { throw null; } }
        public string Service { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.Defender.Easm.Source> Sources { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
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
