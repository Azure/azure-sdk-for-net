namespace Microsoft.Extensions.Azure
{
    public static partial class AzureClientBuilderExtensions
    {
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
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilder.RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, TClient> clientFactory) { throw null; }
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<Microsoft.Extensions.Configuration.IConfiguration>.RegisterClientFactory<TClient, TOptions>(Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
        Azure.Core.Extensions.IAzureClientBuilder<TClient, TOptions> Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential.RegisterClientFactory<TClient, TOptions>(System.Func<TOptions, Azure.Core.TokenCredential, TClient> clientFactory, bool requiresCredential) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(System.Action<Azure.Core.ClientOptions, System.IServiceProvider> configureOptions) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder ConfigureDefaults(System.Action<Azure.Core.ClientOptions> configureOptions) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder UseConfiguration(System.Func<System.IServiceProvider, Microsoft.Extensions.Configuration.IConfiguration> configurationProvider) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder UseCredential(Azure.Core.TokenCredential tokenCredential) { throw null; }
        public Microsoft.Extensions.Azure.AzureClientFactoryBuilder UseCredential(System.Func<System.IServiceProvider, Azure.Core.TokenCredential> tokenCredentialFactory) { throw null; }
    }
    public static partial class AzureClientServiceCollectionExtensions
    {
        public static void AddAzureClients(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, System.Action<Microsoft.Extensions.Azure.AzureClientFactoryBuilder> configureClients) { }
    }
    public abstract partial class AzureComponentFactory
    {
        protected AzureComponentFactory() { }
        public abstract object CreateClientOptions(System.Type optionsType, object serviceVersion, Microsoft.Extensions.Configuration.IConfiguration configuration);
        public abstract Azure.Core.TokenCredential CreateCredential(Microsoft.Extensions.Configuration.IConfiguration configuration);
    }
    public partial interface IAzureClientFactory<TClient>
    {
        TClient CreateClient(string name);
    }
}
