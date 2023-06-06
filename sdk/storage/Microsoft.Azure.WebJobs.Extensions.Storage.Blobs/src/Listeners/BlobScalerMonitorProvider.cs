﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobScalerMonitorProvider : IScaleMonitorProvider
    {
        private readonly IScaleMonitor _scaleMonitor;

        public BlobScalerMonitorProvider(IServiceProvider serviceProvider, TriggerMetadata triggerMetadata)
        {
            AzureComponentFactory azureComponentFactory = null;
            if ((triggerMetadata.Properties != null) && (triggerMetadata.Properties.TryGetValue(nameof(AzureComponentFactory), out object value)))
            {
                azureComponentFactory = value as AzureComponentFactory;
            }
            else
            {
                azureComponentFactory = serviceProvider.GetService<AzureComponentFactory>();
            }
            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();
            AzureEventSourceLogForwarder logForwarder = serviceProvider.GetService<AzureEventSourceLogForwarder>();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            BlobMetadata blobMetadata = JsonConvert.DeserializeObject<BlobMetadata>(triggerMetadata.Metadata.ToString());
            BlobServiceClientProvider blobServiceClientProvider = new BlobServiceClientProvider(configuration, azureComponentFactory, logForwarder, factory.CreateLogger<BlobServiceClient>());
            BlobServiceClient blobServiceClient = blobServiceClientProvider.Get(blobMetadata.Connection, serviceProvider.GetRequiredService<INameResolver>());
            _scaleMonitor = new ZeroToOneScaleMonitor(triggerMetadata.FunctionName, blobServiceClient, factory);
        }

        public IScaleMonitor GetMonitor()
        {
            return _scaleMonitor;
        }

        private class ZeroToOneScaleMonitor : IScaleMonitor<ScaleMetrics>
        {
            private readonly ScaleMonitorDescriptor _scaleMonitorDescriptor;
            private readonly Lazy<Task<BlobLogListener>> _blobLogListener;
            private readonly ILogger _logger;
            private int _threadSafeWritesDetectedValue;

            public ZeroToOneScaleMonitor(string functionId, BlobServiceClient blobServiceClient, ILoggerFactory loggerFactory)
            {
                _scaleMonitorDescriptor = new ScaleMonitorDescriptor(functionId, functionId);
                _blobLogListener = new(() => BlobLogListener.CreateAsync(
                    blobServiceClient,
                    loggerFactory.CreateLogger<BlobListener>(),
                    CancellationToken.None));
                _logger = loggerFactory.CreateLogger<ZeroToOneScaleMonitor>();
            }

            #pragma warning disable 0649
            // For tests, in PROD the value is always null
            private BlobWithContainer<BlobBaseClient> _recentWrite;
            #pragma warning restore 0649

            public ScaleMonitorDescriptor Descriptor => _scaleMonitorDescriptor;

            public async Task<ScaleMetrics> GetMetricsAsync()
            {
                // if new blob were detected we want to GetScaleStatus return scale out vote at least once
                if (Interlocked.Equals(_threadSafeWritesDetectedValue, 1))
                {
                    _logger.LogInformation($"New writes were detectd but GetScaleStatus was not called. Waiting GetScaleStatus to call.");
                    return new ScaleMetrics();
                }

                var blobLogListener = await _blobLogListener.Value.ConfigureAwait(false);
                BlobWithContainer<BlobBaseClient>[] recentWrites = _recentWrite == null ? (await blobLogListener.GetRecentBlobWritesAsync(CancellationToken.None).ConfigureAwait(false)).ToArray()
                    : new BlobWithContainer<BlobBaseClient>[] { _recentWrite };
                if (recentWrites.Length > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (var write in recentWrites)
                    {
                        stringBuilder.Append($"'{write.BlobClient.Name}', ");
                        if (stringBuilder.Length > 1000)
                        {
                            stringBuilder.Append("[truncated]");
                            break;
                        }
                    }
                    _logger.LogInformation($"'{recentWrites.Length}' recent writes were detected for '{_scaleMonitorDescriptor.FunctionId}': {stringBuilder}");
                    Interlocked.CompareExchange(ref _threadSafeWritesDetectedValue, 1, 0);
                }
                else
                {
                    _logger.LogInformation($"No recent writes were detected for '{_scaleMonitorDescriptor.FunctionId}'");
                    Interlocked.CompareExchange(ref _threadSafeWritesDetectedValue, 0, 1);
                }
                return new ScaleMetrics();
            }

            public ScaleStatus GetScaleStatus(ScaleStatusContext context)
            {
                return GetScaleStatusCore(context.WorkerCount);
            }

            public ScaleStatus GetScaleStatus(ScaleStatusContext<ScaleMetrics> context)
            {
                return GetScaleStatusCore(context.WorkerCount);
            }

            private ScaleStatus GetScaleStatusCore(int workerCount)
            {
                // if there is at least one worker we assume all the blobs are added to internal queue and we need to ScaleIn
                if (workerCount > 0)
                {
                    // Set to 0 if there is an active worker
                    Interlocked.CompareExchange(ref _threadSafeWritesDetectedValue, 0, 1);
                }

                ScaleVote vote = ScaleVote.None;
                if (workerCount == 0 && _threadSafeWritesDetectedValue == 1)
                {
                    vote = ScaleVote.ScaleOut;
                }
                else if (workerCount > 0 && _threadSafeWritesDetectedValue == 0)
                {
                    vote = ScaleVote.ScaleIn;
                }
                else if (workerCount == 0 && _threadSafeWritesDetectedValue == 0)
                {
                    vote = ScaleVote.None;
                }
                _logger.LogInformation($"Current vote is '{vote}', active workers is '{workerCount}' for '{_scaleMonitorDescriptor.FunctionId}'");

                return new ScaleStatus()
                {
                    Vote = vote
                };
            }
        }

        internal class BlobMetadata
        {
            [JsonProperty]
            public string Connection { get; set; }
        }
    }
}
