// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.ModelsRepository
{
    internal class StandardStrings
    {
        public const string GenericGetModelsError = "Failure handling \"{0}\".";
        public const string InvalidDtmiFormat = "Invalid DTMI format \"{0}\".";
        public const string ClientInitWithFetcher = "Client session {0} initialized with {1} content fetcher.";
        public const string ProcessingDtmi = "Processing DTMI \"{0}\". ";
        public const string SkippingPreProcessedDtmi = "Already processed DTMI \"{0}\". Skipping.";
        public const string DiscoveredDependencies = "Discovered dependencies \"{0}\".";
        public const string FetchingModelContent = "Attempting to fetch model content from \"{0}\".";
        public const string ErrorFetchingModelContent = "Model file \"{0}\" not found or not accessible in target repository.";
        public const string FailureProcessingRepositoryMetadata = "Unable to fetch or process repository metadata file.";
        public const string IncorrectDtmi =
            "Fetched model has an incorrect DTMI. Expected \"{0}\", parsed \"{1}\".";
    }
}
