// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Triggers;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class MessageToStringConverter : IAsyncConverter<ServiceBusReceivedMessage, string>
    {
        public async Task<string> ConvertAsync(ServiceBusReceivedMessage input, CancellationToken cancellationToken)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var body = input.GetRawAmqpMessage().Body;
            if (body.BodyType == AmqpMessageBodyType.Data)
            {
                if (input.Body == null)
                {
                    return null;
                }

                Stream stream = input.Body.ToStream();

                TextReader reader = new StreamReader(stream, StrictEncodings.Utf8);
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    try
                    {
                        return await reader.ReadToEndAsync().ConfigureAwait(false);
                    }
                    catch (DecoderFallbackException)
                    {
                        // we'll try again below
                    }

                    // We may get here if the message is a string yet was DataContract-serialized when created. We'll
                    // try to deserialize it here using GetBody<string>(). This may fail as well, in which case we'll
                    // provide a decent error.

                    try
                    {
                        var serializer = DataContractBinarySerializer<string>.Instance;
                        stream.Position = 0;
                        return (string) serializer.ReadObject(stream);
                    }
                    catch
                    {
                        // always possible to get a valid string from the message
                        return input.Body.ToString();
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }

                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
            }
            else if (body.BodyType == AmqpMessageBodyType.Value)
            {
                body.TryGetValue(out object value);
                if (value is string stringValue)
                {
                    return stringValue;
                }

                throw new NotSupportedException(
                    $"A message with a body of type {value?.GetType()} cannot be bound to a string.");
            }
            else
            {
                throw new NotSupportedException("A sequence body message cannot be bound to a string.");
            }
        }
    }
}
