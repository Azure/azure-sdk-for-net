// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Media.Tests.ScenarioTests
{
    public class ContentKeyPolicyTests : MediaScenarioTestBase
    {
        [Fact]
        public void ContentKeyPolicyComboTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType().FullName))
            {
                try
                {
                    CreateMediaServicesAccount();

                    // List ContentKeyPolicies, which should be empty
                    var contentKeyPolicies = MediaClient.ContentKeyPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(contentKeyPolicies);

                    string policyName = TestUtilities.GenerateName("ContentKeyPolicy");
                    string policyDescription = "Test policy";

                    // Try to get the policy, which should not exist
                    ContentKeyPolicy contentKeyPolicy = MediaClient.ContentKeyPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.Null(contentKeyPolicy);

                    // Create the policy
                    ContentKeyPolicyOption[] options = new ContentKeyPolicyOption[]
                        {
                            new ContentKeyPolicyOption(new ContentKeyPolicyClearKeyConfiguration(), new ContentKeyPolicyOpenRestriction())
                        };

                    ContentKeyPolicy createdPolicy = MediaClient.ContentKeyPolicies.CreateOrUpdate(ResourceGroup, AccountName, policyName, options, policyDescription);
                    ValidateContentKeyPolicy(createdPolicy, policyName, policyDescription, options);

                    // List ContentKeyPolicies and validate the created policy shows up
                    contentKeyPolicies = MediaClient.ContentKeyPolicies.List(ResourceGroup, AccountName);
                    Assert.Single(contentKeyPolicies);
                    ValidateContentKeyPolicy(createdPolicy, policyName, policyDescription, options);

                    // Get the newly created policy
                    contentKeyPolicy = MediaClient.ContentKeyPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.NotNull(contentKeyPolicy);
                    ValidateContentKeyPolicy(createdPolicy, policyName, policyDescription, options);

                    // Update the policy
                    var primaryVerificationKey = new ContentKeyPolicySymmetricTokenKey(new byte[32]);
                    ContentKeyPolicyOption[] options2 = new ContentKeyPolicyOption[]
                        {
                            new ContentKeyPolicyOption(new ContentKeyPolicyClearKeyConfiguration(), 
                                                       new ContentKeyPolicyTokenRestriction(
                                                           "issuer", 
                                                           "audience", 
                                                           primaryVerificationKey, 
                                                           ContentKeyPolicyRestrictionTokenType.Jwt, 
                                                           requiredClaims: new ContentKeyPolicyTokenClaim[] { ContentKeyPolicyTokenClaim.ContentKeyIdentifierClaim }))
                        };

                    ContentKeyPolicy updatedByPutPolicy = MediaClient.ContentKeyPolicies.CreateOrUpdate(ResourceGroup, AccountName, policyName, options2, policyDescription);
                    ValidateContentKeyPolicy(updatedByPutPolicy, policyName, policyDescription, options2);

                    // List ContentKeyPolicies and validate the updated policy shows up as expected
                    contentKeyPolicies = MediaClient.ContentKeyPolicies.List(ResourceGroup, AccountName);
                    Assert.Single(contentKeyPolicies);
                    ValidateContentKeyPolicy(contentKeyPolicies.First(), policyName, policyDescription, options2);

                    // Get the newly updated policy
                    contentKeyPolicy = MediaClient.ContentKeyPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.NotNull(contentKeyPolicy);
                    ValidateContentKeyPolicy(contentKeyPolicy, policyName, policyDescription, options2);

                    // Delete the policy
                    MediaClient.ContentKeyPolicies.Delete(ResourceGroup, AccountName, policyName);

                    // List ContentKeyPolicies, which should be empty again
                    contentKeyPolicies = MediaClient.ContentKeyPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(contentKeyPolicies);

                    // Try to get the policy, which should not exist
                    contentKeyPolicy = MediaClient.ContentKeyPolicies.Get(ResourceGroup, AccountName, policyName);
                    Assert.Null(contentKeyPolicy);
                }
                finally
                {
                    DeleteMediaServicesAccount();
                }
            }
        }

        internal static void ValidateContentKeyPolicy(ContentKeyPolicy contentKeyPolicy, string expectedName, string expectedDescription, ContentKeyPolicyOption[] expectedOptions)
        {
            Assert.Equal(expectedName, contentKeyPolicy.Name);
            Assert.NotEqual(Guid.Empty, contentKeyPolicy.PolicyId);
            Assert.Equal(expectedDescription, contentKeyPolicy.Description);
            Assert.Equal(expectedOptions.Length, contentKeyPolicy.Options.Count);

            for (int i = 0; i < expectedOptions.Length; i++)
            {
                Assert.Equal(expectedOptions[i].Name, contentKeyPolicy.Options[i].Name);
                Assert.Equal(expectedOptions[i].Configuration.GetType(), contentKeyPolicy.Options[i].Configuration.GetType());
                Assert.Equal(expectedOptions[i].Restriction.GetType(), contentKeyPolicy.Options[i].Restriction.GetType());
                Assert.NotEqual(Guid.Empty, contentKeyPolicy.Options[i].PolicyOptionId);

                if (expectedOptions[i].Restriction.GetType() == typeof(ContentKeyPolicyTokenRestriction))
                {
                    ContentKeyPolicyTokenRestriction expectedOptionRestriction = (ContentKeyPolicyTokenRestriction)expectedOptions[i].Restriction;
                    ContentKeyPolicyTokenRestriction actualOptionRestriction = (ContentKeyPolicyTokenRestriction)contentKeyPolicy.Options[i].Restriction;

                    Assert.Equal(expectedOptionRestriction.Audience, actualOptionRestriction.Audience);
                    Assert.Equal(expectedOptionRestriction.Issuer, actualOptionRestriction.Issuer);
                    Assert.Equal(expectedOptionRestriction.OpenIdConnectDiscoveryDocument, actualOptionRestriction.OpenIdConnectDiscoveryDocument);
                    Assert.Equal(expectedOptionRestriction.RestrictionTokenType, actualOptionRestriction.RestrictionTokenType);
                    Assert.Equal(expectedOptionRestriction.RequiredClaims.Count, actualOptionRestriction.RequiredClaims.Count);

                    for (int x = 0; x < expectedOptionRestriction.RequiredClaims.Count; x++)
                    {
                        Assert.Equal(expectedOptionRestriction.RequiredClaims[x].ClaimType, actualOptionRestriction.RequiredClaims[x].ClaimType);
                        Assert.Equal(expectedOptionRestriction.RequiredClaims[x].ClaimValue, actualOptionRestriction.RequiredClaims[x].ClaimValue);
                    }
                }
            }
        }
    }
}


