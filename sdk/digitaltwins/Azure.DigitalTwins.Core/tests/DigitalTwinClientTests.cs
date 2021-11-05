// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    [Category("Unit")]
    [Parallelizable(ParallelScope.All)]
    public class DigitalTwinClientTests
    {
        private const string PublicCloudScope = "https://digitaltwins.azure.net/.default";

        [Test]
        public void DigitalTwinClient_GetScopes()
        {
            string[] scopes = DigitalTwinsClient.GetAuthorizationScopes();
            scopes.Length.Should().Be(1, "There must be only 1 scope in the list");
            scopes.First().Should().Be(PublicCloudScope, "Invalid scope was generated");
        }
    }
}
