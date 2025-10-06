namespace Microsoft.CoreWCF.Azure
{
    public enum AzureClientCredentialType
    {
        Default = 0,
        Sas = 1,
        StorageSharedKey = 2,
        Token = 3,
        ConnectionString = 4,
    }
    public partial class AzureServiceCredentials : CoreWCF.Description.ServiceCredentials
    {
        public AzureServiceCredentials() { }
        protected AzureServiceCredentials(Microsoft.CoreWCF.Azure.AzureServiceCredentials other) { }
        public Azure.Storage.Queues.Models.QueueAudience Audience { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Identity.DefaultAzureCredentialOptions DefaultAzureCredentialOptions { get { throw null; } set { } }
        public bool EnableTenantDiscovery { get { throw null; } set { } }
        public Azure.AzureSasCredential Sas { get { throw null; } set { } }
        public Azure.Storage.StorageSharedKeyCredential StorageSharedKey { get { throw null; } set { } }
        public Azure.Core.TokenCredential Token { get { throw null; } set { } }
        protected override CoreWCF.Description.ServiceCredentials CloneCore() { throw null; }
        public override CoreWCF.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager() { throw null; }
    }
    public partial class AzureServiceCredentialsSecurityTokenManager : CoreWCF.Security.ServiceCredentialsSecurityTokenManager
    {
        public AzureServiceCredentialsSecurityTokenManager(Microsoft.CoreWCF.Azure.AzureServiceCredentials azureServiceCredentials) : base (default(CoreWCF.Description.ServiceCredentials)) { }
        public override CoreWCF.IdentityModel.Selectors.SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(CoreWCF.IdentityModel.Selectors.SecurityTokenRequirement tokenRequirement, out CoreWCF.IdentityModel.Selectors.SecurityTokenResolver outOfBandTokenResolver) { throw null; }
        public override CoreWCF.IdentityModel.Selectors.SecurityTokenProvider CreateSecurityTokenProvider(CoreWCF.IdentityModel.Selectors.SecurityTokenRequirement tokenRequirement) { throw null; }
        public override CoreWCF.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(CoreWCF.IdentityModel.Selectors.SecurityTokenVersion version) { throw null; }
    }
    public static partial class ServiceCredentialsExtensions
    {
        public static Microsoft.CoreWCF.Azure.AzureServiceCredentials UseAzureCredentials(this CoreWCF.ServiceHostBase serviceHostBase) { throw null; }
        public static Microsoft.CoreWCF.Azure.AzureServiceCredentials UseAzureCredentials<TService>(this CoreWCF.Configuration.IServiceBuilder serviceBuilder) where TService : class { throw null; }
        public static void UseAzureCredentials<TService>(this CoreWCF.Configuration.IServiceBuilder serviceBuilder, System.Action<Microsoft.CoreWCF.Azure.AzureServiceCredentials> configure) where TService : class { }
    }
}
namespace Microsoft.CoreWCF.Azure.StorageQueues
{
    public partial class AzureQueueStorageBinding : CoreWCF.Channels.Binding
    {
        public AzureQueueStorageBinding(string deadLetterQueueName = "default-dead-letter-queue") { }
        public string DeadLetterQueueName { get { throw null; } set { } }
        public long MaxMessageSize { get { throw null; } set { } }
        public Microsoft.CoreWCF.Azure.StorageQueues.AzureQueueStorageMessageEncoding MessageEncoding { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public Microsoft.CoreWCF.Azure.StorageQueues.AzureQueueStorageSecurity Security { get { throw null; } set { } }
        public override CoreWCF.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public enum AzureQueueStorageMessageEncoding
    {
        Binary = 0,
        Text = 1,
    }
    public partial class AzureQueueStorageSecurity
    {
        public AzureQueueStorageSecurity() { }
        public Microsoft.CoreWCF.Azure.StorageQueues.AzureQueueStorageTransportSecurity Transport { get { throw null; } set { } }
    }
    public partial class AzureQueueStorageTransportSecurity
    {
        public AzureQueueStorageTransportSecurity() { }
        public Microsoft.CoreWCF.Azure.AzureClientCredentialType ClientCredentialType { get { throw null; } set { } }
    }
}
namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    public partial class AzureQueueStorageTransportBindingElement : CoreWCF.Queue.Common.Configuration.QueueBaseTransportBindingElement, CoreWCF.Configuration.ITransportServiceBuilder
    {
        public AzureQueueStorageTransportBindingElement() { }
        protected AzureQueueStorageTransportBindingElement(Microsoft.CoreWCF.Azure.StorageQueues.Channels.AzureQueueStorageTransportBindingElement other) { }
        public Microsoft.CoreWCF.Azure.AzureClientCredentialType ClientCredentialType { get { throw null; } set { } }
        public string DeadLetterQueueName { get { throw null; } set { } }
        public override long MaxReceivedMessageSize { get { throw null; } set { } }
        public System.TimeSpan MaxReceiveTimeout { get { throw null; } set { } }
        public System.TimeSpan PollingInterval { get { throw null; } set { } }
        public Azure.Storage.Queues.QueueMessageEncoding QueueMessageEncoding { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public override CoreWCF.Queue.Common.QueueTransportPump BuildQueueTransportPump(CoreWCF.Channels.BindingContext context) { throw null; }
        public override CoreWCF.Channels.BindingElement Clone() { throw null; }
        void CoreWCF.Configuration.ITransportServiceBuilder.Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder app) { }
        public override T GetProperty<T>(CoreWCF.Channels.BindingContext context) { throw null; }
    }
}
