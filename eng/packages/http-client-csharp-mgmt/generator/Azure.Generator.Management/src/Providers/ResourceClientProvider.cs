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
    internal class ResourceClientProvider : ContextualClientProvider
    {
        internal static ResourceClientProvider Create(InputModelType model, ResourceMetadata resourceMetadata)
        {
            // TODO: handle multiple clients in the future, for now we assume that there is only one client for the resource.
            var inputClient = resourceMetadata.Methods.Select(m => ManagementClientGenerator.Instance.InputLibrary.GetClientByMethod(ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!)!).Distinct().First();
            // TODO -- the name of a resource is not always the name of its model. Maybe the resource metadata should have a property for the name of the resource?
            var resource = new ResourceClientProvider(model.Name.ToIdentifierName(), model, inputClient, resourceMetadata);
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
        private readonly bool _hasGetMethod;
        private readonly bool _shouldGenerateTagMethods;

        private readonly ResourceMetadata _resourceMetadata;

        private protected readonly ClientProvider _restClientProvider;
        private protected readonly FieldProvider _clientDiagnosticsField;
        private protected readonly FieldProvider _restClientField;

        private ResourceClientProvider(string resourceName, InputModelType model, InputClient inputClient, ResourceMetadata resourceMetadata)
            : base(new RequestPathPattern(resourceMetadata.ResourceIdPattern))
        {
            _resourceMetadata = resourceMetadata;
            _hasGetMethod = resourceMetadata.Methods.Any(m => m.Kind == ResourceOperationKind.Get);
            _resourceTypeField = new FieldProvider(FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly, typeof(ResourceType), "ResourceType", this, description: $"Gets the resource type for the operations.", initializationValue: Literal(ResourceTypeValue));
            _shouldGenerateTagMethods = ShouldGenerateTagMethods(model);

            ResourceName = resourceName;

            // We should be able to assume that all operations in the resource client are for the same resource
            _resourceServiceMethods = resourceMetadata.Methods.Select(m => (m.Kind, ManagementClientGenerator.Instance.InputLibrary.GetMethodByCrossLanguageDefinitionId(m.Id)!));
            ResourceData = ManagementClientGenerator.Instance.TypeFactory.CreateModel(model)!;

            _restClientProvider = ManagementClientGenerator.Instance.TypeFactory.CreateClient(inputClient)!;

            _dataField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, ResourceData.Type, "_data", this);
            _clientDiagnosticsField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientDiagnostics), ResourceHelpers.GetClientDiagnosticFieldName(ResourceName), this);
            _restClientField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, _restClientProvider.Type, $"_{ResourceName.ToLower()}RestClient", this);
        }

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

        private protected virtual IReadOnlyList<ResourceClientProvider> BuildChildResources()
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

            var bodyStatements = new MethodBodyStatement[]
            {
                _clientDiagnosticsField.Assign(New.Instance(typeof(ClientDiagnostics), Literal(Type.Namespace), _resourceTypeField.As<ResourceType>().Namespace(), This.As<ArmResource>().Diagnostics())).Terminate(),
                ResourceHelpers.BuildTryGetApiVersionInvocation(ResourceName, _resourceTypeField, out var apiVersion).Terminate(),
                _restClientField.Assign(New.Instance(_restClientProvider.Type, _clientDiagnosticsField, This.As<ArmResource>().Pipeline(), This.As<ArmResource>().Endpoint(), apiVersion)).Terminate(),
                Static(Type).Invoke("ValidateResourceId", idParameter).Terminate()
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

            foreach (var segment in new RequestPathPattern(_resourceMetadata.ResourceIdPattern))
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

        //TODO -- these fields should be removed
        internal ScopedApi<ClientDiagnostics> GetClientDiagnosticsField() => _clientDiagnosticsField.As<ClientDiagnostics>();
        internal ValueExpression GetRestClientField() => _restClientField;
        internal ClientProvider GetClientProvider() => _restClientProvider;

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
                    var updateMethodProvider = new UpdateOperationMethodProvider(this, _restClientProvider, method, convenienceMethod, _clientDiagnosticsField, _restClientField, false);
                    operationMethods.Add(updateMethodProvider);

                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    var updateAsyncMethodProvider = new UpdateOperationMethodProvider(this, _restClientProvider, method, asyncConvenienceMethod, _clientDiagnosticsField, _restClientField, true);
                    operationMethods.Add(updateAsyncMethodProvider);
                }
                else
                {
                    operationMethods.Add(new ResourceOperationMethodProvider(this, this, _restClientProvider, method, convenienceMethod, _clientDiagnosticsField, _restClientField, false));
                    var asyncConvenienceMethod = _restClientProvider.GetConvenienceMethodByOperation(method.Operation, true);
                    operationMethods.Add(new ResourceOperationMethodProvider(this, this, _restClientProvider, method, asyncConvenienceMethod, _clientDiagnosticsField, _restClientField, true));
                }
            }

            var methods = new List<MethodProvider>
            {
                BuildCreateResourceIdentifierMethod(),
                BuildValidateResourceIdMethod(_resourceTypeField)
            };
            methods.AddRange(operationMethods);

            // Only generate tag methods if the resource model has tag properties
            if (_shouldGenerateTagMethods)
            {
                methods.AddRange([
                    new AddTagMethodProvider(this, _clientDiagnosticsField, _restClientField, true),
                    new AddTagMethodProvider(this, _clientDiagnosticsField, _restClientField, false),
                    new SetTagsMethodProvider(this, _clientDiagnosticsField, _restClientField, true),
                    new SetTagsMethodProvider(this, _clientDiagnosticsField, _restClientField, false),
                    new RemoveTagMethodProvider(this, _clientDiagnosticsField, _restClientField, true),
                    new RemoveTagMethodProvider(this, _clientDiagnosticsField, _restClientField, false)
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
    }
}
