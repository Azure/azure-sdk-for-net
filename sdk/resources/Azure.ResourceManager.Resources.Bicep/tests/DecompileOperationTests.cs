// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources.Bicep.Models;
using Azure.Core;
using System.Linq;

namespace Azure.ResourceManager.Resources.Bicep.Tests
{
    public sealed class DecompileOperationTests : BicepManagementTestBase
    {
        public DecompileOperationTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Decompile_generates_valid_bicep_code()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();

            var response = await subscription.BicepDecompileOperationGroupAsync(new DecompileOperationContent("""
            {
              "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
              "contentVersion": "1.0.0.0",
              "metadata": {
                "_generator": {
                  "name": "bicep",
                  "version": "0.36.1.42791",
                  "templateHash": "18309635653390499776"
                }
              },
              "parameters": {
                "foo": {
                  "type": "string"
                }
              },
              "resources": [],
              "outputs": {
                "foo": {
                  "type": "string",
                  "value": "[parameters('foo')]"
                }
              }
            }
            """.Replace("\r\n", "\n")));

            var mainBicep = response.Value.Files.Single(x => x.Path == response.Value.EntryPoint);
            Assert.AreEqual("param foo string\n\noutput foo string = foo\n", mainBicep.Contents);
        }
    }
}
