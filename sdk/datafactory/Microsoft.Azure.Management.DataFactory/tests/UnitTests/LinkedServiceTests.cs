// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.JsonSamples;
using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Serialization;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DataFactory.Tests.UnitTests
{
    public class LinkedServiceTests : BaseUnitTest
    {
        // Enable Xunit test output logger.
        protected readonly ITestOutputHelper logger = new TestOutputHelper();

        public LinkedServiceTests(ITestOutputHelper logger)
            : base()
        {
            this.logger = logger;
        }

        [Theory]
        [ClassData(typeof(LinkedServiceJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void LinkedService_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<LinkedServiceResource>(jsonSample);
        }

        [Fact]
        public void LinkedService_WebLinkedServiceSDKSample()
        {
            string password = "secretpassword";
            LinkedServiceResource linkedServiceResource = new LinkedServiceResource
            {
                Properties = new WebLinkedService
                {
                    TypeProperties = new WebBasicAuthentication
                    {
                        Url = "https://localhost",
                        Username = "myname",
                        Password = new SecureString(password)
                    }
                }
            };

            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(linkedServiceResource, client.SerializationSettings);
            Assert.Contains(password, json);
        }
    }
}
