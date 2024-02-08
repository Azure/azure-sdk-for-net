// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Demo
{
    internal class Program
    {
        private const string ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource s_activitySource = new(ActivitySourceName);

        private const string ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        private static Random _random = new();

        public static void Main(string[] args)
        {
            using TracerProvider tracerProvider = Sdk.CreateTracerProviderBuilder()
                            .AddSource(ActivitySourceName)
                            .AddLiveMetrics(configure => configure.ConnectionString = ConnectionString)
                            .Build();

            Console.WriteLine("Press any key to stop the loop.");

            // Loop until a key is pressed
            while (!Console.KeyAvailable)
            {
                GenerateTelemetry();
                System.Threading.Thread.Sleep(200);
            }

            Console.WriteLine("Key pressed. Exiting the loop.");
        }

        private static bool GetRandomBool(int percent) => percent >= _random.Next(0, 100);

        private static void GenerateTelemetry()
        {
            // Request
            if (GetRandomBool(percent: 70))
            {
                Console.WriteLine("Request");
                using (var activity = s_activitySource.StartActivity("Request", kind: ActivityKind.Server))
                {
                    // Exception
                    if (GetRandomBool(percent: 40))
                    {
                        Console.WriteLine("Request Exception");
                        try
                        {
                            throw new Exception("Test exception");
                        }
                        catch (Exception ex)
                        {
                            activity?.SetStatus(ActivityStatusCode.Error);
                            activity?.RecordException(ex);
                        }
                    }
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
                            throw new Exception("Test exception");
                        }
                        catch (Exception ex)
                        {
                            activity?.SetStatus(ActivityStatusCode.Error);
                            activity?.RecordException(ex);
                        }
                    }
                }
            }
        }
    }
}
