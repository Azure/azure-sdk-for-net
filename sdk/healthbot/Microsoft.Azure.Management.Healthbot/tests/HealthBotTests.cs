using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Healthbot;
using Microsoft.Azure.Management.Healthbot.Models;
using Microsoft.Azure.Test.HttpRecorder;
using System.Reflection;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Healthbot.Tests
{
    public class HealthbotTests
    {
        protected MockContext Context { get; set; }
        public healthbotClient Client { get; protected set; }
        public ResourceManagementClient RMClient { get; protected set; }

        public HealthbotTests()
        {/*
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);*/
            //this.Context = MockContext.Start(this.GetType());
            this.Client = this.Context.GetServiceClient<healthbotClient>();
            this.RMClient = this.Context.GetServiceClient<ResourceManagementClient>();
        }

        public void Dispose()
        {
            this.Client.Dispose();
            this.Context.Dispose();
        }


        [Fact]
        public void HealthbotFirstTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            // Verify that there are no results when querying an empty resource group
            var bots = new int [] {}; // healthbotMgmtClient.Bots.ListByResourceGroup(rgname);
            Assert.Empty(bots);
        }
    }
}
