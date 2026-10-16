// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace StorageMcp.Generator;

internal sealed class ContainerBindingProvider() : McpProvider("ContainerCreateBinding")
{
    protected override TypeSignatureModifiers BuildDeclarationModifiers() =>
        TypeSignatureModifiers.Internal | TypeSignatureModifiers.Class | TypeSignatureModifiers.Static;

    protected override MethodProvider[] BuildMethods()
    {
        var serviceType = ExistingType("Azure.Storage.Blobs", "BlobServiceClient");
        var containerType = ExistingType("Azure.Storage.Blobs", "BlobContainerClient");
        var accessType = ExistingType("Azure.Storage.Blobs.Models", "PublicAccessType");
        var service = new ParameterProvider("serviceClient", $"The authenticated Storage SDK client.", serviceType);
        var container = new ParameterProvider("container", $"The container name.", typeof(string));
        var token = new ParameterProvider("cancellationToken", $"The cancellation token.", typeof(CancellationToken));
        var declaration = Declare("client", containerType,
            ((ValueExpression)service).Invoke("GetBlobContainerClient", container), out VariableExpression client);
        return
        [
            new MethodProvider(new MethodSignature("CreateAsync", $"Creates a private container using the existing Azure SDK.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Async,
                new CSharpType(typeof(Task<>), containerType), null, [service, container, token]),
                new MethodBodyStatements(
                [
                    declaration,
                    client.Invoke("CreateAsync",
                        [Static(accessType).Property("None"), PositionalReference("cancellationToken", token)], true).Terminate(),
                    Return(client)
                ]), this)
        ];
    }
}
