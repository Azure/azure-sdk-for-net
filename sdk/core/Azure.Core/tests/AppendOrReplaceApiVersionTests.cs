// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class AppendOrReplaceApiVersionTests
    {
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW",
                  "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-10-30-PREVIEW",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW",
                  "/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-10-30-PREVIEW",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW",
                  "https://management.azure.com/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/testRG-416/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testRi-6086?api-version=2021-09-30-PREVIEW")]
        [TestCase("/operations/2608e164-7bb4-4012-98f6-9a862b2218a6",
                  "https://qnamaker-resource-name.api.cognitiveservices.azure.com/qnamaker/v5.0-preview.1/knowledgebases/create",
                  "/operations/2608e164-7bb4-4012-98f6-9a862b2218a6")]
        [TestCase("xyz.com?api-version=2021-10-01&x=1",
                  "https://abc.com?api-version=2021-11-01&a=1",
                  "xyz.com?api-version=2021-11-01&x=1")]
        [TestCase("https://xyz.com?x=1&api-version=2021-10-01&y=2",
                  "https://abc.com?a=1&api-version=2021-11-01&b=2",
                  "https://xyz.com?x=1&api-version=2021-11-01&y=2")]
        [TestCase("https://xyz.com?x=1&api-version=2021-10-01",
                  "https://abc.com?a=1&api-version=2021-11-01",
                  "https://xyz.com?x=1&api-version=2021-11-01")]
        [TestCase("https://xyz.com?x=1&api-version=2021-10-01",
                  "https://abc.com?a=1",
                  "https://xyz.com?x=1&api-version=2021-10-01")]
        [TestCase("https://xyz.com?x=1",
                  "https://abc.com",
                  "https://xyz.com?x=1")]
        [TestCase("https://xyz.com?API-VERSION=2021-10-01",
                  "https://abc.com?api-version=2021-11-01",
                  "https://xyz.com?API-VERSION=2021-10-01&api-version=2021-11-01")]
        [TestCase("https://xyz.com?x=1",
                  "https://abc.com?api-version",
                  "https://xyz.com?x=1")]
        [TestCase("https://xyz.com?x=1",
                  "https://abc.com?api-version&x=1",
                  "https://xyz.com?x=1")]
        [TestCase("https://xyz.com?api-version",
                  "https://abc.com?api-version=2021-11-01",
                  "https://xyz.com?api-version=2021-11-01")]
        [TestCase("https://xyz.com?api-version&x=1",
                  "https://abc.com?api-version=2021-11-01",
                  "https://xyz.com?api-version=2021-11-01&x=1")]
        public void TestAppendOrReplaceApiVersion(string uriToProcess, string startRequestUriStr, string expectedUri)
        {
            Uri startRequestUri = new Uri(startRequestUriStr);
            NextLinkOperationImplementation.TryGetApiVersion(startRequestUri, out ReadOnlySpan<char> apiVersion);
            string resultUri = NextLinkOperationImplementation.AppendOrReplaceApiVersion(uriToProcess, apiVersion.IsEmpty ? null : apiVersion.ToString());
            Assert.AreEqual(resultUri, expectedUri);
        }
    }
}
