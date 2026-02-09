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
            Assert.IsNull(oldModel);
            var newModel = assembly.GetType("Versioning.RenamedFrom.NewModel");
            Assert.IsNotNull(newModel);

            /* check the renamed property of model */
            var properties = typeof(NewModel).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            Assert.IsNull(typeof(NewModel).GetProperty("OldProp"));
            Assert.IsNotNull(typeof(NewModel).GetProperty("NewProp"));

            /* check the renamed enum from `OldEnum` to `NewEnum` */
            var oldEnum = assembly.GetType("Versioning.RenamedFrom.OldEnum");
            Assert.IsNull(oldEnum);
            var newEnum = assembly.GetType("Versioning.RenamedFrom.NewEnum");
            Assert.IsNotNull(newEnum);

            /* check the renamed enum value */
            var enumValues = typeof(NewEnum).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            Assert.IsFalse(enumValues.Contains("OldEnumMember"));
            Assert.IsTrue(enumValues.Contains("NewEnumMember"));

            /* check the renamed operation */
            var oldMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "OldOp" || m.Name == "OldOpAsync");
            Assert.AreEqual(0, oldMethods.Count());
            var newMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "NewOp" || m.Name == "NewOpAsync");
            Assert.AreEqual(4, newMethods.Count());

            /* check the renamed interface */
            var oldInterface = assembly.GetType("Versioning.RenamedFrom.OldInterface");
            Assert.IsNull(oldInterface);
            var newInterface = assembly.GetType("Versioning.RenamedFrom.NewInterface");
            Assert.IsNotNull(newInterface);
        }

        [SpectorTest]
        public Task Versioning_RenamedFrom_NewOp() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).NewOpAsync("bar", body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.NewProp);
            Assert.AreEqual(NewEnum.NewEnumMember, response.Value.EnumProp);
            Assert.AreEqual(10, response.Value.UnionProp.ToObjectFromJson<int>());
        });

        [SpectorTest]
        public Task Versioning_RenamedFrom_NewInterface() => Test(async (host) =>
        {
            NewModel body = new NewModel("foo", NewEnum.NewEnumMember, BinaryData.FromObjectAsJson(10));
            var response = await new RenamedFromClient(host).GetNewInterfaceClient().NewOpInNewInterfaceAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.NewProp);
            Assert.AreEqual(NewEnum.NewEnumMember, response.Value.EnumProp);
            Assert.AreEqual(10, response.Value.UnionProp.ToObjectFromJson<int>());
        });
    }
}
