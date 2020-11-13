// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class BinaryDataExtensions
    {
        private static readonly UTF8Encoding encoding = new UTF8Encoding(false, true);

        public static string ToValidUTF8String(this BinaryData binaryData)
        {
            if (MemoryMarshal.TryGetArray(binaryData.ToMemory(), out ArraySegment<byte> data))
            {
                return encoding.GetString(data.Array, data.Offset, data.Count);
            }
            return encoding.GetString(binaryData.ToArray());
        }

        public static string TryGetAsString(this BinaryData binaryData)
        {
            if (binaryData == null)
            {
                throw new ArgumentNullException(nameof(binaryData));
            }

            string value;

            try
            {
                value = binaryData.ToValidUTF8String();
            }
            catch (Exception ex)
            {
                if (ex is DecoderFallbackException || ex is FormatException)
                {
                    value = null;
                }
                else
                {
                    throw;
                }
            }

            return value;
        }
    }
}
