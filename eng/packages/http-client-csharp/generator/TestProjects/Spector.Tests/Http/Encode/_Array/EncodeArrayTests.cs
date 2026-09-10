// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Encode._Array;
using Encode._Array._Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode._Array
{
    public class EncodeArrayTests : SpectorTestBase
    {
        [SpectorTest]
        public Task EncodeArrayPropertyCommaDelimited() => Test(async (host) =>
        {
            var value = new[] { "blue", "red", "green" };
            var response = await new ArrayClient(host, null).GetPropertyClient().CommaDelimitedAsync(new CommaDelimitedArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertySpaceDelimited() => Test(async (host) =>
        {
            var value = new[] { "blue", "red", "green" };
            var response = await new ArrayClient(host, null).GetPropertyClient().SpaceDelimitedAsync(new SpaceDelimitedArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyPipeDelimited() => Test(async (host) =>
        {
            var value = new[] { "blue", "red", "green" };
            var response = await new ArrayClient(host, null).GetPropertyClient().PipeDelimitedAsync(new PipeDelimitedArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyNewlineDelimited() => Test(async (host) =>
        {
            var value = new[] { "blue", "red", "green" };
            var response = await new ArrayClient(host, null).GetPropertyClient().NewlineDelimitedAsync(new NewlineDelimitedArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyEnumCommaDelimited() => Test(async (host) =>
        {
            var value = new[] { Colors.Blue, Colors.Red, Colors.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().EnumCommaDelimitedAsync(new CommaDelimitedEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyEnumSpaceDelimited() => Test(async (host) =>
        {
            var value = new[] { Colors.Blue, Colors.Red, Colors.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().EnumSpaceDelimitedAsync(new SpaceDelimitedEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyEnumPipeDelimited() => Test(async (host) =>
        {
            var value = new[] { Colors.Blue, Colors.Red, Colors.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().EnumPipeDelimitedAsync(new PipeDelimitedEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyEnumNewlineDelimited() => Test(async (host) =>
        {
            var value = new[] { Colors.Blue, Colors.Red, Colors.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().EnumNewlineDelimitedAsync(new NewlineDelimitedEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyExtensibleEnumCommaDelimited() => Test(async (host) =>
        {
            var value = new[] { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().ExtensibleEnumCommaDelimitedAsync(new CommaDelimitedExtensibleEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyExtensibleEnumSpaceDelimited() => Test(async (host) =>
        {
            var value = new[] { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().ExtensibleEnumSpaceDelimitedAsync(new SpaceDelimitedExtensibleEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyExtensibleEnumPipeDelimited() => Test(async (host) =>
        {
            var value = new[] { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().ExtensibleEnumPipeDelimitedAsync(new PipeDelimitedExtensibleEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });

        [SpectorTest]
        public Task EncodeArrayPropertyExtensibleEnumNewlineDelimited() => Test(async (host) =>
        {
            var value = new[] { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green };
            var response = await new ArrayClient(host, null).GetPropertyClient().ExtensibleEnumNewlineDelimitedAsync(new NewlineDelimitedExtensibleEnumArrayProperty(value));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(value, response.Value.Value);
        });
    }
}
