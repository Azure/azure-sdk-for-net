// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Utilities;
using Azure.ResourceManager;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class MgmtLongRunningOperationProvider : TypeProvider
    {
        private class Template<T> { }
        private readonly CSharpType _t = typeof(Template<>).GetGenericArguments()[0];

        private bool _isGeneric;
        private FieldProvider _operationField;
        private FieldProvider _rehydrationTokenField;
        private FieldProvider _nextLinkOperationField;
        private FieldProvider _operationIdField;

        public MgmtLongRunningOperationProvider(bool isGeneric)
        {
            _isGeneric = isGeneric;
            _operationField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, isGeneric ? new CSharpType(typeof(OperationInternal), _t) : typeof(OperationInternal), "_operation", this);
            _rehydrationTokenField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, new CSharpType(typeof(RehydrationToken), true), "_completeRehydrationToken", this);
            _nextLinkOperationField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, new CSharpType(typeof(NextLinkOperationImplementation), true), "_nextLinkOperation", this);
            _operationIdField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_operationId", this);
        }

        private readonly string _serviceName = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Name.Split('.').Last();
        protected override string BuildName() => $"{_serviceName}ArmOperation";

        protected override CSharpType[] GetTypeArguments() => _isGeneric ? new CSharpType[] { _t } : base.GetTypeArguments();

        protected override string BuildRelativeFilePath()
        {
            return Path.Combine("src", "Generated", "LongRunningOperation", GetFileName());

            string GetFileName() => _isGeneric ? $"{_serviceName}ArmOperationOfT.cs" : $"{Name}.cs";
        }

        protected override CSharpType[] BuildImplements() => [_isGeneric ? new CSharpType(typeof(ArmOperation), _t) : typeof(ArmOperation)];

        protected override FieldProvider[] BuildFields()
            => [_operationField, _rehydrationTokenField, _nextLinkOperationField, _operationIdField];

        protected override MethodProvider[] BuildMethods()
        {
            var getRehydrationTokenMethod = new MethodProvider(
                new MethodSignature("GetRehydrationToken", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(RehydrationToken), true), null, []),
                _nextLinkOperationField.NullConditional().Invoke(nameof(NextLinkOperationImplementation.GetRehydrationToken)).NullCoalesce(_rehydrationTokenField),
                this, XmlDocProvider.InheritDocs);

            var getRawResponseMethod = new MethodProvider(
                new MethodSignature("GetRawResponse", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, []),
                _operationField.Property("RawResponse"),
                this, XmlDocProvider.InheritDocs);

            var cancellationTokenParameter = new ParameterProvider("cancellationToken", $"", typeof(CancellationToken), Default);
            var updateStatusMethod = new MethodProvider(
                new MethodSignature("UpdateStatus", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, [cancellationTokenParameter]),
                _operationField.Invoke("UpdateStatus", [cancellationTokenParameter]),
                this, XmlDocProvider.InheritDocs);

            var updateStatusAsyncMethod = new MethodProvider(
                new MethodSignature("UpdateStatusAsync", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(ValueTask), typeof(Response)), null, [cancellationTokenParameter]),
                _operationField.Invoke("UpdateStatusAsync", [cancellationTokenParameter]),
                this, XmlDocProvider.InheritDocs);

            var waitForCompletionResponseMethod = _isGeneric
                ? new MethodProvider(
                    new MethodSignature("WaitForCompletion", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(Response), _t), null, [cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletion", [cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs)
                : new MethodProvider(
                    new MethodSignature("WaitForCompletionResponse", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, [cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionResponse", [cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs);

            var timeSpanParameter = new ParameterProvider("pollingInterval", $"", typeof(TimeSpan));
            var waitForCompletionResponseWithPolingMethod = _isGeneric
                ? new MethodProvider(
                    new MethodSignature("WaitForCompletion", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(Response), _t), null, [timeSpanParameter, cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletion", [timeSpanParameter, cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs)
                : new MethodProvider(
                    new MethodSignature("WaitForCompletionResponse", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, [timeSpanParameter, cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionResponse", [timeSpanParameter, cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs);

            var waitForCompletionResponseAsyncMethod = _isGeneric
                ? new MethodProvider(
                    new MethodSignature("WaitForCompletionAsync", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(ValueTask), new CSharpType(typeof(Response), _t)), null, [cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionAsync", [cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs)
                : new MethodProvider(
                    new MethodSignature("WaitForCompletionResponseAsync", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(ValueTask), typeof(Response)), null, [cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionResponseAsync", [cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs);

            var waitForCompletionResponseWithPollingAsyncMethod = _isGeneric
                ? new MethodProvider(
                    new MethodSignature("WaitForCompletionAsync", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(ValueTask), new CSharpType(typeof(Response), _t)), null, [timeSpanParameter, cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionAsync", [timeSpanParameter, cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs)
                : new MethodProvider(
                    new MethodSignature("WaitForCompletionResponseAsync", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, new CSharpType(typeof(ValueTask), typeof(Response)), null, [timeSpanParameter, cancellationTokenParameter]),
                    _operationField.Invoke("WaitForCompletionResponseAsync", [timeSpanParameter, cancellationTokenParameter]),
                    this, XmlDocProvider.InheritDocs);

            return [BuildGetOperationIdMethod(), getRehydrationTokenMethod, getRawResponseMethod, updateStatusMethod, updateStatusAsyncMethod, waitForCompletionResponseMethod, waitForCompletionResponseWithPolingMethod, waitForCompletionResponseAsyncMethod, waitForCompletionResponseWithPollingAsyncMethod];
        }

        private const string GetOperationIdName = "GetOperationId";
        private MethodProvider BuildGetOperationIdMethod()
        {
            var rehydrationTokenParaemter = new ParameterProvider("rehydrationToken", $"The token to rehydrate a long-running operation", new CSharpType(typeof(RehydrationToken), true));
            var signature = new MethodSignature(GetOperationIdName, null, MethodSignatureModifiers.Private, typeof(string), null, [rehydrationTokenParaemter]);
            var body = new MethodBodyStatement[]
            {
                new IfStatement(rehydrationTokenParaemter.Is(Null))
                {
                    Return(Null)
                },
                Declare("lroDetails", typeof(Dictionary<string, string>), Static(typeof(ModelReaderWriter)).Invoke("Write", [rehydrationTokenParaemter, Static(typeof(ModelReaderWriterOptions)).Property("Json")]).Invoke("ToObjectFromJson", [], new List<CSharpType>{ typeof(Dictionary<string, string>) }, false), out var lroDetailsVariable),
                Return(new IndexerExpression(lroDetailsVariable, Literal("id")))
            };
            return new MethodProvider(signature, body, this);
        }

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildRehydrationConstructor(), BuildInitializationConstructor()];

        private ConstructorProvider BuildInitializationConstructor()
        {
            var sourceParameter = new ParameterProvider("source", $"", new CSharpType(typeof(IOperationSource<>), _t));
            var clientDiagnosticsParameter = new ParameterProvider("clientDiagnostics", $"", typeof(ClientDiagnostics));
            var pipelineParameter = new ParameterProvider("pipeline", $"", typeof(HttpPipeline));
            var requestParameter = new ParameterProvider("request", $"", typeof(Request));
            var responseParameter = new ParameterProvider("response", $"", typeof(Response));
            var finalStateViaParameter = new ParameterProvider("finalStateVia", $"", typeof(OperationFinalStateVia));
            var skipApiVersionOverrideParameter = new ParameterProvider("skipApiVersionOverride", $"", typeof(bool), defaultValue: Literal(false));
            var apiVersionOverrideValueParameter = new ParameterProvider("apiVersionOverrideValue", $"", typeof(string), defaultValue: Null);
            var parameters = _isGeneric
                ? new List<ParameterProvider>
                {
                    sourceParameter,
                    clientDiagnosticsParameter,
                    pipelineParameter,
                    requestParameter,
                    responseParameter,
                    finalStateViaParameter,
                    skipApiVersionOverrideParameter,
                    apiVersionOverrideValueParameter,
                }
                : new List<ParameterProvider>
                {
                    clientDiagnosticsParameter,
                    pipelineParameter,
                    requestParameter,
                    responseParameter,
                    finalStateViaParameter,
                    skipApiVersionOverrideParameter,
                    apiVersionOverrideValueParameter,
                };
            var signature = new ConstructorSignature(Type, $"", MethodSignatureModifiers.Internal, parameters, null);
            var responseDeclaration = Declare("nextLinkOperation", typeof(IOperation), Static(typeof(NextLinkOperationImplementation)).Invoke("Create", [pipelineParameter, requestParameter.Property("Method"), requestParameter.Property("Uri").Invoke("ToUri"), responseParameter, finalStateViaParameter, skipApiVersionOverrideParameter, apiVersionOverrideValueParameter]), out var nextLinkOperationVariable);

            var body = new MethodBodyStatement[]
            {
                responseDeclaration,
                new IfElseStatement(
                    nextLinkOperationVariable.Is(Declare<NextLinkOperationImplementation>("nextLinkOperationImplementation", out var nextLinkOperationImplementationVariable)),
                    new MethodBodyStatements([
                        _nextLinkOperationField.Assign(nextLinkOperationImplementationVariable).Terminate(),
                        _operationIdField.Assign(_nextLinkOperationField.Property("OperationId")).Terminate(),
                    ]),
                    new MethodBodyStatements([
                        _rehydrationTokenField.Assign(Static(typeof(NextLinkOperationImplementation)).Invoke("GetRehydrationToken", [requestParameter.Property("Method"), requestParameter.Property("Uri").Invoke("ToUri"), responseParameter, finalStateViaParameter])).Terminate(),
                        _operationIdField.Assign(This.Invoke(GetOperationIdName, _rehydrationTokenField)).Terminate(),
                    ])),
                _operationField.Assign(_isGeneric
                    ? New.Instance(new CSharpType(typeof(OperationInternal), _t), [Static<NextLinkOperationImplementation>().Invoke("Create", sourceParameter, nextLinkOperationVariable), clientDiagnosticsParameter, responseParameter, Literal("MgmtTypeSpecArmOperation"), Null, New.Instance(typeof(SequentialDelayStrategy))])
                    : New.Instance(typeof(OperationInternal), [nextLinkOperationVariable, clientDiagnosticsParameter, responseParameter, Literal("MgmtTypeSpecArmOperation"), Null, New.Instance(typeof(SequentialDelayStrategy))])).Terminate(),
            };
            return new ConstructorProvider(signature, body, this);
        }

        private ConstructorProvider BuildRehydrationConstructor()
        {
            var responseParameter = new ParameterProvider("response", $"", _isGeneric ? new CSharpType(typeof(Response), _t) : typeof(Response));
            var rehydrationTokenParameter = new ParameterProvider("rehydrationToken", $"", new CSharpType(typeof(RehydrationToken), true), Null);
            var signature = new ConstructorSignature(Type, $"", MethodSignatureModifiers.Internal, [responseParameter, rehydrationTokenParameter], null);
            var body = new MethodBodyStatement[]
            {
                _operationField.Assign(_isGeneric
                    ? Static(new CSharpType(typeof(OperationInternal), _t)).Invoke(nameof(OperationInternal.Succeeded), [responseParameter.Invoke("GetRawResponse"), responseParameter.Property("Value")])
                    : Static(typeof(OperationInternal)).Invoke(nameof(OperationInternal.Succeeded), [responseParameter])
                ).Terminate(),
                _rehydrationTokenField.Assign(rehydrationTokenParameter).Terminate(),
                _operationIdField.Assign(This.Invoke(GetOperationIdName, rehydrationTokenParameter)).Terminate(),
            };
            return new ConstructorProvider(signature, body, this);
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var idProperty = new PropertyProvider(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(string), "Id", new ExpressionPropertyBody(_operationIdField.NullCoalesce(Static<NextLinkOperationImplementation>().Property(nameof(NextLinkOperationImplementation.NotSet)))), this);
            var hasCompletedProperty = new PropertyProvider(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(bool), "HasCompleted", new ExpressionPropertyBody(_operationField.Property("HasCompleted")), this);

            if (_isGeneric)
            {
                var valueProperty = new PropertyProvider(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, _t, "Value", new ExpressionPropertyBody(_operationField.Property("Value")), this);
                var hasValueProperty = new PropertyProvider(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(bool), "HasValue", new ExpressionPropertyBody(_operationField.Property("HasValue")), this);
                return [idProperty, valueProperty, hasValueProperty, hasCompletedProperty];
            }

            return [idProperty, hasCompletedProperty];
        }
    }
}
