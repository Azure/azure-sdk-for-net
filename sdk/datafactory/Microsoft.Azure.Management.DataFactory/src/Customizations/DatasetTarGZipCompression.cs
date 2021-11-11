using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The TarGZip compression method used on a dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("TarGZip")]
    public partial class DatasetTarGZipCompression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetTarGZipCompression class.
        /// </summary>
        public DatasetTarGZipCompression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetTarGZipCompression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="level">The TarGZip compression level.</param>
        public DatasetTarGZipCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), object level = default(object))
            : base(additionalProperties)
        {
            Level = level;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the TarGZip compression level.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public object Level { get; set; }

    }
}
