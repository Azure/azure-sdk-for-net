// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

internal static class ManifestFixtures
{
    internal static JsonSerializerOptions JsonOptions { get; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    internal static McpManifest Create() => new("Example.Generated", [],
        [
            Tool("Secrets", "get", "keyvault", "secret", "Secret", "Example.SecretClient", "GetSecretAsync", "GET", "secrets"),
            Tool("Queues", "remove", "servicebus", "queue", "Queue", "Example.QueueClient", "DeleteQueueAsync", "DELETE", "queues")
        ],
        [new CompositeSelection("keyvault secret list", "Handwritten composition.")]);

    private static ToolSelection Tool(string resource, string operation, string service, string noun,
        string prefix, string client, string sdkMethod, string verb, string path) => new(
        $"Services.{resource}.{operation}",
        service == "keyvault" ? "f5088334-e630-4df0-a5be-ac87787acad0" : "a9ab33b5-d9b0-4cf4-b851-4e20925ade9b",
        [service, noun], operation, $"{operation} {noun}",
        new GeneratedTypes(prefix + "Catalog", prefix + "Options", prefix + "Binding", prefix + "Result", prefix + "JsonContext"),
        $"Example.{prefix}Command", $"{service} request failed (HTTP {{0}}): {{1}}",
        new WireMapping(verb, $"/{path}/{{name}}", "{endpoint}", [new WireConstant("mode", JsonSerializer.SerializeToElement("1"))]),
        [
            new OptionMapping("Name", "string", true, Source: "name"),
            new OptionMapping("Tenant", "string", false, Description: "Optional tenant."),
            new OptionMapping("Limit", "int", false, Description: "Optional local limit.")
        ],
        new SdkBinding("ExecuteAsync", $"Executes {operation} via an existing SDK.", "Example.Model",
            [
                new BindingParameter("client", client, "The authenticated SDK client."),
                new BindingParameter("name", "string", "The resource name."),
                new BindingParameter("cancellationToken", "System.Threading.CancellationToken", "The cancellation token.")
            ],
            [
                new SdkCall("client", sdkMethod,
                    [
                        new BindingArgument(Variable: "name"),
                        new BindingArgument(Literal: JsonSerializer.SerializeToElement<object?>(null)),
                        new BindingArgument(Variable: "cancellationToken", Name: "cancellationToken")
                    ],
                    true, "result", "Example.Model")
            ], "result"),
        [new ResultProperty("Value", "Example.Model")],
        new SafetyOverrides(null, null, null, false));
}
