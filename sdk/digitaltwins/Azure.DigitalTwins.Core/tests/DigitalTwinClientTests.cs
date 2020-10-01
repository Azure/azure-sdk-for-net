// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void DigitalTwinClient_GetScopes_PpeValid()
        {
            Uri adtInstanceEndpoint = new Uri("https://testinstance.api.scus.pp.azuredigitaltwins-ppe.net");
            string[] scopes = DigitalTwinsClient.GetAuthorizationScopes(adtInstanceEndpoint);
            scopes.Length.Should().Be(1, "There must be only 1 scope in the list");
            scopes.First().Should().Be(PublicCloudScope, "Invalid scope was generated");
        }

        [Test]
        public void DigitalTwinClient_GetScopes_PublicCloudValid()
        {
            Uri adtInstanceEndpoint = new Uri("https://testInstance.api.scus.azuredigitaltwins.azure.net");
            string[] scopes = DigitalTwinsClient.GetAuthorizationScopes(adtInstanceEndpoint);
            scopes.Length.Should().Be(1, "There must be only 1 scope in the list");
            scopes.First().Should().Be(PublicCloudScope, "Invalid scope was generated");
        }

        [Test]
        public void DigitalTwinClient_GetScopes_InvalidEndpoint()
        {
            Uri adtInstanceEndpoint = new Uri("https://testInstance.api.scus.azuredigitaltwins.fairfax.gov");

            // act
            Func<string[]> act = () =>
            {
                return DigitalTwinsClient.GetAuthorizationScopes(adtInstanceEndpoint);
            };

            // assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void DigitalTwinClient_GetScopes_NullOrEmptyEndpointThrows()
        {
            // act
            Func<string[]> act = () =>
            {
                return DigitalTwinsClient.GetAuthorizationScopes(null);
            };

            // assert
            act.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("endpoint");
        }
    }
}
