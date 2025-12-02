// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.Usage;
using Specs.Azure.ClientGenerator.Core.Usage._ModelInOperation;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Usage
{
    public class UsageTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Usage_ModelInOperation() => Test(async (host) =>
        {
            var response1 = await new UsageClient(host, null).GetModelInOperationClient().InputToInputOutputAsync(new InputModel("Madge"));
            Assert.AreEqual(204, response1.Status);

            var response2 = await new UsageClient(host, null).GetModelInOperationClient().OutputToInputOutputAsync();
            Assert.AreEqual("Madge", response2.Value.Name);

            var response3 = await new UsageClient(host, null).GetModelInOperationClient().ModelInReadOnlyPropertyAsync(new RoundTripModel());
            Assert.AreEqual("Madge", response3.Value.Result.Name);

            var response4 = await new UsageClient(host, null).GetModelInOperationClient().OrphanModelSerializableAsync(
                BinaryData.FromObjectAsJson(
                    new
                    {
                        name = "name",
                        desc = "desc"
                    }));
            Assert.AreEqual(204, response4.Status);
        });
    }
}