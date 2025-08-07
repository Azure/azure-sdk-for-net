// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Storage.Tests
{
    public static class RandomExtensions
    {
        private const string _alphanumeric = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string NextString(this Random random, int length)
        {
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = _alphanumeric[random.Next(_alphanumeric.Length)];
            }
            return new string(buffer);
        }

        public static Span<byte> NextBytesInline(this Random random, int length)
        {
            var buffer = new byte[length];
            random.NextBytes(buffer);
            return new Span<byte>(buffer);
        }

        public static Memory<byte> NextMemoryInline(this Random random, int length)
        {
            var buffer = new byte[length];
            random.NextBytes(buffer);
            return new Memory<byte>(buffer);
        }

        public static string NextBase64(this Random random, int length)
        {
            var buffer = new byte[length];
            random.NextBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}
