// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    [CodeGenType("InitTimeData")]
    internal partial class InitTimeData
    {
        /// <summary>
        /// Constructs a new instance of an InitTimeData class whose body is an opaque binary blob.
        /// </summary>
        /// <param name="binaryData">binary data with which to initialize the <see cref="InitTimeData"/> object.</param>
        public InitTimeData(byte[] binaryData)
        {
            DataType = Azure.Security.Attestation.DataType.Binary;
            Data = BinaryData.FromBytes(binaryData);
        }

        /// <summary>
        /// Constructs a new instance of an InitTimeData class whose body is a serialized object.
        /// </summary>
        /// <param name="serializableObject">object to serialize.</param>
        public InitTimeData(object serializableObject)
        {
            DataType = Azure.Security.Attestation.DataType.JSON;

            Data = BinaryData.FromBytes(JsonSerializer.SerializeToUtf8Bytes(serializableObject));
        }
    }
}
