# Checked-in preview NuGet packages (the .NET "package drop")

This directory ships the `Azure.AI.AgentServer.*` packages as locally-built
`.nupkg` files so samples (and downstream repos) can consume the **unreleased
preview** resilient + steerable surface **without** a `ProjectReference` into
this repo and **without** waiting for the packages to publish to nuget.org.

It is the .NET analogue of the Python demo's checked-in wheels
(`sdk/agentserver/wheels/*.whl`).

| Package | Version | Source project |
|---------|---------|----------------|
| `Azure.AI.AgentServer.Core` | `1.0.0-beta.27` | `sdk/agentserver/Azure.AI.AgentServer.Core` |
| `Azure.AI.AgentServer.Responses` | `1.0.0-beta.7` | `sdk/agentserver/Azure.AI.AgentServer.Responses` |
| `Azure.AI.AgentServer.Invocations` | `1.0.0-beta.6` | `sdk/agentserver/Azure.AI.AgentServer.Invocations` |

`Azure.AI.AgentServer.Responses` and `Azure.AI.AgentServer.Invocations` each depend
on `Azure.AI.AgentServer.Core`, so Core must be present in the feed alongside
whichever protocol host a sample consumes.

## Consumption (a local NuGet feed)

A consuming project references these packages by version and restores them from a
local folder registered as a NuGet source via a `nuget.config`:

```xml
<!-- nuget.config next to the consuming .csproj -->
<configuration>
  <packageSources>
    <add key="agentserver-local" value="./packages" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
```

```xml
<!-- .csproj -->
<PackageReference Include="Azure.AI.AgentServer.Responses" Version="1.0.0-beta.7" />
<!-- Core is pulled transitively; pin it too if you use Core types directly:
<PackageReference Include="Azure.AI.AgentServer.Core" Version="1.0.0-beta.27" /> -->
```

The `resilient-responses-agent-demo/build.sh` copies these `.nupkg` files into
the sample's docker build context (`src/.../packages/`, gitignored). The sample's
`Dockerfile` then `dotnet restore`s against them using the sample's `nuget.config`.

**Devs do NOT need to rebuild these — they're checked in.**

## Using this drop in another repo

1. Copy the `.nupkg` files from this directory into a `packages/` folder in your
   repo (or reference this folder directly).
2. Add a `nuget.config` with a `packageSources` entry pointing at that folder
   (see above).
3. Add the `PackageReference`(s) at the versions in the table above.

When the packages publish to nuget.org, delete the local source and the packages
resolve from nuget.org with no other change.

## Refreshing (maintainer-only)

After source changes to Core or Responses, run:

```bash
sdk/agentserver/packages/build-packages.sh
git add sdk/agentserver/packages/*.nupkg
git commit
```

The script removes stale `*.nupkg` files and rebuilds at the `<Version>` in each
package's `.csproj`, passing `-p:SkipDevBuildNumber=true` so the drop ships the
real `beta` version (no `-alpha.<date>` dev suffix) and `Responses` records the
correct `Core` dependency version. No version bump is needed for unreleased
`betaN` previews — the same filename is overwritten with the new content.
