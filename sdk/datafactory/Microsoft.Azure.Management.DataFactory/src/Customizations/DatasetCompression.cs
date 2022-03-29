using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    /// <summary>
    /// The compression method used on a dataset.
    /// </summary>
    public partial class DatasetCompression
    {
        /// <summary>
        /// Initializes a new instance of the DatasetCompression class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        public DatasetCompression(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>))
        {
            AdditionalProperties = additionalProperties;
            CustomInit();
        }
    }
}
