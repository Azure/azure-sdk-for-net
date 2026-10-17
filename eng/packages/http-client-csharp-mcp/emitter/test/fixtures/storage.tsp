import "./specification/storage/data-plane/BlobStorage/main.tsp";

using Azure.Mcp;

@@mcpService(
  Storage.Blob,
  #{
    outputNamespace: "Azure.Mcp.Tools.Storage.GeneratedMcp",
    metadataReferences: #[
      "src/bin/Debug/net10.0/Microsoft.Mcp.Core.dll",
      "src/bin/Debug/net10.0/Azure.Mcp.Core.dll"
    ],
  }
);

@@command(
  Storage.Blob.Container.create,
  #{
    id: "f5088334-e630-4df0-a5be-ac87787acad0",
    path: "storage blob container create",
    title: "Create Storage Blob Container",
    commandType: "Azure.Mcp.Tools.Storage.Commands.Blob.Container.ContainerCreateCommand",
    handler: #{
      type: "Azure.Mcp.Tools.Storage.Services.IStorageService",
      member: "CreateContainer",
    },
    resultName: "Container",
    description: #{
      type: "Azure.Mcp.Tools.Storage.Commands.Blob.Container.ContainerCreateCustomization",
      member: "Description",
    },
    errorPolicy: #{
      type: "Azure.Mcp.Tools.Storage.Commands.Blob.Container.ContainerCreateCustomization",
      member: "GetErrorMessage",
    },
    errorMessage: "Storage request failed (HTTP {0}): {1}",
    options: #[
      #{
        name: "account",
        description: "The name of the Azure Storage account. This is the unique name you chose for your storage account (e.g., 'mystorageaccount').",
      },
      #{
        name: "container",
        description: "The name of the container to access within the storage account.",
      },
      #{
        name: "tenant",
        descriptionMember: #{
          type: "Azure.Mcp.Core.Options.OptionDescriptions",
          member: "Tenant",
        },
      }
    ],
    safety: #{
      destructive: true,
      idempotent: false,
      readOnly: false,
      openWorld: false,
    },
  }
);
