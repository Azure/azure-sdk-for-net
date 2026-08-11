<#
.SYNOPSIS
Copies the test result files to the llm-artifacts directory for further processing.

.DESCRIPTION
This script stages test result files into an "llm-artifacts" directory so they can be
uploaded as a pipeline artifact and consumed by LLM tooling (for example GitHub Copilot)
to analyze a test run.

It is language agnostic. Every Azure SDK language repo emits test results in a different
format (.NET produces TRX, the other languages produce JUnit XML) and with a different
file name, so callers pass the appropriate leaf-name glob via TestResultsGlob:

- .NET    (TRX):       TestResultsGlob: '$(TestTargetFramework)*.trx'
- Python  (JUnit XML): TestResultsGlob: '*test*.xml'
- JS      (JUnit XML): TestResultsGlob: 'test-results*.xml', SearchFolder: '$(System.DefaultWorkingDirectory)/sdk'
- Java    (JUnit XML): TestResultsGlob: 'TEST-*.xml',        SearchFolder: '$(System.DefaultWorkingDirectory)/sdk'
- Go      (JUnit XML): TestResultsGlob: 'report.xml'

The staging step does not care about the file format; it only moves files. Each file is
renamed using its location relative to the repo's "sdk" directory so results from different
services/packages do not collide once flattened into a single directory.

.PARAMETER ArtifactStagingDirectory
The folder in which the llm-artifacts directory will be created. Passed from DevOps as a string.

.PARAMETER SearchFolder
The folder under which test result files will be searched for. Passed from DevOps as a string.

.PARAMETER TestResultsGlob
The glob pattern to match test result files. Passed from DevOps as a string.

.PARAMETER SourcesDirectory
The root folder of the repo. Passed from DevOps as a string.
#>
Param(
    [Parameter(Mandatory = $True)]
    [string] $ArtifactStagingDirectory,
    [Parameter(Mandatory = $True)]
    [string] $SearchFolder,
    [Parameter(Mandatory = $True)]
    [string] $TestResultsGlob,
    [Parameter(Mandatory = $True)]
    [string] $SourcesDirectory
)

$artifactsDirectory = "$ArtifactStagingDirectory/llm-artifacts"
New-Item $artifactsDirectory -ItemType Directory -Force | Out-Null

$patterns = $TestResultsGlob.Split(",", [StringSplitOptions]::RemoveEmptyEntries) `
| ForEach-Object { $_.Trim() } | Where-Object { $_ }

$testResultsFiles = @(Get-ChildItem -Path $SearchFolder -Include $patterns -Recurse -File -ErrorAction SilentlyContinue)

Write-Host "================="
Write-Host "Found $($testResultsFiles.Count) test result file(s) under '$SearchFolder' matching: $($patterns -join ', ')"
$testResultsFiles | ForEach-Object { Write-Host $_.FullName }
Write-Host "================="

$stagedCount = 0
foreach ($testResultsFile in $testResultsFiles) {
    $fileFullName = $testResultsFile.FullName

    # Build a unique, traceable artifact name from the file's location. Prefer the path
    # relative to the language repo's "sdk" directory, for example:
    #   <sources>/sdk/template/Azure.Template/tests/TestResults/net8.0.trx
    #     -> template-Azure.Template-tests-TestResults-net8.0.trx
    #   <sources>/sdk/storage/report.xml
    #     -> storage-report.xml
    # Fall back to a sources-relative path for repos without an "sdk" directory.
    if ($fileFullName -match "[\\/]sdk[\\/]") {
        $relativePath = ($fileFullName -split "[\\/]sdk[\\/]", 2)[-1]
    }
    else {
        $relativePath = [System.IO.Path]::GetRelativePath($SourcesDirectory, $fileFullName)
    }
    $fileName = $relativePath -replace "^[\\/]+", "" -replace "[\\/]+", "-"

    $destination = "$artifactsDirectory/$fileName"
    Move-Item -Path $fileFullName -Destination $destination -ErrorAction Continue
    if (Test-Path -Path $destination) {
        $stagedCount++
    }
}

# Only signal an upload when test result files were actually staged.
if ($stagedCount -gt 0) {
    Write-Host "Staged $stagedCount test result file(s) into '$artifactsDirectory'."
    Write-Host "##vso[task.setvariable variable=uploadLlmArtifacts]true"
}
else {
    Write-Host "No test result files were staged; skipping llm-artifacts upload."
}
