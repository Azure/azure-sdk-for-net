// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Contracts;
using CoreWCF.AzureQueueStorage.Tests.Helpers;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using Xunit.Abstractions;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class IntegrationTests
    {
        private readonly ITestOutputHelper _output = null;
        public const string QueueName = "AzureQueue";

        [Fact(Skip = "Need AzureQueue")]
        public void ReceiveMessage_ServiceCall_Success()
        {
            IWebHost host = ServiceHelper.CreateWebHostBuilder<Startup>(_output).Build();
            using (host)
            {
                host.Start();
                MessageQueueHelper.SendMessageInQueue(QueueName);

                var resolver = new DependencyResolverHelper(host);
                var testService = resolver.GetService<TestService>();
                Assert.True(testService.ManualResetEvent.Wait(System.TimeSpan.FromSeconds(5)));
            }
        }
    }
}
