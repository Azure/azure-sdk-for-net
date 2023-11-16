namespace Azure.Maps.Geolocation
{
    public partial class CountryRegionResult : System.ClientModel.Primitives.IJsonModel<Azure.Maps.Geolocation.CountryRegionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Maps.Geolocation.CountryRegionResult>
    {
        internal CountryRegionResult() { }
        public System.Net.IPAddress IpAddress { get { throw null; } }
        public string IsoCode { get { throw null; } }
        Azure.Maps.Geolocation.CountryRegionResult System.ClientModel.Primitives.IJsonModel<Azure.Maps.Geolocation.CountryRegionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Maps.Geolocation.CountryRegionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Maps.Geolocation.CountryRegionResult System.ClientModel.Primitives.IPersistableModel<Azure.Maps.Geolocation.CountryRegionResult>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Maps.Geolocation.CountryRegionResult>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Maps.Geolocation.CountryRegionResult>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsGeolocationClient
    {
        protected MapsGeolocationClient() { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential) { }
        public MapsGeolocationClient(Azure.AzureKeyCredential credential, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public MapsGeolocationClient(Azure.AzureSasCredential credential) { }
        public MapsGeolocationClient(Azure.AzureSasCredential credential, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsGeolocationClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Geolocation.MapsGeolocationClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Geolocation.CountryRegionResult> GetCountryCode(System.Net.IPAddress ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Geolocation.CountryRegionResult>> GetCountryCodeAsync(System.Net.IPAddress ipAddress, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
