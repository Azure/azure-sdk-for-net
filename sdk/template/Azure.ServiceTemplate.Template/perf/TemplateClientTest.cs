// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.ServiceTemplate.Template.Perf
{
    public class TemplateClientTest : PerfTest<TemplateClientTest.TemplateClientOptions>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/MiniSecretClientTest.cs to write perf test. */
        // private readonly TemplateClient _miniSecretClient;

        // public MiniSecretClientTest(MiniSecretClientOptions options) : base(options)
        // {
        //     var keyVaultUri = GetEnvironmentVariable("KEYVAULT_URL");
        //     _miniSecretClient = new MiniSecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
        // }

        // public override void Run(CancellationToken cancellationToken)
        // {
        //     // Throttle requests to avoid exceeding service limits
        //     Thread.Sleep(TimeSpan.FromMilliseconds(Options.Delay));

        //     _miniSecretClient.GetSecret(Options.SecretName, cancellationToken);
        // }

        // public override async Task RunAsync(CancellationToken cancellationToken)
        // {
        //     // Throttle requests to avoid exceeding service limits
        //     await Task.Delay(TimeSpan.FromMilliseconds(Options.Delay), cancellationToken);

        //     await _miniSecretClient.GetSecretAsync(Options.SecretName, cancellationToken);
        // }

        // public class MiniSecretClientOptions : PerfOptions
        // {
        //     [Option("secret-name", Default = "TestSecret", HelpText = "Name of secret to get")]
        //     public string SecretName { get; set; }

        //     [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
        //     public int Delay { get; set; }
        // }
    }
}
