[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage='Project name to use in the request uri')]
    [string]
    $ProjectName,

    [Parameter(Mandatory=$true, HelpMessage='The request name to use in the request uri')]
    [string]
    $RequestName,

    [Parameter(HelpMessage='Wait for symbols to be published')]
    [switch]
    $Wait
)

$ErrorActionPreference = 'Stop'

Write-Host "Getting token for api://30471ccf-0966-45b9-a979-065dbedb24c1 (sym-projectapi-prod)"
$token = (Get-AzAccessToken -ResourceUrl 'api://30471ccf-0966-45b9-a979-065dbedb24c1').Token
Write-Host "Token obtained."

$requestUri = "https://symbolrequestprod.trafficmanager.net/projects/$ProjectName/requests/$RequestName"

$jsonBody = @{
    "publishToInternalServer" = $true;
    "publishToPublicServer" = $true
} | ConvertTo-Json

Write-Host "Posting request`nUri: $requestUri`nBody: $jsonBody"
Invoke-RestMethod -Method POST -Uri $requestUri -Headers @{ Authorization = "Bearer $token" } -ContentType "application/json" -Body $jsonBody
Write-Host "Request"


if ($Wait) {
    Write-Host "Waiting for symbols to be published..."
    while($true) {
        Start-Sleep -Seconds 10

        $response = Invoke-RestMethod -Method GET -Uri $requestUri -Headers @{ Authorization = "Bearer $token" } -ContentType "application/json"

        $internalStatus = $response.publishToInternalServerStatus
        $publicStatus = $response.publishToPublicServerStatus
        $internalResult = $response.publishToInternalServerResult
        $publicResult = $response.publishToPublicServerResult

        if ($internalStatus -eq 'Completed' -and $publicStatus -eq 'Completed') {
            Write-Host "Publish result internal: $internalResult, public: $publicResult."
            if ($internalResult -ne 'Succeeded' -or $publicResult -ne 'Succeeded') {
                throw "Publish failed"
            }
            break
        }

        Write-Host "Publish result internal: $internalResult, public: $publicResult ..."
    }
}
