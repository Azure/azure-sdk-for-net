// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
    }
}
