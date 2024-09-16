namespace Azure.Developer.MicrosoftPlaywrightTesting
{
    public partial class ConnectOptions<T> where T : class, new()
    {
        public T? Options;
        public string? WsEndpoint;
        public ConnectOptions() { }
    }
    public partial class PlaywrightService
    {
        public PlaywrightService(Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceOptions playwrightServiceOptions, Azure.Core.TokenCredential? credential = null) { }
        public PlaywrightService(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = default(bool?), Azure.Core.TokenCredential? credential = null) { }
        public System.Threading.Timer? RotationTimer { get { throw null; } set { } }
        public string ServiceAuth { get { throw null; } set { } }
        public static string? ServiceEndpoint { get { throw null; } }
        public bool UseCloudHostedBrowsers { get { throw null; } set { } }
        public void Cleanup() { }
        public System.Threading.Tasks.Task<Azure.Developer.MicrosoftPlaywrightTesting.ConnectOptions<T>> GetConnectOptionsAsync<T>(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null) where T : class, new() { throw null; }
        public System.Threading.Tasks.Task InitializeAsync() { throw null; }
    }
    public partial class PlaywrightServiceOptions
    {
        public PlaywrightServiceOptions(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, string? useCloudHostedBrowsers = null, string? azureTokenCredentialType = null, string? managedIdentityClientId = null) { }
    }
    public partial class RunSettingKey
    {
        public static readonly string AzureTokenCredentialType;
        public static readonly string EnableGitHubSummary;
        public static readonly string EnableResultPublish;
        public static readonly string ExposeNetwork;
        public static readonly string ManagedIdentityClientId;
        public static readonly string Os;
        public static readonly string RunId;
        public static readonly string ServiceAuthType;
        public static readonly string UseCloudHostedBrowsers;
        public RunSettingKey() { }
    }
    public partial class ServiceAuthType
    {
        public static readonly string AccessToken;
        public static readonly string EntraId;
        public ServiceAuthType() { }
    }
    public partial class ServiceEnvironmentVariable
    {
        public static readonly string PlaywrightServiceAccessToken;
        public static readonly string PlaywrightServiceExposeNetwork;
        public static readonly string PlaywrightServiceOs;
        public static readonly string PlaywrightServiceRunId;
        public static readonly string PlaywrightServiceUrl;
        public ServiceEnvironmentVariable() { }
    }
    public partial class ServiceOs
    {
        public static readonly string Linux;
        public static readonly string Windows;
        public ServiceOs() { }
    }
}
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client
{
    public partial class TestReportingClientOptions : Azure.Core.ClientOptions
    {
        public TestReportingClientOptions(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client.TestReportingClientOptions.ServiceVersion version = Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client.TestReportingClientOptions.ServiceVersion.V2024_05_20_Preview) { }
        public enum ServiceVersion
        {
            V2024_05_20_Preview = 1,
        }
    }
}
