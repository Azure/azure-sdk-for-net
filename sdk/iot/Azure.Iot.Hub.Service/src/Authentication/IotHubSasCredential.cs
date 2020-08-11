// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// The IoT Hub credentials, to be used for authenticating against an IoT Hub instance via SAS tokens.
    /// </summary>
    public class IotHubSasCredential : ISasTokenProvider
    {
        // Time buffer before expiry when the token should be renewed, expressed as a percentage of the time to live.
        // The token will be renewed when it has 15% or less of the sas token's lifespan left.
        private const int RenewalTimeBufferPercentage = 15;

        private readonly object _lock = new object();

        private string _cachedSasToken;
        private DateTimeOffset _tokenExpiryTime;

        internal IotHubSasCredential(string connectionString)
        {
            Argument.AssertNotNullOrWhiteSpace(connectionString, nameof(connectionString));

            var iotHubConnectionString = ConnectionString.Parse(connectionString);

            var sharedAccessPolicy = iotHubConnectionString.GetRequired(SharedAccessSignatureConstants.SharedAccessPolicyIdentifier);
            var sharedAccessKey = iotHubConnectionString.GetRequired(SharedAccessSignatureConstants.SharedAccessKeyIdentifier);

            Endpoint = BuildEndpointUriFromHostName(iotHubConnectionString.GetRequired(SharedAccessSignatureConstants.HostNameIdentifier));
            SetCredentials(sharedAccessPolicy, sharedAccessKey);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IotHubSasCredential"/> class.
        /// </summary>
        /// <param name="sharedAccessPolicy">
        /// The IoT Hub access permission, which can be either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <param name="sharedAccessKey">
        /// The IoT Hub shared access key associated with the shared access policy permissions.
        /// </param>
        /// <param name="timeToLive">
        /// (Optional) The validity duration of the generated shared access signature token used for authentication.
        /// The token will be renewed when at 15% or less of it's lifespan. The default value is 30 minutes.
        /// </param>
        public IotHubSasCredential(string sharedAccessPolicy, string sharedAccessKey, TimeSpan timeToLive = default)
        {
            Argument.AssertNotNullOrWhiteSpace(sharedAccessPolicy, nameof(sharedAccessPolicy));
            Argument.AssertNotNullOrWhiteSpace(sharedAccessKey, nameof(sharedAccessKey));

            SetCredentials(sharedAccessPolicy, sharedAccessKey, timeToLive);
        }

        private void SetCredentials(string sharedAccessPolicy, string sharedAccessKey, TimeSpan timeToLive = default)
        {
            SharedAccessPolicy = sharedAccessPolicy;
            SharedAccessKey = sharedAccessKey;

            if (!timeToLive.Equals(TimeSpan.Zero))
            {
                if (timeToLive.CompareTo(TimeSpan.Zero) < 0)
                {
                    throw new ArgumentException("The value for SasTokenTimeToLive cannot be a negative TimeSpan", nameof(timeToLive));
                }

                SasTokenTimeToLive = timeToLive;
            }

            _cachedSasToken = null;
        }

        /// <summary>
        /// The IoT Hub service instance endpoint to connect to.
        /// </summary>
        public Uri Endpoint { get; internal set; }

        /// <summary>
        /// The IoT Hub access permission, which can be either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </summary>
        public string SharedAccessPolicy { get; private set; }

        /// <summary>
        /// The IoT Hub shared access key associated with the shared access policy permissions.
        /// </summary>
        public string SharedAccessKey { get; private set; }

        /// <summary>
        /// The validity duration of the generated shared access signature token used for authentication.
        /// The token will be renewed when at 15% or less of it's lifespan. The default value is 30 minutes.
        /// </summary>
        public TimeSpan SasTokenTimeToLive { get; private set; } = TimeSpan.FromMinutes(30);

        private static Uri BuildEndpointUriFromHostName(string hostName)
        {
            return new UriBuilder
            {
                Scheme = Uri.UriSchemeHttps,
                Host = hostName
            }.Uri;
        }

        public string GetSasToken()
        {
            lock (_lock)
            {
                if (TokenShouldBeGenerated())
                {
                    var builder = new SharedAccessSignatureBuilder
                    {
                        HostName = Endpoint.Host,
                        SharedAccessPolicy = SharedAccessPolicy,
                        SharedAccessKey = SharedAccessKey,
                        TimeToLive = SasTokenTimeToLive,
                    };

                    _tokenExpiryTime = DateTimeOffset.UtcNow.Add(SasTokenTimeToLive);
                    _cachedSasToken = builder.ToSignature();
                }

                return _cachedSasToken;
            }
        }

        private bool TokenShouldBeGenerated()
        {
            // The token needs to be generated if this is the first time it is being accessed (not cached yet)
            // or the current time is greater than or equal to the token expiry time, less 15% buffer.
            if (_cachedSasToken == null)
            {
                return true;
            }

            var bufferTimeInMilliseconds = (double)RenewalTimeBufferPercentage / 100 * SasTokenTimeToLive.TotalMilliseconds;
            DateTimeOffset tokenExpiryTimeWithBuffer = _tokenExpiryTime.AddMilliseconds(-bufferTimeInMilliseconds);
            return DateTimeOffset.UtcNow.CompareTo(tokenExpiryTimeWithBuffer) >= 0;
        }
    }
}
