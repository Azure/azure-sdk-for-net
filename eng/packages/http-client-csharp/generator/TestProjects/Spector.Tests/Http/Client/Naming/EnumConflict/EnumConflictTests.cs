// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.Naming.EnumConflict;
using Client.Naming.EnumConflict.FirstNamespace;
using Client.Naming.EnumConflict.SecondNamespace;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Naming.EnumConflict
{
    public class EnumConflictTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Client_Naming_EnumConflict_first() => Test(async (host) =>
        {
            var firstModel = new FirstModel(Status.Active, "test");
            var response = await new EnumConflictClient(host, null).GetFirstOperationsClient().FirstAsync(firstModel);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(Status.Active, response.Value.Status);
            Assert.AreEqual("test", response.Value.Name);
        });

        [SpectorTest]
        public Task Client_Naming_EnumConflict_second() => Test(async (host) =>
        {
            var secondModel = new SecondModel(SecondStatus.Running, "test description");
            var response = await new EnumConflictClient(host, null).GetSecondOperationsClient().SecondAsync(secondModel);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(SecondStatus.Running, response.Value.Status);
            Assert.AreEqual("test description", response.Value.Description);
        });
    }
}