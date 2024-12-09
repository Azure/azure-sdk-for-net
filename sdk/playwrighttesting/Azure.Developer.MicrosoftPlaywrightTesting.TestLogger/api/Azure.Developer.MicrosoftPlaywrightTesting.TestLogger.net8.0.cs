namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger
{
    public partial class ConnectOptions<T> where T : class, new()
    {
        public ConnectOptions() { }
        public T? Options { get { throw null; } set { } }
        public string? WsEndpoint { get { throw null; } set { } }
    }
    public partial class PlaywrightService
    {
        public PlaywrightService(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions playwrightServiceOptions, Azure.Core.TokenCredential? credential = null, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface.IFrameworkLogger? frameworkLogger = null) { }
        public PlaywrightService(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, string? serviceAuth = null, bool? useCloudHostedBrowsers = default(bool?), Azure.Core.TokenCredential? credential = null, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface.IFrameworkLogger? frameworkLogger = null) { }
        public string? ExposeNetwork { get { throw null; } set { } }
        public System.Runtime.InteropServices.OSPlatform? Os { get { throw null; } set { } }
        public System.Threading.Timer? RotationTimer { get { throw null; } set { } }
        public string? RunId { get { throw null; } set { } }
        public string ServiceAuth { get { throw null; } set { } }
        public static string? ServiceEndpoint { get { throw null; } }
        public bool UseCloudHostedBrowsers { get { throw null; } set { } }
        public void Cleanup() { }
        public System.Threading.Tasks.Task<Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ConnectOptions<T>> GetConnectOptionsAsync<T>(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, new() { throw null; }
        public System.Threading.Tasks.Task InitializeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static readonly string NumberOfTestWorkers;
        public static readonly string Os;
        public static readonly string RunId;
        public static readonly string RunName;
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
        public static readonly string PlaywrightServiceUri;
        public ServiceEnvironmentVariable() { }
    }
}
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client
{
    public partial class TestReportingClientOptions : Azure.Core.ClientOptions
    {
        public TestReportingClientOptions(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client.TestReportingClientOptions.ServiceVersion version = Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client.TestReportingClientOptions.ServiceVersion.V2024_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_09_01_Preview = 1,
        }
    }
}
namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    public partial interface IFrameworkLogger
    {
        void Debug(string message);
        void Error(string message);
        void Info(string message);
        void Warning(string message);
    }
}
