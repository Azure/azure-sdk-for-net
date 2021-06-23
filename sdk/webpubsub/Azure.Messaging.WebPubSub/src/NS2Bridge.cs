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

        public static void Append(this StringBuilder sb, ReadOnlySpan<char> value)
        {
            unsafe
            {
                fixed (char* chars = value)
                {
                    sb.Append(chars, value.Length);
                }
            }
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

        public static int Latin1ToUtf16InPlace(byte[] latin1, int dataLength)
        {
            int utf16ByteLength = dataLength << 1;
            if (latin1.Length < utf16ByteLength)
                throw new ArgumentOutOfRangeException(nameof(dataLength));

            int destination = utf16ByteLength - 1;

            if (BitConverter.IsLittleEndian)
            {
                for (int i = dataLength - 1; i >= 0; i--)
                {
                    latin1[destination - 1] = latin1[i];
                    latin1[destination] = 0;
                    destination -= 2;
                }
            }
            else
            {
                for (int i = dataLength - 1; i >= 0; i--)
                {
                    latin1[destination - 1] = 0;
                    latin1[destination] = latin1[i];
                    destination -= 2;
                }
            }

            return utf16ByteLength;
        }
        public static OperationStatus Base64UrlEncodeInPlace(Span<byte> buffer, long dataLength, out int bytesWritten)
        {
            OperationStatus status = Base64.EncodeToUtf8InPlace(buffer, (int)dataLength, out bytesWritten);
            if (status != OperationStatus.Done)
            {
                return status;
            }

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
            return OperationStatus.Done;
        }
        public static OperationStatus Base64UrlEncode(ReadOnlySpan<byte> buffer, Span<byte> destination, out int bytesConsumend, out int bytesWritten)
        {
            OperationStatus status = Base64.EncodeToUtf8(buffer, destination, out bytesConsumend, out bytesWritten, isFinalBlock: true);
            if (status != OperationStatus.Done)
            {
                return status;
            }

            if (destination[bytesWritten - 1] == (byte)'=')
            {
                bytesWritten--;
                if (destination[bytesWritten - 1] == (byte)'=')
                    bytesWritten--;
            }
            for (int i = 0; i < bytesWritten; i++)
            {
                byte current = destination[i];
                if (current == (byte)'+')
                    destination[i] = (byte)'-';
                else if (current == (byte)'/')
                    destination[i] = (byte)'_';
            }
            return OperationStatus.Done;
        }
    }
}
