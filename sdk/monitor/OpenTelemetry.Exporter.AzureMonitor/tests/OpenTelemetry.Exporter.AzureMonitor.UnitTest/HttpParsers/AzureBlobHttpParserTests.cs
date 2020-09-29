// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    public class AzureBlobHttpParserTests
    {
        [Fact]
        public void AzureBlobHttpParserConvertsValidDependencies()
        {
            Dictionary<string, string> defaultProperties = null;
            var containerProperties
                = new Dictionary<string, string> { ["Container"] = "my/container" };
            var blobProperties
                = new Dictionary<string, string> { ["Container"] = "my/container", ["Blob"] = "myblob" };

            var testCases = new List<Tuple<string, string, string, string, Dictionary<string, string>>>()
            {
                ////
                //// copied from https://msdn.microsoft.com/en-us/library/azure/dd135733.aspx 9/29/2016
                ////

                Tuple.Create("List Containers",                  "GET",      "https://myaccount.blob.core.windows.net/?comp=list",                                                           "myaccount", defaultProperties),
                Tuple.Create("Set Blob Service Properties",      "PUT",      "https://myaccount.blob.core.windows.net/?restype=service&comp=properties",                                     "myaccount", defaultProperties),
                Tuple.Create("Get Blob Service Properties",      "GET",      "https://myaccount.blob.core.windows.net/?restype=service&comp=properties",                                     "myaccount", defaultProperties),
                Tuple.Create("Preflight Blob Request",           "OPTIONS",  "http://myaccount.blob.core.windows.net/my/container/myblob",                                               "myaccount", blobProperties),
                Tuple.Create("Get Blob Service Stats",           "GET",      "https://myaccount.blob.core.windows.net/?restype=service&comp=stats",                                          "myaccount", defaultProperties),
                Tuple.Create("Create Container",                 "PUT",      "https://myaccount.blob.core.windows.net/my/container?restype=container",                                        "myaccount", containerProperties),
                Tuple.Create("Get Container Properties",         "GET",      "https://myaccount.blob.core.windows.net/my/container?restype=container",                                        "myaccount", containerProperties),
                Tuple.Create("Get Container Properties",         "HEAD",     "https://myaccount.blob.core.windows.net/my/container?restype=container",                                        "myaccount", containerProperties),
                Tuple.Create("Get Container Metadata",           "GET",      "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=metadata",                          "myaccount", containerProperties),
                Tuple.Create("Get Container Metadata",           "HEAD",     "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=metadata",                          "myaccount", containerProperties),
                Tuple.Create("Set Container Metadata",           "PUT",      "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=metadata",                          "myaccount", containerProperties),
                Tuple.Create("Get Container ACL",                "GET",      "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=acl",                               "myaccount", containerProperties),
                Tuple.Create("Get Container ACL",                "HEAD",     "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=acl",                               "myaccount", containerProperties),
                Tuple.Create("Set Container ACL",                "PUT",      "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=acl",                               "myaccount", containerProperties),
                Tuple.Create("Lease Container",                  "PUT",      "https://myaccount.blob.core.windows.net/my/container?comp=lease&restype=container",                             "myaccount", containerProperties),
                Tuple.Create("Delete Container",                 "DELETE",   "https://myaccount.blob.core.windows.net/my/container?restype=container",                                        "myaccount", containerProperties),
                Tuple.Create("List Blobs",                       "GET",      "https://myaccount.blob.core.windows.net/my/container?restype=container&comp=list",                              "myaccount", containerProperties),
                Tuple.Create("Put Blob",                         "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob",                                                   "myaccount", blobProperties),
                Tuple.Create("Get Blob",                         "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob",                                                   "myaccount", blobProperties),
                Tuple.Create("Get Blob",                         "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?snapshot=DateTime",                                 "myaccount", blobProperties),
                Tuple.Create("Get Blob Properties",              "HEAD",     "https://myaccount.blob.core.windows.net/my/container/myblob",                                                   "myaccount", blobProperties),
                Tuple.Create("Get Blob Properties",              "HEAD",     "https://myaccount.blob.core.windows.net/my/container/myblob?snapshot=DateTime",                                 "myaccount", blobProperties),
                Tuple.Create("Set Blob Properties",              "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=properties",                                   "myaccount", blobProperties),
                Tuple.Create("Get Blob Metadata",                "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=metadata",                                     "myaccount", blobProperties),
                Tuple.Create("Get Blob Metadata",                "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=metadata&snapshot=DateTime",                   "myaccount", blobProperties),
                Tuple.Create("Get Blob Metadata",                "HEAD",     "https://myaccount.blob.core.windows.net/my/container/myblob?comp=metadata",                                     "myaccount", blobProperties),
                Tuple.Create("Get Blob Metadata",                "HEAD",     "https://myaccount.blob.core.windows.net/my/container/myblob?comp=metadata&snapshot=DateTime",                   "myaccount", blobProperties),
                Tuple.Create("Set Blob Metadata",                "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=metadata",                                     "myaccount", blobProperties),
                Tuple.Create("Delete Blob",                      "DELETE",   "https://myaccount.blob.core.windows.net/my/container/myblob",                                                   "myaccount", blobProperties),
                Tuple.Create("Delete Blob",                      "DELETE",   "https://myaccount.blob.core.windows.net/my/container/myblob?snapshot=DateTime",                                 "myaccount", blobProperties),
                Tuple.Create("Lease Blob",                       "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=lease",                                        "myaccount", blobProperties),
                Tuple.Create("Snapshot Blob",                    "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=snapshot",                                     "myaccount", blobProperties),
                Tuple.Create("Copy Blob",                        "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob",                                                   "myaccount", blobProperties),
                Tuple.Create("Abort Copy Blob",                  "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=copy&copyid=id",                               "myaccount", blobProperties),
                Tuple.Create("Put Block",                        "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=block&blockid=id",                             "myaccount", blobProperties),
                Tuple.Create("Put Block List",                   "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=blocklist",                                    "myaccount", blobProperties),
                Tuple.Create("Get Block List",                   "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=blocklist",                                    "myaccount", blobProperties),
                Tuple.Create("Get Block List",                   "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=blocklist&snapshot=DateTime",                  "myaccount", blobProperties),
                Tuple.Create("Put Page",                         "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=page",                                         "myaccount", blobProperties),
                Tuple.Create("Get Page Ranges",                  "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=pagelist",                                     "myaccount", blobProperties),
                Tuple.Create("Get Page Ranges",                  "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=pagelist&snapshot=DateTime",                   "myaccount", blobProperties),
                Tuple.Create("Get Page Ranges",                  "GET",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=pagelist&snapshot=DateTime&prevsnapshot=Date", "myaccount", blobProperties),
                Tuple.Create("Append Block",                     "PUT",      "https://myaccount.blob.core.windows.net/my/container/myblob?comp=appendblock",                                  "myaccount", blobProperties)
            };

            foreach (var testCase in testCases)
            {
                this.EnsureAzureBlobHttpParserConvertsValidDependency(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3,
                    testCase.Item4,
                    testCase.Item5);
            }
        }

        [Fact]
        public void AzureBlobHttpParserSupportsNationalClouds()
        {
            var blobProperties
                = new Dictionary<string, string> { ["Container"] = "my/container", ["Blob"] = "myblob" };

            var testCases = new List<Tuple<string, string, string, string, Dictionary<string, string>>>()
            {
                Tuple.Create("Get Blob", "GET", "https://myaccount.blob.core.windows.net/my/container/myblob", "myaccount", blobProperties),
                Tuple.Create("Get Blob", "GET", "https://myaccount.blob.core.chinacloudapi.cn/my/container/myblob", "myaccount", blobProperties),
                Tuple.Create("Get Blob", "GET", "https://myaccount.blob.core.cloudapi.de/my/container/myblob", "myaccount", blobProperties),
                Tuple.Create("Get Blob", "GET", "https://myaccount.blob.core.usgovcloudapi.net/my/container/myblob", "myaccount", blobProperties)
            };

            foreach (var testCase in testCases)
            {
                this.EnsureAzureBlobHttpParserConvertsValidDependency(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3,
                    testCase.Item4,
                    testCase.Item5);
            }
        }

        private void EnsureAzureBlobHttpParserConvertsValidDependency(
            string operation,
            string verb,
            string url,
            string accountName,
            Dictionary<string, string> properties)
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

            bool success = AzureBlobHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureBlob, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    string value = null;
                    Assert.True(d.Properties.TryGetValue(property.Key, out value), operation);
                    Assert.Equal(property.Value, value);
                }
            }

            // Parse without verb
            d = new RemoteDependencyData(
                version:2,
                name: parsedUrl.AbsolutePath,
                duration: "10"
                )
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString
            };

            success = AzureBlobHttpParser.TryParse(ref d);

            Assert.True(success, operation);
            Assert.Equal(RemoteDependencyConstants.AzureBlob, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    string value = null;
                    Assert.True(d.Properties.TryGetValue(property.Key, out value), operation);
                    Assert.Equal(property.Value, value);
                }
            }
        }
    }
}
