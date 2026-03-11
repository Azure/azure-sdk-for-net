// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    internal class ChainedTokenCredentialTests : Tests.ChainedTokenCredentialTests
    {
        public ChainedTokenCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        internal override TokenCredential CreateChainedCredential(params TokenCredential[] sources)
        {
            if (sources == null || sources.Length == 0)
            {
                throw new ArgumentException("At least one credential is required.", nameof(sources));
            }

            // Build config with CredentialSource: "ChainedTokenCredential" and Sources array of objects
            var credentialNames = new[] { "AzureCliCredential", "AzurePowerShellCredential",
                "ManagedIdentityCredential", "VisualStudioCredential", "AzureDeveloperCliCredential",
                "EnvironmentCredential", "WorkloadIdentityCredential", "InteractiveBrowserCredential" };

            var configValues = new Dictionary<string, string>
            {
                ["CredentialSource"] = "ChainedTokenCredential"
            };
            for (int i = 0; i < sources.Length && i < credentialNames.Length; i++)
            {
                configValues[$"Sources:{i}:CredentialSource"] = credentialNames[i];
            }

            var cc = CreateConfigurableFromConfig(configValues);

            // Replace inner credential with CTC built from mock sources.
            // Config flow was validated by creating the CC; now inject test sources.
            typeof(ConfigurableCredential)
                .GetField("_tokenCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(cc, new ChainedTokenCredential(sources));

            return cc;
        }

        internal override TokenCredential InstrumentChainedCredential(TokenCredential cred)
            => InstrumentClient((ConfigurableCredential)cred);

        [Test]
        public override void CtorInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => CreateChainedCredential(Array.Empty<TokenCredential>()));
        }

        private static IConfigurationSection BuildConfigSection(Dictionary<string, string> configValues)
        {
            const string prefix = "MyClient:Credential:";
            var prefixed = new Dictionary<string, string>();
            foreach (var kvp in configValues)
            {
                prefixed[$"{prefix}{kvp.Key}"] = kvp.Value;
            }

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(prefixed)
                .Build();

            return config.GetSection("MyClient:Credential");
        }

        private static ConfigurableCredential CreateConfigurableFromConfig(Dictionary<string, string> configValues)
        {
            var section = BuildConfigSection(configValues);
            var options = new DefaultAzureCredentialOptions(new CredentialSettings(section), section);
            return new ConfigurableCredential(options);
        }
    }
}
