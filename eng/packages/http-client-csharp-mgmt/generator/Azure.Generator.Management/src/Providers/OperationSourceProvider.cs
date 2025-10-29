// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Management.Primitives;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class OperationSourceProvider : TypeProvider
    {
        private readonly ResourceClientProvider? _resource;
        private readonly CSharpType _resultType;
        private readonly CSharpType _operationSourceInterface;
        private readonly bool _isResourceType;

        private readonly FieldProvider? _clientField;

        // Constructor for resource types
        public OperationSourceProvider(ResourceClientProvider resource)
        {
            _resource = resource;
            _resultType = resource.Type;
            _isResourceType = true;
            _clientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ArmClient), "_client", this);
            _operationSourceInterface = new CSharpType(typeof(IOperationSource<>), _resultType);
        }

        // Constructor for non-resource types
        public OperationSourceProvider(CSharpType resultType)
        {
            _resource = null;
            _resultType = resultType;
            _isResourceType = false;
            _clientField = null;
            _operationSourceInterface = new CSharpType(typeof(IOperationSource<>), _resultType);
        }

        protected override string BuildName()
        {
            if (_isResourceType && _resource != null)
            {
                return $"{_resource.ResourceName}OperationSource";
            }
            else
            {
                // For non-resource types, use the type name
                var typeName = _resultType.Name;
                return $"{typeName}OperationSource";
            }
        }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");

        protected override CSharpType[] BuildImplements()
        {
            return [new CSharpType(typeof(IOperationSource<>), _resultType)];
        }

        protected override MethodProvider[] BuildMethods() => [BuildCreateResult(), BuildCreateResultAsync()];

        private MethodProvider BuildCreateResultAsync()
        {
            var signature = new MethodSignature(
                "CreateResultAsync",
                null,
                MethodSignatureModifiers.Async,
                new CSharpType(typeof(ValueTask<>), _resultType),
                $"",
                [KnownAzureParameters.Response, KnownAzureParameters.CancellationTokenWithoutDefault],
                ExplicitInterface: _operationSourceInterface);

            MethodBodyStatement[] body;

            if (_isResourceType && _resource != null)
            {
                // Resource type: deserialize and wrap in resource
                body = new MethodBodyStatement[]
                {
                    UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.ParseAsync), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream)), Default, KnownAzureParameters.CancellationTokenWithoutDefault], true), out var documentVariable),
                    Declare("data", _resource.ResourceData.Type, Static(_resource.ResourceData.Type).Invoke($"Deserialize{_resource.ResourceData.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var dataVariable),
                    Return(New.Instance(_resource.Type, [_clientField!, dataVariable])),
                };
            }
            else
            {
                // Non-resource type: just deserialize and return
                body = new MethodBodyStatement[]
                {
                    UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.ParseAsync), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream)), Default, KnownAzureParameters.CancellationTokenWithoutDefault], true), out var documentVariable),
                    Declare("result", _resultType, Static(_resultType).Invoke($"Deserialize{_resultType.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var resultVariable),
                    Return(resultVariable),
                };
            }

            return new MethodProvider(signature, body, this);
        }

        private MethodProvider BuildCreateResult()
        {
            var signature = new MethodSignature(
                "CreateResult",
                null,
                MethodSignatureModifiers.None,
                _resultType,
                $"",
                [KnownAzureParameters.Response, KnownAzureParameters.CancellationTokenWithoutDefault],
                ExplicitInterface: _operationSourceInterface);

            MethodBodyStatement[] body;

            if (_isResourceType && _resource != null)
            {
                // Resource type: deserialize and wrap in resource
                body = new MethodBodyStatement[]
                {
                    UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.Parse), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream))]), out var documentVariable),
                    Declare("data", _resource.ResourceData.Type, Static(_resource.ResourceData.Type).Invoke($"Deserialize{_resource.ResourceData.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var dataVariable),
                    Return(New.Instance(_resource.Type, [_clientField!, dataVariable])),
                };
            }
            else
            {
                // Non-resource type: just deserialize and return
                body = new MethodBodyStatement[]
                {
                    UsingDeclare("document", typeof(JsonDocument), Static(typeof(JsonDocument)).Invoke(nameof(JsonDocument.Parse), [KnownAzureParameters.Response.Property(nameof(Response.ContentStream))]), out var documentVariable),
                    Declare("result", _resultType, Static(_resultType).Invoke($"Deserialize{_resultType.Name}", documentVariable.Property(nameof(JsonDocument.RootElement)), Static<ModelSerializationExtensionsDefinition>().Property("WireOptions").As<ModelReaderWriterOptions>()), out var resultVariable),
                    Return(resultVariable),
                };
            }

            return new MethodProvider(signature, body, this);
        }

        protected override FieldProvider[] BuildFields()
        {
            return _clientField != null ? [_clientField] : [];
        }

        protected override ConstructorProvider[] BuildConstructors() => [BuildInitializationConstructor()];

        private ConstructorProvider BuildInitializationConstructor()
        {
            if (_isResourceType)
            {
                var clientParameter = new ParameterProvider("client", $"", typeof(ArmClient));
                var signature = new ConstructorSignature(Type, $"", MethodSignatureModifiers.Internal, [clientParameter]);
                var body = new MethodBodyStatement[]
                {
                    _clientField!.Assign(clientParameter).Terminate(),
                };
                return new ConstructorProvider(signature, body, this);
            }
            else
            {
                // Non-resource type has a parameterless constructor
                var signature = new ConstructorSignature(Type, $"", MethodSignatureModifiers.Internal, []);
                var body = Array.Empty<MethodBodyStatement>();
                return new ConstructorProvider(signature, body, this);
            }
        }
    }
}
