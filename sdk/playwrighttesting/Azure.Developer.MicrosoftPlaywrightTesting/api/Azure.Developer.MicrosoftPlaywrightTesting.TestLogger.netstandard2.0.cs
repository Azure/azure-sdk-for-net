namespace Azure.Developer.MicrosoftPlaywrightTesting
{
    public partial class AzureTokenCredentialType
    {
        public static readonly string AzureCliCredential;
        public static readonly string AzureDeveloperCliCredential;
        public static readonly string AzurePowerShellCredential;
        public static readonly string DefaultAzureCredential;
        public static readonly string EnvironmentCredential;
        public static readonly string InteractiveBrowserCredential;
        public static readonly string ManagedIdentityCredential;
        public static readonly string SharedTokenCacheCredential;
        public static readonly string VisualStudioCodeCredential;
        public static readonly string VisualStudioCredential;
        public static readonly string WorkloadIdentityCredential;
        public AzureTokenCredentialType() { }
    }
    public partial class ConnectOptions<T> where T : class, new()
    {
        public T? Options;
        public string? WsEndpoint;
        public ConnectOptions() { }
    }
    public partial class PlaywrightService
    {
        public PlaywrightService(Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceSettings playwrightServiceSettings, Azure.Core.TokenCredential? tokenCredential = null) { }
        public PlaywrightService(string? os = null, string? runId = null, string? exposeNetwork = null, string? defaultAuth = null, bool? useCloudHostedBrowsers = default(bool?), Azure.Core.TokenCredential? tokenCredential = null) { }
        public string DefaultAuth { get { throw null; } set { } }
        public System.Threading.Timer? RotationTimer { get { throw null; } set { } }
        public static string? ServiceEndpoint { get { throw null; } }
        public bool UseCloudHostedBrowsers { get { throw null; } set { } }
        public void Cleanup() { }
        public System.Threading.Tasks.Task<Azure.Developer.MicrosoftPlaywrightTesting.ConnectOptions<T>> GetConnectOptionsAsync<T>(string? os = null, string? runId = null, string? exposeNetwork = null) where T : class, new() { throw null; }
        public System.Threading.Tasks.Task InitializeAsync() { throw null; }
    }
    public partial class PlaywrightServiceSettings
    {
        public PlaywrightServiceSettings(string? os = null, string? runId = null, string? exposeNetwork = null, string? defaultAuth = null, string? useCloudHostedBrowsers = null, string? azureTokenCredentialType = null, string? managedIdentityClientId = null) { }
    }
    public partial class RunSettingKey
    {
        public static readonly string AZURE_TOKEN_CREDENTIAL_TYPE;
        public static readonly string DEFAULT_AUTH;
        public static readonly string EXPOSE_NETWORK;
        public static readonly string MANAGED_IDENTITY_CLIENT_ID;
        public static readonly string OS;
        public static readonly string RUN_ID;
        public static readonly string USE_CLOUD_HOSTED_BROWSERS;
        public RunSettingKey() { }
    }
    public partial class ServiceAuth
    {
        public static readonly string ENTRA;
        public static readonly string TOKEN;
        public ServiceAuth() { }
    }
    public partial class ServiceEnvironmentVariable
    {
        public static readonly string PLAYWRIGHT_SERVICE_ACCESS_TOKEN_ENVIRONMENT_VARIABLE;
        public static readonly string PLAYWRIGHT_SERVICE_EXPOSE_NETWORK_ENVIRONMENT_VARIABLE;
        public static readonly string PLAYWRIGHT_SERVICE_OS_ENVIRONMENT_VARIABLE;
        public static readonly string PLAYWRIGHT_SERVICE_RUN_ID_ENVIRONMENT_VARIABLE;
        public static readonly string PLAYWRIGHT_SERVICE_URL_ENVIRONMENT_VARIABLE;
        public ServiceEnvironmentVariable() { }
    }
    public partial class ServiceOs
    {
        public static readonly string LINUX;
        public static readonly string WINDOWS;
        public ServiceOs() { }
    }
}
