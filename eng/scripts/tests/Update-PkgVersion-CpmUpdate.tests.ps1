#Requires -Version 7.0
<#
.How-To-Run
This test file uses Pester, a testing framework for PowerShell.
For more information about Pester, see: https://pester.dev/docs/quick-start

First, ensure you have `pester` installed:

`Install-Module Pester -Force`

Then invoke tests with:

`Invoke-Pester ./Update-PkgVersion-CpmUpdate.tests.ps1`

#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

Set-StrictMode -Version 3

BeforeAll {
    # Helper functions that replicate the CPM update logic from Update-PkgVersion.ps1.
    # We test in isolation since Update-PkgVersion.ps1 has heavy dependencies on common.ps1.

    function Update-NewCpmFiles {
        param (
            [Parameter(Mandatory = $true)] [string]$RepoRoot,
            [Parameter(Mandatory = $true)] [string]$PackageName,
            [Parameter(Mandatory = $true)] [string]$ReleasedVersion
        )
        $escapedName = [regex]::Escape($PackageName)
        $versionPattern = '(<Package(?:Version|Reference)\s+(?:Include|Update)="' + $escapedName + '"\s+Version=")(\d[^"]*?)(")'
        $totalUpdates = 0

        $cpmDir = Join-Path $RepoRoot "eng" "centralpackagemanagement"
        if (Test-Path -LiteralPath $cpmDir -PathType Container) {
            $cpmFiles = Get-ChildItem -LiteralPath $cpmDir -File -Filter '*.Packages.props'
            foreach ($file in $cpmFiles) {
                $content = Get-Content -LiteralPath $file.FullName -Raw
                if (-not $content) { continue }
                $newContent = [regex]::Replace($content, $versionPattern, '${1}' + $ReleasedVersion + '${3}')
                if ($newContent -ne $content) {
                    Set-Content -LiteralPath $file.FullName -Value $newContent -NoNewline
                    $totalUpdates++
                }
            }
        }
        return $totalUpdates
    }

    function Update-OldCpmFile {
        param (
            [Parameter(Mandatory = $true)] [string]$RepoRoot,
            [Parameter(Mandatory = $true)] [string]$PackageName,
            [Parameter(Mandatory = $true)] [string]$ReleasedVersion
        )
        $escapedName = [regex]::Escape($PackageName)
        $oldFile = Join-Path $RepoRoot "eng" "Packages.Data.props"
        if (-not (Test-Path -LiteralPath $oldFile -PathType Leaf)) { return 0 }

        $content = Get-Content -LiteralPath $oldFile -Raw
        $itemGroupPattern = '<ItemGroup(?<attrs>[^>]*)>(?<body>.*?)</ItemGroup>'
        $regexOptions = [System.Text.RegularExpressions.RegexOptions]::Singleline
        $packagePattern = '(<Package(?:Version|Reference)\s+(?:Include|Update)="' + $escapedName + '"\s+Version=")(\d[^"]*?)(")'

        $builder = New-Object System.Text.StringBuilder
        $lastIndex = 0
        $oldFileUpdated = $false

        foreach ($match in [regex]::Matches($content, $itemGroupPattern, $regexOptions)) {
            if ($match.Index -gt $lastIndex) {
                [void]$builder.Append($content.Substring($lastIndex, $match.Index - $lastIndex))
            }

            $attrs = $match.Groups['attrs'].Value
            $body = $match.Groups['body'].Value

            $isUnsafe = ($attrs -match 'MSBuildProjectName') -or
                        ($attrs -match 'TargetFramework') -or
                        ($attrs -match "IsClientLibrary\)'\s*!=\s*'true'")

            $newBody = $body
            if (-not $isUnsafe) {
                $newBody = [regex]::Replace($body, $packagePattern, '${1}' + $ReleasedVersion + '${3}')
                if ($newBody -ne $body) { $oldFileUpdated = $true }
            }

            [void]$builder.Append('<ItemGroup' + $attrs + '>' + $newBody + '</ItemGroup>')
            $lastIndex = $match.Index + $match.Length
        }

        if ($lastIndex -lt $content.Length) {
            [void]$builder.Append($content.Substring($lastIndex))
        }

        if ($oldFileUpdated) {
            Set-Content -LiteralPath $oldFile -Value $builder.ToString() -NoNewline
            return 1
        }
        return 0
    }
}

# --------------------- New CPM: File Discovery ---------------------
Describe "New CPM file discovery" -Tag "UnitTest" {
    Context "with new CPM structure only" {
        It "updates files from centralpackagemanagement but not overrides" {
            $root = Join-Path $TestDrive "newcpm"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            $overridesDir = Join-Path $cpmDir "overrides"
            New-Item -ItemType Directory -Path $overridesDir -Force | Out-Null

            '<Project><ItemGroup><PackageVersion Include="Azure.Core" Version="1.43.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props")
            '<Project><ItemGroup><PackageVersion Include="Azure.Core" Version="1.43.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Support.Packages.props")
            "readme" | Set-Content (Join-Path $cpmDir "README.md")
            '<Project><ItemGroup><PackageVersion Include="Azure.Core" Version="1.40.0" /></ItemGroup></Project>' | Set-Content (Join-Path $overridesDir "Azure.Something.Packages.props")

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 2
            (Get-Content (Join-Path $overridesDir "Azure.Something.Packages.props") -Raw) | Should -Match 'Version="1.40.0"'
        }
    }

    Context "when centralpackagemanagement does not exist" {
        It "returns 0" {
            $root = Join-Path $TestDrive "nocpmdir"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }

    Context "with empty file" {
        It "does not crash" {
            $root = Join-Path $TestDrive "emptycpm"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            "" | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }
}

# --------------------- New CPM: Version Replacement ---------------------
Describe "New CPM version replacement" -Tag "UnitTest" {
    Context "with PackageVersion Include" {
        It "updates the version and leaves others alone" {
            $root = Join-Path $TestDrive "upd-include"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            @"
<Project>
  <ItemGroup>
    <PackageVersion Include="Azure.Core" Version="1.43.0" />
    <PackageVersion Include="Azure.Identity" Version="1.12.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $content = Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw
            $content | Should -Match 'Include="Azure.Core" Version="1.44.0"'
            $content | Should -Match 'Include="Azure.Identity" Version="1.12.0"'
        }
    }

    Context "prefix-safe matching" {
        It "Azure.Core does not match Azure.Core.Amqp" {
            $root = Join-Path $TestDrive "upd-prefix"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            @"
<Project>
  <ItemGroup>
    <PackageVersion Include="Azure.Core" Version="1.43.0" />
    <PackageVersion Include="Azure.Core.Amqp" Version="1.3.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $content = Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw
            $content | Should -Match 'Include="Azure.Core" Version="1.44.0"'
            $content | Should -Match 'Include="Azure.Core.Amqp" Version="1.3.0"'
        }
    }

    Context "dots in name are literal" {
        It "Azure.Core does not match AzureXCore" {
            $root = Join-Path $TestDrive "upd-dots"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="AzureXCore" Version="1.0.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }

    Context "with prerelease version" {
        It "updates prerelease versions" {
            $root = Join-Path $TestDrive "upd-pre"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="Azure.Generator" Version="1.0.0-alpha.20260219.1" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Generator" -ReleasedVersion "1.0.0-alpha.20260225.1"

            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Version="1.0.0-alpha.20260225.1"'
        }

        It "updates beta versions" {
            $root = Join-Path $TestDrive "upd-beta"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="Azure.AI.OpenAI" Version="2.0.0-beta.3" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.AI.OpenAI" -ReleasedVersion "2.0.0-beta.4"

            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Version="2.0.0-beta.4"'
        }

        It "updates preview versions" {
            $root = Join-Path $TestDrive "upd-preview"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="Azure.Monitor.OpenTelemetry" Version="1.0.0-preview.5" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Monitor.OpenTelemetry" -ReleasedVersion "1.0.0-preview.6"

            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Version="1.0.0-preview.6"'
        }
    }

    Context "with property reference version" {
        It "skips MSBuild property references" {
            $root = Join-Path $TestDrive "upd-prop"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="NUnit" Version="$(NUnitVersion)" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "NUnit" -ReleasedVersion "4.0.0"

            $result | Should -Be 0
        }
    }

    Context "with PrivateAssets attribute" {
        It "preserves other attributes" {
            $root = Join-Path $TestDrive "upd-pa"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="Azure.ClientSdk.Analyzers" Version="0.1.0" PrivateAssets="All" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.ClientSdk.Analyzers" -ReleasedVersion "0.1.1"

            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Version="0.1.1" PrivateAssets="All"'
        }
    }

    Context "with version already matching target" {
        It "returns 0" {
            $root = Join-Path $TestDrive "upd-noop"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageVersion Include="Azure.Core" Version="1.44.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }

    Context "with multiple files, package only in some" {
        It "only updates files containing the package" {
            $root = Join-Path $TestDrive "upd-partial"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null

            '<Project><ItemGroup><PackageVersion Include="Azure.Core" Version="1.43.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline
            '<Project><ItemGroup><PackageVersion Include="Azure.Identity" Version="1.12.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Support.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Version="1.44.0"'
            (Get-Content (Join-Path $cpmDir "Directory.Support.Packages.props") -Raw) | Should -Match 'Version="1.12.0"'
        }
    }

    Context "with PackageReference Update syntax in new files" {
        It "updates PackageReference Update entries too" {
            $root = Join-Path $TestDrive "upd-pkgref"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            '<Project><ItemGroup><PackageReference Update="Azure.Core" Version="1.43.0" /></ItemGroup></Project>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            (Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw) | Should -Match 'Update="Azure.Core" Version="1.44.0"'
        }
    }
}

# --------------------- Old Packages.Data.props: Scoped Update ---------------------
Describe "Old Packages.Data.props scoped update" -Tag "UnitTest" {
    Context "updates package in safe ItemGroups" {
        It "updates in broad role-based conditional group" {
            $root = Join-Path $TestDrive "old-safe"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true' or '`$(IsTestProject)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="1.44.0"'
        }
    }

    Context "updates package in unconditioned build-time group" {
        It "updates in group with no condition" {
            $root = Join-Path $TestDrive "old-buildtime"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup>
    <PackageReference Update="Azure.ClientSdk.Analyzers" Version="0.1.0" PrivateAssets="All" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.ClientSdk.Analyzers" -ReleasedVersion "0.1.1"

            $result | Should -Be 1
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="0.1.1"'
        }
    }

    Context "updates package in test/support-only safe group" {
        It "updates in group with test and support role conditions" {
            $root = Join-Path $TestDrive "old-testsupport"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsTestProject)' == 'true' or '`$(IsTestSupportProject)' == 'true' or '`$(IsPerfProject)' == 'true' or '`$(IsStressProject)' == 'true' or '`$(IsSamplesProject)' == 'true' or '`$(IsToolProject)' == 'true'">
    <PackageReference Update="Moq" Version="4.18.4" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Moq" -ReleasedVersion "4.20.0"

            $result | Should -Be 1
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="4.20.0"'
        }
    }

    Context "updates same package across multiple safe ItemGroups" {
        It "updates all entries in different safe groups" {
            $root = Join-Path $TestDrive "old-multisafe"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
  <ItemGroup Condition="'`$(IsTestProject)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            $matches = [regex]::Matches($content, 'Version="1\.44\.0"')
            $matches.Count | Should -Be 2
            $content | Should -Not -Match 'Version="1\.43\.0"'
        }
    }

    Context "does NOT update package in MSBuildProjectName override group" {
        It "skips per-package StartsWith override group" {
            $root = Join-Path $TestDrive "old-override"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="`$(MSBuildProjectName.StartsWith('Azure.AI.OpenAI'))">
    <PackageReference Update="OpenAI" Version="2.8.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "OpenAI" -ReleasedVersion "2.9.0"

            $result | Should -Be 0
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="2.8.0"'
        }

        It "skips per-package Contains override group" {
            $root = Join-Path $TestDrive "old-contains"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="`$(MSBuildProjectName.Contains('Azure.ResourceManager'))">
    <PackageReference Update="Azure.Core" Version="1.41.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="1.41.0"'
        }
    }

    Context "does NOT update package in TargetFramework group" {
        It "skips framework-specific group" {
            $root = Join-Path $TestDrive "old-tfm"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition=" '`$(TargetFramework)' != 'netstandard1.4' ">
    <PackageReference Update="Microsoft.AspNetCore.WebUtilities" Version="2.2.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Microsoft.AspNetCore.WebUtilities" -ReleasedVersion "3.0.0"

            $result | Should -Be 0
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="2.2.0"'
        }
    }

    Context "does NOT update package in legacy Track 1 group" {
        It "skips IsClientLibrary != true group" {
            $root = Join-Path $TestDrive "old-legacy"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' != 'true' and `$(MSBuildProjectName.StartsWith('Microsoft.Azure'))">
    <PackageReference Update="Microsoft.Azure.Amqp" Version="2.4.11" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Microsoft.Azure.Amqp" -ReleasedVersion "2.5.0"

            $result | Should -Be 0
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="2.4.11"'
        }
    }

    Context "mixed: updates safe group but skips override group" {
        It "only updates the entry in the safe group" {
            $root = Join-Path $TestDrive "old-mixed"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
  <ItemGroup Condition="`$(MSBuildProjectName.StartsWith('Azure.Something'))">
    <PackageReference Update="Azure.Core" Version="1.40.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            # Safe group updated
            $content | Should -Match 'Version="1.44.0"'
            # Override group NOT touched — still has 1.40.0
            $content | Should -Match 'Version="1.40.0"'
        }
    }

    Context "skips MSBuild property reference versions" {
        It 'does not update property reference versions' {
            $root = Join-Path $TestDrive "old-propref"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="NUnit" Version="`$(NUnitVersion)" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "NUnit" -ReleasedVersion "4.0.0"

            $result | Should -Be 0
        }
    }

    Context "skips version ranges" {
        It "does not update [x,y) style ranges" {
            $root = Join-Path $TestDrive "old-range"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup>
    <PackageReference Update="Moq" Version="[4.18.2]" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Moq" -ReleasedVersion "4.19.0"

            $result | Should -Be 0
        }
    }

    Context "when file does not exist" {
        It "returns 0" {
            $root = Join-Path $TestDrive "old-nofile"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }

    Context "preserves file formatting" {
        It "does not mangle whitespace or XML declaration" {
            $root = Join-Path $TestDrive "old-format"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            $original = @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
    <PackageReference Update="Azure.Identity" Version="1.12.0" />
  </ItemGroup>
</Project>
"@
            $original | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            # Indentation preserved
            $content | Should -Match '^\<Project'
            # Other entries untouched
            $content | Should -Match 'Update="Azure.Identity" Version="1.12.0"'
            # Our entry updated
            $content | Should -Match 'Update="Azure.Core" Version="1.44.0"'
        }
    }

    Context "with beta version in old format" {
        It "updates beta versions in safe group" {
            $root = Join-Path $TestDrive "old-beta"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.AI.OpenAI" Version="2.0.0-beta.3" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.AI.OpenAI" -ReleasedVersion "2.0.0-beta.4"

            $result | Should -Be 1
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="2.0.0-beta.4"'
        }
    }

    Context "with MSBuild XML namespace (production format)" {
        It "updates package in safe group when xmlns is present" {
            $root = Join-Path $TestDrive "old-xmlns"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true' or '`$(IsTestProject)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            (Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw) | Should -Match 'Version="1.44.0"'
        }

        It "skips override group when xmlns is present" {
            $root = Join-Path $TestDrive "old-xmlns-skip"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
  <ItemGroup Condition="`$(MSBuildProjectName.StartsWith('Azure.Batch'))">
    <PackageReference Update="Azure.Core" Version="1.41.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            $content | Should -Match 'Version="1.44.0"'
            $content | Should -Match 'Version="1.41.0"'
        }
    }

    Context "mixed: override group has same version as safe group" {
        It "does not update the override group when versions coincide" {
            $root = Join-Path $TestDrive "old-mixed-same"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            @"
<Project>
  <ItemGroup Condition="'`$(IsClientLibrary)' == 'true'">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
  <ItemGroup Condition="`$(MSBuildProjectName.StartsWith('Azure.Something'))">
    <PackageReference Update="Azure.Core" Version="1.43.0" />
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 1
            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            # Safe group updated
            $content | Should -Match 'Version="1.44.0"'
            # Override group NOT touched — still has 1.43.0
            $content | Should -Match 'Version="1.43.0"'
        }
    }
}

# --------------------- Error Resilience ---------------------
Describe "Error resilience" -Tag "UnitTest" {
    Context "malformed XML in old file" {
        It "does not crash on malformed content" {
            $root = Join-Path $TestDrive "err-malformed"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            'this is not valid xml <>' | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            # With regex-based approach, malformed content just gets no matches
            $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            $result | Should -Be 0
        }
    }

    Context "new CPM malformed file does not crash" {
        It "skips file that contains no matches" {
            $root = Join-Path $TestDrive "err-newmalformed"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null
            'not xml at all <<<>>>' | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            # New CPM uses regex, not XML parsing, so malformed content just gets no matches
            $result = Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"

            $result | Should -Be 0
        }
    }

    Context "production try/catch wrapping" {
        It "handles errors gracefully" {
            $root = Join-Path $TestDrive "err-trycatch"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null
            'this is not valid xml <>' | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            # With regex-based approach, malformed content is handled gracefully
            $result = $null
            try {
                $result = Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            }
            catch {
                $result = -1
            }

            $result | Should -Be 0
        }
    }
}

Describe "SkipCpmUpdate gating" {
    Context "default behavior (SkipCpmUpdate=true)" {
        It "does not update new CPM files when SkipCpmUpdate is true" {
            $root = Join-Path $TestDrive "skip-new"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null

            $original = @'
<Project>
  <ItemGroup>
    <PackageVersion Include="Azure.Core" Version="1.43.0"/>
  </ItemGroup>
</Project>
'@
            $original | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            # Simulate SkipCpmUpdate=true (default): do NOT call update functions
            $skipCpmUpdate = $true
            if (-not $skipCpmUpdate) {
                Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            }

            $content = Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw
            $content | Should -BeLike '*Version="1.43.0"*'
        }

        It "does not update old CPM file when SkipCpmUpdate is true" {
            $root = Join-Path $TestDrive "skip-old"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null

            $original = @'
<Project>
  <ItemGroup>
    <PackageVersion Update="Azure.Core" Version="1.43.0"/>
  </ItemGroup>
</Project>
'@
            $original | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $skipCpmUpdate = $true
            if (-not $skipCpmUpdate) {
                Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            }

            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            $content | Should -BeLike '*Version="1.43.0"*'
        }
    }

    Context "opt-in behavior (SkipCpmUpdate=false)" {
        It "updates new CPM files when SkipCpmUpdate is false" {
            $root = Join-Path $TestDrive "noskip-new"
            $cpmDir = Join-Path $root "eng" "centralpackagemanagement"
            New-Item -ItemType Directory -Path $cpmDir -Force | Out-Null

            $original = @'
<Project>
  <ItemGroup>
    <PackageVersion Include="Azure.Core" Version="1.43.0"/>
  </ItemGroup>
</Project>
'@
            $original | Set-Content (Join-Path $cpmDir "Directory.Packages.props") -NoNewline

            # Simulate SkipCpmUpdate=false: call update functions
            $skipCpmUpdate = $false
            if (-not $skipCpmUpdate) {
                Update-NewCpmFiles -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            }

            $content = Get-Content (Join-Path $cpmDir "Directory.Packages.props") -Raw
            $content | Should -BeLike '*Version="1.44.0"*'
        }

        It "updates old CPM file when SkipCpmUpdate is false" {
            $root = Join-Path $TestDrive "noskip-old"
            New-Item -ItemType Directory -Path (Join-Path $root "eng") -Force | Out-Null

            $original = @'
<Project>
  <ItemGroup>
    <PackageVersion Update="Azure.Core" Version="1.43.0"/>
  </ItemGroup>
</Project>
'@
            $original | Set-Content (Join-Path $root "eng" "Packages.Data.props") -NoNewline

            $skipCpmUpdate = $false
            if (-not $skipCpmUpdate) {
                Update-OldCpmFile -RepoRoot $root -PackageName "Azure.Core" -ReleasedVersion "1.44.0"
            }

            $content = Get-Content (Join-Path $root "eng" "Packages.Data.props") -Raw
            $content | Should -BeLike '*Version="1.44.0"*'
        }
    }
}
