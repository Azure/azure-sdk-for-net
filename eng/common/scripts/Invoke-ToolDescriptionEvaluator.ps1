<#
.SYNOPSIS
    Evaluates tool and prompt descriptions and produces a Markdown results report using Tool Description Evaluator from Mcp repo.

.DESCRIPTION
    This script builds and runs the ToolDescriptionEvaluator (.NET) against a set of tool and prompt definitions.
    It restores and compiles the evaluator, executes it with the provided JSON inputs, and emits a `results.md`
    report. The script supports configuration via parameters and environment variables for the embedding model
    service used during evaluation.

.LINK
    https://github.com/microsoft/mcp/tree/main/eng/tools/ToolDescriptionEvaluator

.PARAMETER EvaluatorPath
    The path to the evaluator project root (or its `src` directory) that will be restored, built, and executed.

.PARAMETER ToolsFilePath
    The path to the JSON file containing tool definitions to be evaluated.

.PARAMETER PromptsFilePath
    The path to the JSON file containing prompt definitions to be evaluated.

.PARAMETER OutputFilePath
    The target file path where the generated `results.md` will be moved after the evaluator runs.

.PARAMETER AoaiEndpoint
    The full endpoint URL for the embedding model (e.g., Azure OpenAI embeddings) used by the evaluator.

.PARAMETER TextEmbeddingApiKey
    The API key used to authenticate with the embedding endpoint. Prefer providing this via a secure
    secret store or environment variable rather than hard-coding.

.NOTES
    - The evaluator emits `results.md` in the evaluator folder; this script moves it to `OutputFilePath`.
    - Requires .NET SDK available on PATH.
    - Set-StrictMode is enabled.

.EXAMPLE
    .\Invoke-ToolDescriptionEvaluator.ps1 `
    -EvaluatorPath "C:\work\mcp\eng\tools\ToolDescriptionEvaluator\src" `
    -ToolsFilePath "C:\work\azure-sdk-tools\tools\azsdk-cli\azure-sdk-tools.json" `
    -PromptsFilePath "C:\work\azure-sdk-tools\tools\azsdk-cli\azure-sdk-prompts.json" `
    -OutputFilePath "C:\work\azure-sdk-tools\tools\azsdk-cli" `
    -AoaiEndpoint "https://<your-endpoint>/openai/deployments/text-embedding-3-large/embeddings?api-version=2023-05-15" `
    -TextEmbeddingApiKey (Get-Secret -Name 'TextEmbeddingApiKey')

    Runs the evaluator with the specified tools and prompts files, then moves the generated results to the output path.
#>
param (
    [Parameter(Mandatory = $true)]
    [string] $EvaluatorPath,

    [Parameter(Mandatory = $true)]
    [string] $ToolsFilePath, 

    [Parameter(Mandatory = $true)]
    [string] $PromptsFilePath,

    [Parameter(Mandatory = $true)]
    [string] $OutputFilePath,

    # Environment Variables
    [Parameter(Mandatory = $true)]
    [string] $AoaiEndpoint,

    [Parameter(Mandatory = $true)]
    [string] $TextEmbeddingApiKey
)

Set-StrictMode -Version 3

# Validate input paths
$pathsToCheck = @{
    "EvaluatorPath"  = $EvaluatorPath
    "ToolsFilePath"  = $ToolsFilePath
    "PromptsFilePath" = $PromptsFilePath
    "OutputFilePath" = $OutputFilePath
}

foreach ($p in $pathsToCheck.GetEnumerator()) {
    if (-not (Test-Path -Path $p.Value)) {
        throw "Path does not exist for parameter '$($p.Key)': $($p.Value)"
    }
}

# Build & run the evaluator
Write-Host "Changing directory to evaluator: $EvaluatorPath"
Push-Location $EvaluatorPath
try { 
    $env:AOAI_ENDPOINT = $AoaiEndpoint
    $env:TEXT_EMBEDDING_API_KEY = $TextEmbeddingApiKey

    Write-Host "Running Tool..."
    dotnet run --configuration Release -- --tools-file "$ToolsFilePath" --prompts-file "$PromptsFilePath"
}
finally {
    Pop-Location
    Remove-Item Env:\AOAI_ENDPOINT -ErrorAction SilentlyContinue
    Remove-Item Env:\TEXT_EMBEDDING_API_KEY -ErrorAction SilentlyContinue
}

# The tool emits results.md in the evaluator folder
$generatedName = 'results.md'
$EvaluatorRoot = Split-Path $EvaluatorPath -Parent
$generatedPath = Join-Path -Path $EvaluatorRoot -ChildPath $generatedName
if (-not (Test-Path -Path $generatedPath -PathType Leaf)) {
    throw "Expected output file not found: $generatedPath"
}

Write-Host "Moving Results File: $generatedPath -> $OutputFilePath"
Move-Item -Path $generatedPath -Destination $OutputFilePath -Force
Write-Host "Successfully moved results file to $OutputFilePath"