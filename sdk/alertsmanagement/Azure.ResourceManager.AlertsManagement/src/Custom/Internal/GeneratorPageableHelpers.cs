// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.AlertsManagement
{
    // Bridges the frozen generated AlertsManagement code to the shared pageable helper implementation.
    //
    // TODO: Remove this file during the mgmt-plane (MPG) migration to TypeSpec.
    // It only exists so the frozen AutoRest-generated code, which references
    // Autorest.CSharp.Core.GeneratorPageableHelpers, keeps compiling now that the
    // AutoRest dependency has been dropped. Once this library is regenerated from
    // TypeSpec the generated code will no longer reference GeneratorPageableHelpers.
    internal static class GeneratorPageableHelpers
    {
        public static AsyncPageable<T> CreateAsyncPageable<T>(Func<int?, HttpMessage> createFirstPageRequest, Func<int?, string, HttpMessage> createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string itemPropertyName, string nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return PageableHelpers.CreateAsyncPageable(createFirstPageRequest, createNextPageRequest, valueFactory, clientDiagnostics, pipeline, scopeName, itemPropertyName, nextLinkPropertyName, cancellationToken);
        }

        public static Pageable<T> CreatePageable<T>(Func<int?, HttpMessage> createFirstPageRequest, Func<int?, string, HttpMessage> createNextPageRequest, Func<JsonElement, T> valueFactory, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string scopeName, string itemPropertyName, string nextLinkPropertyName, CancellationToken cancellationToken) where T : notnull
        {
            return PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, valueFactory, clientDiagnostics, pipeline, scopeName, itemPropertyName, nextLinkPropertyName, cancellationToken);
        }
    }
}
