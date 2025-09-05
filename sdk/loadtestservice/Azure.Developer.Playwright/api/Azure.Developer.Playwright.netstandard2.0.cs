namespace Azure.Developer.Playwright
{
    public partial class ConnectOptions<T> where T : class, new()
    {
        public ConnectOptions(string WsEndpoint, T Options) { }
        public T Options { get { throw null; } set { } }
        public string WsEndpoint { get { throw null; } set { } }
    }
    public partial class PlaywrightServiceBrowserClient : System.IDisposable
    {
        public PlaywrightServiceBrowserClient() { }
        public PlaywrightServiceBrowserClient(Azure.Core.TokenCredential credential) { }
        public PlaywrightServiceBrowserClient(Azure.Core.TokenCredential credential, Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        public PlaywrightServiceBrowserClient(Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        public virtual void Dispose() { }
        public virtual System.Threading.Tasks.Task DisposeAsync() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Developer.Playwright.ConnectOptions<T>> GetConnectOptionsAsync<T>(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, new() { throw null; }
        public virtual Azure.Developer.Playwright.ConnectOptions<T> GetConnectOptions<T>(System.Runtime.InteropServices.OSPlatform? os = default(System.Runtime.InteropServices.OSPlatform?), string? runId = null, string? exposeNetwork = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : class, new() { throw null; }
        public virtual void Initialize(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task InitializeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlaywrightServiceBrowserClientOptions : Azure.Core.ClientOptions
    {
        public PlaywrightServiceBrowserClientOptions(Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions.ServiceVersion serviceVersion = Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions.ServiceVersion.V2025_09_01) { }
        public string ExposeNetwork { get { throw null; } set { } }
        public Microsoft.Extensions.Logging.ILogger? Logger { get { throw null; } set { } }
        public System.Runtime.InteropServices.OSPlatform OS { get { throw null; } set { } }
        public string RunId { get { throw null; } set { } }
        public string RunName { get { throw null; } set { } }
        public Azure.Developer.Playwright.ServiceAuthType ServiceAuth { get { throw null; } set { } }
        public string? ServiceEndpoint { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_09_01 = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAuthType : System.IEquatable<Azure.Developer.Playwright.ServiceAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAuthType(string value) { throw null; }
        public static Azure.Developer.Playwright.ServiceAuthType AccessToken { get { throw null; } }
        public static Azure.Developer.Playwright.ServiceAuthType EntraId { get { throw null; } }
        public bool Equals(Azure.Developer.Playwright.ServiceAuthType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.Playwright.ServiceAuthType left, Azure.Developer.Playwright.ServiceAuthType right) { throw null; }
        public static implicit operator Azure.Developer.Playwright.ServiceAuthType (string value) { throw null; }
        public static bool operator !=(Azure.Developer.Playwright.ServiceAuthType left, Azure.Developer.Playwright.ServiceAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceEnvironmentVariable : System.IEquatable<Azure.Developer.Playwright.ServiceEnvironmentVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceEnvironmentVariable(string value) { throw null; }
        public static Azure.Developer.Playwright.ServiceEnvironmentVariable PlaywrightServiceAccessToken { get { throw null; } }
        public static Azure.Developer.Playwright.ServiceEnvironmentVariable PlaywrightServiceUri { get { throw null; } }
        public bool Equals(Azure.Developer.Playwright.ServiceEnvironmentVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Developer.Playwright.ServiceEnvironmentVariable left, Azure.Developer.Playwright.ServiceEnvironmentVariable right) { throw null; }
        public static implicit operator Azure.Developer.Playwright.ServiceEnvironmentVariable (string value) { throw null; }
        public static bool operator !=(Azure.Developer.Playwright.ServiceEnvironmentVariable left, Azure.Developer.Playwright.ServiceEnvironmentVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
}
