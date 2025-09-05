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
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsAsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AsAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsAssertAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AssertAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsAsyncAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AsyncAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsAwaitAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.AwaitAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsBreakAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.BreakAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsClassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ClassAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsConstructorAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ConstructorAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsContinueAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ContinueAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsDefAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.DefAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsDelAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.DelAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsElifAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ElifAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsElseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ElseAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsExceptAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ExceptAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsExecAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ExecAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsFinallyAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.FinallyAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsForAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ForAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsFromAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.FromAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsGlobalAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.GlobalAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsIfAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.IfAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsImportAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ImportAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsInAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.InAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsIsAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.IsAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsLambdaAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.LambdaAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsNotAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.NotAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsOrAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.OrAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsPassAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.PassAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsRaiseAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.RaiseAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsReturnAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.ReturnAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsWhileAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.WhileAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsTryAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.TryAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsWithAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.WithAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task OperationsYieldAsync() => Test(async (host) =>
        {
            var client = new SpecialWordsClient(host, null).GetOperationsClient();
            var response = await client.YieldAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}
