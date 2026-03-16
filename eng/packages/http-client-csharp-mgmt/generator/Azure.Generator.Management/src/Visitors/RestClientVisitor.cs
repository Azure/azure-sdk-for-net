// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
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
                type.Update(methods: [.. client.RestClient.Methods], modifiers: TransformPublicModifiersToInternal(type), relativeFilePath: TransformRelativeFilePathForClient(type));
            }
        }

        // remove RestClientProvider
        if (type is RestClientProvider)
        {
            return null;
        }

        return type;
    }

    private void UpdateRootClient(ClientProvider rootClient)
    {
        // Reuse the ClientProvider's own FieldProvider objects. REST client
        // methods reference these objects by identity, so creating new ones
        // with different names (e.g., _apiVersion vs _serviceTestsApiVersion)
        // causes unresolved references in the generated code.
        var endpointField = rootClient.EndpointField;

        // Collect API version fields from the client's existing fields.
        // In multi-service clients the base generator uses namespace-derived
        // names (e.g., _serviceTestsApiVersion) that the request builders reference.
        var apiVersionFields = rootClient.Fields
            .Where(f => f != endpointField && f.Name.IndexOf("apiVersion", StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        var fields = new System.Collections.Generic.List<FieldProvider> { endpointField };
        if (apiVersionFields.Count > 0)
        {
            fields.AddRange(apiVersionFields);
        }
        else
        {
            // Fallback for clients with no API version fields
            fields.Add(new FieldProvider(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(string), "_apiVersion", rootClient));
        }

        // properties
        var pipelineProperty = new PropertyProvider(
            description: $"The HTTP pipeline for sending and receiving REST requests and responses.",
            modifiers: MethodSignatureModifiers.Public,
            type: typeof(HttpPipeline),
            name: "Pipeline",
            body: new AutoPropertyBody(false),
            enclosingType: rootClient);
        var clientDiagnosticsProperty = new PropertyProvider(
            description: $"The ClientDiagnostics is used to provide tracing support for the client library.",
            modifiers: MethodSignatureModifiers.Internal,
            type: typeof(ClientDiagnostics),
            name: "ClientDiagnostics",
            body: new AutoPropertyBody(false),
            enclosingType: rootClient);

        // constructor — accepts a single apiVersion string and assigns it to
        // all API version fields (which may differ only in name across services).
        var clientDiagnosticsParam = new ParameterProvider("clientDiagnostics", $"The ClientDiagnostics is used to provide tracing support for the client library.", typeof(ClientDiagnostics));
        var pipelineParam = new ParameterProvider("pipeline", $"The HTTP pipeline for sending and receiving REST requests and responses.", typeof(HttpPipeline));
        var endpointParam = new ParameterProvider("endpoint", $"Service endpoint.", typeof(Uri), null);
        var apiVersionParam = new ParameterProvider("apiVersion", $"The API version to use for this client.", typeof(string));

        // Build constructor body: assign all fields from the corresponding parameters
        var apiVersionFieldsOnly = fields.Where(f => f != endpointField).ToArray();
        var assignments = new MethodBodyStatement[3 + apiVersionFieldsOnly.Length];
        assignments[0] = clientDiagnosticsProperty.Assign(clientDiagnosticsParam).Terminate();
        assignments[1] = endpointField.Assign(endpointParam).Terminate();
        assignments[2] = pipelineProperty.Assign(pipelineParam).Terminate();
        for (int i = 0; i < apiVersionFieldsOnly.Length; i++)
        {
            assignments[3 + i] = apiVersionFieldsOnly[i].Assign(apiVersionParam).Terminate();
        }

        var ctor = new ConstructorProvider(
            new ConstructorSignature(rootClient.Type, null, MethodSignatureModifiers.Public, [clientDiagnosticsParam, pipelineParam, endpointParam, apiVersionParam]),
            assignments,
            rootClient);

        rootClient.Update(
            fields: [.. fields],
            methods: [.. rootClient.RestClient.Methods], // put create request methods to client directly
            modifiers: TransformPublicModifiersToInternal(rootClient),
            relativeFilePath: TransformRelativeFilePathForClient(rootClient),
            properties: [pipelineProperty, clientDiagnosticsProperty],
            constructors: [ctor, ConstructorProviderHelpers.BuildMockingConstructor(rootClient)]);
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
