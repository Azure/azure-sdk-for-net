param(
    [Parameter(Mandatory)]
    [string] $Region,

    [Parameter(Mandatory)]
    [string] $ResourceGroup,
    
    [Parameter(Mandatory)]
    [string] $SubscriptionId,

    [Parameter()]
    [string] $IotHubName,

    [Parameter()]
    [string] $AppRegistrationName
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

if (-not $IotHubName)
{
    $IotHubName = $ResourceGroup
}

if (-not $AppRegistrationName)
{
    $AppRegistrationName = $ResourceGroup
}

$appId = az ad app list --show-mine --query "[?displayName=='$AppRegistrationName'].appId" --output tsv
if (-not $appId)
{
    Write-Host "`nCreating App Registration $AppRegistrationName`n"
    $appId = az ad app create --display-name $AppRegistrationName --native-app --query 'appId' --output tsv
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

$hubExists = az iot hub list -g $ResourceGroup --query "[?name=='$IotHubName']" --output tsv --only-show-errors
if (-not $hubExists)
{
    Write-Host "`nCreating IoT Hub $IotHubName`n"
    az iot hub create -n $IotHubName -g $ResourceGroup --location $Region --output none --only-show-errors
}
$iotHubHostName = az iot hub show -n $IotHubName -g $ResourceGroup --query 'properties.hostName' --output tsv --only-show-errors

Write-Host("Set a new client secret for $appId`n")
$appSecret = az ad app credential reset --id $appId --years 2 --query 'password' --output tsv

$user = $env:UserName
$fileName = "$user.config.json"
Write-Host("Writing user config file - $fileName`n")
$appSecretJsonEscaped = ConvertTo-Json $appSecret
$config = @"
{
    "IotHubHostName": "https://$($iotHubHostName)",
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
