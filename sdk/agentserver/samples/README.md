# Build & Push Sample Images
TODO: see agentop guide

# FAQs

## How do I get access to nightly builds?

Builds of the Container Agents are available [here](https://github.com/orgs/microsoft/packages?repo_name=container_agents).

To download builds follow the following steps:

1. You will need a GitHub account to complete these steps.
1. Create a GitHub Personal Access Token with the `read:packages` scope using these [instructions](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic).
1. If your account is part of the Microsoft organization then you must authorize the `Microsoft` organization as a single sign-on organization.
    1. Click the "Configure SSO" next to the Personal Access Token you just created and then authorize `Microsoft`.
1. Use the following command to add the Microsoft GitHub Packages source to your NuGet configuration:

    ```powershell
    dotnet nuget add source --username GITHUBUSERNAME --password GITHUBPERSONALACCESSTOKEN --store-password-in-clear-text --name github "https://nuget.pkg.github.com/microsoft/index.json"
    ```

1. Or you can manually create a `NuGet.Config` in your local per-user config file: ` ~/.nuget/NuGet/NuGet.Config`. **DO NOT** check in your token to repo!

    ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <packageSources>
        <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
        <add key="github" value="https://nuget.pkg.github.com/microsoft/index.json" />
      </packageSources>

      <packageSourceCredentials>
        <github>
            <add key="Username" value="<Your GitHub Id>" />
            <add key="ClearTextPassword" value="<Your Personal Access Token>" />
          </github>
      </packageSourceCredentials>
    </configuration>
    ```

1. You can now add packages from the nightly build to your project.
    * E.g. use this command `dotnet add package Microsoft.AIFoundry.ContainerAgents.Adapters.AgentFramework --version 0.0.1-nightly.20250905.30`
1. And the latest package release can be referenced in the project like this:
    * `<PackageReference Include="Microsoft.AIFoundry.ContainerAgents.Adapters.AgentFramework" Version="*-*" />`

For more information see: <https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry>
