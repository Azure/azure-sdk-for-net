# Install-Module -Name Pester -Force -SkipPublisherCheck
# Invoke-Pester -Passthru path/to/git-helpers.tests.ps1
BeforeAll {
    . $PSScriptRoot/git-helpers.ps1

    $RunFolder = "$PSScriptRoot/.testruns"

    if (Test-Path $RunFolder){
        Remove-Item -Recurse -Force $RunFolder
    }

    New-Item -ItemType Directory -Path $RunFolder
}

Describe "git-helpers.ps1 tests"{
    Context "Test Parse-ConflictedFile" {
        It "Parses a basic conflicted file" {
            $content = @'
{
  "AssetsRepo": "Azure/azure-sdk-assets-integration",
  "AssetsRepoPrefixPath": "python",
  "TagPrefix": "python/storage/azure-storage-blob",
<<<<<<< HEAD
  "Tag": "integration/example/storage_feature_addition2"
=======
  "Tag": "integration/example/storage_feature_addition1"
>>>>>>> test-storage-tag-combination
}
'@
            $contentPath = Join-Path $RunFolder "basic_conflict_test.json"
            Set-Content -Path $contentPath -Value $content

            $resolution = [ConflictedFile]::new($contentPath)
            $resolution.IsConflicted | Should -Be $true
            $resolution.LeftSource | Should -Be "HEAD"
            $resolution.RightSource | Should -Be "test-storage-tag-combination"
        }

        It "Recognizes when no conflicts are present" {
            $content = @'
{
  "AssetsRepo": "Azure/azure-sdk-assets-integration",
  "AssetsRepoPrefixPath": "python",
  "TagPrefix": "python/storage/azure-storage-blob",
  "Tag": "integration/example/storage_feature_addition1"
}
'@
            $contentPath = Join-Path $RunFolder "no_conflict_test.json"
            Set-Content -Path $contentPath -Value $content

            $resolution = [ConflictedFile]::new($contentPath)
            $resolution.IsConflicted | Should -Be $false
            $resolution.LeftSource | Should -Be ""
            $resolution.RightSource | Should -Be ""
        }
    }
}