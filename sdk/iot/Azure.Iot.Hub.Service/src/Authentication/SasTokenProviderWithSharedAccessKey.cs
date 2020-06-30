// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// Implementation of a shared access signature provider with token caching and refresh.
    /// </summary>
    internal class SasTokenProviderWithSharedAccessKey : ISasTokenProvider
    {
        // The default time to live for a sas token is set to 30 minutes.
        private static readonly TimeSpan s_defaultTimeToLive = TimeSpan.FromMinutes(30);

        // Time buffer before expiry when the token should be renewed, expressed as a percentage of the time to live.
        // The token will be renewed when it has 15% or less of the sas token's lifespan left.
        private const int s_renewalTimeBufferPercentage = 15;

        private readonly object _lock = new object();

        private readonly string _hostName;
        private readonly string _sharedAccessPolicy;
        private readonly string _sharedAccessKey;
        private readonly TimeSpan _timeToLive;

        private string _cachedSasToken;
        private DateTimeOffset _tokenExpiryTime;

        // Protected constructor, to allow mocking
        protected SasTokenProviderWithSharedAccessKey()
        {
        }

        internal SasTokenProviderWithSharedAccessKey(string hostName, string sharedAccessPolicy, string sharedAccessKey, TimeSpan? timeToLive = null)
        {
            _hostName = hostName;
            _sharedAccessPolicy = sharedAccessPolicy;
            _sharedAccessKey = sharedAccessKey;
            _timeToLive = timeToLive ?? s_defaultTimeToLive;

            _cachedSasToken = null;
        }

        string ISasTokenProvider.GetSasToken()
        {
            lock (_lock)
            {
                if (IsTokenExpired())
                {
                    var builder = new SharedAccessSignatureBuilder
                    {
                        HostName = _hostName,
                        SharedAccessPolicy = _sharedAccessPolicy,
                        SharedAccessKey = _sharedAccessKey,
                        TimeToLive = _timeToLive,
                    };

                    _tokenExpiryTime = DateTimeOffset.UtcNow.Add(_timeToLive);
                    _cachedSasToken = builder.ToSignature();
                }

                return _cachedSasToken;
            }
        }

        private bool IsTokenExpired()
        {
            // The token is considered expired if this is the first time it is being accessed (not cached yet)
            // or the current time is greater than or equal to the token expiry time, less 15% buffer.
            if (_cachedSasToken == null)
            {
                return true;
            }

            var bufferTimeInMilliseconds = (double)s_renewalTimeBufferPercentage / 100 * _timeToLive.TotalMilliseconds;
            DateTimeOffset tokenExpiryTimeWithBuffer = _tokenExpiryTime.AddMilliseconds(-bufferTimeInMilliseconds);
            return DateTimeOffset.UtcNow.CompareTo(tokenExpiryTimeWithBuffer) >= 0;
        }
    }
}
