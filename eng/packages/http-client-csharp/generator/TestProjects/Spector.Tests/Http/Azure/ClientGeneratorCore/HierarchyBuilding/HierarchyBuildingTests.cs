// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Threading.Tasks;
using _Specs_.Azure.ClientGenerator.Core.HierarchyBuilding;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.HierarchyBuilding
{
    public class HierarchyBuilding : SpectorTestBase
    {
        [SpectorTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/51958")]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsAnimal() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdateDogAsAnimalAsync(dog);
            dog = response1.Value as Dog;
            Assert.IsNotNull(dog);
            Assert.AreEqual("Rex", dog!.Name);
            Assert.AreEqual("German Shepherd", dog.Breed);
            Assert.IsTrue(dog.Trained);
            Assert.AreEqual(200, response1.GetRawResponse().Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/51958")]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdatePetAsAnimal() => Test(async (host) =>
        {
            var pet = new Pet("Buddy", true);
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdatePetAsAnimalAsync(pet);
            pet = response1.Value as Pet;
            Assert.IsNotNull(pet);
            Assert.AreEqual("Buddy", pet!.Name);
            Assert.IsTrue(pet.Trained);
            Assert.AreEqual(200, response1.GetRawResponse().Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/51958")]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsDog() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetDogOperationsClient().UpdateDogAsDogAsync(dog);
            dog = response1.Value as Dog;
            Assert.IsNotNull(dog);
            Assert.AreEqual("Rex", dog!.Name);
            Assert.AreEqual("German Shepherd", dog.Breed);
            Assert.IsTrue(dog.Trained);
            Assert.AreEqual(200, response1.GetRawResponse().Status);
        });

        [SpectorTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/51958")]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsPet() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdateDogAsAnimalAsync(dog);
            dog = response1.Value as Dog;
            Assert.IsNotNull(dog);
            Assert.AreEqual("Rex", dog!.Name);
            Assert.AreEqual("German Shepherd", dog.Breed);
            Assert.IsTrue(dog.Trained);
            Assert.AreEqual(200, response1.GetRawResponse().Status);
        });
    }
}