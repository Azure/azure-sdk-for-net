// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.SourceInput;
using Moq;

namespace Microsoft.TypeSpec.Generator.AspNetServer.Tests.TestHelpers
{
    /// <summary>
    /// Lightweight helper that boots a mocked <see cref="AspNetServerCodeModelGenerator"/>
    /// instance so provider tests can run without spinning up the full MEF
    /// composition that the real CLI host uses.
    /// </summary>
    /// <remarks>
    /// The helper wires up just enough of the framework for unit tests:
    /// it loads <c>Configuration.json</c> from <c>TestHelpers/</c>, builds a
    /// <see cref="GeneratorContext"/>, supplies an empty <see cref="InputLibrary"/>
    /// mock so the framework's namespace resolution doesn't try to read a real
    /// <c>tspCodeModel.json</c>, sets the static <c>_instance</c> on
    /// <see cref="CodeModelGenerator"/>, and invokes the private <c>Configure</c>
    /// hook so providers can be materialized.
    /// </remarks>
    internal static class AspNetServerMockHelpers
    {
        private const string TestHelpersFolder = "TestHelpers";

        private static readonly string ConfigFilePath =
            Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);

        public static Mock<AspNetServerCodeModelGenerator> LoadMockPlugin(
            string primaryNamespace = "Microsoft.TypeSpec.Generator.AspNetServer.Test")
        {
            var loadMethod = typeof(Configuration).GetMethod(
                "Load",
                BindingFlags.Static | BindingFlags.NonPublic);
            object?[] parameters = [ConfigFilePath, null];
            var config = loadMethod?.Invoke(null, parameters);

            var mockGeneratorContext = new Mock<GeneratorContext>(config!);
            var mockGenerator = new Mock<AspNetServerCodeModelGenerator>(mockGeneratorContext.Object)
            {
                CallBase = true
            };

            // Provide an empty InputNamespace so the framework's lazy namespace
            // resolution path doesn't try to read a real tspCodeModel.json from
            // disk during provider materialization.
            var mockInputNamespace = new Mock<InputNamespace>(
                primaryNamespace,
                (IReadOnlyList<string>)new List<string> { "2024-01-01" },
                (IReadOnlyList<InputLiteralType>)new List<InputLiteralType>(),
                (IReadOnlyList<InputEnumType>)new List<InputEnumType>(),
                (IReadOnlyList<InputModelType>)new List<InputModelType>(),
                (IReadOnlyList<InputClient>)new List<InputClient>(),
                new InputAuth(null, null));

            var mockInputLibrary = new Mock<InputLibrary>(ConfigFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNamespace.Object);
            mockGenerator.SetupGet(p => p.InputLibrary).Returns(mockInputLibrary.Object);

            // Reset the static singleton on CodeModelGenerator so subsequent
            // resolves go through this mock.
            var codeModelInstance = typeof(CodeModelGenerator).GetField(
                "_instance",
                BindingFlags.Static | BindingFlags.NonPublic);
            codeModelInstance!.SetValue(null, mockGenerator.Object);

            var sourceInputModel = new Mock<SourceInputModel>(() => new SourceInputModel(null, null))
            {
                CallBase = true
            };
            mockGenerator.Setup(p => p.SourceInputModel).Returns(sourceInputModel.Object);

            var configureMethod = typeof(CodeModelGenerator).GetMethod(
                "Configure",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
            configureMethod!.Invoke(mockGenerator.Object, null);

            return mockGenerator;
        }
    }
}

