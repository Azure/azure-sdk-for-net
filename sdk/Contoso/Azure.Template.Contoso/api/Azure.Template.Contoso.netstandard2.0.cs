namespace Azure.Template.Contoso
{
    public partial class ContosoClient
    {
        public ContosoClient() { }
        public ContosoClient(Azure.Template.Contoso.ContosoClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteWidget(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteWidgetAsync(Azure.WaitUntil waitUntil, string widgetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetWidget(string widgetName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWidgetAsync(string widgetName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWidgets(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWidgetsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class ContosoClientOptions : Azure.Core.ClientOptions
    {
        public ContosoClientOptions(Azure.Template.Contoso.ContosoClientOptions.ServiceVersion version = Azure.Template.Contoso.ContosoClientOptions.ServiceVersion.V2022_11_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_11_01_Preview = 1,
        }
    }
}
