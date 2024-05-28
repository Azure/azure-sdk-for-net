﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.LiveMetrics;
using Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Demo
{
    internal class Program
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);
        private static ILogger? _logger;

        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        private static Random _random = new();

        private const int chunkSizeMB = 100;
        private static long totalMemoryAllocated = 0;

        public static async Task Main(string[] args)
        {
            var azureMonitorOptions = new AzureMonitorOptions
            {
                ConnectionString = ConnectionString
            };

            var manager = new Manager(azureMonitorOptions, new DefaultPlatform());

            using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(ActivitySourceName)
                .AddProcessor(new LiveMetricsActivityProcessor(manager))
                .Build();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options => options.AddProcessor(new LiveMetricsLogProcessor(manager)));
            });
            _logger = loggerFactory.CreateLogger<Program>();

            Console.WriteLine("Press any key to stop the loop.");

            // Loop until a key is pressed
            while (!Console.KeyAvailable)
            {
                await GenerateTelemetry();
                System.Threading.Thread.Sleep(200);
            }

            Console.WriteLine("Key pressed. Exiting the loop.");
        }

        private static bool GetRandomBool(int percent) => percent > _random.Next(0, 100);

        private static async Task GenerateTelemetry()
        {
            byte[]? memoryChunk;
            if (GetRandomBool(percent: 50))
            {
                // this will generate memory pressure
                memoryChunk = new byte[chunkSizeMB * 1024 * 1024];
                totalMemoryAllocated += memoryChunk.Length;
                Console.WriteLine("Total memory allocated: " + totalMemoryAllocated / 1024 / 1024 + " MB");
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
                            activity?.RecordException(ex, new TagList { { "customKey1", "customValue1" } });
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
                            activity?.RecordException(ex, new TagList { { "customKey1", "customValue1" } });
                        }
                    }

                    activity?.SetTag("customKey1", "customValue1");
                }
            }

            // Logs
            if (GetRandomBool(percent: 70))
            {
                Console.WriteLine("Log");

                _logger?.Log(
                    logLevel: LogLevel.Information,
                    eventId: 0,
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
                        _logger?.Log(
                            logLevel: LogLevel.Error,
                            eventId: 0,
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
    }
}
