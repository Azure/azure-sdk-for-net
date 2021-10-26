// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// MetadataScheduler tracks when metadata should be fetched from a repository.
    /// </summary>
    internal class MetadataScheduler
    {
        private bool _initialFetch;
        private readonly bool _enabled;

        /// <param name="metadataOptions">The desired configuration for metadata processing.</param>
        public MetadataScheduler(ModelsRepositoryClientMetadataOptions metadataOptions)
        {
            _initialFetch = true;
            _enabled = metadataOptions.Enabled;
        }

        /// <summary>
        /// To be invoked by caller indicating repository metadata has been fetched.
        /// </summary>
        public void Set()
        {
            if (_initialFetch)
            {
                _initialFetch = false;
            }
        }

        /// <summary>
        /// Indicates whether the caller should fetch metadata.
        /// </summary>
        public bool ShouldFetchMetadata()
        {
            if (!_enabled)
            {
                return false;
            }

            if (_initialFetch)
            {
                return true;
            }

            return false;
        }
    }
}
