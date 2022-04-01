// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Identity;
using Microsoft.Azure.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.SignalR.Tests.Common;
using Microsoft.Azure.WebJobs.Hosting;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests
{
    public class SignalROptionsFacts
    {
        private readonly ITestOutputHelper _outputHelper;

        public SignalROptionsFacts(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void TestDefaultSignalROptionsFormat()
        {
            var options = new SignalROptions();
            _outputHelper.WriteLine((options as IOptionsFormatter).Format());
        }

        [Fact]
        public void TestSignalROptionsFormat()
        {
            var options = new SignalROptions()
            {
                JsonObjectSerializer = new JsonObjectSerializer(),
                ServiceTransportType = ServiceTransportType.Persistent
            };
            options.ServiceEndpoints.Add(new ServiceEndpoint(FakeEndpointUtils.GetFakeConnectionString()));
            options.ServiceEndpoints.Add(new ServiceEndpoint(new Uri("https://mysignalr.com"), new DefaultAzureCredential(), EndpointType.Secondary, "backup"));
            _outputHelper.WriteLine((options as IOptionsFormatter).Format());
        }
    }
}
