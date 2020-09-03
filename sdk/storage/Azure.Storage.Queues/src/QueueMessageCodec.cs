// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Queues
{
    internal class QueueMessageCodec
    {
        public static string EncodeMessageBody(BinaryData? binaryData, QueueMessageEncoding messageEncoding)
        {
            if (!binaryData.HasValue)
            {
                return null;
            }
            switch (messageEncoding)
            {
                case QueueMessageEncoding.UTF8:
                    return binaryData.Value.ToString();
                case QueueMessageEncoding.Base64:
                    return Convert.ToBase64String(binaryData.Value.Bytes.ToArray());
                default:
                    throw new ArgumentException($"Unsupported message encoding {messageEncoding}");
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
                case QueueMessageEncoding.UTF8:
                    return new BinaryData(messageText);
                case QueueMessageEncoding.Base64:
                    return new BinaryData(Convert.FromBase64String(messageText));
                default:
                    throw new ArgumentException($"Unsupported message encoding {messageEncoding}");
            }
        }
    }
}
