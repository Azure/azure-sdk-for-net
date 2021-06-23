// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace Azure.Core
{
    // APIs not avaliable in NetStandard 2.0
    internal static class NS2Bridge
    {
        public delegate void SpanAction<T, TArg>(Span<T> buffer, TArg state);
        public static string CreateString<TState>(int length, TState state, SpanAction<char, TState> action)
        {
            var result = new string((char)0, length);
            unsafe
            {
                fixed (char* chars = result)
                {
                    var charBuffer = new Span<char>(chars, result.Length);
                    action(charBuffer, state);
                }
            }
            return result;
        }

        public static void Latin1ToUtf16(ReadOnlySpan<byte> latin1, Span<char> utf16)
        {
            if (utf16.Length < latin1.Length)
                throw new ArgumentOutOfRangeException(nameof(utf16));
            for (int i = 0; i < latin1.Length; i++)
            {
                utf16[i] = (char)latin1[i];
            }
        }

        public static OperationStatus Base64UrlEncodeInPlace(Span<byte> buffer, long dataLength, out int bytesWritten)
        {
            OperationStatus status = Base64.EncodeToUtf8InPlace(buffer, (int)dataLength, out bytesWritten);
            if (status != OperationStatus.Done)
            {
                return status;
            }

            bytesWritten = Base64ToBase64Url(buffer.Slice(0, bytesWritten));
            return OperationStatus.Done;
        }
        public static OperationStatus Base64UrlEncode(ReadOnlySpan<byte> buffer, Span<byte> destination, out int bytesConsumend, out int bytesWritten)
        {
            OperationStatus status = Base64.EncodeToUtf8(buffer, destination, out bytesConsumend, out bytesWritten, isFinalBlock: true);
            if (status != OperationStatus.Done)
            {
                return status;
            }

            bytesWritten = Base64ToBase64Url(destination.Slice(0,bytesWritten));
            return OperationStatus.Done;
        }

        private static int Base64ToBase64Url(Span<byte> buffer)
        {
            var bytesWritten = buffer.Length;
            if (buffer[bytesWritten - 1] == (byte)'=')
            {
                bytesWritten--;
                if (buffer[bytesWritten - 1] == (byte)'=')
                    bytesWritten--;
            }
            for (int i = 0; i < bytesWritten; i++)
            {
                byte current = buffer[i];
                if (current == (byte)'+')
                    buffer[i] = (byte)'-';
                else if (current == (byte)'/')
                    buffer[i] = (byte)'_';
            }
            return bytesWritten;
        }
    }
}
