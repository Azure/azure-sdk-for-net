// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientLiveTestVersionTests
    {
        [TestCase(CertificateClientOptions.ServiceVersion.V7_0, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_1, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_2, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_3, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_4, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_5, false)]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_6, true)]
        [TestCase(CertificateClientOptions.ServiceVersion.V2025_07_01, true)]
        [TestCase(CertificateClientOptions.ServiceVersion.V2026_03_01_Preview, true)]
        [TestCase(CertificateClientOptions.ServiceVersion.V2026_04_01, true)]
        public void PreserveCertificateOrderUsesSupportedServiceVersions(
            CertificateClientOptions.ServiceVersion serviceVersion, bool supported)
        {
            ClientTestFixtureAttribute fixtureBuilder = new ClientTestFixtureAttribute(serviceVersion);
            TestSuite[] fixtures = fixtureBuilder.BuildFrom(new TypeWrapper(typeof(CertificateClientLiveTests))).ToArray();

            Assert.AreEqual(2, fixtures.Length, "Both sync and async fixtures must be covered.");
            foreach (TestSuite fixture in fixtures)
            {
                Assert.That(fixture.Tests.Single(test => test.Name == nameof(CertificateClientLiveTests.StartCreateCertificateError)).RunState,
                    Is.EqualTo(RunState.Runnable), "Existing certificate coverage must remain available on every service version.");

                foreach (string testName in new[]
                {
                    nameof(CertificateClientLiveTests.StartCreateCertificateWithPreserveCertificateOrder),
                    nameof(CertificateClientLiveTests.ImportCertificateWithPreserveCertificateOrder),
                })
                {
                    TestSuite test = fixture.Tests.OfType<TestSuite>().SingleOrDefault(test => test.Name == testName);
                    if (supported)
                    {
                        Assert.NotNull(test, $"{fixture.Name}.{testName}");
                        Assert.That(test.Tests.Select(test => test.Arguments[0]), Is.EquivalentTo(new[] { true, false }));
                        Assert.That(test.Tests.Select(test => test.RunState), Is.All.EqualTo(RunState.Runnable));
                    }
                    else
                    {
                        Assert.IsNull(test, $"{fixture.Name}.{testName} requires API version 7.6 or later.");
                    }
                }
            }
        }
    }
}
