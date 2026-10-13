Describe "Mark-PackageReleased.ps1" {
    BeforeAll {
        $scriptPath = Join-Path (Join-Path $PSScriptRoot "..") "Mark-PackageReleased.ps1"

        function global:azsdk {
            param (
                [Parameter(ValueFromRemainingArguments = $true)]
                [object[]] $Arguments
            )

            if ($Arguments.Count -eq 1 -and $Arguments[0] -eq "--version") {
                $global:LASTEXITCODE = 0
                return $global:AzSdkVersion
            }

            $global:CapturedAzSdkArguments = @($Arguments)
            $global:CapturedAzSdkInvocations += ,@($Arguments)
            $global:LASTEXITCODE = $global:AzSdkExitCode
            return $global:AzSdkOutput
        }
    }

    AfterAll {
        Remove-Item Function:\azsdk -ErrorAction SilentlyContinue
        Remove-Variable AzSdkExitCode, AzSdkOutput, AzSdkVersion, CapturedAzSdkArguments, CapturedAzSdkInvocations, LanguageShort -Scope Global -ErrorAction SilentlyContinue
    }

    BeforeEach {
        $global:LanguageShort = "python"
        $global:AzSdkExitCode = 0
        $global:AzSdkVersion = "0.6.38"
        $global:AzSdkOutput = '{"operation_status":"Succeeded","api_review_hub":{"packageVersionId":"version123","isReleased":true},"api_view":{"revisionId":"revision456","isReleased":true}}'
        $global:CapturedAzSdkArguments = @()
        $global:CapturedAzSdkInvocations = @()
        $packageInfoPath = Join-Path $TestDrive "azure-test.json"
        @{
            Name = "azure-test"
            Version = "1.0.0"
            ApiHash = "abc123"
        } | ConvertTo-Json | Set-Content $packageInfoPath
    }

    It "passes package-info release inputs to azsdk" {
        & $scriptPath -PackageInfoFiles $packageInfoPath -RepoOwner Azure

        ($global:CapturedAzSdkArguments -join "|") | Should Be (@(
            "package", "mark-released",
            "--language", "python",
            "--package-name", "azure-test",
            "--package-version", "1.0.0",
            "--api-hash", "abc123",
            "--output", "json",
            "--repo-owner", "Azure"
        ) -join "|")
        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--dry-run"
    }

    It "omits the optional repository owner" {
        & $scriptPath -PackageInfoFiles $packageInfoPath

        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--repo-owner"
    }

    It "omits the optional ApiHash" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo.PSObject.Properties.Remove("ApiHash")
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath

        & $scriptPath -PackageInfoFiles $packageInfoPath

        $global:CapturedAzSdkInvocations.Count | Should Be 1
        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--api-hash"
    }

    It "fails without prompting when the azsdk executable is unavailable" {
        $missingExecutable = Join-Path $TestDrive "missing-azsdk.exe"
        $caughtError = $null

        try {
            & $scriptPath -PackageInfoFiles $packageInfoPath -AzSdkExePath $missingExecutable
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "azsdk CLI executable was not found"
    }

    It "fails when the azsdk version is unsupported" {
        $global:AzSdkVersion = "0.6.37"
        $caughtError = $null

        try {
            & $scriptPath -PackageInfoFiles $packageInfoPath
        }
        catch {
            $caughtError = $_
        }

        $caughtError.Exception.Message | Should Match "version 0.6.38 or later is required"
        $global:CapturedAzSdkInvocations.Count | Should Be 0
    }

    It "shows both backend results" {
        $messages = @(& $scriptPath -PackageInfoFiles $packageInfoPath 6>&1) |
            ForEach-Object { "$_" }

        [Array]::IndexOf($messages, "API Review Hub") | Should BeLessThan ([Array]::IndexOf($messages, "APIView"))
        ($messages -join [Environment]::NewLine) | Should Match '"packageVersionId":"version123"'
        ($messages -join [Environment]::NewLine) | Should Match '"revisionId":"revision456"'
    }

    It "surfaces partial backend failure details from azsdk" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = '{"operation_status":"Failed","api_review_hub":{"packageVersionId":"version123"},"api_view":null,"response_errors":["APIView: APIView failed"]}'
        $caughtError = $null

        try {
            & $scriptPath -PackageInfoFiles $packageInfoPath
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "APIView: APIView failed"
    }

    It "includes raw output when azsdk returns malformed output" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = "distinct raw command output"
        $caughtError = $null

        try {
            & $scriptPath -PackageInfoFiles $packageInfoPath
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "distinct raw command output"
    }

    It "accepts a successful response with a missing backend result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","api_review_hub":{"packageVersionId":"version123"},"api_view":null}'

        { & $scriptPath -PackageInfoFiles $packageInfoPath } | Should Not Throw
    }

    It "marks every explicitly supplied package-info file" {
        $secondPackageInfoPath = Join-Path $TestDrive "azure-test-two.json"
        @{
            Name = "azure-test-two"
            Version = "2.0.0"
            ApiHash = "def456"
        } | ConvertTo-Json | Set-Content $secondPackageInfoPath

        & $scriptPath -PackageInfoFiles @($packageInfoPath, $secondPackageInfoPath)

        $global:CapturedAzSdkInvocations.Count | Should Be 2
        ($global:CapturedAzSdkInvocations[0] -join "|") | Should Match "--package-name\|azure-test\|--package-version\|1.0.0.*--api-hash\|abc123"
        ($global:CapturedAzSdkInvocations[1] -join "|") | Should Match "--package-name\|azure-test-two\|--package-version\|2.0.0.*--api-hash\|def456"
    }

    It "continues marking valid packages after invalid package info" {
        $invalidPackageInfoPath = Join-Path $TestDrive "invalid.json"
        Set-Content $invalidPackageInfoPath "not json"

        { & $scriptPath -PackageInfoFiles @($invalidPackageInfoPath, $packageInfoPath) } |
            Should Throw

        $global:CapturedAzSdkInvocations.Count | Should Be 1
    }
}
