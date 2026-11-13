// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Tests
{
    public class WebJobsConfigurationTests
    {
        [TestCase("Key")]
        [TestCase("AzureWebJobsKey")]
        [TestCase("ConnectionStrings:Key")]
        public void KeysAreMappedForSingleValue(string actualKeyName)
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(actualKeyName, "value")
                });
            var configuration = builder.Build();
            Assert.That("value", Is.EqualTo(configuration.GetWebJobsConnectionStringSection("Key").Value));
        }

        [TestCase("Key")]
        [TestCase("AzureWebJobsKey")]
        [TestCase("ConnectionStrings:Key")]
        public void KeysAreMappedForSections(string actualKeyName)
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(actualKeyName + ":Value1", "value1"),
                    new KeyValuePair<string, string>(actualKeyName + ":Value2", "value2")
                });
            var configuration = builder.Build();

            Assert.That("value1", Is.EqualTo(configuration.GetWebJobsConnectionStringSection("Key")["Value1"]));
            Assert.That("value2", Is.EqualTo(configuration.GetWebJobsConnectionStringSection("Key")["Value2"]));
        }
    }
}