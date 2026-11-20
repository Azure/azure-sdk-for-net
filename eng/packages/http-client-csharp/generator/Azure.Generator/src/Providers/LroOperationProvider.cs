// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal sealed class LroOperationProvider : TypeProvider
    {
        private readonly InputLongRunningServiceMethod _method;
        private readonly ClientProvider _client;
        private readonly string _name;
        private readonly FieldProvider _operation;
        private readonly FieldProvider _getResponse;

        internal LroOperationProvider(InputLongRunningServiceMethod method, ClientProvider client, string name)
        {
            _method = method;
            _client = client;
            _name = name;
            ResultType = method.Response.Type is null ? null : new CSharpType(typeof(BinaryData));
            var resultType = ResultType;
            _operation = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                resultType is null ? typeof(Operation) : new CSharpType(typeof(Operation<>), resultType),
                "_operation", this);
            _getResponse = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(Func<Response>), "_getStatusMonitorResponse", this);
        }

        internal CSharpType? ResultType { get; }
        protected override string BuildName() => _name;
        protected override string BuildNamespace() => _client.Type.Namespace;
        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "LongRunningOperation", $"{Name}.cs");
        protected override FormattableString BuildDescription() => $"Tracks the long-running {_method.Name} operation and exposes its selected operation ID.";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => TypeSignatureModifiers.Internal | TypeSignatureModifiers.Partial;
        protected override CSharpType BuildBaseType() => _operation.Type;
        protected override CSharpType[] BuildImplements() => [typeof(IStatusMonitorOperation), typeof(IPollingUriOperation)];
        protected override FieldProvider[] BuildFields() => [_operation, _getResponse];

        protected override ConstructorProvider[] BuildConstructors()
        {
            var operation = new ParameterProvider("operation", $"The underlying operation.", _operation.Type);
            var getResponse = new ParameterProvider("getStatusMonitorResponse", $"Gets the latest status-monitor response.", typeof(Func<Response>));
            return
            [
                new ConstructorProvider(new ConstructorSignature(Type, null, MethodSignatureModifiers.Internal, [operation, getResponse]),
                new MethodBodyStatement[]
                {
                    _operation.Assign(operation).Terminate(),
                    _getResponse.Assign(getResponse).Terminate()
                }, this)
            ];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>
            {
                DelegatedProperty("HasCompleted", typeof(bool)),
                new PropertyProvider($"Gets the selected server-issued operation identifier, or NOT_SET until available.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(string), "Id",
                    new ExpressionPropertyBody(BuildId()), this)
            };
            if (ResultType is not null)
            {
                properties.Add(DelegatedProperty("Value", ResultType));
                properties.Add(DelegatedProperty("HasValue", typeof(bool)));
            }
            return properties.ToArray();
        }

        private PropertyProvider DelegatedProperty(string name, CSharpType type) =>
            new(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, type, name,
                new ExpressionPropertyBody(_operation.Property(name)), this);

        private ValueExpression BuildId()
        {
            var metadata = _method.LongRunningServiceMetadata.OperationId;
            var path = metadata.OfType<InputLroOperationIdPathMetadata>().SingleOrDefault();
            var body = metadata.OfType<InputLroOperationIdPropertyMetadata>().SingleOrDefault();
            string? pollingLinkHeader = null;
            if (path is not null && !TryGetPollingLinkHeader(path.Source, out pollingLinkHeader))
            {
                AzureClientGenerator.Instance.Emitter.ReportDiagnostic(
                    "unsupported-lro-operation-id-source",
                    $"The polling link of operation '{_method.Name}' comes from '{path.Source.Location}' '{path.Source.Property.SerializedName}', which the generated operation does not poll. The operation ID is not extracted from the polling URI.",
                    _method.CrossLanguageDefinitionId);
                path = null;
            }
            return Static(typeof(ProtocolOperationHelpers)).Invoke("GetOperationId",
            [
                _operation,
                _getResponse.AsValueExpression.Invoke("Invoke"),
                body is null ? Null : New.Array(typeof(string), body.PropertySegments.Select(p => Literal(p.SerializationOptions?.Json?.Name ?? p.SerializedName)).ToArray()),
                pollingLinkHeader is null ? Null : Literal(pollingLinkHeader),
                path is null ? Null : Literal(path.PollingPath),
                path is null ? Null : Literal(path.PathParameter.SerializedName),
                path is null ? Null : Literal(path.PathParameter.Style.ToString())
            ]);
        }

        // Azure.Core polls the initial request URI or the first of these headers present on the initial response.
        private static readonly string[] SupportedPollingLinkHeaders = ["Operation-Location", "Azure-AsyncOperation", "Location"];

        private static bool TryGetPollingLinkHeader(InputOperationLink source, out string? header)
        {
            header = null;
            switch (source.Location)
            {
                case InputOperationLinkLocation.Self:
                    return true;
                case InputOperationLinkLocation.ResponseHeader:
                    header = SupportedPollingLinkHeaders.FirstOrDefault(h => string.Equals(h, source.Property.SerializedName, StringComparison.OrdinalIgnoreCase));
                    return header is not null;
                default:
                    return false;
            }
        }

        internal FuncExpression CreateFactory()
        {
            var operation = new VariableExpression(new CSharpType(typeof(Operation<>), ResultType ?? typeof(VoidValue)), "operation");
            var monitor = new VariableExpression(typeof(Func<Response>), "monitor");
            return new FuncExpression([operation.Declaration, monitor.Declaration], New.Instance(Type, operation, monitor));
        }

        protected override MethodProvider[] BuildMethods()
        {
            var cancellationToken = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken), Default);
            var pollingLinkHeader = new ParameterProvider("pollingLinkHeader", $"The header that supplied the polling link.", new CSharpType(typeof(string), isNullable: true));
            var pollingInterval = new ParameterProvider("pollingInterval", $"The polling interval.", typeof(TimeSpan));
            var delayStrategy = new ParameterProvider("delayStrategy", $"The polling delay strategy.", typeof(DelayStrategy));
            var methods = new List<MethodProvider>
            {
                new MethodProvider(new MethodSignature("GetRawResponse", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, []),
                    _operation.AsValueExpression.Invoke("GetRawResponse"), this),
                new MethodProvider(new MethodSignature("GetRehydrationToken", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(RehydrationToken?), null, []),
                    _operation.AsValueExpression.Invoke("GetRehydrationToken"), this),
                new MethodProvider(new MethodSignature("GetStatusMonitorResponse", null,
                    MethodSignatureModifiers.None, typeof(Response), null, [], ExplicitInterface: typeof(IStatusMonitorOperation)),
                    _getResponse.AsValueExpression.Invoke("Invoke"), this),
                new MethodProvider(new MethodSignature("GetPollingUri", null,
                    MethodSignatureModifiers.None, typeof(Uri), null, [pollingLinkHeader], ExplicitInterface: typeof(IPollingUriOperation)),
                    Static(typeof(ProtocolOperationHelpers)).Invoke("GetPollingUri", _operation, pollingLinkHeader), this),
                new MethodProvider(new MethodSignature("UpdateStatus", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, [cancellationToken]),
                    _operation.AsValueExpression.Invoke("UpdateStatus", cancellationToken), this),
                new MethodProvider(new MethodSignature("UpdateStatusAsync", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(ValueTask<Response>), null, [cancellationToken]),
                    _operation.AsValueExpression.Invoke("UpdateStatusAsync", cancellationToken), this)
            };
            foreach (var parameters in new ParameterProvider[][] { [cancellationToken], [pollingInterval, cancellationToken], [delayStrategy, cancellationToken] })
            {
                methods.Add(DelegateWait("WaitForCompletionResponse", typeof(Response), parameters));
                methods.Add(DelegateWait("WaitForCompletionResponseAsync", typeof(ValueTask<Response>), parameters));
                if (ResultType is not null)
                {
                    var responseType = new CSharpType(typeof(Response<>), ResultType);
                    methods.Add(DelegateWait("WaitForCompletion", responseType, parameters));
                    methods.Add(DelegateWait("WaitForCompletionAsync", new CSharpType(typeof(ValueTask<>), responseType), parameters));
                }
            }
            return methods.ToArray();
        }

        private MethodProvider DelegateWait(string name, CSharpType returnType, ParameterProvider[] parameters) =>
            new(new MethodSignature(name, null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                returnType, null, parameters),
                _operation.AsValueExpression.Invoke(name, parameters.Select(parameter => (ValueExpression)parameter).ToArray()), this);
    }
}
