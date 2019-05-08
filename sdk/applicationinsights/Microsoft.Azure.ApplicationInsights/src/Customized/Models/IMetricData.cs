namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public interface IMetricData
    {
        float? Sum { get; }
        float? Average { get; }
        float? Min { get; }
        float? Max { get; }
        int? Count { get; }
    }
}
