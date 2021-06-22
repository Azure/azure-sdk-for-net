<#
.SYNOPSIS
Starts an Azure DevOps pipeline with the requested variables

.PARAMETER DevOpsPat
DevOps PAT obtained from https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=preview-page

.PARAMETER DevOpsOrg
DevOps organization name (used to build API URL)

.PARAMETER DevOpsProject
DevOps project name (used to build API URL)

.PARAMETER DevOpsPipelineId
ID of the pipeline to launch (used to build API URL)

.PARAMETER RequestBodyJson
Body JSON of the request. Example: 
'{ "variables": { "params": { "value": "{ \"target_repo\": { \"url\": \"https://github.com/MicrosoftDocs/azure-docs-sdk-node\", \"branch\": \"<target-branch-name>\", \"folder\": \"./\" }, \"source_repos\": [] }" } } }'
#>

param(
  [Parameter(Mandatory = $true)]
  [string] $DevOpsPat,

  [Parameter(Mandatory = $true)]
  [string] $DevOpsOrg,

  [Parameter(Mandatory = $true)] 
  [string] $DevOpsProject,

  [Parameter(Mandatory = $true)]
  [string] $DevOpsPipelineId,

  [Parameter()]
  [string] $RequestBodyJson
)

# Create a basic auth header part with a prepended colon to 
# represent that no username is set.
# https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=preview-page#use-a-pat-in-your-code
$authHeader = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(":$DevOpsPat"))

$result = Invoke-RestMethod `
  -Uri "https://dev.azure.com/$DevOpsOrg/$DevOpsProject/_apis/pipelines/$DevOpsPipelineId/runs/?api-version=6.1-preview.1" `
  -Method POST `
  -Headers @{ Authorization = "Basic $authHeader" } `
  -ContentType 'application/json' `
  -Body $RequestBodyJson

if ($result._links.web.href) {
  Write-Host "Build URL: $($result._links.web.href)"
}

return $result
