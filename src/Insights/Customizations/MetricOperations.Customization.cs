using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    internal partial class MetricOperations
    {
        public async Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            // Get Definitions for requested Metrics and pass through to get by definition
            return
                await this.GetMetricsAsync(
                    resourceUri,
                    RemoveNamesFromFilterString(filterString),
                    (await this.Client.MetricDefinitionOperations.GetMetricDefinitionsAsync(
                        resourceUri,
                        ShoeboxHelper.GenerateMetricDefinitionFilterString(MetricFilterExpressionParser.Parse(filterString).Names),
                        cancellationToken)).MetricDefinitionCollection.Value);
        }

        // Alternate method for getting metrics by passing in the definitions
        public async Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            // If no definitions provided, return empty collection
            if (definitions == null || !definitions.Any())
            {
                return new MetricListResponse();
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

            Dictionary<MetricAvailability, MetricFilter> groups =
                definitions.GroupBy(d => d.MetricAvailabilities.First(a => a.TimeGrain == filter.TimeGrain),
                    new AvailabilityComparer()).ToDictionary(g => g.Key, g => new MetricFilter()
                    {
                        TimeGrain = filter.TimeGrain,
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        Names = g.Select(d => d.Name.Value)
                    });

            MetricCollection metrics = new MetricCollection()
            {
                Value =
                    (await
                        Task.Factory.ContinueWhenAll(
                            groups.Select(g => g.Key.Location == null
                                    ? this.GetMetricsInternalAsync(resourceUri, ShoeboxHelper.GenerateMetricFilterString(g.Value), CancellationToken.None)
                                    : ShoeboxClient.GetMetricsInternalAsync(g.Value, g.Key.Location)).ToArray(),
                            tasks =>
                                tasks.Aggregate<Task<MetricListResponse>, IEnumerable<Metric>>(new List<Metric>(),
                                    (list, r) => list.Union(r.Result.MetricCollection.Value)))).ToList()
            };

            CompleteShoeboxMetrics(metrics, definitions, resourceUri);
            
            return new MetricListResponse()
            {
                StatusCode = HttpStatusCode.OK,
                MetricCollection = metrics
            };
        }

        private void CompleteShoeboxMetrics(MetricCollection collection, IEnumerable<MetricDefinition> definitions, string resourceUri)
        {
            foreach (Metric metric in collection.Value)
                {
                    MetricDefinition definition = definitions.FirstOrDefault(md => string.Equals(md.Name.Value, metric.Name.Value, StringComparison.OrdinalIgnoreCase));

                    metric.ResourceId = resourceUri;
                    metric.Name.LocalizedValue = definition == null ? metric.Name.Value : definition.Name.Value;
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
