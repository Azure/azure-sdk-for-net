// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.SourceInput;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Azure.Generator.Provisioning.Tests.TestHelpers
{
    internal static class ProvisioningMockHelpers
    {
        private const string TestHelpersFolder = "TestHelpers";
        private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);

        public static Mock<ProvisioningGenerator> LoadMockPlugin(
            Func<IReadOnlyList<string>>? apiVersions = null,
            Func<IReadOnlyList<InputLiteralType>>? inputLiterals = null,
            Func<IReadOnlyList<InputEnumType>>? inputEnums = null,
            Func<IReadOnlyList<InputModelType>>? inputModels = null,
            Func<IReadOnlyList<InputClient>>? clients = null,
            string? primaryNamespace = null)
        {
            IReadOnlyList<string> inputNsApiVersions = apiVersions?.Invoke() ?? [];
            IReadOnlyList<InputLiteralType> inputNsLiterals = inputLiterals?.Invoke() ?? [];
            IReadOnlyList<InputEnumType> inputNsEnums = inputEnums?.Invoke() ?? [];
            IReadOnlyList<InputModelType> inputNsModels = inputModels?.Invoke() ?? [];
            IReadOnlyList<InputClient> inputNsClients = clients?.Invoke() ?? [];
            var mockInputNamespace = new Mock<InputNamespace>(
                primaryNamespace ?? "Azure.Provisioning.Tests",
                inputNsApiVersions,
                inputNsLiterals,
                inputNsEnums,
                inputNsModels,
                inputNsClients,
                new InputAuth(null, null));
            // ProvisioningGenerator inherits ManagementClientGenerator and does not define a
            // provisioning-specific input library type, so tests mock ManagementInputLibrary.
            var mockInputLibrary = new Mock<ManagementInputLibrary>(_configFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNamespace.Object);

            var loadMethod = typeof(Configuration).GetMethod("Load", BindingFlags.Static | BindingFlags.NonPublic);
            var config = loadMethod!.Invoke(null, [_configFilePath, null]);
            var mockGeneratorContext = new Mock<GeneratorContext>(config!);
            var mockGenerator = new Mock<ProvisioningGenerator>(mockGeneratorContext.Object) { CallBase = true };

            mockGenerator.SetupGet(p => p.InputLibrary).Returns(mockInputLibrary.Object);
            mockGenerator.Setup(p => p.SourceInputModel).Returns(new SourceInputModel(null, null));
            typeof(Azure.Generator.Management.ManagementInputLibrary)
                .GetField("_providerSchema", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(mockInputLibrary.Object, new ArmProviderSchema([], []));

            var codeModelInstance = typeof(CodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var provisioningInstance = typeof(ProvisioningGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            codeModelInstance!.SetValue(null, mockGenerator.Object);
            provisioningInstance!.SetValue(null, mockGenerator.Object);

            return mockGenerator;
        }
    }
}
