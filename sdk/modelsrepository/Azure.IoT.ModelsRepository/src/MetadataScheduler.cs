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

        /// <param name="desiredElapsedTimeSpan">A desired <c>TimeSpan</c> that is used to calculate elapsed time periods.</param>
        public MetadataScheduler(TimeSpan desiredElapsedTimeSpan)
        {
            _lastFetched = DateTime.MinValue;
            _desiredElapsedTimeSpan = desiredElapsedTimeSpan;
            _initialFetch = true;
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
            if (_initialFetch)
            {
                return true;
            }

            return (DateTime.UtcNow - _lastFetched) >= _desiredElapsedTimeSpan;
        }
    }
}
