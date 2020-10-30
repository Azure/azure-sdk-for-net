// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Security.Attestation.Models
{
    public partial class RuntimeData
    {
        /// <summary>
        /// Constructs a new instance of an InitTimeData class whose body is an opaque binary blob.
        /// </summary>
        /// <param name="binaryData">binary data with which to initialize the <see cref="InitTimeData"/> object.</param>
        public RuntimeData(byte[] binaryData)
        {
            DataType = Models.DataType.Binary;
            Data = binaryData;
        }

        /// <summary>
        /// Constructs a new instance of an InitTimeData class whose body is a serialized object.
        /// </summary>
        /// <param name="serializableObject">object to serialize.</param>
        public RuntimeData(object serializableObject)
        {
            DataType = Models.DataType.Json;

            Data = JsonSerializer.SerializeToUtf8Bytes(serializableObject);
        }
    }
}
