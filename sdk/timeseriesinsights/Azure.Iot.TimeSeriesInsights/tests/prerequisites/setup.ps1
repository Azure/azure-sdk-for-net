# This script is used to create the necessary resources required to run the unit/E2E tests

param(
    [Parameter(Mandatory)]
    [string] $Region,

    [Parameter(Mandatory)]
    [string] $ResourceGroup,

    [Parameter(Mandatory)]
    [string] $SubscriptionId,

    [Parameter(Mandatory)]
    [string[]] $TimeSeriesIds,

    [Parameter(Mandatory)]
    [ValidateLength(6, 50)]
    [string] $EnvironmentName,

    [Parameter(Mandatory)]
    [string] $ConsumerGroupName,

    [Parameter(Mandatory)]
    [string] $Timestamp
)

Function Connect-AzureSubscription
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

$sp = az ad sp list --show-mine --query "[?appId=='$appId'].appId" --output tsv
if (-not $sp)
{
    Write-Host "`nCreating service principal for app $appId`n"
    az ad sp create --id $appId --output none
}

# Get test application OID from the service principal
$applicationOId = az ad sp show --id $appId --query "objectId" --output tsv

$rgExists = az group exists --name $ResourceGroup
if ($rgExists -eq "False")
{
    Write-Host "`nCreating Resource Group $ResourceGroup in $Region`n"
    az group create --name $ResourceGroup --location $Region --output none
}

Write-Host "`nDeploying resources to $ResourceGroup in $Region`n"

$armTemplateFile = Join-Path -Path $PSScriptRoot -ChildPath "../../../test-resources.json";

if (-not (Test-Path $armTemplateFile -PathType leaf))
{
    throw "`nARM template was not found. Please make sure you have an ARM template file named test-resources.json in the root of the service directory`n"
}

# Format the Id properties before deployment
$tsIDArray = @()
foreach( $id in $TimeSeriesIds)
{
    $tsId = [pscustomobject]@{name=$id;type='string'}
    $tsIDArray += $tsId
}

$timeSeriesIdProperties = $tsIDArray | ConvertTo-Json -Compress
$timeSeriesIdProperties = $timeSeriesIdProperties.Replace('"','\"')

# Deploy test-resources.json ARM template.
az deployment group create --resource-group $ResourceGroup --name $($EnvironmentName.ToLower()) --template-file $armTemplateFile --parameters `
    region=$Region `
    resourceGroup=$ResourceGroup `
    environmentName=$EnvironmentName `
    iotHubName=$($EnvironmentName + "-hub") `
    consumerGroupName=$ConsumerGroupName `
    environmentTimeSeriesIdProperties=$timeSeriesIdProperties `
    eventSourceName=$($EnvironmentName + "EventSource") `
    eventSourceTimestampPropertyName=$eventSourceTimestampPropertyName `
    testApplicationOid=$applicationOId

# Even though the output variable names are all capital letters in the script, ARM turns them into a strange casing
# and we have to use that casing in order to get them from the deployment outputs.
$dataAccessFqdn = az deployment group show -g $ResourceGroup -n $($EnvironmentName.ToLower()) --query 'properties.outputs.TIMESERIESINSIGHTS_URL.value' --output tsv

Write-Host("`nSet a new client secret for $appId`n")
$appSecret = az ad app credential reset --id $appId --years 2 --query 'password' --output tsv

$user = $env:UserName
$fileName = "$user.config.json"
Write-Host("`nWriting user config file - $fileName`n")

$config = @"
{
    "TestMode": "Live"	
}
"@

$config | Out-File "$PSScriptRoot\..\config\$fileName"

$outputfileDir = (Get-Item -Path $PSScriptRoot).Parent.Parent.Parent.Fullname
$outputFile = Join-Path -Path $outputfileDir -ChildPath "test-resources.json.env"
$tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47"

Add-Type -AssemblyName System.Security

$appSecretJsonEscaped = ConvertTo-Json $appSecret
$environmentText = @"
{
    "TIMESERIESINSIGHTS_URL": "$dataAccessFqdn",
    "TIMESERIESINSIGHTS_CLIENT_ID": "$appId",
    "TIMESERIESINSIGHTS_CLIENT_SECRET": $appSecretJsonEscaped,
    "TIMESERIESINSIGHTS_TENANT_ID": "$tenantId"
}
"@

Write-Host "`nEnvironment variables set, this will now be encrypted. Copy these values for future reference.`n"
Write-Host "`n$environmentText`n"

$bytes = ([System.Text.Encoding]::UTF8).GetBytes($environmentText)
$protectedBytes = [Security.Cryptography.ProtectedData]::Protect($bytes, $null, [Security.Cryptography.DataProtectionScope]::CurrentUser)
Set-Content $outputFile -Value $protectedBytes -AsByteStream -Force
Write-Host "`nTest environment settings stored into encrypted $outputFile`n"

Write-Host "Done!"
