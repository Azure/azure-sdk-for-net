// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Resources;
using Azure.Monitor.OpenTelemetry.Exporter;
using System.Threading;
using System.Diagnostics.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Demo
{
    internal class Program
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private const string MeterName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static readonly Meter s_meter = new(MeterName);
        private static ILogger? s_logger;

        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        private static readonly Random s_random = new();

        private const int ChunkSizeMB = 100;
        private static long s_totalMemoryAllocated = 0;

        public static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddOpenTelemetry()
                .ConfigureResource(r => r.AddAttributes(new Dictionary<string, object>
                {
                    { "service.name", "my-service" },
                    { "service.namespace", "my-namespace" },
                    { "service.instance.id", "my-instance" },
                    { "service.version", "1.0.0-demo" },
                }))
                .UseAzureMonitorExporter(o => o.ConnectionString = ConnectionString)
                .WithTracing(tracing => tracing.AddSource(ActivitySourceName))
                .WithMetrics(metrics => metrics.AddMeter(MeterName));

            using var host = builder.Build();
            using var cancellationTokenSource = new CancellationTokenSource();
            var hostLifetime = host.RunAsync(cancellationTokenSource.Token);

            Console.WriteLine("Press any key to stop the loop.");

            // Get the logger from the host's service provider
            s_logger = host.Services.GetRequiredService<ILogger<Program>>();

            // Loop until a key is pressed
            while (!Console.KeyAvailable)
            {
                await GenerateTelemetry();
                await GenerateMetrics();
                Task.Delay(200).Wait();
            }

            Console.WriteLine("Key pressed. Exiting the loop.");

            // Signal the host to stop
            cancellationTokenSource.Cancel();
            await hostLifetime;
        }

        private static bool GetRandomBool(int percent) => percent > s_random.Next(0, 100);

        private static async Task GenerateTelemetry()
        {
            byte[]? memoryChunk;
            if (GetRandomBool(percent: 50))
            {
                // this will generate memory pressure
                memoryChunk = new byte[ChunkSizeMB * 1024 * 1024];
                s_totalMemoryAllocated += memoryChunk.Length;
                Console.WriteLine("Total memory allocated: " + s_totalMemoryAllocated / 1024 / 1024 + " MB");
            }

            if (GetRandomBool(percent: 5))
            {
                Console.WriteLine("CPU Stress Test");
                await RunCPUStressTest();
            }

            // Request
            if (GetRandomBool(percent: 70))
            {
                Console.WriteLine("Request");
                using (var activity = s_activitySource.StartActivity("Request", kind: ActivityKind.Server))
                {
                    activity?.SetTag("url.scheme", "http");
                    activity?.SetTag("server.address", "localhost");

                    // Exception
                    if (GetRandomBool(percent: 40))
                    {
                        activity?.SetTag("url.path", "/request/fail");
                        Console.WriteLine("Request Exception");
                        try
                        {
                            throw new Exception("Test Request Exception");
                        }
                        catch (Exception ex)
                        {
                            activity?.SetStatus(ActivityStatusCode.Error);
                            activity?.AddException(ex, new TagList { { "customKey1", "customValue1" } });
                        }
                    }
                    else
                    {
                        activity?.SetTag("url.path", "/request/success");
                    }

                    activity?.SetTag("customKey1", "customValue1");
                }
            }

            // Dependency
            if (GetRandomBool(percent: 70))
            {
                Console.WriteLine("Dependency");
                using (var activity = s_activitySource.StartActivity("Dependency", kind: ActivityKind.Client))
                {
                    // Exception
                    if (GetRandomBool(percent: 40))
                    {
                        Console.WriteLine("Dependency Exception");
                        try
                        {
                            throw new Exception("Test Dependency Exception");
                        }
                        catch (Exception ex)
                        {
                            activity?.SetStatus(ActivityStatusCode.Error);
                            activity?.AddException(ex, new TagList { { "customKey1", "customValue1" } });
                        }
                    }

                    activity?.SetTag("customKey1", "customValue1");
                }
            }

            // Logs
            if (GetRandomBool(percent: 70))
            {
                Console.WriteLine("Log");

                s_logger?.Log(
                    logLevel: LogLevel.Information,
                    eventId: 1,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });

                // Exception
                if (GetRandomBool(percent: 40))
                {
                    Console.WriteLine("Log Exception");
                    try
                    {
                        throw new Exception("Test Log Exception");
                    }
                    catch (Exception ex)
                    {
                        s_logger?.Log(
                            logLevel: LogLevel.Error,
                            eventId: 2,
                            exception: ex,
                            message: "Hello {name}.",
                            args: new object[] { "World" });
                    }
                }
            }

            // Release the allocated memory
            memoryChunk = null;
        }

        private static async Task RunCPUStressTest()
        {
            // Get the number of available processors
            int numProcessors = Environment.ProcessorCount;
            numProcessors = numProcessors > 1 ? numProcessors - 1 : numProcessors;

            Task[] tasks = new Task[numProcessors];

            // Start each task
            for (int i = 0; i < numProcessors; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    var timeStamp = DateTime.Now.AddSeconds(5);
                    while (DateTime.Now < timeStamp)
                    {
                        // Keep the CPU busy
                    }
                });
            }

            await Task.WhenAll(tasks);
        }

        private static Task GenerateMetrics()
        {
            return Task.Run(() =>
            {
                // Counter Example
                Counter<long> myFruitCounter = s_meter.CreateCounter<long>("MyFruitCounter");

                myFruitCounter.Add(1, new("name", "apple"), new("color", "red"));
                myFruitCounter.Add(2, new("name", "lemon"), new("color", "yellow"));
                myFruitCounter.Add(1, new("name", "lemon"), new("color", "yellow"));
                myFruitCounter.Add(2, new("name", "apple"), new("color", "green"));
                myFruitCounter.Add(5, new("name", "apple"), new("color", "red"));
                myFruitCounter.Add(4, new("name", "lemon"), new("color", "yellow"));

                // Histogram Example
                Histogram<long> myFruitSalePrice = s_meter.CreateHistogram<long>("MyFruitSalePrice");

                var random = new Random();
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "red"));
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "green"));
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "red"));
                myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));

                // Gauge Example
                var process = Process.GetCurrentProcess();

                ObservableGauge<int> myObservableGauge = s_meter.CreateObservableGauge("Thread.State", () => GetThreadState(process));
            });
        }

        private static IEnumerable<Measurement<int>> GetThreadState(Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                yield return new((int)thread.ThreadState, new("ProcessId", process.Id), new("ThreadId", thread.Id));
            }
        }
    }
}
