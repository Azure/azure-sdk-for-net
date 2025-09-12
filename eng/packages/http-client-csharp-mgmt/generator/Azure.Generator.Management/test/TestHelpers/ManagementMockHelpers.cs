// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using Moq;
using Moq.Protected;
using System.Reflection;

namespace Azure.Generator.Management.Tests.TestHelpers
{
    internal class ManagementMockHelpers
    {
        private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, TestHelpersFolder);
        private const string TestHelpersFolder = "TestHelpers";

        public static Mock<ManagementClientGenerator> LoadMockPlugin(
            Func<InputType, TypeProvider, IReadOnlyList<TypeProvider>>? createSerializationsCore = null,
            Func<InputType, CSharpType>? createCSharpTypeCore = null,
            Func<InputApiKeyAuth>? apiKeyAuth = null,
            Func<InputOAuth2Auth>? oauth2Auth = null,
            Func<IReadOnlyList<string>>? apiVersions = null,
            Func<IReadOnlyList<InputLiteralType>>? inputLiterals = null,
            Func<IReadOnlyList<InputEnumType>>? inputEnums = null,
            Func<IReadOnlyList<InputModelType>>? inputModels = null,
            Func<IReadOnlyList<InputClient>>? clients = null,
            ClientResponseApi? clientResponseApi = null,
            ClientPipelineApi? clientPipelineApi = null,
            HttpMessageApi? httpMessageApi = null,
            string? primaryNamespace = null)
        {
            IReadOnlyList<string> inputNsApiVersions = apiVersions?.Invoke() ?? ["2023-01-01"];
            IReadOnlyList<InputLiteralType> inputNsLiterals = inputLiterals?.Invoke() ?? [];
            IReadOnlyList<InputEnumType> inputNsEnums = inputEnums?.Invoke() ?? [];
            IReadOnlyList<InputClient> inputNsClients = clients?.Invoke() ?? [];
            IReadOnlyList<InputModelType> inputNsModels = inputModels?.Invoke() ?? [];
            var mgmtInstance = typeof(ManagementClientGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            InputAuth inputNsAuth = new InputAuth(apiKeyAuth?.Invoke(), oauth2Auth?.Invoke());
            var mockInputNs = new Mock<InputNamespace>(
                primaryNamespace ?? "Samples",
                inputNsApiVersions,
                inputNsLiterals,
                inputNsEnums,
                inputNsModels,
                inputNsClients,
                inputNsAuth);
            var mockInputLibrary = new Mock<ManagementInputLibrary>(_configFilePath);
            mockInputLibrary.Setup(p => p.InputNamespace).Returns(mockInputNs.Object);

            Mock<ManagementTypeFactory> mockTypeFactory = new Mock<ManagementTypeFactory>() { CallBase = true };
            if (createCSharpTypeCore is not null)
            {
                mockTypeFactory.Protected().Setup<CSharpType>("CreateCSharpTypeCore", ItExpr.IsAny<InputType>()).Returns(createCSharpTypeCore);
            }

            // initialize the mock singleton instance of the plugin
            var codeModelInstance = typeof(CodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var clientModelInstance = typeof(ScmCodeModelGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            var azureInstance = typeof(AzureClientGenerator).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
            // invoke the load method with the config file path
            var loadMethod = typeof(Configuration).GetMethod("Load", BindingFlags.Static | BindingFlags.NonPublic);
            object?[] parameters = [_configFilePath, null];
            var config = loadMethod?.Invoke(null, parameters);
            var mockGeneratorContext = new Mock<GeneratorContext>(config!);
            var mockPluginInstance = new Mock<ManagementClientGenerator>(mockGeneratorContext.Object) { CallBase = true };
            codeModelInstance!.SetValue(null, mockPluginInstance.Object);
            clientModelInstance!.SetValue(null, mockPluginInstance.Object);
            azureInstance!.SetValue(null, mockPluginInstance.Object);
            mockPluginInstance.SetupGet(p => p.InputLibrary).Returns(mockInputLibrary.Object);
            mockPluginInstance.SetupGet(p => p.TypeFactory).Returns(mockTypeFactory.Object);

            var sourceInputModel = new Mock<SourceInputModel>(() => new SourceInputModel(null, null)) { CallBase = true };
            mockPluginInstance.Setup(p => p.SourceInputModel).Returns(sourceInputModel.Object);
            var configureMethod = typeof(CodeModelGenerator).GetMethod(
                "Configure",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod
            );
            configureMethod!.Invoke(mockPluginInstance.Object, null);
            return mockPluginInstance;
        }
    }
}
