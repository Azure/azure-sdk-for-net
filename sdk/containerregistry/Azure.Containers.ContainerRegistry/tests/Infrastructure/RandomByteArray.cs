// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Tests
{
    public static class RandomByteArray
    {
        public static byte[] Create(int size)
        {
            var bytes = new byte[size];
            ThreadsafeRandom.NextBytes(bytes);
            return bytes;
        }
    }
}
