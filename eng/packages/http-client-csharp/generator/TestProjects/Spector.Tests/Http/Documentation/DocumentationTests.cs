// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Documentation;
using Documentation._Lists;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Documentation
{
    public class DocumentationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Documentation_Lists_BulletPointsOp() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetListsClient().BulletPointsOpAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Documentation_Lists_BulletPointsModel() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetListsClient().BulletPointsModelAsync(new BulletPointsModel(BulletPointsEnum.Simple));
            Assert.AreEqual(200, response.Status);
        });

        [SpectorTest]
        public Task Documentation_Lists_Numbered() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetListsClient().NumberedAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Documentation_TextFormatting_BoldText() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetTextFormattingClient().BoldTextAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Documentation_TextFormatting_ItalicText() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetTextFormattingClient().ItalicTextAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Documentation_TextFormatting_CombinedFormatting() => Test(async (host) =>
        {
            var response = await new DocumentationClient(host, null).GetTextFormattingClient().CombinedFormattingAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
