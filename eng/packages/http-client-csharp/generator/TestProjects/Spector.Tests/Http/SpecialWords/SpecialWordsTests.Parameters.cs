// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using SpecialWords;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.SpecialWords
{
    public partial class SpecialWordsTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ParametersWithAndAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAndAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithAsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAsAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithAssertAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAssertAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithAsyncAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAsyncAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithAwaitAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAwaitAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithBreakAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithBreakAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithClassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithClassAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithConstructorAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithConstructorAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithContinueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithContinueAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithDefAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithDefAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithDelAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithDelAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithElifAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithElifAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithElseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithElseAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithExceptAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithExceptAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithExecAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithExecAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithFinallyAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithFinallyAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithFromAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithFromAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithGlobalAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithGlobalAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithImportAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithImportAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithInAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithInAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithIsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithIsAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithLambdaAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithLambdaAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithNotAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithNotAsync("ok");
            Assert.AreEqual(204, response.Status);
        });


        [SpectorTest]
        public Task ParametersWithOrAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithOrAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithPassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithPassAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithRaiseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithRaiseAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithReturnAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithReturnAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithTryAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithTryAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithIfAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithIfAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithForAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithForAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithWithAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithWithAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithWhileAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithWhileAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithYieldAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithYieldAsync("ok");
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ParametersWithCancellationTokenAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithCancellationTokenAsync("ok");
            Assert.AreEqual(204, response.Status);
        });
    }
}
