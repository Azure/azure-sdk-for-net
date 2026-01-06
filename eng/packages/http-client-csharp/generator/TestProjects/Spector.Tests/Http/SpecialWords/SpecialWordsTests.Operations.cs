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
        public Task OperationsAndAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AndAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsAsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AsAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsAssertAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AssertAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsAsyncAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AsyncAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsAwaitAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AwaitAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsBreakAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.BreakAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsClassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ClassAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsConstructorAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ConstructorAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsContinueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ContinueAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsDefAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.DefAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsDelAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.DelAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsElifAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ElifAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsElseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ElseAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsExceptAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ExceptAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsExecAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ExecAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsFinallyAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.FinallyAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsForAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ForAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsFromAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.FromAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsGlobalAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.GlobalAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsIfAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.IfAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsImportAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ImportAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsInAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.InAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsIsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.IsAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsLambdaAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.LambdaAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsNotAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.NotAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsOrAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.OrAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsPassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.PassAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsRaiseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.RaiseAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsReturnAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ReturnAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsWhileAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.WhileAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsTryAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.TryAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsWithAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.WithAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task OperationsYieldAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.YieldAsync();
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
