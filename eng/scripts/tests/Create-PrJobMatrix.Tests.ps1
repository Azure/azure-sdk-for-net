#Requires -Version 7.0
<#
.How-To-Run
Invoke-Pester -Output Detailed $PSScriptRoot/Create-PrJobMatrix.Tests.ps1
#>

. (Join-Path $PSScriptRoot '..' '..' 'common' 'scripts' 'Helpers' 'PSModule-Helpers.ps1')
Install-ModuleIfNotInstalled 'Pester' '5.3.3' | Import-Module

Describe 'Create-PrJobMatrix scheduling limit' -Tag 'UnitTest' {
    BeforeAll {
        $script:RepositoryRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')
        $script:CreateMatrixPath = Join-Path $script:RepositoryRoot `
            'eng/common/scripts/job-matrix/Create-PrJobMatrix.ps1'
    }

    It 'increases scheduling batch size without dropping singleton artifacts or matrix legs' {
        $packageInfo = Join-Path $TestDrive 'PackageInfo'
        New-Item -ItemType Directory -Path $packageInfo -Force | Out-Null
        $artifactNames = 1..5 | ForEach-Object { "Azure.Package.$_" }
        foreach ($artifactName in $artifactNames) {
            [ordered]@{
                ArtifactName = $artifactName
                DirectoryPath = "sdk/example/$artifactName"
                IncludedForValidation = $false
                CIParameters = @{ CIMatrixConfigs = @() }
            } | ConvertTo-Json -Depth 10 |
                Set-Content -LiteralPath (Join-Path $packageInfo "$artifactName.json")
        }

        $platformMatrix = Join-Path $TestDrive 'platform-matrix.json'
        [ordered]@{
            matrix = [ordered]@{
                Agent = [ordered]@{
                    LinuxNet8 = @{ Pool = 'LinuxPool'; TestTargetFramework = 'net8.0' }
                    LinuxNet9 = @{ Pool = 'LinuxPool'; TestTargetFramework = 'net9.0' }
                }
            }
        } | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $platformMatrix
        $prMatrix = Join-Path $TestDrive 'pr-matrix.json'
        @([ordered]@{
            Name = 'test'
            # The production matrix loader resolves paths relative to the repository root.
            Path = [System.IO.Path]::GetRelativePath($script:RepositoryRoot, $platformMatrix)
            Selection = 'all'
        }) | ConvertTo-Json -Depth 10 -AsArray | Set-Content -LiteralPath $prMatrix

        $serialized = & $script:CreateMatrixPath `
            -PackagePropertiesFolder $packageInfo `
            -PRMatrixFile $prMatrix `
            -PRMatrixSetting ProjectNames `
            -PackagesPerPRJob 1 `
            -MaxJobs 4 `
            -CI:$false
        $matrix = $serialized | Select-Object -Last 1 | ConvertFrom-Json
        $legs = @($matrix.PSObject.Properties)

        $legs.Count | Should -Be 4
        @($legs.Value | ForEach-Object { @($_.ProjectNames -split ',').Count } |
            Measure-Object -Maximum).Maximum | Should -BeLessOrEqual 3
        $assignments = @($legs.Value | ForEach-Object { $_.ProjectNames -split ',' })
        foreach ($artifactName in $artifactNames) {
            # Every singleton appears once on each of the two platform legs.
            @($assignments | Where-Object { $_ -eq $artifactName }).Count | Should -Be 2
        }
    }
}
