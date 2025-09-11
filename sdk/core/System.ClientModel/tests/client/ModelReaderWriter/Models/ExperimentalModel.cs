// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
#if NET8_0_OR_GREATER
    [Experimental("TEST001")]
#endif
    public class ExperimentalModel : IJsonModel<ExperimentalModel>
    {
        public BinaryData Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public ExperimentalModel? Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public string GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        public ExperimentalModel? Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
