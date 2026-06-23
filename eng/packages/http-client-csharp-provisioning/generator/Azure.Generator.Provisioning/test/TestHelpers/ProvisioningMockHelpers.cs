// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.SourceInput;
using Moq;
using System;
using System.IO;
using System.Reflection;

namespace Azure.Generator.Provisioning.Tests.TestHelpers
{
    internal static class ProvisioningMockHelpers
    {
        private const string TestHelpersFolder = "TestHelpers";
        private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);

        public static ProvisioningGenerator LoadMockGenerator()
        {
            var loadMethod = typeof(Configuration).GetMethod("Load", BindingFlags.Static | BindingFlags.NonPublic);
            var config = loadMethod!.Invoke(null, [_configFilePath, null]);
            var context = (GeneratorContext)typeof(GeneratorContext)
                .GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, [typeof(Configuration)], null)!
                .Invoke([config]);

            var generator = new ProvisioningGenerator(context);
            var mockInputNamespace = new Mock<InputNamespace>(
                "Azure.Provisioning.Tests",
                Array.Empty<string>(),
                Array.Empty<InputLiteralType>(),
                Array.Empty<InputEnumType>(),
                Array.Empty<InputModelType>(),
                Array.Empty<InputClient>(),
                new InputAuth(null, null));
            var mockInputLibrary = new Mock<ManagementInputLibrary>(_configFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNamespace.Object);
            typeof(ManagementClientGenerator)
                .GetField("<InputLibrary>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(generator, mockInputLibrary.Object);
            typeof(Azure.Generator.Management.ManagementInputLibrary)
                .GetField("_providerSchema", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(generator.InputLibrary, new ArmProviderSchema([], []));
            typeof(CodeModelGenerator)
                .GetProperty(nameof(CodeModelGenerator.SourceInputModel))!
                .SetValue(generator, new SourceInputModel(null, null));

            var codeModelInstance = typeof(CodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            codeModelInstance!.SetValue(null, generator);

            var factory = generator.TypeFactory;
            typeof(Microsoft.TypeSpec.Generator.TypeFactory)
                .GetField("_primaryNamespace", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(factory, "Azure.Provisioning.Tests");
            typeof(Azure.Generator.Management.ManagementTypeFactory)
                .GetField("_resourceProviderName", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(factory, "Tests");

            return generator;
        }
    }
}
