// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Stress;
using CommandLine;
using Azure.Template.Models;

namespace Azure.Template.Stress
{
    public class TemplateClientTest : StressTest<TemplateClientTest.TemplateClientStressOptions, TemplateClientTest.TemplateClientStressMetrics>
    {
        public TemplateClientTest(TemplateClientStressOptions options, TemplateClientStressMetrics metrics) : base(options, metrics)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            string keyVaultUri = GetEnvironmentVariable("KEYVAULT_URL");
            TemplateClient client = new TemplateClient(keyVaultUri, new DefaultAzureCredential());

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Throttle requests to avoid exceeding service limits
                    await Task.Delay(TimeSpan.FromMilliseconds(Options.Delay), cancellationToken);

                    Response<SecretBundle> secret = await client.GetSecretValueAsync(Options.SecretName, cancellationToken);
                    Interlocked.Increment(ref Metrics.SecretsReceived);

                    if (secret.Value.Value == "TestValue")
                    {
                        Interlocked.Increment(ref Metrics.CorrectValues);
                    }
                    else
                    {
                        Interlocked.Increment(ref Metrics.IncorrectValues);
                    }
                }
                catch (Exception e) when (ContainsOperationCanceledException(e))
                {
                }
                catch (Exception e)
                {
                    Metrics.Exceptions.Enqueue(e);
                }
            }
        }

        public class TemplateClientStressMetrics : StressMetrics
        {
            public long SecretsReceived;
            public long CorrectValues;
            public long IncorrectValues;
        }

        public class TemplateClientStressOptions : StressOptions
        {
            [Option("secret-name", Default = "TestSecret", HelpText = "Name of secret to get")]
            public string SecretName { get; set; }

            [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
            public int Delay { get; set; }
        }
    }
}
