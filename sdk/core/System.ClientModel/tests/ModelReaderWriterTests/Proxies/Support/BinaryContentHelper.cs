// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal static class BinaryContentHelper
    {
        internal static BinaryData WriteBinaryContent<T>(T model, ModelReaderWriterOptions options)
            where T : IPersistableModel<T>
        {
            using BinaryContent content = BinaryContent.Create(model, options);
            return WriteToBinaryData(content);
        }

        internal static BinaryData WriteToBinaryData(BinaryContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream);
            return BinaryData.FromBytes(stream.ToArray());
        }
    }
}
