using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.Azure.Insights
{
    internal partial class MetricOperations
    {
        public async Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            // Ensure exactly one '/' at the start
            resourceUri = '/' + resourceUri.TrimStart('/');

            // Generate filter strings
            string metricFilter = RemoveNamesFromFilterString(filterString);
            string definitionFilter = ShoeboxHelper.GenerateMetricDefinitionFilterString(MetricFilterExpressionParser.Parse(filterString).Names);

            // Get definitions for requested metrics
            IList<MetricDefinition> definitions =
                (await this.Client.MetricDefinitionOperations.GetMetricDefinitionsAsync(
                    resourceUri,
                    definitionFilter,
                    cancellationToken).ConfigureAwait(false)).MetricDefinitionCollection.Value;

            // Get Metrics by definitions
            return await this.GetMetricsAsync(resourceUri, metricFilter, definitions, cancellationToken).ConfigureAwait(false);
        }

        // Alternate method for getting metrics by passing in the definitions
        public async Task<MetricListResponse> GetMetricsAsync(
            string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions, CancellationToken cancellationToken)
        {
            MetricListResponse result;

            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            string invocationId = Tracing.NextInvocationId.ToString(CultureInfo.InvariantCulture);
            this.LogStartGetMetrics(invocationId, resourceUri, filterString, definitions);

            // If no definitions provided, return empty collection
            if (!definitions.Any())
            {
                result = new MetricListResponse()
                {
                    RequestId = Guid.NewGuid().ToString("D"),
                    StatusCode =  HttpStatusCode.OK
                };

                this.LogEndGetMetrics(invocationId, result);

                return result;
            }

            // Parse MetricFilter
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            // Names not allowed in filter since the names are in the definitions
            if (filter.Names != null && filter.Names.Any())
            {
                throw new ArgumentException("Cannot specify names when MetricDefinitions are included", "filterString");
            }

            // Ensure every definition has at least one availability matching the filter timegrain
            if (!definitions.All(d => d.MetricAvailabilities.Any(a => a.TimeGrain == filter.TimeGrain)))
            {
                throw new ArgumentException("Definition contains no availability for the timeGrain requested", "definitions");
            }

            // Group definitions by location so we can make one request to each location
            Dictionary<MetricAvailability, MetricFilter> groups =
                definitions.GroupBy(d => d.MetricAvailabilities.First(a => a.TimeGrain == filter.TimeGrain),
                    new AvailabilityComparer()).ToDictionary(g => g.Key, g => new MetricFilter()
                    {
                        TimeGrain = filter.TimeGrain,
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        Names = g.Select(d => d.Name.Value)
                    });

            // Get Metrics from each location (group)
            IEnumerable<Task<MetricListResponse>> locationTasks = groups.Select(g => g.Key.Location == null
                    ? this.GetMetricsInternalAsync(resourceUri, ShoeboxHelper.GenerateMetricFilterString(g.Value), cancellationToken)
                    : ShoeboxClient.GetMetricsInternalAsync(g.Value, g.Key.Location, invocationId));

            // Aggregate metrics from all groups
            MetricListResponse[] results = (await Task.Factory.ContinueWhenAll(locationTasks.ToArray(), tasks => tasks.Select(t => t.Result))).ToArray();
            IEnumerable<Metric> metrics = results.Aggregate<MetricListResponse, IEnumerable<Metric>>(
                new List<Metric>(), (list, response) => list.Union(response.MetricCollection.Value));
            
            this.LogMetricCountFromResponses(invocationId, metrics.Count());

            // Fill in values (resourceUri, displayName, unit) from definitions
            CompleteShoeboxMetrics(metrics, definitions, resourceUri);

            // Add empty objects for metrics that had no values come back, ensuring a metric is returned for each definition
            IEnumerable<Metric> emptyMetrics = definitions
                .Where(d => !metrics.Any(m => string.Equals(m.Name.Value, d.Name.Value, StringComparison.OrdinalIgnoreCase)))
                .Select(d => new Metric()
                {
                    Name = d.Name,
                    Unit = d.Unit,
                    ResourceId = resourceUri,
                    StartTime = filter.StartTime,
                    EndTime = filter.EndTime,
                    TimeGrain = filter.TimeGrain,
                    MetricValues = new List<MetricValue>(),
                    Properties = new Dictionary<string, string>()
                });
            
            // Create response (merge and wrap metrics)
            result = new MetricListResponse()
            {
                RequestId = Guid.NewGuid().ToString("D"),
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = metrics.Union(emptyMetrics).ToList()
                }
            };

            this.LogEndGetMetrics(invocationId, result);

            return result;
        }

        private void LogMetricCountFromResponses(string invocationId, int metricsCount)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Tracing.Information("InvocationId: {0}. Total number of metrics in all resposes: {1}", invocationId, metricsCount);
            }
        }

        private void LogEndGetMetrics(string invocationId, MetricListResponse result)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Tracing.Exit(invocationId, result);
            }
        }

        private void LogStartGetMetrics(string invocationId, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            if (CloudContext.Configuration.Tracing.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);
                tracingParameters.Add("definitions", string.Concat(definitions.Select(d => d.Name)));

                Tracing.Enter(invocationId, this, "GetMetricsAsync", tracingParameters);
            }
        }

        private static void CompleteShoeboxMetrics(IEnumerable<Metric> collection, IEnumerable<MetricDefinition> definitions, string resourceUri)
        {
            foreach (Metric metric in collection)
            {
                MetricDefinition definition = definitions.FirstOrDefault(md => string.Equals(md.Name.Value, metric.Name.Value, StringComparison.OrdinalIgnoreCase));

                metric.ResourceId = resourceUri;
                metric.Name.LocalizedValue = (definition != null && !string.IsNullOrEmpty(definition.Name.LocalizedValue)) ? definition.Name.LocalizedValue : metric.Name.Value;
                metric.Unit = definition == null ? Unit.Count : definition.Unit;
            }
        }

        private static string RemoveNamesFromFilterString(string filterString)
        {
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);
            MetricFilter nameless = new MetricFilter()
            {
                TimeGrain = filter.TimeGrain,
                StartTime = filter.StartTime,
                EndTime = filter.EndTime
            };

            return ShoeboxHelper.GenerateMetricFilterString(nameless);
        }

        private class AvailabilityComparer : IEqualityComparer<MetricAvailability>
        {
            public bool Equals(MetricAvailability x, MetricAvailability y)
            {
                if (x.Location == null && y.Location == null)
                {
                    return true;
                }

                if (x.Location == null || y.Location == null)
                {
                    return false;
                }

                return x.Location.TableEndpoint == y.Location.TableEndpoint;
            }

            public int GetHashCode(MetricAvailability obj)
            {
                return obj.Location == null ? 0 : obj.Location.TableEndpoint.GetHashCode();
            }
        }
    }
}
