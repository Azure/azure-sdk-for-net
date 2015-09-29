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
    internal partial class MetricDefinitionOperations
    {
        public async Task<MetricDefinitionListResponse> GetMetricDefinitionsAsync(string resourceUri, string filterString, CancellationToken cancellationToken)
        {
            MetricDefinitionListResponse result;

            string invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);
            this.LogStartGetMetricDefinitions(invocationId, resourceUri, filterString);

            // Remove any '/' characters from the start since these are handled by the hydra (thin) client
            // Encode segments here since they are not encoded by hydra client
            resourceUri = ShoeboxHelper.EncodeUriSegments(resourceUri.TrimStart('/'));
            IEnumerable<MetricDefinition> definitions = null;

            // If no filter string, must request all metric definitions since we don't know if we have them all
            if (string.IsNullOrWhiteSpace(filterString))
            {
                // request all definitions
                definitions = (await this.GetMetricDefinitionsInternalAsync(resourceUri, string.Empty, CancellationToken.None).ConfigureAwait(false))
                    .MetricDefinitionCollection.Value;

                // cache definitions
                if (this.Client.IsCacheEnabled)
                {
                    this.Client.Cache[resourceUri] = definitions;
                }

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
            if (this.Client.IsCacheEnabled)
            {
                definitions = this.Client.Cache[resourceUri];
            }

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
                if (this.Client.IsCacheEnabled)
                {
                    this.Client.Cache[resourceUri] = definitions;
                }
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

            if (TracingAdapter.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);


                TracingAdapter.Enter(invocationId, this, "GetMetricDefinitionsAsync", tracingParameters);
            }
        }

        private void LogEndGetMetricDefinitions(string invocationId, MetricDefinitionListResponse result)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Exit(invocationId, result);
            }
        }
    }
}
