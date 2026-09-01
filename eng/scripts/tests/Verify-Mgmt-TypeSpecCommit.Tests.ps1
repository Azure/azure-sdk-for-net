#Requires -Version 7.0

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
  . (Join-Path $PSScriptRoot ".." "Verify-Mgmt-TypeSpecCommit.ps1") -ServiceDirectory "unused"

  function Invoke-Git {
    param([string]$RepositoryPath, [Parameter(ValueFromRemainingArguments)]$Arguments)

    git -C $RepositoryPath @Arguments
    if ($LASTEXITCODE -ne 0) {
      throw "git $Arguments failed."
    }
  }
}

Describe "Verify-Mgmt-TypeSpecCommit" -Tag "UnitTest" {
  BeforeEach {
    $caseRoot = Join-Path $TestDrive ([guid]::NewGuid().ToString())
    $testRoot = Join-Path $caseRoot "repo"
    $sdkRoot = Join-Path $testRoot "sdk"
    $serviceRoot = Join-Path $sdkRoot "test"
    $mgmtRoot = Join-Path $serviceRoot "Azure.ResourceManager.Test"
    $provisioningRoot = Join-Path $serviceRoot "Azure.Provisioning.Test"
    $specRoot = Join-Path $caseRoot "spec"

    New-Item -Path $mgmtRoot -ItemType Directory -Force | Out-Null
    New-Item -Path $provisioningRoot -ItemType Directory -Force | Out-Null
    New-Item -Path $specRoot -ItemType Directory -Force | Out-Null

    Invoke-Git $specRoot init --initial-branch=main --quiet
    Invoke-Git $specRoot config user.email "test@example.com"
    Invoke-Git $specRoot config user.name "Test"
    Invoke-Git $specRoot commit --allow-empty --message "main" --quiet
    $mainCommit = Invoke-Git $specRoot rev-parse HEAD

    Invoke-Git $specRoot switch --create feature --quiet
    Invoke-Git $specRoot commit --allow-empty --message "feature" --quiet
    $featureCommit = Invoke-Git $specRoot rev-parse HEAD
    Invoke-Git $specRoot switch main --quiet

    @"
repo: Azure/azure-rest-api-specs
directory: specification/test/resource-manager/Test
commit: $mainCommit
"@ | Set-Content (Join-Path $mgmtRoot "tsp-location.yaml")

    @"
repo: Contoso/azure-rest-api-specs
commit: $featureCommit
"@ | Set-Content (Join-Path $provisioningRoot "tsp-location.yaml")
  }

  It "only discovers Azure.ResourceManager packages" {
    $locations = Get-MgmtTypeSpecLocations -SdkPath $sdkRoot -ServiceDirectory "test"

    $locations.Count | Should -Be 1
    $locations[0].Directory.Name | Should -Be "Azure.ResourceManager.Test"
  }

  It "only selects changed management TypeSpec locations" {
    Invoke-Git $testRoot init --initial-branch=main --quiet
    Invoke-Git $testRoot config user.email "test@example.com"
    Invoke-Git $testRoot config user.name "Test"
    Invoke-Git $testRoot add sdk
    Invoke-Git $testRoot commit --message "main" --quiet
    $sdkRemote = Join-Path $caseRoot "sdk-remote.git"
    git clone --bare --quiet $testRoot $sdkRemote
    $LASTEXITCODE | Should -Be 0
    Invoke-Git $testRoot remote add origin $sdkRemote

    Add-Content (Join-Path $mgmtRoot "tsp-location.yaml") "cleanup: true"
    Add-Content (Join-Path $provisioningRoot "tsp-location.yaml") "cleanup: true"
    Invoke-Git $testRoot add sdk
    Invoke-Git $testRoot commit --message "change locations" --quiet
    $sourceCommit = Invoke-Git $testRoot rev-parse HEAD

    $locations = Get-ChangedMgmtTypeSpecLocations `
      -RepoRoot $testRoot `
      -ServiceDirectory "test" `
      -SourceCommittish $sourceCommit `
      -TargetCommittish "origin/main"

    $locations.Count | Should -Be 1
    $locations[0].Directory.Name | Should -Be "Azure.ResourceManager.Test"
  }

  It "accepts a commit from main" {
    {
      Invoke-MgmtTypeSpecCommitVerification `
        -ServiceDirectory "test" `
        -RepoRoot $testRoot `
        -SpecRepoPath $specRoot `
        -SpecRepoUrl "unused"
    } | Should -Not -Throw
  }

  It "rejects a commit that is only on a feature branch" {
    (Get-Content (Join-Path $mgmtRoot "tsp-location.yaml") -Raw).Replace($mainCommit, $featureCommit) |
      Set-Content (Join-Path $mgmtRoot "tsp-location.yaml")

    {
      Invoke-MgmtTypeSpecCommitVerification `
        -ServiceDirectory "test" `
        -RepoRoot $testRoot `
        -SpecRepoPath $specRoot `
        -SpecRepoUrl "unused"
    } | Should -Throw "*does not belong*main*"
  }

  It "rejects a specs fork" {
    (Get-Content (Join-Path $mgmtRoot "tsp-location.yaml") -Raw).Replace(
      "Azure/azure-rest-api-specs",
      "Contoso/azure-rest-api-specs") |
      Set-Content (Join-Path $mgmtRoot "tsp-location.yaml")

    {
      Invoke-MgmtTypeSpecCommitVerification `
        -ServiceDirectory "test" `
        -RepoRoot $testRoot `
        -SpecRepoPath $specRoot `
        -SpecRepoUrl "unused"
    } | Should -Throw "*repo must be 'Azure/azure-rest-api-specs'*"
  }
}
