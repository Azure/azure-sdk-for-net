namespace Azure.Maps.Geolocation
{
    public partial class GetLocationResult
    {
        internal GetLocationResult() { }
        public System.Net.IPAddress IpAddress { get { throw null; } }
        public string IsoCode { get { throw null; } }
    }
    public partial class MapsGeolocationClient
    {
        protected MapsGeolocationClient() { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential) { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Geolocation.GetLocationResult> GetLocation(System.Net.IPAddress ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Geolocation.GetLocationResult>> GetLocationAsync(System.Net.IPAddress ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsGeolocationClientOptions : Azure.Core.ClientOptions
    {
        public MapsGeolocationClientOptions(Azure.Maps.Geolocation.MapsGeolocationClientOptions.ServiceVersion version = Azure.Maps.Geolocation.MapsGeolocationClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
