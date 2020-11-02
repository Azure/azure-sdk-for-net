// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests
{
    public class PublicSurfaceTests
    {
        [Fact]
        public void WebJobs_Extensions_EventHubs_VerifyPublicSurfaceArea()
        {
            var assembly = typeof(EventHubAttribute).Assembly;

            var expected = new[]
            {
                "EventHubAttribute",
                "EventHubTriggerAttribute",
                "EventHubOptions",
                "EventHubWebJobsBuilderExtensions",
                "EventHubsWebJobsStartup"
            };

            TestHelpers.AssertPublicTypes(expected, assembly);
        }
    }
}
