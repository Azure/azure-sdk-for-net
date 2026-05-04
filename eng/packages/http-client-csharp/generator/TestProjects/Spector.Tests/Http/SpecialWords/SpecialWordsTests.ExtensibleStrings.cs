// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using SpecialWords;
using SpecialWords._ExtensibleStrings;

namespace TestProjects.Spector.Tests.Http.SpecialWords
{
    public partial class SpecialWordsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ExtensibleStringsPutExtensibleStringValueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetExtensibleStringsClient();
            var response = await client.PutExtensibleStringValueAsync(ExtensibleString.Class);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(ExtensibleString.Class, response.Value);
        });
    }
}
