// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class StreamingPolicyTests : MediaScenarioTestBase
    {
        [Fact]
        public void StreamingPolicyComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List StreamingPolicies, which should only contain the predefined policies
                    var policies = MediaClient.StreamingPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(policies.Where(p => !p.Name.StartsWith("Predefined_")));

                    string policyName = TestUtilities.GenerateName("StreamingPolicy");

                    // Get the StreamingPolicy, which should not exist
                    StreamingPolicy policy = MediaClient.StreamingPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.Null(policy);

                    // Create a new StreamingPolicy
                    string defaultContentKeyPolicyName = null;
                    CommonEncryptionCbcs commonEncryptionCbcs = null;
                    CommonEncryptionCenc commonEncryptionCenc = null;
                    EnvelopeEncryption envelopeEncryption = new EnvelopeEncryption(enabledProtocols: new EnabledProtocols(false, false, true, false));
                    NoEncryption noEncryption = null;
                    var input = new StreamingPolicy(envelopeEncryption: envelopeEncryption);
                    StreamingPolicy createdPolicy = MediaClient.StreamingPolicies.Create(ResourceGroup, AccountName, policyName, input);
                    ValidateStreamingPolicy(createdPolicy, policyName, defaultContentKeyPolicyName, commonEncryptionCbcs, commonEncryptionCenc, envelopeEncryption, noEncryption);

                    // List StreamingPolicies and validate the newly created one shows up
                    policies = MediaClient.StreamingPolicies.List(ResourceGroup, AccountName);
                    policy = policies.Where(p => !p.Name.StartsWith("Predefined_")).First();
                    ValidateStreamingPolicy(policy, policyName, defaultContentKeyPolicyName, commonEncryptionCbcs, commonEncryptionCenc, envelopeEncryption, noEncryption);

                    // Get the newly created StreamingPolicy
                    policy = MediaClient.StreamingPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.NotNull(policy);
                    ValidateStreamingPolicy(policy, policyName, defaultContentKeyPolicyName, commonEncryptionCbcs, commonEncryptionCenc, envelopeEncryption, noEncryption);

                    // Delete the StreamingPolicy
                    MediaClient.StreamingPolicies.Delete(ResourceGroup, AccountName, policyName);

                    // List StreamingPolicies, which should only contain the predefined policies
                    policies = MediaClient.StreamingPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(policies.Where(p => !p.Name.StartsWith("Predefined_")));

                    // Get the StreamingPolicy, which should not exist
                    policy = MediaClient.StreamingPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.Null(policy);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateStreamingPolicy(
            StreamingPolicy policy, 
            string expectedName, 
            string expectedDefaultContentKeyPolicyName,
            CommonEncryptionCbcs expectedCommonEncryptionCbcs,
            CommonEncryptionCenc expectedCommonEncryptionCenc,
            EnvelopeEncryption expectedEnvelopeEncryption,
            NoEncryption expectedNoEncryption)
        {
            Assert.Equal(expectedName, policy.Name);
            Assert.Equal(expectedDefaultContentKeyPolicyName, policy.DefaultContentKeyPolicyName);
            Assert.False(string.IsNullOrEmpty(policy.Id));

            if (expectedCommonEncryptionCbcs == null)
            {
                Assert.Null(policy.CommonEncryptionCbcs);
            }
            else
            {
                ValidateEnabledProtocols(expectedCommonEncryptionCbcs.EnabledProtocols, policy.CommonEncryptionCbcs.EnabledProtocols);
            }

            if (expectedCommonEncryptionCenc == null)
            {
                Assert.Null(policy.CommonEncryptionCenc);
            }
            else
            {
                ValidateEnabledProtocols(expectedCommonEncryptionCenc.EnabledProtocols, policy.CommonEncryptionCenc.EnabledProtocols);
            }

            if (expectedEnvelopeEncryption == null)
            {
                Assert.Null(policy.EnvelopeEncryption);
            }
            else
            {
                ValidateEnabledProtocols(expectedEnvelopeEncryption.EnabledProtocols, policy.EnvelopeEncryption.EnabledProtocols);
            }

            if (expectedNoEncryption == null)
            {
                Assert.Null(policy.NoEncryption);
            }
            else
            {
                ValidateEnabledProtocols(expectedNoEncryption.EnabledProtocols, policy.NoEncryption.EnabledProtocols);
            }
        }

        internal static void ValidateEnabledProtocols(EnabledProtocols expected, EnabledProtocols actual)
        {
            Assert.Equal(expected.Dash, actual.Dash);
            Assert.Equal(expected.Download, actual.Download);
            Assert.Equal(expected.Hls, actual.Hls);
            Assert.Equal(expected.SmoothStreaming, actual.SmoothStreaming);
        }
    }
}
