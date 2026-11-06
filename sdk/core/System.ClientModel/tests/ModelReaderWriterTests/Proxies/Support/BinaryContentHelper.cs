// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal static class BinaryContentHelper
    {
        internal static string WriteBinaryContent(PlainTextModel model, ModelReaderWriterOptions options)
        {
            using BinaryContent content = BinaryContent.Create(model, options);
            using var stream = new MemoryStream();
            content.WriteTo(stream);
            return BinaryData.FromBytes(stream.ToArray()).ToString();
        }
    }
}
