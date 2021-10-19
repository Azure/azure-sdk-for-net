<#
.SYNOPSIS
  Record live values for CosmosDB's .NET SDK tests.
.DESCRIPTION
  Usually when running the .NET SDK's tests, they use prerecorded responses
  to HTTP requests instead of hitting the live system, which makes the tests
  run locally and much, much faster.

  When the .NET SDK is updated, we have to record new values. This script
  sets up the necessary service principals and environment variables, then
  runs the tests to record new values.
.PARAMETER <SubscriptionId>
    The id of the subscription the tests should create and modify resources in.
.INPUTS
  None
.OUTPUTS
  New recorded sessions in the tests/SessionRecords/ directory.
.EXAMPLE
  cd <SDK path>/sdk/cosmosdb/Microsoft.Azure.Management.CosmosDB
  ./RecordTests.ps1 -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
                                    
#>
param(
    [Parameter(Mandatory=$true, HelpMessage="The id of the subscription the tests should create and modify resources in.")]
    [ValidateScript({[System.Guid]::TryParse($_, [System.Management.Automation.PSReference][System.Guid]::empty)})]
    [string]$SubscriptionId
)

$ServicePrincipalName = "CosmosDBDotNetSDKTestRecorder"

az login
az account set --subscription $SubscriptionId

# Patches the existing service principal if it exists, and sets a new secret.
$ServicePrincipal = az ad sp create-for-rbac --name $ServicePrincipalName --role Contributor | ConvertFrom-Json

$ServicePrincipalId = $ServicePrincipal.appId
$Password = $ServicePrincipal.password
$TenantId = $ServicePrincipal.tenant

$env:TEST_CSM_ORGID_AUTHENTICATION = "SubscriptionId=$SubscriptionId;ServicePrincipal=$ServicePrincipalId;ServicePrincipalSecret=$Password;AADTenant=$TenantId;Environment=Prod;HttpRecorderMode=Record;"
$env:AZURE_TEST_MODE = "Record"

$SdkRoot = git rev-parse --show-toplevel
$TestProject = "$SdkRoot/sdk/cosmosdb/Microsoft.Azure.Management.CosmosDB/tests/Microsoft.Azure.Management.CosmosDB.Tests.csproj"

dotnet build $TestProject
dotnet test $TestProject

