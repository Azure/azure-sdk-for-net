// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// AttestationData represents a <see cref="BinaryData"/> object passed as an input to the Attestation Service.
    ///
    /// AttestationData comes in two forms: Binary and JSON. To distinguish between the two, when an <see cref="AttestationData"/>
    /// object is created, the caller provides an indication that the input binary data will be treated as either JSON or Binary.
    ///
    /// The <see cref="AttestationData"/> is reflected in the generated <see cref="AttestationResult"/> in two possible ways.
    /// If the <see cref="AttestationData"/> is Binary, then the <see cref="AttestationData"/> is reflected in the <see cref="AttestationResult.EnclaveHeldData"/> claim.
    /// If the <see cref="AttestationData"/> is JSON, then the <see cref="AttestationData"/> is expressed as JSON in the <see cref="AttestationResult.RuntimeClaims"/> or <see cref="AttestationResult.InittimeClaims"/> claim.
    /// </summary>
    public class AttestationData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttestationData"/> class.
        /// </summary>
        /// <param name="data">Binary data to be sent to the service.</param>
        /// <param name="dataIsJson">True if the binary data should be treated as JSON by the attestation service.</param>
        public AttestationData(BinaryData data, bool dataIsJson)
        {
            Argument.AssertNotNull(data, nameof(data));
            BinaryData = data;
            DataIsJson = dataIsJson;
            if (dataIsJson)
            {
                var parsedJson = JsonDocument.Parse(data.ToArray());
                if (parsedJson.RootElement.ValueKind != JsonValueKind.Object)
                {
                    throw new ArgumentException("Data provided to BinaryData was marked as JSON but is not a JSON object.");
                }
            }
        }

        /// <summary>
        /// BinaryData to be sent to the Attestation Service.
        /// </summary>
        public BinaryData BinaryData { get; }

        /// <summary>
        /// True if the BinaryData should be treated as JSON.
        /// </summary>
        public bool DataIsJson { get; }
    }
}
