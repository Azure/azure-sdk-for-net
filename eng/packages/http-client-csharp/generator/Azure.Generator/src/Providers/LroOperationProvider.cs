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
        private readonly LroStatusMetadataProvider? _metadata;
        private readonly FieldProvider _operation;
        private readonly FieldProvider _getResponse;
        private readonly TypeSignatureModifiers _modifiers;

        internal LroOperationProvider(InputLongRunningServiceMethod method, ClientProvider client,
            string name, CSharpType? resultType, LroStatusMetadataProvider? metadata, TypeSignatureModifiers modifiers)
        {
            _method = method;
            _client = client;
            _name = name;
            ResultType = resultType;
            _metadata = metadata;
            _modifiers = modifiers;
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
        protected override FormattableString BuildDescription() => $"Tracks the long-running {_method.Name} operation and its selected metadata.";
        protected override TypeSignatureModifiers BuildDeclarationModifiers() => _modifiers;
        protected override CSharpType BuildBaseType() => _operation.Type;
        protected override CSharpType[] BuildImplements() => [typeof(IStatusMonitorOperation)];
        protected override FieldProvider[] BuildFields() => [_operation, _getResponse];

        protected override ConstructorProvider[] BuildConstructors()
        {
            var operation = new ParameterProvider("operation", $"The underlying operation.", _operation.Type);
            var getResponse = new ParameterProvider("getStatusMonitorResponse", $"Gets the latest status-monitor response.", typeof(Func<Response>));
            return
            [
                new ConstructorProvider(
                    new ConstructorSignature(Type, $"Initializes a new instance for mocking.", MethodSignatureModifiers.Protected, []),
                    Array.Empty<MethodBodyStatement>(), this),
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
            if (_metadata is not null)
            {
                properties.Add(new PropertyProvider(
                    $"Gets auxiliary metadata from the latest monitor response, including failed and canceled responses. Values are repopulated by polling after rehydration.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Virtual, _metadata.Type, "Metadata",
                    new ExpressionPropertyBody(New.Instance(_metadata.Type, _getResponse)), this));
            }
            return properties.ToArray();
        }

        private PropertyProvider DelegatedProperty(string name, CSharpType type) =>
            new(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, type, name,
                new ExpressionPropertyBody(_operation.Property(name)), this);

        private ValueExpression BuildId()
        {
            var metadata = _method.LongRunningServiceMetadata.OperationId;
            if (metadata.Count == 0)
            {
                return Literal(NextLinkOperationImplementation.NotSet);
            }
            var path = metadata.OfType<InputLroOperationIdPathMetadata>().SingleOrDefault();
            var body = metadata.OfType<InputLroOperationIdPropertyMetadata>().SingleOrDefault();
            return Static(typeof(ProtocolOperationHelpers)).Invoke("GetOperationId",
            [
                _operation.AsValueExpression.Invoke(nameof(Operation.GetRehydrationToken)),
                _getResponse.AsValueExpression.Invoke("Invoke"),
                path is null ? Null : Literal(path.PollingPath),
                path is null ? Null : Literal(path.PathParameter.SerializedName),
                body is null ? Null : New.Array(typeof(string), body.PropertySegments.Select(p => Literal(p.SerializationOptions?.Json?.Name ?? p.SerializedName)).ToArray())
            ]);
        }

        internal FuncExpression CreateFactory()
        {
            var resultType = ResultType ?? typeof(VoidValue);
            var operation = new VariableExpression(new CSharpType(typeof(Operation<>), resultType), "operation");
            var monitor = new VariableExpression(typeof(Func<Response>), "monitor");
            return new FuncExpression([operation.Declaration, monitor.Declaration], New.Instance(Type, operation, monitor));
        }

        internal ValueExpression CreateResultSelector(VariableExpression response)
        {
            if (ResultType is null)
            {
                return New.Instance(typeof(VoidValue));
            }
            if (ResultType.Equals(typeof(BinaryData)))
            {
                return response.Property(nameof(Response.Content));
            }
            return !string.IsNullOrEmpty(_method.LongRunningServiceMetadata.ResultPath) && _method.Response.Type is InputModelType
                ? Static(ResultType).Invoke("FromLroResponse", response)
                : new CastExpression(response, ResultType);
        }

        protected override MethodProvider[] BuildMethods()
        {
            var cancellationToken = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken), Default);
            var response = new VariableExpression(typeof(Response), "response");
            var pipeline = new ParameterProvider("pipeline", $"The client pipeline.", typeof(HttpPipeline));
            var token = new ParameterProvider("rehydrationToken", $"The operation rehydration token.", typeof(RehydrationToken));
            var options = new ParameterProvider("options", $"The client options.", typeof(ClientOptions), Null);
            return
            [
                new MethodProvider(new MethodSignature("GetRawResponse", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, []),
                    _operation.AsValueExpression.Invoke("GetRawResponse"), this),
                new MethodProvider(new MethodSignature("GetRehydrationToken", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(RehydrationToken?), null, []),
                    _operation.AsValueExpression.Invoke("GetRehydrationToken"), this),
                new MethodProvider(new MethodSignature("GetStatusMonitorResponse", null,
                    MethodSignatureModifiers.None, typeof(Response), null, [], ExplicitInterface: typeof(IStatusMonitorOperation)),
                    _getResponse.AsValueExpression.Invoke("Invoke"), this),
                new MethodProvider(new MethodSignature("UpdateStatus", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(Response), null, [cancellationToken]),
                    _operation.AsValueExpression.Invoke("UpdateStatus", cancellationToken), this),
                new MethodProvider(new MethodSignature("UpdateStatusAsync", null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, typeof(ValueTask<Response>), null, [cancellationToken]),
                    _operation.AsValueExpression.Invoke("UpdateStatusAsync", cancellationToken), this),
                new MethodProvider(new MethodSignature("FromRehydrationToken",
                    $"Rehydrates the operation without polling. Metadata is populated by the next status update.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, Type, null, [pipeline, token, options]),
                    Static(typeof(ProtocolOperationHelpers)).Invoke("Rehydrate",
                    [
                        pipeline, token, options, Literal($"{_client.Name}.{_method.Name}"),
                        new FuncExpression([response.Declaration], CreateResultSelector(response)),
                        CreateFactory()
                    ], [ResultType ?? typeof(VoidValue), Type], false), this)
            ];
        }
    }
}
