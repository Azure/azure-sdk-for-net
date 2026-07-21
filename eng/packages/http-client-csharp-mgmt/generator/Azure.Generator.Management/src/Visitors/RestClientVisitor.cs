// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors;

internal class RestClientVisitor : ScmLibraryVisitor
{
    /// <inheritdoc/>
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type is not null && type is ClientProvider client)
        {
            // handle root client
            if (client.ClientOptions is not null)
            {
                UpdateRootClient(client);
            }
            else
            {
                // omit methods for ClientProvider, MPG will implement its own client methods
                // put create request methods to client directly
                UpdateNonRootClient(client);
            }
        }

        // remove RestClientProvider
        if (type is RestClientProvider)
        {
            return null;
        }

        return type;
    }

    private static void UpdateNonRootClient(ClientProvider client)
    {
        var userAgentField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(TelemetryDetails), "_userAgent", client);
        var constructor = client.Constructors.Single(constructor =>
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
            ? [userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(client.Type).Property(nameof(Type.Assembly)), applicationIdParam)).Terminate()]
            : new MethodBodyStatement[]
            {
                constructor.BodyStatements,
                userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(client.Type).Property(nameof(Type.Assembly)), applicationIdParam)).Terminate(),
            };

        var xmlDocs = constructor.XmlDocs;
        if (xmlDocs is not null)
        {
            var parameterDocs = xmlDocs.Parameters.ToList();
            parameterDocs.Insert(pipelineParameterIndex + 1, new XmlDocParamStatement(applicationIdParam));
            xmlDocs.Update(parameters: parameterDocs);
        }

        constructor.Update(signature: signature, bodyStatements: body, xmlDocs: xmlDocs);
        client.Update(
            fields: [.. client.Fields, userAgentField],
            methods: [.. client.RestClient.Methods],
            modifiers: TransformPublicModifiersToInternal(client),
            relativeFilePath: TransformRelativeFilePathForClient(client));
    }

    private void UpdateRootClient(ClientProvider rootClient)
    {
        UpdateClient(
            rootClient,
            MethodSignatureModifiers.Public,
            new ParameterProvider("apiVersion", $"The API version to use for this client.", typeof(string)));
    }

    private static void UpdateClient(ClientProvider client, MethodSignatureModifiers constructorModifiers, ParameterProvider apiVersionParam)
    {
        // fields
        var apiVersionField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_apiVersion", client);
        var endpointField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(Uri), "_endpoint", client);
        var userAgentField = new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(TelemetryDetails), "_userAgent", client);

        // properties
        var pipelineProperty = new PropertyProvider(
            description: $"The HTTP pipeline for sending and receiving REST requests and responses.",
            modifiers: MethodSignatureModifiers.Public,
            type: typeof(HttpPipeline),
            name: "Pipeline",
            body: new AutoPropertyBody(false),
            enclosingType: client);
        var clientDiagnosticsProperty = new PropertyProvider(
            description: $"The ClientDiagnostics is used to provide tracing support for the client library.",
            modifiers: MethodSignatureModifiers.Internal,
            type: typeof(ClientDiagnostics),
            name: "ClientDiagnostics",
            body: new AutoPropertyBody(false),
            enclosingType: client);

        // constructor
        var clientDiagnosticsParam = new ParameterProvider("clientDiagnostics", $"The ClientDiagnostics is used to provide tracing support for the client library.", typeof(ClientDiagnostics));
        var pipelineParam = new ParameterProvider("pipeline", $"The HTTP pipeline for sending and receiving REST requests and responses.", typeof(HttpPipeline));
        var applicationIdParam = new ParameterProvider("applicationId", $"The application id to use for user agent.", typeof(string));
        var endpointParam = new ParameterProvider("endpoint", $"Service endpoint.", typeof(Uri), null);
        var ctorBody = new MethodBodyStatement[]
        {
            clientDiagnosticsProperty.Assign(clientDiagnosticsParam).Terminate(),
            endpointField.Assign(endpointParam).Terminate(),
            pipelineProperty.Assign(pipelineParam).Terminate(),
            apiVersionField.Assign(apiVersionParam).Terminate(),
            userAgentField.Assign(New.Instance(typeof(TelemetryDetails), TypeOf(client.Type).Property(nameof(Type.Assembly)), applicationIdParam)).Terminate(),
        };
        var ctor = new ConstructorProvider(
            new ConstructorSignature(client.Type, null, constructorModifiers, [clientDiagnosticsParam, pipelineParam, applicationIdParam, endpointParam, apiVersionParam]),
            ctorBody,
            client);

        client.Update(
            fields: [apiVersionField, endpointField, userAgentField],
            methods: [.. client.RestClient.Methods],
            modifiers: TransformPublicModifiersToInternal(client),
            relativeFilePath: TransformRelativeFilePathForClient(client),
            properties: [pipelineProperty, clientDiagnosticsProperty],
            constructors: [ctor, ConstructorProviderHelpers.BuildMockingConstructor(client)]);
    }

    private static string TransformRelativeFilePathForClient(TypeProvider type)
        => Path.Combine("src", "Generated", "RestOperations", $"{type.Name}RestOperations.cs");

    private static TypeSignatureModifiers TransformPublicModifiersToInternal(TypeProvider type)
    {
        var modifiers = type.DeclarationModifiers;
        if (modifiers.HasFlag(TypeSignatureModifiers.Public))
        {
            modifiers &= ~TypeSignatureModifiers.Public;
            modifiers |= TypeSignatureModifiers.Internal;
        }

        return modifiers;
    }
}
