using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The Tar archive method used on a dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Tar")]
    public partial class DatasetTarCompression : DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetTarCompression class.
        /// </summary>
        public DatasetTarCompression()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetTarCompression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        public DatasetTarCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>))
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
