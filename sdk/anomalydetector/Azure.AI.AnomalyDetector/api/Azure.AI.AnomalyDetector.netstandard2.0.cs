namespace Azure.AI.AnomalyDetector
{
    public partial class AnomalyDetectorClient
    {
        protected AnomalyDetectorClient() { }
        public AnomalyDetectorClient(System.Uri endpoint, string apiVersion, Azure.AzureKeyCredential credential) { }
        public AnomalyDetectorClient(System.Uri endpoint, string apiVersion, Azure.AzureKeyCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public AnomalyDetectorClient(System.Uri endpoint, string apiVersion, Azure.Core.TokenCredential credential) { }
        public AnomalyDetectorClient(System.Uri endpoint, string apiVersion, Azure.Core.TokenCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response BatchDetectAnomaly(System.Guid modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BatchDetectAnomalyAsync(System.Guid modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateMultivariateModel(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMultivariateModelAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteMultivariateModel(System.Guid modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMultivariateModelAsync(System.Guid modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DetectChangePoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectChangePointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DetectEntireSeries(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectEntireSeriesAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DetectLastPoint(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectLastPointAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBatchDetectionResult(System.Guid resultId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBatchDetectionResultAsync(System.Guid resultId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMultivariateModel(System.Guid modelId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMultivariateModelAsync(System.Guid modelId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMultivariateModels(int? skip = default(int?), int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMultivariateModelsAsync(int? skip = default(int?), int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response LastDetectAnomaly(System.Guid modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> LastDetectAnomalyAsync(System.Guid modelId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_1) { }
        public enum ServiceVersion
        {
            V1_1 = 1,
        }
    }
}
