// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class ZeroToOneTargetScalerProvider : ITargetScalerProvider
    {
        private readonly ITargetScaler _targetScaler;

        public ZeroToOneTargetScalerProvider(IServiceProvider serviceProvider, TriggerMetadata triggerMetadata)
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
            blobMetadata.ResolveProperties(serviceProvider.GetService<INameResolver>());
            BlobServiceClientProvider blobServiceClientProvider = new BlobServiceClientProvider(configuration, azureComponentFactory, logForwarder, factory.CreateLogger<BlobServiceClient>());
            BlobServiceClient blobServiceClient = blobServiceClientProvider.Get(blobMetadata.Connection, serviceProvider.GetRequiredService<INameResolver>());
            _targetScaler = new ZeroToOneTargetScaler(triggerMetadata.FunctionName, blobServiceClient, blobMetadata.Path, factory);
        }

        public ITargetScaler GetTargetScaler()
        {
            return _targetScaler;
        }

        internal class ZeroToOneTargetScaler : ITargetScaler
        {
            private readonly TargetScalerDescriptor _targetScalerDescriptor;
            private readonly Lazy<Task<BlobLogListener>> _blobLogListener;
            private readonly ILogger _logger;
            private readonly IBlobPathSource _pathSource;
            private StorageAnalyticsLogEntry _lastIdentifiedLogEntryWithWrites = null;

            public ZeroToOneTargetScaler(string functionId, BlobServiceClient blobServiceClient, string blobPath, ILoggerFactory loggerFactory)
            {
                _targetScalerDescriptor = new TargetScalerDescriptor(functionId);
                _blobLogListener = new(() => BlobLogListener.CreateAsync(
                    blobServiceClient,
                    loggerFactory.CreateLogger<BlobListener>(),
                    CancellationToken.None));
                _logger = loggerFactory.CreateLogger<ZeroToOneTargetScaler>();

                // Matching on the full path pattern keeps scale decisions consistent with BlobTriggerExecutor.
                _pathSource = CreatePathSource(blobPath, _logger);
            }

            public TargetScalerDescriptor TargetScalerDescriptor => _targetScalerDescriptor;

            public async Task<TargetScalerResult> GetScaleResultAsync(TargetScalerContext context)
            {
                var now = DateTimeOffset.UtcNow;

                var startOfPreviousHour = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0).AddHours(-1);
                if (_lastIdentifiedLogEntryWithWrites?.RequestStartTime > startOfPreviousHour)
                {
                    _logger.LogInformation($"Recent writes were detected from cache for '{_targetScalerDescriptor.FunctionId}' (requestedObjectKey='{_lastIdentifiedLogEntryWithWrites.RequestedObjectKey}', requestStartTime='{_lastIdentifiedLogEntryWithWrites.RequestStartTime:O}').");
                    return new TargetScalerResult() { TargetWorkerCount = 1 };
                }

                var blobLogListener = await _blobLogListener.Value.ConfigureAwait(false);
                _lastIdentifiedLogEntryWithWrites = await blobLogListener.GetFirstLogEntryWithWritesAsync(_pathSource, CancellationToken.None).ConfigureAwait(false);
                if (_lastIdentifiedLogEntryWithWrites != null)
                {
                    _logger.LogInformation($"Recent writes were detected for '{_targetScalerDescriptor.FunctionId}' (requestedObjectKey='{_lastIdentifiedLogEntryWithWrites.RequestedObjectKey}', requestStartTime='{_lastIdentifiedLogEntryWithWrites.RequestStartTime:O}').");
                    return new TargetScalerResult() { TargetWorkerCount = 1 };
                }
                else
                {
                    _logger.LogInformation($"No recent writes were detected for '{_targetScalerDescriptor.FunctionId}'.");
                }

                return new TargetScalerResult() { TargetWorkerCount = 0 };
            }

            private static IBlobPathSource CreatePathSource(string blobPath, ILogger logger)
            {
                try
                {
                    return BlobPathSource.Create(blobPath);
                }
                catch (FormatException ex)
                {
                    // Degrade rather than failing scaling for the whole function. An empty container name matches
                    // nothing, which is the safe default when the path is unusable.
                    int separatorIndex = blobPath?.IndexOf('/') ?? -1;
                    string containerName = separatorIndex > 0 ? blobPath.Substring(0, separatorIndex) : blobPath ?? string.Empty;

                    logger.LogWarning(ex, "Unable to parse blob trigger path '{BlobPath}'. Falling back to container-only matching on '{ContainerName}'.", blobPath, containerName);

                    return new FixedBlobPathSource(new BlobPath(containerName, string.Empty));
                }
            }
        }

        internal class BlobMetadata
        {
            [JsonProperty]
            public string Connection { get; set; }

            [JsonProperty]
            public string Path { get; set; }

            public void ResolveProperties(INameResolver resolver)
            {
                if (resolver != null)
                {
                    Path = resolver.ResolveWholeString(Path);
                }
            }
        }
    }
}
