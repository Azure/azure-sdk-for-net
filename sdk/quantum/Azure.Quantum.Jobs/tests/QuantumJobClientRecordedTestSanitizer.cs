// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Quantum.Jobs.Models;
using NUnit.Framework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientRecordedTestSanitizer : RecordedTestSanitizer
    {
        public const string ZERO_UID = "00000000-0000-0000-0000-000000000000";
        public const string TENANT_ID = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public const string PLACEHOLDER = "PLACEHOLDER";
        public const string RESOURCE_GROUP = "myresourcegroup";
        public const string WORKSPACE = "myworkspace";
        public const string LOCATION = "eastus";
        public const string STORAGE = "mystorage";

        public QuantumJobClientRecordedTestSanitizer()
            : base()
        {
            AddJsonPathSanitizer("$..containerUri");
            AddJsonPathSanitizer("$..inputDataUri");
            AddJsonPathSanitizer("$..outputDataUri");
            AddJsonPathSanitizer("$..sasUri");
            AddJsonPathSanitizer("$..outputMappingBlobUri");
            AddJsonPathSanitizer("$..containerUri");
            AddJsonPathSanitizer("$..containerUri");
            AddJsonPathSanitizer("$..containerUri");

            AddJsonPathSanitizer("$..AZURE_QUANTUM_WORKSPACE_LOCATION");
            AddJsonPathSanitizer("$..AZURE_QUANTUM_WORKSPACE_NAME");
            AddJsonPathSanitizer("$..AZURE_QUANTUM_WORKSPACE_RG");

            var testEnvironment = new QuantumJobClientTestEnvironment();
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/resourceGroups/[a-z0-9-]+/", $"/resourceGroups/{RESOURCE_GROUP}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/workspaces/[a-z0-9-]+/", $"/workspaces/{WORKSPACE}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"https://[^\.]+.blob.core.windows.net/", $"https://{STORAGE}.blob.core.windows.net/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"https://[^\.]+.quantum.azure.com/", $"https://{LOCATION}.quantum.azure.com/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/workspaces/[a-z0-9-]+/", $"/workspaces/{WORKSPACE}/"
            ));
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/subscriptions/[a-z0-9-]+/", $"/subscriptions/{ZERO_UID}/"
            ));
        }
    }
}
