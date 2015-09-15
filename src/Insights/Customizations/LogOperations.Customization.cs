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
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Thick client class for getting logs
    /// </summary>
    internal partial class LogOperations
    {
        /// <summary>
        /// Get logs.
        /// </summary>
        /// <param name="resourceUri">The resourceUri</param>
        /// <param name="filterString">The filter string</param>
        /// <param name="definitions">The log definitions</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public async Task<LogListResponse> GetLogsAsync(
            string resourceUri, 
            string filterString, 
            IEnumerable<LogDefinition> definitions, 
            CancellationToken cancellationToken)
        {
            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            if (resourceUri == null)
            {
                throw new ArgumentNullException("resourceUri");
            }

            // Ensure exactly one '/' at the start
            resourceUri = '/' + resourceUri.TrimStart('/');

            LogListResponse result;
            string invocationId = TracingAdapter.NextInvocationId.ToString(CultureInfo.InvariantCulture);

            // If no definitions provided, return empty collection
            if (!definitions.Any())
            {
                this.LogStartGetLogs(invocationId, resourceUri, filterString, definitions);
                result = new LogListResponse()
                {
                    RequestId = Guid.NewGuid().ToString("D"),
                    StatusCode = HttpStatusCode.OK,
                    LogCollection = new LogCollection()
                    {
                        Value = new Log[0]
                    }
                };

                this.LogEndGetLogs(invocationId, result);

                return result;
            }

            // Parse LogFilter. Reusing the metric filter. 
            // We might consider extracting the parsing functionality to a class with a less specific name
            MetricFilter filter = MetricFilterExpressionParser.Parse(filterString, false);

            if (filter.StartTime == default(DateTime)) 
            {
                throw new InvalidOperationException("startTime is required");
            }

            if (filter.EndTime == default(DateTime))
            {
                throw new InvalidOperationException("endTime is required");
            }

            this.LogStartGetLogs(invocationId, resourceUri, filterString, definitions);

            var logsPerBlob = new Dictionary<string, Task<Log>>(StringComparer.OrdinalIgnoreCase);

            // We download all the relevant blobs first and then use the data later, to avoid download the same blob more than once.
            foreach (LogDefinition logDefinition in definitions)
            {
                foreach (BlobInfo blobInfo in logDefinition.BlobLocation.BlobInfo)
                {
                    if (blobInfo.EndTime < filter.StartTime || blobInfo.StartTime >= filter.EndTime)
                    {
                        continue;
                    }

                    string blobId = GetBlobEndpoint(blobInfo);
                    if (!logsPerBlob.ContainsKey(blobId))
                    {
                        logsPerBlob.Add(blobId, FetchLogFromBlob(blobInfo.BlobUri, filter, logDefinition.Category));
                    }
                }
            }

            foreach (var task in logsPerBlob.Values)
            {
                await task;
            }

            var logsPerCategory = new Dictionary<string, Log>();
            foreach (var task in logsPerBlob.Values)
            {
                Log log = task.Result;
                Log existingLog;
                if (logsPerCategory.TryGetValue(log.Category.Value, out existingLog))
                {
                    ((List<LogValue>)existingLog.Value).AddRange(log.Value);
                    existingLog.StartTime = this.Min(log.StartTime, existingLog.StartTime);
                    existingLog.EndTime = this.Max(log.StartTime, existingLog.StartTime);
                }
                else
                {
                    logsPerCategory.Add(log.Category.Value, log);
                }
            }

            result = new LogListResponse
            {
                RequestId = Guid.NewGuid().ToString("D"),
                StatusCode = HttpStatusCode.OK,
                LogCollection = new LogCollection
                {
                    Value = logsPerCategory.Values.ToList()
                }
            };

            this.LogEndGetLogs(invocationId, result);

            return result;
        }

        DateTime Max(DateTime a, DateTime b)
        {
            if (b.Ticks > a.Ticks)
            {
                return b;
            }

            return a;
        }

        DateTime Min(DateTime a, DateTime b)
        {
            if (b.Ticks < a.Ticks)
            {
                return b;
            }

            return a;
        }

        private static readonly char[] questionMark = { '?' };

        private static string GetBlobEndpoint(BlobInfo blobInfo)
        {
            return blobInfo.BlobUri.Split(questionMark, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private async Task<Log> FetchLogFromBlob(string blobUri, MetricFilter filter, LocalizableString category)
        {
            var blob = new CloudBlockBlob(new Uri(blobUri));

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
                        return new Log
                        {
                            Category = new LocalizableString
                            {
                                LocalizedValue = category.LocalizedValue,
                                Value = category.Value
                            },
                            StartTime = filter.StartTime,
                            EndTime = filter.EndTime,
                            Value = new List<LogValue>()
                        };
                    }

                    throw;
                }

                memoryStream.Seek(0, 0);
                using (var streamReader = new StreamReader(memoryStream))
                {
                    string content = await streamReader.ReadToEndAsync();
                    var logBlob = JsonConvert.DeserializeObject<LogBlob>(content);
                    var logValues = logBlob.records.Where(x => x.Time >= filter.StartTime && x.Time < filter.EndTime).ToList();

                    return new Log
                    {
                        Category = category,
                        StartTime = filter.StartTime,
                        EndTime = filter.EndTime,
                        Value = logValues
                    };
                }
            }
        }

        private class LogBlob
        {
            public List<LogValue> records { get; set; }
        }

        private void LogLogCountFromResponses(string invocationId, int logsCount)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Information("InvocationId: {0}. Total number of logs in all resposes: {1}", invocationId, logsCount);
            }
        }

        private void LogEndGetLogs(string invocationId, LogListResponse result)
        {
            if (TracingAdapter.IsEnabled)
            {
                TracingAdapter.Exit(invocationId, result);
            }
        }

        private void LogStartGetLogs(string invocationId, string resourceUri, string filterString, IEnumerable<LogDefinition> definitions)
        {
            if (TracingAdapter.IsEnabled)
            {
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceUri", resourceUri);
                tracingParameters.Add("filterString", filterString);
                tracingParameters.Add("definitions", string.Concat(definitions.Select(d => d.Category)));

                TracingAdapter.Enter(invocationId, this, "GetLogsAsync", tracingParameters);
            }
        }
    }
}
