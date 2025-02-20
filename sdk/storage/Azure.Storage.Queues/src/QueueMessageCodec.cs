// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;

namespace Azure.Storage.Queues
{
    internal static class QueueMessageCodec
    {
        public static string EncodeMessageBody(BinaryData binaryData, QueueMessageEncoding messageEncoding)
        {
            if (binaryData == null)
            {
                return null;
            }
            switch (messageEncoding)
            {
                case QueueMessageEncoding.None:
                    try
                    {
                        return binaryData.ToString();
                    }
                    catch (ArgumentNullException) // workaround for: https://github.com/dotnet/runtime/issues/68262 which was fixed in 8.0.0, can remove this after upgrade
                    {
                        return string.Empty;
                    }
                case QueueMessageEncoding.Base64:
                    if (MemoryMarshal.TryGetArray(binaryData.ToMemory(), out var segment))
                    {
                        return Convert.ToBase64String(segment.Array, segment.Offset, segment.Count);
                    }
                    else
                    {
                        return Convert.ToBase64String(binaryData.ToArray());
                    }
                default:
                    throw new ArgumentException($"Unsupported message encoding {messageEncoding}", nameof(messageEncoding));
            }
        }

        public static BinaryData DecodeMessageBody(string messageText, QueueMessageEncoding messageEncoding)
        {
            if (messageText == null)
            {
                return new BinaryData(string.Empty);
            }

            switch (messageEncoding)
            {
                case QueueMessageEncoding.None:
                    return new BinaryData(messageText);
                case QueueMessageEncoding.Base64:
                    return new BinaryData(Convert.FromBase64String(messageText));
                default:
                    throw new ArgumentException($"Unsupported message encoding {messageEncoding}", nameof(messageEncoding));
            }
        }
    }
}
