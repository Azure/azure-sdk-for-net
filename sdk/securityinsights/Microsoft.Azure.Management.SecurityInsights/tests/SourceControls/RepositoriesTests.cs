// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class RepositoriesTests : TestBase
    {
        #region Test setup

        #endregion

        #region Repositories

        [Fact]
        public void Repositories_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                //var Repositories = SecurityInsightsClient.SourceControl.ListRepositories(TestHelper.ResourceGroup, TestHelper.WorkspaceName, "GitHub");
                // ValidateRepositories(Repositories);
                //Can not test since you need tokens for repos
            }
        }

        #endregion

        #region Validations

        private void ValidateRepositories(IPage<Repo> Repositories)
        {
            Assert.True(Repositories.IsAny());

            Repositories.ForEach(ValidateRepository);
        }

        private void ValidateRepository(Repo Repository)
        {
            Assert.NotNull(Repository);
        }

        #endregion
    }
}
