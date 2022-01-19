using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The BZip2 compression method used on a dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("BZip2")]
    public partial class DatasetBZip2Compression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetBZip2Compression class.
        /// </summary>
        public DatasetBZip2Compression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetBZip2Compression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        public DatasetBZip2Compression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>))
            : base(additionalProperties)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}
