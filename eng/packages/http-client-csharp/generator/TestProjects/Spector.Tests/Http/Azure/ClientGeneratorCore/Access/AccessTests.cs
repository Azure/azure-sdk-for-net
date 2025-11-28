// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Specs.Azure.ClientGenerator.Core.Access;
using Azure;
using NUnit.Framework;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Specs.Azure.ClientGenerator.Core.Access._InternalOperation;
using Specs.Azure.ClientGenerator.Core.Access._PublicOperation;
using Specs.Azure.ClientGenerator.Core.Access._RelativeModelInOperation;
using Specs.Azure.ClientGenerator.Core.Access._SharedModelInOperation;

namespace TestProjects.Spector.Tests.Http.Azure.ClientGeneratorCore.Access
{
    public class AccessTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_PublicOperation() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetPublicOperationClient().NoDecoratorInPublicAsync("sample");
            Assert.AreEqual("sample", response1.Value.Name);

            var response2 = await new AccessClient(host, null).GetPublicOperationClient().PublicDecoratorInPublicAsync("sample");
            Assert.AreEqual("sample", response2.Value.Name);

            Assert.IsNotNull(typeof(PublicOperation).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(PublicOperation).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(PublicOperation).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(PublicOperation).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsTrue(typeof(NoDecoratorModelInPublic).IsVisible);
            Assert.IsTrue(typeof(PublicDecoratorModelInPublic).IsVisible);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_InternalOperation() => Test(async (host) =>
        {
            var internalOperationClient = new AccessClient(host, null).GetInternalOperationClient();
            var response1 = await InvokeMethodAsync(internalOperationClient, "NoDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.AreEqual("sample", GetNameValue(response1!));

            var response2 = await InvokeMethodAsync(internalOperationClient, "InternalDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.AreEqual("sample", GetNameValue(response2!));

            var response3 = await InvokeMethodAsync(internalOperationClient, "PublicDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.AreEqual("sample", GetNameValue(response3!));

            Assert.IsNotNull(typeof(InternalOperation).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(InternalOperation).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(InternalOperation).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(InternalOperation).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(InternalOperation).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(InternalOperation).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsTrue(typeof(PublicDecoratorModelInInternal).IsVisible);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_SharedModelInOperation() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetSharedModelInOperationClient().PublicAsync("sample");
            Assert.AreEqual("sample", response1.Value.Name);

            var response2 = await InvokeMethodAsync(new AccessClient(host, null).GetSharedModelInOperationClient(), "InternalAsync", "sample", CancellationToken.None);
            Assert.AreEqual("sample", GetNameValue(response2!));

            Assert.IsNotNull(typeof(SharedModelInOperation).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(SharedModelInOperation).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(SharedModelInOperation).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) })!.IsPublic);
            Assert.IsNotNull(typeof(SharedModelInOperation).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) })!.IsPublic);

            Assert.IsTrue(typeof(SharedModel).IsVisible);
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_RelativeModelInOperation() => Test(async (host) =>
        {
            var response1 = await InvokeMethodAsync(new AccessClient(host, null).GetRelativeModelInOperationClient(), "OperationAsync", "Madge", CancellationToken.None);
            Assert.AreEqual("Madge", GetNameValue(response1!));
            Assert.AreEqual("Madge", GetInnerNameValue(response1!));

            var response2 = await InvokeMethodAsync(new AccessClient(host, null).GetRelativeModelInOperationClient(), "DiscriminatorAsync", "real", CancellationToken.None);
            Assert.AreEqual("Madge", GetNameValue(response2!));

            Assert.IsNotNull(typeof(RelativeModelInOperation).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(RelativeModelInOperation).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));

            Assert.IsNotNull(typeof(RelativeModelInOperation).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }));
            Assert.IsNotNull(typeof(RelativeModelInOperation).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }));
        });


        private static object GetNameValue(object response)
        {
            object model = response.GetType().GetProperty("Value")!.GetValue(response)!;
            return model.GetType().GetProperty("Name")!.GetValue(model)!;
        }

        private static object GetInnerNameValue(object response)
        {
            object model = response.GetType().GetProperty("Value")!.GetValue(response)!;
            object innerModel = model.GetType().GetProperty("Inner")!.GetValue(model)!;
            return innerModel.GetType().GetProperty("Name")!.GetValue(innerModel)!;
        }
    }
}