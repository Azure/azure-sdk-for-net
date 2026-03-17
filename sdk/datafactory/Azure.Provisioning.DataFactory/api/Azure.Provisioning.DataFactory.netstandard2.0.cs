namespace Azure.Provisioning.DataFactory
{
    public enum ActivityOnInactiveMarkAs
    {
        Succeeded = 0,
        Failed = 1,
        Skipped = 2,
    }
    public partial class AmazonMwsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonMwsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MarketplaceId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret MwsAuthToken { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecretKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SellerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonMwsObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AmazonMwsObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonMwsSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AmazonMwsSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AmazonRdsForOracleAuthenticationType
    {
        Basic = 0,
    }
    public partial class AmazonRdsForOracleLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonRdsForOracleLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AmazonRdsForOracleAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CryptoChecksumClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CryptoChecksumTypesClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBulkLoad { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionTypesClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FetchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FetchTswtzAsTimestamp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitializationString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InitialLobFetchSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StatementCacheSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportV1DataTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRdsForOraclePartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AmazonRdsForOraclePartitionSettings() { }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRdsForOracleSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AmazonRdsForOracleSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberPrecision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OracleReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.AmazonRdsForOraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRdsForOracleTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AmazonRdsForOracleTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AmazonRdsForSqlAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL")]
        Sql = 0,
        Windows = 1,
    }
    public partial class AmazonRdsForSqlServerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonRdsForSqlServerLinkedService() { }
        public Azure.Provisioning.DataFactory.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApplicationIntent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AmazonRdsForSqlAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encrypt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailoverPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostNameInCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IntegratedSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LoadBalanceTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultipleActiveResultSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiSubnetFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRdsForSqlServerSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AmazonRdsForSqlServerSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRdsForSqlServerTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AmazonRdsForSqlServerTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRedshiftLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonRedshiftLinkedService() { }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRedshiftSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AmazonRedshiftSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.RedshiftUnloadSettings RedshiftUnloadSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonRedshiftTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AmazonRedshiftTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3CompatibleLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonS3CompatibleLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ForcePathStyle { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecretAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3CompatibleLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AmazonS3CompatibleLocation() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3CompatibleReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AmazonS3CompatibleReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3Dataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AmazonS3Dataset() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AmazonS3LinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecretAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SessionToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3Location : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AmazonS3Location() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmazonS3ReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AmazonS3ReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppendVariableActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public AppendVariableActivity() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VariableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AppFiguresLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AppFiguresLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientKey { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AsanaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AsanaLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AvroDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AvroDataset() { }
        public Azure.Provisioning.BicepValue<string> AvroCompressionCodec { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> AvroCompressionLevel { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AvroSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AvroSink() { }
        public Azure.Provisioning.DataFactory.AvroWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AvroSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AvroSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AvroWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AvroWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRowsPerFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecordName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RecordNamespace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzPowerShellSetup : Azure.Provisioning.DataFactory.CustomSetupBase
    {
        public AzPowerShellSetup() { }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBatchLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureBatchLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BatchUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PoolName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureBlobDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableRootLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureBlobFSDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureBlobFSLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AzureBlobFSLocation() { }
        public Azure.Provisioning.BicepValue<string> FileSystem { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AzureBlobFSReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureBlobFSSink() { }
        public Azure.Provisioning.BicepValue<string> CopyBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryMetadataItemInfo> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AzureBlobFSSource() { }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SkipHeaderLineCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatEmptyAsNull { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobFSWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public AzureBlobFSWriteSettings() { }
        public Azure.Provisioning.BicepValue<int> BlockSizeInMB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureBlobStorageLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AccountKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureStorageAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobStorageLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AzureBlobStorageLocation() { }
        public Azure.Provisioning.BicepValue<string> Container { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobStorageReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AzureBlobStorageReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureBlobStorageWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public AzureBlobStorageWriteSettings() { }
        public Azure.Provisioning.BicepValue<int> BlockSizeInMB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureDatabricksDeltaLakeDataset() { }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeExportCommand : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureDatabricksDeltaLakeExportCommand() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimestampFormat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeImportCommand : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureDatabricksDeltaLakeImportCommand() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimestampFormat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureDatabricksDeltaLakeLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureDatabricksDeltaLakeSink() { }
        public Azure.Provisioning.DataFactory.AzureDatabricksDeltaLakeImportCommand ImportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksDeltaLakeSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AzureDatabricksDeltaLakeSource() { }
        public Azure.Provisioning.DataFactory.AzureDatabricksDeltaLakeExportCommand ExportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDatabricksLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureDatabricksLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataSecurityMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExistingClusterId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstancePoolId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> NewClusterCustomTags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewClusterDriverNodeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> NewClusterEnableElasticDisk { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> NewClusterInitScripts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewClusterLogDestination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewClusterNodeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewClusterNumOfWorker { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> NewClusterSparkConf { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> NewClusterSparkEnvVars { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NewClusterVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PolicyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataExplorerCommandActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public AzureDataExplorerCommandActivity() { }
        public Azure.Provisioning.BicepValue<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommandTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataExplorerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureDataExplorerLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataExplorerSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureDataExplorerSink() { }
        public Azure.Provisioning.BicepValue<bool> FlushImmediately { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IngestionMappingAsJson { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IngestionMappingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataExplorerSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AzureDataExplorerSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> NoTruncation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataExplorerTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureDataExplorerTableDataset() { }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeAnalyticsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureDataLakeAnalyticsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataLakeAnalyticsUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureDataLakeStoreDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureDataLakeStoreLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataLakeStoreUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AzureDataLakeStoreLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AzureDataLakeStoreReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ListAfter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ListBefore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureDataLakeStoreSink() { }
        public Azure.Provisioning.BicepValue<string> CopyBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableAdlsSingleFileParallel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public AzureDataLakeStoreSource() { }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDataLakeStoreWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public AzureDataLakeStoreWriteSettings() { }
        public Azure.Provisioning.BicepValue<string> ExpiryDateTime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFileStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureFileStorageLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileShare { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Snapshot { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFileStorageLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public AzureFileStorageLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFileStorageReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public AzureFileStorageReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFileStorageWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public AzureFileStorageWriteSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureFunctionActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public AzureFunctionActivity() { }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureFunctionActivityMethod> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> RequestHeaders { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureFunctionActivityMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PUT")]
        Put = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DELETE")]
        Delete = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OPTIONS")]
        Options = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HEAD")]
        Head = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TRACE")]
        Trace = 6,
    }
    public partial class AzureFunctionLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureFunctionLinkedService() { }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionAppUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret FunctionKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureKeyVaultLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureKeyVaultLinkedService() { }
        public Azure.Provisioning.BicepValue<string> BaseUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMariaDBLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureMariaDBLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMariaDBSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AzureMariaDBSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMariaDBTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureMariaDBTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLBatchExecutionActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public AzureMLBatchExecutionActivity() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> GlobalParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.AzureMLWebServiceFile> WebServiceInputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.AzureMLWebServiceFile> WebServiceOutputs { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLExecutePipelineActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public AzureMLExecutePipelineActivity() { }
        public Azure.Provisioning.BicepValue<bool> ContinueOnStepFailure { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DataPathAssignments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExperimentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MLParentRunId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MLPipelineEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MLPipelineId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> MLPipelineParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureMLLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MLEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateResourceEndpoint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLServiceLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureMLServiceLinkedService() { }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MLWorkspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroupName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLUpdateResourceActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public AzureMLUpdateResourceActivity() { }
        public Azure.Provisioning.BicepValue<string> TrainedModelFilePath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference TrainedModelLinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrainedModelName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMLWebServiceFile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureMLWebServiceFile() { }
        public Azure.Provisioning.BicepValue<string> FilePath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMySqlLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureMySqlLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMySqlSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureMySqlSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMySqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AzureMySqlSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMySqlTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureMySqlTableDataset() { }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePostgreSqlLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzurePostgreSqlLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReadBufferSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Timeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timezone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePostgreSqlSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzurePostgreSqlSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> UpsertKeys { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzurePostgreSqlWriteMethodEnum> WriteMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePostgreSqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AzurePostgreSqlSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePostgreSqlTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzurePostgreSqlTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzurePostgreSqlWriteMethodEnum
    {
        BulkInsert = 0,
        CopyCommand = 1,
        Upsert = 2,
    }
    public partial class AzureQueueSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureQueueSink() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSearchIndexDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureSearchIndexDataset() { }
        public Azure.Provisioning.BicepValue<string> IndexName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSearchIndexSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureSearchIndexSink() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureSearchIndexWriteBehaviorType> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureSearchIndexWriteBehaviorType
    {
        Merge = 0,
        Upload = 1,
    }
    public partial class AzureSearchLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureSearchLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureSqlDatabaseAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL")]
        Sql = 0,
        ServicePrincipal = 1,
        SystemAssignedManagedIdentity = 2,
        UserAssignedManagedIdentity = 3,
    }
    public partial class AzureSqlDatabaseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureSqlDatabaseLinkedService() { }
        public Azure.Provisioning.DataFactory.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApplicationIntent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureSqlDatabaseAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectTimeout { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encrypt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailoverPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostNameInCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IntegratedSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LoadBalanceTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultipleActiveResultSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiSubnetFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureSqlDWAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL")]
        Sql = 0,
        ServicePrincipal = 1,
        SystemAssignedManagedIdentity = 2,
        UserAssignedManagedIdentity = 3,
    }
    public partial class AzureSqlDWLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureSqlDWLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ApplicationIntent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureSqlDWAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectTimeout { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encrypt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailoverPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostNameInCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IntegratedSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LoadBalanceTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultipleActiveResultSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiSubnetFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSqlDWTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureSqlDWTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureSqlMIAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL")]
        Sql = 0,
        ServicePrincipal = 1,
        SystemAssignedManagedIdentity = 2,
        UserAssignedManagedIdentity = 3,
    }
    public partial class AzureSqlMILinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureSqlMILinkedService() { }
        public Azure.Provisioning.DataFactory.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApplicationIntent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.AzureSqlMIAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectTimeout { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encrypt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailoverPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostNameInCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IntegratedSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LoadBalanceTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultipleActiveResultSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiSubnetFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSqlMITableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureSqlMITableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSqlSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureSqlSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AzureSqlSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSqlTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureSqlTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AzureStorageAuthenticationType
    {
        Anonymous = 0,
        AccountKey = 1,
        SasUri = 2,
        ServicePrincipal = 3,
        Msi = 4,
    }
    public partial class AzureStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureStorageLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureSynapseArtifactsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureSynapseArtifactsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public AzureTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureTableSink : Azure.Provisioning.DataFactory.CopySink
    {
        public AzureTableSink() { }
        public Azure.Provisioning.BicepValue<string> AzureTableDefaultPartitionKeyValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTableInsertType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTablePartitionKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTableRowKeyName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureTableSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public AzureTableSource() { }
        public Azure.Provisioning.BicepValue<bool> AzureTableSourceIgnoreTableNotFound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTableSourceQuery { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureTableStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public AzureTableStorageLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret SasToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SasUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceEndpoint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BigDataPoolParametrizationReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BigDataPoolParametrizationReference() { }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.BigDataPoolReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BigDataPoolReferenceType
    {
        BigDataPoolReference = 0,
    }
    public partial class BinaryDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public BinaryDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BinaryReadSettings : Azure.Provisioning.DataFactory.FormatReadSettings
    {
        public BinaryReadSettings() { }
        public Azure.Provisioning.DataFactory.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BinarySink : Azure.Provisioning.DataFactory.CopySink
    {
        public BinarySink() { }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BinarySource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public BinarySource() { }
        public Azure.Provisioning.DataFactory.BinaryReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CassandraLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CassandraLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CassandraSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public CassandraSource() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.CassandraSourceReadConsistencyLevel> ConsistencyLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CassandraSourceReadConsistencyLevel
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="ALL")]
        All = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="EACH_QUORUM")]
        EachQuorum = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="QUORUM")]
        Quorum = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="LOCAL_QUORUM")]
        LocalQuorum = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ONE")]
        One = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="TWO")]
        Two = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="THREE")]
        Three = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="LOCAL_ONE")]
        LocalOne = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SERIAL")]
        Serial = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="LOCAL_SERIAL")]
        LocalSerial = 9,
    }
    public partial class CassandraTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CassandraTableDataset() { }
        public Azure.Provisioning.BicepValue<string> Keyspace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ChainingTrigger : Azure.Provisioning.DataFactory.DataFactoryTriggerProperties
    {
        public ChainingTrigger() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryPipelineReference> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunDimension { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CmdkeySetup : Azure.Provisioning.DataFactory.CustomSetupBase
    {
        public CmdkeySetup() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommonDataServiceForAppsEntityDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CommonDataServiceForAppsEntityDataset() { }
        public Azure.Provisioning.BicepValue<string> EntityName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommonDataServiceForAppsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CommonDataServiceForAppsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrganizationName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommonDataServiceForAppsSink : Azure.Provisioning.DataFactory.CopySink
    {
        public CommonDataServiceForAppsSink() { }
        public Azure.Provisioning.BicepValue<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BypassBusinessLogicExecution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BypassPowerAutomateFlows { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DynamicsSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CommonDataServiceForAppsSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public CommonDataServiceForAppsSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComponentSetup : Azure.Provisioning.DataFactory.CustomSetupBase
    {
        public ComponentSetup() { }
        public Azure.Provisioning.BicepValue<string> ComponentName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret LicenseKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CompressionReadSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CompressionReadSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConcurLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ConcurLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConcurObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ConcurObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConcurSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ConcurSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConnectionStateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConnectionStateProperties() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContinuationSettingsReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContinuationSettingsReference() { }
        public Azure.Provisioning.BicepValue<int> ContinuationTtlInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomizedCheckpointKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IdleCondition { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ControlActivity : Azure.Provisioning.DataFactory.PipelineActivity
    {
        public ControlActivity() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopyActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public CopyActivity() { }
        public Azure.Provisioning.BicepValue<int> DataIntegrationUnits { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSkipIncompatibleRow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStaging { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetReference> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLogSettings LogSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetReference> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ParallelCopies { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Preserve { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> PreserveRules { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.RedirectIncompatibleRowSettings RedirectIncompatibleRowSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.CopySink Sink { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SkipErrorFile SkipErrorFile { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.CopyActivitySource Source { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StagingSettings StagingSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Translator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ValidateDataConsistency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopyActivityLogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopyActivityLogSettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableReliableLogging { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopyActivitySource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopyActivitySource() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SourceRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceRetryWait { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopyComputeScaleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopyComputeScaleProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DataIntegrationUnit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeToLive { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CopySink : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CopySink() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SinkRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SinkRetryWait { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WriteBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBatchTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CosmosDBConnectionMode
    {
        Gateway = 0,
        Direct = 1,
    }
    public partial class CosmosDBLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CosmosDBLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccountEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccountKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.CosmosDBConnectionMode> ConnectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBMongoDBApiCollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CosmosDBMongoDBApiCollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> Collection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBMongoDBApiLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CosmosDBMongoDBApiLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsServerVersionAbove32 { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBMongoDBApiSink : Azure.Provisioning.DataFactory.CopySink
    {
        public CosmosDBMongoDBApiSink() { }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBMongoDBApiSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public CosmosDBMongoDBApiSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBSqlApiCollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CosmosDBSqlApiCollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> CollectionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBSqlApiSink : Azure.Provisioning.DataFactory.CopySink
    {
        public CosmosDBSqlApiSink() { }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CosmosDBSqlApiSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public CosmosDBSqlApiSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DetectDatetime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PageSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PreferredRegions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CouchbaseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CouchbaseLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret CredString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CouchbaseSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public CouchbaseSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CouchbaseTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CouchbaseTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public CustomActivity() { }
        public Azure.Provisioning.BicepValue<string> AutoUserSpecification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> ExtendedProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.CustomActivityReferenceObject ReferenceObjects { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference ResourceLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> RetentionTimeInDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomActivityReferenceObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomActivityReferenceObject() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetReference> Datasets { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> LinkedServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public CustomDataset() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> TypeProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomDataSourceLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public CustomDataSourceLinkedService() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> TypeProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomEventsTrigger : Azure.Provisioning.DataFactory.MultiplePipelineTrigger
    {
        public CustomEventsTrigger() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Events { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectBeginsWith { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubjectEndsWith { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomSetupBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomSetupBase() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksJobActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DatabricksJobActivity() { }
        public Azure.Provisioning.BicepValue<string> JobId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> JobParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksNotebookActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DatabricksNotebookActivity() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> BaseParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepDictionary<System.BinaryData>> Libraries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NotebookPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksSparkJarActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DatabricksSparkJarActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepDictionary<System.BinaryData>> Libraries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MainClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatabricksSparkPythonActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DatabricksSparkPythonActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.BicepDictionary<System.BinaryData>> Libraries { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PythonFile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryBlobEventsTrigger : Azure.Provisioning.DataFactory.MultiplePipelineTrigger
    {
        public DataFactoryBlobEventsTrigger() { }
        public Azure.Provisioning.BicepValue<string> BlobPathBeginsWith { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlobPathEndsWith { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryBlobEventType> Events { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreEmptyBlobs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryBlobEventType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage.BlobCreated")]
        MicrosoftStorageBlobCreated = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Microsoft.Storage.BlobDeleted")]
        MicrosoftStorageBlobDeleted = 1,
    }
    public partial class DataFactoryBlobSink : Azure.Provisioning.DataFactory.CopySink
    {
        public DataFactoryBlobSink() { }
        public Azure.Provisioning.BicepValue<bool> BlobWriterAddHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BlobWriterDateTimeFormat { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BlobWriterOverwriteFiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CopyBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryMetadataItemInfo> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryBlobSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DataFactoryBlobSource() { }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SkipHeaderLineCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatEmptyAsNull { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryBlobTrigger : Azure.Provisioning.DataFactory.MultiplePipelineTrigger
    {
        public DataFactoryBlobTrigger() { }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryChangeDataCapture : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryChangeDataCapture(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowVnetOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FolderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MapperPolicy Policy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperSourceConnectionsInfo> SourceConnectionsInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperTargetConnectionsInfo> TargetConnectionsInfo { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryChangeDataCapture FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryCredential() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryCredentialReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryCredentialReference() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryCredentialReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryCredentialReferenceType
    {
        CredentialReference = 0,
    }
    public partial class DataFactoryDataFlow : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryDataFlow(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryDataFlowProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryDataFlow FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryDataFlowProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryDataFlowProperties() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryDataset : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryDataset(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryDatasetProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryDataset FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryDatasetProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryDatasetProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.EntityParameterSpecification> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetSchemaDataElement> Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetDataElement> Structure { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class DataFactoryEncryptionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryEncryptionConfiguration() { }
        public Azure.Provisioning.BicepValue<string> KeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> VaultBaseUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryExpression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryExpression() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryExpressionType> ExpressionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryExpressionType
    {
        Expression = 0,
    }
    public partial class DataFactoryExpressionV2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryExpressionV2() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryExpressionV2> Operands { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Operators { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryExpressionV2Type> V2Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> V2Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryExpressionV2Type
    {
        Constant = 0,
        Field = 1,
        Unary = 2,
        Binary = 3,
        NAry = 4,
    }
    public partial class DataFactoryFlowletProperties : Azure.Provisioning.DataFactory.DataFactoryDataFlowProperties
    {
        public DataFactoryFlowletProperties() { }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ScriptLines { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowSink> Sinks { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowSource> Sources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowTransformation> Transformations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryGlobalParameter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryGlobalParameter(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.DataFactoryGlobalParameterProperties> Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryGlobalParameter FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryGlobalParameterProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryGlobalParameterProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryGlobalParameterType> GlobalParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryGlobalParameterType
    {
        Object = 0,
        String = 1,
        Int = 2,
        Float = 3,
        Bool = 4,
        Array = 5,
    }
    public partial class DataFactoryHttpDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DataFactoryHttpDataset() { }
        public Azure.Provisioning.BicepValue<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryHttpFileSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DataFactoryHttpFileSource() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryIntegrationRuntime : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryIntegrationRuntime(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryIntegrationRuntimeProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryIntegrationRuntime FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryIntegrationRuntimeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryIntegrationRuntimeProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryKeyVaultSecret : Azure.Provisioning.DataFactory.DataFactorySecret
    {
        public DataFactoryKeyVaultSecret() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryLinkedService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryLinkedService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryLinkedService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryLinkedServiceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryLinkedServiceProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkedServiceVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.EntityParameterSpecification> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryLinkedServiceReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryLinkedServiceReference() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryLinkedServiceReferenceKind
    {
        LinkedServiceReference = 0,
    }
    public partial class DataFactoryLogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryLogSettings() { }
        public Azure.Provisioning.DataFactory.CopyActivityLogSettings CopyActivityLogSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableCopyActivityLog { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryManagedIdentityCredential : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryManagedIdentityCredential(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryManagedIdentityCredential FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryManagedIdentityCredentialProperties : Azure.Provisioning.DataFactory.DataFactoryCredential
    {
        public DataFactoryManagedIdentityCredentialProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryManagedVirtualNetwork : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryManagedVirtualNetwork(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryManagedVirtualNetworkProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryManagedVirtualNetwork FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryManagedVirtualNetworkProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryManagedVirtualNetworkProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Alias { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Guid> VnetId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryMappingDataFlowProperties : Azure.Provisioning.DataFactory.DataFactoryDataFlowProperties
    {
        public DataFactoryMappingDataFlowProperties() { }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ScriptLines { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowSink> Sinks { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowSource> Sources { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFlowTransformation> Transformations { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryMetadataItemInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryMetadataItemInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryPackageStore : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryPackageStore() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.EntityReference PackageStoreLinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryPipeline : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryPipeline(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> Activities { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Concurrency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ElapsedTimeMetricDuration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FolderName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.EntityParameterSpecification> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> RunDimensions { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.PipelineVariableSpecification> Variables { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryPipeline FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryPipelineReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryPipelineReference() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryPipelineReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryPipelineReferenceType
    {
        PipelineReference = 0,
    }
    public partial class DataFactoryPrivateEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryPrivateEndpoint(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryManagedVirtualNetwork? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryPrivateEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryPrivateEndpoint FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryPrivateEndpointConnection(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PrivateLinkConnectionApprovalRequest Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryPrivateEndpointConnection FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryPrivateEndpointConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryPrivateEndpointConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } }
        public Azure.Provisioning.DataFactory.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryPrivateEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryPrivateEndpointProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ConnectionStateProperties ConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsReserved { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryPublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DataFactoryRecurrenceFrequency
    {
        NotSpecified = 0,
        Minute = 1,
        Hour = 2,
        Day = 3,
        Week = 4,
        Month = 5,
        Year = 6,
    }
    public partial class DataFactoryRecurrenceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryRecurrenceSchedule() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Hours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Minutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> MonthDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryRecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryDayOfWeek> WeekDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryRecurrenceScheduleOccurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryRecurrenceScheduleOccurrence() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryDayOfWeek> Day { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Occurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryScheduleTrigger : Azure.Provisioning.DataFactory.MultiplePipelineTrigger
    {
        public DataFactoryScheduleTrigger() { }
        public Azure.Provisioning.DataFactory.ScheduleTriggerRecurrence Recurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryScriptAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryScriptAction() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Roles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryScriptActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DataFactoryScriptActivity() { }
        public Azure.Provisioning.DataFactory.ScriptActivityTypeLogSettings LogSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ReturnMultistatementResult { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptBlockExecutionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.ScriptActivityScriptBlock> Scripts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatDecimalAsString { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryScriptType
    {
        Query = 0,
        NonQuery = 1,
    }
    public partial class DataFactorySecret : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactorySecret() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactorySecretString : Azure.Provisioning.DataFactory.DataFactorySecret
    {
        public DataFactorySecretString() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryService : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryService(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.DataFactory.DataFactoryEncryptionConfiguration Encryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.DataFactoryGlobalParameterProperties> GlobalParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryPublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PurviewResourceId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.FactoryRepoConfiguration RepoConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryService FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryServiceCredential : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryServiceCredential(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredential Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryServiceCredential FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public enum DataFactorySparkConfigurationType
    {
        Default = 0,
        Customized = 1,
        Artifact = 2,
    }
    public partial class DataFactoryTrigger : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DataFactoryTrigger(string bicepIdentifier, string? resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryService? Parent { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryTriggerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DataFactory.DataFactoryTrigger FromExisting(string bicepIdentifier, string? resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2018_06_01;
        }
    }
    public partial class DataFactoryTriggerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryTriggerProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Annotations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryTriggerRuntimeState> RuntimeState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFactoryTriggerReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFactoryTriggerReference() { }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryTriggerReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFactoryTriggerReferenceType
    {
        TriggerReference = 0,
    }
    public enum DataFactoryTriggerRuntimeState
    {
        Started = 0,
        Stopped = 1,
        Disabled = 2,
    }
    public partial class DataFactoryWranglingDataFlowProperties : Azure.Provisioning.DataFactory.DataFactoryDataFlowProperties
    {
        public DataFactoryWranglingDataFlowProperties() { }
        public Azure.Provisioning.BicepValue<string> DocumentLocale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PowerQuerySource> Sources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFlowComputeType
    {
        General = 0,
        MemoryOptimized = 1,
        ComputeOptimized = 2,
    }
    public partial class DataFlowReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFlowReference() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DatasetParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFlowReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataFlowReferenceType
    {
        DataFlowReference = 0,
    }
    public partial class DataFlowSink : Azure.Provisioning.DataFactory.DataFlowTransformation
    {
        public DataFlowSink() { }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference RejectedDataLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFlowSource : Azure.Provisioning.DataFactory.DataFlowTransformation
    {
        public DataFlowSource() { }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference SchemaLinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFlowStagingInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFlowStagingInfo() { }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataFlowTransformation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataFlowTransformation() { }
        public Azure.Provisioning.DataFactory.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFlowReference Flowlet { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataLakeAnalyticsUsqlActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DataLakeAnalyticsUsqlActivity() { }
        public Azure.Provisioning.BicepValue<string> CompilationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> DegreeOfParallelism { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Priority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataMapperMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataMapperMapping() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperAttributeMapping> AttributeMappings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MapperConnectionReference SourceConnectionReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> SourceDenormalizeInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceEntityName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetEntityName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetAvroFormat : Azure.Provisioning.DataFactory.DatasetStorageFormat
    {
        public DatasetAvroFormat() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetCompression : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetCompression() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatasetCompressionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Level { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetDataElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetDataElement() { }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ColumnType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetJsonFormat : Azure.Provisioning.DataFactory.DatasetStorageFormat
    {
        public DatasetJsonFormat() { }
        public Azure.Provisioning.BicepValue<string> EncodingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> FilePattern { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JsonNodeReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> JsonPathDefinition { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NestingSeparator { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetLocation() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetOrcFormat : Azure.Provisioning.DataFactory.DatasetStorageFormat
    {
        public DatasetOrcFormat() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetParquetFormat : Azure.Provisioning.DataFactory.DatasetStorageFormat
    {
        public DatasetParquetFormat() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetReference() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DatasetReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatasetReferenceType
    {
        DatasetReference = 0,
    }
    public partial class DatasetSchemaDataElement : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetSchemaDataElement() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SchemaColumnType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DatasetSourceValueType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="actual")]
        Actual = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="display")]
        Display = 1,
    }
    public partial class DatasetStorageFormat : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetStorageFormat() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Deserializer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Serializer { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetTextFormat : Azure.Provisioning.DataFactory.DatasetStorageFormat
    {
        public DatasetTextFormat() { }
        public Azure.Provisioning.BicepValue<string> ColumnDelimiter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EscapeChar { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NullValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuoteChar { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RowDelimiter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SkipLineCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatEmptyAsNull { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataworldLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public DataworldLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum Db2AuthenticationType
    {
        Basic = 0,
    }
    public partial class Db2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public Db2LinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.Db2AuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertificateCommonName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageCollection { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Db2Source : Azure.Provisioning.DataFactory.TabularSource
    {
        public Db2Source() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Db2TableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public Db2TableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeleteActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public DeleteActivity() { }
        public Azure.Provisioning.DataFactory.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableLogging { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.LogStorageSettings LogStorageSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DelimitedTextDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DelimitedTextDataset() { }
        public Azure.Provisioning.BicepValue<string> ColumnDelimiter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompressionCodec { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompressionLevel { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EscapeChar { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NullValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QuoteChar { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RowDelimiter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DelimitedTextReadSettings : Azure.Provisioning.DataFactory.FormatReadSettings
    {
        public DelimitedTextReadSettings() { }
        public Azure.Provisioning.DataFactory.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SkipLineCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DelimitedTextSink : Azure.Provisioning.DataFactory.CopySink
    {
        public DelimitedTextSink() { }
        public Azure.Provisioning.DataFactory.DelimitedTextWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DelimitedTextSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DelimitedTextSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DelimitedTextReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DelimitedTextWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DelimitedTextWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileExtension { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRowsPerFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> QuoteAllText { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DependencyCondition
    {
        Succeeded = 0,
        Failed = 1,
        Skipped = 2,
        Completed = 3,
    }
    public partial class DependencyReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DependencyReference() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DistcpSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DistcpSettings() { }
        public Azure.Provisioning.BicepValue<string> DistcpOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceManagerEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TempScriptPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DocumentDBCollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DocumentDBCollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> CollectionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DocumentDBCollectionSink : Azure.Provisioning.DataFactory.CopySink
    {
        public DocumentDBCollectionSink() { }
        public Azure.Provisioning.BicepValue<string> NestingSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DocumentDBCollectionSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DocumentDBCollectionSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NestingSeparator { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DrillLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public DrillLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DrillSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public DrillSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DrillTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DrillTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DWCopyCommandDefaultValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DWCopyCommandDefaultValue() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> ColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DWCopyCommandSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DWCopyCommandSettings() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DWCopyCommandDefaultValue> DefaultValues { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsAXLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public DynamicsAXLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AadResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsAXResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DynamicsAXResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsAXSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public DynamicsAXSource() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsCrmEntityDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DynamicsCrmEntityDataset() { }
        public Azure.Provisioning.BicepValue<string> EntityName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsCrmLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public DynamicsCrmLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrganizationName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsCrmSink : Azure.Provisioning.DataFactory.CopySink
    {
        public DynamicsCrmSink() { }
        public Azure.Provisioning.BicepValue<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BypassBusinessLogicExecution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BypassPowerAutomateFlows { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DynamicsSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsCrmSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DynamicsCrmSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsEntityDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public DynamicsEntityDataset() { }
        public Azure.Provisioning.BicepValue<string> EntityName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public DynamicsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeploymentType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrganizationName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DynamicsSink : Azure.Provisioning.DataFactory.CopySink
    {
        public DynamicsSink() { }
        public Azure.Provisioning.BicepValue<string> AlternateKeyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BypassBusinessLogicExecution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> BypassPowerAutomateFlows { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DynamicsSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DynamicsSinkWriteBehavior
    {
        Upsert = 0,
    }
    public partial class DynamicsSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public DynamicsSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EloquaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public EloquaLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EloquaObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public EloquaObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EloquaSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public EloquaSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EntityParameterSpecification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EntityParameterSpecification() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.EntityParameterType> ParameterType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EntityParameterType
    {
        Object = 0,
        String = 1,
        Int = 2,
        Float = 3,
        Bool = 4,
        Array = 5,
        SecureString = 6,
    }
    public partial class EntityReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EntityReference() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeEntityReferenceType> IntegrationRuntimeEntityReferenceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EnvironmentVariableSetup : Azure.Provisioning.DataFactory.CustomSetupBase
    {
        public EnvironmentVariableSetup() { }
        public Azure.Provisioning.BicepValue<string> VariableName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VariableValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExcelDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ExcelDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FirstRowAsHeader { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NullValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Range { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SheetIndex { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SheetName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExcelSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public ExcelSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecuteDataFlowActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public ExecuteDataFlowActivity() { }
        public Azure.Provisioning.DataFactory.ExecuteDataFlowActivityComputeType Compute { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ContinuationSettingsReference ContinuationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ContinueOnError { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RunConcurrently { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TraceLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecuteDataFlowActivityComputeType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExecuteDataFlowActivityComputeType() { }
        public Azure.Provisioning.BicepValue<string> ComputeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CoreCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecutePipelineActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public ExecutePipelineActivity() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ExecutePipelineActivityPolicy Policy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> WaitOnCompletion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecutePipelineActivityPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ExecutePipelineActivityPolicy() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureInputEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecuteSsisPackageActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public ExecuteSsisPackageActivity() { }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SsisExecutionCredential ExecutionCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoggingLevel { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SsisLogLocation LogLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.SsisExecutionParameter>> PackageConnectionManagers { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SsisPackageLocation PackageLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.SsisExecutionParameter> PackageParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.SsisExecutionParameter>> ProjectConnectionManagers { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.SsisExecutionParameter> ProjectParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.SsisPropertyOverride> PropertyOverrides { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Runtime { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecuteWranglingDataflowActivity : Azure.Provisioning.DataFactory.PipelineActivity
    {
        public ExecuteWranglingDataflowActivity() { }
        public Azure.Provisioning.DataFactory.ExecuteDataFlowActivityComputeType Compute { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ContinuationSettingsReference ContinuationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ContinueOnError { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFlowReference DataFlow { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeReference IntegrationRuntime { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PipelineActivityPolicy Policy { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PowerQuerySinkMapping> Queries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RunConcurrently { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.PowerQuerySink> Sinks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SourceStagingConcurrency { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFlowStagingInfo Staging { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TraceLevel { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ExecutionActivity : Azure.Provisioning.DataFactory.PipelineActivity
    {
        public ExecutionActivity() { }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PipelineActivityPolicy Policy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FactoryGitHubClientSecret : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FactoryGitHubClientSecret() { }
        public Azure.Provisioning.BicepValue<System.Uri> ByoaSecretAkvUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ByoaSecretName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FactoryGitHubConfiguration : Azure.Provisioning.DataFactory.FactoryRepoConfiguration
    {
        public FactoryGitHubConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.FactoryGitHubClientSecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FactoryRepoConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FactoryRepoConfiguration() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CollaborationBranch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisablePublish { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LastCommitId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootFolder { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FactoryVstsConfiguration : Azure.Provisioning.DataFactory.FactoryRepoConfiguration
    {
        public FactoryVstsConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ProjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FailActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public FailActivity() { }
        public Azure.Provisioning.BicepValue<string> ErrorCode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileServerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public FileServerLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileServerLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public FileServerLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileServerReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public FileServerReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileServerWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public FileServerWriteSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileShareDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public FileShareDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileFilter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FolderPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetStorageFormat Format { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileSystemSink : Azure.Provisioning.DataFactory.CopySink
    {
        public FileSystemSink() { }
        public Azure.Provisioning.BicepValue<string> CopyBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileSystemSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public FileSystemSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FilterActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public FilterActivity() { }
        public Azure.Provisioning.DataFactory.DataFactoryExpression Condition { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryExpression Items { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ForEachActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public ForEachActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> Activities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BatchCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSequential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryExpression Items { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FormatReadSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FormatReadSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FtpAuthenticationType
    {
        Basic = 0,
        Anonymous = 1,
    }
    public partial class FtpReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public FtpReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableChunking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseBinaryTransfer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FtpServerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public FtpServerLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.FtpAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FtpServerLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public FtpServerLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GetDatasetMetadataActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public GetDatasetMetadataActivity() { }
        public Azure.Provisioning.DataFactory.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> FieldList { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.FormatReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GoogleAdWordsAuthenticationType
    {
        ServiceAuthentication = 0,
        UserAuthentication = 1,
    }
    public partial class GoogleAdWordsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GoogleAdWordsLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.GoogleAdWordsAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientCustomerId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret DeveloperToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GoogleAdsApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoginCustomerId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PrivateKey { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportLegacyDataTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleAdWordsObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public GoogleAdWordsObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleAdWordsSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public GoogleAdWordsSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GoogleBigQueryAuthenticationType
    {
        ServiceAuthentication = 0,
        UserAuthentication = 1,
    }
    public partial class GoogleBigQueryLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GoogleBigQueryLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AdditionalProjects { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.GoogleBigQueryAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Email { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Project { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> RequestGoogleDriveScope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleBigQueryObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public GoogleBigQueryObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleBigQuerySource : Azure.Provisioning.DataFactory.TabularSource
    {
        public GoogleBigQuerySource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GoogleBigQueryV2AuthenticationType
    {
        ServiceAuthentication = 0,
        UserAuthentication = 1,
    }
    public partial class GoogleBigQueryV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GoogleBigQueryV2LinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.GoogleBigQueryV2AuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret KeyFileContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret RefreshToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleBigQueryV2ObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public GoogleBigQueryV2ObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleBigQueryV2Source : Azure.Provisioning.DataFactory.TabularSource
    {
        public GoogleBigQueryV2Source() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleCloudStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GoogleCloudStorageLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecretAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleCloudStorageLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public GoogleCloudStorageLocation() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleCloudStorageReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public GoogleCloudStorageReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GoogleSheetsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GoogleSheetsLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum GreenplumAuthenticationType
    {
        Basic = 0,
    }
    public partial class GreenplumLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public GreenplumLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.GreenplumAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GreenplumSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public GreenplumSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GreenplumTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public GreenplumTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HBaseAuthenticationType
    {
        Anonymous = 0,
        Basic = 1,
    }
    public partial class HBaseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HBaseLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HBaseAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HBaseObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public HBaseObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HBaseSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public HBaseSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HdfsLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HdfsLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HdfsLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public HdfsLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HdfsReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public HdfsReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HdfsSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public HdfsSource() { }
        public Azure.Provisioning.DataFactory.DistcpSettings DistcpSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HDInsightActivityDebugInfoOptionSetting
    {
        None = 0,
        Always = 1,
        Failure = 2,
    }
    public enum HDInsightClusterAuthenticationType
    {
        BasicAuth = 0,
        SystemAssignedManagedIdentity = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class HDInsightHiveActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public HDInsightHiveActivity() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Defines { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightActivityDebugInfoOptionSetting> GetDebugInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> QueryTimeout { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Variables { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HDInsightLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HDInsightLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightClusterAuthenticationType> ClusterAuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileSystem { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEspEnabled { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HDInsightMapReduceActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public HDInsightMapReduceActivity() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Defines { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightActivityDebugInfoOptionSetting> GetDebugInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JarFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> JarLibs { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference JarLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HDInsightOnDemandClusterResourceGroupAuthenticationType
    {
        ServicePrincipalKey = 0,
        SystemAssignedManagedIdentity = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class HDInsightOnDemandLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HDInsightOnDemandLinkedService() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> AdditionalLinkedServiceNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClusterPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightOnDemandClusterResourceGroupAuthenticationType> ClusterResourceGroupAuthType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ClusterSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClusterSshPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterSshUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> CoreConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> DataNodeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> HBaseConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference HcatalogLinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> HdfsConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> HeadNodeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> HiveConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostSubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> MapReduceConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> OozieConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryScriptAction> ScriptActions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SparkVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StormConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubnetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeToLiveExpression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualNetworkId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> YarnConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ZookeeperNodeSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HDInsightPigActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public HDInsightPigActivity() { }
        public Azure.Provisioning.BicepList<string> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Defines { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightActivityDebugInfoOptionSetting> GetDebugInfo { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference ScriptLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HDInsightSparkActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public HDInsightSparkActivity() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EntryFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightActivityDebugInfoOptionSetting> GetDebugInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProxyUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> SparkConfig { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference SparkJobLinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HDInsightStreamingActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public HDInsightStreamingActivity() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Combiner { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> CommandEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Defines { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference FileLinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> FilePaths { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HDInsightActivityDebugInfoOptionSetting> GetDebugInfo { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Input { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Mapper { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Output { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Reducer { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> StorageLinkedServices { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HiveAuthenticationType
    {
        Anonymous = 0,
        Username = 1,
        UsernameAndPassword = 2,
        WindowsAzureHDInsightService = 3,
    }
    public partial class HiveLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HiveLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HiveAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HiveServerType> ServerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ServiceDiscoveryMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HiveThriftTransportProtocol> ThriftTransportProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseNativeQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ZooKeeperNameSpace { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HiveObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public HiveObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HiveServerType
    {
        HiveServer1 = 0,
        HiveServer2 = 1,
        HiveThriftServer = 2,
    }
    public partial class HiveSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public HiveSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum HiveThriftTransportProtocol
    {
        Binary = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SASL")]
        Sasl = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP ")]
        Http = 2,
    }
    public enum HttpAuthenticationType
    {
        Basic = 0,
        Anonymous = 1,
        Digest = 2,
        Windows = 3,
        ClientCertificate = 4,
    }
    public partial class HttpLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HttpLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.HttpAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> AuthHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CertThumbprint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EmbeddedCertData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HttpReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public HttpReadSettings() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMethod { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HttpServerLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public HttpServerLocation() { }
        public Azure.Provisioning.BicepValue<string> RelativeUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubspotLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public HubspotLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubspotObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public HubspotObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class HubspotSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public HubspotSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IcebergDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public IcebergDataset() { }
        public Azure.Provisioning.DataFactory.DatasetLocation Location { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IcebergSink : Azure.Provisioning.DataFactory.CopySink
    {
        public IcebergSink() { }
        public Azure.Provisioning.DataFactory.IcebergWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IcebergWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IcebergWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IfConditionActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public IfConditionActivity() { }
        public Azure.Provisioning.DataFactory.DataFactoryExpression Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> IfFalseActivities { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> IfTrueActivities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImpalaAuthenticationType
    {
        Anonymous = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SASLUsername")]
        SaslUsername = 1,
        UsernameAndPassword = 2,
    }
    public partial class ImpalaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ImpalaLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ImpalaAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ImpalaThriftTransportProtocol> ThriftTransportProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImpalaObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ImpalaObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImpalaSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ImpalaSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImpalaThriftTransportProtocol
    {
        Binary = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP")]
        Http = 1,
    }
    public partial class InformixLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public InformixLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InformixSink : Azure.Provisioning.DataFactory.CopySink
    {
        public InformixSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InformixSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public InformixSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class InformixTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public InformixTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationRuntimeComputeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeComputeProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.CopyComputeScaleProperties CopyComputeScaleProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfNodes { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PipelineExternalComputeScaleProperties PipelineExternalComputeScaleProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeVnetProperties VnetProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationRuntimeCustomSetupScriptProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeCustomSetupScriptProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> BlobContainerUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecretString SasToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationRuntimeDataFlowCustomItem : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeDataFlowCustomItem() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationRuntimeDataFlowProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFlowComputeType> ComputeType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CoreCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.IntegrationRuntimeDataFlowCustomItem> CustomProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldCleanupAfterTtl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeToLiveInMinutes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IntegrationRuntimeDataProxyProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.Provisioning.DataFactory.EntityReference ConnectVia { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.EntityReference StagingLinkedService { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationRuntimeEdition
    {
        Standard = 0,
        Enterprise = 1,
    }
    public enum IntegrationRuntimeEntityReferenceType
    {
        IntegrationRuntimeReference = 0,
        LinkedServiceReference = 1,
    }
    public enum IntegrationRuntimeLicenseType
    {
        BasePrice = 0,
        LicenseIncluded = 1,
    }
    public partial class IntegrationRuntimeReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeReference() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationRuntimeReferenceType
    {
        IntegrationRuntimeReference = 0,
    }
    public partial class IntegrationRuntimeSsisCatalogInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecretString CatalogAdminPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CatalogAdminUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeSsisCatalogPricingTier> CatalogPricingTier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CatalogServerEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DualStandbyPairName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationRuntimeSsisCatalogPricingTier
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
        PremiumRS = 3,
    }
    public partial class IntegrationRuntimeSsisProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeSsisProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeEdition> Edition { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeLicenseType> LicenseType { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryPackageStore> PackageStores { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum IntegrationRuntimeState
    {
        Initial = 0,
        Stopped = 1,
        Started = 2,
        Starting = 3,
        Stopping = 4,
        NeedRegistration = 5,
        Online = 6,
        Limited = 7,
        Offline = 8,
        AccessDenied = 9,
    }
    public partial class IntegrationRuntimeVnetProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IntegrationRuntimeVnetProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PublicIPs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> VnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InteractiveCapabilityStatus
    {
        Enabling = 0,
        Enabled = 1,
        Disabling = 2,
        Disabled = 3,
    }
    public partial class InteractiveQueryProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public InteractiveQueryProperties() { }
        public Azure.Provisioning.BicepValue<int> AutoTerminationMinutes { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.InteractiveCapabilityStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JiraLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public JiraLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JiraObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public JiraObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JiraSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public JiraSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public JsonDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodingName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonReadSettings : Azure.Provisioning.DataFactory.FormatReadSettings
    {
        public JsonReadSettings() { }
        public Azure.Provisioning.DataFactory.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonSink : Azure.Provisioning.DataFactory.CopySink
    {
        public JsonSink() { }
        public Azure.Provisioning.DataFactory.JsonWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public JsonSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.JsonReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JsonWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FilePattern { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LakehouseAuthenticationType
    {
        ServicePrincipal = 0,
        SystemAssignedManagedIdentity = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class LakeHouseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public LakeHouseLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ArtifactId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.LakehouseAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public LakeHouseLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public LakeHouseReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public LakeHouseTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseTableSink : Azure.Provisioning.DataFactory.CopySink
    {
        public LakeHouseTableSink() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionNameList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableActionOption { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseTableSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public LakeHouseTableSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimestampAsOf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> VersionAsOf { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LakeHouseWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public LakeHouseWriteSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LinkedIntegrationRuntimeKeyAuthorization : Azure.Provisioning.DataFactory.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeKeyAuthorization() { }
        public Azure.Provisioning.DataFactory.DataFactorySecretString Key { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.Provisioning.DataFactory.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization() { }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LinkedIntegrationRuntimeType : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LinkedIntegrationRuntimeType() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogLocationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogLocationSettings() { }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LogStorageSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public LogStorageSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableReliableLogging { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class LookupActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public LookupActivity() { }
        public Azure.Provisioning.DataFactory.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FirstRowOnly { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.CopyActivitySource Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatDecimalAsString { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MagentoLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MagentoLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MagentoObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MagentoObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MagentoSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public MagentoSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedIntegrationRuntime : Azure.Provisioning.DataFactory.DataFactoryIntegrationRuntimeProperties
    {
        public ManagedIntegrationRuntime() { }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CustomerVirtualNetworkSubnetId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.InteractiveQueryProperties InteractiveQuery { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ManagedVirtualNetworkReference ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.IntegrationRuntimeState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedVirtualNetworkReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedVirtualNetworkReference() { }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ManagedVirtualNetworkReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedVirtualNetworkReferenceType
    {
        ManagedVirtualNetworkReference = 0,
    }
    public partial class MapperAttributeMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperAttributeMapping() { }
        public Azure.Provisioning.DataFactory.MapperAttributeReference AttributeReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperAttributeReference> AttributeReferences { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FunctionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.MappingType> MappingType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperAttributeReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperAttributeReference() { }
        public Azure.Provisioning.BicepValue<string> Entity { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MapperConnectionReference EntityConnectionReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperConnection() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperDslConnectorProperties> CommonDslConnectorProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.MapperConnectionType> ConnectionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsInlineDataset { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedService { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkedServiceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperConnectionReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperConnectionReference() { }
        public Azure.Provisioning.BicepValue<string> ConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.MapperConnectionType> ConnectionType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MapperConnectionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="linkedservicetype")]
        Linkedservicetype = 0,
    }
    public partial class MapperDslConnectorProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperDslConnectorProperties() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperPolicy() { }
        public Azure.Provisioning.BicepValue<string> Mode { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MapperPolicyRecurrence Recurrence { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperPolicyRecurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperPolicyRecurrence() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.MapperPolicyRecurrenceFrequencyType> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MapperPolicyRecurrenceFrequencyType
    {
        Hour = 0,
        Minute = 1,
        Second = 2,
    }
    public partial class MapperSourceConnectionsInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperSourceConnectionsInfo() { }
        public Azure.Provisioning.DataFactory.MapperConnection Connection { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperTable> SourceEntities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperTable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperTable() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperDslConnectorProperties> DslConnectorProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperTableSchema> Schema { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperTableSchema : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperTableSchema() { }
        public Azure.Provisioning.BicepValue<string> DataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MapperTargetConnectionsInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MapperTargetConnectionsInfo() { }
        public Azure.Provisioning.DataFactory.MapperConnection Connection { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataMapperMapping> DataMapperMappings { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Relationships { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.MapperTable> TargetEntities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MappingType
    {
        Direct = 0,
        Derived = 1,
        Aggregate = 2,
    }
    public partial class MariaDBLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MariaDBLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DriverVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MariaDBSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public MariaDBSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MariaDBTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MariaDBTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MarketoLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MarketoLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MarketoObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MarketoObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MarketoSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public MarketoSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MicrosoftAccessLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MicrosoftAccessLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MicrosoftAccessSink : Azure.Provisioning.DataFactory.CopySink
    {
        public MicrosoftAccessSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MicrosoftAccessSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public MicrosoftAccessSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MicrosoftAccessTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MicrosoftAccessTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBAtlasCollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MongoDBAtlasCollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> Collection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBAtlasLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MongoDBAtlasLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DriverVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBAtlasSink : Azure.Provisioning.DataFactory.CopySink
    {
        public MongoDBAtlasSink() { }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBAtlasSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public MongoDBAtlasSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MongoDBAuthenticationType
    {
        Basic = 0,
        Anonymous = 1,
    }
    public partial class MongoDBCollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MongoDBCollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> CollectionName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBCursorMethodsProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MongoDBCursorMethodsProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Limit { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Project { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Skip { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Sort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MongoDBLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.MongoDBAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatabaseName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public MongoDBSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBV2CollectionDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MongoDBV2CollectionDataset() { }
        public Azure.Provisioning.BicepValue<string> Collection { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MongoDBV2LinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBV2Sink : Azure.Provisioning.DataFactory.CopySink
    {
        public MongoDBV2Sink() { }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MongoDBV2Source : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public MongoDBV2Source() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.MongoDBCursorMethodsProperties CursorMethods { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filter { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MultiplePipelineTrigger : Azure.Provisioning.DataFactory.DataFactoryTriggerProperties
    {
        public MultiplePipelineTrigger() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.TriggerPipelineReference> Pipelines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public MySqlLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowZeroDateTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ConvertZeroDateTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DriverVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GuidFormat { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TreatTinyAsBoolean { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public MySqlSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MySqlTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public MySqlTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetezzaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public NetezzaLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.NetezzaSecurityLevelType> SecurityLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetezzaPartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetezzaPartitionSettings() { }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetezzaSecurityLevelType
    {
        PreferredUnSecured = 0,
        OnlyUnSecured = 1,
    }
    public partial class NetezzaSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public NetezzaSource() { }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.NetezzaPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetezzaTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public NetezzaTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NotebookParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NotebookParameter() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.NotebookParameterType> ParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NotebookParameterType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="string")]
        String = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="int")]
        Int = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="float")]
        Float = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bool")]
        Bool = 3,
    }
    public enum NotebookReferenceType
    {
        NotebookReference = 0,
    }
    public enum ODataAadServicePrincipalCredentialType
    {
        ServicePrincipalKey = 0,
        ServicePrincipalCert = 1,
    }
    public enum ODataAuthenticationType
    {
        Basic = 0,
        Anonymous = 1,
        Windows = 2,
        AadServicePrincipal = 3,
        ManagedServiceIdentity = 4,
    }
    public partial class ODataLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ODataLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AadResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ODataAadServicePrincipalCredentialType> AadServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ODataAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> AuthHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ODataResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ODataResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ODataSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public ODataSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OdbcLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public OdbcLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OdbcSink : Azure.Provisioning.DataFactory.CopySink
    {
        public OdbcSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OdbcSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public OdbcSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OdbcTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public OdbcTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Office365Dataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public Office365Dataset() { }
        public Azure.Provisioning.BicepValue<string> Predicate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Office365LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public Office365LinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Office365TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalTenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Office365Source : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public Office365Source() { }
        public Azure.Provisioning.BicepList<string> AllowedGroups { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DateFilterColumn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.Office365TableOutputColumn> OutputColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserScopeFilterUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class Office365TableOutputColumn : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public Office365TableOutputColumn() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OracleAuthenticationType
    {
        Basic = 0,
    }
    public partial class OracleCloudStorageLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public OracleCloudStorageLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecretAccessKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleCloudStorageLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public OracleCloudStorageLocation() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleCloudStorageReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public OracleCloudStorageReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Prefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public OracleLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.OracleAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CryptoChecksumClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CryptoChecksumTypesClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableBulkLoad { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptionTypesClient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> FetchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FetchTswtzAsTimestamp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InitializationString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InitialLobFetchSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StatementCacheSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SupportV1DataTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OraclePartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OraclePartitionSettings() { }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleServiceCloudLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public OracleServiceCloudLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleServiceCloudObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public OracleServiceCloudObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleServiceCloudSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public OracleServiceCloudSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleSink : Azure.Provisioning.DataFactory.CopySink
    {
        public OracleSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public OracleSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberPrecision { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OracleReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.OraclePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OracleTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public OracleTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OrcDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public OrcDataset() { }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OrcCompressionCodec { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OrcSink : Azure.Provisioning.DataFactory.CopySink
    {
        public OrcSink() { }
        public Azure.Provisioning.DataFactory.OrcWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OrcSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public OrcSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OrcWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OrcWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRowsPerFile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParquetDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ParquetDataset() { }
        public Azure.Provisioning.BicepValue<string> CompressionCodec { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParquetReadSettings : Azure.Provisioning.DataFactory.FormatReadSettings
    {
        public ParquetReadSettings() { }
        public Azure.Provisioning.DataFactory.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParquetSink : Azure.Provisioning.DataFactory.CopySink
    {
        public ParquetSink() { }
        public Azure.Provisioning.DataFactory.ParquetWriteSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreWriteSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParquetSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public ParquetSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.ParquetReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ParquetWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ParquetWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileNamePrefix { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRowsPerFile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PaypalLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public PaypalLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PaypalObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public PaypalObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PaypalSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public PaypalSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PhoenixAuthenticationType
    {
        Anonymous = 0,
        UsernameAndPassword = 1,
        WindowsAzureHDInsightService = 2,
    }
    public partial class PhoenixLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public PhoenixLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.PhoenixAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PhoenixObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public PhoenixObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PhoenixSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public PhoenixSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineActivity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineActivity() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivityDependency> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ActivityOnInactiveMarkAs> OnInactiveMarkAs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.PipelineActivityState> State { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivityUserProperty> UserProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineActivityDependency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineActivityDependency() { }
        public Azure.Provisioning.BicepValue<string> Activity { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DependencyCondition> DependencyConditions { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineActivityPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineActivityPolicy() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureInputEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureOutputEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Retry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetryIntervalInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineActivityState
    {
        Active = 0,
        Inactive = 1,
    }
    public partial class PipelineActivityUserProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineActivityUserProperty() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineExternalComputeScaleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineExternalComputeScaleProperties() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfExternalNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfPipelineNodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeToLive { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineVariableSpecification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineVariableSpecification() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> DefaultValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.PipelineVariableType> VariableType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineVariableType
    {
        String = 0,
        Bool = 1,
        Array = 2,
    }
    public partial class PolybaseSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PolybaseSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RejectSampleValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.PolybaseSettingsRejectType> RejectType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RejectValue { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseTypeDefault { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PolybaseSettingsRejectType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="value")]
        Value = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="percentage")]
        Percentage = 1,
    }
    public partial class PostgreSqlLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public PostgreSqlLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public PostgreSqlSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public PostgreSqlTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public PostgreSqlV2LinkedService() { }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectionTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> LogParameters { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReadBufferSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timezone { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlV2Source : Azure.Provisioning.DataFactory.TabularSource
    {
        public PostgreSqlV2Source() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PostgreSqlV2TableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public PostgreSqlV2TableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PowerQuerySink : Azure.Provisioning.DataFactory.DataFlowSink
    {
        public PowerQuerySink() { }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PowerQuerySinkMapping : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PowerQuerySinkMapping() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PowerQuerySink> DataflowSinks { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PowerQuerySource : Azure.Provisioning.DataFactory.DataFlowSource
    {
        public PowerQuerySource() { }
        public Azure.Provisioning.BicepValue<string> Script { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PrestoAuthenticationType
    {
        Anonymous = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="LDAP")]
        Ldap = 1,
    }
    public partial class PrestoLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public PrestoLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.PrestoAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Catalog { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServerVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZoneId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrestoObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public PrestoObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrestoSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public PrestoSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateLinkConnectionApprovalRequest : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkConnectionApprovalRequest() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateEndpointId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PrivateLinkConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateLinkConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateLinkConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuickbaseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public QuickbaseLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret UserToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuickBooksLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public QuickBooksLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessTokenSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CompanyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConsumerKey { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ConsumerSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuickBooksObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public QuickBooksObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class QuickBooksSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public QuickBooksSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedirectIncompatibleRowSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedirectIncompatibleRowSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RedshiftUnloadSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RedshiftUnloadSettings() { }
        public Azure.Provisioning.BicepValue<string> BucketName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference S3LinkedServiceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RelationalSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public RelationalSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RelationalTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public RelationalTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RerunTumblingWindowTrigger : Azure.Provisioning.DataFactory.DataFactoryTriggerProperties
    {
        public RerunTumblingWindowTrigger() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> ParentTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestedEndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> RequestedStartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RerunConcurrency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponsysLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ResponsysLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponsysObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ResponsysObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponsysSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ResponsysSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public RestResourceDataset() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> PaginationRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelativeUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RestServiceAuthenticationType
    {
        Anonymous = 0,
        Basic = 1,
        AadServicePrincipal = 2,
        ManagedServiceIdentity = 3,
        OAuth2ClientCredential = 4,
    }
    public partial class RestServiceLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public RestServiceLinkedService() { }
        public Azure.Provisioning.BicepValue<string> AadResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.RestServiceAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> AuthHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureCloudType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TokenEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestSink : Azure.Provisioning.DataFactory.CopySink
    {
        public RestSink() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpCompressionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> RequestInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RestSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public RestSource() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdditionalHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PaginationRules { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestBody { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> RequestInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMethod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RetryPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RetryPolicy() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> IntervalInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SalesforceLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentUri { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecurityToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceMarketingCloudLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SalesforceMarketingCloudLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceMarketingCloudObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SalesforceMarketingCloudObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceMarketingCloudSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SalesforceMarketingCloudSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SalesforceObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> ObjectApiName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SalesforceServiceCloudLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtendedProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret SecurityToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SalesforceServiceCloudObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> ObjectApiName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SalesforceServiceCloudSink() { }
        public Azure.Provisioning.BicepValue<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SalesforceSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public SalesforceServiceCloudSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReadBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SalesforceServiceCloudV2LinkedService() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudV2ObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SalesforceServiceCloudV2ObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> ObjectApiName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReportId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudV2Sink : Azure.Provisioning.DataFactory.CopySink
    {
        public SalesforceServiceCloudV2Sink() { }
        public Azure.Provisioning.BicepValue<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SalesforceV2SinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceServiceCloudV2Source : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public SalesforceServiceCloudV2Source() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IncludeDeletedObjects { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SoqlQuery { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SalesforceSink() { }
        public Azure.Provisioning.BicepValue<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SalesforceSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SalesforceSinkWriteBehavior
    {
        Insert = 0,
        Upsert = 1,
    }
    public partial class SalesforceSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SalesforceSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReadBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SalesforceV2LinkedService() { }
        public Azure.Provisioning.BicepValue<string> ApiVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceV2ObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SalesforceV2ObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> ObjectApiName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReportId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SalesforceV2Sink : Azure.Provisioning.DataFactory.CopySink
    {
        public SalesforceV2Sink() { }
        public Azure.Provisioning.BicepValue<string> ExternalIdFieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IgnoreNullValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SalesforceV2SinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SalesforceV2SinkWriteBehavior
    {
        Insert = 0,
        Upsert = 1,
    }
    public partial class SalesforceV2Source : Azure.Provisioning.DataFactory.TabularSource
    {
        public SalesforceV2Source() { }
        public Azure.Provisioning.BicepValue<bool> IncludeDeletedObjects { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PageSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SoqlQuery { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapBWCubeDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapBWCubeDataset() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapBWLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapBWLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapBWSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapBWSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapCloudForCustomerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapCloudForCustomerLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapCloudForCustomerResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapCloudForCustomerResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapCloudForCustomerSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SapCloudForCustomerSink() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SapCloudForCustomerSinkWriteBehavior> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SapCloudForCustomerSinkWriteBehavior
    {
        Insert = 0,
        Update = 1,
    }
    public partial class SapCloudForCustomerSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapCloudForCustomerSource() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapEccLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapEccLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapEccResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapEccResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapEccSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapEccSource() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SapHanaAuthenticationType
    {
        Basic = 0,
        Windows = 1,
    }
    public partial class SapHanaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapHanaLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SapHanaAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapHanaSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapHanaSource() { }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapHanaTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapHanaTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOdpLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapOdpLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogonGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServerService { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SncFlag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncLibraryPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncMyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncPartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncQop { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriberName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> X509CertificatePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOdpResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapOdpResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> Context { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ObjectName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOdpSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapOdpSource() { }
        public Azure.Provisioning.BicepValue<string> ExtractionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Projection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Selection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriberProcess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOpenHubLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapOpenHubLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogonGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServerService { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOpenHubSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapOpenHubSource() { }
        public Azure.Provisioning.BicepValue<int> BaseRequestId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ExcludeLastRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SapDataColumnDelimiter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapOpenHubTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapOpenHubTableDataset() { }
        public Azure.Provisioning.BicepValue<int> BaseRequestId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ExcludeLastRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OpenHubDestinationName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapTableLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SapTableLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogonGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MessageServerService { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SncFlag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncLibraryPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncMyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncPartnerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SncQop { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SystemNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapTablePartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SapTablePartitionSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxPartitionsNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapTableResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SapTableResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SapTableSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SapTableSource() { }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomRfcReadTableFunctionModule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SapTablePartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RfcTableFields { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RfcTableOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RowCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RowSkips { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SapDataColumnDelimiter { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScheduleTriggerRecurrence : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScheduleTriggerRecurrence() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactoryRecurrenceFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryRecurrenceSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScriptActivityLogDestination
    {
        ActivityOutput = 0,
        ExternalStore = 1,
    }
    public partial class ScriptActivityParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptActivityParameter() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ScriptActivityParameterDirection> Direction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ScriptActivityParameterType> ParameterType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ScriptActivityParameterDirection
    {
        Input = 0,
        Output = 1,
        InputOutput = 2,
    }
    public enum ScriptActivityParameterType
    {
        Boolean = 0,
        DateTime = 1,
        DateTimeOffset = 2,
        Decimal = 3,
        Double = 4,
        Guid = 5,
        Int16 = 6,
        Int32 = 7,
        Int64 = 8,
        Single = 9,
        String = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Timespan")]
        TimeSpan = 11,
    }
    public partial class ScriptActivityScriptBlock : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptActivityScriptBlock() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.ScriptActivityParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Text { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ScriptActivityTypeLogSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ScriptActivityTypeLogSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ScriptActivityLogDestination> LogDestination { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.LogLocationSettings LogLocationSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SecureInputOutputPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SecureInputOutputPolicy() { }
        public Azure.Provisioning.BicepValue<bool> IsSecureInputEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSecureOutputEnabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfDependencyTumblingWindowTriggerReference : Azure.Provisioning.DataFactory.DependencyReference
    {
        public SelfDependencyTumblingWindowTriggerReference() { }
        public Azure.Provisioning.BicepValue<string> Offset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHostedIntegrationRuntime : Azure.Provisioning.DataFactory.DataFactoryIntegrationRuntimeProperties
    {
        public SelfHostedIntegrationRuntime() { }
        public Azure.Provisioning.BicepValue<bool> IsSelfContainedInteractiveAuthoringEnabled { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceNowAuthenticationType
    {
        Basic = 0,
        OAuth2 = 1,
    }
    public partial class ServiceNowLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ServiceNowLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ServiceNowAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceNowObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ServiceNowObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceNowSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ServiceNowSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServiceNowV2AuthenticationType
    {
        Basic = 0,
        OAuth2 = 1,
    }
    public partial class ServiceNowV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ServiceNowV2LinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ServiceNowV2AuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GrantType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceNowV2ObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ServiceNowV2ObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DatasetSourceValueType> ValueType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceNowV2Source : Azure.Provisioning.DataFactory.TabularSource
    {
        public ServiceNowV2Source() { }
        public Azure.Provisioning.DataFactory.DataFactoryExpressionV2 Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PageSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServicePrincipalCredential : Azure.Provisioning.DataFactory.DataFactoryCredential
    {
        public ServicePrincipalCredential() { }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SetVariableActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public SetVariableActivity() { }
        public Azure.Provisioning.DataFactory.SecureInputOutputPolicy Policy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SetSystemVariable { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Value { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VariableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SftpAuthenticationType
    {
        Basic = 0,
        SshPublicKey = 1,
        MultiFactor = 2,
    }
    public partial class SftpLocation : Azure.Provisioning.DataFactory.DatasetLocation
    {
        public SftpLocation() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SftpReadSettings : Azure.Provisioning.DataFactory.StoreReadSettings
    {
        public SftpReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> DeleteFilesAfterCompletion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableChunking { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnablePartitionDiscovery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileListPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModifiedDatetimeStart { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionRootPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Recursive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WildcardFolderPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SftpServerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SftpServerLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SftpAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostKeyFingerprint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PassPhrase { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PrivateKeyContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateKeyPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SkipHostKeyValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SftpWriteSettings : Azure.Provisioning.DataFactory.StoreWriteSettings
    {
        public SftpWriteSettings() { }
        public Azure.Provisioning.BicepValue<string> OperationTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseTempFileRename { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharePointOnlineListLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SharePointOnlineListLinkedService() { }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCert { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalEmbeddedCertPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SiteUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharePointOnlineListResourceDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SharePointOnlineListResourceDataset() { }
        public Azure.Provisioning.BicepValue<string> ListName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SharePointOnlineListSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public SharePointOnlineListSource() { }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ShopifyLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ShopifyLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ShopifyObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ShopifyObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ShopifySource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ShopifySource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SkipErrorFile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SkipErrorFile() { }
        public Azure.Provisioning.BicepValue<bool> DataInconsistency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> FileMissing { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SmartsheetLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SmartsheetLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SnowflakeAuthenticationType
    {
        Basic = 0,
        KeyPair = 1,
        AADServicePrincipal = 2,
    }
    public partial class SnowflakeDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SnowflakeDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeExportCopyCommand : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SnowflakeExportCopyCommand() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalCopyOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalFormatOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageIntegration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeImportCopyCommand : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SnowflakeImportCopyCommand() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalCopyOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalFormatOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageIntegration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SnowflakeLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SnowflakeSink() { }
        public Azure.Provisioning.DataFactory.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public SnowflakeSource() { }
        public Azure.Provisioning.DataFactory.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeV2Dataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SnowflakeV2Dataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeV2LinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SnowflakeV2LinkedService() { }
        public Azure.Provisioning.BicepValue<string> AccountIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SnowflakeAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PrivateKey { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PrivateKeyPassphrase { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Role { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> User { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseUtcTimestamps { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Warehouse { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeV2Sink : Azure.Provisioning.DataFactory.CopySink
    {
        public SnowflakeV2Sink() { }
        public Azure.Provisioning.DataFactory.SnowflakeImportCopyCommand ImportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SnowflakeV2Source : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public SnowflakeV2Source() { }
        public Azure.Provisioning.DataFactory.SnowflakeExportCopyCommand ExportSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SparkAuthenticationType
    {
        Anonymous = 0,
        Username = 1,
        UsernameAndPassword = 2,
        WindowsAzureHDInsightService = 3,
    }
    public partial class SparkConfigurationParametrizationReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SparkConfigurationParametrizationReference() { }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SparkConfigurationReferenceType> ReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SparkConfigurationReferenceType
    {
        SparkConfigurationReference = 0,
    }
    public enum SparkJobReferenceType
    {
        SparkJobDefinitionReference = 0,
    }
    public partial class SparkLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SparkLinkedService() { }
        public Azure.Provisioning.BicepValue<bool> AllowHostNameCNMismatch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowSelfSignedServerCert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SparkAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServerCertificateValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSsl { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpPath { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SparkServerType> ServerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SparkThriftTransportProtocol> ThriftTransportProtocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrustedCertPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseSystemTrustStore { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SparkObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SparkServerType
    {
        SharkServer = 0,
        SharkServer2 = 1,
        SparkThriftServer = 2,
    }
    public partial class SparkSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SparkSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SparkThriftTransportProtocol
    {
        Binary = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SASL")]
        Sasl = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HTTP ")]
        Http = 2,
    }
    public enum SqlAlwaysEncryptedAkvAuthType
    {
        ServicePrincipal = 0,
        ManagedIdentity = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class SqlAlwaysEncryptedProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlAlwaysEncryptedProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SqlAlwaysEncryptedAkvAuthType> AlwaysEncryptedAkvAuthType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlDWSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SqlDWSink() { }
        public Azure.Provisioning.BicepValue<bool> AllowCopyCommand { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AllowPolyBase { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.PolybaseSettings PolyBaseSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlDWUpsertSettings UpsertSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlDWSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SqlDWSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlDWUpsertSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlDWUpsertSettings() { }
        public Azure.Provisioning.BicepValue<string> InterimSchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Keys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlMISink : Azure.Provisioning.DataFactory.CopySink
    {
        public SqlMISink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlMISource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SqlMISource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlPartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlPartitionSettings() { }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SqlServerAuthenticationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SQL")]
        Sql = 0,
        Windows = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class SqlServerLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SqlServerLinkedService() { }
        public Azure.Provisioning.DataFactory.SqlAlwaysEncryptedProperties AlwaysEncryptedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApplicationIntent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SqlServerAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CommandTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectRetryInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ConnectTimeout { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Encrypt { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FailoverPartner { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HostNameInCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IntegratedSecurity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LoadBalanceTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinPoolSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultipleActiveResultSets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiSubnetFailover { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PacketSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Pooling { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TrustServerCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SqlServerSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SqlServerSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ProduceAdditionalTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerStoredProcedureActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public SqlServerStoredProcedureActivity() { }
        public Azure.Provisioning.BicepValue<string> StoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlServerTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SqlServerTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlSink : Azure.Provisioning.DataFactory.CopySink
    {
        public SqlSink() { }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlWriterTableType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SqlWriterUseTableLock { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoredProcedureTableTypeParameterName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlUpsertSettings UpsertSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SqlSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SqlUpsertSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SqlUpsertSettings() { }
        public Azure.Provisioning.BicepValue<string> InterimSchemaName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseTempDB { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SquareLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SquareLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RedirectUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SquareObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SquareObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SquareSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SquareSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SsisAccessCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisAccessCredential() { }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SsisChildPackage : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisChildPackage() { }
        public Azure.Provisioning.BicepValue<string> PackageContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageLastModifiedDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackagePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SsisExecutionCredential : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisExecutionCredential() { }
        public Azure.Provisioning.BicepValue<string> Domain { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecretString Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SsisExecutionParameter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisExecutionParameter() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SsisLogLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisLogLocation() { }
        public Azure.Provisioning.DataFactory.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SsisLogLocationType> LocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogRefreshInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SsisLogLocationType
    {
        File = 0,
    }
    public partial class SsisPackageLocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisPackageLocation() { }
        public Azure.Provisioning.DataFactory.SsisAccessCredential AccessCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.SsisChildPackage> ChildPackages { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SsisAccessCredential ConfigurationAccessCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConfigurationPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SsisPackageLocationType> LocationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageLastModifiedDate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackageName { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PackagePassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PackagePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SsisPackageLocationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="SSISDB")]
        SsisDB = 0,
        File = 1,
        InlinePackage = 2,
        PackageStore = 3,
    }
    public partial class SsisPropertyOverride : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SsisPropertyOverride() { }
        public Azure.Provisioning.BicepValue<bool> IsSensitive { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StagingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StagingSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableCompression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference LinkedServiceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StoreReadSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StoreReadSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentConnections { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StoreWriteSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StoreWriteSettings() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CopyBehavior { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableMetricsCollection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryMetadataItemInfo> Metadata { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SwitchActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public SwitchActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.SwitchCaseActivity> Cases { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> DefaultActivities { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryExpression On { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SwitchCaseActivity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SwitchCaseActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> Activities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SybaseAuthenticationType
    {
        Basic = 0,
        Windows = 1,
    }
    public partial class SybaseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public SybaseLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SybaseAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SybaseSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public SybaseSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SybaseTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public SybaseTableDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SynapseNotebookActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public SynapseNotebookActivity() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> Conf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactorySparkConfigurationType> ConfigurationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DriverSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExecutorSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SynapseNotebookReference Notebook { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumExecutors { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.DataFactory.NotebookParameter> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> SparkConfig { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.BigDataPoolParametrizationReference SparkPool { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SynapseNotebookReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SynapseNotebookReference() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.NotebookReferenceType> NotebookReferenceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SynapseSparkJobDefinitionActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public SynapseSparkJobDefinitionActivity() { }
        public Azure.Provisioning.BicepList<System.BinaryData> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClassName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Conf { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.DataFactorySparkConfigurationType> ConfigurationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DriverSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExecutorSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> File { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> Files { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> FilesV2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumExecutors { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<System.BinaryData> PythonCodeReference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ScanFolder { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> SparkConfig { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SynapseSparkJobReference SparkJob { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.BigDataPoolParametrizationReference TargetBigDataPool { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SparkConfigurationParametrizationReference TargetSparkConfiguration { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SynapseSparkJobReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SynapseSparkJobReference() { }
        public Azure.Provisioning.BicepValue<string> ReferenceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.SparkJobReferenceType> SparkJobReferenceType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TabularSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public TabularSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> QueryTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TarGzipReadSettings : Azure.Provisioning.DataFactory.CompressionReadSettings
    {
        public TarGzipReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TarReadSettings : Azure.Provisioning.DataFactory.CompressionReadSettings
    {
        public TarReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> PreserveCompressionFileNameAsFolder { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TeamDeskAuthenticationType
    {
        Basic = 0,
        Token = 1,
    }
    public partial class TeamDeskLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public TeamDeskLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.TeamDeskAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TeradataAuthenticationType
    {
        Basic = 0,
        Windows = 1,
    }
    public partial class TeradataImportCommand : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TeradataImportCommand() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalFormatOptions { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> AdditionalProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TeradataLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public TeradataLinkedService() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.TeradataAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CharacterSet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> HttpsPortNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxRespSize { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> PortNumber { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SslMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> UseDataEncryption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TeradataPartitionSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TeradataPartitionSettings() { }
        public Azure.Provisioning.BicepValue<string> PartitionColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionLowerBound { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PartitionUpperBound { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TeradataSink : Azure.Provisioning.DataFactory.CopySink
    {
        public TeradataSink() { }
        public Azure.Provisioning.DataFactory.TeradataImportCommand ImportSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TeradataSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public TeradataSource() { }
        public Azure.Provisioning.BicepValue<string> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.TeradataPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TeradataTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public TeradataTableDataset() { }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TriggerDependencyReference : Azure.Provisioning.DataFactory.DependencyReference
    {
        public TriggerDependencyReference() { }
        public Azure.Provisioning.DataFactory.DataFactoryTriggerReference ReferenceTrigger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TriggerPipelineReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TriggerPipelineReference() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryPipelineReference PipelineReference { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TumblingWindowFrequency
    {
        Minute = 0,
        Hour = 1,
        Month = 2,
    }
    public partial class TumblingWindowTrigger : Azure.Provisioning.DataFactory.DataFactoryTriggerProperties
    {
        public TumblingWindowTrigger() { }
        public Azure.Provisioning.BicepValue<string> Delay { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DependencyReference> DependsOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> EndOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.TumblingWindowFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrency { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.TriggerPipelineReference Pipeline { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.RetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TumblingWindowTriggerDependencyReference : Azure.Provisioning.DataFactory.TriggerDependencyReference
    {
        public TumblingWindowTriggerDependencyReference() { }
        public Azure.Provisioning.BicepValue<string> Offset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TwilioLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public TwilioLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class UntilActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public UntilActivity() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.PipelineActivity> Activities { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryExpression Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ValidationActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public ValidationActivity() { }
        public Azure.Provisioning.BicepValue<bool> ChildItems { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetReference Dataset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinimumSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Sleep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VerticaLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public VerticaLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Database { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryKeyVaultSecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Server { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uid { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VerticaSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public VerticaSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VerticaTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public VerticaTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WaitActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public WaitActivity() { }
        public Azure.Provisioning.BicepValue<int> WaitTimeInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WarehouseAuthenticationType
    {
        ServicePrincipal = 0,
        SystemAssignedManagedIdentity = 1,
        UserAssignedManagedIdentity = 2,
    }
    public partial class WarehouseLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public WarehouseLinkedService() { }
        public Azure.Provisioning.BicepValue<string> ArtifactId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.WarehouseAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalCredentialType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServicePrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ServicePrincipalKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WarehouseSink : Azure.Provisioning.DataFactory.CopySink
    {
        public WarehouseSink() { }
        public Azure.Provisioning.BicepValue<bool> AllowCopyCommand { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DWCopyCommandSettings CopyCommandSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PreCopyScript { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TableOption { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WriteBehavior { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WarehouseSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public WarehouseSource() { }
        public Azure.Provisioning.BicepValue<string> IsolationLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PartitionOption { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SqlPartitionSettings PartitionSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderQuery { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SqlReaderStoredProcedureName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> StoredProcedureParameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WarehouseTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public WarehouseTableDataset() { }
        public Azure.Provisioning.BicepValue<string> SchemaTypePropertiesSchema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Table { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebActivity : Azure.Provisioning.DataFactory.ExecutionActivity
    {
        public WebActivity() { }
        public Azure.Provisioning.DataFactory.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.IntegrationRuntimeReference ConnectVia { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DatasetReference> Datasets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableCertValidation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HttpRequestTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DataFactory.DataFactoryLinkedServiceReference> LinkedServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.WebActivityMethod> Method { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> RequestHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> TurnOffAsync { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebActivityAuthentication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebActivityAuthentication() { }
        public Azure.Provisioning.DataFactory.DataFactoryCredentialReference Credential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Pfx { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Resource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserTenant { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WebActivityAuthenticationType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebActivityMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="GET")]
        Get = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="PUT")]
        Put = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="DELETE")]
        Delete = 3,
    }
    public partial class WebAnonymousAuthentication : Azure.Provisioning.DataFactory.WebLinkedServiceTypeProperties
    {
        public WebAnonymousAuthentication() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebBasicAuthentication : Azure.Provisioning.DataFactory.WebLinkedServiceTypeProperties
    {
        public WebBasicAuthentication() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebClientCertificateAuthentication : Azure.Provisioning.DataFactory.WebLinkedServiceTypeProperties
    {
        public WebClientCertificateAuthentication() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Pfx { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebHookActivity : Azure.Provisioning.DataFactory.ControlActivity
    {
        public WebHookActivity() { }
        public Azure.Provisioning.DataFactory.WebActivityAuthentication Authentication { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Body { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.WebHookActivityMethod> Method { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.SecureInputOutputPolicy Policy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ReportStatusOnCallBack { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> RequestHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WebHookActivityMethod
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="POST")]
        Post = 0,
    }
    public partial class WebLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public WebLinkedService() { }
        public Azure.Provisioning.DataFactory.WebLinkedServiceTypeProperties TypeProperties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebLinkedServiceTypeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WebLinkedServiceTypeProperties() { }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public WebSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WebTableDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public WebTableDataset() { }
        public Azure.Provisioning.BicepValue<int> Index { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XeroLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public XeroLinkedService() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret ConsumerKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret PrivateKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XeroObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public XeroObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XeroSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public XeroSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XmlDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public XmlDataset() { }
        public Azure.Provisioning.DataFactory.DatasetCompression Compression { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DatasetLocation DataLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodingName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NullValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XmlReadSettings : Azure.Provisioning.DataFactory.FormatReadSettings
    {
        public XmlReadSettings() { }
        public Azure.Provisioning.DataFactory.CompressionReadSettings CompressionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DetectDataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> NamespacePrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Namespaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class XmlSource : Azure.Provisioning.DataFactory.CopyActivitySource
    {
        public XmlSource() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> AdditionalColumns { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.XmlReadSettings FormatSettings { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.StoreReadSettings StoreSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ZendeskAuthenticationType
    {
        Basic = 0,
        Token = 1,
    }
    public partial class ZendeskLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ZendeskLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret ApiToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DataFactory.ZendeskAuthenticationType> AuthenticationType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.DataFactory.DataFactorySecret Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Uri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ZipDeflateReadSettings : Azure.Provisioning.DataFactory.CompressionReadSettings
    {
        public ZipDeflateReadSettings() { }
        public Azure.Provisioning.BicepValue<bool> PreserveZipFileNameAsFolder { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ZohoLinkedService : Azure.Provisioning.DataFactory.DataFactoryLinkedServiceProperties
    {
        public ZohoLinkedService() { }
        public Azure.Provisioning.DataFactory.DataFactorySecret AccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> ConnectionProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncryptedCredential { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseEncryptedEndpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseHostVerification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UsePeerVerification { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ZohoObjectDataset : Azure.Provisioning.DataFactory.DataFactoryDatasetProperties
    {
        public ZohoObjectDataset() { }
        public Azure.Provisioning.BicepValue<string> TableName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ZohoSource : Azure.Provisioning.DataFactory.TabularSource
    {
        public ZohoSource() { }
        public Azure.Provisioning.BicepValue<string> Query { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
