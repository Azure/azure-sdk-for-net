// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class FeatureMetricEmissionHelper
    {
        private static Dictionary<string, FeatureMetricEmissionHelper> s_helperRegistry = [];

        private readonly string _resourceProvider;
        private readonly string _attachMode;
        private readonly string _ciKey;
        private readonly string _os;

        private readonly Meter _featureMeter = new(StatsbeatConstants.AttachStatsbeatMeterName, "1.0");

        private StatsbeatFeatures _observedFeatures = StatsbeatFeatures.None;

        private FeatureMetricEmissionHelper(string resourceProvider, string attachMode, string ciKey, string os)
        {
            this._resourceProvider = resourceProvider;
            this._attachMode = attachMode;
            this._ciKey = ciKey;
            this._os = os;

            this._featureMeter.CreateObservableGauge(StatsbeatConstants.FeatureStatsbeatMetricName, () => GetFeatureStatsbeat());
        }

        internal static FeatureMetricEmissionHelper GetOrCreateHelper(string resourceProvider, string attachMode, string ciKey, string os)
        {
            string key = $"{resourceProvider};{attachMode};{ciKey};{os}";

            if (s_helperRegistry.TryGetValue(key, out FeatureMetricEmissionHelper? helper))
            {
                return helper;
            }

            helper = new FeatureMetricEmissionHelper(resourceProvider, attachMode, ciKey, os);
            s_helperRegistry.Add(key, helper);
            return helper;
        }

        internal void MarkFeatureInUse(StatsbeatFeatures features)
        {
            this._observedFeatures |= features;
        }

        internal Measurement<int> GetFeatureStatsbeat()
        {
            if (this._observedFeatures == 0)
            {
                // If no features have been observed, then skip sending the feature measurement
                return new Measurement<int>();
            }

            try
            {
                return
                    new Measurement<int>(1,
                        new("rp", this._resourceProvider),
                        new("attach", this._attachMode),
                        new("cikey", this._ciKey),
                        new("feature", this._observedFeatures),
                        new("type", 0), // 0 = feature, 1 = instrumentation scopes
                        new("os", this._os),
                        new("language", "dotnet"),
                        // We don't memoize this version because it can be updated up to a minute into the application startup
                        new("version", SdkVersionUtils.GetVersion())
                    );
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                return new Measurement<int>();
            }
        }
    }
}
