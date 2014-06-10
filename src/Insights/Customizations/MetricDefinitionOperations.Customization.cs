using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    internal partial class MetricDefinitionOperations
    {
        public async Task<MetricDefinitionListResponse> GetMetricDefinitionsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            // Parse the filter and retrieve cached definitions
            IEnumerable<string> names = MetricDefinitionFilterParser.Parse(filterString);
            IEnumerable<MetricDefinition> definitions = this.Client.Cache.Retrieve(resourceUri);

            // Find the names in the filter that don't appear on any of the cached definitions
            IEnumerable<string> missing = names.Where((n => !definitions.Any(d => string.Equals(d.Name.Value, n, StringComparison.OrdinalIgnoreCase))));

            // Request any missing definitions and update cache (if any)
            if (missing.Any())
            {
                definitions =
                    definitions.Union(
                        (await
                            this.GetMetricDefinitionsInternalAsync(resourceUri,
                                ShoeboxHelper.GenerateMetricDefinitionFilterString(missing), cancellationToken))
                            .MetricDefinitionCollection.Value);

                // Store the new set of definitions
                this.Client.Cache.Store(resourceUri, definitions);
            }

            // Filter out the metrics that were cached but not requested and wrap
            return new MetricDefinitionListResponse()
            {
                StatusCode = HttpStatusCode.OK,
                MetricDefinitionCollection = new MetricDefinitionCollection()
                {
                    Value = definitions.Where(d => names.Contains(d.Name.Value)).ToList()
                }
            };
        }
    }
}
