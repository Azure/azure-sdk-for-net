// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TokenCredentialOptionsTests : ClientTestBase
    {
        public TokenCredentialOptionsTests(bool isAsync) : base(isAsync)
        {
        }

        [NonParallelizable]
        [Test]
        public void InvalidEnvAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", "mock-env-authority-host"))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.Throws<UriFormatException>(() => { Uri authHost = option.AuthorityHost; });
            }
        }

        [NonParallelizable]
        [Test]
        public void EnvAuthorityHost()
        {
            string envHostValue = AzureAuthorityHosts.AzureChina.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();
                Uri authHost = option.AuthorityHost;

                Assert.AreEqual(authHost, new Uri(envHostValue));
            }
        }

        [NonParallelizable]
        [Test]
        public void CustomAuthorityHost()
        {
            string envHostValue = AzureAuthorityHosts.AzureGermany.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                Uri customUri = AzureAuthorityHosts.AzureChina;

                TokenCredentialOptions option = new TokenCredentialOptions() { AuthorityHost = customUri };
                Uri authHost = option.AuthorityHost;

                Assert.AreNotEqual(authHost, new Uri(envHostValue));
                Assert.AreEqual(authHost, customUri);
            }
        }

        [NonParallelizable]
        [Test]
        public void DefaultAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", null))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.AreEqual(option.AuthorityHost, AzureAuthorityHosts.AzurePublicCloud);
            }
        }

        [Test]
        public void SetAuthorityHostToNonHttpsEndpointThrows()
        {
            TokenCredentialOptions options = new TokenCredentialOptions();

            Assert.Throws<ArgumentException>(() => options.AuthorityHost = new Uri("http://unprotected.login.com"));
        }

        [NonParallelizable]
        [Test]
        public void EnviornmentSpecifiedNonHttpsAuthorityHostFails()
        {
            string tenantId = Guid.NewGuid().ToString();
            string clientId = Guid.NewGuid().ToString();
            string username = Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            var certificatePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", "http://unprotected.login.com"))
            {
                Assert.Throws<ArgumentException>(() => new ClientCertificateCredential(tenantId, clientId, certificatePath, new ClientCertificateCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new ClientSecretCredential(tenantId, clientId, password, new TokenCredentialOptions()));
                Assert.Throws(Is.TypeOf<ArgumentException>().Or.TypeOf<TypeInitializationException>(), () => new DefaultAzureCredential(new DefaultAzureCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new DeviceCodeCredential(new DeviceCodeCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new SharedTokenCacheCredential(new SharedTokenCacheCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions()));
                Assert.Throws<ArgumentException>(() => new UsernamePasswordCredential(tenantId, clientId, username, password, new TokenCredentialOptions()));
            }
        }

        [Test]
        public void VerifyClone([Values]SupportsInterfaces originalSupportsInterfaces, [Values]SupportsInterfaces cloneSupportsInterfaces, [Values]bool setTransport)
        {
            CloneTestOptions original = null;

            switch (originalSupportsInterfaces)
            {
                case SupportsInterfaces.All:
                    original = CloneTestOptions.CreatePopulatedOptions<SupportsAll>(setTransport);
                    break;
                case SupportsInterfaces.AdditionallyAllowedTenants:
                    original = CloneTestOptions.CreatePopulatedOptions<SupportsAdditionallyAllowedTenants>(setTransport);
                    break;
                case SupportsInterfaces.DisableInstanceDiscovery:
                    original = CloneTestOptions.CreatePopulatedOptions<SupportsDisableInstanceDiscovery>(setTransport);
                    break;
                case SupportsInterfaces.TokenCachePersistanceOptions:
                    original = CloneTestOptions.CreatePopulatedOptions<SupportsTokenCachePersistenceOptions>(setTransport);
                    break;
                default:
                    Assert.Fail();
                    break;
            }

            CloneTestOptions clone = null;

            switch (cloneSupportsInterfaces)
            {
                case SupportsInterfaces.All:
                    clone = original.Clone<SupportsAll>();
                    break;
                case SupportsInterfaces.AdditionallyAllowedTenants:
                    clone = original.Clone<SupportsAdditionallyAllowedTenants>();
                    break;
                case SupportsInterfaces.DisableInstanceDiscovery:
                    clone = original.Clone<SupportsDisableInstanceDiscovery>();
                    break;
                case SupportsInterfaces.TokenCachePersistanceOptions:
                    clone = original.Clone<SupportsTokenCachePersistenceOptions>();
                    break;
                default:
                    Assert.Fail();
                    break;
            }

            AssertOptionsCloned(original, clone);
        }

        private void AssertOptionsCloned(CloneTestOptions original, CloneTestOptions clone)
        {
            if (original is ISupportsAdditionallyAllowedTenants && clone is ISupportsAdditionallyAllowedTenants)
            {
                CollectionAssert.AreEqual(original.AdditionallyAllowedTenants, clone.AdditionallyAllowedTenants);
            }
            else
            {
                CollectionAssert.AreNotEqual(original.AdditionallyAllowedTenants, clone.AdditionallyAllowedTenants);
            }

            if (original is ISupportsDisableInstanceDiscovery && clone is ISupportsDisableInstanceDiscovery)
            {
                Assert.AreEqual(original.DisableInstanceDiscovery, clone.DisableInstanceDiscovery);
            }
            else
            {
                Assert.AreNotEqual(original.DisableInstanceDiscovery, clone.DisableInstanceDiscovery);
            }

            if (original is ISupportsTokenCachePersistenceOptions && clone is ISupportsTokenCachePersistenceOptions)
            {
                Assert.AreEqual(original.TokenCachePersistenceOptions, clone.TokenCachePersistenceOptions);
            }
            else
            {
                Assert.AreNotEqual(original.TokenCachePersistenceOptions, clone.TokenCachePersistenceOptions);
            }

            Assert.AreEqual(original.Transport, clone.Transport);

            var isCustomTransportTestProp = typeof(ClientOptions).GetProperty("IsCustomTransportSet", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual(isCustomTransportTestProp.GetValue(original), isCustomTransportTestProp.GetValue(clone));

            AssertPublicPropertiesCloned(original.Retry, clone.Retry);

            AssertPublicPropertiesCloned(original.Diagnostics, clone.Diagnostics);
        }

        private void AssertPublicPropertiesCloned<T>(T original, T clone)
        {
            foreach (var propInfo in typeof(T).GetProperties())
            {
                if (propInfo.PropertyType is IEnumerable)
                {
                    CollectionAssert.AreEqual((IEnumerable)propInfo.GetValue(original), (IEnumerable)propInfo.GetValue(clone));
                }
                else
                {
                    Assert.AreEqual(propInfo.GetValue(original), propInfo.GetValue(clone));
                }
            }
        }

        public enum SupportsInterfaces
        {
            All,
            AdditionallyAllowedTenants,
            DisableInstanceDiscovery,
            TokenCachePersistanceOptions
        }

        public class SupportsAll : CloneTestOptions, ISupportsAdditionallyAllowedTenants, ISupportsDisableInstanceDiscovery, ISupportsTokenCachePersistenceOptions { }

        public class SupportsAdditionallyAllowedTenants : CloneTestOptions, ISupportsAdditionallyAllowedTenants { }

        public class SupportsDisableInstanceDiscovery : CloneTestOptions, ISupportsDisableInstanceDiscovery { }

        public class SupportsTokenCachePersistenceOptions : CloneTestOptions, ISupportsTokenCachePersistenceOptions { }

        public class CloneTestOptions : TokenCredentialOptions
        {
            public IList<string> AdditionallyAllowedTenants { get; } = new List<string>();

            public bool DisableInstanceDiscovery { get; set; }

            public TokenCachePersistenceOptions TokenCachePersistenceOptions { get; set; }

            public static T CreatePopulatedOptions<T>(bool setTransport)
                where T : CloneTestOptions, new()
            {
                T options = new T
                {
                    AdditionallyAllowedTenants = { Guid.NewGuid().ToString() },
                    DisableInstanceDiscovery = true,
                    TokenCachePersistenceOptions = new TokenCachePersistenceOptions(),
                    AuthorityHost = AzureAuthorityHosts.AzureChina,
                    IsLoggingPIIEnabled = true,
                    Retry =
                    {
                        MaxRetries = 15,
                        MaxDelay = TimeSpan.FromSeconds(29),
                        Mode = RetryMode.Fixed,
                        NetworkTimeout = TimeSpan.FromSeconds(13)
                    },
                    Diagnostics =
                    {
                        ApplicationId = Guid.NewGuid().ToString().Substring(0, 20),
                        IsLoggingEnabled = false,
                        IsLoggingContentEnabled = false,
                        IsTelemetryEnabled = true,
                        IsAccountIdentifierLoggingEnabled = true,
                        LoggedContentSizeLimit = 313,
                        LoggedHeaderNames = { Guid.NewGuid().ToString() },
                        LoggedQueryParameters = { Guid.NewGuid().ToString() }
                    }
                };

                if (setTransport)
                {
                    options.Transport = new HttpClientTransport(new HttpClient());
                }

                return options;
            }
        }
    }
}
