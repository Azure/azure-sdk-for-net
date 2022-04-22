// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;

namespace Azure.IoT.ModelsRepository
{
    [EventSource(Name = EventSourceName)]
    internal sealed class ModelsRepositoryEventSource : AzureEventSource
    {
        private const string EventSourceName = ModelsRepositoryConstants.ModelsRepositoryEventSourceName;

        // Event ids defined as constants to makes it easy to keep track of them
        // Consider EventSource name, Guid, Event Id and parameters as public API and follow the appropriate versioning rules.
        // More information on EventSource and Azure guidelines:
        // https://azure.github.io/azure-sdk/dotnet_implementation.html#eventsource

        private const int InitFetcherEventId = 1000;
        private const int ProcessingDtmiEventId = 2000;
        private const int FetchingModelContentEventId = 2001;
        private const int DiscoveredDependenciesEventId = 2002;
        private const int SkippingPreprocessedDtmiEventId = 2003;
        private const int FailureProcessingRepositoryMetadataEventId = 3001;
        private const int InvalidDtmiInputEventId = 4000;
        private const int ErrorFetchingModelContentEventId = 4004;
        private const int IncorrectDtmiEventId = 4006;

        public static ModelsRepositoryEventSource Instance { get; } = new ModelsRepositoryEventSource();

        private ModelsRepositoryEventSource()
            : base(EventSourceName)
        { }

        [Event(InitFetcherEventId, Level = EventLevel.Informational, Message = StandardStrings.ClientInitWithFetcher)]
        public void InitFetcher(Guid clientId, string scheme)
        {
            // We are calling Guid.ToString make sure anyone is listening before spending resources
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(InitFetcherEventId, clientId.ToString("N"), scheme);
            }
        }

        [Event(InvalidDtmiInputEventId, Level = EventLevel.Error, Message = StandardStrings.InvalidDtmiFormat)]
        public void InvalidDtmiInput(string dtmi)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None))
            {
                WriteEvent(InvalidDtmiInputEventId, dtmi);
            }
        }

        [Event(SkippingPreprocessedDtmiEventId, Level = EventLevel.Informational, Message = StandardStrings.SkippingPreProcessedDtmi)]
        public void SkippingPreprocessedDtmi(string dtmi)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(SkippingPreprocessedDtmiEventId, dtmi);
            }
        }

        [Event(ProcessingDtmiEventId, Level = EventLevel.Informational, Message = StandardStrings.ProcessingDtmi)]
        public void ProcessingDtmi(string dtmi)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(ProcessingDtmiEventId, dtmi);
            }
        }

        [Event(DiscoveredDependenciesEventId, Level = EventLevel.Informational, Message = StandardStrings.DiscoveredDependencies)]
        public void DiscoveredDependencies(string dependencies)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(DiscoveredDependenciesEventId, dependencies);
            }
        }

        [Event(IncorrectDtmiEventId, Level = EventLevel.Error, Message = StandardStrings.IncorrectDtmi)]
        public void IncorrectDtmi(string expected, string parsed)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None))
            {
                WriteEvent(IncorrectDtmiEventId, expected, parsed);
            }
        }

        [Event(FetchingModelContentEventId, Level = EventLevel.Informational, Message = StandardStrings.FetchingModelContent)]
        public void FetchingModelContent(string path)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(FetchingModelContentEventId, path);
            }
        }

        [Event(ErrorFetchingModelContentEventId, Level = EventLevel.Error, Message = StandardStrings.ErrorFetchingModelContent)]
        public void ErrorFetchingModelContent(string path)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.None))
            {
                WriteEvent(ErrorFetchingModelContentEventId, path);
            }
        }

        [Event(FailureProcessingRepositoryMetadataEventId, Level = EventLevel.Informational, Message = StandardStrings.FailureProcessingRepositoryMetadata)]
        public void FailureProcessingRepositoryMetadata(string path)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                WriteEvent(FailureProcessingRepositoryMetadataEventId, path);
            }
        }
    }
}
