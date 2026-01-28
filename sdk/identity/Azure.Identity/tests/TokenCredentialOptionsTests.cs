// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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

                Assert.That(new Uri(envHostValue), Is.EqualTo(authHost));
            }
        }

        [NonParallelizable]
        [Test]
        public void CustomAuthorityHost()
        {
            string envHostValue = AzureAuthorityHosts.AzureGovernment.ToString();

            using (new TestEnvVar("AZURE_AUTHORITY_HOST", envHostValue))
            {
                Uri customUri = AzureAuthorityHosts.AzureChina;

                TokenCredentialOptions option = new TokenCredentialOptions() { AuthorityHost = customUri };
                Uri authHost = option.AuthorityHost;

                Assert.That(new Uri(envHostValue), Is.Not.EqualTo(authHost));
                Assert.That(customUri, Is.EqualTo(authHost));
            }
        }

        [NonParallelizable]
        [Test]
        public void DefaultAuthorityHost()
        {
            using (new TestEnvVar("AZURE_AUTHORITY_HOST", null))
            {
                TokenCredentialOptions option = new TokenCredentialOptions();

                Assert.That(AzureAuthorityHosts.AzurePublicCloud, Is.EqualTo(option.AuthorityHost));
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
        public void VerifyClone([Values] SupportsInterfaces originalSupportsInterfaces, [Values] SupportsInterfaces cloneSupportsInterfaces, [Values] bool setTransport)
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
                Assert.That(clone.AdditionallyAllowedTenants, Is.EqualTo(original.AdditionallyAllowedTenants).AsCollection);
            }
            else
            {
                Assert.That(clone.AdditionallyAllowedTenants, Is.Not.EqualTo(original.AdditionallyAllowedTenants).AsCollection);
            }

            if (original is ISupportsDisableInstanceDiscovery && clone is ISupportsDisableInstanceDiscovery)
            {
                Assert.That(clone.DisableInstanceDiscovery, Is.EqualTo(original.DisableInstanceDiscovery));
            }
            else
            {
                Assert.That(clone.DisableInstanceDiscovery, Is.Not.EqualTo(original.DisableInstanceDiscovery));
            }

            if (original is ISupportsTokenCachePersistenceOptions && clone is ISupportsTokenCachePersistenceOptions)
            {
                Assert.That(clone.TokenCachePersistenceOptions, Is.EqualTo(original.TokenCachePersistenceOptions));
            }
            else
            {
                Assert.That(clone.TokenCachePersistenceOptions, Is.Not.EqualTo(original.TokenCachePersistenceOptions));
            }

            Assert.That(clone.Transport, Is.EqualTo(original.Transport));

            var isCustomTransportTestProp = typeof(ClientOptions).GetProperty("IsCustomTransportSet", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.That(isCustomTransportTestProp.GetValue(clone), Is.EqualTo(isCustomTransportTestProp.GetValue(original)));

            AssertPublicPropertiesCloned(original.Retry, clone.Retry);

            AssertPublicPropertiesCloned(original.Diagnostics, clone.Diagnostics);
        }

        private void AssertPublicPropertiesCloned<T>(T original, T clone)
        {
            foreach (var propInfo in typeof(T).GetProperties())
            {
                if (propInfo.PropertyType is IEnumerable)
                {
                    Assert.That((IEnumerable)propInfo.GetValue(clone), Is.EqualTo((IEnumerable)propInfo.GetValue(original)).AsCollection);
                }
                else
                {
                    Assert.That(propInfo.GetValue(clone), Is.EqualTo(propInfo.GetValue(original)));
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
                    IsUnsafeSupportLoggingEnabled = true,
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

        // this is a list of ISupports* interfaces that are explicitly supported by TokenCredentialOptions.Clone<T>()
        // do not add any ISupports* types to this list without first adding support to TokenCredentialOptions.Clone<T>()
        // and adding corresponding validation to VerifyClone and VerifyCloneHandlesISupportsForAllTypes
        private static Type[] s_KnownISupportsInterfaces = new Type[]
        {
            typeof(ISupportsAdditionallyAllowedTenants),
            typeof(ISupportsDisableInstanceDiscovery),
            typeof(ISupportsTokenCachePersistenceOptions),
            typeof(ISupportsTenantId)
        };

        public static IEnumerable<TestCaseData> CredentialOptionsCloneTypeTestMatrix()
        {
            var optionsTypes = typeof(TokenCredentialOptions).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(TokenCredentialOptions)) && !t.IsAbstract);

            foreach (var sourceType in optionsTypes)
            {
                foreach (var destinationType in optionsTypes)
                {
                    yield return new TestCaseData(sourceType, destinationType);
                }
            }
        }

        [TestCaseSource(nameof(CredentialOptionsCloneTypeTestMatrix))]
        public void VerifyCloneHandlesISupportsForAllTypes(Type sourceType, Type destinationType)
        {
            // assert that all ISupports* intefaces on the source in the in known interfaces
            var iSupportsInterfaces = sourceType.GetInterfaces().Where(i => i.Name.StartsWith("ISupports"));

            Assert.That(iSupportsInterfaces, Is.SubsetOf(s_KnownISupportsInterfaces));

            // create source instance and set values for all the supported intefaces
            var source = Activator.CreateInstance(sourceType, true);

            if (source is ISupportsAdditionallyAllowedTenants aat)
            {
                aat.AdditionallyAllowedTenants.Add(Guid.NewGuid().ToString());
            }

            if (source is ISupportsDisableInstanceDiscovery did)
            {
                did.DisableInstanceDiscovery = true;
            }

            if (source is ISupportsTokenCachePersistenceOptions tcpo)
            {
                tcpo.TokenCachePersistenceOptions = new TokenCachePersistenceOptions() { Name = Guid.NewGuid().ToString() };
            }

            if (source is ISupportsTenantId sti)
            {
                sti.TenantId = Guid.NewGuid().ToString();
            }

            // clone the source and assert that the correct types is returned and all ISupports* interfaces the cloned type supports have been copied
            var destination = sourceType.GetMethod("Clone", BindingFlags.Instance | BindingFlags.NonPublic).MakeGenericMethod(destinationType).Invoke(source, null);

            Assert.That(destination, Is.Not.Null);

            Assert.That(destination, Is.InstanceOf(destinationType));

            if (source is ISupportsAdditionallyAllowedTenants aatSource && destination is ISupportsAdditionallyAllowedTenants aatDestination)
            {
                Assert.That(aatDestination.AdditionallyAllowedTenants, Is.EqualTo(aatSource.AdditionallyAllowedTenants).AsCollection);
            }

            if (source is ISupportsDisableInstanceDiscovery didSource && destination is ISupportsDisableInstanceDiscovery didDestination)
            {
                Assert.That(didDestination.DisableInstanceDiscovery, Is.EqualTo(didSource.DisableInstanceDiscovery));
            }

            if (source is ISupportsTokenCachePersistenceOptions tcpoSource && destination is ISupportsTokenCachePersistenceOptions tcpoDestination)
            {
                Assert.That(tcpoDestination.TokenCachePersistenceOptions.Name, Is.EqualTo(tcpoSource.TokenCachePersistenceOptions.Name));
                Assert.That(tcpoDestination.TokenCachePersistenceOptions.UnsafeAllowUnencryptedStorage, Is.EqualTo(tcpoSource.TokenCachePersistenceOptions.UnsafeAllowUnencryptedStorage));
            }

            if (source is ISupportsTenantId stiSource && destination is ISupportsTenantId stiDestination)
            {
                Assert.That(stiDestination.TenantId, Is.EqualTo(stiSource.TenantId));
            }
        }
    }
}
