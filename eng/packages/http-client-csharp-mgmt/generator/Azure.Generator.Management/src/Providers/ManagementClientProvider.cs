// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers;

internal sealed class ManagementClientProvider : ClientProvider
{
    private readonly bool _isRootClient;
    private readonly FieldProvider? _apiVersionField;
    private readonly FieldProvider? _endpointField;
    private readonly FieldProvider _userAgentField;
    private readonly PropertyProvider? _pipelineProperty;
    private readonly PropertyProvider? _clientDiagnosticsProperty;

    public ManagementClientProvider(InputClient inputClient)
        : base(inputClient)
    {
        _isRootClient = inputClient.Parent is null;
        _userAgentField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(TelemetryDetails), "_userAgent", this);

        if (_isRootClient)
        {
            _apiVersionField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_apiVersion", this);
            _endpointField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(Uri), "_endpoint", this);
            _pipelineProperty = new PropertyProvider(
                description: $"The HTTP pipeline for sending and receiving REST requests and responses.",
                modifiers: MethodSignatureModifiers.Public,
                type: typeof(HttpPipeline),
                name: "Pipeline",
                body: new AutoPropertyBody(false),
                enclosingType: this);
            _clientDiagnosticsProperty = new PropertyProvider(
                description: $"The ClientDiagnostics is used to provide tracing support for the client library.",
                modifiers: MethodSignatureModifiers.Internal,
                type: typeof(ClientDiagnostics),
                name: "ClientDiagnostics",
                body: new AutoPropertyBody(false),
                enclosingType: this);
        }
    }

    protected override FieldProvider[] BuildFields()
        => _isRootClient
            ? [_apiVersionField!, _endpointField!, _userAgentField]
            : [.. base.BuildFields(), _userAgentField];

    protected override PropertyProvider[] BuildProperties()
        => _isRootClient
            ? [_pipelineProperty!]
            : base.BuildProperties();

    protected override ConstructorProvider[] BuildConstructors()
        => _isRootClient ? BuildRootConstructors() : BuildNonRootConstructors();

    protected override FormattableString BuildDescription() => $"";

    protected override string BuildRelativeFilePath()
        => Path.Combine("src", "Generated", "RestOperations", $"{Name}RestOperations.cs");

    private ConstructorProvider[] BuildRootConstructors()
    {
        var clientDiagnosticsParam = new ParameterProvider("clientDiagnostics", $"The ClientDiagnostics is used to provide tracing support for the client library.", typeof(ClientDiagnostics));
        var pipelineParam = new ParameterProvider("pipeline", $"The HTTP pipeline for sending and receiving REST requests and responses.", typeof(HttpPipeline));
        var applicationIdParam = new ParameterProvider("applicationId", $"The application id to use for user agent.", typeof(string));
        var endpointParam = new ParameterProvider("endpoint", $"Service endpoint.", typeof(Uri), null);
        var apiVersionParam = new ParameterProvider("apiVersion", $"The API version to use for this client.", typeof(string));
        var constructor = new ConstructorProvider(
            new ConstructorSignature(Type, null, MethodSignatureModifiers.Public, [clientDiagnosticsParam, pipelineParam, applicationIdParam, endpointParam, apiVersionParam]),
            new MethodBodyStatement[]
            {
                _clientDiagnosticsProperty!.Assign(clientDiagnosticsParam).Terminate(),
                _endpointField!.Assign(endpointParam).Terminate(),
                _pipelineProperty!.Assign(pipelineParam).Terminate(),
                _apiVersionField!.Assign(apiVersionParam).Terminate(),
                _userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(Type).Property(nameof(System.Type.Assembly)), applicationIdParam)).Terminate(),
            },
            this);

        return [constructor, ConstructorProviderHelpers.BuildMockingConstructor(this)];
    }

    private ConstructorProvider[] BuildNonRootConstructors()
    {
        var constructors = base.BuildConstructors();
        var constructor = constructors.Single(constructor =>
            constructor.Signature.Parameters.Any(parameter => parameter.Type.Equals(typeof(HttpPipeline))));
        var applicationIdParam = new ParameterProvider("applicationId", $"The application id to use for user agent.", typeof(string));
        var parameters = constructor.Signature.Parameters.ToList();
        var pipelineParameterIndex = parameters.FindIndex(parameter => parameter.Type.Equals(typeof(HttpPipeline)));
        parameters.Insert(pipelineParameterIndex + 1, applicationIdParam);

        var signature = new ConstructorSignature(
            constructor.Signature.Type,
            constructor.Signature.Description,
            constructor.Signature.Modifiers,
            parameters,
            constructor.Signature.Attributes,
            constructor.Signature.Initializer);
        var body = constructor.BodyStatements is null
            ? [_userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(Type).Property(nameof(System.Type.Assembly)), applicationIdParam)).Terminate()]
            : new MethodBodyStatement[]
            {
                constructor.BodyStatements,
                _userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(Type).Property(nameof(System.Type.Assembly)), applicationIdParam)).Terminate(),
            };

        var xmlDocs = constructor.XmlDocs;
        if (xmlDocs is not null)
        {
            var parameterDocs = xmlDocs.Parameters.ToList();
            parameterDocs.Insert(pipelineParameterIndex + 1, new XmlDocParamStatement(applicationIdParam));
            xmlDocs.Update(parameters: parameterDocs);
        }

        constructor.Update(signature: signature, bodyStatements: body, xmlDocs: xmlDocs);
        return constructors;
    }
}
