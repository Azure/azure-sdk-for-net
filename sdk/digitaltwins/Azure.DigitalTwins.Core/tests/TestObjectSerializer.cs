﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Custom serializer to pass to the DigitalTwins client.
    /// </summary>
    public class TestObjectSerializer : ObjectSerializer
    {
        private static readonly JsonObjectSerializer s_serializer = new JsonObjectSerializer();

        // This field is used by the tests to confirm the function was called.
        public bool WasDeserializeCalled { get; set; }

        // This field is used by the tests to confirm the function was called.
        public bool WasSerializeCalled { get; set; }

        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            WasDeserializeCalled = true;
            return s_serializer.Deserialize(stream, returnType, cancellationToken);
        }

        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            WasDeserializeCalled = true;
            return await s_serializer.DeserializeAsync(stream, returnType, cancellationToken);
        }

        public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            WasSerializeCalled = true;
            s_serializer.Serialize(stream, value, inputType, cancellationToken);
        }

        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            WasSerializeCalled = true;
            await s_serializer.SerializeAsync(stream, value, inputType, cancellationToken);
        }
    }
}
