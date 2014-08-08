using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Insights
{
    internal partial class MetricDefinitionOperations
    {
        public async Task<MetricDefinitionListResponse> GetMetricDefinitionsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            MetricDefinitionListResponse result;

            string invocationId = Tracing.NextInvocationId.ToString(CultureInfo.InvariantCulture);
            this.LogStartGetMetricDefinitions(invocationId, resourceUri, filterString);

            // Ensure exactly one '/' at the start
            resourceUri = '/' + resourceUri.TrimStart('/');
            IEnumerable<MetricDefinition> definitions;

            // If no filter string, must request all metric definiitons since we don't know if we have them all
            if (string.IsNullOrWhiteSpace(filterString))
            {
                // request all definitions
                definitions = (await this.GetMetricDefinitionsInternalAsync(resourceUri, string.Empty, CancellationToken.None).ConfigureAwait(false))
                    .MetricDefinitionCollection.Value;

                // cache definitions
                this.Client.Cache[resourceUri] = definitions;

                // wrap and return definitions
                result = new MetricDefinitionListResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    MetricDefinitionCollection = new MetricDefinitionCollection()
                    {
                        Value = definitions.ToList()
                    }
                };

                this.LogEndGetMetricDefinitions(invocationId, result);

                return result;
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
                string missingFilter = ShoeboxHelper.GenerateMetricDefinitionFilterString(missing);

                // Request missing definitions
                var missingDefinitions = (await this.GetMetricDefinitionsInternalAsync(resourceUri, missingFilter, cancellationToken).ConfigureAwait(false))
                    .MetricDefinitionCollection.Value;

                // merge definitions
                definitions = (definitions ?? new MetricDefinition[0]).Union(missingDefinitions);

                // Store the new set of definitions
                this.Client.Cache[resourceUri] = definitions;
            }

            // Filter out the metrics that were cached but not requested and wrap
            result = new MetricDefinitionListResponse()
            {
                StatusCode = HttpStatusCode.OK,
                MetricDefinitionCollection = new MetricDefinitionCollection()
                {
                    Value = definitions.Where(d => names.Contains(d.Name.Value)).ToList()
                }
            };

            this.LogEndGetMetricDefinitions(invocationId, result);

            return result;
        }

        private void LogStartGetMetricDefinitions(string invocationId, string resourceUri, string filterString)
        {
            invocationId = null;

            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);

                
                Tracing.Enter(invocationId, this, "GetMetricDefinitionsAsync", tracingParameters);
            }
        }

        private void LogEndGetMetricDefinitions(string invocationId, MetricDefinitionListResponse result)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Tracing.Exit(invocationId, result);
            }
        }
    }
}
