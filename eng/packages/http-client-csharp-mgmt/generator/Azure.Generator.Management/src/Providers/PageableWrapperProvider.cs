// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// Provides a converter type that can convert from one type to another.
    /// </summary>
    internal sealed class PageableWrapperProvider : TypeProvider
    {
        private class Template<T, U> { }
        private readonly CSharpType _tType;
        private readonly CSharpType _uType;
        private readonly CSharpType _pageableT;
        private readonly CSharpType _pageableU;
        private readonly CSharpType _asyncPageableT;
        private readonly CSharpType _asyncPageableU;
        private readonly FieldProvider _sourceField;
        private readonly FieldProvider _converterField;
        private readonly bool _isAsync;

        public PageableWrapperProvider(bool isAsync)
        {
            _isAsync = isAsync;

            var templateGenericArgs = typeof(Template<,>).GetGenericArguments();
            _tType = templateGenericArgs[0];
            _uType = templateGenericArgs[1];

            // Create Pageable<T> and Pageable<U> types from Azure.Core
            _pageableT = new CSharpType(typeof(Pageable<>), _tType);
            _pageableU = new CSharpType(typeof(Pageable<>), _uType);

            // Create AsyncPageable<T> and AsyncPageable<U> types from Azure.Core
            _asyncPageableT = new CSharpType(typeof(AsyncPageable<>), _tType);
            _asyncPageableU = new CSharpType(typeof(AsyncPageable<>), _uType);

            // Create the fields
            _sourceField = new FieldProvider(
                FieldModifiers.Private,
                isAsync ? _asyncPageableT : _pageableT,
                "_source",
                this,
                description: isAsync
                    ? (FormattableString)$"The source async pageable value of type AsyncPageable<{_tType.Name}>."
                    : (FormattableString)$"The source pageable value of type Pageable<{_tType.Name}>.");

            _converterField = new FieldProvider(
                FieldModifiers.Private,
                new CSharpType(typeof(Func<,>), _tType, _uType),
                "_converter",
                this,
                description: $"The converter function from {_tType.Name} to {_uType.Name}.");
        }

        protected override string BuildName() => $"{(_isAsync ? "Async" : "")}PageableWrapper";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
        {
            return TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class;
        }

        protected override CSharpType? BuildBaseType()
        {
            return _isAsync ? _asyncPageableU : _pageableU;
        }

        protected override CSharpType[] GetTypeArguments() => [_tType, _uType];

        protected override FieldProvider[] BuildFields()
        {
            return [_sourceField, _converterField];
        }

        protected override MethodProvider[] BuildMethods()
        {
            return [BuildAsPagesMethod()];
        }

        private MethodProvider BuildAsPagesMethod()
        {
            // Create the return type based on async flag
            var pageUType = new CSharpType(typeof(Page<>), _uType);
            var returnType = _isAsync
                ? new CSharpType(typeof(IAsyncEnumerable<>), pageUType)
                : new CSharpType(typeof(IEnumerable<>), pageUType);

            // Create parameters for AsPages method
            var continuationTokenParam = new ParameterProvider(
                "continuationToken",
                $"A continuation token from a previous response.",
                new CSharpType(typeof(string)));

            var pageSizeHintParam = new ParameterProvider(
                "pageSizeHint",
                $"An optional hint to specify the desired size of each page.",
                new CSharpType(typeof(int?)));

            // Create the method signature with appropriate modifiers
            var modifiers = MethodSignatureModifiers.Public | MethodSignatureModifiers.Override;
            if (_isAsync)
            {
                modifiers |= MethodSignatureModifiers.Async;
            }

            var sourceTypeName = _isAsync ? _asyncPageableT.Name : _pageableT.Name;
            var signature = new MethodSignature(
                Name: "AsPages",
                Description: $"Converts the pages from {sourceTypeName} to {pageUType.Name}.",
                Modifiers: modifiers,
                ReturnType: returnType,
                ReturnDescription: $"An enumerable of pages containing converted items of type {_uType.Name}.",
                Parameters: new[] { continuationTokenParam, pageSizeHintParam });

            // Build the method body using foreach and yield return pattern
            var pageType = new CSharpType(typeof(Page<>), _tType);
            var asPagesInvocation = _sourceField.Invoke("AsPages", [continuationTokenParam, pageSizeHintParam]);
            var pages = _isAsync
                // we can't write ConfigureAwait for a non-async invoke, this is a workaround
                ? asPagesInvocation.Invoke(nameof(TaskAsyncEnumerableExtensions.ConfigureAwait), [False], null, false, false, extensionType: typeof(TaskAsyncEnumerableExtensions))
                : asPagesInvocation;
            var foreachStatement = new ForEachStatement(
                pageType,
                "page",
                pages,
                isAsync: _isAsync,
                out var pageVar);

            // Create a list to collect converted values instead of using LINQ Select
            var listType = new CSharpType(typeof(List<>), _uType);
            var listDeclaration = Declare("convertedItems", listType, New.Instance(listType), out var listVar);

            // Create inner foreach to convert each item
            var innerForeachStatement = new ForEachStatement(
                _tType,
                "item",
                pageVar.Property("Values"),
                isAsync: false,
                out var itemVar);

            innerForeachStatement.Add(listVar.Invoke("Add", [_converterField.Invoke("Invoke", [itemVar])]).Terminate());

            foreachStatement.Add(listDeclaration);
            foreachStatement.Add(innerForeachStatement);
            foreachStatement.Add(
                new YieldReturnStatement(
                    Static(pageUType).Invoke(
                        "FromValues",
                        [
                            listVar,
                            pageVar.Property("ContinuationToken"),
                            pageVar.Invoke("GetRawResponse", [])
                        ])));

            return new MethodProvider(signature, foreachStatement, this);
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var sourceParameterType = _isAsync ? _asyncPageableT : _pageableT;
            var sourceParameterDescription = _isAsync
                ? (FormattableString)$"The source async pageable value of type AsyncPageable<{_tType.Name}>."
                : (FormattableString)$"The source pageable value of type Pageable<{_tType.Name}>.";

            var sourceParameter = new ParameterProvider("source", sourceParameterDescription, sourceParameterType);
            var converterParameter = new ParameterProvider("converter", $"The converter function from {_tType.Name} to {_uType.Name}.", new CSharpType(typeof(Func<,>), _tType, _uType));

            var signature = new ConstructorSignature(
                Type,
                $"Initializes a new instance of the {(_isAsync ? "Async" : "")}PageableWrapper class.",
                MethodSignatureModifiers.Public,
                [sourceParameter, converterParameter]);

            var bodyStatements = new MethodBodyStatement[]
            {
                _sourceField.Assign(sourceParameter).Terminate(),
                _converterField.Assign(converterParameter).Terminate()
            };

            return [new ConstructorProvider(signature, bodyStatements, this)];
        }

        protected override FormattableString BuildDescription()
        {
            return (FormattableString)$"A converter that can convert from type {_tType.Name} to type {_uType.Name} for {(_isAsync ? "Async" : "")}Pageable operations.";
        }
    }
}
