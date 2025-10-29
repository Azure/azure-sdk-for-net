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

                Assert.AreEqual(authHost, new Uri(envHostValue));
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

            CollectionAssert.IsSubsetOf(iSupportsInterfaces, s_KnownISupportsInterfaces);

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

            Assert.NotNull(destination);

            Assert.IsInstanceOf(destinationType, destination);

            if (source is ISupportsAdditionallyAllowedTenants aatSource && destination is ISupportsAdditionallyAllowedTenants aatDestination)
            {
                CollectionAssert.AreEqual(aatSource.AdditionallyAllowedTenants, aatDestination.AdditionallyAllowedTenants);
            }

            if (source is ISupportsDisableInstanceDiscovery didSource && destination is ISupportsDisableInstanceDiscovery didDestination)
            {
                Assert.AreEqual(didSource.DisableInstanceDiscovery, didDestination.DisableInstanceDiscovery);
            }

            if (source is ISupportsTokenCachePersistenceOptions tcpoSource && destination is ISupportsTokenCachePersistenceOptions tcpoDestination)
            {
                Assert.AreEqual(tcpoSource.TokenCachePersistenceOptions.Name, tcpoDestination.TokenCachePersistenceOptions.Name);
                Assert.AreEqual(tcpoSource.TokenCachePersistenceOptions.UnsafeAllowUnencryptedStorage, tcpoDestination.TokenCachePersistenceOptions.UnsafeAllowUnencryptedStorage);
            }

            if (source is ISupportsTenantId stiSource && destination is ISupportsTenantId stiDestination)
            {
                Assert.AreEqual(stiSource.TenantId, stiDestination.TenantId);
            }
        }
    }
}
