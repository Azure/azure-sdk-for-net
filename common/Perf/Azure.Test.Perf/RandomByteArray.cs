// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    public static class RandomByteArray
    {
        public static byte[] Create(int size)
        {
            var bytes = new byte[size];
            (new Random(0)).NextBytes(bytes);
            return bytes;
        }
    }
}
