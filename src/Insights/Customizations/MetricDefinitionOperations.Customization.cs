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
            // Ensure exactly one '/' at the start
            resourceUri = '/' + resourceUri.TrimStart('/');
            IEnumerable<MetricDefinition> definitions;

            // If no filter string, must request all metric definiitons since we don't know if we have them all
            if (string.IsNullOrWhiteSpace(filterString))
            {
                // request all definitions
                definitions = (await this.GetMetricDefinitionsInternalAsync(resourceUri, string.Empty, CancellationToken.None)).MetricDefinitionCollection.Value;

                // cache definitions
                this.Client.Cache[resourceUri] = definitions;

                // wrap and return definitions
                return new MetricDefinitionListResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    MetricDefinitionCollection = new MetricDefinitionCollection()
                    {
                        Value = definitions.ToList()
                    }
                };
            }

            // Parse the filter and retrieve cached definitions
            IEnumerable<string> names = MetricDefinitionFilterParser.Parse(filterString);
            definitions = this.Client.Cache[resourceUri];

            // Find the names in the filter that don't appear on any of the cached definitions
            IEnumerable<string> missing = definitions == null
                ? names
                : names.Where((n => !definitions.Any(d => string.Equals(d.Name.Value, n, StringComparison.OrdinalIgnoreCase))));

            // Request any missing definitions and update cache (if any)
            if (missing.Any())
            {
                definitions =
                    (definitions ?? new MetricDefinition[0]).Union(
                        (await
                            this.GetMetricDefinitionsInternalAsync(resourceUri,
                                ShoeboxHelper.GenerateMetricDefinitionFilterString(missing), cancellationToken))
                            .MetricDefinitionCollection.Value);

                // Store the new set of definitions
                this.Client.Cache[resourceUri] = definitions;
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
