// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.SourceInput;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Azure.Generator.Tests.TestHelpers
{
    internal class MockHelpers
    {
        private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);
        private const string TestHelpersFolder = "TestHelpers";

        public static Mock<AzureClientPlugin> LoadMockPlugin(
            Func<InputType, TypeProvider, IReadOnlyList<TypeProvider>>? createSerializationsCore = null,
            Func<InputType, CSharpType>? createCSharpTypeCore = null,
            Func<InputApiKeyAuth>? apiKeyAuth = null,
            Func<IReadOnlyList<string>>? apiVersions = null,
            Func<IReadOnlyList<InputEnumType>>? inputEnums = null,
            Func<IReadOnlyList<InputModelType>>? inputModels = null,
            Func<IReadOnlyList<InputClient>>? clients = null,
            ClientResponseApi? clientResponseApi = null,
            ClientPipelineApi? clientPipelineApi = null,
            HttpMessageApi? httpMessageApi = null)
        {
            IReadOnlyList<string> inputNsApiVersions = apiVersions?.Invoke() ?? [];
            IReadOnlyList<InputEnumType> inputNsEnums = inputEnums?.Invoke() ?? [];
            IReadOnlyList<InputClient> inputNsClients = clients?.Invoke() ?? [];
            IReadOnlyList<InputModelType> inputNsModels = inputModels?.Invoke() ?? [];
            InputAuth inputNsAuth = apiKeyAuth != null ? new InputAuth(apiKeyAuth(), null) : new InputAuth();
            var mockTypeFactory = new Mock<AzureTypeFactory>() { CallBase = true };
            var mockInputNs = new Mock<InputNamespace>(
                string.Empty,
                inputNsApiVersions,
                inputNsEnums,
                inputNsModels,
                inputNsClients,
                inputNsAuth);
            var mockInputLibrary = new Mock<InputLibrary>(_configFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNs.Object);

            if (createCSharpTypeCore is not null)
            {
                mockTypeFactory.Protected().Setup<CSharpType>("CreateCSharpTypeCore", ItExpr.IsAny<InputType>()).Returns(createCSharpTypeCore);
            }

            // initialize the mock singleton instance of the plugin
            var codeModelInstance = typeof(CodeModelPlugin).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var clientModelInstance = typeof(ClientModelPlugin).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var azureInstance = typeof(AzureClientPlugin).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            // invoke the load method with the config file path
            var loadMethod = typeof(Configuration).GetMethod("Load", BindingFlags.Static | BindingFlags.NonPublic);
            object?[] parameters = [_configFilePath, null];
            var config = loadMethod?.Invoke(null, parameters);
            var mockGeneratorContext = new Mock<GeneratorContext>(config!);
            var mockPluginInstance = new Mock<AzureClientPlugin>(mockGeneratorContext.Object) { CallBase = true };
            mockPluginInstance.SetupGet(p => p.TypeFactory).Returns(mockTypeFactory.Object);
            mockPluginInstance.Setup(p => p.InputLibrary).Returns(mockInputLibrary.Object);

            var sourceInputModel = new Mock<SourceInputModel>(() => new SourceInputModel(null)) { CallBase = true };
            mockPluginInstance.Setup(p => p.SourceInputModel).Returns(sourceInputModel.Object);

            codeModelInstance!.SetValue(null, mockPluginInstance.Object);
            clientModelInstance!.SetValue(null, mockPluginInstance.Object);
            azureInstance!.SetValue(null, mockPluginInstance.Object);
            mockPluginInstance.Object.Configure();
            return mockPluginInstance;
        }
    }
}
