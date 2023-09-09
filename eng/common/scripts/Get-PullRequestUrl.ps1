param(
  [string]$RepositoryName,
  [string]$SourceBranch,
  [string]$Variable,
  [switch]$IsOutput
)

$PRUrl = $SourceBranch
if ($SourceBranch -match "refs/pull/(\d+)/(head|merge)") {
    $PRUrl = "https://github.com/$RepositoryName/pull/$($Matches[1])"
}

if ($IsOutput) {
  Write-Host "Setting output variable '$Variable' to $PRUrl"
  Write-Host "##vso[task.setvariable variable=$Variable;isoutput=true]$PRUrl"
} else {
  Write-Host "Setting variable '$Variable' to $PRUrl"
  Write-Host "##vso[task.setvariable variable=$Variable]$PRUrl"
}
