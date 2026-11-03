// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Encode.Boolean;
using Encode.Boolean._Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Boolean
{
    public class EncodeBooleanTests : SpectorTestBase
    {
        [SpectorTest]
        public Task PropertyTrueLower() => Test(async (host) =>
        {
            var response = await new BooleanClient(host, null).GetPropertyClient().TrueLowerAsync(new BoolAsStringProperty(true));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsTrue(response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyFalseLower() => Test(async (host) =>
        {
            var response = await new BooleanClient(host, null).GetPropertyClient().FalseLowerAsync(new BoolAsStringProperty(false));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyTrueUpper() => Test(async (host) =>
        {
            var response = await new BooleanClient(host, null).GetPropertyClient().TrueUpperAsync(new BoolAsStringProperty(true));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsTrue(response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyFalseMixed() => Test(async (host) =>
        {
            var response = await new BooleanClient(host, null).GetPropertyClient().FalseMixedAsync(new BoolAsStringProperty(false));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsFalse(response.Value.Value);
        });
    }
}
