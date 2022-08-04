// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;
using TestSchema;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Perf.Scenarios
{
    public class Serialize : SchemaRegistryAvroSerializerPerfTestBase
    {
        private readonly List<Employee> _employees = new();

        public Serialize(SizeCountOptions options) : base(options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                _employees.Add(new Employee() { Name = "Caketown", Age = 42});
            }
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (Employee employee in _employees)
            {
                Serializer.Serialize(employee, cancellationToken: cancellationToken);
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            foreach (Employee employee in _employees)
            {
                await Serializer.SerializeAsync(employee, cancellationToken: cancellationToken);
            }
        }
    }
}