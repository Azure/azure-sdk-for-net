# JsonSchemaSegment Multi-Package Test

This test demonstrates how multiple NuGet packages can each ship a JSON Schema fragment via the MSBuild `JsonSchemaSegment` feature. Visual Studio merges all fragments from referenced packages into a single schema, providing IntelliSense for `appsettings.json`.

## What This Tests

The test simulates the Azure SDK package dependency chain:

```
ThirdPartyApp (console app)
├── PackageRef: TestBlob 1.0.0         → simulates Azure.Storage.Blobs
│   └── PackageRef: TestCore 1.0.0     → simulates Azure.Core
│       └── PackageRef: TestScm 1.0.0  → simulates System.ClientModel
├── PackageRef: TestIdentity 1.0.0     → simulates Azure.Identity
├── (optional) PackageRef: TestArm 1.0.0 → simulates Azure.ResourceManager
│   └── PackageRef: TestCore 1.0.0
├── (optional) PackageRef: TestOpenAI 1.0.0 → simulates OpenAI .NET SDK
│   └── PackageRef: TestScm 1.0.0
└── (optional) PackageRef: TestAzureOpenAI 1.0.0 → simulates Azure.AI.OpenAI
    ├── PackageRef: TestCore 1.0.0
    └── PackageRef: TestOpenAI 1.0.0
```

### What Each Package Ships

| Package | Simulates | Schema Content |
|---------|-----------|---------------|
| **TestScm** | System.ClientModel | `ClientSdk` section with `credential` (ApiKeyCredential only), pipeline `options`, `clientLoggingOptions` definitions |
| **TestCore** | Azure.Core | `AzureSdk` section with `retry`, `diagnostics`, `azureOptions` definitions |
| **TestIdentity** | Azure.Identity | `credential` definition with 13 credential types + conditional properties per type |
| **TestBlob** | Azure.Storage.Blobs | `BlobServiceClient` well-known name under `AzureSdk`, extends `azureOptions` with `EnableTenantDiscovery` |
| **TestArm** | Azure.ResourceManager | `ArmClient` well-known name under `AzureSdk`, extends `azureOptions` with `AuxiliaryTenantIds` |
| **TestOpenAI** | OpenAI .NET SDK | `ChatClient` well-known name under `ClientSdk` with `Model` (extensible enum), `openAIOptions` (Endpoint, OrganizationId, ProjectId, UserAgentApplicationId). Uses shared `credential` definition — `ApiKeyCredential` only by default, enriched with all credential types when TestIdentity is present. |
| **TestAzureOpenAI** | Azure.AI.OpenAI | `ChatClient` well-known name under `AzureSdk` with same `Model` + `openAIOptions`, but uses full Azure.Identity `credential` (all 13 types) and Azure.Core `azureOptions` |

### Key Design Points

- **Cross-package `#/definitions/` references**: TestBlob uses `$ref: "#/definitions/credential"` which resolves to TestIdentity's definition after VS merges all segments.
- **`allOf` extension**: TestBlob/TestArm extend TestCore's `azureOptions` with client-specific properties using `allOf`.
- **Package isolation**: `ArmClient` IntelliSense only appears when TestArm is referenced. Unreferenced packages don't contribute schema.
- **Transitive segments**: TestScm flows through TestCore → TestBlob → ThirdPartyApp (3 levels deep).
- **Shared `.targets` pattern**: Each package ships a simple `.targets` file (identical pattern) and `ConfigurationSchema.json` via `buildTransitive/`. The packing logic lives in `Directory.Build.targets`.

## Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 17.9+ (JsonSchemaSegment is a VS-only feature, no VS Code support)

## Setup

1. **Pack the NuGet packages** (must be done in dependency order):

```powershell
cd <path-to-this-folder>

# Create local package feed
New-Item -ItemType Directory -Path C:\local-packages -Force

# Pack in dependency order
dotnet pack TestScm\TestScm.csproj -o C:\local-packages -c Release
dotnet pack TestIdentity\TestIdentity.csproj -o C:\local-packages -c Release
dotnet restore TestCore\TestCore.csproj --force
dotnet pack TestCore\TestCore.csproj -o C:\local-packages -c Release
dotnet restore TestBlob\TestBlob.csproj --force
dotnet pack TestBlob\TestBlob.csproj -o C:\local-packages -c Release
dotnet restore TestArm\TestArm.csproj --force
dotnet pack TestArm\TestArm.csproj -o C:\local-packages -c Release
dotnet restore TestOpenAI\TestOpenAI.csproj --force
dotnet pack TestOpenAI\TestOpenAI.csproj -o C:\local-packages -c Release
dotnet restore TestAzureOpenAI\TestAzureOpenAI.csproj --force
dotnet pack TestAzureOpenAI\TestAzureOpenAI.csproj -o C:\local-packages -c Release
```

2. **Restore and build ThirdPartyApp**:

```powershell
cd ThirdPartyApp
dotnet restore --force
dotnet build
```

3. **Open `SegmentTest.sln` in Visual Studio** and open `ThirdPartyApp\appsettings.json`.

## What to Verify

### IntelliSense (with default refs: TestBlob + TestIdentity)

1. **`AzureSdk` section** — type `"AzureSdk": { }` and trigger IntelliSense inside
   - `BlobServiceClient` should appear (from TestBlob)
   - `ArmClient` should **NOT** appear (TestArm not referenced)
   - Any other key should show `Credential` + `Options` fallback (from TestCore's `additionalProperties`)

2. **`BlobServiceClient` → `Credential`** — set `"CredentialSource": "AzureCli"` then trigger IntelliSense
   - Should show `TenantId`, `Subscription`, `ProcessTimeout`, `AdditionallyAllowedTenants` (conditional properties from TestIdentity)

3. **`BlobServiceClient` → `Options`** — trigger IntelliSense inside
   - Should show `Retry` + `Diagnostics` (from TestCore's `azureOptions` via `allOf`)
   - Should show `EnableTenantDiscovery` (Blob-specific extension)

4. **`ClientSdk` section** — type `"ClientSdk": { "MyClient": { } }` and trigger IntelliSense
   - Should show `Credential` + `Options` (from TestScm, 3 levels transitive)
   - `Credential` → `CredentialSource` should show all credential types (shared `credential` definition is enriched by TestIdentity)

### OpenAI Test (add TestOpenAI + TestAzureOpenAI refs to ThirdPartyApp)

1. Add `<PackageReference Include="TestOpenAI" Version="1.0.0" />` and `<PackageReference Include="TestAzureOpenAI" Version="1.0.0" />` to ThirdPartyApp.csproj
2. Run `dotnet restore --force`, close and reopen the solution in VS

3. **`ClientSdk` → `ChatClient`** — should show `Model` (extensible enum with gpt-4o, gpt-4.1, etc.), `Credential`, `Options`
   - `Credential` → `CredentialSource` should show all credential types (shared `credential` definition merged from TestScm + TestIdentity)
   - `Options` should show both SCM pipeline options (NetworkTimeout, etc.) and OpenAI-specific options (Endpoint, OrganizationId, ProjectId, UserAgentApplicationId)

4. **`AzureSdk` → `ChatClient`** — should show same `Model` + `Options`, but:
   - `Credential` → `CredentialSource` should show all 13 Azure.Identity credential types
   - `Options` should show Azure options (Retry, Diagnostics) plus OpenAI-specific options (Endpoint, OrganizationId, ProjectId, UserAgentApplicationId)

### Package Isolation Test

1. Uncomment `<PackageReference Include="TestArm" Version="1.0.0" />` in `ThirdPartyApp.csproj`
2. Run `dotnet restore --force` in ThirdPartyApp
3. Close and reopen the solution in VS
4. `ArmClient` should now appear under `AzureSdk`
5. `ArmClient` → `Options` should show `Retry`, `Diagnostics`, and `AuxiliaryTenantIds`

## Repack After Schema Changes

If you modify any `ConfigurationSchema.json`, you need to repack:

```powershell
# Clear NuGet cache for affected package (e.g., TestBlob)
Remove-Item "$env:USERPROFILE\.nuget\packages\testblob" -Recurse -Force -ErrorAction SilentlyContinue
# Or if your cache is at C:\Nuget:
Remove-Item "C:\Nuget\testblob" -Recurse -Force -ErrorAction SilentlyContinue

# Remove old nupkg
Remove-Item C:\local-packages\TestBlob.1.0.0.nupkg -Force

# Repack
dotnet pack TestBlob\TestBlob.csproj -o C:\local-packages -c Release

# Re-restore ThirdPartyApp
cd ThirdPartyApp
dotnet restore --force
```

Then close and reopen the solution in VS to clear its schema cache.

## How JsonSchemaSegment Works

Each NuGet package ships two things:
1. `ConfigurationSchema.json` — the JSON Schema fragment (at package root)
2. `{PackageId}.targets` — a `.targets` file in `buildTransitive/{tfm}/` that registers the schema:

```xml
<Project>
  <ItemGroup>
    <JsonSchemaSegment Include="$(MSBuildThisFileDirectory)..\..\ConfigurationSchema.json"
                       FilePathPattern="appsettings\..*json" />
  </ItemGroup>
</Project>
```

When a project references the NuGet package (directly or transitively), MSBuild imports the `.targets` file, which adds a `JsonSchemaSegment` item. Visual Studio collects ALL `JsonSchemaSegment` items and merges them into a single schema document. This merged schema is used for IntelliSense in files matching the `FilePathPattern` regex.

### Limitations

- **VS-only** — VS Code does not support `JsonSchemaSegment` (yet)
- **No external `$ref`** — relative file paths and HTTP URLs in `$ref` do not resolve. Only internal `#/definitions/...` references work (which resolve after VS merges all segments into one document).
- **Schema cache** — VS caches the merged schema. After repacking, close and reopen the solution.
