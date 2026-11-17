// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type.Union.Discriminated.Extends;
using _Type.Union.Discriminated.Extends._CustomDiscriminator;
using _Type.Union.Discriminated.Extends._EnumDiscriminator;
using _Type.Union.Discriminated.Extends._ExplicitDiscriminator;
using _Type.Union.Discriminated.Extends._InjectedDiscriminator;
using _Type.Union.Discriminated.Extends._Recursive;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Union.Discriminated.Extends
{
    public class UnionExtendsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ExplicitDiscriminator() => Test(async host =>
        {
            var client = new ExtendsClient(host, null).GetExplicitDiscriminatorClient().GetExplicitDiscriminatorOperationsClient();
            var cat = await client.GetCatAsync();
            Assert.IsInstanceOf<ExplicitCat>(cat.Value);
            Assert.AreEqual("Whiskers", cat.Value.Name);
            Assert.IsTrue(((ExplicitCat)cat.Value).Meow);
            Assert.AreEqual(204, (await client.PutCatAsync(new ExplicitCat("Whiskers", true))).Status);
            var dog = await client.GetDogAsync();
            Assert.IsInstanceOf<ExplicitDog>(dog.Value);
            Assert.AreEqual("Rex", dog.Value.Name);
            Assert.IsFalse(((ExplicitDog)dog.Value).Bark);
            Assert.AreEqual(204, (await client.PutDogAsync(new ExplicitDog("Rex", false))).Status);
        });

        [SpectorTest]
        public Task InjectedDiscriminator() => Test(async host =>
        {
            var client = new ExtendsClient(host, null).GetInjectedDiscriminatorClient().GetInjectedDiscriminatorOperationsClient();
            var cat = await client.GetCatAsync();
            Assert.IsInstanceOf<InjectedCat>(cat.Value);
            Assert.AreEqual("Whiskers", cat.Value.Name);
            Assert.IsTrue(((InjectedCat)cat.Value).Meow);
            Assert.AreEqual(204, (await client.PutCatAsync(new InjectedCat("Whiskers", true))).Status);
            var dog = await client.GetDogAsync();
            Assert.IsInstanceOf<InjectedDog>(dog.Value);
            Assert.AreEqual("Rex", dog.Value.Name);
            Assert.IsFalse(((InjectedDog)dog.Value).Bark);
            Assert.AreEqual(204, (await client.PutDogAsync(new InjectedDog("Rex", false))).Status);
        });

        [SpectorTest]
        public Task CustomDiscriminator() => Test(async host =>
        {
            var client = new ExtendsClient(host, null).GetCustomDiscriminatorClient().GetCustomDiscriminatorOperationsClient();
            var cat = await client.GetCatAsync();
            Assert.IsInstanceOf<CustomCat>(cat.Value);
            Assert.AreEqual("Whiskers", cat.Value.Name);
            Assert.IsTrue(((CustomCat)cat.Value).Meow);
            Assert.AreEqual(204, (await client.PutCatAsync(new CustomCat("Whiskers", true))).Status);
            var dog = await client.GetDogAsync();
            Assert.IsInstanceOf<CustomDog>(dog.Value);
            Assert.AreEqual("Rex", dog.Value.Name);
            Assert.IsFalse(((CustomDog)dog.Value).Bark);
            Assert.AreEqual(204, (await client.PutDogAsync(new CustomDog("Rex", false))).Status);
        });

        [SpectorTest]
        public Task EnumDiscriminator() => Test(async host =>
        {
            var client = new ExtendsClient(host, null).GetEnumDiscriminatorClient().GetEnumDiscriminatorOperationsClient();
            var cat = await client.GetCatAsync();
            Assert.IsInstanceOf<EnumCat>(cat.Value);
            Assert.AreEqual("Whiskers", cat.Value.Name);
            Assert.IsTrue(((EnumCat)cat.Value).Meow);
            Assert.AreEqual(204, (await client.PutCatAsync(new EnumCat("Whiskers", true))).Status);
            var dog = await client.GetDogAsync();
            Assert.IsInstanceOf<EnumDog>(dog.Value);
            Assert.AreEqual("Rex", dog.Value.Name);
            Assert.IsFalse(((EnumDog)dog.Value).Bark);
            Assert.AreEqual(204, (await client.PutDogAsync(new EnumDog("Rex", false))).Status);
        });

        [SpectorTest]
        public Task RecursiveUnion() => Test(async host =>
        {
            var client = new ExtendsClient(host, null).GetRecursiveClient();
            var response = await client.GetAsync();
            Assert.IsInstanceOf<RecursiveCat>(response.Value);
            Assert.IsTrue(((RecursiveCat)response.Value).Meow);
            Assert.IsInstanceOf<RecursiveDog>(response.Value.Friend);
            Assert.AreEqual("Rex", response.Value.Friend.Name);
            Assert.IsInstanceOf<RecursiveCat>(response.Value.Friends[0]);
            Assert.AreEqual("Kitten", response.Value.Friends[0].Name);
            Assert.IsInstanceOf<RecursiveDog>(response.Value.Lookup["best"]);

            var value = new RecursiveCat("Whiskers", true) { Friend = new RecursiveDog("Rex", false) };
            value.Friends.Add(new RecursiveCat("Kitten", false));
            value.Lookup.Add("best", new RecursiveDog("Rex", false));
            Assert.AreEqual(204, (await client.PutAsync(value)).Status);
        });
    }
}
