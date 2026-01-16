// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using _Type.Model.Inheritance.SingleDiscriminator;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.SingleDiscriminator
{
    public class SingleDiscriminatorTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetModel() => Test(async (host) =>
        {
            var result = await new SingleDiscriminatorClient(host, null).GetModelAsync();
            Assert.That(result.Value is Sparrow, Is.True);
            Assert.That(((Sparrow)result.Value).Wingspan, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task PutModel() => Test(async (host) =>
        {
            var body = new Sparrow(1);
            var response = await new SingleDiscriminatorClient(host, null).PutModelAsync(body);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetRecursiveModel() => Test(async (host) =>
        {
            var result = await new SingleDiscriminatorClient(host, null).GetRecursiveModelAsync();
            Assert.That(result.Value is Eagle, Is.True);
            var eagle = (Eagle)result.Value;
            Assert.That(eagle.Wingspan, Is.EqualTo(5));
            Assert.That(eagle.Partner is Goose, Is.True);
            var goose = (Goose)eagle.Partner;
            Assert.That(goose.Wingspan, Is.EqualTo(2));
            Assert.That(eagle.Friends.Count, Is.EqualTo(1));
            Assert.That(eagle.Friends[0] is SeaGull, Is.True);
            var seaGull = (SeaGull)eagle.Friends[0];
            Assert.That(seaGull.Wingspan, Is.EqualTo(2));
            Assert.That(eagle.Hate.Count, Is.EqualTo(1));
            Assert.That(eagle.Hate.ContainsKey("key3"), Is.True);
            Assert.That(eagle.Hate["key3"] is Sparrow, Is.True);
            var sparrow = (Sparrow)eagle.Hate["key3"];
            Assert.That(sparrow.Wingspan, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task PutRecursiveModel() => Test(async (host) =>
        {
            var body = new Eagle(5)
            {
                Friends = { new SeaGull(2) },
                Hate =
                {
                    ["key3"] = new Sparrow(1)
                },
                Partner = new Goose(2)
            };
            var response = await new SingleDiscriminatorClient(host, null).PutRecursiveModelAsync(body);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetMissingDiscriminator() => Test(async (host) =>
        {
            var result = await new SingleDiscriminatorClient(host, null).GetMissingDiscriminatorAsync();
            Assert.That(result.Value is Bird, Is.True);

            var unknownBirdType = typeof(Bird).Assembly.GetType("_Type.Model.Inheritance.SingleDiscriminator.UnknownBird");
            Assert.That(unknownBirdType, Is.Not.Null);
            Assert.That(result.Value.GetType(), Is.EqualTo(unknownBirdType));
            Assert.That(result.Value.Wingspan, Is.EqualTo(1));

            var kindProperty = result.Value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(kindProperty?.GetValue(result.Value), Is.EqualTo("unknown"));
        });

        [SpectorTest]
        public Task GetWrongDiscriminator() => Test(async (host) =>
        {
            var result = await new SingleDiscriminatorClient(host, null).GetWrongDiscriminatorAsync();
            Assert.That(result.Value is Bird, Is.True);

            var unknownBirdType = typeof(Bird).Assembly.GetType("_Type.Model.Inheritance.SingleDiscriminator.UnknownBird");
            Assert.That(unknownBirdType, Is.Not.Null);
            Assert.That(result.Value.GetType(), Is.EqualTo(unknownBirdType));
            Assert.That(result.Value.Wingspan, Is.EqualTo(1));

            var kindProperty = result.Value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(kindProperty?.GetValue(result.Value), Is.EqualTo("wrongKind"));
        });

        [SpectorTest]
        public Task GetLegacyModel() => Test(async (host) =>
        {
            var result = await new SingleDiscriminatorClient(host, null).GetLegacyModelAsync();
            Assert.That(result.Value is TRex, Is.True);
            Assert.That(((TRex)result.Value).Size, Is.EqualTo(20));
        });
    }
}
