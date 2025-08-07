// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Amqp.Shared;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusGrpcEndToEndTestsBase : WebJobsServiceBusTestBase
    {
        public ServiceBusGrpcEndToEndTestsBase(bool isSession) : base(isSession)
        {
        }

        public static ByteString EncodeDictionary(IDictionary<string, object> dictionary)
        {
            var map = new AmqpMap();
            foreach (KeyValuePair<string, object> kvp in dictionary)
            {
                AmqpAnnotatedMessageConverter.TryCreateAmqpPropertyValueFromNetProperty(kvp.Value, out var amqpValue);
                map.Add(new MapKey(kvp.Key), amqpValue);
            }
            using ByteBuffer buffer = new ByteBuffer(256, true);
            AmqpCodec.EncodeMap(map, buffer);
            return ByteString.CopyFrom(buffer.Buffer, 0, buffer.Length);
        }

        internal class MockServerCallContext : ServerCallContext
        {
            protected override Task WriteResponseHeadersAsyncCore(Metadata responseHeaders)
            {
                throw new NotImplementedException();
            }

            protected override ContextPropagationToken CreatePropagationTokenCore(ContextPropagationOptions options)
            {
                throw new NotImplementedException();
            }

            protected override string MethodCore { get; }
            protected override string HostCore { get; }
            protected override string PeerCore { get; }
            protected override DateTime DeadlineCore { get; }
            protected override Metadata RequestHeadersCore { get; }
            protected override CancellationToken CancellationTokenCore { get; } = CancellationToken.None;
            protected override Metadata ResponseTrailersCore { get; }
            protected override Status StatusCore { get; set; }
            protected override WriteOptions WriteOptionsCore { get; set; }
            protected override AuthContext AuthContextCore { get; }
        }
    }
}
#endif