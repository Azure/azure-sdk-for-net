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
            Assert.Multiple(() =>
            {
                Assert.That(model2.Wingspan, Is.EqualTo(model.Wingspan));
                Assert.That(model2.Partner.Wingspan, Is.EqualTo(model.Partner.Wingspan));
                Assert.That(model2.Partner.GetType(), Is.EqualTo(model.Partner.GetType()));
                Assert.That(model2.Friends.Count, Is.EqualTo(model.Friends.Count));
            });
            Assert.Multiple(() =>
            {
                Assert.That(model2.Friends[0].Wingspan, Is.EqualTo(model.Friends[0].Wingspan));
                Assert.That(model2.Friends[0].GetType(), Is.EqualTo(model.Friends[0].GetType()));
                Assert.That(model2.Hate.Count, Is.EqualTo(model.Hate.Count));
            });
            Assert.Multiple(() =>
            {
                Assert.That(model2.Hate["key3"].Wingspan, Is.EqualTo(model.Hate["key3"].Wingspan));
                Assert.That(model2.Hate["key3"].GetType(), Is.EqualTo(model.Hate["key3"].GetType()));
            });
        }

        protected override RequestContent ToRequestContent(Eagle model) => model;

        protected override Eagle ToModel(Response response) => (Eagle)response;

        protected override void VerifyModel(Eagle model, string format)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model.Wingspan, Is.EqualTo(5));
                Assert.That(model.Partner.Wingspan, Is.EqualTo(2));
                Assert.That(model.Partner is Goose, Is.True);
                Assert.That(model.Friends.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Friends[0].Wingspan, Is.EqualTo(2));
                Assert.That(model.Friends[0] is SeaGull, Is.True);
                Assert.That(model.Hate.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Hate["key3"].Wingspan, Is.EqualTo(1));
                Assert.That(model.Hate["key3"] is Sparrow, Is.True);
            });
        }
    }
}
