Describe 'Write-ApiReviewGenerationMetadata.ps1' {
    It 'records the exact <Kind> checkout separately from language metadata' -TestCases @(
        @{ Kind = 'base'; Ref = 'refs/tags/v1' },
        @{ Kind = 'target'; Ref = 'refs/heads/feature/test' }
    ) {
        param($Kind, $Ref)
        $scriptPath = Join-Path $PSScriptRoot '..' 'Write-ApiReviewGenerationMetadata.ps1'
        $outputDirectory = Join-Path $TestDrive $Kind
        New-Item -ItemType Directory -Force -Path $outputDirectory | Out-Null
        $apiMetadataPath = Join-Path $outputDirectory 'api.metadata.yml'
        'apiHash: language-hash' | Set-Content -LiteralPath $apiMetadataPath
        $sha = 'a' * 40

        & $scriptPath -ArtifactOutputDirectory $outputDirectory -OperationId 'operation-1' -Kind $Kind -Ref $Ref -SourceCommit $sha

        $metadata = Get-Content -LiteralPath (Join-Path $outputDirectory 'generation-metadata.json') -Raw | ConvertFrom-Json
        $metadata.operationId | Should Be 'operation-1'
        $metadata.kind | Should Be $Kind
        $metadata.ref | Should Be $Ref
        $metadata.sourceCommit | Should Be $sha
        (Get-Content -LiteralPath $apiMetadataPath -Raw).Trim() | Should Be 'apiHash: language-hash'
    }

    It 'rejects an absent or invalid source SHA before publishing metadata' -TestCases @(
        @{ SourceCommit = '' },
        @{ SourceCommit = 'not-a-sha' }
    ) {
        param($SourceCommit)
        $scriptPath = Join-Path $PSScriptRoot '..' 'Write-ApiReviewGenerationMetadata.ps1'
        $outputDirectory = Join-Path $TestDrive 'invalid'
        {
            & $scriptPath -ArtifactOutputDirectory $outputDirectory -OperationId 'operation-1' -Kind target -Ref refs/heads/main -SourceCommit $SourceCommit
        } | Should Throw '40-character Git commit SHA'
        (Test-Path (Join-Path $outputDirectory 'generation-metadata.json')) | Should Be $false
    }
}
