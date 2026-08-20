Describe "Create-APIViewRevision.ps1" {
    BeforeAll {
        $scriptPath = Join-Path (Join-Path $PSScriptRoot "..") "Create-APIViewRevision.ps1"

        function global:Find-Unknown-Artifacts-For-Apireview {
            param ([string] $ArtifactPath, [string] $ArtifactName)
            return @{ $ArtifactName = $global:TestPackagePath }
        }

        function global:az {
            $global:LASTEXITCODE = 0
            return '{"accessToken":"test-token"}'
        }

        function global:Invoke-WebRequest {
            param (
                [string] $Method,
                [string] $Uri,
                [object] $Body,
                [hashtable] $Headers,
                [int] $MaximumRetryCount
            )

            $global:ApiViewRequests += [PSCustomObject]@{
                Method = $Method
                Uri = $Uri
                Body = if ($null -ne $Body) { $Body.ReadAsStringAsync().GetAwaiter().GetResult() } else { "" }
                Headers = $Headers
                MaximumRetryCount = $MaximumRetryCount
            }
            return [PSCustomObject]@{ Content = "created"; StatusCode = 200 }
        }
    }

    AfterAll {
        Remove-Item Function:\Find-Unknown-Artifacts-For-Apireview -ErrorAction SilentlyContinue
        Remove-Item Function:\az -ErrorAction SilentlyContinue
        Remove-Item Function:\Invoke-WebRequest -ErrorAction SilentlyContinue
        Remove-Variable TestPackagePath, ApiViewRequests -Scope Global -ErrorAction SilentlyContinue
    }

    BeforeEach {
        $testRoot = Join-Path $TestDrive "artifacts"
        $packageName = "test-package"
        $packageDirectory = Join-Path $testRoot $packageName
        $packageInfoDirectory = Join-Path $testRoot "PackageInfo"
        New-Item -ItemType Directory -Path $packageDirectory, $packageInfoDirectory -Force | Out-Null

        $global:TestPackagePath = Join-Path $packageDirectory "$packageName.zip"
        Set-Content -Path $global:TestPackagePath -Value "package"
        $packageInfoPath = Join-Path $packageInfoDirectory "$packageName.json"
        @{
            ArtifactName = $packageName
            Name = $packageName
            Version = "1.0.0"
            SdkType = "client"
            ReleaseStatus = "Unreleased"
        } | ConvertTo-Json | Set-Content $packageInfoPath
        $global:ApiViewRequests = @()
    }

    It "uploads the source artifact when no review token exists" {
        & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch main -DefaultBranch main

        $global:ApiViewRequests.Count | Should Be 1
        $global:ApiViewRequests[0].Uri | Should Be "https://apiview.dev/autoreview/upload"
        $global:ApiViewRequests[0].Headers.Authorization | Should Be "Bearer test-token"
        $global:ApiViewRequests[0].MaximumRetryCount | Should Be 3
        $global:ApiViewRequests[0].Body | Should Match '(?s)name="?label"?.*?Source Branch:main'
        $global:ApiViewRequests[0].Body | Should Match '(?s)name="?packageVersion"?.*?1.0.0'
        $global:ApiViewRequests[0].Body | Should Match '(?s)name="?setReleaseTag"?.*?False'
        $global:ApiViewRequests[0].Body | Should Match '(?s)name="?packageType"?.*?client'
    }

    It "creates a revision from a review token when one exists" {
        Set-Content -Path (Join-Path $packageDirectory "${packageName}_Unknown.json") -Value "{}"

        & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch main -DefaultBranch main -BuildId 123 -RepoName Azure/test

        $global:ApiViewRequests.Count | Should Be 1
        $global:ApiViewRequests[0].Uri | Should Match "/create\?"
        $global:ApiViewRequests[0].Uri | Should Match "buildId=123"
        $global:ApiViewRequests[0].Uri | Should Match "repoName=Azure%2ftest"
        $global:ApiViewRequests[0].Uri | Should Match "packageName=test-package"
        $global:ApiViewRequests[0].Uri | Should Match "reviewFilePath=test-package_Unknown.json"
        $global:ApiViewRequests[0].Uri | Should Not Match "setReleaseTag"
        $global:ApiViewRequests[0].MaximumRetryCount | Should Be 3
    }

    It "requires pipeline metadata when creating from a review token" {
        Set-Content -Path (Join-Path $packageDirectory "${packageName}_Unknown.json") -Value "{}"

        $caughtError = $null
        try {
            & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch main -DefaultBranch main
        }
        catch {
            $caughtError = $_
        }

        $caughtError.Exception.Message | Should Match "BuildId is required"
        $global:ApiViewRequests.Count | Should Be 0
    }

    It "requires branch metadata before processing packages" {
        $caughtError = $null
        try {
            & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch "" -DefaultBranch main
        }
        catch {
            $caughtError = $_
        }

        $caughtError.Exception.Message | Should Match "SourceBranch is required"
        $global:ApiViewRequests.Count | Should Be 0
    }

    It "skips prerelease revisions from feature branches" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo.Version = "1.0.0-beta.1"
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath

        & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch feature -DefaultBranch main

        $global:ApiViewRequests.Count | Should Be 0
    }
}
