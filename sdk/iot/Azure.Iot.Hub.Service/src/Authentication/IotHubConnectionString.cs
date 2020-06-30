// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// Implementation for creating the shared access signature token provider.
    /// </summary>
    internal class IotHubConnectionString
    {
        private const string HostNameIdentifier = "HostName";
        private const string SharedAccessKeyIdentifier = "SharedAccessKey";
        private const string SharedAccessKeyNameIdentifier = "SharedAccessKeyName";
        private const string SharedAccessSignatureIdentifier = "SharedAccessSignature";

        private readonly ConnectionString _connectionString;
        private readonly string _sharedAccessPolicy;
        private readonly string _sharedAccessKey;
        private readonly string _sharedAccessSignature;

        internal IotHubConnectionString(string connectionString)
        {
            _connectionString = ConnectionString.Parse(connectionString);
            _sharedAccessKey = _connectionString.GetNonRequired(SharedAccessKeyIdentifier);
            _sharedAccessPolicy = _connectionString.GetNonRequired(SharedAccessKeyNameIdentifier);
            _sharedAccessSignature = _connectionString.GetNonRequired(SharedAccessSignatureIdentifier);

            if (!ValidateInput(_sharedAccessPolicy, _sharedAccessKey, _sharedAccessSignature))
            {
                throw new ArgumentException("Specify either both the sharedAccessKey and sharedAccessKeyName, or only sharedAccessSignature");
            }

            HostName = _connectionString.GetRequired(HostNameIdentifier);
        }

        internal string HostName { get; }

        internal ISasTokenProvider GetSasTokenProvider()
        {
            if (_sharedAccessSignature == null)
            {
                return new SasTokenProviderWithSharedAccessKey(HostName, _sharedAccessPolicy, _sharedAccessKey);
            }
            return new FixedSasTokenProvider(_sharedAccessSignature);
        }

        private static bool ValidateInput(string sharedAccessPolicy, string sharedAccessKey, string sharedAccessSignature)
        {
            if (sharedAccessSignature == null)
            {
                return sharedAccessKey != null && sharedAccessPolicy != null;
            }
            else
            {
                return sharedAccessKey == null && sharedAccessPolicy == null;
            }
        }
    }
}
