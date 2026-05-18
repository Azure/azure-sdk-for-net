// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Models;
using Azure.Generator.Management.Providers.OperationMethodProviders;
using Azure.Generator.Management.Providers.TagMethodProviders;
using Azure.Generator.Management.Snippets;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Humanizer;
using Microsoft.CodeAnalysis;
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
    internal sealed class ResourceClientProvider : TypeProvider
    {
        internal static ResourceClientProvider Create(ArmResourceMetadata resourceMetadata, IReadOnlyList<ResourceMethod> methodsInResource, IReadOnlyList<ResourceMethod> methodsInCollection)
        {
            // Create a resource that supports multiple clients, using ResourceName from metadata
            var resource = new ResourceClientProvider(resourceMetadata.ResourceName, resourceMetadata.ResourceModel, methodsInResource, resourceMetadata);
            if (!resource.IsSingleton)
            {
                var collection = new ResourceCollectionClientProvider(resource, resourceMetadata.ResourceModel, methodsInCollection, resourceMetadata);
                resource.ResourceCollection = collection;
            }

            return resource;
        }

        private IReadOnlyList<ResourceMethod> _resourceServiceMethods;

        private readonly FieldProvider _dataField;
        private readonly FieldProvider _resourceTypeField;
        private readonly InputModelType _inputModel;

        private readonly ArmResourceMetadata _resourceMetadata;

        private readonly OperationContext _operationContext;

        // Support for multiple rest clients
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        private readonly ResourceMethod _readMethod;

        private ResourceClientProvider(string resourceName, InputModelType model, IReadOnlyList<ResourceMethod> resourceMethods, ArmResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _operationContext = OperationContext.Create(resourceMetadata.ResourceIdPattern);
            _inputModel = model;

            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));

            ResourceName = resourceName;

            _resourceServiceMethods = resourceMethods;
            _readMethod = resourceMethods.First(m => m.Kind == ResourceOperationKind.Read)!;
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
        }

        internal ResourceScope ResourceScope => _resourceMetadata.Scope.Kind;
        internal RequestPathPattern? ParentResourceIdPattern => _resourceMetadata.ParentResourceId;
        internal RequestPathPattern ResourceIdPattern => _resourceMetadata.ResourceIdPattern;

        internal bool IsExtensionResource => ResourceScope == ResourceScope.Extension;

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        protected override string BuildName() => ResourceName.EndsWith("Resource") ? ResourceName : $"{ResourceName}Resource";

        protected override FormattableString BuildDescription() => $"A class representing a {ResourceName} along with the instance operations that can be performed on it.\nIf you have a {typeof(ResourceIdentifier):C} you can construct a {Type:C} from an instance of {typeof(ArmClient):C} using the GetResource method.\nOtherwise you can get one from its parent resource {TypeOfParentResource:C} using the {FactoryMethodSignature.Name} method.";

        internal ModelProvider ResourceData { get; }
        internal string ResourceName { get; }

        internal string? SingletonResourceName => _resourceMetadata.SingletonResourceName;

        public bool IsSingleton => SingletonResourceName is not null;

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        private IReadOnlyList<ResourceClientProvider>? _childResources;
        public IReadOnlyList<ResourceClientProvider> ChildResources => _childResources ??= BuildChildResources();

        private CSharpType? _typeOfParentResource;
        internal CSharpType TypeOfParentResource => _typeOfParentResource ??= BuildTypeOfParentResource();

        private IReadOnlyList<ResourceClientProvider> BuildChildResources()
        {
            var childResources = new List<ResourceClientProvider>(_resourceMetadata.ChildResourceIds.Count);
            // the resourcemetadata has a list of the ids of child resources
            foreach (var childId in _resourceMetadata.ChildResourceIds)
            {
                // if the child resource id is not in the output library, we cannot find it.
                var childResource = ManagementClientGenerator.Instance.OutputLibrary.GetResourceById(childId);
                if (childResource is null)
                {
                    ManagementClientGenerator.Instance.Emitter.ReportDiagnostic(
                        "general-warning",
                        $"Cannot find child resource with id {childId} for resource {ResourceName}."
                    );
                    continue;
                }
                childResources.Add(childResource);
            }
            return childResources;
        }

        private CSharpType BuildTypeOfParentResource()
        {
            // if the resource has a parent resource id, we can find it in the output library
            if (_resourceMetadata.ParentResourceId is not null)
            {
                return ManagementClientGenerator.Instance.OutputLibrary.GetResourceById(_resourceMetadata.ParentResourceId).Type;
            }

            // if not and this is an extension resource, we return ArmResource as the parent type as fallback
            if (_resourceMetadata.Scope.Kind == ResourceScope.Extension)
            {
                return typeof(ArmResource);
            }

            // if it does not, this resource's parent must be one of the MockableResource
            return ManagementClientGenerator.Instance.OutputLibrary.GetMockableResourceByScope(_resourceMetadata.Scope.Kind).ArmCoreType;
        }

        private MethodSignature? _factoryMethodSignature;
        internal MethodSignature FactoryMethodSignature => _factoryMethodSignature ??= BuildFactoryMethodSignature();

        private MethodSignature BuildFactoryMethodSignature()
        {
            if (ResourceCollection != null)
            {
                // we have the collection, we are not a singleton resource
                var methodName = ResourceName.GetCollectionMethodName();
                // Use inputIsKnownToBeSingular: false because some words like "Quota" and "Metadata"
                // are treated by Humanizer as already plural (from Latin), and we want to preserve
                // them unchanged rather than incorrectly pluralizing them.
                var pluralOfResourceName = ResourceName.PluralizeLastWord(inputIsKnownToBeSingular: false);
                return new MethodSignature(
                    methodName,
                    $"Gets a collection of {pluralOfResourceName} in the {TypeOfParentResource:C}",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    ResourceCollection.Type,
                    $"An object representing collection of {pluralOfResourceName} and their operations over a {Name}.",
                    [.. ResourceCollection.PathParameters]
                    );
            }
            else
            {
                // we do not have a collection, we are a singleton resource
                return new MethodSignature(
                    $"Get{ResourceName}",
                    $"Gets an object representing a {Type:C} along with the instance operations that can be performed on it in the {TypeOfParentResource:C}.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    Type,
                    $"Returns a {Type:C} object.",
                    []
                    );
            }
        }

        protected override FieldProvider[] BuildFields()
        {
            List<FieldProvider> fields = new();
            foreach (var clientInfo in _clientInfos.Values)
            {
                fields.Add(clientInfo.DiagnosticsField);
                fields.Add(clientInfo.RestClientField);
            }
            fields.Add(_dataField);
            fields.Add(_resourceTypeField);

            return fields.ToArray();
        }

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
            var properties = new List<PropertyProvider>
            {
                hasDataProperty,
                dataProperty
            };

            foreach (var clientInfo in _clientInfos.Values)
            {
                if (clientInfo.DiagnosticProperty is not null)
                {
                    properties.Add(clientInfo.DiagnosticProperty);
                }
                if (clientInfo.RestClientProperty is not null)
                {
                    properties.Add(clientInfo.RestClientProperty);
                }
            }

            return [.. properties];
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

        private ConstructorProvider BuildResourceIdentifierConstructor()
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

            var thisResource = This.As<ArmResource>();

            var bodyStatements = new List<MethodBodyStatement>();

            bodyStatements.Add(thisResource.TryGetApiVersion(_resourceTypeField, $"{ResourceName}ApiVersion".ToVariableName(), out var apiVersion).Terminate());

            // Initialize all client diagnostics and rest client fields
            foreach (var (inputClient, clientInfo) in _clientInfos)
            {
                bodyStatements.Add(clientInfo.DiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeField.As<ResourceType>().Namespace(), thisResource.Diagnostics())).Terminate());
                var effectiveApiVersion = apiVersion.NullCoalesce(Literal(inputClient.CurrentApiVersion));
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type, clientInfo.DiagnosticsField, thisResource.Pipeline(), thisResource.Endpoint(), effectiveApiVersion)).Terminate());
            }

            bodyStatements.Add(Static(Type).As<ArmResource>().ValidateResourceId(idParameter).Terminate());

            return new ConstructorProvider(signature, bodyStatements.ToArray(), this);
        }

        private MethodProvider BuildCreateResourceIdentifierMethod()
        {
            var parameters = new List<ParameterProvider>();
            var formatBuilder = new StringBuilder();
            var refCount = 0;

            foreach (var segment in _operationContext.ContextualPath)
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
                    var parameter = new ParameterProvider(variableName, $"The {variableName}", ResourceHelpers.GetRequestPathParameterType(variableName, _readMethod.InputMethod));
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
                Declare("resourceId", typeof(string), new FormattableStringExpression(formatBuilder.ToString(), parameters.Select(p => p.AsArgument()).ToArray()), out var resourceIdVar),
                Return(New.Instance(typeof(ResourceIdentifier), resourceIdVar))
            };

            return new MethodProvider(signature, bodyStatements, this);
        }

        internal string ResourceTypeValue => _resourceMetadata.ResourceType;

        protected override CSharpType? BuildBaseType() => typeof(ArmResource);

        protected override MethodProvider[] BuildMethods()
        {
            var operationMethods = new List<MethodProvider>();
            UpdateOperationMethodProvider? updateMethodProvider = null;

            foreach (var resourceMethod in _resourceServiceMethods)
            {
                var methodKind = resourceMethod.Kind;
                var method = resourceMethod.InputMethod;
                var inputClient = resourceMethod.InputClient;

                var isFakeLro = ResourceHelpers.ShouldMakeLro(methodKind);

                // Get the appropriate rest client for this specific method
                var restClientInfo = _clientInfos[inputClient];

                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(method.Operation, false);
                var asyncConvenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(method.Operation, true);

                if (method is InputPagingServiceMethod pagingMethod)
                {
                    // Use PageableOperationMethodProvider for InputPagingServiceMethod
                    operationMethods.Add(new PageableOperationMethodProvider(this, _operationContext, restClientInfo, pagingMethod, true, methodName: ResourceHelpers.GetOperationMethodName(methodKind, true, false)));
                    operationMethods.Add(new PageableOperationMethodProvider(this, _operationContext, restClientInfo, pagingMethod, false, methodName: ResourceHelpers.GetOperationMethodName(methodKind, false, false)));

                    continue;
                }

                // Check if this is an update operation (PUT or Patch method for non-singleton resource)
                var isUpdateOperation = (methodKind == ResourceOperationKind.Create || methodKind == ResourceOperationKind.Update) && !IsSingleton;

                if (isUpdateOperation)
                {
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, _operationContext, restClientInfo, method, true, methodKind, isFakeLro);
                    operationMethods.Add(updateAsyncMethodProvider);

                    updateMethodProvider = new UpdateOperationMethodProvider(this, _operationContext, restClientInfo, method, false, methodKind, isFakeLro);
                    operationMethods.Add(updateMethodProvider);
                }
                else
                {
                    var asyncMethodName = ResourceHelpers.GetOperationMethodName(methodKind, true, false);
                    operationMethods.Add(BuildResourceOperationMethod(method, restClientInfo, true, asyncMethodName, isFakeLro));
                    var methodName = ResourceHelpers.GetOperationMethodName(methodKind, false, false);
                    operationMethods.Add(BuildResourceOperationMethod(method, restClientInfo, false, methodName, isFakeLro));
                }
            }

            var methods = new List<MethodProvider>
            {
                BuildCreateResourceIdentifierMethod(),
                ResourceMethodSnippets.BuildValidateResourceIdMethod(this, _resourceTypeField)
            };
            methods.AddRange(operationMethods);

            // Only generate tag methods if the resource model has tag properties, has get and update methods
            if (HasTags() && _readMethod is not null)
            {
                (bool isPatch, ResourceMethod? tagUpdateMethod) = PopulateUpdateMethod();
                if (tagUpdateMethod is not null)
                {
                    var inputReadMethod = _readMethod.InputMethod;
                    var inputReadClient = _readMethod.InputClient;
                    var inputUpdateClient = tagUpdateMethod.InputClient;
                    if (inputReadClient is not null)
                    {
                        var updateRestClientInfo = _clientInfos[inputUpdateClient];
                        var getRestClientInfo = _clientInfos[inputReadClient];
                        var isFakeLro = ResourceHelpers.ShouldMakeLro(tagUpdateMethod.Kind);
                        var tagUpdateMethodProvider = new UpdateOperationMethodProvider(this, _operationContext, updateRestClientInfo, tagUpdateMethod.InputMethod, false, tagUpdateMethod.Kind, isFakeLro);

                        methods.AddRange([
                            new AddTagMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                            new AddTagMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, false),
                            new SetTagsMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                            new SetTagsMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, false),
                            new RemoveTagMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                            new RemoveTagMethodProvider(this, _operationContext, tagUpdateMethodProvider, inputReadMethod, updateRestClientInfo, getRestClientInfo, isPatch, false)
                        ]);
                    }
                }
            }

            // add method to get the child resource collection from the current resource.
            methods.AddRange(BuildGetChildResourceMethods());

            return [.. methods];
        }

        private MethodProvider BuildResourceOperationMethod(InputServiceMethod method, RestClientInfo restClientInfo, bool isAsync, string? methodName, bool isFakeLro)
        {
            // Check if the response body type is a list - if so, wrap it in a single-page pageable
            var responseBodyType = method.GetResponseBodyType();
            if (responseBodyType != null && responseBodyType.IsList)
            {
                return new ArrayResponseOperationMethodProvider(this, _operationContext, restClientInfo, method, isAsync, methodName);
            }

            return new ResourceOperationMethodProvider(this, _operationContext, restClientInfo, method, isAsync, methodName, forceLro: isFakeLro);
        }

        private (bool IsPatch, ResourceMethod? UpdateMethod) PopulateUpdateMethod()
        {
            // First try to find a patch method that has a body parameter whose model defines a tags property
            // and returns content. A bodyless PATCH, one whose body model lacks tags, or one that returns
            // no content cannot be used for tag operations — skip it.
            var patchMethod = _resourceMetadata.Methods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Update);
            var patchBodyParameter = patchMethod?.InputMethod.Operation.Parameters.OfType<InputBodyParameter>().FirstOrDefault();
            if (patchMethod is not null && patchBodyParameter is not null)
            {
                if (ModelHasTags(patchBodyParameter.Type as InputModelType) && OperationReturnsContent(patchMethod.InputMethod))
                {
                    return (true, patchMethod);
                }

                // PATCH has a body but either the body model does not define tags or the operation
                // returns no content — do not fall back to PUT, as the resource intentionally omits
                // tags from its update path.
                return (false, null);
            }

            // If there is no patch method with a body, fall back to the put method.
            // Search _resourceServiceMethods (the categorized set) instead of _resourceMetadata.Methods
            // because for non-singleton resources with an Update method, the Create method is only
            // assigned to the collection, not the resource.
            var putMethod = _resourceServiceMethods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Create);
            return (false, putMethod);
        }

        private static bool OperationReturnsContent(InputServiceMethod method)
        {
            if (method is InputLongRunningServiceMethod lroMethod)
            {
                return lroMethod.LongRunningServiceMetadata.ReturnType is not null;
            }

            var response = method.Operation.Responses.FirstOrDefault(r => !r.IsErrorResponse);
            return response?.BodyType is not null;
        }

        private List<MethodProvider> BuildGetChildResourceMethods()
        {
            var methods = new List<MethodProvider>();

            foreach (var childResource in ChildResources)
            {
                var thisResource = This.As<ArmResource>();
                if (childResource.IsSingleton)
                {
                    var signature = childResource.FactoryMethodSignature;
                    var lastSegment = childResource.ResourceTypeValue.Split('/')[^1];
                    var bodyStatement = Return(New.Instance(childResource.Type, thisResource.Client(), thisResource.Id().AppendChildResource(Literal(lastSegment), Literal(childResource.SingletonResourceName!))));
                    methods.Add(new MethodProvider(signature, bodyStatement, this));
                }
                else
                {
                    Debug.Assert(childResource.ResourceCollection is not null, "Child resource collection should not be null for non-singleton resources.");
                    var signature = childResource.FactoryMethodSignature;
                    MethodBodyStatement bodyStatement;
                    if (signature.Parameters.Count > 0)
                    {
                        // When the collection getter has path parameters (e.g. nestedTypeName),
                        // we must NOT use GetCachedClient because its cache key is only typeof(T),
                        // which means different parameter values would return the same stale instance.
                        bodyStatement = Return(New.Instance(childResource.ResourceCollection.Type,
                            [thisResource.Client(), thisResource.Id(), .. signature.Parameters]));
                    }
                    else
                    {
                        bodyStatement = Return(thisResource.GetCachedClient(new CodeWriterDeclaration("client"),
                            client => New.Instance(childResource.ResourceCollection.Type, client, thisResource.Id())));
                    }
                    methods.Add(new MethodProvider(signature, bodyStatement, this));
                    // Add Get methods backed by collection's Get and GetAsync methods
                    if (childResource.ResourceCollection.GetSyncMethodProvider is not null && childResource.ResourceCollection.GetAsyncMethodProvider is not null)
                    {
                        // Create both async and sync Get methods
                        var methodProviders = new[]
                        {
                            (childResource.ResourceCollection.GetAsyncMethodProvider, true, "Async"),
                            (childResource.ResourceCollection.GetSyncMethodProvider, false, "")
                        };

                        foreach (var (collectionMethodProvider, isAsync, suffix) in methodProviders)
                        {
                            var collectionSignature = collectionMethodProvider.Signature;
                            var getMethodName = $"Get{childResource.ResourceName}{suffix}";

                            var getSignature = new MethodSignature(
                                getMethodName,
                                collectionSignature.Description,
                                collectionSignature.Modifiers,
                                collectionSignature.ReturnType,
                                collectionSignature.ReturnDescription,
                                [.. signature.Parameters, .. collectionSignature.Parameters],
                                [new AttributeStatement(typeof(ForwardsClientCallsAttribute))],
                                collectionSignature.GenericArguments);

                            var getBodyStatement = Return(
                                thisResource.Invoke(signature.Name, signature.Parameters.Select(p => p.AsArgument()).ToArray())
                                    .Invoke(collectionSignature.Name, collectionSignature.Parameters.Select(p => p.AsArgument()).ToArray(), null, isAsync));

                            methods.Add(new MethodProvider(getSignature, getBodyStatement, this));
                        }
                    }
                }
            }

            return methods;
        }

        private bool HasTags()
        {
            return ModelHasTags(_inputModel);
        }

        private static bool ModelHasTags(InputModelType? model)
        {
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
    }
}
