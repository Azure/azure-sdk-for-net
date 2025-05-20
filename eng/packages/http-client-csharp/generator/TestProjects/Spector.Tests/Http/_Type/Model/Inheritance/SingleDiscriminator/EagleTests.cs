// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.IO;
using _Type.Model.Inheritance.SingleDiscriminator;
using Azure;
using Azure.Core;
using Azure.Generator.Tests.Common;
using NUnit.Framework;
using TestProjects.Spector.Tests.Infrastructure;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.SingleDiscriminator
{
    internal class EagleTests : SpectorModelJsonTests<Eagle>
    {
        protected override string JsonPayload => File.ReadAllText(ModelTestHelper.GetLocation("TestData/Eagle/Eagle.json"));

        protected override string WirePayload => File.ReadAllText(ModelTestHelper.GetLocation("TestData/Eagle/EagleWire.json"));

        protected override void CompareModels(Eagle model, Eagle model2, string format)
        {
            Assert.AreEqual(model.Wingspan, model2.Wingspan);
            Assert.AreEqual(model.Partner.Wingspan, model2.Partner.Wingspan);
            Assert.AreEqual(model.Partner.GetType(), model2.Partner.GetType());
            Assert.AreEqual(model.Friends.Count, model2.Friends.Count);
            Assert.AreEqual(model.Friends[0].Wingspan, model2.Friends[0].Wingspan);
            Assert.AreEqual(model.Friends[0].GetType(), model2.Friends[0].GetType());
            Assert.AreEqual(model.Hate.Count, model2.Hate.Count);
            Assert.AreEqual(model.Hate["key3"].Wingspan, model2.Hate["key3"].Wingspan);
            Assert.AreEqual(model.Hate["key3"].GetType(), model2.Hate["key3"].GetType());
        }

        protected override RequestContent ToRequestContent(Eagle model) => model;

        protected override Eagle ToModel(Response response) => (Eagle)response;

        protected override void VerifyModel(Eagle model, string format)
        {
            Assert.AreEqual(5, model.Wingspan);
            Assert.AreEqual(2, model.Partner.Wingspan);
            Assert.IsTrue(model.Partner is Goose);
            Assert.AreEqual(1, model.Friends.Count);
            Assert.AreEqual(2, model.Friends[0].Wingspan);
            Assert.IsTrue(model.Friends[0] is SeaGull);
            Assert.AreEqual(1, model.Hate.Count);
            Assert.AreEqual(1, model.Hate["key3"].Wingspan);
            Assert.IsTrue(model.Hate["key3"] is Sparrow);
        }
    }
}
