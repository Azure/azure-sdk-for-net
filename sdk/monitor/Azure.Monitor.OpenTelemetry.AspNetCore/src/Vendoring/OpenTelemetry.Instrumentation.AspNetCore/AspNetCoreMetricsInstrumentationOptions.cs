// <copyright file="AspNetCoreMetricsInstrumentationOptions.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using static OpenTelemetry.Internal.HttpSemanticConventionHelper;

namespace OpenTelemetry.Instrumentation.AspNetCore
{
    /// <summary>
    /// Options for metrics requests instrumentation.
    /// </summary>
    internal class AspNetCoreMetricsInstrumentationOptions
    {
        internal readonly HttpSemanticConvention HttpSemanticConvention;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetCoreMetricsInstrumentationOptions"/> class.
        /// </summary>
        public AspNetCoreMetricsInstrumentationOptions()
            : this(new ConfigurationBuilder().AddEnvironmentVariables().Build())
        {
        }

        internal AspNetCoreMetricsInstrumentationOptions(IConfiguration configuration)
        {
            Debug.Assert(configuration != null, "configuration was null");

            this.HttpSemanticConvention = GetSemanticConventionOptIn(configuration);
        }

        /// <summary>
        /// Delegate for enrichment of recorded metric with additional tags.
        /// </summary>
        /// <param name="name">The name of the metric being enriched.</param>
        /// <param name="context"><see cref="HttpContext"/>: the HttpContext object. Both Request and Response are available.</param>
        /// <param name="tags"><see cref="TagList"/>: List of current tags. You can add additional tags to this list. </param>
        public delegate void AspNetCoreMetricEnrichmentFunc(string name, HttpContext context, ref TagList tags);

        /// <summary>
        /// Gets or sets a filter function that determines whether or not to
        /// collect telemetry on a per request basis.
        /// </summary>
        /// <remarks>
        /// Notes:
        /// <list type="bullet">
        /// <item>The first parameter is the name of the metric being
        /// filtered.</item>
        /// <item>The return value for the filter function is interpreted as:
        /// <list type="bullet">
        /// <item>If filter returns <see langword="true" />, the request is
        /// collected.</item>
        /// <item>If filter returns <see langword="false" /> or throws an
        /// exception the request is NOT collected.</item>
        /// </list></item>
        /// </list>
        /// </remarks>
        public Func<string, HttpContext, bool> Filter { get; set; }

        /// <summary>
        /// Gets or sets an function to enrich a recorded metric with additional custom tags.
        /// </summary>
        public AspNetCoreMetricEnrichmentFunc Enrich { get; set; }
    }
}
