// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;
using MtlsBindingStrength = Microsoft.Identity.Client.AppConfig.MtlsBindingStrength;

namespace Azure.Core.Tests.Identity
{
    public class MsalManagedIdentityClientReflectionTests
    {
        [Test]
        public void TryCreateWithAttestationSupport_DoesNotThrow_AndReturnsConsistentResult()
        {
            Assert.DoesNotThrow(() =>
            {
                bool success = MsalManagedIdentityClient.TryCreateWithAttestationSupport(out Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> withAttestationSupport);

                if (success)
                {
                    Assert.NotNull(withAttestationSupport, "Delegate must be non-null when reflection contract resolves successfully.");
                }
                else
                {
                    Assert.IsNull(withAttestationSupport, "Delegate must be null when reflection contract is unavailable.");
                }
            });
        }

        [TestCase(false, true, true, true)]
        [TestCase(false, false, true, false)]
        [TestCase(false, true, false, false)]
        [TestCase(true, true, true, false)]
        public void ShouldAttemptMtlsPopHonorsCallerIntentAndOptOut(
            bool disableMtlsProofOfPossession,
            bool isProofOfPossessionEnabled,
            bool isTokenBindingAvailable,
            bool expected)
        {
            var client = new MsalManagedIdentityClient(
                new ManagedIdentityClientOptions
                {
                    ManagedIdentityId = ManagedIdentityId.SystemAssigned,
                    DisableMtlsProofOfPossession = disableMtlsProofOfPossession
                });
            var context = new TokenRequestContext(
                MockScopes.Default,
                isProofOfPossessionEnabled: isProofOfPossessionEnabled);

            Assert.AreEqual(expected, client.ShouldAttemptMtlsPop(context, isTokenBindingAvailable));
        }

        [Test]
        public void ConfigureMtlsPopWithoutAttestationSupportLeavesBearerRequest()
        {
            AcquireTokenForManagedIdentityParameterBuilder builder = CreateTokenBuilder();

            AcquireTokenForManagedIdentityParameterBuilder configuredBuilder =
                MsalManagedIdentityClient.ConfigureMtlsPop(builder, withAttestationSupport: null);

            Assert.AreSame(builder, configuredBuilder);
            Assert.IsFalse(GetCommonParameter<bool>(configuredBuilder, "IsMtlsPopRequested"));
            Assert.AreEqual(MtlsBindingStrength.None, GetCommonParameter<MtlsBindingStrength>(configuredBuilder, "MtlsPopMinStrength"));
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)]
#if NETFRAMEWORK
        [Ignore("Managed identity mTLS proof-of-possession is not supported on .NET Framework.")]
#endif
        public void ConfigureMtlsPopRequiresKeyGuardBeforeAttestation()
        {
            AcquireTokenForManagedIdentityParameterBuilder builder = CreateTokenBuilder();
            bool attestationConfigured = false;

            AcquireTokenForManagedIdentityParameterBuilder configuredBuilder =
                MsalManagedIdentityClient.ConfigureMtlsPop(
                    builder,
                    candidate =>
                    {
                        Assert.IsTrue(GetCommonParameter<bool>(candidate, "IsMtlsPopRequested"));
                        Assert.AreEqual(MtlsBindingStrength.KeyGuard, GetCommonParameter<MtlsBindingStrength>(candidate, "MtlsPopMinStrength"));
                        attestationConfigured = true;
                        return candidate;
                    });

            Assert.AreSame(builder, configuredBuilder);
            Assert.IsTrue(attestationConfigured);
        }

        private static AcquireTokenForManagedIdentityParameterBuilder CreateTokenBuilder()
        {
            IManagedIdentityApplication application = ManagedIdentityApplicationBuilder
                .Create(Microsoft.Identity.Client.AppConfig.ManagedIdentityId.SystemAssigned)
                .Build();
            return application.AcquireTokenForManagedIdentity("https://vault.azure.net/.default");
        }

        private static T GetCommonParameter<T>(AcquireTokenForManagedIdentityParameterBuilder builder, string propertyName)
        {
            Type type = builder.GetType();
            PropertyInfo commonParametersProperty = null;
            while (type != null && commonParametersProperty == null)
            {
                commonParametersProperty = type.GetProperty("CommonParameters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                type = type.BaseType;
            }

            Assert.NotNull(commonParametersProperty);
            object commonParameters = commonParametersProperty.GetValue(builder);
            PropertyInfo property = commonParameters.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.NotNull(property);
            return (T)property.GetValue(commonParameters);
        }
    }
}
