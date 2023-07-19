using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The ZipDeflate compression method used on a dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("ZipDeflate")]
    public partial class DatasetZipDeflateCompression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetZipDeflateCompression
        /// class.
        /// </summary>
        public DatasetZipDeflateCompression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetZipDeflateCompression
        /// class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="level">The ZipDeflate compression level.</param>
        public DatasetZipDeflateCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), object level = default(object))
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
        /// Gets or sets the ZipDeflate compression level.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public object Level { get; set; }

    }
}
