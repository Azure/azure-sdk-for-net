param(
  [string]$Variable,
  [switch]$IsOutput
)

$repoUrl = $env:BUILD_REPOSITORY_URI
$sourceBranch = $env:BUILD_SOURCEBRANCH

$description = "[$sourceBranch]($repoUrl/tree/$sourceBranch)" 
if ($sourceBranch -match "^refs/heads/(.+)$") {
    $description = "Branch: [$($Matches[1])]($repoUrl/tree/$sourceBranch)"
} elseif ($sourceBranch -match "^refs/tags/(.+)$") {
    $description = "Tag: [$($Matches[1])]($repoUrl/tree/$sourceBranch)"
} elseif ($sourceBranch -match "^refs/pull/(\d+)/(head|merge)$") {
    $description = "Pull request: $repoUrl/pull/$($Matches[1])"
}

if ($IsOutput) {
  Write-Host "Setting output variable '$Variable' to '$description'"
  Write-Host "##vso[task.setvariable variable=$Variable;isoutput=true]$description"
} else {
  Write-Host "Setting variable '$Variable' to '$description'"
  Write-Host "##vso[task.setvariable variable=$Variable]$description"
}
