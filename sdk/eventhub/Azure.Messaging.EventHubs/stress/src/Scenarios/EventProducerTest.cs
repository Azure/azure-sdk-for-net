// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.EventHubs.Stress
{
    public static class EventProducerTest
    {
        private static readonly TimeSpan DefaultProcessReportInterval = TimeSpan.FromSeconds(45);
        private static readonly TimeSpan DefaultRunDuration = TimeSpan.FromHours(72);
        private static readonly string DefaultErrorLogPath = Path.Combine(Environment.CurrentDirectory, $"processor-test-errors-{ DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") }.log");

        public static async Task Run()
        {
            await Task.Delay(3000);
            Console.WriteLine("HEllo :)");
        }
    }
}