// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Azure.Messaging.WebPubSub.Client.Protobuf
{
    /// <summary>
    /// Utils
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// From message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BinaryData ToBinaryData(this IMessage message)
        {
            return BinaryData.FromBytes(Any.Pack(message).ToByteArray());
        }

        /// <summary>
        /// to
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ToProtobufMessage<T>(this BinaryData data) where T : IMessage, new()
        {
            return Any.Parser.ParseFrom(data).Unpack<T>();
        }
    }
}
