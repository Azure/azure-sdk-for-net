namespace Azure.Maps.Geolocation
{
    public partial class IpAddressToLocationResult
    {
        internal IpAddressToLocationResult() { }
        public string IpAddress { get { throw null; } }
        public string IsoCode { get { throw null; } }
    }
    public partial class MapsGeolocationClient
    {
        protected MapsGeolocationClient() { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential) { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Geolocation.IpAddressToLocationResult> GetLocation(string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Geolocation.IpAddressToLocationResult>> GetLocationAsync(string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsGeolocationClientOptions : Azure.Core.ClientOptions
    {
        public MapsGeolocationClientOptions(Azure.Maps.Geolocation.MapsGeolocationClientOptions.ServiceVersion version = Azure.Maps.Geolocation.MapsGeolocationClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
}
