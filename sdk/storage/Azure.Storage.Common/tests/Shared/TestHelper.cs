// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Test
{
    static partial class TestHelper
    {
        public static string GetNewMetadataName() => $"test_metadata_{Guid.NewGuid().ToString().Replace("-", "_")}";

        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        static Random Random => random.Value;

        public static byte[] GetRandomBuffer(long size)
        {
            var buffer = new byte[size];
            Random.NextBytes(buffer);
            return buffer;
        }

        public static string GetNewString(int length = 20)
        {
            var buffer = new char[length];

            for (var i = 0; i < length; i++)
            {
                buffer[i] = (char)('a' + Random.Next(0, 25));
            }

            return new string(buffer);
        }
        public static IPAddress GetIPAddress()
        {
            var ipString = $"{Random.Next(0, 256)}.{Random.Next(0, 256)}.{Random.Next(0, 256)}.{Random.Next(0, 256)}";
            return IPAddress.Parse(ipString);
        }

        public static void DoWith<T>(Action<T> action, params T[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"Case: {arg}");
                action(arg);
            }
        }

        public static async Task DoWith<T>(Func<T, Task> action, params T[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"Case: {arg}");
                await action(arg).ConfigureAwait(false);
            }
        }

        public static Metadata BuildMetadata() =>
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "foo", "bar" },
                { "meta", "data" }
            };

        public static async Task<string> GenerateOAuthToken(
            string activeDirectoryAuthEndpoint,
            string activeDirectoryTenantId,
            string activeDirectoryApplicationId,
            string activeDirectoryApplicationSecret)
        {
            var authority = String.Format(activeDirectoryAuthEndpoint + "/" + activeDirectoryTenantId);

            var credential = new ClientCredential(activeDirectoryApplicationId, activeDirectoryApplicationSecret);

            var context = new AuthenticationContext(authority);
            var result = await context.AcquireTokenAsync("https://storage.azure.com", credential);

            return result.AccessToken;
        }

        /// <summary>
        /// Create and configure connection option instances to use a test
        /// specific retry policy and response classifier.
        ///
        /// We're willing to wait longer and make gratuitous retries than our
        /// default connection options for the sake of robust test execution.
        /// </summary>
        /// <typeparam name="T">The type of StorageConnectionOptions.</typeparam>
        /// <param name="credentials">Optional credentials.</param>
        /// <returns>The modified connection options.</returns>
        public static T GetOptions<T>(IStorageCredentials credentials = default)
            where T : StorageConnectionOptions, new()
            =>  new T
                {
                    Credentials = credentials,
                    ResponseClassifier = new TestResponseClassifier(),
                    ConfigurePipeline = policies =>
                    {
                        for (var i = 0; i < policies.Count; i++)
                        {
                            var policy = policies[i];
                            if (policy is FixedRetryPolicy)
                            {
                                policies[i] = new ExponentialRetryPolicy(new ExponentialRetryOptions()
                                {
                                    MaxRetries = Storage.Constants.MaxReliabilityRetries,
                                    Delay = TimeSpan.FromSeconds(0.5),
                                    MaxDelay = TimeSpan.FromSeconds(10)
                                });
                            }
                        }
                    }
                };
    }
}
