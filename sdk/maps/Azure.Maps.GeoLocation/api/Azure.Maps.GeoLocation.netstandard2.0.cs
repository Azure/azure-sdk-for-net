namespace Azure.Maps.GeoLocation
{
    public partial class IpAddressToLocationResult
    {
        internal IpAddressToLocationResult() { }
        public string IpAddress { get { throw null; } }
        public string IsoCode { get { throw null; } }
    }
    public partial class MapsGeoLocationClient
    {
        protected MapsGeoLocationClient() { }
        public MapsGeoLocationClient(Azure.AzureKeyCredential credential) { }
        public MapsGeoLocationClient(Azure.AzureKeyCredential credential, Azure.Maps.GeoLocation.MapsGeoLocationClientOptions options) { }
        public MapsGeoLocationClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsGeoLocationClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.GeoLocation.MapsGeoLocationClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.GeoLocation.IpAddressToLocationResult> GetLocation(string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.GeoLocation.IpAddressToLocationResult>> GetLocationAsync(string ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsGeoLocationClientOptions : Azure.Core.ClientOptions
    {
        public MapsGeoLocationClientOptions(Azure.Maps.GeoLocation.MapsGeoLocationClientOptions.ServiceVersion version = Azure.Maps.GeoLocation.MapsGeoLocationClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
