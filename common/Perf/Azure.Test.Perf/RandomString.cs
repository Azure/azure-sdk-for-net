// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Test.Perf
{
    public static class RandomString
    {
        private const string _alphanumeric = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string CreateAlphanumeric(int length)
        {
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = _alphanumeric[ThreadsafeRandom.Next(_alphanumeric.Length)];
            }
            return new string(buffer);
        }
    }
}
