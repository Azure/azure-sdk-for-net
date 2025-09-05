// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class OperationSourceProviderTests
    {
        [TestCase]
        public void Verify_CreateResult()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResult");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.None));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.Name, "ResponseTypeResource");

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        [TestCase]
        public void Verify_CreateResultAsync()
        {
            var validateIdMethod = GetOperationSourceProviderMethodByName("CreateResultAsync");

            // verify the method signature
            var signature = validateIdMethod.Signature;
            Assert.IsTrue(signature.Modifiers.Equals(MethodSignatureModifiers.Async));
            Assert.IsTrue(signature.Parameters.Count == 2);
            Assert.IsTrue(signature.Parameters[0].Type.FrameworkType.Equals(typeof(Response)));
            Assert.IsTrue(signature.Parameters[1].Type.FrameworkType.Equals(typeof(CancellationToken)));
            Assert.AreEqual(signature.ReturnType?.FrameworkType, typeof(ValueTask<>));

            // verify the method body
            var bodyStatements = validateIdMethod.BodyStatements?.ToDisplayString();
            Assert.NotNull(bodyStatements);
            var exptected = Helpers.GetExpectedFromFile();
            Assert.AreEqual(exptected, bodyStatements);
        }

        private static MethodProvider GetOperationSourceProviderMethodByName(string methodName)
        {
            OperationSourceProvider resourceProvider = GetOperationSourceProvider();
            var method = resourceProvider.Methods.FirstOrDefault(m => m.Signature.Name == methodName);
            Assert.NotNull(method);
            return method!;
        }

        private static OperationSourceProvider GetOperationSourceProvider()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);
            var operationSourceProvider = plugin.Object.OutputLibrary.TypeProviders.FirstOrDefault(p => p is OperationSourceProvider) as OperationSourceProvider;
            Assert.NotNull(operationSourceProvider);
            return operationSourceProvider!;
        }
    }
}
