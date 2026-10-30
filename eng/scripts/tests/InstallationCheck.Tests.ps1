#Requires -Version 7.0
<#
Invoke-Pester -Output Detailed $PSScriptRoot/InstallationCheck.Tests.ps1
#>

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" "PSModule-Helpers.ps1")
Install-ModuleIfNotInstalled "Pester" "5.3.3" | Import-Module

BeforeAll {
    $installationScript = Join-Path $PSScriptRoot ".." "InstallationCheck.ps1"

    function New-TestPackage(
        [string]$Id = "Azure.ResourceManager.EdgeActions",
        [string]$Version = "1.0.0-beta.4",
        [string]$FileName = "$Id.$Version.nupkg",
        [string]$Namespace = "http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd",
        [string]$Nuspec = "",
        [int]$NuspecCount = 1
    ) {
        if (!$Nuspec) {
            $Nuspec = "<package xmlns='$Namespace'><metadata><id>$Id</id><version>$Version</version></metadata></package>"
        }
        $zip = [IO.Compression.ZipFile]::Open((Join-Path $packageDirectory $FileName), [IO.Compression.ZipArchiveMode]::Create)
        try {
            for ($i = 0; $i -lt $NuspecCount; $i++) {
                $writer = [IO.StreamWriter]::new($zip.CreateEntry("$Id.nuspec").Open())
                try { $writer.Write($Nuspec) } finally { $writer.Dispose() }
            }
        } finally {
            $zip.Dispose()
        }
    }

    function Invoke-InstallationCheck {
        $originalLocation = Get-Location
        try {
            Set-Location $workingDirectory
            & $installationScript -ArtifactsDirectory $artifactsDirectory -Artifact "Azure.ResourceManager.EdgeActions" -RetryLimit 1
        } finally {
            Set-Location $originalLocation
        }
    }
}

Describe "Release installation artifact validation" -Tag "UnitTest" {
    BeforeEach {
        $workingDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $artifactsDirectory = Join-Path $workingDirectory "packages-signed"
        $packageDirectory = Join-Path $artifactsDirectory "Azure.ResourceManager.EdgeActions"
        New-Item -ItemType Directory -Path $packageDirectory -Force | Out-Null
        $infoDirectory = New-Item -ItemType Directory -Path (Join-Path $artifactsDirectory "PackageInfo")
        @{ Version = "1.0.0-beta.4" } | ConvertTo-Json |
            Set-Content (Join-Path $infoDirectory "Azure.ResourceManager.EdgeActions.json")
        # Simulate successful remote restore: it must never mask an invalid local package.
        Mock dotnet { $global:LASTEXITCODE = 0 }
    }

    It "rejects the observed alpha artifact even if remote restore would succeed" {
        New-TestPackage -Version "1.0.0-alpha.20261022.1"
        { Invoke-InstallationCheck } | Should -Throw "*1.0.0-alpha.20261022.1*1.0.0-beta.4*"
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "accepts a matching signed package (namespace='<Namespace>')" -ForEach @(
        @{ Namespace = "http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd" }
        @{ Namespace = "" }
    ) {
        New-TestPackage -Namespace $Namespace
        { Invoke-InstallationCheck } | Should -Not -Throw
        Should -Invoke dotnet -Times 1 -Exactly -ParameterFilter { $args[0] -eq "restore" }
    }

    It "checks nuspec contents rather than trusting the filename" {
        New-TestPackage -Version "1.0.0-alpha.20261022.1" -FileName "Azure.ResourceManager.EdgeActions.1.0.0-beta.4.nupkg"
        { Invoke-InstallationCheck } | Should -Throw "*1.0.0-alpha.20261022.1*1.0.0-beta.4*"
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects a different package identity" {
        New-TestPackage -Id "Azure.Other"
        { Invoke-InstallationCheck } | Should -Throw "*Azure.Other*Azure.ResourceManager.EdgeActions*"
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects a missing product package" {
        { Invoke-InstallationCheck } | Should -Throw
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects an extra product package that publication would also upload" {
        New-TestPackage
        New-TestPackage -Version "1.0.0-alpha.20261022.1"
        { Invoke-InstallationCheck } | Should -Throw
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "ignores legacy symbol packages like the publication steps" {
        New-TestPackage
        Set-Content (Join-Path $packageDirectory "Azure.ResourceManager.EdgeActions.1.0.0-beta.4.symbols.nupkg") "symbols"
        { Invoke-InstallationCheck } | Should -Not -Throw
    }

    It "rejects missing release metadata version" {
        New-TestPackage
        "{}" | Set-Content (Join-Path $artifactsDirectory "PackageInfo/Azure.ResourceManager.EdgeActions.json")
        { Invoke-InstallationCheck } | Should -Throw
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects <Count> root nuspec entries" -ForEach @(
        @{ Count = 0 }
        @{ Count = 2 }
    ) {
        New-TestPackage -NuspecCount $Count
        { Invoke-InstallationCheck } | Should -Throw "*exactly one root nuspec*"
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects missing nuspec <Field>" -ForEach @(
        @{ Field = "ID"; Nuspec = "<package><metadata><version>1.0.0-beta.4</version></metadata></package>" }
        @{ Field = "version"; Nuspec = "<package><metadata><id>Azure.ResourceManager.EdgeActions</id></metadata></package>" }
    ) {
        New-TestPackage -Nuspec $Nuspec
        { Invoke-InstallationCheck } | Should -Throw "*does not match expected*"
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects a malformed nuspec" {
        New-TestPackage -Nuspec "<not-valid-xml"
        { Invoke-InstallationCheck } | Should -Throw
        Should -Invoke dotnet -Times 0 -Exactly
    }

    It "rejects a malformed nupkg" {
        Set-Content (Join-Path $packageDirectory "bad.nupkg") "not a ZIP"
        { Invoke-InstallationCheck } | Should -Throw
        Should -Invoke dotnet -Times 0 -Exactly
    }
}
