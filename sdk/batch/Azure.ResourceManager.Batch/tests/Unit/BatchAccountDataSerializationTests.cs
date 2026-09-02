// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests.Unit
{
    public class BatchAccountDataSerializationTests
    {
        private static readonly ModelReaderWriterOptions s_wireOptions = new("W");

        [Test]
        public void SerializesNullLocation()
        {
            BinaryData json = ModelReaderWriter.Write(new BatchAccountData(), s_wireOptions);

            using JsonDocument document = JsonDocument.Parse(json);
            Assert.AreEqual(JsonValueKind.Null, document.RootElement.GetProperty("location").ValueKind);
        }

        [Test]
        public void DeserializesNullLocation()
        {
            using JsonDocument document = JsonDocument.Parse("""{"location":null}""");

            BatchAccountData data = BatchAccountData.DeserializeBatchAccountData(document.RootElement, s_wireOptions);

            Assert.IsNull(data.Location);
        }
    }
}
