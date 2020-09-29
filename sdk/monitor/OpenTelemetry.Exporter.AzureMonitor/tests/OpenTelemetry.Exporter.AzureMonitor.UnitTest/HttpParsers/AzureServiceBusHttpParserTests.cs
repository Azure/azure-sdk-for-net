// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    public class AzureServiceBusHttpParserTests
    {
        [Fact]
        public void AzureServiceBusHttpParserSupportsNationalClouds()
        {
            var testCases = new List<Tuple<string, string, string>>()
            {
                Tuple.Create("Send message", "POST", "https://myaccount.servicebus.windows.net/myQueue/messages"),
                Tuple.Create("Send message", "POST", "https://myaccount.servicebus.chinacloudapi.cn/myQueue/messages"),
                Tuple.Create("Send message", "POST", "https://myaccount.servicebus.cloudapi.de/myQueue/messages"),
                Tuple.Create("Send message", "POST", "https://myaccount.servicebus.usgovcloudapi.net/myQueue/messages")
            };

            foreach (var testCase in testCases)
            {
                this.AzureServiceBusHttpParserConvertsValidDependencies(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3);
            }
        }

        private void AzureServiceBusHttpParserConvertsValidDependencies(
            string operation,
            string verb,
            string url)
        {
            Uri parsedUrl = new Uri(url);

            // Parse with verb
            var d = new RemoteDependencyData(
                version: 2,
                name: verb + " " + parsedUrl.AbsolutePath,
                duration: string.Empty)
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = AzureServiceBusHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureServiceBus, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: string.Empty)
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = AzureServiceBusHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureServiceBus, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);
        }
    }
}
