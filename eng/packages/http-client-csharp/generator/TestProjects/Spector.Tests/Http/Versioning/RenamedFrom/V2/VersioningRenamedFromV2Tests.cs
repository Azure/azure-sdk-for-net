// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RenamedFromV2;
using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RenamedFromV2::Versioning.RenamedFrom;

namespace TestProjects.Spector.Tests.Http.Versioning.RenamedFrom.V2
{
    public class VersioningRenamedFromTests : SpectorTestBase
    {
        [SpectorTest]
        public void TestRenamedMembers()
        {
            var assembly = typeof(RenamedFromClient).Assembly;
            /* check the renamed model from `OldModel` to `NewModel` */
            var oldModel = assembly.GetType("Versioning.RenamedFrom.OldModel");
            Assert.That(oldModel, Is.Null);
            var newModel = assembly.GetType("Versioning.RenamedFrom.NewModel");
            Assert.That(newModel, Is.Not.Null);

            /* check the renamed property of model */
            var properties = typeof(NewModel).GetProperties();
            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Length, Is.EqualTo(3));
            Assert.That(typeof(NewModel).GetProperty("OldProp"), Is.Null);
            Assert.That(typeof(NewModel).GetProperty("NewProp"), Is.Not.Null);

            /* check the renamed enum from `OldEnum` to `NewEnum` */
            var oldEnum = assembly.GetType("Versioning.RenamedFrom.OldEnum");
            Assert.That(oldEnum, Is.Null);
            var newEnum = assembly.GetType("Versioning.RenamedFrom.NewEnum");
            Assert.That(newEnum, Is.Not.Null);

            /* check the renamed enum value */
            var enumValues = typeof(NewEnum).GetEnumNames();
            Assert.That(enumValues, Is.Not.Null);
            Assert.That(enumValues.Length, Is.EqualTo(1));
            Assert.That(enumValues.Contains("OldEnumMember"), Is.False);
            Assert.That(enumValues.Contains("NewEnumMember"), Is.True);

            /* check the renamed operation */
            var oldMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "OldOp" || m.Name == "OldOpAsync");
            Assert.That(oldMethods.Count(), Is.EqualTo(0));
            var newMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "NewOp" || m.Name == "NewOpAsync");
            Assert.That(newMethods.Count(), Is.EqualTo(4));

            /* check the renamed interface */
            var oldInterface = assembly.GetType("Versioning.RenamedFrom.OldInterface");
            Assert.That(oldInterface, Is.Null);
            var newInterface = assembly.GetType("Versioning.RenamedFrom.NewInterface");
            Assert.That(newInterface, Is.Not.Null);
        }

        [SpectorTest]
        public Task Versioning_RenamedFrom_NewOp() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).NewOpAsync("bar", body);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.NewProp, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(NewEnum.NewEnumMember));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<int>(), Is.EqualTo(10));
        });

        [SpectorTest]
        public Task Versioning_RenamedFrom_NewInterface() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).GetNewInterfaceClient().NewOpInNewInterfaceAsync(body);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.NewProp, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(NewEnum.NewEnumMember));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<int>(), Is.EqualTo(10));
        });
    }
}
