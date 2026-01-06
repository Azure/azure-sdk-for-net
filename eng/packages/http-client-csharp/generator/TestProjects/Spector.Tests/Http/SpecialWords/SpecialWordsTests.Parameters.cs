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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithAsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAsAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithAssertAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAssertAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithAsyncAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAsyncAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithAwaitAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithAwaitAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithBreakAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithBreakAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithClassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithClassAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithConstructorAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithConstructorAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithContinueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithContinueAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithDefAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithDefAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithDelAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithDelAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithElifAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithElifAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithElseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithElseAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithExceptAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithExceptAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithExecAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithExecAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithFinallyAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithFinallyAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithFromAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithFromAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithGlobalAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithGlobalAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithImportAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithImportAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithInAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithInAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithIsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithIsAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithLambdaAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithLambdaAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithNotAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithNotAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });


        [SpectorTest]
        public Task ParametersWithOrAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithOrAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithPassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithPassAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithRaiseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithRaiseAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithReturnAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithReturnAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithTryAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithTryAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithIfAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithIfAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithForAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithForAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithWithAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithWithAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithWhileAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithWhileAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithYieldAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithYieldAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ParametersWithCancellationTokenAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetParametersClient();
            var response = await client.WithCancellationTokenAsync("ok");
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
