# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# This script is used to set up SIP Configuration domains for Azure Communication Services SIP Routing SDK GA tests

# It is invoked by the https://github.com/Azure/azure-sdk-for-net/blob/main/eng/New-TestResources.ps1
# script after the ARM template, defined in https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/test-resources.json,
# is finished being deployed. The ARM template is responsible for creating the Storage accounts needed for live tests.

param (
  [hashtable] $DeploymentOutputs,
  [string] $TenantId,
  [string] $TestApplicationId,
  [string] $TestApplicationSecret
)

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
  $ErrorActionPreference = 'Stop'
}

function Log($Message) {
  Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

Log 'Starting sdk\communication\test-resources-post.ps1'

if($DeploymentOutputs.ContainsKey('COMMUNICATION_SERVICE_ENDPOINT')){
  Write-Host "COMMUNICATION_SERVICE_ENDPOINT exists, proceeding."
}else{
  Write-Host "COMMUNICATION_SERVICE_ENDPOINT does not exist, ending."
exit
}
$communicationServiceEndpoint = $DeploymentOutputs["COMMUNICATION_SERVICE_ENDPOINT"]

if ($communicationServiceEndpoint -notmatch '\/$') {
  Log "adding trailing slash to $communicationServiceEndpoint"
  $communicationServiceEndpoint = $communicationServiceEndpoint + "/"
}

if($DeploymentOutputs.ContainsKey('COMMUNICATION_SERVICE_ACCESS_KEY')){
  Write-Host "COMMUNICATION_SERVICE_ACCESS_KEY exists, proceeding."
}else{
  Write-Host "COMMUNICATION_SERVICE_ACCESS_KEY does not exist, ending."
exit
}
$communicationServiceApiKey = $DeploymentOutputs["COMMUNICATION_SERVICE_ACCESS_KEY"]

if($DeploymentOutputs.ContainsKey('AZURE_TEST_DOMAIN')){
  Write-Host "AZURE_TEST_DOMAIN exists, proceeding."
}else{
  Write-Host "AZURE_TEST_DOMAIN does not exist, ending."
exit
}
$testDomain = $DeploymentOutputs["AZURE_TEST_DOMAIN"]

$payload = @"
{"domains": { "$testDomain": {"enabled": true}},"trunks": null,"routes": null}
"@

$utcNow = [DateTimeOffset]::UtcNow.ToString('r', [cultureinfo]::InvariantCulture)
$contentBytes = [Text.Encoding]::UTF8.GetBytes($payload)
$sha256 = [System.Security.Cryptography.HashAlgorithm]::Create('sha256')
$contentHash = $sha256.ComputeHash($contentBytes)
$contentHashBase64String = [Convert]::ToBase64String($contentHash)
$endpointParsedUri = [System.Uri]$communicationServiceEndpoint
$hostAndPort = $endpointParsedUri.Host
$apiVersion = "2023-04-01-preview"
$urlPathAndQuery = $communicationServiceEndpoint + "sip?api-version=$apiVersion"
$stringToSign = "PATCH`n/sip?api-version=$apiVersion`n$utcNow;$hostAndPort;$contentHashBase64String"
$hmacsha = New-Object System.Security.Cryptography.HMACSHA256
$hmacsha.key = [System.Convert]::FromBase64String($communicationServiceApiKey)
$signatureBytes = $hmacsha.ComputeHash([Text.Encoding]::ASCII.GetBytes($stringToSign))
$requestSignatureBase64String = [Convert]::ToBase64String($signatureBytes)
$authorizationValue = "HMAC-SHA256 SignedHeaders=date;host;x-ms-content-sha256&Signature=$requestSignatureBase64String"

$headers = @{
  "Authorization"       = $authorizationValue
  "x-ms-content-sha256" = $contentHashBase64String
  "Date"                = $utcNow
  "X-Forwarded-Host"    = $hostAndPort
}

try {
  Log "Inserting Domains in SipConfig for Communication Livetest Dynamic Resource..."  
  $response = Invoke-RestMethod -ContentType "application/merge-patch+json" -Uri $urlPathAndQuery -Method PATCH -Headers $headers -UseBasicParsing -Body $payload -Verbose | ConvertTo-Json
  Log $response
  Log "Inserted Domains in SipConfig for Communication Livetest Dynamic Resource"  
}
catch {
  Write-Host "Exception while invoking the SIP Config Patch:"
  Write-Host "StatusCode:" $_.Exception.Response.StatusCode.value__ 
  Write-Host "StatusDescription:" $_.Exception.Response
  Write-Host "Error Message:" $_.ErrorDetails.Message
}

Log 'Finishing sdk\communication\test-resources-post.ps1'
