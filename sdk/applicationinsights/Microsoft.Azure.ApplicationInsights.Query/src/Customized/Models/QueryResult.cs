using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    /// <summary>
    /// The query response. This currently only supports the thinned query
    /// response format.
    /// </summary>
    public partial class QueryResults
    {
        /// <summary>
        /// Enumerates over all rows in all tables.
        /// </summary>
        [JsonProperty(PropertyName = "results")]
        public IEnumerable<IDictionary<string, object>> Results
        {
            get
            {
                foreach (var table in Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        yield return table.Columns.Zip(row, (column, cell) => new { column.Name, cell })
                            .ToDictionary(entry => entry.Name, entry => entry.cell);
                    }
                }
            }
        }

        public IDictionary<string, string> Render { get; set; }
        public IDictionary<string, object> Statistics { get; set; }
    }
}
