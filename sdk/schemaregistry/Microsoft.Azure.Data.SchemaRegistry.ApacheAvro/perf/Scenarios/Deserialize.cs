// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging;
using Azure.Test.Perf;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Perf.Scenarios
{
    public class Deserialize : SchemaRegistryAvroSerializerPerfTestBase
    {
        private readonly List<MessageContent> _serializedData = new();
        public Deserialize(SizeCountOptions options) : base(options)
        {
            var employee = new Employee() { Name = "Caketown", Age = 42 };
            for (int i = 0; i < options.Count; i++)
            {
                _serializedData.Add(Serializer.Serialize(employee));
            }
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (MessageContent message in _serializedData)
            {
                Serializer.Deserialize<Employee>(message, cancellationToken: cancellationToken);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            foreach (MessageContent message in _serializedData)
            {
                await Serializer.DeserializeAsync<Employee>(message, cancellationToken: cancellationToken);
            }
        }
    }
}