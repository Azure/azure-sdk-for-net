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
        internal static ResourceClientProvider Create(ResourceMetadata resourceMetadata, IReadOnlyList<ResourceMethod> methodsInResource, IReadOnlyList<ResourceMethod> methodsInCollection)
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

        private readonly ResourceMetadata _resourceMetadata;

        private readonly RequestPathPattern _contextualPath;

        // Support for multiple rest clients
        private readonly Dictionary<InputClient, RestClientInfo> _clientInfos;

        private ResourceClientProvider(string resourceName, InputModelType model, IReadOnlyList<ResourceMethod> resourceMethods, ResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _contextualPath = new RequestPathPattern(resourceMetadata.ResourceIdPattern);
            _inputModel = model;

            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));

            ResourceName = resourceName;

            _resourceServiceMethods = resourceMethods;
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
        }

        internal ResourceScope ResourceScope => _resourceMetadata.ResourceScope;
        internal string? ParentResourceIdPattern => _resourceMetadata.ParentResourceId;

        internal bool IsExtensionResource => ResourceScope == ResourceScope.Extension;

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        public RequestPathPattern ContextualPath => _contextualPath;

        protected override string BuildName() => ResourceName.EndsWith("Resource") ? ResourceName : $"{ResourceName}Resource";

        protected override FormattableString BuildDescription() => $"A class representing a {ResourceName} along with the instance operations that can be performed on it.\nIf you have a {typeof(ResourceIdentifier):C} you can construct a {Type:C} from an instance of {typeof(ArmClient):C} using the GetResource method.\nOtherwise you can get one from its parent resource {TypeOfParentResource:C} using the {FactoryMethodSignature.Name} method.";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

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
            if (_resourceMetadata.ResourceScope == ResourceScope.Extension)
            {
                return typeof(Azure.ResourceManager.ArmResource);
            }

            // if the resource has a parent resource id, we can find it in the output library
            if (_resourceMetadata.ParentResourceId is not null)
            {
                return ManagementClientGenerator.Instance.OutputLibrary.GetResourceById(_resourceMetadata.ParentResourceId).Type;
            }
            // if it does not, this resource's parent must be one of the MockableResource
            return ManagementClientGenerator.Instance.OutputLibrary.GetMockableResourceByScope(_resourceMetadata.ResourceScope).ArmCoreType;
        }

        private MethodSignature? _factoryMethodSignature;
        internal MethodSignature FactoryMethodSignature => _factoryMethodSignature ??= BuildFactoryMethodSignature();

        private MethodSignature BuildFactoryMethodSignature()
        {
            if (ResourceCollection != null)
            {
                // we have the collection, we are not a singleton resource
                var pluralOfResourceName = ResourceName.Pluralize();
                var methodName = BuildFactoryMethodName();
                return new MethodSignature(
                    methodName,
                    $"Gets a collection of {pluralOfResourceName} in the {TypeOfParentResource:C}",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    ResourceCollection.Type,
                    $"An object representing collection of {pluralOfResourceName} and their operations over a {Name}.",
                    []
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

        // TODO: Temporary workaround for recent breaking changes in converting Playwright service.
        // This special-casing will be replaced by a generalized naming strategy in a follow-up PR.
        private string BuildFactoryMethodName()
        {
            var ResourceNamesHavingIrregularPlural = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "PlaywrightQuota", "PlaywrightWorkspaceQuota" };

            if (ResourceNamesHavingIrregularPlural.Contains(ResourceName))
            {
                return $"GetAll{ResourceName}";
            }
            else
            {
                return $"Get{ResourceName.Pluralize()}";
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
                var effectiveApiVersion = apiVersion.NullCoalesce(Literal(ManagementClientGenerator.Instance.InputLibrary.DefaultApiVersion));
                bodyStatements.Add(clientInfo.RestClientField.Assign(New.Instance(clientInfo.RestClientProvider.Type, clientInfo.DiagnosticsField, thisResource.Pipeline(), thisResource.Endpoint(), effectiveApiVersion)).Terminate());
            }

            bodyStatements.Add(Static(Type).As<ArmResource>().ValidateResourceId(idParameter).Terminate());

            return new ConstructorProvider(signature, bodyStatements.ToArray(), this);
        }

        // TODO -- this is temporary. We should change this to find the corresponding parameters in ContextualParameters after it is refactored to consume parent resources.
        public CSharpType GetPathParameterType(string parameterName)
        {
            foreach (var resourceMethod in _resourceServiceMethods)
            {
                if (!resourceMethod.Kind.IsCrudKind())
                {
                    continue; // Skip non-CRUD operations
                }
                // iterate through all parameters in this method to find a matching parameter
                foreach (var parameter in resourceMethod.InputMethod.Operation.Parameters)
                {
                    if (parameter is not InputPathParameter)
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
                $"Cannot find parameter {parameterName} in any registered operations in resource {ResourceName}."
                );

            return typeof(string); // Default to string if not found
        }

        private MethodProvider BuildCreateResourceIdentifierMethod()
        {
            var parameters = new List<ParameterProvider>();
            var formatBuilder = new StringBuilder();
            var refCount = 0;

            foreach (var segment in _contextualPath)
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
                    operationMethods.Add(new PageableOperationMethodProvider(this, _contextualPath, restClientInfo, pagingMethod, true, methodName: resourceMethod.ResourceScope == _contextualPath ? null : ResourceHelpers.GetOperationMethodName(methodKind, true)));
                    operationMethods.Add(new PageableOperationMethodProvider(this, _contextualPath, restClientInfo, pagingMethod, false, methodName: resourceMethod.ResourceScope == _contextualPath ? null : ResourceHelpers.GetOperationMethodName(methodKind, false)));

                    continue;
                }

                // Check if this is an update operation (PUT or Patch method for non-singleton resource)
                var isUpdateOperation = (methodKind == ResourceOperationKind.Create || methodKind == ResourceOperationKind.Update) && !IsSingleton;

                if (isUpdateOperation)
                {
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, _contextualPath, restClientInfo, method, true, methodKind);
                    operationMethods.Add(updateAsyncMethodProvider);

                    updateMethodProvider = new UpdateOperationMethodProvider(this, _contextualPath, restClientInfo, method, false, methodKind);
                    operationMethods.Add(updateMethodProvider);
                }
                else
                {
                    var asyncMethodName = ResourceHelpers.GetOperationMethodName(methodKind, true);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, method, true, asyncMethodName, forceLro: isFakeLro));
                    // If the method's resource scope matches the contextual path, we use the original method name
                    var methodName = ResourceHelpers.GetOperationMethodName(methodKind, false);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, method, false, methodName, forceLro: isFakeLro));
                }
            }

            var methods = new List<MethodProvider>
            {
                BuildCreateResourceIdentifierMethod(),
                ResourceMethodSnippets.BuildValidateResourceIdMethod(this, _resourceTypeField)
            };
            methods.AddRange(operationMethods);
            var getMethod = _resourceServiceMethods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Get)?.InputMethod;

            // Only generate tag methods if the resource model has tag properties, has get and update methods
            if (HasTags() && getMethod is not null && updateMethodProvider is not null)
            {
                (bool isPatch, InputClient? updateClient) = PopulateUpdateClient();
                var getClient = PopulateGetClient();
                if (updateClient is not null && getClient is not null)
                {
                    var updateRestClientInfo = _clientInfos[updateClient];
                    var getRestClientInfo = _clientInfos[getClient];

                    methods.AddRange([
                        new AddTagMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                        new AddTagMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, false),
                        new SetTagsMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                        new SetTagsMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, false),
                        new RemoveTagMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, true),
                        new RemoveTagMethodProvider(this, _contextualPath, updateMethodProvider, getMethod, updateRestClientInfo, getRestClientInfo, isPatch, false)
                    ]);
                }
            }

            // add method to get the child resource collection from the current resource.
            methods.AddRange(BuildGetChildResourceMethods());

            return [.. methods];
        }

        private InputClient? PopulateGetClient()
            => _resourceMetadata.Methods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Get)?.InputClient;

        private (bool IsPatch, InputClient? UpdateClient) PopulateUpdateClient()
        {
            // first try to find a patch method
            var patchClient = _resourceMetadata.Methods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Update)?.InputClient;
            if (patchClient is not null)
            {
                return (true, patchClient);
            }

            // if there is no tags patch method, fall back to the put method
            var putClient = _resourceMetadata.Methods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Create)?.InputClient;
            return (false, putClient);
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
                    var bodyStatement = Return(thisResource.GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(childResource.ResourceCollection.Type, client, thisResource.Id())));
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
                                collectionSignature.Parameters,
                                [new AttributeStatement(typeof(ForwardsClientCallsAttribute))],
                                collectionSignature.GenericArguments);

                            var getBodyStatement = Return(
                                thisResource.Invoke(signature.Name)
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
            InputModelType? currentModel = _inputModel;
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
