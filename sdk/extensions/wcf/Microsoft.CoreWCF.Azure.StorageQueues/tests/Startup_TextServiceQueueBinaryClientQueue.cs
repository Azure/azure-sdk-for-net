// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Contracts;
using CoreWCF.Configuration;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Tests
{
    public class Startup_TextServiceQueueBinaryClientQueue
    {
        public static string QueueName { get; } = TestHelper.GenerateUniqueQueueName();
        public static string DlqQueueName { get; } = "dlq-" + QueueName;
        private string connectionString = null;
        private string endpointUrlString = null;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<TestService>();
            TestHelper.ConfigureService(services, typeof(TestService).FullName, QueueName, out connectionString, out endpointUrlString, string.Empty, false, QueueMessageEncoding.Base64);
        }

        public void Configure(IApplicationBuilder app)
        {
            QueueClient queue = app.ApplicationServices.GetRequiredService<QueueClient>();

            app.UseServiceModel(services =>
            {
                services.AddService<TestService>();
                var binding = new AzureQueueStorageBinding(DlqQueueName);
                binding.Security.Transport.ClientCredentialType = AzureClientCredentialType.ConnectionString;
                binding.MessageEncoding = AzureQueueStorageMessageEncoding.Text;
                services.AddServiceEndpoint<TestService, ITestContract>(binding, endpointUrlString);
                services.UseAzureCredentials<TestService>(creds =>
                {
                    creds.ConnectionString = connectionString;
                    creds.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                });
            });
        }
    }
}
