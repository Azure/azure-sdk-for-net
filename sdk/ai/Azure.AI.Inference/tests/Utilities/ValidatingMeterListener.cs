// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Azure.AI.Inference.Telemetry;
using NUnit.Framework;

using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Tests.Utilities
{
    internal class ValidatingMeterListener : IDisposable
    {
        private readonly MeterListener m_meterListener;
        private readonly ConcurrentDictionary<string, Instrument> m_instruments = new();
        private readonly ConcurrentDictionary<string, List<Dictionary<string, object>>> m_measurementTags = new();
        private readonly ConcurrentDictionary<string, List<object>> m_measurements = new();

        public ValidatingMeterListener()
        {
            m_meterListener = new()
            {
                InstrumentPublished = (i, l) =>
                {
                    if (i.Meter.Name == OpenTelemetryConstants.ClientName)
                    {
                        l.EnableMeasurementEvents(i);
                        m_instruments.TryAdd(i.Meter.Name, i);
                    }
                }
            };
            m_meterListener.SetMeasurementEventCallback<long>(OnMeasurementRecorded);
            m_meterListener.SetMeasurementEventCallback<double>(OnMeasurementRecorded);
            m_meterListener.Start();
        }

        /// <summary>
        /// The callback for measurement recording.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instrument"></param>
        /// <param name="measurement"></param>
        /// <param name="tags"></param>
        /// <param name="state"></param>
        private void OnMeasurementRecorded<T>(Instrument instrument, T measurement, ReadOnlySpan<KeyValuePair<string, object>> tags, object state)
        {
            m_instruments.TryAdd(instrument.Name, instrument);
            if (!m_measurementTags.TryGetValue(instrument.Name, out List<Dictionary<string, object>> listTags))
            {
                m_measurementTags.TryAdd(instrument.Name, new());
                m_measurements.TryAdd(instrument.Name, new());
            }
            Dictionary<string, object> dtTags = new();
            foreach (KeyValuePair<string, object> tag in tags)
            {
                dtTags[tag.Key] = tag.Value;
            }
            m_measurementTags[instrument.Name].Add(dtTags);
            m_measurements[instrument.Name].Add(measurement);
        }

        public void Dispose()
        {
            // Disable all instruments (histograms) as a measure to clean up
            // for consequent tests.
            foreach (var instrument in m_instruments.Values) {
                m_meterListener.DisableMeasurementEvents(instrument);
            }
            m_meterListener.Dispose();
        }

        /// <summary>
        /// Populate tags dictionary with values, present for all metrics.
        /// </summary>
        /// <param name="model">The model called.</param>
        /// <param name="endpoint">The endpoint called.</param>
        /// <returns></returns>
        private static Dictionary<string, object> GetDefaultTags(string requestModel, string responseModel, Uri endpoint, string errorType)
        {
             var standardTags = new Dictionary<string, object>{
                { GenAiSystemKey, GenAiSystemValue},
                { GenAiRequestModelKey, requestModel},
                { ServerAddressKey, endpoint.Host },
                { GenAiOperationNameKey, "chat"}
            };

            if (responseModel != null)
            {
                standardTags[GenAiResponseModelKey] = responseModel;
            }

            if (errorType != null)
            {
                standardTags[ErrorTypeKey] = errorType;
            }

            if (endpoint.Port != 443)
            {
                standardTags[ServerPortKey] = endpoint.Port;
            }
            return standardTags;
        }

        public void ValidateUsageIsNotReported()
        {
            ValidateMetrics(GenAiClientTokenUsageMetricName, null, false);
        }

        /// <summary>
        /// Validate Tag usage metrics.
        /// </summary>
        /// <param name="model">The model called.</param>
        /// <param name="endpoint">The endpoint called.</param>
        public void ValidateUsage(string requestModel, string responseModel, Uri endpoint)
        {
            var lstExpected = new List<Dictionary<string, object>>();
            // InputTags
            Dictionary<string, object> input_tags = GetDefaultTags(requestModel, responseModel, endpoint, null);
            input_tags.Add(GenAiUsageInputTokensKey, "input");
            lstExpected.Add(input_tags);
            // Output tags
            Dictionary<string, object> output_tags = GetDefaultTags(requestModel, responseModel, endpoint, null);
            output_tags.Add(GenAiUsageOutputTokensKey, "output");
            lstExpected.Add(output_tags);
            ValidateMetrics(GenAiClientTokenUsageMetricName, lstExpected, true);
        }

        /// <summary>
        /// Validate the metrics for duration.
        /// </summary>
        /// <param name="model">The model to be called.</param>
        /// <param name="endpoint">The endpoint called.</param>
        public void ValidateDuration(string requestModel, string responseModel, Uri endpoint, string errorType)
        {
            var lstExpected = new List<Dictionary<string, object>>()
            {
                GetDefaultTags(requestModel, responseModel, endpoint, errorType),
            };
            ValidateMetrics(GenAiClientOperationDurationMetricName, lstExpected, true);
        }

        /// <summary>
        /// Test that the measurements are as expected.
        /// </summary>
        /// <param name="metricsName">The metric to be checked.</param>
        /// <param name="lstExpected">The expected list of tag dictionaries.</param>
        private void ValidateMetrics(string metricsName, List<Dictionary<string, object>> lstExpected, bool metricsPresent)
        {
            if (metricsPresent)
            {
                Assert.That(m_measurementTags.ContainsKey(metricsName), $"{metricsName} is not reported.");
            }
            else
            {
                Assert.That(!m_measurementTags.ContainsKey(metricsName));
                return;
            }
            List<Dictionary<string, object>> lstActual = m_measurementTags[metricsName];
            Assert.AreEqual(lstExpected.Count, lstActual.Count);
            Assert.AreEqual(lstExpected.Count, m_measurements[metricsName].Count);
            for (int i = 0; i < lstExpected.Count; i++)
            {
                AssertDictEqual(lstExpected[i], lstActual[i]);
                foreach (var measurement in m_measurements[metricsName])
                {
                    if (measurement is double d)
                    {
                        Assert.Greater(d, 0);
                    }
                    else
                    {
                        Assert.Greater((long)measurement, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Check that two dictionaries are equal.
        /// </summary>
        /// <param name="actual">The actual values.</param>
        /// <param name="expected">The expected values.</param>
        private static void AssertDictEqual(Dictionary<string, object> expected, Dictionary<string, object> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);
            foreach (KeyValuePair<string, object> kv in expected)
            {
                Assert.That(actual.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, actual[kv.Key]);
            }
        }

        public void ValidateMetricsAreOff()
        {
            Assert.That(m_measurements.IsEmpty);
            Assert.That(m_measurementTags.IsEmpty);
        }
    }
}
