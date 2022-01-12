using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.OperationalInsights.Models
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
        public IEnumerable<IDictionary<string, string>> Results
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

        /// <summary>
        /// If requested, contains visualization information for the results. See https://dev.loganalytics.io/documentation/Using-the-API/RequestOptions for more info.
        /// </summary>
        public IDictionary<string, string> Render { get; set; }

        /// <summary>
        /// If requested, contains query statistics. See https://dev.loganalytics.io/documentation/Using-the-API/RequestOptions for more info.
        /// </summary>
        public IDictionary<string, object> Statistics{ get; set; }

        /// <summary>
        /// Contains information of errors, may contain partial query errors.
        /// </summary>
        public QueryResponseError Error { get; set; }
    }
}
