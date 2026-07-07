// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DevelopmentBrokerOptionsTests
    {
        [Test]
        public void TryCreateDevelopmentBrokerOptions()
        {
            bool success = DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var options);
            Assert.IsTrue(success, "Failed to create DevelopmentBrokerOptions.");
            Assert.IsNotNull(options, "DevelopmentBrokerOptions is null.");
        }

        [Test]
        public void TryCreateDevelopmentBrokerOptionsFromCredentialFactory()
        {
            var factory = new DefaultAzureCredentialFactory(new DefaultAzureCredentialOptions());
            var cred = factory.CreateBrokerCredential();
            try
            {
                cred.GetToken(new TokenRequestContext(new[] { "https://management.azure.com/.default" }), default);
            }
            catch (CredentialUnavailableException)
            {
                // This is expected, as the broker is not available in the test environment.
            }
        }

        [Test]
        public void CopyMsalSettableProperties_CopiesFromDefaultAzureCredentialOptions()
        {
            var source = new DefaultAzureCredentialOptions();
            source.IsLegacyMsaPassthroughEnabled = true;

            Assert.IsTrue(DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var target));
            target.CopyMsalSettableProperties(source);

            Assert.AreEqual(true, GetIsLegacyMsaPassthroughEnabled(target));
        }

        [Test]
        public void CopyMsalSettableProperties_CopiesFalseFromDefaultAzureCredentialOptions()
        {
            var source = new DefaultAzureCredentialOptions();
            source.IsLegacyMsaPassthroughEnabled = false;

            Assert.IsTrue(DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var target));
            target.CopyMsalSettableProperties(source);

            Assert.AreEqual(false, GetIsLegacyMsaPassthroughEnabled(target));
        }

        [Test]
        public void CopyMsalSettableProperties_DoesNotOverwriteWhenSourceHasNoValue()
        {
            var source = new InteractiveBrowserCredentialOptions();

            Assert.IsTrue(DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var target));
            // Set a value on the target before copying
            target.GetType().GetProperty("IsLegacyMsaPassthroughEnabled").SetValue(target, true);

            target.CopyMsalSettableProperties(source);

            Assert.AreEqual(true, GetIsLegacyMsaPassthroughEnabled(target));
        }

        [Test]
        public void CopyMsalSettableProperties_CopiesFromDevelopmentBrokerOptions()
        {
            Assert.IsTrue(DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var source));
            Assert.IsTrue(DefaultAzureCredentialFactory.TryCreateDevelopmentBrokerOptions(out var target));

            source.GetType().GetProperty("IsLegacyMsaPassthroughEnabled").SetValue(source, true);

            target.CopyMsalSettableProperties(source);

            Assert.AreEqual(true, GetIsLegacyMsaPassthroughEnabled(target));
        }

        private static bool? GetIsLegacyMsaPassthroughEnabled(InteractiveBrowserCredentialOptions options)
        {
            return (bool?)options.GetType().GetProperty("IsLegacyMsaPassthroughEnabled")?.GetValue(options);
        }
    }
}
