// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.ClientAssertion
{
    internal class ClientAssertionCredentialTests : Tests.ClientAssertionCredentialTests
    {
        private readonly ConfigurableCredentialTestHelper<ClientAssertionCredential> _helper;

        public ClientAssertionCredentialTests(bool isAsync) : base(isAsync)
        {
            _helper = new ConfigurableCredentialTestHelper<ClientAssertionCredential>(
                "ManagedIdentityAsFederatedIdentity",
                null,
                null,
                InstrumentClient);
        }

        private ConfigurableCredential CreateConfiguredCredential(string tenantId = null)
        {
            IConfiguration config = _helper.GetConfiguration();
            if (tenantId != null)
            {
                config["MyClient:Credential:TenantId"] = tenantId;
            }
            config["MyClient:Credential:ClientId"] = ClientId;
            config["MyClient:Credential:AzureCloud"] = "public";
            config["MyClient:Credential:ManagedIdentityIdKind"] = "ClientId";
            config["MyClient:Credential:ManagedIdentityId"] = Guid.NewGuid().ToString();

            ConfigurableCredential credential;
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TENANT_ID", null },
                { "AZURE_CLIENT_ID", null },
            }))
            {
                credential = _helper.GetCredentialFromConfig(config);
            }

            return credential;
        }

        private static void InjectField(ClientAssertionCredential target, string fieldName, object value)
        {
            typeof(ClientAssertionCredential)
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(target, value);
        }

        protected override TokenCredential CreateCredential(string tenantId, string clientId, string assertionValue, ClientAssertionCredentialOptions options)
        {
            // Create credential through the config path (validates config → factory → credential composition)
            var configCredential = CreateConfiguredCredential(tenantId);
            var underlying = _helper.GetUnderlyingCredential(configCredential);

            // Restore pipeline with test transport
            var pipeline = options?.Pipeline ?? CredentialPipeline.GetInstance(options);
            InjectField(underlying, "<Pipeline>k__BackingField", pipeline);

            // Inject MSAL client: use mock from options if provided,
            // otherwise create a real one with simple assertion and test transport
            // (so transport-based CredentialTestBase tests work correctly)
            if (options?.MsalClient != null)
            {
                InjectField(underlying, "<Client>k__BackingField", options.MsalClient);
            }
            else
            {
                MsalConfidentialClient msalClient = IsAsync
                    ? new MsalConfidentialClient(pipeline, tenantId, clientId, (Func<CancellationToken, Task<string>>)((_) => Task.FromResult(assertionValue)), options)
                    : new MsalConfidentialClient(pipeline, tenantId, clientId, (Func<string>)(() => assertionValue), options);
                InjectField(underlying, "<Client>k__BackingField", msalClient);
            }

            return InstrumentClient(configCredential);
        }
    }
}
