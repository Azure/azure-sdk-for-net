// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Models;
using Azure.ResourceManager;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class ResourceProvider : TypeProvider
    {
        private ResourceDataProvider _resourceData;
        private string _specName;
        private FieldProvider _dataField;
        private FieldProvider _clientDiagonosticsField;
        private FieldProvider _restClientField;
        private FieldProvider _resourcetypeField;
        private ClientProvider _clientProvider;
        private string _resrouceType;

        public ResourceProvider(string specName, ResourceDataProvider resourceData, ClientProvider clientProvider, string resrouceType)
        {
            _specName = specName;
            _resourceData = resourceData;
            _dataField = new FieldProvider(FieldModifiers.Private, _resourceData.Type, "_data", this);
            _clientDiagonosticsField = new FieldProvider(FieldModifiers.Private, typeof(ClientDiagnostics), "_clientDiagnostics", this);
            _restClientField = new FieldProvider(FieldModifiers.Private, clientProvider.Type, "_restClient", this);
            _clientProvider = clientProvider;
            _resrouceType = resrouceType;
            _resourcetypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, initializationValue: Literal(_resrouceType));
        }

        protected override string BuildName() => $"{_specName}Resource"; // TODO: replace _specName with ToCleanName(_resourceName)

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override PropertyProvider[] BuildProperties()
        {
            var hasDataProperty = new PropertyProvider(
                $"Gets whether or not the current instance has data.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                typeof(bool),
                "HasData",
                new AutoPropertyBody(false),
                this);

            var dataProperty = new PropertyProvider(
                $"Gets the data representing this Feature.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                _resourceData.Type,
            "Data",
                new MethodPropertyBody(new MethodBodyStatement[]
                {
                    new IfStatement(Not(hasDataProperty))
                    {
                        Throw(New.Instance(typeof(InvalidOperationException), Literal("The current instance does not have data, you must call Get first.")))
                    },
                    Return(_dataField)
                }),
                this);
            return [hasDataProperty, dataProperty];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            return [BuildInitializationConstructor()];
        }

        private ConstructorProvider BuildInitializationConstructor()
        {
            var parameters = new List<ParameterProvider>
            {
                new("client", $"The client parameters to use in these operations.", typeof(ArmClient)),
                new("id", $"The identifier of the resource that is the target of operations.", typeof(ResourceIdentifier))
            };

            var initializer = new ConstructorInitializer(true, parameters);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C}",
                MethodSignatureModifiers.Internal,
                parameters,
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagonosticsField.Assign(New.Instance(typeof(ClientDiagnostics),  _clientDiagonosticsField, Literal(Namespace), _resourcetypeField.AsVariableExpression.Invoke(nameof(ResourceType.Namespace)), This.Invoke("Diagnostics"))).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_clientProvider.Type, _clientDiagonosticsField, This.Invoke("Pipeline"), This.Invoke("Diagnostics").Invoke(nameof(DiagnosticsOptions.ApplicationId)), This.Invoke("Endpoint"), apiVersion)).Terminate(),
                new IfElsePreprocessorStatement("DEBUG", This.Invoke(ValidateResourceIdMethodName).Terminate(), null)
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
                typeof(void),
                null,
                [
                    idParameter
                ]);
            var bodyStatements = new IfStatement(idParameter.NotEqual(This.Invoke("ResourceType")))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.Invoke("Resourcetype"), This.Invoke("ResourceType")), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        protected override CSharpType[] BuildImplements() => [typeof(ArmResource)];

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildValidateResourceIdMethod()];
        }

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{_specName}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [_resourcetypeField, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }
    }
}
