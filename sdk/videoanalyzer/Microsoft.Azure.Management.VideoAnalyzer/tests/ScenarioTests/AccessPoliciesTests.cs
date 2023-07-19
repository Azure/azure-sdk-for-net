// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using VideoAnalyzer.Tests.Helpers;
using Microsoft.Azure.Management.VideoAnalyzer;
using Microsoft.Azure.Management.VideoAnalyzer.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace VideoAnalyzer.Tests.ScenarioTests
{
    public class AccessPoliciesTest : VideoAnalyzerTestBase
    {
        [Fact]
        public void AccessPoliciesLifeCycleTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateVideoAnalyzerAccount();

                    var accessPoliies = VideoAnalyzerClient.AccessPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(accessPoliies);

                    var accessPolicyName = TestUtilities.GenerateName("ap");

                    var a = new JwtAuthentication()
                    {
                        Audiences = new List<string>() { "testAudience" }
                    };
                    var aa = a.Audiences;

                    VideoAnalyzerClient.AccessPolicies.CreateOrUpdate(ResourceGroup, AccountName, accessPolicyName, AccessPolicyRole.Reader,
                        new JwtAuthentication()
                        {
                            Audiences = new List<string>() { "testAudience" },
                            Issuers = new List<string>() { "testIssuers" },
                            Keys = new List<TokenKey>() { new RsaTokenKey
                            {
                                Alg = AccessPolicyRsaAlgo.RS256,
                                Kid="123",
                                N="YmFzZTY0IQ==",
                                E="ZLFzZTY0IQ=="
                            }
                            }
                        });

                    var accessPolicy = VideoAnalyzerClient.AccessPolicies.Get(ResourceGroup, AccountName, accessPolicyName);
                    Assert.NotNull(accessPolicy);
                    Assert.Equal(accessPolicyName, accessPolicy.Name);

                    accessPoliies = VideoAnalyzerClient.AccessPolicies.List(ResourceGroup, AccountName);
                    Assert.NotNull(accessPoliies);
                    Assert.Single(accessPoliies);

                    VideoAnalyzerClient.AccessPolicies.Delete(ResourceGroup, AccountName, accessPolicyName);

                    accessPoliies = VideoAnalyzerClient.AccessPolicies.List(ResourceGroup, AccountName);
                    Assert.Empty(accessPoliies);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

