param(
    [Parameter(Mandatory)]
    [string] $Region,

    [Parameter(Mandatory)]
    [string] $ResourceGroup,
    
    [Parameter(Mandatory)]
    [string] $SubscriptionId,

    [Parameter()]
    [string] $DigitalTwinName,

    [Parameter()]
    [string] $AppRegistrationName,

    [Parameter()]
    [string] $EventHubName
)

Function Connect-AzureSubscription()
{
    # Ensure the user is logged in
    try
    {
        $azureContext = az account show
    }
    catch { }

    if (-not $azureContext)
    {
        Write-Host "`nPlease login to Azure..."
        az login
        $azureContext = az account show
    }

    # Ensure the desired subscription is selected
    $sub = az account show --output tsv --query id
    if ($sub -ne $SubscriptionId)
    {
        Write-Host "`nSelecting subscription $SubscriptionId"
        az account set --subscription $SubscriptionId
    }

    return $azureContext
}

$isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")
if (-not $isAdmin)
{
    throw "This script must be run in administrative mode."
}

Connect-AzureSubscription

$Region = $Region.Replace(' ', '')

if (-not $DigitalTwinName)
{
    $DigitalTwinName = $ResourceGroup
}

if (-not $EventHubName)
{
    $EventHubName = $ResourceGroup
}

if (-not $AppRegistrationName)
{
    $AppRegistrationName = $ResourceGroup
}

$pathToManifest = "$PSScriptRoot\manifest.json"

$appId = az ad app list --show-mine --query "[?displayName=='$AppRegistrationName'].appId" --output tsv
if (-not $appId)
{
    Write-Host "`nCreating App Registration $AppRegistrationName`n"
    $appId = az ad app create --display-name $AppRegistrationName --native-app --required-resource-accesses $pathToManifest --query 'appId' --output tsv
}

$spExists = az ad sp list --show-mine --query "[?appId=='$appId'].appId" --output tsv
if (-not $spExists)
{
    Write-Host "`nCreating service principal for app $appId`n"
    az ad sp create --id $appId --output none
}

$rgExists = az group exists --name $ResourceGroup
if ($rgExists -eq "False")
{
    Write-Host "`nCreating Resource Group $ResourceGroup in $Region`n"
    az group create --name $ResourceGroup --location $Region --output none
}

$dtExists = az dt list -g $ResourceGroup --query "[?name=='$DigitalTwinName']" --output tsv --only-show-errors
if (-not $dtExists)
{
    Write-Host "`nCreating Digital Twin $DigitalTwinName`n"
    az dt create -n $DigitalTwinName -g $ResourceGroup --location $Region --output none --only-show-errors
}
$dtHostName = az dt show -n $DigitalTwinName -g $ResourceGroup --query 'hostName' --output tsv --only-show-errors

# The Service Principal takes a while to get propogated and if a different endpoint is hit before that, trying to grant a permission will fail.
# Adding retries so that we can grant the permissions successfully without re-running the script.
Write-Host "Assigning owner role to $appId for $DigitalTwinName`n"
$tries = 0;
while (++$tries -le 10)
{
    try
    {
        az dt rbac assign-role --assignee $appId --role owner -n $DigitalTwinName --output none --only-show-errors

        if ($LastExitCode -eq 0)
        {
            Write-Host "`tSucceeded"
            break
        }
    }
    catch { }

    if ($tries -ge 10)
    {
        Write-Error "Max retries reached for granting service principal permissions."
        throw
    }

    Write-Host "`tGranting service principal permission failed. Waiting 5 seconds before retry..."
    Start-Sleep -s 5;
}

Write-Host("Set a new client secret for $appId`n")
$appSecret = az ad app credential reset --id $appId --years 2 --query 'password' --output tsv

# Create an eventhub namespace and an eventhub in that namespace to serve as an endpoint for the digital twins instance to use for tests
$eventHubNamespaceExists = az eventhubs namespace list -g $ResourceGroup --query "[?name=='$EventHubName']" --output tsv
if (-not $eventHubNamespaceExists)
{
    Write-Host "`nCreating Event Hub Namespace $EventHubName`n"
    az eventhubs namespace create --name $EventHubName -g $ResourceGroup -l $Region --output none
}
else
{
    Write-Host "Skipping creating the eventhub namespace as it already exists"
}

$eventHubExists = az eventhubs eventhub list --namespace-name $EventHubName -g $ResourceGroup --query "[?name=='$EventHubName']" --output tsv
if (-not $eventHubExists) {
    Write-Host "`nCreating Event Hub $EventHubName`n"
    az eventhubs eventhub create --name $EventHubName -g $ResourceGroup --namespace-name $EventHubName --output none
}
else {
    Write-Host "Skipping creating the eventhub as it already exists"
}

$Policy = "owner"
$policyExists = az eventhubs eventhub authorization-rule list -g $ResourceGroup --namespace-name $EventHubName --eventhub-name $EventHubName --query "[?name=='$Policy']" --output tsv
if (-not $policyExists)
{
    Write-Host "`nCreating Event Hub Policy $Policy`n"
    az eventhubs eventhub authorization-rule create -g $ResourceGroup --namespace-name $EventHubName --eventhub-name $EventHubName --name $Policy --rights Manage Send Listen
}
else
{
    Write-Host "Skipping creating the owner policy as it already exists"
}

# Link the eventhub to the digital twins instance as a dedicated endpoint

$endpointName = "someEventHubEndpoint"
$endpointLinkExists = az dt endpoint list -g $ResourceGroup --dt-name $DigitalTwinName --query "[?name=='$endpointName']" --output tsv --only-show-errors
if (-not $endpointLinkExists)
{
    Write-Host "`nConnecting Event Hub Endpoint to Digital Twin instance`n"
    az dt endpoint create eventhub --endpoint-name $endpointName --subscription $SubscriptionId --eventhub $EventHubName --eventhub-namespace $EventHubName --eventhub-resource-group $ResourceGroup --dt-name $DigitalTwinName --eventhub-policy $Policy --only-show-errors
}
else
{
    Write-Host "Skipping linking the event hub to the digital twin instance as it is already linked"
}

$user = $env:UserName
$fileName = "$user.config.json"
Write-Host("Writing user config file - $fileName`n")
$appSecretJsonEscaped = ConvertTo-Json $appSecret
$config = @"
{
    "DigitalTwinsInstanceHostName": "https://$($dtHostName)",
    "ApplicationId": "$appId",
    "ClientSecret": $appSecretJsonEscaped,
    "TestMode":  "Live"
}
"@
$config | Out-File "$PSScriptRoot\..\config\$fileName"

$userSettingsFileSuffix = ".test.assets.config.json"
$userSettingsFileName = "$user$userSettingsFileSuffix"
$userTestAssetSettingsFileName = "$PSScriptRoot\..\config\$userSettingsFileName"
if (-not (Test-Path $userTestAssetSettingsFileName))
{
    Write-Host "Creating empty user test assets config file - $userSettingsFileName`n"
    New-Item -ItemType File -Path $userTestAssetSettingsFileName -Value "{}" | Out-Null
}

Write-Host "Done!"
