using TypeSpec.Http;
using Azure.Mcp;

/** Regression fixture for the original low-level SDK-binding mapping. */
@service(#{ title: "Storage MCP pilot" })
@server(
  "{endpoint}",
  "The Storage account endpoint, resolved by the existing MCP account and tenant context.",
  {
    endpoint: url,
  }
)
@mcpService(#{
  outputNamespace: "Azure.Mcp.Tools.Storage.GeneratedMcp",
  metadataReferences: #[
    "src/bin/Debug/net10.0/Microsoft.Mcp.Core.dll",
    "src/bin/Debug/net10.0/Azure.Mcp.Core.dll"
  ],
  composites: #[
    #{
      path: "storage account get",
      reason: "Human-authored Resource Graph query and output shaping.",
    },
    #{
      path: "storage blob container get",
      reason: "Human-authored get/list/prefix composition.",
    },
    #{
      path: "storage blob get",
      reason: "Human-authored get/list composition.",
    }
  ],
})
namespace StoragePilot;

interface Containers {
  /** Creates a private blob container in a Storage account. */
  @put
  @route("/{container}")
  @tool(#{
    id: "f5088334-e630-4df0-a5be-ac87787acad0",
    group: #["storage", "blob", "container"],
    name: "create",
    title: "Create Storage Blob Container",
    types: #{
      catalog: "ContainerCreateCatalog",
      options: "GeneratedContainerCreateOptions",
      binding: "ContainerCreateBinding",
      result: "GeneratedContainerCreateResult",
      jsonContext: "GeneratedStorageJsonContext",
    },
    commandType: "Azure.Mcp.Tools.Storage.Commands.Blob.Container.ContainerCreateCommand",
    descriptionOverride: #{
      type: "Azure.Mcp.Tools.Storage.Commands.Blob.Container.ContainerCreateCommand",
      member: "CustomizedDescription",
    },
    errorMessage: "Storage request failed (HTTP {0}): {1}",
    wire: #{
      method: "PUT",
      path: "/{container}",
      uri: "{endpoint}",
      constants: #[#{ name: "restype", value: "container" }],
    },
    options: #[
      #{
        name: "Account",
        type: "string",
        required: true,
        description: "The name of the Azure Storage account. This is the unique name you chose for your storage account (e.g., 'mystorageaccount').",
      },
      #{
        name: "Container",
        type: "string",
        required: true,
        source: "container",
      },
      #{
        name: "Tenant",
        type: "string",
        required: false,
        descriptionMember: #{
          type: "Azure.Mcp.Core.Options.OptionDescriptions",
          member: "Tenant",
        },
      }
    ],
    binding: #{
      method: "CreateAsync",
      description: "Creates a private container using the existing Azure SDK.",
      returnType: "Azure.Storage.Blobs.BlobContainerClient",
      parameters: #[
        #{
          name: "serviceClient",
          type: "Azure.Storage.Blobs.BlobServiceClient",
          description: "The authenticated Storage SDK client.",
        },
        #{
          name: "container",
          type: "string",
          description: "The container name.",
        },
        #{
          name: "cancellationToken",
          type: "System.Threading.CancellationToken",
          description: "The cancellation token.",
        }
      ],
      calls: #[
        #{
          target: "serviceClient",
          method: "GetBlobContainerClient",
          arguments: #[#{ variable: "container" }],
          await: false,
          resultName: "client",
          resultType: "Azure.Storage.Blobs.BlobContainerClient",
        },
        #{
          target: "client",
          method: "CreateAsync",
          arguments: #[
            #{
              member: #{
                type: "Azure.Storage.Blobs.Models.PublicAccessType",
                member: "None",
              },
            },
            #{ variable: "cancellationToken", name: "cancellationToken" }
          ],
          await: true,
        }
      ],
      returnVariable: "client",
    },
    result: #[
      #{
        name: "Container",
        type: "Azure.Mcp.Tools.Storage.Models.ContainerInfo",
      }
    ],
    safety: #{
      destructive: true,
      idempotent: false,
      readOnly: false,
      openWorld: false,
    },
  })
  create(
    @doc("The name of the container to access within the storage account.")
    @path
    container: string,

    @query restype: "container",
  ): {
    @statusCode statusCode: 201;
  };

  /** Retrieves a container. The existing MCP get/list composition remains handwritten. */
  @get
  @route("/{container}")
  get(@path container: string, @query restype: "container"): void;
}
