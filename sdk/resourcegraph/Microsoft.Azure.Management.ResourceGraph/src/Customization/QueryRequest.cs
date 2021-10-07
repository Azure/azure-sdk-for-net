namespace Microsoft.Azure.Management.ResourceGraph.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Describes a query to be executed.
    /// </summary>
    public partial class QueryRequest
    {
        /// <summary>
        /// Initializes a new instance of the QueryRequest class.
        /// This constructor is used in the older versions of ResourceGraph
        /// package and is needed for the backward compatibility.
        /// </summary>
        /// <param name="subscriptions">Azure subscriptions against which to
        /// execute the query.</param>
        /// <param name="query">The resources query.</param>
        /// <param name="options">The query evaluation options</param>
        /// <param name="facets">An array of facet requests to be computed
        /// against the query result.</param>
        public QueryRequest(IList<string> subscriptions, string query, QueryRequestOptions options = default(QueryRequestOptions), IList<FacetRequest> facets = default(IList<FacetRequest>))
            : this(query, subscriptions: subscriptions, options: options, facets: facets)
        {
        }
    }
}
