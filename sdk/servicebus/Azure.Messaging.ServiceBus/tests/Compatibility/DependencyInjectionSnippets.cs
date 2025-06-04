// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    [TestFixture]
    public class DependencyInjectionSnippets
    {
        public class ClientRegistrationConnectionString
        {
            #region Snippet:DependencyInjectionRegisterClient
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddAzureClients(builder =>
                {
                    builder.AddServiceBusClient("<< SERVICE BUS CONNECTION STRING >>");
                });

                // Register other services, controllers, and other infrastructure.
            }
            #endregion
        }

        public class ClientRegistrationIdentity
        {
            #region Snippet:DependencyInjectionRegisterClientWithIdentity
           public void ConfigureServices(IServiceCollection services)
            {
                services.AddAzureClients(builder =>
                {
                    // This will register the ServiceBusClient using an Azure Identity credential.
                    builder.AddServiceBusClientWithNamespace("<< YOUR NAMESPACE >>.servicebus.windows.net");

                    // By default, DefaultAzureCredential is used, which is likely desired for most
                    // scenarios. If you need to restrict to a specific credential instance, you could
                    // register that instance as the default credential instead.
                    builder.UseCredential(new ManagedIdentityCredential());
                });

                // Register other services, controllers, and other infrastructure.
            }
            #endregion
        }

        public class SubClientRegistration
        {
            #region Snippet:DependencyInjectionRegisterSubClients
            public async Task ConfigureServicesAsync(IServiceCollection services)
            {
                // Query the available queues for the Service Bus namespace.
                var adminClient = new ServiceBusAdministrationClient("<< FULLY QUALIFIED NAMESPACE >>", new DefaultAzureCredential());
                var queueNames = new List<string>();

                // Because the result is async, they need to be captured to a standard list to avoid async
                // calls when registering.  Failure to do so results in an error with the services collection.
                await foreach (var queue in adminClient.GetQueuesAsync())
                {
                    queueNames.Add(queue.Name);
                }

                // After registering the ServiceBusClient, register a named factory for each
                // queue.  This allows them to be lazily created and managed as singleton instances.

                services.AddAzureClients(builder =>
                {
                    builder.AddServiceBusAdministrationClientWithNamespace("<< FULLY QUALIFIED NAMESPACE >>");

                    foreach (var queueName in queueNames)
                    {
                        builder.AddClient<ServiceBusSender, ServiceBusClientOptions>((_, _, provider) =>
                            provider
                                .GetService<ServiceBusClient>()
                                .CreateSender(queueName)
                        )
                        .WithName(queueName);
                    }
                });

                // Register other services, controllers, and other infrastructure.
            }
            #endregion

            #region Snippet:DependencyInjectionBindToNamedSubClients
            public class ServiceBusSendingController : ControllerBase
            {
                private readonly ServiceBusSender _sender;

                public ServiceBusSendingController(IAzureClientFactory<ServiceBusSender> serviceBusSenderFactory)
                {
                    // Though the method is called "CreateClient", the factory will manage the sender as a
                    // singleton, creating a new instance only on the first use.
                    _sender = serviceBusSenderFactory.CreateClient("<< QUEUE NAME >>");
                }
            }
            #endregion
        }

        // This is a dummy class pretending to be an ASP.NET controller. It is intended
        // to allow the snippet to compile.
        public class ControllerBase
        {
        }
    }
}
