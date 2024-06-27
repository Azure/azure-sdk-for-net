[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage='Project name to use in the request uri')]
    [string]
    $ProjectName,

    [Parameter(Mandatory=$true, HelpMessage='The name of the Azure Pipelines variable to set with the request name')]
    [string]
    $VariableName
)

$ErrorActionPreference = 'Stop'

$token = (Get-AzAccessToken -ResourceUrl api://30471ccf-0966-45b9-a979-065dbedb24c1).Token
$requestUri = "https://symbolrequestprod.trafficmanager.net/projects/$ProjectName/requests"

$randomString = (New-Guid).ToString().Substring(0, 8)
$requestName = "$ProjectName-$randomString"

$jsonBody = @{ "requestName" = $requestName } | ConvertTo-Json

Invoke-RestMethod -Method POST -Uri $requestUri -Headers @{ Authorization = "Bearer $token" } -ContentType "application/json" -Body $jsonBody

Write-Host "##vso[task.setvariable variable=$VariableName]$requestName"
