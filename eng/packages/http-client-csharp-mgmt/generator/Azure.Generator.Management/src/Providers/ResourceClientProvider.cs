// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Extensions;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Providers.TagMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Provides a resource client type.
    /// </summary>
    internal class ResourceClientProvider : TypeProvider
    {
        public static ResourceClientProvider Create(InputModelType model, ResourceMetadata resourceMetadata)
        {
            var resource = new ResourceClientProvider(model, resourceMetadata);
            if (!resource.IsSingleton)
            {
                var collection = new ResourceCollectionClientProvider(model, resourceMetadata, resource);
                resource.ResourceCollection = collection;
            }

            return resource;
        }

        private IEnumerable<(ResourceOperationKind, InputServiceMethod)> _resourceServiceMethods;

        private readonly FieldProvider _dataField;
        private readonly FieldProvider _resourceTypeField;
        private readonly bool _hasGetMethod;
        private readonly bool _shouldGenerateTagMethods;

        private readonly RequestPathPattern _resourceIdPattern;
        private readonly ResourceMetadata _resourceMetadata;

        private protected readonly ClientProvider _restClientProvider;
        private protected readonly FieldProvider _clientDiagnosticsField;
        private protected readonly FieldProvider _clientField;

        private protected ResourceClientProvider(InputModelType model, ResourceMetadata resourceMetadata)
        {
            IsSingleton = resourceMetadata.IsSingleton;
            _resourceMetadata = resourceMetadata;
            ResourceScope = resourceMetadata.ResourceScope;
            var resourceType = resourceMetadata.ResourceType;
            _hasGetMethod = resourceMetadata.Methods.Any(m => m.Kind == ResourceOperationKind.Get);
            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(resourceType));
            _shouldGenerateTagMethods = ShouldGenerateTagMethods(model);

            // TODO -- the name of a resource is not always the name of its model. Maybe the resource metadata should have a property for the name of the resource?
            SpecName = model.Name.ToIdentifierName();

            // We should be able to assume that all operations in the resource client are for the same resource
            _resourceIdPattern = new RequestPathPattern(_resourceMetadata.ResourceIdPattern);
            _resourceServiceMethods = resourceMetadata.Methods.Select(m => (m.Kind, ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!));
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            // TODO: handle multiple clients in the future, for now we assume that there is only one client for the resource.
            var inputClients = resourceMetadata.Methods.Select(m => ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!)!).Distinct();
            _restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClients.First())!;

            ContextualParameters = GetContextualParameters(_resourceIdPattern);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), $"_{SpecName.ToLower()}ClientDiagnostics", this);
            _clientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _restClientProvider.Type, $"_{SpecName.ToLower()}RestClient", this);
        }

        internal ResourceScope ResourceScope { get; }

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        private IReadOnlyList<string> GetContextualParameters(string contextualRequestPath)
        {
            var contextualParametersList = new List<string>();
            var contextualSegments = new RequestPathPattern(contextualRequestPath);
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
        internal IEnumerable<(ResourceOperationKind Kind, InputServiceMethod Method)> ResourceServiceMethods => _resourceServiceMethods;

        public bool IsSingleton { get; }

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override FieldProvider[] BuildFields() => [_clientDiagnosticsField, _clientField, _dataField, _resourceTypeField];

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

        protected override TypeProvider[] BuildSerializationProviders() => [new ResourceSerializationProvider(this)];

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
                _clientDiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), ResourceTypeExpression.Property(nameof(ResourceType.Namespace)), This.As<ArmResource>().Diagnostics())).Terminate(),
                TryGetApiVersion(out var apiVersion).Terminate(),
                _clientField.Assign(New.Instance(_restClientProvider.Type, _clientDiagnosticsField, This.As<ArmResource>().Pipeline(), This.As<ArmResource>().Endpoint(), apiVersion)).Terminate(),
                Static(Type).Invoke(ValidateResourceIdMethodName, idParameter).Terminate()
            };

            return new ConstructorProvider(signature, bodyStatements, this);
        }

        internal const string ValidateResourceIdMethodName = "ValidateResourceId";

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
            var bodyStatements = new IfStatement(idParameter.As<ResourceIdentifier>().ResourceType().NotEqual(ResourceTypeExpression))
            {
                Throw(New.ArgumentException(idParameter, StringSnippets.Format(Literal("Invalid resource type {0} expected {1}"), idParameter.As<ResourceIdentifier>().ResourceType(), ResourceTypeExpression), false))
            };
            return new MethodProvider(signature, bodyStatements, this);
        }

        private CSharpType GetPathParameterType(string parameterName)
        {
            foreach (var (kind, method) in _resourceServiceMethods)
            {
                if (!kind.IsCrudKind())
                {
                    continue; // Skip non-CRUD operations
                }
                // iterate through all parameters in this method to find a matching parameter
                foreach (var parameter in method.Operation.Parameters)
                {
                    if (parameter.Location != InputRequestLocation.Path)
                    {
                        continue; // Skip parameters that are not in the path
                    }
                    if (parameter.Name == parameterName)
                    {
                        var csharpType = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(parameter.Type) ?? typeof(string);
                        return parameterName switch
                        {
                            "subscriptionId" when csharpType.Equals(typeof(Guid)) => typeof(string),
                            // Cases will be added later
                            _ => csharpType
                        };
                    }
                }
            }

            // what if we did not find the parameter in any method?
            ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                "general-warning",
                $"Cannot find parameter {parameterName} in any registered operations in resource {SpecName}."
                );

            return typeof(string); // Default to string if not found
        }

        private MethodProvider BuildCreateResourceIdentifierMethod()
        {
            var parameters = new List<ParameterProvider>();
            var formatBuilder = new StringBuilder();
            var refCount = 0;

            foreach (var segment in _resourceIdPattern)
            {
                bool isConstant = RequestPathPattern.IsSegmentConstant(segment);

                if (isConstant)
                {
                    formatBuilder.Append($"/{segment}");
                }
                else
                {
                    if (formatBuilder.Length > 0)
                    {
                        formatBuilder.Append('/');
                    }
                    var trimmed = RequestPathPattern.TrimSegment(segment);
                    var parameter = new ParameterProvider(trimmed, $"The {trimmed}", GetPathParameterType(trimmed));
                    parameters.Add(parameter);
                    formatBuilder.Append($"{{{refCount++}}}");
                }
            }

            var signature = new MethodSignature(
                "CreateResourceIdentifier",
                $"Generate the resource identifier for this resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(ResourceIdentifier),
                null,
                parameters);

            var bodyStatements = new MethodBodyStatement[]
            {
                Declare("resourceId", typeof(string), new FormattableStringExpression(formatBuilder.ToString(), parameters.Select(p => p.AsExpression()).ToArray()), out var resourceIdVar),
                Return(New.Instance(typeof(ResourceIdentifier), resourceIdVar))
            };

            return new MethodProvider(signature, bodyStatements, this);
        }

        protected virtual ScopedApi<ResourceType> ResourceTypeExpression => _resourceTypeField.As<ResourceType>();

        protected internal virtual CSharpType ResourceClientCSharpType => Type;

        internal ScopedApi<ClientDiagnostics> GetClientDiagnosticsField() => _clientDiagnosticsField.As<ClientDiagnostics>();
        internal ValueExpression GetRestClientField() => _clientField;
        internal ClientProvider GetClientProvider() => _restClientProvider;
        internal IReadOnlyList<string> ContextualParameters { get; }

        /// <summary>
        /// Gets the collection of parameter names that are implicitly available from the resource context
        /// and should be excluded from method parameters.
        /// </summary>
        internal virtual IReadOnlyList<string> ImplicitParameterNames => ContextualParameters;

        protected override CSharpType? GetBaseType() => typeof(ArmResource);

        protected override MethodProvider[] BuildMethods()
        {
            var operationMethods = new List<MethodProvider>();
            foreach (var (methodKind, method) in _resourceServiceMethods)
            {
                var convenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, false);
                // exclude the List operations for resource, they will be in ResourceCollection
                var returnType = convenienceMethod.Signature.ReturnType!;
                if ((returnType.IsFrameworkType && returnType.IsList) || (method is InputPagingServiceMethod pagingMethod && pagingMethod.PagingMetadata.ItemPropertySegments.Any() == true))
                {
                    continue;
                }

                // Skip Create operations for non-singleton resources
                if (!IsSingleton && methodKind == ResourceOperationKind.Create)
                {
                    continue;
                }

                // Check if this is an update operation (PUT or Patch method for non-singleton resource)
                var isUpdateOperation = (methodKind == ResourceOperationKind.Create || methodKind == ResourceOperationKind.Update) && !IsSingleton;

                if (isUpdateOperation)
                {
                    var updateMethodProvider = new UpdateOperationMethodProvider(this, method, convenienceMethod, false);
                    operationMethods.Add(updateMethodProvider);

                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, method, asyncConvenienceMethod, true);
                    operationMethods.Add(updateAsyncMethodProvider);
                }
                else
                {
                    operationMethods.Add(new ResourceOperationMethodProvider(this, method, convenienceMethod, false));
                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, method, asyncConvenienceMethod, true));
                }
            }

            var methods = new List<MethodProvider>
            {
                BuildCreateResourceIdentifierMethod(),
                BuildValidateResourceIdMethod()
            };
            methods.AddRange(operationMethods);

            // Only generate tag methods if the resource model has tag properties
            if (_shouldGenerateTagMethods)
            {
                methods.AddRange([
                    new AddTagMethodProvider(this, true),
                    new AddTagMethodProvider(this, false),
                    new SetTagsMethodProvider(this, true),
                    new SetTagsMethodProvider(this, false),
                    new RemoveTagMethodProvider(this, true),
                    new RemoveTagMethodProvider(this, false)
                ]);
            }

            return [.. methods];
        }

        private bool ShouldGenerateTagMethods(InputModelType model)
        {
            if (!_hasGetMethod)
            {
                return false; // If there is no Get method, we cannot retrieve tags, so no need to generate tag methods.
            }

            InputModelType? currentModel = model;
            while (currentModel != null)
            {
                foreach (var property in currentModel.Properties)
                {
                    if (property.Name == "tags" && property.Type is not null)
                    {
                       if (property.Type is InputDictionaryType dictType)
                       {
                            if (dictType.KeyType is InputPrimitiveType kt && kt.Kind == InputPrimitiveTypeKind.String &&
                                dictType.ValueType is InputPrimitiveType vt && vt.Kind == InputPrimitiveTypeKind.String)
                            {
                                return true;
                            }
                       }
                    }
                }
                currentModel = currentModel.BaseModel;
            }
            return false;
        }

        public ScopedApi<bool> TryGetApiVersion(out ScopedApi<string> apiVersion)
        {
            var apiVersionDeclaration = new VariableExpression(typeof(string), $"{SpecName.ToLower()}ApiVersion");
            apiVersion = apiVersionDeclaration.As<string>();
            var invocation = new InvokeMethodExpression(This, "TryGetApiVersion", [ResourceTypeExpression, new DeclarationExpression(apiVersionDeclaration, true)]);
            return invocation.As<bool>();
        }

        public ValueExpression[] PopulateArguments(
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression contextVariable,
            IReadOnlyList<ParameterProvider> methodParameters,
            InputOperation operation)
        {
            var arguments = new List<ValueExpression>();
            foreach (var parameter in requestParameters)
            {
                if (parameter.Name.Equals("subscriptionId", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        Static(typeof(Guid)).Invoke(
                            nameof(Guid.Parse),
                            This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.SubscriptionId))));
                }
                else if (parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.ResourceGroupName)));
                }
                // TODO: handle parents
                // Handle resource name - the last contextual parameter
                else if (ContextualParameters.Any() && parameter.Name.Equals(ContextualParameters.Last(), StringComparison.InvariantCultureIgnoreCase))
                {
                    arguments.Add(
                        This.Property(nameof(ArmResource.Id)).Property(nameof(ResourceIdentifier.Name)));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    if (methodParameters.Count > 0)
                    {
                        // Find the content parameter in the method parameters
                        // TODO: need to revisit the filter here
                        var contentInputParameter = operation.Parameters.First(p => !ImplicitParameterNames.Contains(p.Name) && p.Kind == InputParameterKind.Method && p.Type is not InputPrimitiveType);
                        var resource = methodParameters.Single(p => p.Name == "data" || p.Name == contentInputParameter.Name);
                        arguments.Add(resource);
                    }
                }
                else if (parameter.Type.Equals(typeof(RequestContext)))
                {
                    arguments.Add(contextVariable);
                }
                else
                {
                    arguments.Add(methodParameters.Single(p => p.Name == parameter.Name));
                }
            }
            return [.. arguments];
        }
    }
}
