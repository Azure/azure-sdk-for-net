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

using System.Collections.Generic;
using Microsoft.Azure.Insights.Models;
using System.Net.Http;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Customizations for InsightsClient class, including handler implementation and cache for MetricDefinitions
    /// </summary>
    public partial class InsightsClient
    {
        private MetricDefinitionCache _cache;

        internal MetricDefinitionCache Cache
        {
            get
            {
                return this.IsCacheEnabled
                    ? _cache ?? (_cache = new MetricDefinitionCache())
                    : null;
            }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether to enable the metric definition cache
        /// </summary>
        public bool IsCacheEnabled { get; set; }

        /// <summary>
        /// Get an instance of the InsightsClient class that uses the handler while initiating web requests.
        /// </summary>
        /// <param name="handler">the handler</param>
        public override InsightsClient WithHandler(DelegatingHandler handler)
        {
            return WithHandler(new InsightsClient(), handler);
        }

        internal class MetricDefinitionCache : SizeBoundedCache<string, IEnumerable<MetricDefinition>>
        {
        }
    }
}
