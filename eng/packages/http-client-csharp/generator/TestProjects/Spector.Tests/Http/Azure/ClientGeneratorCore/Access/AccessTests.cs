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
            Assert.That(response1.Value.Name, Is.EqualTo("sample"));

            var response2 = await new AccessClient(host, null).GetPublicOperationClient().PublicDecoratorInPublicAsync("sample");
            Assert.Multiple(() =>
            {
                Assert.That(response2.Value.Name, Is.EqualTo("sample"));

                Assert.That(typeof(PublicOperation).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(PublicOperation).GetMethod("NoDecoratorInPublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(PublicOperation).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(PublicOperation).GetMethod("PublicDecoratorInPublic", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(NoDecoratorModelInPublic).IsVisible, Is.True);
                Assert.That(typeof(PublicDecoratorModelInPublic).IsVisible, Is.True);
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_InternalOperation() => Test(async (host) =>
        {
            var internalOperationClient = new AccessClient(host, null).GetInternalOperationClient();
            var response1 = await InvokeMethodAsync(internalOperationClient, "NoDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.That(GetNameValue(response1!), Is.EqualTo("sample"));

            var response2 = await InvokeMethodAsync(internalOperationClient, "InternalDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.That(GetNameValue(response2!), Is.EqualTo("sample"));

            var response3 = await InvokeMethodAsync(internalOperationClient, "PublicDecoratorInInternalAsync", "sample", CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(GetNameValue(response3!), Is.EqualTo("sample"));

                Assert.That(typeof(InternalOperation).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(InternalOperation).GetMethod("NoDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(InternalOperation).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(InternalOperation).GetMethod("InternalDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(InternalOperation).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(InternalOperation).GetMethod("PublicDecoratorInInternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(PublicDecoratorModelInInternal).IsVisible, Is.True);
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_SharedModelInOperation() => Test(async (host) =>
        {
            var response1 = await new AccessClient(host, null).GetSharedModelInOperationClient().PublicAsync("sample");
            Assert.That(response1.Value.Name, Is.EqualTo("sample"));

            var response2 = await InvokeMethodAsync(new AccessClient(host, null).GetSharedModelInOperationClient(), "InternalAsync", "sample", CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(GetNameValue(response2!), Is.EqualTo("sample"));

                Assert.That(typeof(SharedModelInOperation).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(SharedModelInOperation).GetMethod("PublicAsync", BindingFlags.Instance | BindingFlags.Public, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(SharedModelInOperation).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) })!.IsPublic, Is.Not.Null);
                Assert.That(typeof(SharedModelInOperation).GetMethod("InternalAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) })!.IsPublic, Is.Not.Null);

                Assert.That(typeof(SharedModel).IsVisible, Is.True);
            });
        });

        [SpectorTest]
        public Task Azure_ClientGenerator_Core_Access_RelativeModelInOperation() => Test(async (host) =>
        {
            var response1 = await InvokeMethodAsync(new AccessClient(host, null).GetRelativeModelInOperationClient(), "OperationAsync", "Madge", CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(GetNameValue(response1!), Is.EqualTo("Madge"));
                Assert.That(GetInnerNameValue(response1!), Is.EqualTo("Madge"));
            });

            var response2 = await InvokeMethodAsync(new AccessClient(host, null).GetRelativeModelInOperationClient(), "DiscriminatorAsync", "real", CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(GetNameValue(response2!), Is.EqualTo("Madge"));

                Assert.That(typeof(RelativeModelInOperation).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(RelativeModelInOperation).GetMethod("OperationAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);

                Assert.That(typeof(RelativeModelInOperation).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(CancellationToken) }), Is.Not.Null);
                Assert.That(typeof(RelativeModelInOperation).GetMethod("DiscriminatorAsync", BindingFlags.Instance | BindingFlags.NonPublic, new[] { typeof(string), typeof(RequestContext) }), Is.Not.Null);
            });
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