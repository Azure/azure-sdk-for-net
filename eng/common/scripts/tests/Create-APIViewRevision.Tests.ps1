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
                [hashtable] $Headers
            )

            $global:ApiViewRequests += [PSCustomObject]@{
                Method = $Method
                Uri = $Uri
                Body = if ($null -ne $Body) { $Body.ReadAsStringAsync().GetAwaiter().GetResult() } else { "" }
                Headers = $Headers
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
        $global:ApiViewRequests[0].Body | Should Match 'name="label"\r?\n\r?\nSource Branch:main'
        $global:ApiViewRequests[0].Body | Should Match 'name="packageVersion"\r?\n\r?\n1.0.0'
        $global:ApiViewRequests[0].Body | Should Match 'name="setReleaseTag"\r?\n\r?\nFalse'
        $global:ApiViewRequests[0].Body | Should Match 'name="packageType"\r?\n\r?\nclient'
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
    }

    It "skips prerelease revisions from feature branches" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo.Version = "1.0.0-beta.1"
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath

        & $scriptPath -ArtifactPath $testRoot -PackageName $packageName -SourceBranch feature -DefaultBranch main

        $global:ApiViewRequests.Count | Should Be 0
    }
}
