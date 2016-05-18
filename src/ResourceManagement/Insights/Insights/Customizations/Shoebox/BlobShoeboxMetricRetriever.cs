﻿//
// Copyright (c) Microsoft.  All rights reserved.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Microsoft.Azure.Insights.Customizations.Shoebox
{
    /// <summary>
    /// Metric retriever for getting metrics in "shoebox" storage accounts using provided SAS keys for blobs
    /// </summary>
    internal class BlobShoeboxMetricRetriever : IMetricRetriever
    {
        private static readonly char[] questionMark = { '?' };

        public async Task<MetricListResponse> GetMetricsAsync(string resourceId, string filterString, IEnumerable<MetricDefinition> definitions, string invocationId)
        {
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString);

            var ongoingTasksPerBlob = new Dictionary<string, Task<Dictionary<string, List<MetricValueBlob>>>>();
            var metricsPerBlob = new Dictionary<string, Dictionary<string, List<MetricValueBlob>>>(StringComparer.OrdinalIgnoreCase);
            
            // We download all the relevant blobs first and then use the data later, to avoid download the same blob more than once.
            foreach (MetricDefinition metricDefinition in definitions)
            {
                if (!IsMetricDefinitionIncluded(filter, metricDefinition))
                {
                    continue;
                }

                foreach (MetricAvailability availability in metricDefinition.MetricAvailabilities)
                {
                    if (filter != null && filter.TimeGrain != default(TimeSpan) && filter.TimeGrain != availability.TimeGrain)
                    {
                        continue;
                    }

                    if (availability.BlobLocation == null)
                    {
                        continue;
                    }

                    foreach (BlobInfo blobInfo in availability.BlobLocation.BlobInfo)
                    {
                        string blobId = GetBlobEndpoint(blobInfo);
                        if (!metricsPerBlob.ContainsKey(blobId) && !ongoingTasksPerBlob.ContainsKey(blobId))
                        {
                            ongoingTasksPerBlob.Add(blobId, FetchMetricValuesFromBlob(blobInfo, filter));
                        }

                        if (ongoingTasksPerBlob.Count == Util.NumberOfParallelCallsForMetricBlobs)
                        {
                            foreach (var blobMetricPair in ongoingTasksPerBlob)
                            {
                                metricsPerBlob[blobMetricPair.Key] = await blobMetricPair.Value;
                            }

                            ongoingTasksPerBlob.Clear();
                        }
                    }
                }
            }

            foreach (var blobMetricPair in ongoingTasksPerBlob)
            {
                metricsPerBlob[blobMetricPair.Key] = await blobMetricPair.Value;
            }

            var result = new MetricListResponse
            {
                MetricCollection = new MetricCollection
                {
                    Value = new List<Metric>()
                }
            };

            // Populate the metrics result using the data from the blobs.
            foreach (MetricDefinition metricDefinition in definitions)
            {
                if (!IsMetricDefinitionIncluded(filter, metricDefinition))
                {
                    continue;
                }

                foreach (MetricAvailability availability in metricDefinition.MetricAvailabilities)
                {
                    if (filter != null && filter.TimeGrain != default(TimeSpan) && filter.TimeGrain != availability.TimeGrain)
                    {
                        continue;
                    }

                    if (availability.BlobLocation == null)
                    {
                        continue;
                    }

                    var metricValues = new List<MetricValueBlob>();
                    foreach (BlobInfo blobInfo in availability.BlobLocation.BlobInfo)
                    {
                        string blobId = GetBlobEndpoint(blobInfo);

                        List<MetricValueBlob> metricsInBlob;
                        if (metricsPerBlob[blobId].TryGetValue(metricDefinition.Name.Value, out metricsInBlob))
                        {
                            metricsInBlob.Sort(CompareMetrics);
                            metricValues.AddRange(metricsInBlob);
                        }
                    }

                    var metric = new Metric
                    {
                        Name = new LocalizableString
                        {
                            Value = metricDefinition.Name.Value,
                            LocalizedValue = metricDefinition.Name.LocalizedValue,
                        },
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        MetricValues = GetAggregatedByTimestamp(metricValues),
                        TimeGrain = availability.TimeGrain,
                    };

                    result.MetricCollection.Value.Add(metric);
                }
            }

            return result;
        }

        private int CompareMetrics(MetricValueBlob a, MetricValueBlob b)
        {
            return a.time.CompareTo(b.time);
        }

        private static string GetBlobEndpoint(BlobInfo blobInfo)
        {
            return blobInfo.BlobUri.Split(questionMark, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        // This method assumes that the list is ordered by timestamp.
        private List<MetricValue> GetAggregatedByTimestamp(List<MetricValueBlob> metricValues)
        {
            MetricValue lastSeen = null;
            var result = new List<MetricValue>();
            foreach (MetricValueBlob m in metricValues)
            {
                if (lastSeen == null)
                {
                    lastSeen = GetConvertedMetric(m);
                    result.Add(lastSeen);
                }
                else
                {
                    if (m.time == lastSeen.Timestamp)
                    {
                        Aggregate(lastSeen, m);
                    }
                    else
                    {
                        lastSeen.Average = lastSeen.Total / lastSeen.Count;
                        lastSeen = GetConvertedMetric(m);
                        result.Add(lastSeen);
                    }
                }
            }

            if (lastSeen != null)
            {
                lastSeen.Average = lastSeen.Total / lastSeen.Count;
            }
            
            return result;
        }

        private static void Aggregate(MetricValue lastSeen, MetricValueBlob m)
        {
            // If count is not supplied, we assume 1, so the total / average relation works.
            lastSeen.Count += m.count == 0 ? 1 : m.count;

            // In case the RP doesn't populate total, we calculate total from the average * count.
            if (m.total == 0 && m.average != 0)
            {
                lastSeen.Total += m.average * lastSeen.Count;
            }
            else
            {
                lastSeen.Total += m.total;
            }

            if (m.maximum > lastSeen.Maximum)
            {
                lastSeen.Maximum = m.maximum;
            }

            if (m.minimum < lastSeen.Minimum)
            {
                lastSeen.Minimum = m.minimum;
            }
        }

        private static MetricValue GetConvertedMetric(MetricValueBlob m)
        {
            // If count is not supplied, we assume 1, so the total / average relation works.
            var metricValue = new MetricValue
            {
                Count = m.count == 0 ? 1 : m.count,
                Maximum = m.maximum,
                Minimum = m.minimum,
                Timestamp = m.time,
            };

            // In case the RP doesn't populate average, we calculate average from total / count.
            if (m.average == 0 && m.total != 0)
            {
                metricValue.Average = m.total / metricValue.Count;
            }
            else
            {
                metricValue.Average = m.average;
            }

            // In case the RP doesn't populate total, we calculate total from the average * count.
            if (m.total == 0 && m.average != 0)
            {
                metricValue.Total = m.average * metricValue.Count;
            }
            else
            {
                metricValue.Total = m.total;
            }

            return metricValue;
        }

        private static bool IsMetricDefinitionIncluded(MetricFilter filter, MetricDefinition metricDefinition)
        {
            return filter == null || filter.DimensionFilters.Any(x => string.Equals(metricDefinition.Name.Value, x.Name, StringComparison.Ordinal));
        }

        private async Task<Dictionary<string, List<MetricValueBlob>>> FetchMetricValuesFromBlob(BlobInfo blobInfo, MetricFilter filter)
        {
            if (blobInfo.EndTime < filter.StartTime || blobInfo.StartTime >= filter.EndTime)
            {
                return new Dictionary<string, List<MetricValueBlob>>();
            }

            var blob = new CloudBlockBlob(new Uri(blobInfo.BlobUri));

            using (var memoryStream = new MemoryStream())
            {
                try
                {
                    await blob.DownloadToStreamAsync(memoryStream);
                }
                catch (StorageException ex)
                {
                    if (ex.RequestInformation.HttpStatusCode == 404)
                    {
                        return new Dictionary<string, List<MetricValueBlob>>();
                    }

                    throw;
                }
                
                memoryStream.Seek(0, 0);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    string content = await streamReader.ReadToEndAsync();
                    var metricBlob = JsonConvert.DeserializeObject<MetricBlob>(content);
                    var metricValues = metricBlob.records;

                    var metricsPerName = new Dictionary<string, List<MetricValueBlob>>();
                    foreach (var metric in metricValues)
                    {
                        if (metric.time < filter.StartTime || metric.time >= filter.EndTime)
                        {
                            continue;
                        }

                        List<MetricValueBlob> metrics;
                        if (!metricsPerName.TryGetValue(metric.metricName, out metrics))
                        {
                            metrics = new List<MetricValueBlob>();
                            metricsPerName.Add(metric.metricName, metrics);
                        }

                        metrics.Add(metric);
                    }

                    return metricsPerName;
                }
            }
        }

        private class MetricBlob
        {
            public List<MetricValueBlob> records { get; set; }
        }

#pragma warning disable 0649
        private class MetricValueBlob
        {
            public string metricName;
			public DateTime time;
			public double total;
			public int count;
			public double maximum;
			public double minimum;
			public double average;
        }
#pragma warning restore 0649
    }
}
