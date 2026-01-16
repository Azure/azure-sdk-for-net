// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _Type.Model.Inheritance.NestedDiscriminator;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.NestedDiscriminator
{
    public class NestedDiscriminatorTests : SpectorTestBase
    {
        [SpectorTest]
        public Task GetMissingDiscriminator() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetMissingDiscriminatorAsync();
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value.Age, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task GetModel() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetModelAsync();
            Assert.That(result.Value, Is.InstanceOf<GoblinShark>());
            Assert.That(result.Value.Age, Is.EqualTo(1));
        });

        [SpectorTest]
        public Task GetRecursiveModel() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetRecursiveModelAsync();
            Assert.That(result.Value, Is.InstanceOf<Salmon>());

            var salmon = (Salmon)result.Value;
            Assert.That(salmon.Age, Is.EqualTo(1));
            Assert.That(salmon.Partner is Shark, Is.True);

            var shark = (Shark)salmon.Partner;
            var sharkTypeProperty = shark.GetType().GetProperty("Sharktype", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(sharkTypeProperty?.GetValue(shark), Is.EqualTo("saw"));
            Assert.That(shark, Is.InstanceOf<SawShark>());
            Assert.That(salmon.Friends.Count, Is.EqualTo(2));
            Assert.That(salmon.Friends[0], Is.InstanceOf<Salmon>());

            var salmonFriend = (Salmon)salmon.Friends[0];
            Assert.That(salmonFriend.Age, Is.EqualTo(2));
            Assert.That(salmonFriend.Hate.Count, Is.EqualTo(2));
            Assert.That(salmon.Hate.ContainsKey("key3"), Is.True);
            Assert.That(salmon.Hate["key3"], Is.InstanceOf<SawShark>());
            Assert.That(salmon.Hate.ContainsKey("key4"), Is.True);
            Assert.That(salmon.Hate["key4"], Is.InstanceOf<Salmon>());
        });

        [SpectorTest]
        public Task GetWrongDiscriminator() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetWrongDiscriminatorAsync();

            var unknownFishType = typeof(Fish).Assembly.GetTypes().FirstOrDefault(t => t.Name == "UnknownFish");
            Assert.That(unknownFishType, Is.Not.Null);
            Assert.That(result.Value.GetType(), Is.EqualTo(unknownFishType));
            Assert.That(result.Value.Age, Is.EqualTo(1));
            var kindProperty = result.Value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(kindProperty?.GetValue(result.Value), Is.EqualTo("wrongKind"));
        });

        [SpectorTest]
        public Task PutModel() => Test(async (host) =>
        {
            var body = new GoblinShark(1);
            var response = await new NestedDiscriminatorClient(host, null).PutModelAsync(body);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task PutRecursiveModel() => Test(async (host) =>
        {
            var body = new Salmon(1)
            {
                Partner = new SawShark(2),
                Friends =
                {
                    new Salmon(2)
                    {
                        Partner = new Salmon(3),
                        Hate = { { "key1", new Salmon(4) }, { "key2", new GoblinShark(2) } }
                    },
                    new GoblinShark(3)
                },
                Hate =
                {
                    { "key3", new SawShark(3) },
                    { "key4", new Salmon(2) { Friends = { new Salmon(1), new GoblinShark(4) } } }
                }
            };
            var response = await new NestedDiscriminatorClient(host, null).PutRecursiveModelAsync(body);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
