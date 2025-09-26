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
using System.Threading.Tasks;
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
        private FieldProvider _resourcetypeField;
        protected ClientProvider _clientProvider;
        protected FieldProvider _clientDiagonosticsField;
        protected FieldProvider _restClientField;

        public ResourceClientProvider(InputClient inputClient)
        {
            var resourceMetadata = inputClient.Decorators.Single(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
            var codeModelId = resourceMetadata.Arguments?[KnownDecorators.ResourceModel].ToObjectFromJson<string>()!;
            IsSingleton = resourceMetadata.Arguments?.TryGetValue("isSingleton", out var isSingleton) == true ? isSingleton.ToObjectFromJson<bool>() : false;
            var resourceType = resourceMetadata.Arguments?[KnownDecorators.ResourceType].ToObjectFromJson<string>()!;
            _resourcetypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(resourceType));
            var resourceModel = ManagementClientGenerator.Instance.InputLibrary.GetModelByCrossLanguageDefinitionId(codeModelId)!;
            SpecName = resourceModel.Name;

            // We should be able to assume that all operations in the resource client are for the same resource
            var requestPath = new RequestPath(inputClient.Methods.First().Operation.Path);
            _resourceServiceMethods = inputClient.Methods;
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(resourceModel)!;
            _clientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

            ContextualParameters = GetContextualParameters(requestPath);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagonosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), $"_{SpecName.ToLower()}ClientDiagnostics", this);
            _restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _clientProvider.Type, $"_{SpecName.ToLower()}RestClient", this);
        }

        private IReadOnlyList<string> GetContextualParameters(string contextualRequestPath)
        {
            var contextualParameters = new List<string>();
            var contextualSegments = new RequestPath(contextualRequestPath);
            foreach (var segment in contextualSegments)
            {
                if (segment.StartsWith("{"))
                {
                    contextualParameters.Add(segment.TrimStart('{').TrimEnd('}'));
                }
            }
            return contextualParameters;
        }

        protected IReadOnlyList<string> ContextualParameters { get; }

        protected override string BuildName() => $"{SpecName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

        internal ModelProvider ResourceData { get; }
        internal string SpecName { get; }

        public bool IsSingleton { get; }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override FieldProvider[] BuildFields() => [_clientDiagonosticsField, _restClientField, _dataField, _resourcetypeField];

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
                _clientDiagonosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), ResourceTypeExpression.Property(nameof(ResourceType.Namespace)), This.Property("Diagnostics"))).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_clientProvider.Type, _clientDiagonosticsField, This.Property("Pipeline"), This.Property("Endpoint"), apiVersion)).Terminate(),
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

        protected virtual ValueExpression ResourceTypeExpression => _resourcetypeField;

        protected virtual ValueExpression ExpectedResourceTypeForValidation => _resourcetypeField;

        protected virtual CSharpType ResourceClientCharpType => this.Type;

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

                // only update for non-singleton resource
                var isUpdateOnly = method.Operation.HttpMethod == HttpMethod.Put.ToString() && !IsSingleton;
                operationMethods.Add(BuildOperationMethod(method, convenienceMethod, false, isUpdateOnly));
                var asyncConvenienceMethod = GetCorrespondingConvenienceMethod(method.Operation, true);
                operationMethods.Add(BuildOperationMethod(method, asyncConvenienceMethod, true, isUpdateOnly));
            }

            return [BuildValidateResourceIdMethod(), .. operationMethods];
        }

        // TODO: the BuildOperationMethod related code is kind of messy now need to be refactored in a following up PR
        protected MethodProvider BuildOperationMethod(InputServiceMethod method, MethodProvider convenienceMethod, bool isAsync, bool isUpdateOnly = false)
        {
            var signature = new MethodSignature(
                isUpdateOnly ? (isAsync ? "UpdateAsync" : "Update") : convenienceMethod.Signature.Name,
                isUpdateOnly ? $"Update a {SpecName}" : convenienceMethod.Signature.Description,
                convenienceMethod.Signature.Modifiers,
                GetOperationMethodReturnType(method, isAsync, out var isGeneric),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, method is InputLongRunningServiceMethod),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);

            return BuildOperationMethodCore(method, convenienceMethod, signature, isAsync, isGeneric);
        }

        protected MethodProvider BuildOperationMethodCore(InputServiceMethod method, MethodProvider convenienceMethod, MethodSignature signature, bool isAsync, bool isGeneric)
        {
            var bodyStatements = new MethodBodyStatement[]
                {
                    UsingDeclare("scope", typeof(DiagnosticScope), _clientDiagonosticsField.Invoke(nameof(ClientDiagnostics.CreateScope), [Literal($"{Name}.{signature.Name}")]), out var scopeVariable),
                    scopeVariable.Invoke(nameof(DiagnosticScope.Start)).Terminate(),
                    new TryCatchFinallyStatement
                    (BuildOperationMethodTryStatement(method, convenienceMethod, signature, isAsync, isGeneric),
                     Catch(Declare<Exception>("e", out var exceptionVarialble),
                     [scopeVariable.Invoke(nameof(DiagnosticScope.Failed), exceptionVarialble).Terminate(), Throw()]))
                };

            return new MethodProvider(signature, bodyStatements, this);
        }

        protected virtual bool SkipMethodParameter(ParameterProvider parameter)
        {
            return ContextualParameters.Contains(parameter.Name);
        }

        protected IReadOnlyList<ParameterProvider> GetOperationMethodParameters(MethodProvider convenienceMethod, bool isLongRunning)
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

        protected bool IsLongRunningOperation(InputServiceMethod method)
        {
            return method is InputLongRunningServiceMethod || method is InputLongRunningPagingServiceMethod;
        }

        protected bool IsReturnTypeGeneric(InputServiceMethod method)
        {
            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            var responseBodyType = response?.BodyType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(response.BodyType);
            return IsLongRunningOperation(method) && responseBodyType is not null;
        }

        protected CSharpType GetOperationMethodReturnType(InputServiceMethod method, bool isAsync, out bool isGeneric)
        {
            bool isLongRunningOperation = IsLongRunningOperation(method);
            isGeneric = IsReturnTypeGeneric(method);

            if (isLongRunningOperation)
            {
                if (!isGeneric)
                {
                    return isAsync ? new CSharpType(typeof(Task<>), typeof(ArmOperation)) : typeof(ArmOperation);
                }
                else
                {
                    return isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(ArmOperation<>), ResourceClientCharpType)) : new CSharpType(typeof(ArmOperation<>), ResourceClientCharpType);
                }
            }
            return isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(Response<>), ResourceClientCharpType)) : new CSharpType(typeof(Response<>), ResourceClientCharpType);
        }

        private TryStatement BuildOperationMethodTryStatement(InputServiceMethod method, MethodProvider convenienceMethod, MethodSignature signature, bool isAsync, bool isGeneric)
        {
            var operation = method.Operation;
            var cancellationToken = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)));

            var tryStatement = new TryStatement();
            var contextDeclaration = Declare("context", typeof(RequestContext), New.Instance(typeof(RequestContext), new Dictionary<ValueExpression, ValueExpression> { { Identifier(nameof(RequestContext.CancellationToken)), cancellationToken } }), out var contextVariable);
            tryStatement.Add(contextDeclaration);
            var requestMethod = GetCorrespondingRequestMethod(operation);
            var messageDeclaration = Declare("message", typeof(HttpMessage), _restClientField.Invoke(requestMethod.Signature.Name, PopulateArguments(requestMethod.Signature.Parameters, convenienceMethod, contextVariable)), out var messageVariable);
            tryStatement.Add(messageDeclaration);
            var responseType = GetResponseType(convenienceMethod, isAsync);
            VariableExpression responseVariable;
            if (!responseType.Equals(typeof(Response)))
            {
                var resultDeclaration = Declare("result", typeof(Response), This.Property("Pipeline").Invoke(isAsync ? "ProcessMessageAsync" : "ProcessMessage", [messageVariable, contextVariable], null, isAsync), out var resultVariable);
                tryStatement.Add(resultDeclaration);
                var responseDeclaration = Declare("response", responseType, Static(typeof(Response)).Invoke(nameof(Response.FromValue), [resultVariable.CastTo(ResourceData.Type), resultVariable]), out responseVariable);
                tryStatement.Add(responseDeclaration);
            }
            else
            {
                var responseDeclaration = Declare("response", typeof(Response), This.Property("Pipeline").Invoke(isAsync ? "ProcessMessageAsync" : "ProcessMessage", [messageVariable, contextVariable], null, isAsync), out responseVariable);
                tryStatement.Add(responseDeclaration);
            }

            if (method is InputLongRunningServiceMethod || method is InputLongRunningPagingServiceMethod)
            {
                OperationFinalStateVia finalStateVia = OperationFinalStateVia.Location;
                if (method is InputLongRunningServiceMethod lroMethod)
                {
                    finalStateVia = (OperationFinalStateVia)lroMethod.LongRunningServiceMetadata.FinalStateVia;
                }
                else if (method is InputLongRunningPagingServiceMethod lroPagingMethod)
                {
                    finalStateVia = (OperationFinalStateVia)lroPagingMethod.LongRunningServiceMetadata.FinalStateVia;
                }

                var armOperationType = !isGeneric ? ManagementClientGenerator.Instance.OutputLibrary.ArmOperation.Type : ManagementClientGenerator.Instance.OutputLibrary.GenericArmOperation.Type.MakeGenericType([ResourceClientCharpType]);
                ValueExpression[] armOperationArguments = [_clientDiagonosticsField, This.Property("Pipeline"), messageVariable.Property("Request"), isGeneric ? responseVariable.Invoke("GetRawResponse") : responseVariable, Static(typeof(OperationFinalStateVia)).Property(finalStateVia.ToString())];
                var operationDeclaration = Declare("operation", armOperationType, New.Instance(armOperationType, isGeneric ? [New.Instance(Source.Type, This.Property("Client")), .. armOperationArguments] : armOperationArguments), out var operationVariable);

                tryStatement.Add(operationDeclaration);
                tryStatement.Add(new IfStatement(KnownAzureParameters.WaitUntil.Equal(Static(typeof(WaitUntil)).Property(nameof(WaitUntil.Completed))))
                {
                    isAsync
                    ? operationVariable.Invoke(isGeneric ? "WaitForCompletionAsync" : "WaitForCompletionResponseAsync", [cancellationToken], null, isAsync).Terminate()
                    : operationVariable.Invoke(isGeneric ? "WaitForCompletion" : "WaitForCompletionResponse", cancellationToken).Terminate()
                });
                tryStatement.Add(Return(operationVariable));
            }
            else
            {
                tryStatement.Add(BuildReturnStatements(responseVariable, signature));
            }

            return tryStatement;
        }

        protected virtual MethodBodyStatement BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            List<MethodBodyStatement> statements =
            [
                new IfStatement(responseVariable.Property("Value").Equal(Null))
                        {
                            ((KeywordExpression)ThrowExpression(New.Instance(typeof(RequestFailedException), responseVariable.Invoke("GetRawResponse")))).Terminate()
                        },
            ];
            var returnValueExpression =  New.Instance(ResourceClientCharpType, This.Property("Client"), responseVariable.Property("Value"));
            statements.Add(Return(Static(typeof(Response)).Invoke(nameof(Response.FromValue), returnValueExpression, responseVariable.Invoke("GetRawResponse"))));

            return statements;
        }

        private static CSharpType GetResponseType(MethodProvider convenienceMethod, bool isAsync) => isAsync ? convenienceMethod.Signature.ReturnType?.Arguments[0]! : convenienceMethod.Signature.ReturnType!;

        private ValueExpression[] PopulateArguments(IReadOnlyList<ParameterProvider> parameters, MethodProvider convenienceMethod, VariableExpression contextVariable)
        {
            var arguments = new List<ValueExpression>();
            foreach (var parameter in parameters)
            {
                if (parameter.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(Static(typeof(Guid)).Invoke(nameof(Guid.Parse), This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.SubscriptionId))));
                }
                else if (parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.ResourceGroupName)));
                }
                // TODO: handle parents
                else if (parameter.Name.Equals(ContextualParameters.Last(), StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.Name)));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    var resource = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(ResourceData.Type));
                    arguments.Add(resource);
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    var cancellationToken = convenienceMethod.Signature.Parameters.Single(p => p.Type.Equals(typeof(CancellationToken)));
                    arguments.Add(contextVariable);
                }
                else
                {
                    arguments.Add(parameter);
                }
            }
            return arguments.ToArray();
        }

        // TODO: get clean name of operation Name
        protected MethodProvider GetCorrespondingConvenienceMethod(InputOperation operation, bool isAsync)
            => _clientProvider.CanonicalView.Methods.Single(m => m.Signature.Name.Equals(isAsync ? $"{operation.Name}Async" : operation.Name, StringComparison.OrdinalIgnoreCase) && m.Signature.Parameters.Any(p => p.Type.Equals(typeof(CancellationToken))));

        private MethodProvider GetCorrespondingRequestMethod(InputOperation operation)
            => _clientProvider.RestClient.Methods.Single(m => m.Signature.Name.Equals($"Create{operation.Name}Request", StringComparison.OrdinalIgnoreCase));

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{SpecName.ToLower()}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [ResourceTypeExpression, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }
    }
}
