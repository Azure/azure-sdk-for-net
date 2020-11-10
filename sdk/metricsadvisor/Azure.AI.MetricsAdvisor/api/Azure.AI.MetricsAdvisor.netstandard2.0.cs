namespace Azure.AI.MetricsAdvisor
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertQueryTimeMode : System.IEquatable<Azure.AI.MetricsAdvisor.AlertQueryTimeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertQueryTimeMode(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.AlertQueryTimeMode AnomalyTime { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.AlertQueryTimeMode CreatedTime { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.AlertQueryTimeMode ModifiedTime { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.AlertQueryTimeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.AlertQueryTimeMode left, Azure.AI.MetricsAdvisor.AlertQueryTimeMode right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.AlertQueryTimeMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.AlertQueryTimeMode left, Azure.AI.MetricsAdvisor.AlertQueryTimeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeedbackQueryTimeMode : System.IEquatable<Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeedbackQueryTimeMode(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode FeedbackCreatedTime { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode MetricTimestamp { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode left, Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode left, Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetAlertsOptions
    {
        public GetAlertsOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.AI.MetricsAdvisor.AlertQueryTimeMode timeMode) { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.AI.MetricsAdvisor.AlertQueryTimeMode TimeMode { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetAllFeedbackOptions
    {
        public GetAllFeedbackOptions() { }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.FeedbackType? FeedbackType { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey Filter { get { throw null; } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.FeedbackQueryTimeMode? TimeMode { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetAnomaliesForAlertOptions
    {
        public GetAnomaliesForAlertOptions() { }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetAnomaliesForDetectionConfigurationFilter
    {
        public GetAnomaliesForDetectionConfigurationFilter() { }
        public GetAnomaliesForDetectionConfigurationFilter(Azure.AI.MetricsAdvisor.Models.AnomalySeverity minimumSeverity, Azure.AI.MetricsAdvisor.Models.AnomalySeverity maximumSeverity) { }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity? MaximumSeverity { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity? MinimumSeverity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.DimensionKey> SeriesGroupKeys { get { throw null; } set { } }
    }
    public partial class GetAnomaliesForDetectionConfigurationOptions
    {
        public GetAnomaliesForDetectionConfigurationOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public Azure.AI.MetricsAdvisor.GetAnomaliesForDetectionConfigurationFilter Filter { get { throw null; } set { } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetDataFeedIngestionStatusesOptions
    {
        public GetDataFeedIngestionStatusesOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetDataFeedsFilter
    {
        public GetDataFeedsFilter() { }
        public string Creator { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType? GranularityType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedSourceType? SourceType { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedStatus? Status { get { throw null; } set { } }
    }
    public partial class GetDataFeedsOptions
    {
        public GetDataFeedsOptions() { }
        public Azure.AI.MetricsAdvisor.GetDataFeedsFilter GetDataFeedsFilter { get { throw null; } set { } }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetDimensionValuesOptions
    {
        public GetDimensionValuesOptions() { }
        public string DimensionValueToFilter { get { throw null; } set { } }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetHooksOptions
    {
        public GetHooksOptions() { }
        public string HookNameFilter { get { throw null; } set { } }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetIncidentsForAlertOptions
    {
        public GetIncidentsForAlertOptions() { }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetIncidentsForDetectionConfigurationOptions
    {
        public GetIncidentsForDetectionConfigurationOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.DimensionKey> DimensionsToFilter { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetMetricEnrichmentStatusesOptions
    {
        public GetMetricEnrichmentStatusesOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetMetricSeriesDataOptions
    {
        public GetMetricSeriesDataOptions(System.Collections.Generic.IEnumerable<Azure.AI.MetricsAdvisor.Models.DimensionKey> seriesToFilter, System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.MetricsAdvisor.Models.DimensionKey> SeriesToFilter { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class GetMetricSeriesDefinitionsOptions
    {
        public GetMetricSeriesDefinitionsOptions(System.DateTimeOffset activeSince) { }
        public System.DateTimeOffset ActiveSince { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> DimensionCombinationsToFilter { get { throw null; } set { } }
        public int? SkipCount { get { throw null; } set { } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class GetValuesOfDimensionWithAnomaliesOptions
    {
        public GetValuesOfDimensionWithAnomaliesOptions(System.DateTimeOffset startTime, System.DateTimeOffset endTime) { }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey DimensionToFilter { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public int? SkipCount { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public int? TopCount { get { throw null; } set { } }
    }
    public partial class MetricsAdvisorClient
    {
        protected MetricsAdvisorClient() { }
        public MetricsAdvisorClient(System.Uri endpoint, Azure.AI.MetricsAdvisor.MetricsAdvisorKeyCredential credential) { }
        public MetricsAdvisorClient(System.Uri endpoint, Azure.AI.MetricsAdvisor.MetricsAdvisorKeyCredential credential, Azure.AI.MetricsAdvisor.MetricsAdvisorClientsOptions options) { }
        public virtual Azure.Response<string> AddFeedback(Azure.AI.MetricsAdvisor.Models.MetricFeedback feedback, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> AddFeedbackAsync(Azure.AI.MetricsAdvisor.Models.MetricFeedback feedback, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.AnomalyAlert> GetAlerts(string alertConfigurationId, Azure.AI.MetricsAdvisor.GetAlertsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.AnomalyAlert> GetAlertsAsync(string alertConfigurationId, Azure.AI.MetricsAdvisor.GetAlertsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.MetricFeedback> GetAllFeedback(string metricId, Azure.AI.MetricsAdvisor.GetAllFeedbackOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.MetricFeedback> GetAllFeedbackAsync(string metricId, Azure.AI.MetricsAdvisor.GetAllFeedbackOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.DataPointAnomaly> GetAnomalies(string detectionConfigurationId, Azure.AI.MetricsAdvisor.GetAnomaliesForDetectionConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.DataPointAnomaly> GetAnomalies(string alertConfigurationId, string alertId, Azure.AI.MetricsAdvisor.GetAnomaliesForAlertOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.DataPointAnomaly> GetAnomaliesAsync(string detectionConfigurationId, Azure.AI.MetricsAdvisor.GetAnomaliesForDetectionConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.DataPointAnomaly> GetAnomaliesAsync(string alertConfigurationId, string alertId, Azure.AI.MetricsAdvisor.GetAnomaliesForAlertOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetDimensionValues(string metricId, string dimensionName, Azure.AI.MetricsAdvisor.GetDimensionValuesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetDimensionValuesAsync(string metricId, string dimensionName, Azure.AI.MetricsAdvisor.GetDimensionValuesOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.MetricFeedback> GetFeedback(string feedbackId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.MetricFeedback>> GetFeedbackAsync(string feedbackId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.IncidentRootCause> GetIncidentRootCauses(Azure.AI.MetricsAdvisor.Models.AnomalyIncident incident, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.IncidentRootCause> GetIncidentRootCauses(string detectionConfigurationId, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.IncidentRootCause> GetIncidentRootCausesAsync(Azure.AI.MetricsAdvisor.Models.AnomalyIncident incident, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.IncidentRootCause> GetIncidentRootCausesAsync(string detectionConfigurationId, string incidentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.AnomalyIncident> GetIncidents(string detectionConfigurationId, Azure.AI.MetricsAdvisor.GetIncidentsForDetectionConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.AnomalyIncident> GetIncidents(string alertConfigurationId, string alertId, Azure.AI.MetricsAdvisor.GetIncidentsForAlertOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.AnomalyIncident> GetIncidentsAsync(string detectionConfigurationId, Azure.AI.MetricsAdvisor.GetIncidentsForDetectionConfigurationOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.AnomalyIncident> GetIncidentsAsync(string alertConfigurationId, string alertId, Azure.AI.MetricsAdvisor.GetIncidentsForAlertOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.MetricEnrichedSeriesData> GetMetricEnrichedSeriesData(System.Collections.Generic.IEnumerable<Azure.AI.MetricsAdvisor.Models.DimensionKey> seriesKeys, string detectionConfigurationId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.MetricEnrichedSeriesData> GetMetricEnrichedSeriesDataAsync(System.Collections.Generic.IEnumerable<Azure.AI.MetricsAdvisor.Models.DimensionKey> seriesKeys, string detectionConfigurationId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.EnrichmentStatus> GetMetricEnrichmentStatuses(string metricId, Azure.AI.MetricsAdvisor.GetMetricEnrichmentStatusesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.EnrichmentStatus> GetMetricEnrichmentStatusesAsync(string metricId, Azure.AI.MetricsAdvisor.GetMetricEnrichmentStatusesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.MetricSeriesData> GetMetricSeriesData(string metricId, Azure.AI.MetricsAdvisor.GetMetricSeriesDataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.MetricSeriesData> GetMetricSeriesDataAsync(string metricId, Azure.AI.MetricsAdvisor.GetMetricSeriesDataOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.MetricSeriesDefinition> GetMetricSeriesDefinitions(string metricId, Azure.AI.MetricsAdvisor.GetMetricSeriesDefinitionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.MetricSeriesDefinition> GetMetricSeriesDefinitionsAsync(string metricId, Azure.AI.MetricsAdvisor.GetMetricSeriesDefinitionsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetValuesOfDimensionWithAnomalies(string detectionConfigurationId, string dimensionName, Azure.AI.MetricsAdvisor.GetValuesOfDimensionWithAnomaliesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetValuesOfDimensionWithAnomaliesAsync(string detectionConfigurationId, string dimensionName, Azure.AI.MetricsAdvisor.GetValuesOfDimensionWithAnomaliesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetricsAdvisorClientsOptions : Azure.Core.ClientOptions
    {
        public MetricsAdvisorClientsOptions(Azure.AI.MetricsAdvisor.MetricsAdvisorClientsOptions.ServiceVersion version = Azure.AI.MetricsAdvisor.MetricsAdvisorClientsOptions.ServiceVersion.V1_0) { }
        public Azure.AI.MetricsAdvisor.MetricsAdvisorClientsOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class MetricsAdvisorKeyCredential
    {
        public MetricsAdvisorKeyCredential(string subscriptionKey, string apiKey) { }
        public void UpdateApiKey(string key) { }
        public void UpdateSubscriptionKey(string key) { }
    }
}
namespace Azure.AI.MetricsAdvisor.Administration
{
    public partial class MetricsAdvisorAdministrationClient
    {
        protected MetricsAdvisorAdministrationClient() { }
        public MetricsAdvisorAdministrationClient(System.Uri endpoint, Azure.AI.MetricsAdvisor.MetricsAdvisorKeyCredential credential) { }
        public MetricsAdvisorAdministrationClient(System.Uri endpoint, Azure.AI.MetricsAdvisor.MetricsAdvisorKeyCredential credential, Azure.AI.MetricsAdvisor.MetricsAdvisorClientsOptions options) { }
        public virtual Azure.Response<string> CreateAlertConfiguration(Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration alertConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateAlertConfigurationAsync(Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration alertConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> CreateDataFeed(Azure.AI.MetricsAdvisor.Models.DataFeed dataFeed, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateDataFeedAsync(Azure.AI.MetricsAdvisor.Models.DataFeed dataFeed, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> CreateDetectionConfiguration(Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration detectionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateDetectionConfigurationAsync(Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration detectionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> CreateHook(Azure.AI.MetricsAdvisor.Models.NotificationHook hook, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> CreateHookAsync(Azure.AI.MetricsAdvisor.Models.NotificationHook hook, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAlertConfiguration(string alertConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAlertConfigurationAsync(string alertConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDataFeed(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDataFeedAsync(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDetectionConfiguration(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDetectionConfigurationAsync(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteHook(string hookId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteHookAsync(string hookId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration> GetAlertConfiguration(string alertConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration>> GetAlertConfigurationAsync(string alertConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration> GetAlertConfigurations(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration> GetAlertConfigurationsAsync(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.DataFeed> GetDataFeed(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.DataFeed>> GetDataFeedAsync(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.DataFeedIngestionProgress> GetDataFeedIngestionProgress(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.DataFeedIngestionProgress>> GetDataFeedIngestionProgressAsync(string dataFeedId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.DataFeedIngestionStatus> GetDataFeedIngestionStatuses(string dataFeedId, Azure.AI.MetricsAdvisor.GetDataFeedIngestionStatusesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.DataFeedIngestionStatus> GetDataFeedIngestionStatusesAsync(string dataFeedId, Azure.AI.MetricsAdvisor.GetDataFeedIngestionStatusesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.DataFeed> GetDataFeeds(Azure.AI.MetricsAdvisor.GetDataFeedsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.DataFeed> GetDataFeedsAsync(Azure.AI.MetricsAdvisor.GetDataFeedsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration> GetDetectionConfiguration(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration>> GetDetectionConfigurationAsync(string detectionConfigurationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration> GetDetectionConfigurations(string metricId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration> GetDetectionConfigurationsAsync(string metricId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.MetricsAdvisor.Models.NotificationHook> GetHook(string hookId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.MetricsAdvisor.Models.NotificationHook>> GetHookAsync(string hookId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.MetricsAdvisor.Models.NotificationHook> GetHooks(Azure.AI.MetricsAdvisor.GetHooksOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.MetricsAdvisor.Models.NotificationHook> GetHooksAsync(Azure.AI.MetricsAdvisor.GetHooksOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshDataFeedIngestion(string dataFeedId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshDataFeedIngestionAsync(string dataFeedId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAlertConfiguration(string alertConfigurationId, Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration alertConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAlertConfigurationAsync(string alertConfigurationId, Azure.AI.MetricsAdvisor.Models.AnomalyAlertConfiguration alertConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDataFeed(string dataFeedId, Azure.AI.MetricsAdvisor.Models.DataFeed dataFeed, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDataFeedAsync(string dataFeedId, Azure.AI.MetricsAdvisor.Models.DataFeed dataFeed, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDetectionConfiguration(string detectionConfigurationId, Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration detectionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDetectionConfigurationAsync(string detectionConfigurationId, Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration detectionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateHook(string hookId, Azure.AI.MetricsAdvisor.Models.NotificationHook hook, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateHookAsync(string hookId, Azure.AI.MetricsAdvisor.Models.NotificationHook hook, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.MetricsAdvisor.Models
{
    public partial class AnomalyAlert
    {
        internal AnomalyAlert() { }
        public System.DateTimeOffset CreatedTime { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    public partial class AnomalyAlertConfiguration
    {
        public AnomalyAlertConfiguration(string name, System.Collections.Generic.IList<string> idsOfHooksToAlert, System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfiguration> metricAlertConfigurations) { }
        public Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator? CrossMetricsOperator { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<string> IdsOfHooksToAlert { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfiguration> MetricAlertConfigurations { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class AnomalyDetectionConfiguration
    {
        public AnomalyDetectionConfiguration(string metricId, string name, Azure.AI.MetricsAdvisor.Models.MetricWholeSeriesDetectionCondition wholeSeriesDetectionConditions) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string MetricId { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.MetricSingleSeriesDetectionCondition> SeriesDetectionConditions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.MetricSeriesGroupDetectionCondition> SeriesGroupDetectionConditions { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.MetricWholeSeriesDetectionCondition WholeSeriesDetectionConditions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalyDetectorDirection : System.IEquatable<Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalyDetectorDirection(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection Both { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection Down { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection Up { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection left, Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection left, Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnomalyIncident
    {
        internal AnomalyIncident() { }
        public string DetectionConfigurationId { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey DimensionKey { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastTime { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity Severity { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalyIncidentStatus : System.IEquatable<Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalyIncidentStatus(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus Active { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus Resolved { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus left, Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus left, Azure.AI.MetricsAdvisor.Models.AnomalyIncidentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalySeverity : System.IEquatable<Azure.AI.MetricsAdvisor.Models.AnomalySeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalySeverity(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.AnomalySeverity High { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalySeverity Low { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalySeverity Medium { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.AnomalySeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.AnomalySeverity left, Azure.AI.MetricsAdvisor.Models.AnomalySeverity right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.AnomalySeverity (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.AnomalySeverity left, Azure.AI.MetricsAdvisor.Models.AnomalySeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalyStatus : System.IEquatable<Azure.AI.MetricsAdvisor.Models.AnomalyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalyStatus(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyStatus Active { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyStatus Resolved { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.AnomalyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.AnomalyStatus left, Azure.AI.MetricsAdvisor.Models.AnomalyStatus right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.AnomalyStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.AnomalyStatus left, Azure.AI.MetricsAdvisor.Models.AnomalyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnomalyValue : System.IEquatable<Azure.AI.MetricsAdvisor.Models.AnomalyValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnomalyValue(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyValue Anomaly { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyValue AutoDetect { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.AnomalyValue NotAnomaly { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.AnomalyValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.AnomalyValue left, Azure.AI.MetricsAdvisor.Models.AnomalyValue right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.AnomalyValue (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.AnomalyValue left, Azure.AI.MetricsAdvisor.Models.AnomalyValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureApplicationInsightsDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureApplicationInsightsDataFeedSource(string applicationId, string apiKey, string azureCloud, string query) { }
        public string ApiKey { get { throw null; } }
        public string ApplicationId { get { throw null; } }
        public string AzureCloud { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AzureBlobDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureBlobDataFeedSource(string connectionString, string container, string blobTemplate) { }
        public string BlobTemplate { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public string Container { get { throw null; } }
    }
    public partial class AzureCosmosDbDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureCosmosDbDataFeedSource(string connectionString, string sqlQuery, string database, string collectionId) { }
        public string CollectionId { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public string Database { get { throw null; } }
        public string SqlQuery { get { throw null; } }
    }
    public partial class AzureDataExplorerDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureDataExplorerDataFeedSource(string connectionString, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AzureDataLakeStorageGen2DataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureDataLakeStorageGen2DataFeedSource(string accountName, string accountKey, string fileSystemName, string directoryTemplate, string fileTemplate) { }
        public string AccountKey { get { throw null; } }
        public string AccountName { get { throw null; } }
        public string DirectoryTemplate { get { throw null; } }
        public string FileSystemName { get { throw null; } }
        public string FileTemplate { get { throw null; } }
    }
    public partial class AzureTableDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public AzureTableDataFeedSource(string connectionString, string table, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Query { get { throw null; } }
        public string Table { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BoundaryDirection : System.IEquatable<Azure.AI.MetricsAdvisor.Models.BoundaryDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BoundaryDirection(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.BoundaryDirection Both { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.BoundaryDirection Down { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.BoundaryDirection Up { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.BoundaryDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.BoundaryDirection left, Azure.AI.MetricsAdvisor.Models.BoundaryDirection right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.BoundaryDirection (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.BoundaryDirection left, Azure.AI.MetricsAdvisor.Models.BoundaryDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangePointValue : System.IEquatable<Azure.AI.MetricsAdvisor.Models.ChangePointValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangePointValue(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.ChangePointValue AutoDetect { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.ChangePointValue ChangePoint { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.ChangePointValue NotChangePoint { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.ChangePointValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.ChangePointValue left, Azure.AI.MetricsAdvisor.Models.ChangePointValue right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.ChangePointValue (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.ChangePointValue left, Azure.AI.MetricsAdvisor.Models.ChangePointValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeThresholdCondition
    {
        public ChangeThresholdCondition(double changePercentage, int shiftPoint, bool isWithinRange, Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection anomalyDetectorDirection, Azure.AI.MetricsAdvisor.Models.SuppressCondition suppressCondition) { }
        public Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection AnomalyDetectorDirection { get { throw null; } }
        public double ChangePercentage { get { throw null; } }
        public bool IsWithinRange { get { throw null; } }
        public int ShiftPoint { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.SuppressCondition SuppressCondition { get { throw null; } }
    }
    public partial class DataFeed
    {
        public DataFeed(string dataFeedName, Azure.AI.MetricsAdvisor.Models.DataFeedSource dataSource, Azure.AI.MetricsAdvisor.Models.DataFeedGranularity dataFeedGranularity, Azure.AI.MetricsAdvisor.Models.DataFeedSchema dataFeedSchema, Azure.AI.MetricsAdvisor.Models.DataFeedIngestionSettings dataFeedIngestionSettings) { }
        public Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode? AccessMode { get { throw null; } set { } }
        public string ActionLinkTemplate { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Administrators { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string Creator { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedSource DataSource { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedGranularity Granularity { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedIngestionSettings IngestionSettings { get { throw null; } }
        public bool? IsAdministrator { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MetricIds { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillSettings MissingDataPointFillSettings { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedRollupSettings RollupSettings { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedSchema Schema { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedSourceType SourceType { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<string> Viewers { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedAccessMode : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedAccessMode(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode Private { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode Public { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode left, Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode left, Azure.AI.MetricsAdvisor.Models.DataFeedAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedAutoRollupMethod : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedAutoRollupMethod(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod Average { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod Count { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod Maximum { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod Minimum { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod None { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod Sum { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod left, Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod left, Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFeedDimension
    {
        public DataFeedDimension(string dimensionName) { }
        public string DimensionDisplayName { get { throw null; } set { } }
        public string DimensionName { get { throw null; } }
    }
    public partial class DataFeedGranularity
    {
        public DataFeedGranularity(Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType granularityType) { }
        public int? CustomGranularityValue { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType GranularityType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedGranularityType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedGranularityType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Custom { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Daily { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Hourly { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Monthly { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType PerMinute { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType PerSecond { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Weekly { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType Yearly { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType left, Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType left, Azure.AI.MetricsAdvisor.Models.DataFeedGranularityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFeedIngestionProgress
    {
        internal DataFeedIngestionProgress() { }
        public System.DateTimeOffset? LatestActiveTimestamp { get { throw null; } }
        public System.DateTimeOffset? LatestSuccessTimestamp { get { throw null; } }
    }
    public partial class DataFeedIngestionSettings
    {
        public DataFeedIngestionSettings(System.DateTimeOffset ingestionStartTime) { }
        public int? DataSourceRequestConcurrency { get { throw null; } set { } }
        public System.TimeSpan? IngestionRetryDelay { get { throw null; } set { } }
        public System.TimeSpan? IngestionStartOffset { get { throw null; } set { } }
        public System.DateTimeOffset IngestionStartTime { get { throw null; } }
        public System.TimeSpan? StopRetryAfter { get { throw null; } set { } }
    }
    public partial class DataFeedIngestionStatus
    {
        internal DataFeedIngestionStatus() { }
        public string Message { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.IngestionStatusType Status { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    public partial class DataFeedMetric
    {
        public DataFeedMetric(string metricName) { }
        public string MetricDescription { get { throw null; } set { } }
        public string MetricDisplayName { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string MetricName { get { throw null; } }
    }
    public partial class DataFeedMissingDataPointFillSettings
    {
        public DataFeedMissingDataPointFillSettings() { }
        public double? CustomFillValue { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType? FillType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedMissingDataPointFillType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedMissingDataPointFillType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType CustomValue { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType NoFilling { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType PreviousValue { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType SmartFilling { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType left, Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType left, Azure.AI.MetricsAdvisor.Models.DataFeedMissingDataPointFillType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFeedRollupSettings
    {
        public DataFeedRollupSettings() { }
        public string AlreadyRollupIdentificationValue { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AutoRollupGroupByColumnNames { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedAutoRollupMethod? RollupMethod { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DataFeedRollupType? RollupType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedRollupType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedRollupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedRollupType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedRollupType AlreadyRollup { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedRollupType NeedRollup { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedRollupType NoRollup { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedRollupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedRollupType left, Azure.AI.MetricsAdvisor.Models.DataFeedRollupType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedRollupType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedRollupType left, Azure.AI.MetricsAdvisor.Models.DataFeedRollupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataFeedSchema
    {
        public DataFeedSchema(System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.DataFeedMetric> metricColumns) { }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.DataFeedDimension> DimensionColumns { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.MetricsAdvisor.Models.DataFeedMetric> MetricColumns { get { throw null; } }
        public string TimestampColumn { get { throw null; } set { } }
    }
    public abstract partial class DataFeedSource
    {
        internal DataFeedSource() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedSourceType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedSourceType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureApplicationInsights { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureBlob { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureCosmosDb { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureDataExplorer { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureDataLakeStorageGen2 { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType AzureTable { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType Elasticsearch { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType HttpRequest { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType InfluxDb { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType MongoDb { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType MySql { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType PostgreSql { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedSourceType SqlServer { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedSourceType left, Azure.AI.MetricsAdvisor.Models.DataFeedSourceType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedSourceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedSourceType left, Azure.AI.MetricsAdvisor.Models.DataFeedSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFeedStatus : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DataFeedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFeedStatus(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedStatus Active { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DataFeedStatus Paused { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DataFeedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DataFeedStatus left, Azure.AI.MetricsAdvisor.Models.DataFeedStatus right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DataFeedStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DataFeedStatus left, Azure.AI.MetricsAdvisor.Models.DataFeedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataPointAnomaly
    {
        internal DataPointAnomaly() { }
        public string AnomalyDetectionConfigurationId { get { throw null; } }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public string MetricId { get { throw null; } }
        public System.DateTimeOffset? ModifiedTime { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesKey { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity Severity { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalyStatus? Status { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DetectionConditionsOperator : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DetectionConditionsOperator(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator And { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator Or { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator left, Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator left, Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DimensionKey : System.IEquatable<Azure.AI.MetricsAdvisor.Models.DimensionKey>
    {
        public DimensionKey() { }
        public void AddDimensionColumn(string dimensionColumnName, string dimensionColumnValue) { }
        public System.Collections.Generic.Dictionary<string, string> AsDictionary() { throw null; }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.DimensionKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.DimensionKey left, Azure.AI.MetricsAdvisor.Models.DimensionKey right) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.DimensionKey left, Azure.AI.MetricsAdvisor.Models.DimensionKey right) { throw null; }
        public void RemoveDimensionColumn(string dimensionColumnName) { }
    }
    public partial class ElasticsearchDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public ElasticsearchDataFeedSource(string host, string port, string authorizationHeader, string query) { }
        public string AuthorizationHeader { get { throw null; } }
        public string Host { get { throw null; } }
        public string Port { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class EmailNotificationHook : Azure.AI.MetricsAdvisor.Models.NotificationHook
    {
        public EmailNotificationHook(string name, System.Collections.Generic.IList<string> emailsToAlert) { }
        public System.Collections.Generic.IList<string> EmailsToAlert { get { throw null; } }
    }
    public partial class EnrichmentStatus
    {
        internal EnrichmentStatus() { }
        public string Message { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    public partial class FeedbackDimensionFilter
    {
        public FeedbackDimensionFilter(Azure.AI.MetricsAdvisor.Models.DimensionKey dimensionFilter) { }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey DimensionFilter { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeedbackType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.FeedbackType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeedbackType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.FeedbackType Anomaly { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.FeedbackType ChangePoint { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.FeedbackType Comment { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.FeedbackType Period { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.FeedbackType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.FeedbackType left, Azure.AI.MetricsAdvisor.Models.FeedbackType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.FeedbackType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.FeedbackType left, Azure.AI.MetricsAdvisor.Models.FeedbackType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HardThresholdCondition
    {
        public HardThresholdCondition(Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection anomalyDetectorDirection, Azure.AI.MetricsAdvisor.Models.SuppressCondition suppressCondition) { }
        public Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection AnomalyDetectorDirection { get { throw null; } }
        public double? LowerBound { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.SuppressCondition SuppressCondition { get { throw null; } }
        public double? UpperBound { get { throw null; } set { } }
    }
    public partial class HttpRequestDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public HttpRequestDataFeedSource(System.Uri url, string httpHeader, string httpMethod, string payload) { }
        public string HttpHeader { get { throw null; } }
        public string HttpMethod { get { throw null; } }
        public string Payload { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class IncidentRootCause
    {
        internal IncidentRootCause() { }
        public string Description { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey DimensionKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Paths { get { throw null; } }
        public double Score { get { throw null; } }
    }
    public partial class InfluxDbDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public InfluxDbDataFeedSource(string connectionString, string database, string username, string password, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Database { get { throw null; } }
        public string Password { get { throw null; } }
        public string Query { get { throw null; } }
        public string Username { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IngestionStatusType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.IngestionStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IngestionStatusType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Error { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Failed { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType NoData { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType NotStarted { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Paused { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Running { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Scheduled { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.IngestionStatusType Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.IngestionStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.IngestionStatusType left, Azure.AI.MetricsAdvisor.Models.IngestionStatusType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.IngestionStatusType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.IngestionStatusType left, Azure.AI.MetricsAdvisor.Models.IngestionStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricAnomalyAlertConditions
    {
        public MetricAnomalyAlertConditions() { }
        public Azure.AI.MetricsAdvisor.Models.MetricBoundaryCondition MetricBoundaryCondition { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.SeverityCondition SeverityCondition { get { throw null; } set { } }
    }
    public partial class MetricAnomalyAlertConfiguration
    {
        public MetricAnomalyAlertConfiguration(string detectionConfigurationId, Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScope alertScope) { }
        public Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConditions AlertConditions { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScope AlertScope { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertSnoozeCondition AlertSnoozeCondition { get { throw null; } set { } }
        public string DetectionConfigurationId { get { throw null; } }
        public bool? UseDetectionResultToFilterAnomalies { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricAnomalyAlertConfigurationsOperator : System.IEquatable<Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricAnomalyAlertConfigurationsOperator(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator And { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator Or { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator Xor { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator left, Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator left, Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertConfigurationsOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricAnomalyAlertScope
    {
        internal MetricAnomalyAlertScope() { }
        public Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType ScopeType { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesGroupInScope { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.TopNGroupScope TopNGroupInScope { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScope GetScopeForSeriesGroup(Azure.AI.MetricsAdvisor.Models.DimensionKey seriesGroupKey) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScope GetScopeForTopNGroup(Azure.AI.MetricsAdvisor.Models.TopNGroupScope topNGroup) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScope GetScopeForWholeSeries() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricAnomalyAlertScopeType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricAnomalyAlertScopeType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType SeriesGroup { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType TopN { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType WholeSeries { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType left, Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType left, Azure.AI.MetricsAdvisor.Models.MetricAnomalyAlertScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetricAnomalyAlertSnoozeCondition
    {
        public MetricAnomalyAlertSnoozeCondition(int autoSnooze, Azure.AI.MetricsAdvisor.Models.SnoozeScope snoozeScope, bool isOnlyForSuccessive) { }
        public int AutoSnooze { get { throw null; } }
        public bool IsOnlyForSuccessive { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.SnoozeScope SnoozeScope { get { throw null; } }
    }
    public partial class MetricAnomalyFeedback : Azure.AI.MetricsAdvisor.Models.MetricFeedback
    {
        public MetricAnomalyFeedback(string metricId, Azure.AI.MetricsAdvisor.Models.FeedbackDimensionFilter dimensionFilter, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.AI.MetricsAdvisor.Models.AnomalyValue value) { }
        public string AnomalyDetectionConfigurationId { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.AnomalyDetectionConfiguration AnomalyDetectionConfigurationSnapshot { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalyValue AnomalyValue { get { throw null; } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
    }
    public partial class MetricBoundaryCondition
    {
        public MetricBoundaryCondition(Azure.AI.MetricsAdvisor.Models.BoundaryDirection direction) { }
        public string CompanionMetricId { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.BoundaryDirection Direction { get { throw null; } }
        public double? LowerBound { get { throw null; } set { } }
        public bool? TriggerForMissing { get { throw null; } set { } }
        public double? UpperBound { get { throw null; } set { } }
    }
    public partial class MetricChangePointFeedback : Azure.AI.MetricsAdvisor.Models.MetricFeedback
    {
        public MetricChangePointFeedback(string metricId, Azure.AI.MetricsAdvisor.Models.FeedbackDimensionFilter dimensionFilter, System.DateTimeOffset startTime, System.DateTimeOffset endTime, Azure.AI.MetricsAdvisor.Models.ChangePointValue value) { }
        public Azure.AI.MetricsAdvisor.Models.ChangePointValue ChangePointValue { get { throw null; } }
        public System.DateTimeOffset EndTime { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
    }
    public partial class MetricCommentFeedback : Azure.AI.MetricsAdvisor.Models.MetricFeedback
    {
        public MetricCommentFeedback(string metricId, Azure.AI.MetricsAdvisor.Models.FeedbackDimensionFilter dimensionFilter, string comment) { }
        public string Comment { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
    }
    public partial class MetricEnrichedSeriesData
    {
        internal MetricEnrichedSeriesData() { }
        public System.Collections.Generic.IReadOnlyList<double?> ExpectedValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<bool?> IsAnomaly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double?> LowerBoundaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int?> Periods { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesKey { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double?> UpperBoundaries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> Values { get { throw null; } }
    }
    public partial class MetricFeedback
    {
        internal MetricFeedback() { }
        public System.DateTimeOffset? CreatedTime { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.FeedbackDimensionFilter DimensionFilter { get { throw null; } }
        public string Id { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.FeedbackType Type { get { throw null; } }
        public string UserPrincipal { get { throw null; } }
    }
    public partial class MetricPeriodFeedback : Azure.AI.MetricsAdvisor.Models.MetricFeedback
    {
        public MetricPeriodFeedback(string metricId, Azure.AI.MetricsAdvisor.Models.FeedbackDimensionFilter dimensionFilter, Azure.AI.MetricsAdvisor.Models.PeriodType periodType, int periodValue) { }
        public Azure.AI.MetricsAdvisor.Models.PeriodType PeriodType { get { throw null; } }
        public int PeriodValue { get { throw null; } }
    }
    public partial class MetricSeriesData
    {
        internal MetricSeriesData() { }
        public Azure.AI.MetricsAdvisor.Models.MetricSeriesDefinition Definition { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.DateTimeOffset> Timestamps { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<double> Values { get { throw null; } }
    }
    public partial class MetricSeriesDefinition
    {
        internal MetricSeriesDefinition() { }
        public string MetricId { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesKey { get { throw null; } }
    }
    public partial class MetricSeriesGroupDetectionCondition : Azure.AI.MetricsAdvisor.Models.MetricWholeSeriesDetectionCondition
    {
        public MetricSeriesGroupDetectionCondition(Azure.AI.MetricsAdvisor.Models.DimensionKey seriesGroupKey) { }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesGroupKey { get { throw null; } }
    }
    public partial class MetricSingleSeriesDetectionCondition : Azure.AI.MetricsAdvisor.Models.MetricWholeSeriesDetectionCondition
    {
        public MetricSingleSeriesDetectionCondition(Azure.AI.MetricsAdvisor.Models.DimensionKey seriesKey) { }
        public Azure.AI.MetricsAdvisor.Models.DimensionKey SeriesKey { get { throw null; } }
    }
    public partial class MetricWholeSeriesDetectionCondition
    {
        public MetricWholeSeriesDetectionCondition() { }
        public Azure.AI.MetricsAdvisor.Models.ChangeThresholdCondition ChangeThresholdCondition { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.DetectionConditionsOperator? CrossConditionsOperator { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.HardThresholdCondition HardThresholdCondition { get { throw null; } set { } }
        public Azure.AI.MetricsAdvisor.Models.SmartDetectionCondition SmartDetectionCondition { get { throw null; } set { } }
    }
    public partial class MongoDbDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public MongoDbDataFeedSource(string connectionString, string database, string command) { }
        public string Command { get { throw null; } }
        public string ConnectionString { get { throw null; } }
        public string Database { get { throw null; } }
    }
    public partial class MySqlDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public MySqlDataFeedSource(string connectionString, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class NotificationHook
    {
        internal NotificationHook() { }
        public System.Collections.Generic.IReadOnlyList<string> Administrators { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ExternalLink { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeriodType : System.IEquatable<Azure.AI.MetricsAdvisor.Models.PeriodType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeriodType(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.PeriodType AssignValue { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.PeriodType AutoDetect { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.PeriodType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.PeriodType left, Azure.AI.MetricsAdvisor.Models.PeriodType right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.PeriodType (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.PeriodType left, Azure.AI.MetricsAdvisor.Models.PeriodType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public PostgreSqlDataFeedSource(string connectionString, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class SeverityCondition
    {
        public SeverityCondition(Azure.AI.MetricsAdvisor.Models.AnomalySeverity minimumAlertSeverity, Azure.AI.MetricsAdvisor.Models.AnomalySeverity maximumAlertSeverity) { }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity MaximumAlertSeverity { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.AnomalySeverity MinimumAlertSeverity { get { throw null; } }
    }
    public partial class SmartDetectionCondition
    {
        public SmartDetectionCondition(double sensitivity, Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection anomalyDetectorDirection, Azure.AI.MetricsAdvisor.Models.SuppressCondition suppressCondition) { }
        public Azure.AI.MetricsAdvisor.Models.AnomalyDetectorDirection AnomalyDetectorDirection { get { throw null; } }
        public double Sensitivity { get { throw null; } }
        public Azure.AI.MetricsAdvisor.Models.SuppressCondition SuppressCondition { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnoozeScope : System.IEquatable<Azure.AI.MetricsAdvisor.Models.SnoozeScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnoozeScope(string value) { throw null; }
        public static Azure.AI.MetricsAdvisor.Models.SnoozeScope Metric { get { throw null; } }
        public static Azure.AI.MetricsAdvisor.Models.SnoozeScope Series { get { throw null; } }
        public bool Equals(Azure.AI.MetricsAdvisor.Models.SnoozeScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.MetricsAdvisor.Models.SnoozeScope left, Azure.AI.MetricsAdvisor.Models.SnoozeScope right) { throw null; }
        public static implicit operator Azure.AI.MetricsAdvisor.Models.SnoozeScope (string value) { throw null; }
        public static bool operator !=(Azure.AI.MetricsAdvisor.Models.SnoozeScope left, Azure.AI.MetricsAdvisor.Models.SnoozeScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerDataFeedSource : Azure.AI.MetricsAdvisor.Models.DataFeedSource
    {
        public SqlServerDataFeedSource(string connectionString, string query) { }
        public string ConnectionString { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class SuppressCondition
    {
        public SuppressCondition(int minimumNumber, double minimumRatio) { }
        public int MinimumNumber { get { throw null; } }
        public double MinimumRatio { get { throw null; } }
    }
    public partial class TopNGroupScope
    {
        public TopNGroupScope(int top, int period, int minimumTopCount) { }
        public int MinimumTopCount { get { throw null; } }
        public int Period { get { throw null; } }
        public int Top { get { throw null; } }
    }
    public partial class WebNotificationHook : Azure.AI.MetricsAdvisor.Models.NotificationHook
    {
        public WebNotificationHook(string name, string endpoint) { }
        public string CertificateKey { get { throw null; } set { } }
        public string CertificatePassword { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
}
