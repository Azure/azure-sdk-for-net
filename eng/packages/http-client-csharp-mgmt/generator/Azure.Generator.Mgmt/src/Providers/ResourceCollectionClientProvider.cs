// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceCollectionClientProvider : ResourceClientProvider
    {
        private ResourceClientProvider _resource;
        private InputServiceMethod? _getAll;
        private InputServiceMethod? _create;
        private InputServiceMethod? _get;

        public ResourceCollectionClientProvider(InputClient inputClient, ResourceClientProvider resource) : base(inputClient)
        {
            _resource = resource;

            foreach (var method in inputClient.Methods)
            {
                var operation = method.Operation;
                if (operation.HttpMethod == HttpMethod.Get.ToString())
                {
                    if (operation.Name == "list")
                    {
                        _getAll = method;
                    }
                    else if (operation.Name == "get")
                    {
                        _get = method;
                    }
                }
                if (operation.HttpMethod == HttpMethod.Put.ToString() && operation.Name == "createOrUpdate")
                {
                    _create = method;
                }
            }
        }

        protected override string BuildName() => $"{SpecName}Collection";

        protected override CSharpType[] BuildImplements() =>
            _getAll is null
            ? [typeof(ArmCollection)]
            : [typeof(ArmCollection), new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields() => [_clientDiagonosticsField, _restClientField];

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildResourceIdentifierConstructor()];

        protected override ValueExpression ExpectedResourceTypeForValidation => Static(typeof(ResourceGroupResource)).Property("ResourceType");

        protected override ValueExpression ResourceTypeExpression => Static(_resource.Type).Property("ResourceType");

        protected override CSharpType ResourceClientCharpType => _resource.Type;

        protected override MethodProvider[] BuildMethods() => [BuildValidateResourceIdMethod(), .. BuildCreateOrUpdateMethods(), .. BuildGetMethods(), .. BuildGetAllMethods(), .. BuildExistsMethods(), .. BuildGetIfExistsMethods(), .. BuildEnumeratorMethods()];

        private MethodProvider[] BuildGetAllMethods()
        {
            if (_getAll is null)
            {
                return [];
            }

            // implement paging method GetAll
            var getAll = BuildGetAllMethod(false);
            var getAllAsync = BuildGetAllMethod(true);

            return [getAllAsync, getAll];
        }

        private MethodProvider[] BuildEnumeratorMethods()
        {
            if (_getAll is null)
            {
                return [];
            }

            const string getEnumeratormethodName = "GetEnumerator";
            var body = Return(This.Invoke("GetAll").Invoke("GetEnumerator"));
            var getEnumeratorMethod = new MethodProvider(
                new MethodSignature(getEnumeratormethodName, null, MethodSignatureModifiers.None, typeof(IEnumerator), null, [], ExplicitInterface: typeof(IEnumerable)),
                body,
                this);
            var getEnumeratorOfTMethod = new MethodProvider(
                new MethodSignature(getEnumeratormethodName, null, MethodSignatureModifiers.None, new CSharpType(typeof(IEnumerator<>), _resource.Type), null, [], ExplicitInterface: new CSharpType(typeof(IEnumerable<>), _resource.Type)),
                body,
                this);
            var getEnumeratorAsyncMethod = new MethodProvider(
                new MethodSignature("GetAsyncEnumerator", null, MethodSignatureModifiers.None, new CSharpType(typeof(IAsyncEnumerator<>), _resource.Type), null, [KnownAzureParameters.CancellationTokenWithoutDefault], ExplicitInterface: new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)),
                Return(This.Invoke("GetAllAsync", [KnownAzureParameters.CancellationTokenWithoutDefault]).Invoke("GetAsyncEnumerator", [KnownAzureParameters.CancellationTokenWithoutDefault])),
                this);
            return [getEnumeratorOfTMethod, getEnumeratorMethod, getEnumeratorAsyncMethod];
        }

        private List<MethodProvider> BuildCreateOrUpdateMethods()
        {
            var result = new List<MethodProvider>();
            if (_create is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false})
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(_create!.Operation, isAsync);
                result.Add(BuildOperationMethod(_create, convenienceMethod, isAsync));
            }

            return result;
        }
        private MethodProvider BuildGetAllMethod(bool isAsync)
        {
            var convenienceMethod = GetCorrespondingConvenienceMethod(_getAll!.Operation, isAsync);
            var isLongRunning = _getAll is InputLongRunningPagingServiceMethod;
            var signature = new MethodSignature(
                isAsync ? "GetAllAsync" : "GetAll",
                convenienceMethod.Signature.Description,
                convenienceMethod.Signature.Modifiers,
                isAsync ? new CSharpType(typeof(AsyncPageable<>), _resource.Type) : new CSharpType(typeof(Pageable<>), _resource.Type),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, isLongRunning),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);

            // TODO: implement paging method properly
            return new MethodProvider(signature, ThrowExpression(New.Instance(typeof(NotImplementedException))), this);
        }

        private List<MethodProvider> BuildGetMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false})
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(_get!.Operation, isAsync);
                result.Add(BuildOperationMethod(_get, convenienceMethod, isAsync));
            }

            return result;
        }

        private List<MethodProvider> BuildExistsMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false})
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(_get!.Operation, isAsync);
                var signature = new MethodSignature(
                isAsync ? "ExistsAsync" : "Exists",
                $"Checks to see if the resource exists in azure.",
                convenienceMethod.Signature.Modifiers,
                isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(Response<>), typeof(bool))) : new CSharpType(typeof(Response<>), typeof(bool)),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, false),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);
                result.Add(BuildOperationMethodCore(_get, convenienceMethod, signature, isAsync, IsReturnTypeGeneric(_get)));
            }

            return result;
        }

        private List<MethodProvider> BuildGetIfExistsMethods()
        {
            var result = new List<MethodProvider>();
            if (_get is null)
            {
                return result;
            }

            foreach (var isAsync in new List<bool> { true, false})
            {
                var convenienceMethod = GetCorrespondingConvenienceMethod(_get!.Operation, isAsync);
                var signature = new MethodSignature(
                isAsync ? "GetIfExistsAsync" : "GetIfExists",
                $"Tries to get details for this resource from the service.",
                convenienceMethod.Signature.Modifiers,
                isAsync ? new CSharpType(typeof(Task<>), new CSharpType(typeof(NullableResponse<>), ResourceClientCharpType)) : new CSharpType(typeof(NullableResponse<>), ResourceClientCharpType),
                convenienceMethod.Signature.ReturnDescription,
                GetOperationMethodParameters(convenienceMethod, false),
                convenienceMethod.Signature.Attributes,
                convenienceMethod.Signature.GenericArguments,
                convenienceMethod.Signature.GenericParameterConstraints,
                convenienceMethod.Signature.ExplicitInterface,
                convenienceMethod.Signature.NonDocumentComment);
                result.Add(BuildOperationMethodCore(_get, convenienceMethod, signature, isAsync, IsReturnTypeGeneric(_get)));
            }

            return result;
        }

        protected override bool SkipMethodParameter(ParameterProvider parameter)
        {
            if (ContextualParameters == null)
            {
                return false;
            }
            return ContextualParameters.Take(ContextualParameters.Count - 1).Any(p => p == parameter.Name);
        }

        protected override MethodBodyStatement BuildReturnStatements(ValueExpression responseVariable, MethodSignature signature)
        {
            if (signature.Name == "GetIfExists" || signature.Name == "GetIfExistsAsync")
            {
                return BuildReturnStatementsForGetIfExists(responseVariable, signature);
            }
            if (signature.Name == "Exists" || signature.Name == "ExistsAsync")
            {
                return BuildReturnStatementsForExists(responseVariable);
            }

            return base.BuildReturnStatements(responseVariable, signature);
        }

        // TODO: make the commented implementation work - find a way to access the NoValueResponse<T> type
        private MethodBodyStatement BuildReturnStatementsForGetIfExists(ValueExpression responseVariable, MethodSignature signature)
        {
            // List<MethodBodyStatement> statements =
            // [
            //     new IfStatement(responseVariable.Property("Value").Equal(Null))
            //             {
            //                 Return(New.Instance(new CSharpType(typeof(NoValueResponse<>), _resource.Type), responseVariable.Invoke("GetRawResponse")))
            //             }
            // ];
            // var returnValueExpression =  New.Instance(ResourceClientCharpType, This.Property("Client"), responseVariable.Property("Value"));
            // statements.Add(Return(Static(typeof(Response)).Invoke(nameof(Response.FromValue), returnValueExpression, responseVariable.Invoke("GetRawResponse"))));

            // return statements;
            return base.BuildReturnStatements(responseVariable, signature);
        }

        private MethodBodyStatement BuildReturnStatementsForExists(ValueExpression responseVariable)
        {
            var returnValueExpression = responseVariable.Property("Value").NotEqual(Null);
            return Return(Static(typeof(Response)).Invoke(nameof(Response.FromValue), returnValueExpression, responseVariable.Invoke("GetRawResponse")));
        }
    }
}
