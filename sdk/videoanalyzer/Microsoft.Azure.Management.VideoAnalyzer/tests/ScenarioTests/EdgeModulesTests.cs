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
    public class EdgeModulesTest : VideoAnalyzerTestBase
    {
        [Fact]
        public void EdgeModulesLifeCycleTest()
        {
            using (MockContext context = this.StartMockContextAndInitializeClients(this.GetType()))
            {
                try
                {
                    CreateVideoAnalyzerAccount();

                    var edgeModules = VideoAnalyzerClient.EdgeModules.List(ResourceGroup, AccountName);
                    Assert.Empty(edgeModules);

                    var edgeModuleName = TestUtilities.GenerateName("em");
                    VideoAnalyzerClient.EdgeModules.CreateOrUpdate(ResourceGroup, AccountName, edgeModuleName);

                    var edgeModule = VideoAnalyzerClient.EdgeModules.Get(ResourceGroup, AccountName, edgeModuleName);
                    Assert.NotNull(edgeModule);
                    Assert.Equal(edgeModuleName, edgeModule.Name);

                    edgeModules = VideoAnalyzerClient.EdgeModules.List(ResourceGroup, AccountName);
                    Assert.NotNull(edgeModules);
                    Assert.Single(edgeModules);

                    VideoAnalyzerClient.EdgeModules.Delete(ResourceGroup, AccountName, edgeModuleName);

                    edgeModules = VideoAnalyzerClient.EdgeModules.List(ResourceGroup, AccountName);
                    Assert.Empty(edgeModules);
                }
                finally
                {
                    DeleteVideoAnalyzerAccount();
                }
            }
        }
    }
}

