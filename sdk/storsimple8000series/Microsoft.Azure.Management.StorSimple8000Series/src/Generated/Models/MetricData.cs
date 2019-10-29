
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The metric data.
    /// </summary>
    public partial class MetricData
    {
        /// <summary>
        /// Initializes a new instance of the MetricData class.
        /// </summary>
        public MetricData() { }

        /// <summary>
        /// Initializes a new instance of the MetricData class.
        /// </summary>
        /// <param name="timeStamp">The time stamp of the metric data.</param>
        /// <param name="sum">The sum of all samples at the time stamp.</param>
        /// <param name="count">The count of all samples at the time
        /// stamp.</param>
        /// <param name="average">The average of all samples at the time
        /// stamp.</param>
        /// <param name="minimum">The minimum of all samples at the time
        /// stamp.</param>
        /// <param name="maximum">The maximum of all samples at the time
        /// stamp.</param>
        public MetricData(System.DateTime? timeStamp = default(System.DateTime?), double? sum = default(double?), int? count = default(int?), double? average = default(double?), double? minimum = default(double?), double? maximum = default(double?))
        {
            TimeStamp = timeStamp;
            Sum = sum;
            Count = count;
            Average = average;
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Gets or sets the time stamp of the metric data.
        /// </summary>
        [JsonProperty(PropertyName = "timeStamp")]
        public System.DateTime? TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the sum of all samples at the time stamp.
        /// </summary>
        [JsonProperty(PropertyName = "sum")]
        public double? Sum { get; set; }

        /// <summary>
        /// Gets or sets the count of all samples at the time stamp.
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the average of all samples at the time stamp.
        /// </summary>
        [JsonProperty(PropertyName = "average")]
        public double? Average { get; set; }

        /// <summary>
        /// Gets or sets the minimum of all samples at the time stamp.
        /// </summary>
        [JsonProperty(PropertyName = "minimum")]
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum of all samples at the time stamp.
        /// </summary>
        [JsonProperty(PropertyName = "maximum")]
        public double? Maximum { get; set; }

    }
}

