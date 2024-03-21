// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal sealed class ManagerFactory
    {
        public static readonly ManagerFactory Instance = new();

        internal readonly Dictionary<string, Manager> _runners = new();
        private readonly object _lockObj = new();

        public Manager Get(LiveMetricsExporterOptions options)
        {
            var key = options.ConnectionString ?? string.Empty;

            if (!_runners.TryGetValue(key, out Manager? runner))
            {
                lock (_lockObj)
                {
                    if (!_runners.TryGetValue(key, out runner))
                    {
                        runner = new Manager(options, new DefaultPlatform());

                        _runners.Add(key, runner);
                    }
                }
            }

            return runner;
        }
    }
}
