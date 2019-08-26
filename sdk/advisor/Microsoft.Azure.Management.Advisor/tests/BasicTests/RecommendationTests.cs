// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Azure.Management.Advisor;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Advisor.Tests.BasicTests
{
    public class RecommendationTests
    {
        [Fact]
        public void GenerateRecommendationsTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (var client = context.GetServiceClient<AdvisorManagementClient>())
                {
                    var regex = new Regex("[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}", RegexOptions.Compiled);
                    var headers = client.Recommendations.Generate();
                    var operationId = Guid.Parse(regex.Matches(headers.Location).Last().Value);
                    client.Recommendations.GetGenerateStatus(operationId);
                }
            }
        }
    }
}