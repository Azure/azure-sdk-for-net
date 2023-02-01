```mermaid
%% STEPS TO GENERATE IMAGE
%% =======================
%% 1. Install mermaid CLI (see https://github.com/mermaid-js/mermaid-cli/blob/master/README.md)
%% 2. Run command: mmdc -i DefaultAzureCredentialAuthFlow.md -o DefaultAzureCredentialAuthFlow.svg

flowchart LR;
    A(Environment):::deployed ==> B(Managed Identity):::deployed ==> C(Azure Developer CLI):::developer ==> D(Visual Studio):::developer ==> E(VS Code):::developer ==> F(Azure CLI):::developer ==> G(Azure PowerShell):::developer ==> H(Interactive browser):::interactive;

    subgraph CREDENTIAL TYPES;
        direction LR;
        Deployed(Deployed service):::deployed ==> Developer(Developer):::developer ==> Interactive(Interactive developer):::interactive;

        %% Hide links between boxes in the legend by setting width to 0. The integers after "linkStyle" represent link indices.
        linkStyle 7 stroke-width:0px;
        linkStyle 8 stroke-width:0px;
    end;

    %% Define styles for credential type boxes
    classDef deployed fill:#95C37E, stroke:#71AD4C;
    classDef developer fill:#F5AF6F, stroke:#EB7C39;
    classDef interactive fill:#A5A5A5, stroke:#828282;

    %% Add API ref links to credential type boxes
    click A "https://learn.microsoft.com/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet" _blank;
    click B "https://learn.microsoft.com/dotnet/api/azure.identity.managedidentitycredential?view=azure-dotnet" _blank;
    click D "https://learn.microsoft.com/dotnet/api/azure.identity.visualstudiocredential?view=azure-dotnet" _blank;
    click E "https://learn.microsoft.com/dotnet/api/azure.identity.visualstudiocodecredential?view=azure-dotnet" _blank;
    click F "https://learn.microsoft.com/dotnet/api/azure.identity.azureclicredential?view=azure-dotnet" _blank;
    click G "https://learn.microsoft.com/dotnet/api/azure.identity.azurepowershellcredential?view=azure-dotnet" _blank;
    click H "https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet" _blank;
```
