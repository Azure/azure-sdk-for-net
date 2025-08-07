// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    //<packet type>[<# of binary attachments>-][<namespace>,][<acknowledgment id>][JSON-stringified payload without binary]
    internal class SocketIOProtocol
    {
        public static string EncodePacket(SocketIOPacket packet)
        {
            var sb = new StringBuilder();
            sb.Append(packet.Type.ToString("D"));

            // if we have a namespace other than `/`
            // we append it followed by a comma `,`
            if (packet.Namespace != "/")
            {
                sb.Append(packet.Namespace);
                sb.Append(",");
            }

            // immediately followed by the id
            if (packet.Id != null)
            {
                sb.Append(packet.Id.ToString());
            }

            // json data
            sb.Append(packet.Data);
            return sb.ToString();
        }

        public static SocketIOPacket DecodePacket(string payload)
        {
            var typeChar = payload[0];
            var type = (SocketIOPacketType)int.Parse(typeChar.ToString());

            var index = 1;
            var attachmentCount = 0;
            if (type == SocketIOPacketType.BinaryEvent ||
                type == SocketIOPacketType.BinaryAck)
            {
                var hyphenIndex = payload.IndexOf('-', 1);
                if (hyphenIndex == -1)
                {
                    throw new InvalidDataException("Invalid packet");
                }

                attachmentCount = int.Parse(payload.Substring(1, hyphenIndex - 1));
                index = hyphenIndex + 1;
            }

            var @namespace = "/";
            if (index < payload.Length && payload[index] == '/')
            {
                // has namespace
                var commaIndex = payload.IndexOf(',', index + 1);
                if (commaIndex == -1)
                {
                    commaIndex = payload.Length;
                }
                @namespace = payload.Substring(index, commaIndex - index);
                index = commaIndex + 1;
            }

            int? id = null;
            // look up id
            if (index < payload.Length && char.IsNumber(payload[index]))
            {
                var startIndex = index;
                while (index < payload.Length && char.IsNumber(payload[index]))
                {
                    index++;
                }
                id = int.Parse(payload.Substring(startIndex, index - startIndex));
            }

            var data = string.Empty;
            if (index < payload.Length)
            {
                data = payload.Substring(index);
            }

            return new SocketIOPacket(type, @namespace, data) { Id = id };
        }

        public static (string EventName, IList<object> Arguments) ParseData(string data)
        {
            var parsedData = JsonConvert.DeserializeObject<IList<object>>(data);
            if (parsedData.Count == 0)
            {
                throw new InvalidDataException();
            }

            var eventName = parsedData[0].ToString();
            IList<object> arguments = null;

            if (parsedData.Count > 1)
            {
                arguments = parsedData.Skip(1).ToList();
            }

            return (eventName, arguments);
        }
    }
}
