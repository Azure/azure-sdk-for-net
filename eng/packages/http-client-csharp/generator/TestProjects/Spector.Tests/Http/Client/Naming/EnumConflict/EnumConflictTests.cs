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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Status, Is.EqualTo(Status.Active));
            Assert.That(response.Value.Name, Is.EqualTo("test"));
        });

        [SpectorTest]
        public Task Client_Naming_EnumConflict_second() => Test(async (host) =>
        {
            var secondModel = new SecondModel(SecondStatus.Running, "test description");
            var response = await new EnumConflictClient(host, null).GetSecondOperationsClient().SecondAsync(secondModel);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Status, Is.EqualTo(SecondStatus.Running));
            Assert.That(response.Value.Description, Is.EqualTo("test description"));
        });
    }
}