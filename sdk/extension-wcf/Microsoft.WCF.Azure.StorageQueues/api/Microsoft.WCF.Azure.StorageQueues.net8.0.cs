namespace Microsoft.WCF.Azure
{
    public partial class AzureClientCredentials : System.ServiceModel.Description.ClientCredentials
    {
        public AzureClientCredentials() { }
        protected AzureClientCredentials(Microsoft.WCF.Azure.AzureClientCredentials other) { }
        public Azure.Storage.Queues.Models.QueueAudience Audience { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Identity.DefaultAzureCredentialOptions DefaultAzureCredentialOptions { get { throw null; } set { } }
        public bool EnableTenantDiscovery { get { throw null; } set { } }
        public Azure.AzureSasCredential Sas { get { throw null; } set { } }
        public Azure.Storage.StorageSharedKeyCredential StorageSharedKey { get { throw null; } set { } }
        public Azure.Core.TokenCredential Token { get { throw null; } set { } }
        protected override System.ServiceModel.Description.ClientCredentials CloneCore() { throw null; }
        public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager() { throw null; }
    }
    public partial class AzureClientCredentialsSecurityTokenManager : System.ServiceModel.ClientCredentialsSecurityTokenManager
    {
        public AzureClientCredentialsSecurityTokenManager(Microsoft.WCF.Azure.AzureClientCredentials azureClientCredentials) : base (default(System.ServiceModel.Description.ClientCredentials)) { }
        public override System.IdentityModel.Selectors.SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(System.IdentityModel.Selectors.SecurityTokenRequirement tokenRequirement, out System.IdentityModel.Selectors.SecurityTokenResolver outOfBandTokenResolver) { throw null; }
        public override System.IdentityModel.Selectors.SecurityTokenProvider CreateSecurityTokenProvider(System.IdentityModel.Selectors.SecurityTokenRequirement tokenRequirement) { throw null; }
        public override System.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(System.IdentityModel.Selectors.SecurityTokenVersion version) { throw null; }
    }
    public enum AzureClientCredentialType
    {
        Default = 0,
        Sas = 1,
        StorageSharedKey = 2,
        Token = 3,
        ConnectionString = 4,
    }
    public static partial class ClientCredentialsExtensions
    {
        public static Microsoft.WCF.Azure.AzureClientCredentials UseAzureCredentials(this System.ServiceModel.ChannelFactory channelFactory) { throw null; }
        public static Microsoft.WCF.Azure.AzureClientCredentials UseAzureCredentials(this System.ServiceModel.ChannelFactory channelFactory, System.Action<Microsoft.WCF.Azure.AzureClientCredentials> configure) { throw null; }
    }
}
namespace Microsoft.WCF.Azure.StorageQueues
{
    public partial class AzureQueueStorageBinding : System.ServiceModel.Channels.Binding
    {
        public AzureQueueStorageBinding() { }
        public Microsoft.WCF.Azure.StorageQueues.AzureQueueStorageMessageEncoding MessageEncoding { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public Microsoft.WCF.Azure.StorageQueues.AzureQueueStorageSecurity Security { get { throw null; } set { } }
        public override System.ServiceModel.Channels.BindingElementCollection CreateBindingElements() { throw null; }
    }
    public enum AzureQueueStorageMessageEncoding
    {
        Binary = 0,
        Text = 1,
    }
    public partial class AzureQueueStorageSecurity
    {
        public AzureQueueStorageSecurity() { }
        public Microsoft.WCF.Azure.StorageQueues.AzureQueueStorageTransportSecurity Transport { get { throw null; } set { } }
    }
    public partial class AzureQueueStorageTransportSecurity
    {
        public AzureQueueStorageTransportSecurity() { }
        public Microsoft.WCF.Azure.AzureClientCredentialType ClientCredentialType { get { throw null; } set { } }
    }
}
namespace Microsoft.WCF.Azure.StorageQueues.Channels
{
    public partial class AzureQueueStorageTransportBindingElement : System.ServiceModel.Channels.TransportBindingElement
    {
        public AzureQueueStorageTransportBindingElement() { }
        protected AzureQueueStorageTransportBindingElement(Microsoft.WCF.Azure.StorageQueues.Channels.AzureQueueStorageTransportBindingElement other) { }
        public Microsoft.WCF.Azure.AzureClientCredentialType ClientCredentialType { get { throw null; } set { } }
        public Azure.Storage.Queues.QueueMessageEncoding QueueMessageEncoding { get { throw null; } set { } }
        public override string Scheme { get { throw null; } }
        public override System.ServiceModel.Channels.IChannelFactory<TChannel> BuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override bool CanBuildChannelFactory<TChannel>(System.ServiceModel.Channels.BindingContext context) { throw null; }
        public override System.ServiceModel.Channels.BindingElement Clone() { throw null; }
        public override T GetProperty<T>(System.ServiceModel.Channels.BindingContext context) { throw null; }
    }
}
