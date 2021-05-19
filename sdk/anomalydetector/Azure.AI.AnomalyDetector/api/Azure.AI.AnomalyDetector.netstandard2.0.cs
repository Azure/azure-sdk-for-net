namespace Azure.AI.AnomalyDetector
{
    public partial class AnomalyDetectorClient
    {
        protected AnomalyDetectorClient() { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options = null) { }
        public AnomalyDetectorClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions options = null) { }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse> DetectChangePoint(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.ChangePointDetectResponse>> DetectChangePointAsync(Azure.AI.AnomalyDetector.Models.ChangePointDetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse> DetectEntireSeries(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.EntireDetectResponse>> DetectEntireSeriesAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse> DetectLastPoint(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AnomalyDetector.Models.LastDetectResponse>> DetectLastPointAsync(Azure.AI.AnomalyDetector.Models.DetectRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AnomalyDetectorClientOptions : Azure.Core.ClientOptions
    {
        public AnomalyDetectorClientOptions(Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion version = Azure.AI.AnomalyDetector.AnomalyDetectorClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
}
namespace Azure.AI.AnomalyDetector.Models
{
    public partial class ChangePointDetectRequest
    {
        public ChangePointDetectRequest(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> series, Azure.AI.AnomalyDetector.Models.TimeGranularity granularity) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.TimeGranularity Granularity { get { throw null; } }
        public int? Period { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> Series { get { throw null; } }
        public int? StableTrendWindow { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
    }
    public partial class ChangePointDetectResponse
    {
        internal ChangePointDetectResponse() { }
        public System.Collections.Generic.IReadOnlyList<float> ConfidenceScores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsChangePoint { get { throw null; } }
        public int Period { get { throw null; } }
    }
    public partial class DetectRequest
    {
        public DetectRequest(System.Collections.Generic.IEnumerable<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> series, Azure.AI.AnomalyDetector.Models.TimeGranularity granularity) { }
        public int? CustomInterval { get { throw null; } set { } }
        public Azure.AI.AnomalyDetector.Models.TimeGranularity Granularity { get { throw null; } }
        public float? MaxAnomalyRatio { get { throw null; } set { } }
        public int? Period { get { throw null; } set { } }
        public int? Sensitivity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AnomalyDetector.Models.TimeSeriesPoint> Series { get { throw null; } }
    }
    public partial class EntireDetectResponse
    {
        internal EntireDetectResponse() { }
        public System.Collections.Generic.IReadOnlyList<float> ExpectedValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsNegativeAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool> IsPositiveAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> LowerMargins { get { throw null; } }
        public int Period { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float> UpperMargins { get { throw null; } }
    }
    public partial class LastDetectResponse
    {
        internal LastDetectResponse() { }
        public float ExpectedValue { get { throw null; } }
        public bool IsAnomaly { get { throw null; } }
        public bool IsNegativeAnomaly { get { throw null; } }
        public bool IsPositiveAnomaly { get { throw null; } }
        public float LowerMargin { get { throw null; } }
        public int Period { get { throw null; } }
        public int SuggestedWindow { get { throw null; } }
        public float UpperMargin { get { throw null; } }
    }
    public enum TimeGranularity
    {
        Yearly = 0,
        Monthly = 1,
        Weekly = 2,
        Daily = 3,
        Hourly = 4,
        PerMinute = 5,
        PerSecond = 6,
    }
    public partial class TimeSeriesPoint
    {
        public TimeSeriesPoint(System.DateTimeOffset timestamp, float value) { }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public float Value { get { throw null; } }
    }
}
