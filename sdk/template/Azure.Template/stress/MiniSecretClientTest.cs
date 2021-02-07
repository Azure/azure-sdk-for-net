// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Test.Stress;
using CommandLine;

namespace Azure.Template.Stress
{
    public class MiniSecretClientTest : StressTest<MiniSecretClientTest.MiniSecretClientOptions, MiniSecretClientTest.MiniSecretClientMetrics>
    {
        public MiniSecretClientTest(MiniSecretClientOptions options, MiniSecretClientMetrics metrics) : base(options, metrics)
        {
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            var keyVaultUri = GetEnvironmentVariable("KEYVAULT_URL");
            var client = new MiniSecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Throttle requests to avoid exceeding service limits
                    await Task.Delay(TimeSpan.FromMilliseconds(Options.Delay), cancellationToken);

                    var secret = await client.GetSecretAsync(Options.SecretName, cancellationToken);
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

        public class MiniSecretClientMetrics : StressMetrics
        {
            public long SecretsReceived;
            public long CorrectValues;
            public long IncorrectValues;
        }

        public class MiniSecretClientOptions : StressOptions
        {
            [Option("secret-name", Default = "TestSecret", HelpText = "Name of secret to get")]
            public string SecretName { get; set; }

            [Option("delay", Default = 100, HelpText = "Delay between gets (milliseconds)")]
            public int Delay { get; set; }
        }
    }
}
