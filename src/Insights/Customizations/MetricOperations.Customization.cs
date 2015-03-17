//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Insights.Models;

namespace Microsoft.Azure.Insights
{
    internal partial class MetricOperations
    {
        public async Task<MetricListResponse> GetMetricsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            // Ensure exactly one '/' at the start
            resourceUri = '/' + resourceUri.TrimStart('/');

            // Generate filter strings
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);
            string metricFilterString = GenerateNamelessMetricFilterString(filter);
            string definitionFilterString = filter.DimensionFilters == null ? null
                : ShoeboxHelper.GenerateMetricDefinitionFilterString(filter.DimensionFilters.Select(df => df.Name));

            // Get definitions for requested metrics
            IList<MetricDefinition> definitions =
                (await this.Client.MetricDefinitionOperations.GetMetricDefinitionsAsync(
                    resourceUri,
                    definitionFilterString,
                    cancellationToken).ConfigureAwait(false)).MetricDefinitionCollection.Value;

            // Separate passthrough metrics with dimensions specified
            IEnumerable<MetricDefinition> passthruDefinitions = definitions.Where(d => !IsShoebox(d, filter.TimeGrain));
            IEnumerable<MetricDefinition> shoeboxDefinitions = definitions.Where(d => IsShoebox(d, filter.TimeGrain));

            // Get Passthru definitions
            List<Metric> passthruMetrics = new List<Metric>();
            string invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);
            this.LogStartGetMetrics(invocationId, resourceUri, filterString, passthruDefinitions);
            if (passthruDefinitions.Any())
            {
                // Create new filter for passthru metrics
                List<MetricDimension> passthruDimensionFilters = filter.DimensionFilters == null ? new List<MetricDimension>() :
                    filter.DimensionFilters.Where(df => passthruDefinitions.Any(d => string.Equals(d.Name.Value, df.Name, StringComparison.OrdinalIgnoreCase))).ToList();

                foreach (MetricDefinition def in passthruDefinitions
                    .Where(d => !passthruDimensionFilters.Any(pdf => string.Equals(pdf.Name, d.Name.Value, StringComparison.OrdinalIgnoreCase))))
                {
                    passthruDimensionFilters.Add(new MetricDimension() { Name = def.Name.Value });
                }

                MetricFilter passthruFilter = new MetricFilter()
                {
                    TimeGrain = filter.TimeGrain,
                    StartTime = filter.StartTime,
                    EndTime = filter.EndTime,
                    DimensionFilters = passthruDimensionFilters
                };

                // Create passthru filter string
                string passthruFilterString = ShoeboxHelper.GenerateMetricFilterString(passthruFilter);

                // Get Metrics from passthrough (hydra) client
                MetricListResponse passthruResponse = await this.GetMetricsInternalAsync(resourceUri, passthruFilterString, cancellationToken).ConfigureAwait(false);
                passthruMetrics = passthruResponse.MetricCollection.Value.ToList();

                this.LogMetricCountFromResponses(invocationId, passthruMetrics.Count());

                // Fill in values (resourceUri, displayName, unit) from definitions
                CompleteShoeboxMetrics(passthruMetrics, passthruDefinitions, resourceUri);

                // Add empty objects for metrics that had no values come back, ensuring a metric is returned for each definition
                IEnumerable<Metric> emptyMetrics = passthruDefinitions
                    .Where(d => !passthruMetrics.Any(m => string.Equals(m.Name.Value, d.Name.Value, StringComparison.OrdinalIgnoreCase)))
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

                passthruMetrics.AddRange(emptyMetrics);
            }

            // Get Metrics by definitions
            MetricListResponse shoeboxResponse = await this.GetMetricsAsync(resourceUri, metricFilterString, shoeboxDefinitions, cancellationToken).ConfigureAwait(false);

            // Create response (merge and wrap metrics)
            MetricListResponse result = new MetricListResponse()
            {
                RequestId = Guid.NewGuid().ToString("D"),
                StatusCode = HttpStatusCode.OK,
                MetricCollection = new MetricCollection()
                {
                    Value = passthruMetrics.Union(shoeboxResponse.MetricCollection.Value).ToList()
                }
            };

            this.LogEndGetMetrics(invocationId, result);

            return result;
        }

        // Alternate method for getting metrics by passing in the definitions
        // TODO [davmc]: Revisit - this method cannot support dimensions
        public async Task<MetricListResponse> GetMetricsAsync(
            string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions, CancellationToken cancellationToken)
        {
            MetricListResponse result;

            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            string invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);
            this.LogStartGetMetrics(invocationId, resourceUri, filterString, definitions);

            // If no definitions provided, return empty collection
            if (!definitions.Any())
            {
                result = new MetricListResponse()
                {
                    RequestId = Guid.NewGuid().ToString("D"),
                    StatusCode =  HttpStatusCode.OK,
                    MetricCollection = new MetricCollection()
                    {
                        Value = new Metric[0]
                    }
                };

                this.LogEndGetMetrics(invocationId, result);

                return result;
            }

            // Parse MetricFilter
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            // Names not allowed in filter since the names are in the definitions
            if (filter.DimensionFilters != null && filter.DimensionFilters.Any())
            {
                throw new ArgumentException("Cannot specify names (or dimensions) when MetricDefinitions are included", "filterString");
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
                        DimensionFilters = g.Select(d => new MetricDimension() { Name = d.Name.Value })
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
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Information("InvocationId: {0}. Total number of metrics in all resposes: {1}", invocationId, metricsCount);
            }
        }

        private void LogEndGetMetrics(string invocationId, MetricListResponse result)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Exit(invocationId, result);
            }
        }

        private void LogStartGetMetrics(string invocationId, string resourceUri, string filterString, IEnumerable<MetricDefinition> definitions)
        {
            if (TracingAdapter.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);
                tracingParameters.Add("definitions", string.Concat(definitions.Select(d => d.Name)));

                TracingAdapter.Enter(invocationId, this, "GetMetricsAsync", tracingParameters);
            }
        }

        private static void CompleteShoeboxMetrics(IEnumerable<Metric> collection, IEnumerable<MetricDefinition> definitions, string resourceUri)
        {
            foreach (Metric metric in collection)
            {
                MetricDefinition definition = definitions.FirstOrDefault(md => string.Equals(md.Name.Value, metric.Name.Value, StringComparison.OrdinalIgnoreCase));

                metric.ResourceId = resourceUri;
                metric.Name.LocalizedValue = (definition != null && !string.IsNullOrEmpty(definition.Name.LocalizedValue)) 
                    ? definition.Name.LocalizedValue 
                    : metric.Name.Value;
                metric.Unit = definition == null ? Unit.Count : definition.Unit;
            }
        }

        private static bool IsShoebox(MetricDefinition definition, TimeSpan timeGrain)
        {
            MetricAvailability availability = definition.MetricAvailabilities.FirstOrDefault(a => a.TimeGrain.Equals(timeGrain));

            if (availability == null)
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.InvariantCulture, "MetricDefinition for {0} does not contain an availability with timegrain {1}", definition.Name.Value, timeGrain));
            }

            return availability.Location != null;
        }

        private static string GenerateNamelessMetricFilterString(MetricFilter filter)
        {
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
