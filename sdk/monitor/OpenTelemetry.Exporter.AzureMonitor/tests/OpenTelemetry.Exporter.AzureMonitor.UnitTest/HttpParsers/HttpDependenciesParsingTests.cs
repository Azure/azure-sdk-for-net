// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor;
using OpenTelemetry.Exporter.AzureMonitor.HttpParsers;
using OpenTelemetry.Exporter.AzureMonitor.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.ApplicationInsights.Tests
{
    public class HttpDependenciesParsingTests
    {
        [Fact]
        public void HttpDependenciesParsingConvertsBlobs()
        {
            var d = new RemoteDependencyData(
                version: 2,
                name: "GET /my/container/myBlob",
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = "myaccount.blob.core.windows.net",
                Data = "https://myaccount.blob.core.windows.net/my/container/myBlob?comp=page&timeout=3"
            };

            bool success = AzureBlobHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureBlob, d.Type);
            Assert.Equal("myaccount.blob.core.windows.net", d.Target);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsTables()
        {
            var testCases = new List<string[]>()
            {
                ////
                //// copied from https://msdn.microsoft.com/en-us/library/azure/dd179423.aspx 10/18/2016
                ////

                new string[5] { "Set Table Service Properties", "PUT",      "https://myaccount.table.core.windows.net/?restype=service&comp=properties",                            "myaccount", string.Empty },
                new string[5] { "Get Table Service Properties", "GET",      "https://myaccount.table.core.windows.net/?restype=service&comp=properties",                            "myaccount", string.Empty },
                new string[5] { "Preflight Table Request",      "OPTIONS",  "http://myaccount.table.core.windows.net/mytable",                                                      "myaccount", "mytable" },
                new string[5] { "Get Table Service Stats",      "GET",      "https://myaccount-secondary.table.core.windows.net/?restype=service&comp=stats",                       "myaccount-secondary", string.Empty },
                new string[5] { "Query Tables",                 "GET",      "https://myaccount.table.core.windows.net/Tables",                                                      "myaccount", "Tables" },
                new string[5] { "Create Table",                 "POST",     "https://myaccount.table.core.windows.net/Tables",                                                      "myaccount", "Tables" },
                new string[5] { "Delete Table",                 "DELETE",   "https://myaccount.table.core.windows.net/Tables('mytable')",                                           "myaccount", "Tables" },
                new string[5] { "Get Table ACL",                "GET",      "https://myaccount.table.core.windows.net/mytable?comp=acl",                                            "myaccount", "mytable" },
                new string[5] { "Get Table ACL",                "HEAD",     "https://myaccount.table.core.windows.net/mytable?comp=acl",                                            "myaccount", "mytable" },
                new string[5] { "Set Table ACL",                "PUT",      "https://myaccount.table.core.windows.net/mytable?comp=acl",                                            "myaccount", "mytable" },
                new string[5] { "Query Entities",               "GET",      "https://myaccount.table.core.windows.net/mytable(PartitionKey='<partition-key>',RowKey='<row-key>')?$select=<comma-separated-property-names>", "myaccount", "mytable" },
                new string[5] { "Query Entities",               "GET",      "https://myaccount.table.core.windows.net/mytable()?$filter=<query-expression>&$select=<comma-separated-property-names>", "myaccount", "mytable" },
                new string[5] { "Query Entities",               "GET",      "https://myaccount.table.core.windows.net/Customers()?$filter=(Rating%20ge%203)%20and%20(Rating%20le%206)&$select=PartitionKey,RowKey,Address,CustomerSince", "myaccount", "Customers" },
                new string[5] { "Insert Entity",                "POST",     "https://myaccount.table.core.windows.net/mytable",                                     "myaccount", "mytable" },
                new string[5] { "Insert Or Merge Entity",       "MERGE",    "https://myaccount.table.core.windows.net/mytable(PartitionKey='myPartitionKey', RowKey='myRowKey')",   "myaccount", "mytable" },
                new string[5] { "Insert Or Replace Entity",     "PUT",      "https://myaccount.table.core.windows.net/mytable(PartitionKey='myPartitionKey', RowKey='myRowKey')",   "myaccount", "mytable" },
                new string[5] { "Update Entity",                "PUT",      "https://myaccount.table.core.windows.net/mytable(PartitionKey='myPartitionKey', RowKey='myRowKey')",   "myaccount", "mytable" },
                new string[5] { "Merge Entity",                 "MERGE",    "https://myaccount.table.core.windows.net/mytable(PartitionKey='myPartitionKey', RowKey='myRowKey')",   "myaccount", "mytable" },
                new string[5] { "Delete Entity",                "DELETE",   "https://myaccount.table.core.windows.net/mytable(PartitionKey='myPartitionKey', RowKey='myRowKey')",   "myaccount", "mytable" },
            };

            foreach (var testCase in testCases)
            {
                this.HttpDependenciesParsingConvertsTablesHelper(testCase[0], testCase[1], testCase[2], testCase[3], testCase[4]);
            }
        }

        private void HttpDependenciesParsingConvertsTablesHelper(string operation, string verb, string url, string accountName, string tableName)
        {
            Uri parsedUrl = new Uri(url);

            // Parse with verb
            var d = new RemoteDependencyData(
                version: 2,
                name: verb + " " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = AzureTableHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureTable, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = AzureTableHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureTable, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsQueues()
        {
            var testCases = new List<string[]>()
            {
                ////
                //// copied from https://msdn.microsoft.com/en-us/library/azure/dd179423.aspx 10/19/2016
                ////

                new string[5] { "Set Queue Service Properties",     "PUT",      "https://myaccount.queue.core.windows.net/?restype=service&comp=properties",        "myaccount", string.Empty },
                new string[5] { "Get Queue Service Properties",     "GET",      "https://myaccount.queue.core.windows.net/?restype=service&comp=properties",        "myaccount", string.Empty },
                new string[5] { "List Queues",                      "GET",      "https://myaccount.queue.core.windows.net?comp=list",                               "myaccount", string.Empty },
                new string[5] { "Preflight Queue Request",          "OPTIONS",  "http://myaccount.queue.core.windows.net/myqueue",                                  "myaccount", "myqueue" },
                new string[5] { "Get Queue Service Stats",          "GET",      "https://myaccount-secondary.queue.core.windows.net/?restype=service&comp=stats",   "myaccount-secondary", string.Empty },
                new string[5] { "Create Queue",                     "PUT",      "https://myaccount.queue.core.windows.net/myqueue",                                 "myaccount", "myqueue" },
                new string[5] { "Get Queue Metadata",               "GET",      "https://myaccount.queue.core.windows.net/myqueue?comp=metadata",                   "myaccount", "myqueue" },
                new string[5] { "Get Queue Metadata",               "HEAD",     "https://myaccount.queue.core.windows.net/myqueue?comp=metadata",                   "myaccount", "myqueue" },
                new string[5] { "Get Queue ACL",                    "GET",      "https://myaccount.queue.core.windows.net/myqueue?comp=acl",                        "myaccount", "myqueue" },
                new string[5] { "Get Queue ACL",                    "HEAD",     "https://myaccount.queue.core.windows.net/myqueue?comp=acl",                        "myaccount", "myqueue" },
                new string[5] { "Set Queue ACL",                    "PUT",      "https://myaccount.queue.core.windows.net/myqueue?comp=acl",                        "myaccount", "myqueue" },
                new string[5] { "Put Message",                      "POST",     "https://myaccount.queue.core.windows.net/myqueue/messages?visibilitytimeout=<int-seconds>&messagettl=<int-seconds>",   "myaccount", "myqueue" },
                new string[5] { "Delete Message",                   "DELETE",   "https://myaccount.queue.core.windows.net/myqueue/messages/messageid?popreceipt=string-value",                          "myaccount", "myqueue" },
                new string[5] { "Clear Messages",                   "DELETE",   "https://myaccount.queue.core.windows.net/myqueue/messages",                        "myaccount", "myqueue" },
            };

            foreach (var testCase in testCases)
            {
                this.HttpDependenciesParsingConvertsQueuesHelper(testCase[0], testCase[1], testCase[2], testCase[3], testCase[4]);
            }
        }

        private void HttpDependenciesParsingConvertsQueuesHelper(string operation, string verb, string url, string accountName, string queueName)
        {
            Uri parsedUrl = new Uri(url);

            // Parse with verb
            var d = new RemoteDependencyData(
                version: 2,
                name: verb + " " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = AzureQueueHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureQueue, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = AzureQueueHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureQueue, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsServices()
        {
            var testCases = new List<string[]>()
            {
                ////
                //// copied from https://msdn.microsoft.com/en-us/library/azure/dd179423.aspx 10/19/2016
                ////

                new string[4] { "PUT", "https://microsoft.com/test.asmx", RemoteDependencyConstants.WebService, "/test.asmx" },
                new string[4] { "GET", "https://microsoft.com/test.svc", RemoteDependencyConstants.WcfService, "/test.svc" },
                new string[4] { "POST", "https://microsoft.com/test.asmx/myargument", RemoteDependencyConstants.WebService, "/test.asmx" },
                new string[4] { "HEAD", "https://microsoft.com/test.svc/myarguments", RemoteDependencyConstants.WcfService, "/test.svc" },
            };

            foreach (var testCase in testCases)
            {
                this.HttpDependenciesParsingConvertsServicesHelper(testCase[0], testCase[1], testCase[2], testCase[3]);
            }
        }

        private void HttpDependenciesParsingConvertsServicesHelper(string verb, string url, string expectedType, string expectedName)
        {
            Uri parsedUrl = new Uri(url);

            // Parse with verb
            var d = new RemoteDependencyData(
                version: 2,
                name: verb + " " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = GenericServiceHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(expectedType, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = GenericServiceHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(expectedType, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsDocumentDb()
        {
            Uri parsedUrl = new Uri("https://myaccount.documents.azure.com/dbs/myDatabase");

            var d = new RemoteDependencyData(
                version: 2,
                name: "GET " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = DocumentDbHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureDocumentDb, d.Type);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsServiceBus()
        {
            Uri parsedUrl = new Uri("https://myaccount.servicebus.windows.net/myQueue/messages");

            var d = new RemoteDependencyData(
                version: 2,
                name: "GET " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = AzureServiceBusHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureServiceBus, d.Type);
        }

        [Fact]
        public void HttpDependenciesParsingConvertsIotHub()
        {
            Uri parsedUrl = new Uri("https://myaccount.azure-devices.net/devices");

            var d = new RemoteDependencyData(
                version: 2,
                name: "GET " + parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            bool success = AzureIotHubHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureIotHub, d.Type);
        }
    }
}