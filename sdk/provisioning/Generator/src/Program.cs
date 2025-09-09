// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Generator.Model;
using Azure.Provisioning.Generator.Specifications;

// Collect all the specs to generate
List<Specification> baselineSpecs =
[
    new ArmSpecification(),
    new ResourcesSpecification(),
    new AuthorizationSpecification(),
    new ManagedServiceIdentitiesSpecification(),
];
List<Specification> rpSpecs =
[
    new AppContainersSpecification(),
    new AppServiceSpecification(),
    new AppConfigurationSpecification(),
    new ApplicationInsightsSpecification(),
    new CommunicationSpecification(),
    new CognitiveServicesSpecification(),
    new ContainerRegistrySpecification(),
    new ContainerServiceSpecification(),
    new CosmosDBSpecification(),
    new EventGridSpecification(),
    new EventHubsSpecification(),
    new KeyVaultSpecification(),
    new KubernetesSpecification(),
    new KubernetesConfigurationSpecification(),
    new KustoSpecification(),
    new NetworkSpecification(),
    new OperationalInsightsSpecification(),
    new PostgreSqlSpecification(),
    new RedisSpecification(),
    new RedisEnterpriseSpecification(),
    new SearchSpecification(),
    new ServiceBusSpecification(),
    new SignalRSpecification(),
    new SqlSpecification(),
    new StorageSpecification(),
    new WebPubSubSpecification(),
];

// Generate the specs
Dictionary<string, string> failures = [];
foreach (Specification spec in baselineSpecs)
{
    try
    {
        Console.WriteLine($"Generating {spec.Name}...");
        spec.Build();
    }
    catch (Exception ex)
    {
        failures[spec.Name] = ex.Message;
    }
}
// defines the filter to be the first argument
string? filter = null;
if (args.Length > 0)
{
    filter = args[0];
    Console.WriteLine($"Filtering to only generate specifications matching '{filter}'");
}
foreach (Specification spec in rpSpecs)
{
    if (filter is not null && spec.Name != filter)
    {
        Console.WriteLine($"Skipping {spec.Name}...");
        continue;
    }
    try
    {
        Console.WriteLine($"Generating {spec.Name}...");
        spec.Build();
    }
    catch (Exception ex)
    {
        failures[spec.Name] = ex.Message;
    }
}
Console.WriteLine("\n\nFinished generating all specifications.\n\n");
if (failures.Count > 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    foreach (KeyValuePair<string, string> failure in failures)
    {
        Console.WriteLine($"{failure.Key}: {failure.Value}");
        Console.WriteLine("\n\n");
    }
}
Console.WriteLine($"{failures.Count} Failure{(failures.Count == 1 ? "" : "s")}.\n");