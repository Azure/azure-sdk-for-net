// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Contracts;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.AzureQueueStorage.Tests.Helpers;
using CoreWCF.Queue.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using Azure.Storage.CoreWCF.Channels;

namespace CoreWCF.AzureQueueStorage.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService>();
            services.AddServiceModelServices();
            //services.AddQueueTransport(x => { x.ConcurrencyLevel = 1; });
            // get connection string from settings and add queue client
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseServiceModel(services =>
            {
                services.AddService<TestService>();
                services.AddServiceEndpoint<TestService, ITestContract>(new AzureQueueStorageBinding(),
                    $"net.aqs://localhost/private/{IntegrationTests.QueueName}");
            });
        }
    }
}
