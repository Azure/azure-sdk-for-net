// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using SpecialWords;
using SpecialWords._ModelProperties;
using SpecialWords._Models;
using SpecialWordsAssert = SpecialWords._Models.Assert;
using SpecialWordsIs = SpecialWords._Models.Is;

namespace TestProjects.Spector.Tests.Http.SpecialWords
{
    public partial class SpecialWordsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ModelsWithAndAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithAndAsync(new And("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithAsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithAsAsync(new As("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithAssertAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithAssertAsync(new SpecialWordsAssert("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithAsyncAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithAsyncAsync(new Async("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithAwaitAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithAwaitAsync(new Await("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithBreakAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithBreakAsync(new Break("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithClassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithClassAsync(new Class("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithConstructorAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithConstructorAsync(new Constructor("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithContinueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithContinueAsync(new Continue("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithDefAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithDefAsync(new Def("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithDelAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithDelAsync(new Del("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithElifAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithElifAsync(new Elif("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithElseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithElseAsync(new Else("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithExceptAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithExceptAsync(new Except("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithExecAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithExecAsync(new Exec("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithFinallyAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithFinallyAsync(new Finally("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithFromAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithFromAsync(new From("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithGlobalAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithGlobalAsync(new Global("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithImportAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithImportAsync(new Import("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithInAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithInAsync(new In("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithIsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithIsAsync(new SpecialWordsIs("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithLambdaAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithLambdaAsync(new Lambda("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithNotAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithNotAsync(new Not("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });


        [SpectorTest]
        public Task ModelsWithOrAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithOrAsync(new Or("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithPassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithPassAsync(new Pass("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithRaiseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithRaiseAsync(new Raise("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithReturnAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithReturnAsync(new Return("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithTryAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithTryAsync(new Try("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithIfAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithIfAsync(new If("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithForAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithForAsync(new For("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithWithAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithWithAsync(new With("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithWhileAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithWhileAsync(new While("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelsWithYieldAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetModelsClient();
            var response = await client.WithYieldAsync(new Yield("ok"));
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelProperties_SameAsModelAsync() => Test(async (host) =>
        {
            SameAsModel body = new SameAsModel("ok");
            var client = new SpecialWordsClient(host, null).GetModelPropertiesClient();
            var response = await client.SameAsModelAsync(body);
            NUnit.Framework.Assert.AreEqual(204, response.Status);
        });
    }
}
