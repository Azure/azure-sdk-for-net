// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class OperationSourceProvider : TypeProvider
    {
        private ResourceClientProvider _resource;
        private CSharpType _operationSourceInterface;

        private FieldProvider _clientField;

        public OperationSourceProvider(ResourceClientProvider resource)
        {
            _resource = resource;
            _clientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ArmClient), "_client", this);
            _operationSourceInterface = new CSharpType(typeof(IOperationSource<>), _resource.Type);
        }

        protected override string BuildName() => $"{_resource.ResourceName}OperationSource";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");

        protected override CSharpType[] BuildImplements()
        {
            return [new CSharpType(typeof(IOperationSource<>), _resource.Type)];
        }

        protected override MethodProvider[] BuildMethods() => [BuildCreateResult(), BuildCreateResultAsync()];

        private MethodProvider BuildCreateResultAsync()
        {
            var signature = new MethodSignature(
                "CreateResultAsync",
                null,
                MethodSignatureModifiers.Async,
                new CSharpType(typeof(ValueTask<>), _resource.Type),
                $"",
                [KnownAzureParameters.Response, KnownAzureParameters.CancellationTokenWithoutDefault],
                ExplicitInterface: _operationSourceInterface);
            var body = new MethodBodyStatement[]
            {
                UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.ParseAsync), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream)), Default, KnownAzureParameters.CancellationTokenWithoutDefault], true), out var documentVariable),
                Declare("data", _resource.ResourceData.Type, Static(_resource.ResourceData.Type).Invoke($"Deserialize{_resource.ResourceData.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var dataVariable),
                Return(New.Instance(_resource.Type, [_clientField, dataVariable])),
            };
            return new MethodProvider(signature, body, this);
        }

        private MethodProvider BuildCreateResult()
        {
            var signature = new MethodSignature(
                "CreateResult",
                null,
                MethodSignatureModifiers.None,
                _resource.Type,
                $"",
                [KnownAzureParameters.Response, KnownAzureParameters.CancellationTokenWithoutDefault],
                ExplicitInterface: _operationSourceInterface);
            var body = new MethodBodyStatement[]
            {
                UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.Parse), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream))]), out var documentVariable),
                Declare("data", _resource.ResourceData.Type, Static(_resource.ResourceData.Type).Invoke($"Deserialize{_resource.ResourceData.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var dataVariable),
                Return(New.Instance(_resource.Type, [_clientField, dataVariable])),
            };
            return new MethodProvider(signature, body, this);
        }

        protected override FieldProvider[] BuildFields() => [_clientField];

        protected override ConstructorProvider[] BuildConstructors() => [BuildInitializationConstructor()];

        private ConstructorProvider BuildInitializationConstructor()
        {
            var clientParameter = new ParameterProvider("client", $"", typeof(ArmClient));
            var signature = new ConstructorSignature(Type, $"", MethodSignatureModifiers.Internal, [clientParameter]);
            var body = new MethodBodyStatement[]
            {
                _clientField.Assign(clientParameter).Terminate(),
            };
            return new ConstructorProvider(signature, body, this);
        }
    }
}
