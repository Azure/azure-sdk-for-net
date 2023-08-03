// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample13_AdvancedConfiguration : ServiceBusLiveTestBase
    {
        [Test]
        public void ConfigureProxy()
        {
            #region Snippet:ServiceBusConfigureTransport
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                WebProxy = new WebProxy("https://myproxyserver:80")
            });
            #endregion

            Assert.AreEqual(ServiceBusTransportType.AmqpWebSockets, client.TransportType);
        }

        [Test]
        public void ConfigureRetryOptions()
        {
            #region Snippet:ServiceBusConfigureRetryOptions
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
            {
                RetryOptions = new ServiceBusRetryOptions
                {
                    TryTimeout = TimeSpan.FromSeconds(60),
                    MaxRetries = 3,
                    Delay = TimeSpan.FromSeconds(.8)
                }
            });
            #endregion
        }

        [Test]
        public void ConfigurePrefetchReceiver()
        {
            #region Snippet:ServiceBusConfigurePrefetchReceiver
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver("<queue-name>", new ServiceBusReceiverOptions
            {
                PrefetchCount = 10
            });
            #endregion

            Assert.AreEqual(10, receiver.PrefetchCount);
        }

        [Test]
        public void ConfigurePrefetchProcessor()
        {
            #region Snippet:ServiceBusConfigurePrefetchProcessor
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);
            ServiceBusProcessor processor = client.CreateProcessor("<queue-name>", new ServiceBusProcessorOptions
            {
                PrefetchCount = 10
            });
            #endregion

            Assert.AreEqual(10, processor.PrefetchCount);
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task ConfigureMessageLockLostHandler()
        {
            #region Snippet:ServiceBusProcessorLockLostHandler
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);

            // create a processor that we can use to process the messages
            await using ServiceBusProcessor processor = client.CreateProcessor("<queue-name>");

            // configure the message and error handler to use
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            async Task MessageHandler(ProcessMessageEventArgs args)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

                try
                {
                    args.MessageLockLostAsync += MessageLockLostHandler;

                    // We thread our linked token through to our expensive processing so that we can cancel it in the event of a lock lost exception,
                    // or when the processor is being stopped.
                    await SomeExpensiveProcessingAsync(args.Message, cts.Token);
                }
                finally
                {
                    // Finally, we remove the handler to avoid a memory leak.
                    args.MessageLockLostAsync -= MessageLockLostHandler;
                }

                Task MessageLockLostHandler(MessageLockLostEventArgs lockLostArgs)
                {
                    // We have access to the exception, if any, that triggered the lock lost event.
                    // If no exception was provided, the lock was considered lost by the client based on the lock expiry time.
                    Console.WriteLine(lockLostArgs.Exception);
                    cts.Cancel();
                    return Task.CompletedTask;
                }
            }

            Task ErrorHandler(ProcessErrorEventArgs args)
            {
                // the error source tells me at what point in the processing an error occurred
                Console.WriteLine(args.ErrorSource);
                // the fully qualified namespace is available
                Console.WriteLine(args.FullyQualifiedNamespace);
                // as well as the entity path
                Console.WriteLine(args.EntityPath);
                Console.WriteLine(args.Exception.ToString());
                return Task.CompletedTask;
            }

            // start processing
            await processor.StartProcessingAsync();

            // since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
            Console.ReadKey();
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the code builds")]
        public async Task ConfigureSessionLockLostHandler()
        {
            #region Snippet:ServiceBusSessionProcessorLockLostHandler
#if SNIPPET
            string connectionString = "<connection_string>";
#else
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            var client = new ServiceBusClient(connectionString);

            // create a processor that we can use to process the messages
            await using ServiceBusSessionProcessor processor = client.CreateSessionProcessor("<queue-name>");

            // configure the message and error handler to use
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += ErrorHandler;

            async Task MessageHandler(ProcessSessionMessageEventArgs args)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(args.CancellationToken);

                try
                {
                    args.SessionLockLostAsync += SessionLockLostHandler;

                    // We thread our linked token through to our expensive processing so that we can cancel it in the event of a lock lost exception,
                    // or when the processor is being stopped.
                    await SomeExpensiveProcessingAsync(args.Message, cts.Token);
                }
                finally
                {
                    // Finally, we remove the handler to avoid a memory leak.
                    args.SessionLockLostAsync -= SessionLockLostHandler;
                }

                Task SessionLockLostHandler(SessionLockLostEventArgs lockLostArgs)
                {
                    // We have access to the exception, if any, that triggered the lock lost event.
                    // If no exception was provided, the lock was considered lost by the client based on the lock expiry time.
                    Console.WriteLine(lockLostArgs.Exception);
                    cts.Cancel();
                    return Task.CompletedTask;
                }
            }

            Task ErrorHandler(ProcessErrorEventArgs args)
            {
                // the error source tells me at what point in the processing an error occurred
                Console.WriteLine(args.ErrorSource);
                // the fully qualified namespace is available
                Console.WriteLine(args.FullyQualifiedNamespace);
                // as well as the entity path
                Console.WriteLine(args.EntityPath);
                Console.WriteLine(args.Exception.ToString());
                return Task.CompletedTask;
            }

            // start processing
            await processor.StartProcessingAsync();

            // since the processing happens in the background, we add a Console.ReadKey to allow the processing to continue until a key is pressed.
            Console.ReadKey();
            #endregion
        }

        private Task SomeExpensiveProcessingAsync(ServiceBusReceivedMessage argsMessage, CancellationToken ctsToken)
        {
            return Task.CompletedTask;
        }
    }
}