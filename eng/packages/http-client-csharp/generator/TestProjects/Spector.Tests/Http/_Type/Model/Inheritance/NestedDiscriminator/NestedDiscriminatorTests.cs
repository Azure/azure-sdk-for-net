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
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(1, result.Value.Age);
        });

        [SpectorTest]
        public Task GetModel() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetModelAsync();
            Assert.IsInstanceOf<GoblinShark>(result.Value);
            Assert.AreEqual(1, result.Value.Age);
        });

        [SpectorTest]
        public Task GetRecursiveModel() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetRecursiveModelAsync();
            Assert.IsInstanceOf<Salmon>(result.Value);

            var salmon = (Salmon)result.Value;
            Assert.AreEqual(1, salmon.Age);
            Assert.IsTrue(salmon.Partner is Shark);

            var shark = (Shark)salmon.Partner;
            var sharkTypeProperty = shark.GetType().GetProperty("Sharktype", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("saw", sharkTypeProperty?.GetValue(shark));
            Assert.IsInstanceOf<SawShark>(shark);
            Assert.AreEqual(2, salmon.Friends.Count);
            Assert.IsInstanceOf<Salmon>(salmon.Friends[0]);

            var salmonFriend = (Salmon)salmon.Friends[0];
            Assert.AreEqual(2, salmonFriend.Age);
            Assert.AreEqual(2, salmonFriend.Hate.Count);
            Assert.IsTrue(salmon.Hate.ContainsKey("key3"));
            Assert.IsInstanceOf<SawShark>(salmon.Hate["key3"]);
            Assert.IsTrue(salmon.Hate.ContainsKey("key4"));
            Assert.IsInstanceOf<Salmon>(salmon.Hate["key4"]);
        });

        [SpectorTest]
        public Task GetWrongDiscriminator() => Test(async (host) =>
        {
            var result = await new NestedDiscriminatorClient(host, null).GetWrongDiscriminatorAsync();

            var unknownFishType = typeof(Fish).Assembly.GetTypes().FirstOrDefault(t => t.Name == "UnknownFish");
            Assert.IsNotNull(unknownFishType);
            Assert.AreEqual(unknownFishType, result.Value.GetType());
            Assert.AreEqual(1, result.Value.Age);
            var kindProperty = result.Value.GetType().GetProperty("Kind", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.AreEqual("wrongKind", kindProperty?.GetValue(result.Value));
        });

        [SpectorTest]
        public Task PutModel() => Test(async (host) =>
        {
            var body = new GoblinShark(1);
            var response = await new NestedDiscriminatorClient(host, null).PutModelAsync(body);
            Assert.AreEqual(204, response.Status);
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
            Assert.AreEqual(204, response.Status);
        });
    }
}
