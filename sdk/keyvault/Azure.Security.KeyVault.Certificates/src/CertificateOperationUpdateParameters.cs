// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates
{
    internal class CertificateOperationUpdateParameters : IJsonSerializable
    {
        private const string CancellationRequestedPropertyName = "cancellation_requested";
        private static readonly JsonEncodedText s_cancellationRequestedPropertyNameBytes = JsonEncodedText.Encode(CancellationRequestedPropertyName);

        private readonly bool _cancellationRequested;

        public CertificateOperationUpdateParameters(bool cancellationRequested)
        {
            _cancellationRequested = cancellationRequested;
        }

        void IJsonSerializable.WriteProperties(Utf8JsonWriter json)
        {
            json.WriteBoolean(s_cancellationRequestedPropertyNameBytes, _cancellationRequested);
        }
    }
}
