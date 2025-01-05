namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger
{
    public partial class ConnectOptions<T> where T : class, new()
    {
        public ConnectOptions(string WsEndpoint, T Options) { }
        public T Options { get { throw null; } set { } }
        public string WsEndpoint { get { throw null; } set { } }
    }
    public partial class PlaywrightService
    {
        public PlaywrightService(Azure.Core.TokenCredential? credential, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions options) { }
        public string? ExposeNetwork { get { throw null; } set { } }
        public System.Runtime.InteropServices.OSPlatform? OS { get { throw null; } set { } }
        public string? RunId { get { throw null; } set { } }
        public Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType ServiceAuth { get { throw null; } set { } }
        public bool UseCloudHostedBrowsers { get { throw null; } set { } }
        public void Cleanup() { }
        public System.Threading.Tasks.Task<Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ConnectOptions<T>> GetConnectOptionsAsync<T>(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, new() { throw null; }
        public void Initialize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public System.Threading.Tasks.Task InitializeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlaywrightServiceOptions
    {
        public PlaywrightServiceOptions() { }
        public string? ExposeNetwork { get { throw null; } set { } }
        public Microsoft.Extensions.Logging.ILogger? Logger { get { throw null; } set { } }
        public string? ManagedIdentityClientId { get { throw null; } set { } }
        public System.Runtime.InteropServices.OSPlatform? OS { get { throw null; } set { } }
        public string? RunId { get { throw null; } set { } }
        public Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType ServiceAuth { get { throw null; } set { } }
        public string? ServiceEndpoint { get { throw null; } set { } }
        public string? TokenCredentialType { get { throw null; } set { } }
        public bool UseCloudHostedBrowsers { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunSettingKey : System.IEquatable<Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunSettingKey(string value) { throw null; }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey AzureTokenCredentialType { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey EnableGitHubSummary { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey EnableResultPublish { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey ExposeNetwork { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey ManagedIdentityClientId { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey NumberOfTestWorkers { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey OS { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey RunId { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey RunName { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey ServiceAuthType { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey UseCloudHostedBrowsers { get { throw null; } }
        public bool Equals(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey right) { throw null; }
        public static implicit operator Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey (string value) { throw null; }
        public static bool operator !=(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.RunSettingKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAuthType : System.IEquatable<Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAuthType(string value) { throw null; }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType AccessToken { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType EntraId { get { throw null; } }
        public bool Equals(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType right) { throw null; }
        public static implicit operator Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceEnvironmentVariable : System.IEquatable<Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceEnvironmentVariable(string value) { throw null; }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable PlaywrightServiceAccessToken { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable PlaywrightServiceExposeNetwork { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable PlaywrightServiceOs { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable PlaywrightServiceRunId { get { throw null; } }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable PlaywrightServiceUri { get { throw null; } }
        public bool Equals(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable right) { throw null; }
        public static implicit operator Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable (string value) { throw null; }
        public static bool operator !=(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable left, Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.ServiceEnvironmentVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
}
