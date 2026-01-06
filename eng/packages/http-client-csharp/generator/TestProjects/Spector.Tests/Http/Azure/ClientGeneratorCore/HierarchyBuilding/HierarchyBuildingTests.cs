// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.HierarchyBuilding;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.HierarchyBuilding
{
    public class HierarchyBuilding : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsAnimal() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdateDogAsAnimalAsync(dog);
            dog = response1.Value as Dog;
            Assert.That(dog, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(dog!.Name, Is.EqualTo("Rex"));
                Assert.That(dog.Breed, Is.EqualTo("German Shepherd"));
                Assert.That(dog.Trained, Is.True);
                Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdatePetAsAnimal() => Test(async (host) =>
        {
            var pet = new Pet("Buddy", true);
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdatePetAsAnimalAsync(pet);
            pet = response1.Value as Pet;
            Assert.That(pet, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(pet!.Name, Is.EqualTo("Buddy"));
                Assert.That(pet.Trained, Is.True);
                Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsDog() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetDogOperationsClient().UpdateDogAsDogAsync(dog);
            dog = response1.Value as Dog;
            Assert.That(dog, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(dog!.Name, Is.EqualTo("Rex"));
                Assert.That(dog.Breed, Is.EqualTo("German Shepherd"));
                Assert.That(dog.Trained, Is.True);
                Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdateDogAsPet() => Test(async (host) =>
        {
            var dog = new Dog("Rex", true, "German Shepherd");
            var response1 = await new HierarchyBuildingClient(host, null).GetAnimalOperationsClient().UpdateDogAsAnimalAsync(dog);
            dog = response1.Value as Dog;
            Assert.That(dog, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(dog!.Name, Is.EqualTo("Rex"));
                Assert.That(dog.Breed, Is.EqualTo("German Shepherd"));
                Assert.That(dog.Trained, Is.True);
                Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_HierarchyBuilding_UpdatePetAsPet() => Test(async (host) =>
        {
            var pet = new Pet("Buddy", true);
            var response1 = await new HierarchyBuildingClient(host, null).GetPetOperationsClient().UpdatePetAsPetAsync(pet);
            pet = response1.Value as Pet;
            Assert.That(pet, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(pet!.Name, Is.EqualTo("Buddy"));
                Assert.That(pet.Trained, Is.True);
                Assert.That(response1.GetRawResponse().Status, Is.EqualTo(200));
            });
        });
    }
}