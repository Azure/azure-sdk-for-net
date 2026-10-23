# Azure Provisioning Self Help client library for .NET

Azure.Provisioning.SelfHelp simplifies declarative resource provisioning for Azure Self Help in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.SelfHelp --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

## Key concepts

This library lets you describe Azure Self Help diagnostics, solutions, simplified solutions, and troubleshooters using .NET. Build an `Infrastructure` definition to generate Bicep for deployment to Azure.

Self Help resources use API version `2024-03-01-preview`. Extension resources target the deployment scope by default; set their `Scope` property to target another resource.

## Examples

### Create a diagnostic

Create a diagnostic at the deployment's resource group scope. Supply a diagnostic solution ID returned by the Self Help discovery solutions API when deploying the generated template.

```C# Snippet:SelfHelpBasic
Infrastructure infra = new();

ProvisioningParameter solutionId = new(nameof(solutionId), typeof(string))
{
    Description = "The diagnostic solution ID returned by the discovery solutions API.",
};
infra.Add(solutionId);

SelfHelpDiagnostic diagnostic =
    new(nameof(diagnostic), SelfHelpDiagnostic.ResourceVersions.V2024_03_01_PREVIEW)
    {
        Name = "diagnostic",
        Insights =
        {
            new SelfHelpDiagnosticInvocation
            {
                SolutionId = solutionId,
            },
        },
    };
infra.Add(diagnostic);

infra.Add(new ProvisioningOutput("diagnosticId", typeof(string)) { Value = diagnostic.Id });
```

## Troubleshooting

File issues via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).

## Next steps

See the [Azure Self Help documentation](https://learn.microsoft.com/rest/api/help/) for discovery solutions and diagnostic operations.

## Contributing

See the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).
