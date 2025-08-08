﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        internal static ResourceClientProvider Create(ResourceMetadata resourceMetadata)
        {
            // Create a resource that supports multiple clients, using ResourceName from metadata
            var resource = new ResourceClientProvider(resourceMetadata.ResourceName, resourceMetadata.ResourceModel, resourceMetadata);
            if (!resource.IsSingleton)
            {
                var collection = new ResourceCollectionClientProvider(resource, resourceMetadata.ResourceModel, resourceMetadata);
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

        private ResourceClientProvider(string resourceName, InputModelType model, ResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            _contextualPath = new RequestPathPattern(resourceMetadata.ResourceIdPattern);
            _inputModel = model;

            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));

            ResourceName = resourceName;

            _resourceServiceMethods = resourceMetadata.Methods;
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            // Initialize client info dictionary using extension method
            _clientInfos = resourceMetadata.CreateClientInfosMap(this);

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
        }

        internal ResourceScope ResourceScope => _resourceMetadata.ResourceScope;
        internal string? ParentResourceIdPattern => _resourceMetadata.ParentResourceId;

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        protected override string BuildName() => ResourceName.EndsWith("Resource") ? ResourceName : $"{ResourceName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

        internal ModelProvider ResourceData { get; }
        internal string ResourceName { get; }
        // TODO -- we should not need to expose this.
        // Instead, if some method needs more method, we should prepare them and pass it in as an argument
        internal IEnumerable<ResourceMethod> ResourceServiceMethods => _resourceServiceMethods;

        internal string? SingletonResourceName => _resourceMetadata.SingletonResourceName;

        public bool IsSingleton => SingletonResourceName is not null;

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", $"{Name}.cs");

        private IReadOnlyList<ResourceClientProvider>? _childResources;
        public IReadOnlyList<ResourceClientProvider> ChildResources => _childResources ??= BuildChildResources();

        private IReadOnlyList<ResourceClientProvider> BuildChildResources()
        {
            // first we find all the resources from the output library
            var allResources = ManagementClientGenerator.Instance.OutputLibrary.TypeProviders
                .OfType<ResourceClientProvider>();

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
        private CSharpType GetPathParameterType(string parameterName)
        {
            foreach (var (kind, method, _) in _resourceServiceMethods)
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
                Declare("resourceId", typeof(string), new FormattableStringExpression(formatBuilder.ToString(), parameters.Select(p => p.AsExpression()).ToArray()), out var resourceIdVar),
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

            foreach (var (methodKind, method, inputClient) in _resourceServiceMethods)
            {
                // exclude the List operations for resource and Create operations for non-singleton resources (they will be in ResourceCollection)
                if (methodKind == ResourceOperationKind.List || (!IsSingleton && methodKind == ResourceOperationKind.Create))
                {
                    continue;
                }

                var isFakeLro = ResourceHelpers.ShouldMakeLro(methodKind);

                // Get the appropriate rest client for this specific method
                var restClientInfo = _clientInfos[inputClient];

                var convenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(method.Operation, false);
                var asyncConvenienceMethod = restClientInfo.RestClientProvider.GetConvenienceMethodByOperation(method.Operation, true);

                if (method is InputPagingServiceMethod pagingMethod)
                {
                    // Use PageableOperationMethodProvider for InputPagingServiceMethod
                    operationMethods.Add(new PageableOperationMethodProvider(this, _contextualPath, restClientInfo, pagingMethod, false, methodName: ResourceHelpers.GetOperationMethodName(methodKind, false)));
                    operationMethods.Add(new PageableOperationMethodProvider(this, _contextualPath, restClientInfo, pagingMethod, true, methodName: ResourceHelpers.GetOperationMethodName(methodKind, true)));

                    continue;
                }

                // Check if this is an update operation (PUT or Patch method for non-singleton resource)
                var isUpdateOperation = (methodKind == ResourceOperationKind.Create || methodKind == ResourceOperationKind.Update) && !IsSingleton;

                if (isUpdateOperation)
                {
                    updateMethodProvider = new UpdateOperationMethodProvider(this, _contextualPath, restClientInfo, method, false);
                    operationMethods.Add(updateMethodProvider);

                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, _contextualPath, restClientInfo, method, true);
                    operationMethods.Add(updateAsyncMethodProvider);
                }
                else
                {
                    var methodName = ResourceHelpers.GetOperationMethodName(methodKind, false);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, method, false, methodName, forceLro: isFakeLro));
                    var asyncMethodName = ResourceHelpers.GetOperationMethodName(methodKind, true);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, _contextualPath, restClientInfo, method, true, asyncMethodName, forceLro: isFakeLro));
                }
            }

            var methods = new List<MethodProvider>
            {
                BuildCreateResourceIdentifierMethod(),
                ResourceMethodSnippets.BuildValidateResourceIdMethod(this, _resourceTypeField)
            };
            methods.AddRange(operationMethods);

            // Only generate tag methods if the resource model has tag properties, has get and update methods
            if (HasTags() && _resourceMetadata.Methods.Any(m => m.Kind == ResourceOperationKind.Get) && updateMethodProvider is not null)
            {
                // Find the update method to get its rest client
                var updateMethod = _resourceMetadata.Methods.FirstOrDefault(m => m.Kind == ResourceOperationKind.Update || m.Kind == ResourceOperationKind.Create);
                if (updateMethod is not null)
                {
                    var updateRestClientInfo = _clientInfos[updateMethod.InputClient];

                    methods.AddRange([
                        new AddTagMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, true),
                        new AddTagMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, false),
                        new SetTagsMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, true),
                        new SetTagsMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, false),
                        new RemoveTagMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, true),
                        new RemoveTagMethodProvider(this, _contextualPath, updateMethodProvider, updateRestClientInfo, false)
                    ]);
                }
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
                    $"Get{childResource.ResourceName}",
                    $"Gets an object representing a {childResource.ResourceName} along with the instance operations that can be performed on it in the {ResourceName}.",
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
                var pluralChildResourceName = childResource.ResourceName.Pluralize();
                var signature = new MethodSignature(
                    $"Get{pluralChildResourceName}",
                    $"Gets a collection of {pluralChildResourceName} in the {ResourceName}.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual,
                    childResource.ResourceCollection.Type,
                    $"An object representing collection of {pluralChildResourceName} and their operations over a {ResourceName}.",
                    []);
                var bodyStatement = Return(thisResource.GetCachedClient(new CodeWriterDeclaration("client"), client => New.Instance(childResource.ResourceCollection.Type, client, thisResource.Id())));
                return new MethodProvider(signature, bodyStatement, this);
            }
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
