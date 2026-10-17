import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "./routes.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;

@useAuth(
  OAuth2Auth<[
    {
      type: OAuth2FlowType.implicit,
      authorizationUrl: "https://login.microsoftonline.com/common/oauth2/authorize",
      scopes: ["https://storage.azure.com/.default"],
    }
  ]>
)
@service(#{ title: "Azure Storage Blob service" })
@server(
  "{url}",
  "The host name of the blob storage account, e.g. accountName.blob.core.windows.net",
  {
    @doc("The host name of the blob storage account, e.g. accountName.blob.core.windows.net")
    url: url,
  }
)
@versioned(Versions)
namespace Storage.Blob;

#suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Following standard typespec recommendation"
#suppress "@azure-tools/typespec-azure-core/no-enum" "Following standard typespec recommendation"
@doc("The Azure.Storage.Blob service versions.")
enum Versions {
  @doc("The 2025-11-05 version of the Azure.Storage.Blob service.")
  v2025_11_05: "2025-11-05",

  @doc("The 2026-02-06 version of the Azure.Storage.Blob service.")
  v2026_02_06: "2026-02-06",

  @doc("The 2026-04-06 version of the Azure.Storage.Blob service.")
  v2026_04_06: "2026-04-06",

  @doc("The 2026-06-06 version of the Azure.Storage.Blob service.")
  v2026_06_06: "2026-06-06",

  @doc("The 2026-10-06 version of the Azure.Storage.Blob service.")
  v2026_10_06: "2026-10-06",

  @doc("The 2026-12-06 version of the Azure.Storage.Blob service.")
  v2026_12_06: "2026-12-06",
}
