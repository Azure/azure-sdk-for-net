// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.Provisioning.Generator.Specifications;
using CommandLine;
using System;
using System.Collections.Generic;

namespace Generator;

internal static class Program
{
    public static int Main(string[] args)
    {
        return Parser.Default.ParseArguments<GenerateOptions>(args)
            .MapResult(
                Generate,
                errs => 1);
    }

    private static int Generate(GenerateOptions options)
    {
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
            //new DnsSpecification(), // the Dns's mgmt SDK is majority hand-crafted, therefore here we just use this to generate a scaffold, and then hand-craft the rest.
            new EventGridSpecification(),
            new EventHubsSpecification(),
            new FrontDoorSpecification(),
            new KeyVaultSpecification(),
            new KubernetesSpecification(),
            new KubernetesConfigurationSpecification(),
            new KustoSpecification(),
            new NetworkSpecification(),
            new OperationalInsightsSpecification(),
            new PostgreSqlSpecification(),
            //new PrivateDnsSpecification(), // the Dns's mgmt SDK is majority hand-crafted, therefore here we just use this to generate a scaffold, and then hand-craft the rest.
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
            spec.ShouldGenerateSchema = options.GenerateSchema;
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
        string? filter = options.Filter;
        if (filter is not null)
        {
            Console.WriteLine($"Filtering to only generate specifications matching '{filter}'");
        }
        foreach (Specification spec in rpSpecs)
        {
            if (filter is not null && spec.Name != filter)
            {
                Console.WriteLine($"Skipping {spec.Name}...");
                continue;
            }
            spec.ShouldGenerateSchema = options.GenerateSchema;
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

        return failures.Count == 0 ? 0 : 1;
    }
}
