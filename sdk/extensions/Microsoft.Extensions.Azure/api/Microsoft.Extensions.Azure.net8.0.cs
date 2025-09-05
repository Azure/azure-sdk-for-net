namespace Microsoft.Extensions.Azure
{
    public static partial class AzureClientBuilderExtensions
    {
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, Microsoft.Extensions.Configuration.IConfiguration configuration) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, System.Action<TOptions, System.IServiceProvider> configureOptions) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, System.Action<TOptions> configureOptions) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, Azure.Core.TokenCredential credential) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, System.Func<System.IServiceProvider, Azure.Core.TokenCredential> credentialFactory) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> WithName<TClient, TOptions>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, string name) where TOptions : class { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> WithVersion<TClient, TOptions, TVersion>(this Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> builder, TVersion version) where TOptions : class { throw null; }
    }
    public sealed partial class AzureClientFactoryBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder, Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<Microsoft.Extensions.Configuration.IConfiguration>, Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential
    {
        internal AzureClientFactoryBuilder() { }
        public Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> AddClient<TClient, TOptions>(System.Func<TOptions, Azure.Core.TokenCredential, System.IServiceProvider, TClient> factory) where TOptions : class { throw null; }
        public Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> AddClient<TClient, TOptions>(System.Func<TOptions, Azure.Core.TokenCredential, TClient> factory) where TOptions : class { throw null; }
        public Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> AddClient<TClient, TOptions>(System.Func<TOptions, System.IServiceProvider, TClient> factory) where TOptions : class { throw null; }
        public Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> AddClient<TClient, TOptions>(System.Func<TOptions, TClient> factory) where TOptions : class { throw null; }
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilder.RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, TClient> clientFactory) { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<Microsoft.Extensions.Configuration.IConfiguration>.RegisterClientFactory<TClient, TOptions>(Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential.RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, Azure.Core.TokenCredential, TClient> clientFactory, bool requiresCredential) { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(System.Action<Azure.Core.ClientOptions, System.IServiceProvider> configureOptions) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(System.Action<Azure.Core.ClientOptions> configureOptions) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder UseCredential(Azure.Core.TokenCredential tokenCredential) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder UseCredential(System.Func<System.IServiceProvider, Azure.Core.TokenCredential> tokenCredentialFactory) { throw null; }
    }
    public static partial class AzureClientServiceCollectionExtensions
    {
        public static void AddAzureClients(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, System.Action<Microsoft.Extensions.Azure.AzureClientFactoryBuilder> configureClients) { }
        public static void AddAzureClientsCore(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static void AddAzureClientsCore(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, bool enableLogForwarding) { }
    }
    public abstract partial class AzureComponentFactory
    {
        protected AzureComponentFactory() { }
        public abstract object CreateClient([System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type clientType, Microsoft.Extensions.Configuration.IConfiguration configuration, Azure.Core.TokenCredential credential, object clientOptions);
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public abstract object CreateClientOptions([System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute(System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors)] System.Type optionsType, object serviceVersion, Microsoft.Extensions.Configuration.IConfiguration configuration);
        public abstract Azure.Core.TokenCredential CreateTokenCredential(Microsoft.Extensions.Configuration.IConfiguration configuration);
    }
    public sealed partial class AzureEventSourceLogForwarder : System.IDisposable
    {
        public AzureEventSourceLogForwarder(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory) { }
        public void Dispose() { }
        public void Start() { }
    }
    public partial interface IAzureClientFactory<TClient>
    {
        TClient CreateClient(string name);
    }
}
