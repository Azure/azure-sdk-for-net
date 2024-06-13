// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class Startup_EndToEnd_BinaryEncoding
    {
        public static string QueueName { get; } = TestHelper.GenerateUniqueQueueName();
        public static string DlqQueueName { get; } = "dlq-" + QueueName; private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService_EndToEnd>();
            TestHelper.ConfigureService(services, typeof(TestService_EndToEnd).FullName, QueueName, out connectionString, out endpointUrlString, "", false, QueueMessageEncoding.Base64);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService_EndToEnd>();
                var binding = new AzureQueueStorageBinding(DlqQueueName);
                binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.ConnectionString;
                binding.MessageEncoding = AzureQueueStorageMessageEncoding.Binary;
                services.AddServiceEndpoint<TestService_EndToEnd, ITestContract_EndToEndTest>(binding, endpointUrlString);
                services.UseAzureCredentials<TestService_EndToEnd>(creds =>
                {
                    creds.ConnectionString = connectionString;
                    creds.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                });
            });
        }
    }
}
#endif