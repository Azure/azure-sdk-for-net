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
using Azure.Generator.Management.Visitors;
using Azure.ResourceManager;
using Humanizer;
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
        internal static ResourceClientProvider Create(InputModelType model, ResourceMetadata resourceMetadata)
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

        private readonly RequestPathPattern _contextualRequestPattern;
        private readonly ResourceMetadata _resourceMetadata;

        private protected readonly ClientProvider _restClientProvider;
        private protected readonly FieldProvider _clientDiagnosticsField;
        private protected readonly FieldProvider _clientField;

        private protected ResourceClientProvider(InputModelType model, ResourceMetadata resourceMetadata, RequestPathPattern contextualRequestPattern)
        {
            _resourceMetadata = resourceMetadata;
            _hasGetMethod = resourceMetadata.Methods.Any(m => m.Kind == ResourceOperationKind.Get);
            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));
            _shouldGenerateTagMethods = ShouldGenerateTagMethods(model);

            // TODO -- the name of a resource is not always the name of its model. Maybe the resource metadata should have a property for the name of the resource?
            SpecName = model.Name.ToIdentifierName();

            // We should be able to assume that all operations in the resource client are for the same resource
            _contextualRequestPattern = contextualRequestPattern;
            _resourceServiceMethods = resourceMetadata.Methods.Select(m => (m.Kind, ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!));
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            // TODO: handle multiple clients in the future, for now we assume that there is only one client for the resource.
            var inputClients = resourceMetadata.Methods.Select(m => ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!)!).Distinct();
            _restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClients.First())!;

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), $"_{SpecName.ToLower()}ClientDiagnostics", this);
            _clientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _restClientProvider.Type, $"_{SpecName.ToLower()}RestClient", this);
        }

        private ResourceClientProvider(InputModelType model, ResourceMetadata resourceMetadata)
            : this(model, resourceMetadata, new RequestPathPattern(resourceMetadata.ResourceIdPattern))
        {
        }

        internal ResourceScope ResourceScope => _resourceMetadata.ResourceScope;
        internal string? ParentResourceIdPattern => _resourceMetadata.ParentResourceId;

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        protected override string BuildName() => $"{SpecName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

        internal ModelProvider ResourceData { get; }
        internal string SpecName { get; }
        internal IEnumerable<(ResourceOperationKind Kind, InputServiceMethod Method)> ResourceServiceMethods => _resourceServiceMethods;

        internal string? SingletonResourceName => _resourceMetadata.SingletonResourceName;

        public bool IsSingleton => SingletonResourceName is not null;

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        private IReadOnlyList<ResourceClientProvider>? _childResources;
        public IReadOnlyList<ResourceClientProvider> ChildResources => _childResources ??= BuildChildResources();

        private protected virtual IReadOnlyList<ResourceClientProvider> BuildChildResources()
        {
            // first we find all the resources from the output library
            var allResources = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>()
                // we have to do this because the ResourceCollectionClientProvider inherits ResourceClientProvider, but they are not resources.
                .Where(r => r is not ResourceCollectionClientProvider);

            var childResources = new List<ResourceClientProvider>();
            // TODO -- this is quite cumbersome that every time we have to iterate all the resources to find the child resources of this resource.
            // maybe later we could maintain a map in the OutputLibrary so that we could get them directly.
            foreach (var candidate in allResources)
            {
                // check if the request path of this resource, is the same as the parent resource request path of the candidate.
                if (_resourceMetadata.ResourceIdPattern == candidate._resourceMetadata.ParentResourceId)
                {
                    childResources.Add(candidate);
                }
            }
            return childResources;
        }

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
            => [ConstructorProviderHelpers.BuildMockingConstructor(this), BuildResourceDataConstructor(), BuildResourceIdentifierConstructor()];

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

        // TODO -- this is temporary. We should change this to find the corresponding parameters in ContextualParameters after it is refactored to consume parent resources.
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

            foreach (var segment in _contextualRequestPattern)
            {
                if (segment.IsConstant)
                {
                    formatBuilder.Append($"/{segment}");
                }
                else
                {
                    if (formatBuilder.Length > 0)
                    {
                        formatBuilder.Append('/');
                    }
                    var variableName = segment.VariableName;
                    var parameter = new ParameterProvider(variableName, $"The {variableName}", GetPathParameterType(variableName));
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

        internal string ResourceTypeValue => _resourceMetadata.ResourceType;

        protected virtual ScopedApi<ResourceType> ResourceTypeExpression => _resourceTypeField.As<ResourceType>();

        protected internal virtual CSharpType ResourceClientCSharpType => Type;

        internal ScopedApi<ClientDiagnostics> GetClientDiagnosticsField() => _clientDiagnosticsField.As<ClientDiagnostics>();
        internal ValueExpression GetRestClientField() => _clientField;
        internal ClientProvider GetClientProvider() => _restClientProvider;

        private IReadOnlyDictionary<string, ContextualParameter>? _contextualParameters;
        internal IReadOnlyDictionary<string, ContextualParameter> ContextualParameters => _contextualParameters ??= ContextualParameterBuilder.BuildContextualParameters(_contextualRequestPattern)
            .ToDictionary(c => c.VariableName);

        protected override CSharpType? GetBaseType() => typeof(ArmResource);

        protected override MethodProvider[] BuildMethods()
        {
            var operationMethods = new List<MethodProvider>();
            UpdateOperationMethodProvider? updateMethodProvider = null;
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
                    var provider = new UpdateOperationMethodProvider(this, method, convenienceMethod, false);
                    operationMethods.Add(provider);

                    updateMethodProvider = provider;

                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    var asyncProvider = new UpdateOperationMethodProvider(this, method, asyncConvenienceMethod, true);
                    operationMethods.Add(asyncProvider);
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
                if (updateMethodProvider is null)
                {
                    throw new InvalidOperationException($"Update method provider is required for tag methods but was not found for resource {SpecName}.");
                }

                methods.AddRange([
                    new AddTagMethodProvider(this, updateMethodProvider, true),
                    new AddTagMethodProvider(this, updateMethodProvider, false),
                    new SetTagsMethodProvider(this, updateMethodProvider, true),
                    new SetTagsMethodProvider(this, updateMethodProvider, false),
                    new RemoveTagMethodProvider(this, updateMethodProvider, true),
                    new RemoveTagMethodProvider(this, updateMethodProvider, false)
                ]);
            }

            // add method to get the child resource collection from the current resource.
            foreach (var childResource in ChildResources)
            {
                methods.Add(BuildGetChildResourceMethod(childResource));
            }

            return [.. methods];
        }

        private MethodProvider BuildGetChildResourceMethod(ResourceClientProvider childResource)
        {
            var thisResource = This.As<ArmResource>();
            if (childResource.IsSingleton)
            {
                var signature = new MethodSignature(
                    $"Get{childResource.SpecName}",
                    $"Gets an object representing a {childResource.SpecName} along with the instance operations that can be performed on it in the {SpecName}.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    childResource.Type,
                    $"Returns a {childResource.Type:C} object.",
                    []);
                var lastSegment = childResource.ResourceTypeValue.Split('/')[^1];
                var bodyStatement = Return(New.Instance(childResource.Type, thisResource.Client(), thisResource.Id().AppendChildResource(Literal(lastSegment), Literal(childResource.SingletonResourceName!))));
                return new MethodProvider(signature, bodyStatement, this);
            }
            else
            {
                Debug.Assert(childResource.ResourceCollection is not null, "Child resource collection should not be null for non-singleton resources.");
                var pluralChildResourceName = childResource.SpecName.Pluralize();
                var signature = new MethodSignature(
                    $"Get{pluralChildResourceName}",
                    $"Gets a collection of {pluralChildResourceName} in the {SpecName}.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    childResource.ResourceCollection.Type,
                    $"An object representing collection of {pluralChildResourceName} and their operations over a {SpecName}.",
                    []);
                var bodyStatement = Return(thisResource.GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(childResource.ResourceCollection.Type, client, thisResource.Id())));
                return new MethodProvider(signature, bodyStatement, this);
            }
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
                    if (property.SerializedName == "tags" && property.Type is InputDictionaryType
                        {
                            KeyType: InputPrimitiveType { Kind: InputPrimitiveTypeKind.String },
                            ValueType: InputPrimitiveType { Kind: InputPrimitiveTypeKind.String }
                        })
                    {
                        return true;
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

        internal IReadOnlyList<ValueExpression> PopulateArguments(
            IReadOnlyList<ParameterProvider> requestParameters,
            VariableExpression contextVariable,
            IReadOnlyList<ParameterProvider> methodParameters,
            InputOperation operation)
        {
            var idProperty = This.As<ArmResource>().Id();
            var arguments = new List<ValueExpression>();
            // here we always assume that the parameter name matches the parameter name in the request path.
            foreach (var parameter in requestParameters)
            {
                // find the corresponding contextual parameter in the contextual parameter list
                if (ContextualParameters.TryGetValue(parameter.Name, out var contextualParameter))
                {
                    arguments.Add(Convert(contextualParameter.BuildValueExpression(idProperty), typeof(string), parameter.Type));
                }
                else if (parameter.Type.Equals(typeof(RequestContent)))
                {
                    if (methodParameters.Count > 0)
                    {
                        // find the body parameter in the method parameters
                        var bodyParameter = methodParameters.Single(p => p.Location == ParameterLocation.Body);
                        arguments.Add(Static(bodyParameter.Type).Invoke(SerializationVisitor.ToRequestContentMethodName, [bodyParameter]));
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

        private static ValueExpression Convert(ValueExpression expression, CSharpType fromType, CSharpType toType)
        {
            if (fromType.Equals(toType))
            {
                return expression; // No conversion needed
            }

            if (toType.IsFrameworkType && toType.FrameworkType == typeof(Guid))
            {
                return Static<Guid>().Invoke(nameof(Guid.Parse), expression);
            }

            // other unhandled cases, we will add when we need them in the future.
            return expression;
        }
    }
}
