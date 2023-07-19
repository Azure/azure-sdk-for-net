// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.Support.Tests.ScenarioTests
{
    public class ProblemClassificationTests
    {
        [Fact]
        public void ProblemClassificationListTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var serviceList = client.Services.List();
                    var problemClassificationList = client.ProblemClassifications.List(serviceList.First().Name);
                    Assert.True(problemClassificationList.Count() > 0);
                }
            }
        }

        [Fact]
        public void GetProblemClassificationTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<MicrosoftSupportClient>())
                {
                    var serviceList = client.Services.List();
                    var problemClassificationList = client.ProblemClassifications.List(serviceList.First().Name);
                    var problemClassification = client.ProblemClassifications.Get(serviceList.First().Name, problemClassificationList.First().Name);

                    Assert.True(!string.IsNullOrWhiteSpace(problemClassification.Id));
                    Assert.Equal("microsoft.support/problemclassifications", problemClassification.Type, ignoreCase: true);
                    Assert.True(!string.IsNullOrWhiteSpace(problemClassification.Name));
                    Assert.True(!string.IsNullOrWhiteSpace(problemClassification.DisplayName));
                }
            }
        }
    }
}
