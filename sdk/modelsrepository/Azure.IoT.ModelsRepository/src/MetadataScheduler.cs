// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// MetadataScheduler tracks when metadata should be fetched from a repository.
    /// </summary>
    internal class MetadataScheduler
    {
        private bool _isInitialFetch;
        private readonly bool _isEnabled;

        /// <param name="metadataOptions">The desired configuration for metadata processing.</param>
        public MetadataScheduler(ModelsRepositoryClientMetadataOptions metadataOptions)
        {
            _isInitialFetch = true;
            _isEnabled = metadataOptions.IsMetadataProcessingEnabled;
        }

        /// <summary>
        /// To be invoked by caller indicating repository metadata has been fetched.
        /// </summary>
        public void MarkAsFetched()
        {
            if (_isInitialFetch)
            {
                _isInitialFetch = false;
            }
        }

        /// <summary>
        /// Indicates whether the caller should fetch metadata.
        /// </summary>
        public bool ShouldFetchMetadata()
        {
            if (_isEnabled && _isInitialFetch)
            {
                return true;
            }

            return false;
        }
    }
}
