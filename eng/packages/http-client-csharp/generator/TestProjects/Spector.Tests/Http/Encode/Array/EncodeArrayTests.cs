// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Encode._Array;
using Encode._Array._Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Array
{
    public class EncodeArrayTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Property_CommaDelimited() => Test(async (host) =>
        {
            var body = new CommaDelimitedArrayProperty(new List<string> { "blue", "red", "green" });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().CommaDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_SpaceDelimited() => Test(async (host) =>
        {
            var body = new SpaceDelimitedArrayProperty(new List<string> { "blue", "red", "green" });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().SpaceDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_PipeDelimited() => Test(async (host) =>
        {
            var body = new PipeDelimitedArrayProperty(new List<string> { "blue", "red", "green" });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().PipeDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_NewlineDelimited() => Test(async (host) =>
        {
            var body = new NewlineDelimitedArrayProperty(new List<string> { "blue", "red", "green" });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().NewlineDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_EnumCommaDelimited() => Test(async (host) =>
        {
            var body = new CommaDelimitedEnumArrayProperty(new List<Colors> { Colors.Blue, Colors.Red, Colors.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().EnumCommaDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_EnumSpaceDelimited() => Test(async (host) =>
        {
            var body = new SpaceDelimitedEnumArrayProperty(new List<Colors> { Colors.Blue, Colors.Red, Colors.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().EnumSpaceDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_EnumPipeDelimited() => Test(async (host) =>
        {
            var body = new PipeDelimitedEnumArrayProperty(new List<Colors> { Colors.Blue, Colors.Red, Colors.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().EnumPipeDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_EnumNewlineDelimited() => Test(async (host) =>
        {
            var body = new NewlineDelimitedEnumArrayProperty(new List<Colors> { Colors.Blue, Colors.Red, Colors.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().EnumNewlineDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_ExtensibleEnumCommaDelimited() => Test(async (host) =>
        {
            var body = new CommaDelimitedExtensibleEnumArrayProperty(new List<ColorsExtensibleEnum> { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().ExtensibleEnumCommaDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_ExtensibleEnumSpaceDelimited() => Test(async (host) =>
        {
            var body = new SpaceDelimitedExtensibleEnumArrayProperty(new List<ColorsExtensibleEnum> { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().ExtensibleEnumSpaceDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_ExtensibleEnumPipeDelimited() => Test(async (host) =>
        {
            var body = new PipeDelimitedExtensibleEnumArrayProperty(new List<ColorsExtensibleEnum> { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().ExtensibleEnumPipeDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task Property_ExtensibleEnumNewlineDelimited() => Test(async (host) =>
        {
            var body = new NewlineDelimitedExtensibleEnumArrayProperty(new List<ColorsExtensibleEnum> { ColorsExtensibleEnum.Blue, ColorsExtensibleEnum.Red, ColorsExtensibleEnum.Green });
            var response = await new ArrayClient(host, new ArrayClientOptions()).GetPropertyClient().ExtensibleEnumNewlineDelimitedAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            CollectionAssert.AreEqual(body.Value, response.Value.Value);
        });
    }
}
