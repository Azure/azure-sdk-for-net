// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using _Type.Model.Inheritance.EnumDiscriminator;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.EnumDiscriminator
{
    public class EnumDiscriminatorTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PutExtensibleEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).PutExtensibleModelAsync(new Golden(10));
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetExtensibleEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(result.Value.Weight, Is.EqualTo(10));
                Assert.That(result.Value, Is.InstanceOf<Golden>());
            });
        });

        [SpectorTest]
        public Task GetExtensibleModelMissingDiscriminator() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelMissingDiscriminatorAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(result.Value, Is.Not.InstanceOf<Golden>());
            });
            Assert.That(result.Value.Weight, Is.EqualTo(10));
        });

        [SpectorTest]
        public Task GetExtensibleModelWrongDiscriminator() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelWrongDiscriminatorAsync();
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));

            var unknownDogType = typeof(Dog).Assembly.DefinedTypes.FirstOrDefault(t => t.Name == "UnknownDog");
            Assert.Multiple(() =>
            {
                Assert.That(unknownDogType, Is.Not.Null);
                Assert.That(result.Value.GetType(), Is.EqualTo(unknownDogType));
                Assert.That(result.Value.Weight, Is.EqualTo(8));
            });
        });

        [SpectorTest]
        public Task PutFixedEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).PutFixedModelAsync(new Cobra(10));
            Assert.That(result.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetFixedEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetFixedModelAsync();
            Assert.Multiple(() =>
            {
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(result.Value.Length, Is.EqualTo(10));
            });
            Assert.That(result.Value, Is.InstanceOf<Cobra>());
        });

        [SpectorTest]
        public Task GetFixedModelMissingDiscriminator() => Test(async (host) =>
        {
            var response = await new EnumDiscriminatorClient(host, null).GetFixedModelMissingDiscriminatorAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));

            var unknownSnakeType = typeof(Snake).Assembly.GetTypes().FirstOrDefault(t => t.Name == "UnknownSnake");
            Assert.Multiple(() =>
            {
                Assert.That(unknownSnakeType, Is.Not.Null);
                Assert.That(response.Value.GetType(), Is.EqualTo(unknownSnakeType));
                Assert.That(response.Value.Length, Is.EqualTo(10));
            });
        });

        [SpectorTest]
        public Task GetFixedModelWrongDiscriminator() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await new EnumDiscriminatorClient(host, null).GetFixedModelWrongDiscriminatorAsync());
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception!.Message, Does.Contain("wrongKind"));
            return Task.CompletedTask;
        });

    }
}
