// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.SourceInput;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Test.Extensions.Plugin.TestHelpers
{
    internal static class MockHelpers
    {
        private const string TestHelpersFolder = "TestHelpers";
        private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);

        /// <summary>
        /// Loads a mock <see cref="ScmCodeModelGenerator"/> and wires it up as the current singleton
        /// instance so that <c>ScmCodeModelGenerator.Instance.TypeFactory.CreateModel(...)</c> can be
        /// used to build providers from the supplied input models.
        /// </summary>
        public static Mock<ScmCodeModelGenerator> LoadMockGenerator(
            Func<IReadOnlyList<InputModelType>>? inputModels = null,
            Func<IReadOnlyList<InputEnumType>>? inputEnums = null,
            string? inputNamespace = null)
        {
            IReadOnlyList<InputEnumType> inputNsEnums = inputEnums?.Invoke() ?? [];
            IReadOnlyList<InputModelType> inputNsModels = inputModels?.Invoke() ?? [];
            InputAuth inputNsAuth = new InputAuth(null, null);
            var mockInputNs = new Mock<InputNamespace>(
                inputNamespace ?? "Samples",
                (IReadOnlyList<string>)[],
                (IReadOnlyList<InputLiteralType>)[],
                inputNsEnums,
                inputNsModels,
                (IReadOnlyList<InputClient>)[],
                inputNsAuth);
            var mockInputLibrary = new Mock<InputLibrary>(_configFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNs.Object);

            // initialize the mock singleton instances of the generator
            var codeModelInstance = typeof(CodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var clientModelInstance = typeof(ScmCodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            // invoke the load method with the config file path
            var loadMethod = typeof(Configuration).GetMethod("Load", BindingFlags.Static | BindingFlags.NonPublic);
            object?[] parameters = [_configFilePath, null];
            var config = loadMethod?.Invoke(null, parameters);
            var mockGeneratorContext = new Mock<GeneratorContext>(config!);
            var mockGeneratorInstance = new Mock<ScmCodeModelGenerator>(mockGeneratorContext.Object) { CallBase = true };
            codeModelInstance!.SetValue(null, mockGeneratorInstance.Object);
            clientModelInstance!.SetValue(null, mockGeneratorInstance.Object);
            mockGeneratorInstance.SetupGet(p => p.InputLibrary).Returns(mockInputLibrary.Object);

            var sourceInputModel = new Mock<SourceInputModel>(() => new SourceInputModel(null, null)) { CallBase = true };
            mockGeneratorInstance.Setup(p => p.SourceInputModel).Returns(sourceInputModel.Object);

            var configureMethod = typeof(CodeModelGenerator).GetMethod(
                "Configure",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            configureMethod!.Invoke(mockGeneratorInstance.Object, null);

            return mockGeneratorInstance;
        }
    }
}
