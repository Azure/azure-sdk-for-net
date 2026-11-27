namespace Azure.Provisioning.CertificateRegistration
{
    public partial class AppServiceCertificate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceCertificate(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CertificateRegistration.AppServiceCertificateOrder Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.AppServiceVaultSecretStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CertificateRegistration.AppServiceCertificate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceCertificateDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceCertificateDetails() { }
        public Azure.Provisioning.BicepValue<string> Issuer { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotAfter { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NotBefore { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RawData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SignatureAlgorithm { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Subject { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceCertificateNotRenewableReason
    {
        RegistrationStatusNotSupportedForRenewal = 0,
        ExpirationNotInRenewalTimeRange = 1,
        SubscriptionNotActive = 2,
    }
    public partial class AppServiceCertificateOrder : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public AppServiceCertificateOrder(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.AppServiceCertificateNotRenewableReason> AppServiceCertificateNotRenewableReasons { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.CertificateProductType> CertificateProductType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.CertificateRegistration.AppServiceCertificateProperties> Certificates { get { throw null; } set { } }
        public Azure.Provisioning.CertificateRegistration.CertificateOrderContact Contact { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Csr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DistinguishedName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DomainVerificationToken { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiresOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.AppServiceCertificateDetails Intermediate { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsAutoRenew { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateKeyExternal { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> KeySize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastCertificateIssuedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> NextAutoRenewOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.CertificateRegistrationProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.AppServiceCertificateDetails Root { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SerialNumber { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.AppServiceCertificateDetails SignedCertificate { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.CertificateOrderStatus> Status { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidityInYears { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CertificateRegistration.AppServiceCertificateOrder FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceCertificateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceCertificateProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVaultSecretName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.AppServiceVaultSecretStatus> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppServiceDetector : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal AppServiceDetector() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.DataProviderMetadata> DataProvidersMetadata { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.DiagnosticDataset> Dataset { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.AppServiceDetectorInfo Metadata { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.CertificateRegistration.AppServiceCertificateOrder Parent { get { throw null; } set { } }
        public Azure.Provisioning.CertificateRegistration.DetectorStatusInfo Status { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.QueryUtterancesResults SuggestedUtterances { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.CertificateRegistration.AppServiceDetector FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_11_01;
        }
    }
    public partial class AppServiceDetectorInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AppServiceDetectorInfo() { }
        public Azure.Provisioning.BicepList<string> AnalysisType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Author { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Category { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Score { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.DetectorSupportTopic> SupportTopicList { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.AppServiceDetectorType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AppServiceDetectorType
    {
        Detector = 0,
        Analysis = 1,
        CategoryOverview = 2,
    }
    public enum AppServiceVaultSecretStatus
    {
        Initialized = 0,
        WaitingOnCertificateOrder = 1,
        Succeeded = 2,
        CertificateOrderFailed = 3,
        OperationNotPermittedOnKeyVault = 4,
        AzureServiceUnauthorizedToAccessKeyVault = 5,
        KeyVaultDoesNotExist = 6,
        KeyVaultSecretDoesNotExist = 7,
        UnknownError = 8,
        ExternalPrivateKey = 9,
        Unknown = 10,
    }
    public partial class CertificateOrderContact : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CertificateOrderContact() { }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NameFirst { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NameLast { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Phone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CertificateOrderStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Pendingissuance")]
        PendingIssuance = 0,
        Issued = 1,
        Revoked = 2,
        Canceled = 3,
        Denied = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Pendingrevocation")]
        PendingRevocation = 5,
        PendingRekey = 6,
        Unused = 7,
        Expired = 8,
        NotSubmitted = 9,
    }
    public enum CertificateProductType
    {
        StandardDomainValidatedSsl = 0,
        StandardDomainValidatedWildCardSsl = 1,
    }
    public enum CertificateRegistrationProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        InProgress = 3,
        Deleting = 4,
    }
    public partial class DataProviderKeyValuePair : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataProviderKeyValuePair() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataProviderMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataProviderMetadata() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.DataProviderKeyValuePair> PropertyBag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ProviderName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DetectorInsightStatus
    {
        Critical = 0,
        Warning = 1,
        Info = 2,
        Success = 3,
        None = 4,
    }
    public partial class DetectorStatusInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DetectorStatusInfo() { }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.DetectorInsightStatus> StatusId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DetectorSupportTopic : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DetectorSupportTopic() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PesId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticDataRendering : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticDataRendering() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.CertificateRegistration.DiagnosticDataRenderingType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DiagnosticDataRenderingType
    {
        NoGraph = 0,
        Table = 1,
        TimeSeries = 2,
        TimeSeriesPerInstance = 3,
        PieChart = 4,
        DataSummary = 5,
        Email = 6,
        Insights = 7,
        DynamicInsight = 8,
        Markdown = 9,
        Detector = 10,
        DropDown = 11,
        Card = 12,
        Solution = 13,
        Guage = 14,
        Form = 15,
        ChangeSets = 16,
        ChangeAnalysisOnboarding = 17,
        ChangesView = 18,
        AppInsight = 19,
        DependencyGraph = 20,
        DownTime = 21,
        SummaryCard = 22,
        SearchComponent = 23,
        AppInsightEnablement = 24,
    }
    public partial class DiagnosticDataset : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticDataset() { }
        public Azure.Provisioning.CertificateRegistration.DiagnosticDataRendering RenderingProperties { get { throw null; } }
        public Azure.Provisioning.CertificateRegistration.DiagnosticDataTableObject Table { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticDataTableColumn : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticDataTableColumn() { }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ColumnType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> DataType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DiagnosticDataTableObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DiagnosticDataTableObject() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.DiagnosticDataTableColumn> Columns { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepList<string>> Rows { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueryUtterancesResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueryUtterancesResult() { }
        public Azure.Provisioning.CertificateRegistration.SampleUtterance SampleUtterance { get { throw null; } }
        public Azure.Provisioning.BicepValue<float> Score { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QueryUtterancesResults : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public QueryUtterancesResults() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.CertificateRegistration.QueryUtterancesResult> Results { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SampleUtterance : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SampleUtterance() { }
        public Azure.Provisioning.BicepList<string> Links { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Qid { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
