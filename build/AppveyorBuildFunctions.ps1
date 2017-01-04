function Build-Solution
{
    Write-Host "Building Service Bus projects"

    dotnet restore  
    dotnet build src/Microsoft.Azure.ServiceBus/project.json
    dotnet build test/Microsoft.Azure.ServiceBus.UnitTests/project.json
    
    Write-Host "Building complete"
}

function Add-StrongNameEntry
{
    &'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\x64\sn.exe' -Vr *,*
}

function Deploy-AzureResources
{
    if ([bool]$env:ClientSecret `
        -and [bool]$env:TenantId `
        -and [bool]$env:AppId `
        -and [bool]$env:APPVEYOR_BUILD_NUMBER)
    {
        Write-Host "Creating Azure resources"

        $ErrorActionPreference = 'Stop'
        Enable-AzureDataCollection -WarningAction SilentlyContinue | Out-Null
        $BuildVersion = ($env:APPVEYOR_BUILD_NUMBER).Replace(".", "")
    
        $env:ResourceGroupName = "sb-dotnet-av-$BuildVersion-rg"
        $NamespaceName = "sb-dotnet-av-$BuildVersion-ns"
        $Location = 'westus'

        $Password = ConvertTo-SecureString -AsPlainText -Force $env:ClientSecret
        $Credentials = New-Object `
            -TypeName System.Management.Automation.PSCredential `
            -ArgumentList $env:AppId, $Password

        # https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-authenticate-service-principal
        Add-AzureRmAccount -Credential $Credentials -ServicePrincipal -TenantId $env:TenantId | Out-Null
 
        $ResourceGroup = New-AzureRmResourceGroup -Name $env:ResourceGroupName -Location $Location -Force -WarningAction SilentlyContinue
        Write-Host ("Resource group name: " + $ResourceGroup.ResourceGroupName)

        $ArmParameters = @{
            serviceBusNamespaceName = $NamespaceName;
        }

        $TemplatePath = "$((Get-Location).path)\templates\azuredeploy.json"
    
        $settings = New-AzureRmResourceGroupDeployment `
           -ResourceGroupName $env:ResourceGroupName `
           -TemplateFile $TemplatePath `
           -TemplateParameterObject $ArmParameters `
           -Force `
           -WarningAction SilentlyContinue

        Write-Host "Service Bus namespace: $NamespaceName"
        
        $ConnectionString = $settings.Outputs.Get_Item("namespaceConnectionString").Value
        [Environment]::SetEnvironmentVariable('azure-service-bus-dotnet/connectionstring', $ConnectionString)

        Write-Host "Completed creating Azure resources"
    }
    else
    {
        Write-Host "No environment variables present. Skipping Azure deployment."
    }

    # Useful for debugging ARM deployments
    # Get-AzureRmLog -CorrelationId "GUID" -DetailedOutput
}

function Run-UnitTests
{
    if ([bool][Environment]::GetEnvironmentVariable('azure-service-bus-dotnet/connectionstring'))
    {
        Write-Host "Running unit tests."

        dotnet test test/Microsoft.Azure.ServiceBus.UnitTests/project.json
    }
    else
    {
        Write-Host "No environment variables present. Skipping unit tests."
    }
}

function Delete-AzureResources
{
    if ([bool]$env:ClientSecret -and [bool]$env:AppId)
    {
        Write-Host "Deleting Azure resources"

        $ErrorActionPreference = 'Stop'
    
        $Password = ConvertTo-SecureString -AsPlainText -Force $env:ClientSecret
        $Credentials = New-Object `
            -TypeName System.Management.Automation.PSCredential `
            -ArgumentList $env:AppId, $Password

        Remove-AzureRmResourceGroup -Name $env:ResourceGroupName -WarningAction SilentlyContinue -Force | Out-Null

        Write-Host "Completed deleting Azure resources"
    }
    else
    {
        Write-Host "No environment variables present. Skipping Azure resource deletion"
    }
}