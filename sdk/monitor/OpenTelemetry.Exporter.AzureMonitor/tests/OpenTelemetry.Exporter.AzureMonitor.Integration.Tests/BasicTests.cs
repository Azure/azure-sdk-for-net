﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
{
    /// <summary>
    /// These tests are to verify that the IntegrationTests work (i.e. This project can communicate with the <see cref="AspNetCoreWebApp"/> project).
    /// </summary>
    public class BasicTests : IClassFixture<WebApplicationFactory<AspNetCoreWebApp.Startup>>
    {
        private readonly WebApplicationFactory<AspNetCoreWebApp.Startup> factory;

        public BasicTests(WebApplicationFactory<AspNetCoreWebApp.Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.BadRequest)]
        public async Task VerifyRequest(HttpStatusCode httpStatusCode)
        {
            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, $"api/home/statuscode/{(int)httpStatusCode}");

            // Act
            var response = await client.GetAsync(request);

            // Assert
            Assert.Equal(httpStatusCode, response.StatusCode);
        }
    }
}
