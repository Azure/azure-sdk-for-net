namespace Azure.Template
{
    public partial class AnalyzeClient
    {
        protected AnalyzeClient() { }
        public AnalyzeClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public AnalyzeClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Template.AnalyzeClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CancelJob(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetJobStatus(string jobId, int? top = default(int?), int? skip = default(int?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobStatusAsync(string jobId, int? top = default(int?), int? skip = default(int?), bool? showStats = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SubmitJob(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitJobAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AnalyzeClientOptions : Azure.Core.ClientOptions
    {
        public AnalyzeClientOptions(Azure.Template.AnalyzeClientOptions.ServiceVersion version = Azure.Template.AnalyzeClientOptions.ServiceVersion.V2022_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2022_05_15_Preview = 1,
        }
    }
}
