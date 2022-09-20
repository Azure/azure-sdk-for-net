// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Template.Perf
{
    public class TemplateClientTest : PerfTest<TemplateClientTest.TemplateClientPerfOptions>
    {
        private readonly TemplateClient _templateClient;

        public TemplateClientTest(TemplateClientPerfOptions options) : base(options)
        {
            string keyVaultUri = GetEnvironmentVariable("KEYVAULT_URL");
            _templateClient = new TemplateClient(keyVaultUri, new DefaultAzureCredential());
        }

        public override void Run(CancellationToken cancellationToken)
        {
            // Throttle requests to avoid exceeding service limits
            Thread.Sleep(TimeSpan.FromMilliseconds(Options.Delay));

            _templateClient.GetSecretValue(Options.SecretName, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            // Throttle requests to avoid exceeding service limits
            await Task.Delay(TimeSpan.FromMilliseconds(Options.Delay), cancellationToken);

            await _templateClient.GetSecretValueAsync(Options.SecretName, cancellationToken);
        }

        public class TemplateClientPerfOptions : PerfOptions
        {
            [Option("secret-name", Default = "TestSecret", HelpText = "Name of secret to get")]
            public string SecretName { get; set; }

            [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
            public int Delay { get; set; }
        }
    }
}
