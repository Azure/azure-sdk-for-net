// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// MetadataScheduler tracks when metadata should be fetched from a repository.
    /// </summary>
    internal class MetadataScheduler
    {
        private DateTime _lastFetched;
        private readonly TimeSpan _desiredElapsedTimeSpan;
        private bool _initialFetch;
        private readonly bool _enabled;

        /// <param name="metadataOptions">The desired configuration for metadata processing.</param>
        public MetadataScheduler(ModelsRepositoryClientMetadataOptions metadataOptions)
        {
            _lastFetched = DateTime.MinValue;
            _initialFetch = true;
            _desiredElapsedTimeSpan = metadataOptions.Expiration;
            _enabled = metadataOptions.Enabled;
        }

        /// <summary>
        /// Updates the last fetched DateTime attribute of the scheduler to <c>DateTime.Now</c>.
        /// </summary>
        public void Reset()
        {
            if (_initialFetch)
            {
                _initialFetch = false;
            }

            _lastFetched = DateTime.UtcNow;
        }

        /// <summary>
        /// Determines whether the desired time span has elapsed with respect to the last fetched DateTime attribute.
        /// </summary>
        public bool HasElapsed()
        {
            if (!_enabled)
            {
                return false;
            }

            if (_initialFetch)
            {
                return true;
            }

            return (DateTime.UtcNow - _lastFetched) >= _desiredElapsedTimeSpan;
        }
    }
}
