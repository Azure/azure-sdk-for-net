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
    internal sealed class ResourceClientProvider : TypeProvider
    {
        internal static ResourceClientProvider Create(InputModelType model, ResourceMetadata resourceMetadata)
        {
            // TODO: handle multiple clients in the future, for now we assume that there is only one client for the resource.
            var inputClient = resourceMetadata.Methods.Select(m => ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!)!).Distinct().First();
            var resource = new ResourceClientProvider(resourceMetadata.ResourceName, model, inputClient, resourceMetadata);
            if (!resource.IsSingleton)
            {
                var collection = new ResourceCollectionClientProvider(resource, model, inputClient, resourceMetadata);
                resource.ResourceCollection = collection;
            }

            return resource;
        }

        private IEnumerable<(ResourceOperationKind, InputServiceMethod)> _resourceServiceMethods;

        private readonly FieldProvider _dataField;
        private readonly FieldProvider _resourceTypeField;
        private readonly InputModelType _inputModel;

        private readonly ResourceMetadata _resourceMetadata;

        private readonly ClientProvider _restClientProvider;
        private readonly FieldProvider _clientDiagnosticsField;
        private readonly FieldProvider _restClientField;

        private ResourceClientProvider(string resourceName, InputModelType model, InputClient inputClient, ResourceMetadata resourceMetadata)
        {
            _resourceMetadata = resourceMetadata;
            ContextualPath = new RequestPathPattern(resourceMetadata.ResourceIdPattern);
            _inputModel = model;

            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));

            ResourceName = resourceName;

            // We should be able to assume that all operations in the resource client are for the same resource
            _resourceServiceMethods = resourceMetadata.Methods.Select(m => (m.Kind, ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!));
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            _restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), ResourceHelpers.GetClientDiagnosticFieldName(ResourceName), this);
            _restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _restClientProvider.Type, ResourceHelpers.GetRestClientFieldName(_restClientProvider.Name), this);
        }

        public RequestPathPattern ContextualPath { get; }

        internal ResourceScope ResourceScope => _resourceMetadata.ResourceScope;
        internal string? ParentResourceIdPattern => _resourceMetadata.ParentResourceId;

        internal ResourceCollectionClientProvider? ResourceCollection { get; private set; }

        protected override string BuildName() => $"{ResourceName}Resource";

        private OperationSourceProvider? _source;
        internal OperationSourceProvider Source => _source ??= new OperationSourceProvider(this);

        internal ModelProvider ResourceData { get; }
        internal string ResourceName { get; }
        internal IEnumerable<(ResourceOperationKind Kind, InputServiceMethod Method)> ResourceServiceMethods => _resourceServiceMethods;

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

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeField.As<ResourceType>().Namespace(), thisResource.Diagnostics())).Terminate(),
                thisResource.TryGetApiVersion(_resourceTypeField, $"{ResourceName}ApiVersion".ToVariableName(), out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_restClientProvider.Type, _clientDiagnosticsField, thisResource.Pipeline(), thisResource.Endpoint(), apiVersion)).Terminate(),
                Static(Type).As<ArmResource>().ValidateResourceId(idParameter).Terminate()
            };

            return new ConstructorProvider(signature, bodyStatements, this);
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
                $"Cannot find parameter {parameterName} in any registered operations in resource {ResourceName}."
                );

            return typeof(string); // Default to string if not found
        }

        private MethodProvider BuildCreateResourceIdentifierMethod()
        {
            var parameters = new List<ParameterProvider>();
            var formatBuilder = new StringBuilder();
            var refCount = 0;

            foreach (var segment in ContextualPath)
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
                    updateMethodProvider = new UpdateOperationMethodProvider(this, _restClientProvider, method, convenienceMethod, _clientDiagnosticsField, _restClientField, false);
                    operationMethods.Add(updateMethodProvider);

                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, _restClientProvider, method, asyncConvenienceMethod, _clientDiagnosticsField, _restClientField, true);
                    operationMethods.Add(updateAsyncMethodProvider);
                }
                else
                {
                    operationMethods.Add(new ResourceOperationMethodProvider(this, ContextualPath, _restClientProvider, method, convenienceMethod, _clientDiagnosticsField, _restClientField, false));
                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, ContextualPath, _restClientProvider, method, asyncConvenienceMethod, _clientDiagnosticsField, _restClientField, true));
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
                methods.AddRange([
                    new AddTagMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, true),
                    new AddTagMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, false),
                    new SetTagsMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, true),
                    new SetTagsMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, false),
                    new RemoveTagMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, true),
                    new RemoveTagMethodProvider(this, updateMethodProvider, _restClientProvider, _clientDiagnosticsField, _restClientField, false)
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
