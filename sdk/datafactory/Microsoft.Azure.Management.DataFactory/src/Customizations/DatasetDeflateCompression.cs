using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The Deflate compression method used on a dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Deflate")]
    public partial class DatasetDeflateCompression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetDeflateCompression class.
        /// </summary>
        public DatasetDeflateCompression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetDeflateCompression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="level">The Deflate compression level.</param>
        public DatasetDeflateCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), object level = default(object))
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
        /// Gets or sets the Deflate compression level.
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public object Level { get; set; }

    }
}
