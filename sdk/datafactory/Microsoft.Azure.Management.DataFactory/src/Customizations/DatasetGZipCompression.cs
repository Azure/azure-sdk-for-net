using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    [Newtonsoft.Json.JsonObject("GZip")]
    public partial class DatasetGZipCompression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetGZipCompression class.
        /// </summary>
        public DatasetGZipCompression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetGZipCompression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="level">The GZip compression level.</param>
        public DatasetGZipCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), object level = default(object))
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
        /// Gets or sets the GZip compression level.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public object Level { get; set; }
    }
}
