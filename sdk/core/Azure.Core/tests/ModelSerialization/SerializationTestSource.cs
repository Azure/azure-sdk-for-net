// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core.Tests.ModelSerialization
{
    internal static class SerializationTestSource
    {
        private static List<BinaryData> InvalidOperationBinaryData = new List<BinaryData>
        {
            new BinaryData("\"\""u8.ToArray()),
            new BinaryData("[]"u8.ToArray()),
        };

        private static List<BinaryData> JsonExceptionBinaryData = new List<BinaryData>
        {
            new BinaryData(new byte[] { }),
        };

        private static List<BinaryData> NullBinaryData = new List<BinaryData>
        {
            new BinaryData("null"u8.ToArray()),
        };

        private static List<BinaryData> EmptyObjectBinaryData = new List<BinaryData>
        {
            new BinaryData("{}"u8.ToArray()),
        };
    }
}
