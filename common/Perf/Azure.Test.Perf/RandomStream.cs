// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Test.Perf
{
    public static class RandomStream
    {
        private static readonly Lazy<byte[]> _randomBytes = new Lazy<byte[]>(() => RandomByteArray.Create(1024 * 1024));

        public static Stream Create(long size) => new CircularStream(new MemoryStream(_randomBytes.Value, writable: false), size);
    }
}
