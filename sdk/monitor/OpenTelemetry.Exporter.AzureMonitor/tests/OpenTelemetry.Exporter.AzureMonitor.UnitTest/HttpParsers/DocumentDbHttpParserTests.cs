// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    public class DocumentDbHttpParserTests
    {
        [Fact]
        public void DocumentDbHttpParserConvertsValidDependencies()
        {
            Dictionary<string, string> defaultProperties = null;
            var databaseProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase" };
            var collectionProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase", ["Collection"] = "myCollection" };
            var sprocProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase", ["Collection"] = "myCollection", ["Stored procedure"] = "mySproc" };
            var udfProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase", ["Collection"] = "myCollection", ["User defined function"] = "myUdf" };
            var triggerProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase", ["Collection"] = "myCollection", ["Trigger"] = "myTrigger" };

            string defaultResultCode = "200";

            var testCases = new List<Tuple<string, string, string, Dictionary<string, string>, string>>()
            {
                // Database operations
                Tuple.Create("Create database",             "POST",     "https://myaccount.documents.azure.com/dbs", defaultProperties, defaultResultCode),
                Tuple.Create("List databases",              "GET",      "https://myaccount.documents.azure.com/dbs", defaultProperties, defaultResultCode),
                Tuple.Create("Get database",                "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase", databaseProperties, defaultResultCode),
                Tuple.Create("Delete database",             "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase", databaseProperties, defaultResultCode),

                // Collection operations
                Tuple.Create("Create collection",           "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls", databaseProperties, defaultResultCode),
                Tuple.Create("List collections",            "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls", databaseProperties, defaultResultCode),
                Tuple.Create("Get collection",              "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection", collectionProperties, defaultResultCode),
                Tuple.Create("Delete collection",           "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection", collectionProperties, defaultResultCode),
                Tuple.Create("Replace collection",          "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection", collectionProperties, defaultResultCode),

                // Document operations
                Tuple.Create("Create document",             "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs", collectionProperties, "201"),
                Tuple.Create("Query documents",             "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs", collectionProperties, "200"),
                Tuple.Create("Create/query document",       "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs", collectionProperties, "400"),
                Tuple.Create("List documents",              "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs", collectionProperties, defaultResultCode),
                Tuple.Create("Get document",                "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc", collectionProperties, defaultResultCode),
                Tuple.Create("Replace document",            "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc", collectionProperties, defaultResultCode),
                Tuple.Create("Delete document",             "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc", collectionProperties, defaultResultCode),

                // Attachment operations
                Tuple.Create("Create attachment",           "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc/attachments", collectionProperties, defaultResultCode),
                Tuple.Create("List attachments",            "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc/attachments", collectionProperties, defaultResultCode),
                Tuple.Create("Get attachment",              "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc/attachments/myAtt", collectionProperties, defaultResultCode),
                Tuple.Create("Replace attachment",          "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc/attachments/myAtt", collectionProperties, defaultResultCode),
                Tuple.Create("Delete attachment",           "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/docs/myDoc/attachments/myAtt", collectionProperties, defaultResultCode),

                // Stored procedure operations
                Tuple.Create("Create stored procedure",     "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/sprocs", collectionProperties, defaultResultCode),
                Tuple.Create("List stored procedures",      "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/sprocs", collectionProperties, defaultResultCode),
                Tuple.Create("Replace stored procedure",    "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/sprocs/mySproc", sprocProperties, defaultResultCode),
                Tuple.Create("Delete stored procedure",     "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/sprocs/mySproc", sprocProperties, defaultResultCode),
                Tuple.Create("Execute stored procedure",    "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/sprocs/mySproc", sprocProperties, defaultResultCode),

                // User defined function operations
                Tuple.Create("Create UDF",                  "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/udfs", collectionProperties, defaultResultCode),
                Tuple.Create("List UDFs",                   "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/udfs", collectionProperties, defaultResultCode),
                Tuple.Create("Replace UDF",                 "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/udfs/myUdf", udfProperties, defaultResultCode),
                Tuple.Create("Delete UDF",                  "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/udfs/myUdf", udfProperties, defaultResultCode),

                // Trigger operations
                Tuple.Create("Create trigger",              "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/triggers", collectionProperties, defaultResultCode),
                Tuple.Create("List triggers",               "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/triggers", collectionProperties, defaultResultCode),
                Tuple.Create("Replace trigger",             "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/triggers/myTrigger", triggerProperties, defaultResultCode),
                Tuple.Create("Delete trigger",              "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/colls/myCollection/triggers/myTrigger", triggerProperties, defaultResultCode),

                // User operations
                Tuple.Create("Create user",                 "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/users", databaseProperties, defaultResultCode),
                Tuple.Create("List users",                  "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/users", databaseProperties, defaultResultCode),
                Tuple.Create("Get user",                    "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser", databaseProperties, defaultResultCode),
                Tuple.Create("Replace user",                "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser", databaseProperties, defaultResultCode),
                Tuple.Create("Delete user",                 "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser", databaseProperties, defaultResultCode),

                // Permission operations
                Tuple.Create("Create permission",           "POST",     "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser/permissions", databaseProperties, defaultResultCode),
                Tuple.Create("List permissions",            "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser/permissions", databaseProperties, defaultResultCode),
                Tuple.Create("Get permission",              "GET",      "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser/permissions/myPerm", databaseProperties, defaultResultCode),
                Tuple.Create("Replace permission",          "PUT",      "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser/permissions/myPerm", databaseProperties, defaultResultCode),
                Tuple.Create("Delete permission",           "DELETE",   "https://myaccount.documents.azure.com/dbs/myDatabase/users/myUser/permissions/myPerm", databaseProperties, defaultResultCode),

                // Offer operations
                Tuple.Create("Query offers",                "POST",     "https://myaccount.documents.azure.com/offers", defaultProperties, defaultResultCode),
                Tuple.Create("List offers",                 "GET",      "https://myaccount.documents.azure.com/offers", defaultProperties, defaultResultCode),
                Tuple.Create("Get offer",                   "GET",      "https://myaccount.documents.azure.com/offers/myOffer", defaultProperties, defaultResultCode),
                Tuple.Create("Replace offer",               "PUT",      "https://myaccount.documents.azure.com/offers/myOffer", defaultProperties, defaultResultCode),
            };

            foreach (var testCase in testCases)
            {
                this.DocumentDbHttpParserConvertsValidDependenciesHelper(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3,
                    testCase.Item4,
                    testCase.Item5);
            }
        }

        [Fact]
        public void DocumentDbHttpParserSupportsNationalClouds()
        {
            var databaseProperties
                = new Dictionary<string, string> { ["Database"] = "myDatabase" };

            string defaultResultCode = "200";

            var testCases = new List<Tuple<string, string, string, Dictionary<string, string>, string>>()
            {
                Tuple.Create("Get database", "GET", "https://myaccount.documents.azure.com/dbs/myDatabase", databaseProperties, defaultResultCode),
                Tuple.Create("Get database", "GET", "https://myaccount.documents.chinacloudapi.cn/dbs/myDatabase", databaseProperties, defaultResultCode),
                Tuple.Create("Get database", "GET", "https://myaccount.documents.cloudapi.de/dbs/myDatabase", databaseProperties, defaultResultCode),
                Tuple.Create("Get database", "GET", "https://myaccount.documents.usgovcloudapi.net/dbs/myDatabase", databaseProperties, defaultResultCode)
            };

            foreach (var testCase in testCases)
            {
                this.DocumentDbHttpParserConvertsValidDependenciesHelper(
                    testCase.Item1,
                    testCase.Item2,
                    testCase.Item3,
                    testCase.Item4,
                    testCase.Item5);
            }
        }

        private void DocumentDbHttpParserConvertsValidDependenciesHelper(
            string operation,
            string verb,
            string url,
            Dictionary<string, string> properties,
            string resultCode)
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
                Data = parsedUrl.OriginalString,
                ResultCode = resultCode ?? "200"
            };

            bool success = DocumentDbHttpParser.TryParse(ref d);

            Assert.True(success);
            Assert.Equal(RemoteDependencyConstants.AzureDocumentDb, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    string value = null;
                    Assert.True(d.Properties.TryGetValue(property.Key, out value));
                    Assert.Equal(property.Value, value);
                }
            }

            // Parse without verb
            d = new RemoteDependencyData(
                version: 2,
                name: parsedUrl.AbsolutePath,
                duration: string.Empty)
            {
                Type = RemoteDependencyConstants.HTTP,
                Target = parsedUrl.Host,
                Data = parsedUrl.OriginalString,
                ResultCode = resultCode ?? "200"
            };

            success = DocumentDbHttpParser.TryParse(ref d);

            Assert.True(success, operation);
            Assert.Equal(RemoteDependencyConstants.AzureDocumentDb, d.Type);
            Assert.Equal(parsedUrl.Host, d.Target);

            if (properties != null)
            {
                foreach (var property in properties)
                {
                    string value = null;
                    Assert.True(d.Properties.TryGetValue(property.Key, out value));
                    Assert.Equal(property.Value, value);
                }
            }
        }
    }
}
