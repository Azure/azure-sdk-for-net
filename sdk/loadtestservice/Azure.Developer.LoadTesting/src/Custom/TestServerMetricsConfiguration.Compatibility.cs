// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Developer.LoadTesting
{
    public partial class TestServerMetricsConfiguration
    {
        /// <summary> Initializes a new instance of <see cref="TestServerMetricsConfiguration"/>. </summary>
        /// <param name="metrics"> The resource metrics configuration. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> is null. </exception>
        public TestServerMetricsConfiguration(IDictionary<string, ResourceMetric> metrics) : this()
        {
            if (metrics is null)
            {
                throw new ArgumentNullException(nameof(metrics));
            }

            Metrics = metrics;
        }
    }
}
