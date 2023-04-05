namespace Azure.Contoso.WidgetManager
{
    public partial class WidgetManagerClient
    {
        protected WidgetManagerClient() { }
        public WidgetManagerClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Contoso.WidgetManager.WidgetManagerClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class WidgetManagerClientOptions : Azure.Core.ClientOptions
    {
        public WidgetManagerClientOptions(Azure.Contoso.WidgetManager.Generated.WidgetManagerClientOptions.ServiceVersion version = Azure.Contoso.WidgetManager.Generated.WidgetManagerClientOptions.ServiceVersion.V1_0_0) { }
        public enum ServiceVersion
        {
            V1_0_0 = 1,
        }
    }
}