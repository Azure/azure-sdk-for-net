// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Provides a resource client type.
    /// </summary>
    internal class ResourceClientProvider : TypeProvider
    {
        private IReadOnlyCollection<InputServiceMethod> _resourceServiceMethods;

        private FieldProvider _dataField;
        private FieldProvider _resourceTypeField;
        protected ClientProvider _clientProvider;
        protected FieldProvider _clientDiagnosticsField;
        protected FieldProvider _restClientField;

        public ResourceClientProvider(InputClient inputClient, ResourceMetadata resourceMetadata)
        {
            IsSingleton = resourceMetadata.IsSingleton;
            var resourceType = resourceMetadata.ResourceType;
            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(resourceType));
            var resourceModel = resourceMetadata.ResourceModel;
            SpecName = resourceModel.Name;

            // We should be able to assume that all operations in the resource client are for the same resource
            var requestPath = new RequestPath(inputClient.Methods.First().Operation.Path);
            _resourceServiceMethods = inputClient.Methods;
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(resourceModel)!;
            _clientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

            ContextualParameters = GetContextualParameters(requestPath);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), $"_{SpecName.ToLower()}ClientDiagnostics", this);
            _restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _clientProvider.Type, $"_{SpecName.ToLower()}RestClient", this);
        }

        private IReadOnlyList<string> GetContextualParameters(string contextualRequestPath)
        {
            var contextualParametersList = new List<string>();
            var contextualSegments = new RequestPath(contextualRequestPath);
            foreach (var segment in contextualSegments)
            {
                if (segment.StartsWith("{"))
                {
                    contextualParametersList.Add(segment.TrimStart('{').TrimEnd('}'));
                }
            }
            return contextualParametersList;
        }

        protected override string BuildName() => $"{SpecName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

        internal ModelProvider ResourceData { get; }
        internal string SpecName { get; }

        public bool IsSingleton { get; }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override FieldProvider[] BuildFields() => [_clientDiagnosticsField, _restClientField, _dataField, _resourceTypeField];

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
                ResourceData.Type,
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
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildResourceDataConstructor(), BuildResourceIdentifierConstructor()];

        private ConstructorProvider BuildResourceDataConstructor()
        {
            var clientParameter = new ParameterProvider("client", $"The client parameters to use in these operations.", typeof(ArmClient));
            var dataParameter = new ParameterProvider("data", $"The resource that is the target of operations.", ResourceData.Type);

            var initializer = new ConstructorInitializer(false, [clientParameter, dataParameter.Property("Id")]);
            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of {Type:C} class.",
                MethodSignatureModifiers.Internal,
                [clientParameter, dataParameter],
                null,
                initializer);

            var bodyStatements = new MethodBodyStatement[]
            {
                This.Property("HasData").Assign(Literal(true)).Terminate(),
                _dataField.Assign(dataParameter).Terminate(),
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        protected ConstructorProvider BuildResourceIdentifierConstructor()
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
                _clientDiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), ResourceTypeExpression.Property(nameof(ResourceType.Namespace)), This.Property("Diagnostics"))).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_clientProvider.Type, _clientDiagnosticsField, This.Property("Pipeline"), This.Property("Endpoint"), apiVersion)).Terminate(),
                Static(Type).Invoke(ValidateResourceIdMethodName, idParameter).Terminate()
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        private const string ValidateResourceIdMethodName = "ValidateResourceId";
        protected MethodProvider BuildValidateResourceIdMethod()
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
                ],
                [new AttributeStatement(typeof(ConditionalAttribute), Literal("DEBUG"))]);
            var bodyStatements = new IfStatement(idParameter.NotEqual(ExpectedResourceTypeForValidation))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.Property(nameof(ResourceIdentifier.ResourceType)), ResourceTypeExpression), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        protected virtual ValueExpression ResourceTypeExpression => _resourceTypeField;

        protected virtual ValueExpression ExpectedResourceTypeForValidation => _resourceTypeField;

        protected internal virtual CSharpType ResourceClientCSharpType => this.Type;

        internal ValueExpression GetClientDiagnosticsField() => _clientDiagnosticsField;
        internal ValueExpression GetRestClientField() => _restClientField;
        internal ClientProvider GetClientProvider() => _clientProvider;
        internal IReadOnlyList<string> ContextualParameters { get; }

        protected override CSharpType[] BuildImplements() => [typeof(ArmResource)];

        protected override MethodProvider[] BuildMethods()
        {
            var operationMethods = new List<MethodProvider>();
            foreach (var method in _resourceServiceMethods)
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(method.Operation, false);
                // exclude the List operations for resource, they will be in ResourceCollection
                var returnType = convenienceMethod.Signature.ReturnType!;
                if ((returnType.IsFrameworkType && returnType.IsList) || (method is InputPagingServiceMethod pagingMethod && pagingMethod.PagingMetadata.ItemPropertySegments.Any() == true))
                {
                    continue;
                }

                // Check if this is an update operation (PUT method for non-singleton resource)
                var isUpdateOperation = method.Operation.HttpMethod == HttpMethod.Put.ToString() && !IsSingleton;

                if (isUpdateOperation)
                {
                    var updateMethodProvider = new UpdateOperationMethodProvider(this, method, convenienceMethod, false);
                    operationMethods.Add(updateMethodProvider);

                    var asyncConvenienceMethod = GetCorrespondingConvenienceMethod(method.Operation, true);
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, method, asyncConvenienceMethod, true);
                    operationMethods.Add(updateAsyncMethodProvider);
                }
                else
                {
                    operationMethods.Add(BuildOperationMethod(method, convenienceMethod, false));
                    var asyncConvenienceMethod = GetCorrespondingConvenienceMethod(method.Operation, true);
                    operationMethods.Add(BuildOperationMethod(method, asyncConvenienceMethod, true));
                }
            }

            return [BuildValidateResourceIdMethod(), .. operationMethods];
        }

        protected MethodProvider BuildOperationMethod(InputServiceMethod method, MethodProvider convenienceMethod, bool isAsync)
        {
            return BuildOperationMethodCore(method, convenienceMethod, isAsync);
        }

        protected MethodProvider BuildOperationMethodCore(InputServiceMethod method, MethodProvider convenienceMethod, bool isAsync)
        {
            return new ResourceOperationMethodProvider(this, method, convenienceMethod, isAsync);
        }

        protected virtual bool SkipMethodParameter(ParameterProvider parameter)
        {
            return ContextualParameters.Contains(parameter.Name);
        }

        internal IReadOnlyList<ParameterProvider> GetOperationMethodParameters(MethodProvider convenienceMethod, bool isLongRunning)
        {
            var result = new List<ParameterProvider>();
            if (isLongRunning)
            {
                result.Add(KnownAzureParameters.WaitUntil);
            }

            foreach (var parameter in convenienceMethod.Signature.Parameters)
            {
                if (!SkipMethodParameter(parameter))
                {
                    result.Add(parameter);
                }
            }

            return result;
        }

        // TODO: get clean name of operation Name
        protected MethodProvider GetCorrespondingConvenienceMethod(InputOperation operation, bool isAsync)
            => _clientProvider.CanonicalView.Methods.Single(m => m.Signature.Name.Equals(isAsync ? $"{operation.Name}Async" : operation.Name, StringComparison.OrdinalIgnoreCase) && m.Signature.Parameters.Any(p => p.Type.Equals(typeof(CancellationToken))));

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{SpecName.ToLower()}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [ResourceTypeExpression, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }
    }
}
