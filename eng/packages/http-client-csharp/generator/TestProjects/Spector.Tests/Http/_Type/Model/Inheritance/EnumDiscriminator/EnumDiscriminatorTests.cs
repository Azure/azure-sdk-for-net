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
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task GetExtensibleEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(10, result.Value.Weight);
            Assert.IsInstanceOf<Golden>(result.Value);
        });

        [SpectorTest]
        public Task GetExtensibleModelMissingDiscriminator() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelMissingDiscriminatorAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.IsNotInstanceOf<Golden>(result.Value);
            Assert.AreEqual(10, result.Value.Weight);
        });

        [SpectorTest]
        public Task GetExtensibleModelWrongDiscriminator() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetExtensibleModelWrongDiscriminatorAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);

            var unknownDogType = typeof(Dog).Assembly.DefinedTypes.FirstOrDefault(t => t.Name == "UnknownDog");
            Assert.IsNotNull(unknownDogType);
            Assert.AreEqual(unknownDogType, result.Value.GetType());
            Assert.AreEqual(8, result.Value.Weight);
        });

        [SpectorTest]
        public Task PutFixedEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).PutFixedModelAsync(new Cobra(10));
            Assert.AreEqual(204, result.Status);
        });

        [SpectorTest]
        public Task GetFixedEnum() => Test(async (host) =>
        {
            var result = await new EnumDiscriminatorClient(host, null).GetFixedModelAsync();
            Assert.AreEqual(200, result.GetRawResponse().Status);
            Assert.AreEqual(10, result.Value.Length);
            Assert.IsInstanceOf<Cobra>(result.Value);
        });

        [SpectorTest]
        public Task GetFixedModelMissingDiscriminator() => Test(async (host) =>
        {
            var response = await new EnumDiscriminatorClient(host, null).GetFixedModelMissingDiscriminatorAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);

            var unknownSnakeType = typeof(Snake).Assembly.GetTypes().FirstOrDefault(t => t.Name == "UnknownSnake");
            Assert.IsNotNull(unknownSnakeType);
            Assert.AreEqual(unknownSnakeType, response.Value.GetType());
            Assert.AreEqual(10, response.Value.Length);
        });

        [SpectorTest]
        public Task GetFixedModelWrongDiscriminator() => Test((host) =>
        {
            var exception = Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await new EnumDiscriminatorClient(host, null).GetFixedModelWrongDiscriminatorAsync());
            Assert.IsNotNull(exception);
            Assert.IsTrue(exception!.Message.Contains("wrongKind"));
            return Task.CompletedTask;
        });

    }
}
