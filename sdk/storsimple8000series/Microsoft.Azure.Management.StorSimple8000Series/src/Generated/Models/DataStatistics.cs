
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The additional details related to the data related statistics of a job.
    /// Currently applicable only for Backup, Clone and Restore jobs.
    /// </summary>
    public partial class DataStatistics
    {
        /// <summary>
        /// Initializes a new instance of the DataStatistics class.
        /// </summary>
        public DataStatistics() { }

        /// <summary>
        /// Initializes a new instance of the DataStatistics class.
        /// </summary>
        /// <param name="totalData">The total bytes of data to be processed, as
        /// part of the job.</param>
        /// <param name="processedData">The number of bytes of data processed
        /// till now, as part of the job.</param>
        /// <param name="cloudData">The number of bytes of data written to
        /// cloud, as part of the job.</param>
        /// <param name="throughput">The average throughput of data
        /// processed(bytes/sec), as part of the job.</param>
        public DataStatistics(long? totalData = default(long?), long? processedData = default(long?), long? cloudData = default(long?), long? throughput = default(long?))
        {
            TotalData = totalData;
            ProcessedData = processedData;
            CloudData = cloudData;
            Throughput = throughput;
        }

        /// <summary>
        /// Gets or sets the total bytes of data to be processed, as part of
        /// the job.
        /// </summary>
        [JsonProperty(PropertyName = "totalData")]
        public long? TotalData { get; set; }

        /// <summary>
        /// Gets or sets the number of bytes of data processed till now, as
        /// part of the job.
        /// </summary>
        [JsonProperty(PropertyName = "processedData")]
        public long? ProcessedData { get; set; }

        /// <summary>
        /// Gets or sets the number of bytes of data written to cloud, as part
        /// of the job.
        /// </summary>
        [JsonProperty(PropertyName = "cloudData")]
        public long? CloudData { get; set; }

        /// <summary>
        /// Gets or sets the average throughput of data processed(bytes/sec),
        /// as part of the job.
        /// </summary>
        [JsonProperty(PropertyName = "throughput")]
        public long? Throughput { get; set; }

    }
}

