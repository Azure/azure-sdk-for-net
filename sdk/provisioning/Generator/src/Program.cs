// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Generator.Model;
using Azure.Provisioning.Generator.Specifications;

// Collect all the specs to generate
List<Specification> specs =
[
    // Baseline
    new ArmSpecification(),
    new ResourcesSpecification(),
    new AuthorizationSpecification(),
    new ManagedServiceIdentitiesSpecification(),

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
    // new NetworkSpecification(), // TODO: Resolve bicep serialization issue
    new OperationalInsightsSpecification(),
    new PostgreSqlSpecification(),
    new RedisSpecification(),
    new SearchSpecification(),
    new ServiceBusSpecification(),
    new SignalRSpecification(),
    new SqlSpecification(),
    new StorageSpecification(),
    new WebPubSubSpecification(),
];

// Generate the specs
Dictionary<string, string> failures = [];
foreach (Specification spec in specs)
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
