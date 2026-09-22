// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core.Pipeline;
using Azure.Identity;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MtlsProofOfPossessionApiTests
    {
        [TestCaseSource(nameof(GetApiMembers))]
        public void ApiIsNotExperimental(MemberInfo member)
        {
            Assert.IsNotNull(member);
            Assert.IsFalse(member.GetCustomAttributesData().Any(attribute =>
                attribute.AttributeType.FullName == "System.Diagnostics.CodeAnalysis.ExperimentalAttribute"),
                $"{member.DeclaringType.Name}.{member.Name} should not be experimental.");
        }

        [Test]
        public void ConstructorsAcceptTransportOptions()
        {
            var credential = Mock.Of<TokenCredential>();
            var options = new HttpPipelineTransportOptions();

            Assert.DoesNotThrow(() => new BearerTokenAuthenticationPolicy(credential, "scope", options));
            Assert.DoesNotThrow(() => new BearerTokenAuthenticationPolicy(credential, new[] { "scope" }, options));
        }

        [Test]
        public void TransportOptionsChangedSupportsSubscriptionAndUnsubscription()
        {
            var options = new HttpPipelineTransportOptions();
            var policy = new TransportUpdatingPolicy(Mock.Of<TokenCredential>(), options);
            HttpPipelineTransportOptions receivedOptions = null;
            Action<HttpPipelineTransportOptions> handler = updatedOptions => receivedOptions = updatedOptions;

            policy.TransportOptionsChanged += handler;
            policy.UpdateTransportOptions(options);

            Assert.AreSame(options, receivedOptions);

            policy.TransportOptionsChanged -= handler;
            receivedOptions = null;
            policy.UpdateTransportOptions(options);

            Assert.IsNull(receivedOptions);
        }

        [Test]
        public void ManagedIdentityMtlsOptOutDefaultsToFalseAndCanBeSet()
        {
            var options = new ManagedIdentityCredentialOptions();

            Assert.IsFalse(options.DisableMtlsProofOfPossession);

            options.DisableMtlsProofOfPossession = true;

            Assert.IsTrue(options.DisableMtlsProofOfPossession);
        }

        private static IEnumerable<MemberInfo> GetApiMembers()
        {
            Type policyType = typeof(BearerTokenAuthenticationPolicy);
            yield return policyType.GetConstructor(new[] { typeof(TokenCredential), typeof(string), typeof(HttpPipelineTransportOptions) });
            yield return policyType.GetConstructor(new[] { typeof(TokenCredential), typeof(IEnumerable<string>), typeof(HttpPipelineTransportOptions) });
            yield return policyType.GetEvent(nameof(BearerTokenAuthenticationPolicy.TransportOptionsChanged));
            yield return policyType.GetMethod("OnTransportOptionsChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            yield return typeof(ManagedIdentityCredentialOptions).GetProperty(nameof(ManagedIdentityCredentialOptions.DisableMtlsProofOfPossession));
        }

        private sealed class TransportUpdatingPolicy : BearerTokenAuthenticationPolicy
        {
            public TransportUpdatingPolicy(TokenCredential credential, HttpPipelineTransportOptions options)
                : base(credential, "scope", options)
            {
            }

            public void UpdateTransportOptions(HttpPipelineTransportOptions options)
            {
                OnTransportOptionsChanged(options);
            }
        }
    }
}
