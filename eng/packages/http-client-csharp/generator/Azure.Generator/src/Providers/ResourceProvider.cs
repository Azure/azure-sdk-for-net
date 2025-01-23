// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Mgmt.Models;
using Azure.ResourceManager;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class ResourceProvider : TypeProvider
    {
        private OperationSet _operationSet;
        private ResourceDataProvider _resourceData;
        private string _specName;
        private FieldProvider _dataField;
        private FieldProvider _clientDiagonosticsField;
        private FieldProvider _restClientField;
        private FieldProvider _resourcetypeField;
        private PropertyProvider _hasDataProperty;
        private PropertyProvider _dataProperty;
        private ClientProvider _clientProvider;
        private string _resrouceType;

        public ResourceProvider(OperationSet operationSet, string specName, ResourceDataProvider resourceData, string resrouceType)
        {
            _operationSet = operationSet;
            _specName = specName;
            _resourceData = resourceData;
            _dataField = new FieldProvider(FieldModifiers.Private, _resourceData.Type, "_data", this);
            _clientDiagonosticsField = new FieldProvider(FieldModifiers.Private, typeof(ClientDiagnostics), $"_{specName.ToLower()}ClientDiagnostics", this);
            _clientProvider = AzureClientPlugin.Instance.TypeFactory.CreateClient(operationSet.InputClient)!;
            _restClientField = new FieldProvider(FieldModifiers.Private, _clientProvider.Type, "_restClient", this);
            _resrouceType = resrouceType;
            _resourcetypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(_resrouceType));
            _hasDataProperty = new PropertyProvider(
                $"Gets whether or not the current instance has data.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                typeof(bool),
                "HasData",
                new AutoPropertyBody(false),
                this);
            _dataProperty = new PropertyProvider(
                $"Gets the data representing this Feature.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                _resourceData.Type,
            "Data",
                new MethodPropertyBody(new MethodBodyStatement[]
                {
                    new IfStatement(Not(_hasDataProperty))
                    {
                        Throw(New.Instance(typeof(InvalidOperationException), Literal("The current instance does not have data, you must call Get first.")))
                    },
                    Return(_dataField)
                }),
                this);
        }

        protected override string BuildName() => $"{_specName}Resource"; // TODO: replace _specName with ToCleanName(_resourceName)

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override FieldProvider[] BuildFields()
            => [_dataField, _clientDiagonosticsField, _restClientField, _resourcetypeField];

        protected override PropertyProvider[] BuildProperties()
        {
            return [_hasDataProperty, _dataProperty];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            return [BuildMockingConstructor(this), BuildPrimaryConstructor(), BuildInitializationConstructor(), ];
        }

        public static ConstructorProvider BuildMockingConstructor(TypeProvider enclosingType)
        {
            return new ConstructorProvider(
                new ConstructorSignature(enclosingType.Type, $"Initializes a new instance of {enclosingType.Name} for mocking.", MethodSignatureModifiers.Protected, []),
                new MethodBodyStatement[] { MethodBodyStatement.Empty },
                enclosingType);
        }

        private ConstructorProvider BuildPrimaryConstructor()
        {
            var clientParameter = new ParameterProvider("client", $"The client parameters to use in these operations.", typeof(ArmClient));
            var dataParameter = new ParameterProvider("data", $"The resource that is the target of operations.", _resourceData.Type);

            var initializer = new ConstructorInitializer(false, [clientParameter, dataParameter.AsExpression().Property("Id")]);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                [clientParameter, dataParameter],
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                _hasDataProperty.Assign(Literal(true)).Terminate(),
                _dataField.Assign(dataParameter).Terminate(),
            };
            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private ConstructorProvider BuildInitializationConstructor()
        {
            var idParameter = new ParameterProvider("id", $"The identifier of the resource that is the target of operations.", typeof(ResourceIdentifier));
            var parameters = new List<ParameterProvider>
            {
                new("client", $"The client parameters to use in these operations.", typeof(ArmClient)),
                idParameter
            };

            var initializer = new ConstructorInitializer(true, parameters);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                parameters,
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagonosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Namespace), _resourcetypeField.Property(nameof(ResourceType.Namespace)), This.Property("Diagnostics"))).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_clientProvider.Type, This.Property("Pipeline"), This.Property("Endpoint"), apiVersion)).Terminate(),
                new IfElsePreprocessorStatement("DEBUG", Static(Type).Invoke(ValidateResourceIdMethodName, idParameter).Terminate(), null)
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private const string ValidateResourceIdMethodName = "ValidateResourceId";
        private MethodProvider BuildValidateResourceIdMethod()
        {
            var idParameter = new ParameterProvider("id", $"", typeof(ResourceIdentifier));
            var signature = new MethodSignature(
                ValidateResourceIdMethodName,
                null,
                MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                null,
                null,
                [
                    idParameter
                ]);
            var bodyStatements = new IfStatement(idParameter.NotEqual(_resourcetypeField))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.Property(nameof(ResourceIdentifier.ResourceType)), _resourcetypeField), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        protected override CSharpType[] BuildImplements() => [typeof(ArmResource)];

        protected override MethodProvider[] BuildMethods()
        {
            // TODO: build operation methods
            foreach (var operation in _operationSet)
            {
                var operationMethods = AzureClientPlugin.Instance.TypeFactory.CreateMethods(operation, _clientProvider);
            }

            return [BuildValidateResourceIdMethod()];
        }

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{_specName.ToLower()}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [_resourcetypeField, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }
    }
}
