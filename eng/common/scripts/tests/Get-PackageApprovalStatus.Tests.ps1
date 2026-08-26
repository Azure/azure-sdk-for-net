Describe "Get-PackageApprovalStatus.ps1" {
    BeforeAll {
        $scriptPath = Join-Path (Join-Path $PSScriptRoot "..") "Get-PackageApprovalStatus.ps1"

        function global:azsdk {
            param (
                [Parameter(ValueFromRemainingArguments = $true)]
                [object[]] $Arguments
            )

            $global:CapturedAzSdkArguments = @($Arguments)
            $global:CapturedAzSdkInvocations += ,@($Arguments)
            $global:LASTEXITCODE = $global:AzSdkExitCode
            return $global:AzSdkOutput
        }
    }

    AfterAll {
        Remove-Item Function:\azsdk -ErrorAction SilentlyContinue
        Remove-Variable AzSdkExitCode, AzSdkOutput, CapturedAzSdkArguments, CapturedAzSdkInvocations -Scope Global -ErrorAction SilentlyContinue
    }

    BeforeEach {
        $global:AzSdkExitCode = 0
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":true,"finalSource":"reviewHub","reason":"approved"}}'
        $global:CapturedAzSdkArguments = @()
        $global:CapturedAzSdkInvocations = @()
        $packageInfoPath = Join-Path $TestDrive "azure-test.json"
        @{
            Name = "azure-test"
            Version = "1.0.0"
        } | ConvertTo-Json | Set-Content $packageInfoPath
    }

    It "passes package coordinates, API hash, and repository owner to azsdk" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo | Add-Member -NotePropertyName ApiHash -NotePropertyValue abc123
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath

        & $scriptPath -Language python -PackageInfoFiles $packageInfoPath -RepoOwner Contoso

        ($global:CapturedAzSdkArguments -join "|") | Should Be (@(
            "package", "get-approval-status",
            "--language", "python",
            "--package-name", "azure-test",
            "--package-version", "1.0.0",
            "--output", "json",
            "--api-hash", "abc123",
            "--repo-owner", "Contoso"
        ) -join "|")
    }

    It "omits the API hash when it is unavailable" {
        & $scriptPath -Language java -PackageInfoFiles $packageInfoPath

        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--api-hash"
        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--repo-owner"
    }

    It "fails without prompting when the azsdk executable is unavailable" {
        $missingExecutable = Join-Path $TestDrive "missing-azsdk.exe"
        $caughtError = $null

        try {
            & $scriptPath -Language python -PackageInfoFiles $packageInfoPath -AzSdkExePath $missingExecutable
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "azsdk CLI executable was not found"
    }

    It "fails when azsdk returns a nonzero exit code" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = '{"operation_status":"Failed","response_error":"distinct raw command output"}'
        $caughtError = $null

        try {
            & $scriptPath -Language python -PackageInfoFiles $packageInfoPath
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "distinct raw command output"
    }

    It "logs a reproducible command invocation" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo.Name = "azure test"
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath
        $messages = @(& $scriptPath -Language python -PackageInfoFiles $packageInfoPath 6>&1)

        ($messages -join [Environment]::NewLine) | Should Match 'Command: azsdk package get-approval-status --language python --package-name "azure test" --package-version 1.0.0 --output json'
    }

    It "shows Review Hub and APIView results before the overall result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":true,"finalSource":"APIView","reason":"approved","reviewHub":{"isApproved":false,"reason":"repositoryNotSupported","statusCode":200},"apiView":{"isApproved":true,"reason":"approved","statusCode":200,"details":["API review is approved."]}}}'

        $messages = @(& $scriptPath -Language python -PackageInfoFiles $packageInfoPath 6>&1) |
            ForEach-Object { "$_" }

        [Array]::IndexOf($messages, "API Review Hub") | Should BeLessThan ([Array]::IndexOf($messages, "APIView"))
        [Array]::IndexOf($messages, "APIView") | Should BeLessThan ([Array]::IndexOf($messages, "Overall"))
        ($messages -join [Environment]::NewLine) | Should Match "Overall\r?\n  Status: APPROVED\r?\n  Source: APIView\r?\n  Reason: approved"
    }

    It "includes raw output when azsdk returns malformed output" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = "distinct raw command output"
        $caughtError = $null

        try {
            & $scriptPath -Language python -PackageInfoFiles $packageInfoPath
        }
        catch {
            $caughtError = $_
        }

        $caughtError | Should Not BeNullOrEmpty
        $caughtError.Exception.Message | Should Match "distinct raw command output"
    }

    It "fails when the response is malformed" {
        $global:AzSdkOutput = "not json"

        { & $scriptPath -Language python -PackageInfoFiles $packageInfoPath } |
            Should Throw
    }

    It "fails when a successful CLI invocation reports an unapproved result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":false,"finalSource":"none","reason":"pending"}}'

        { & $scriptPath -Language python -PackageInfoFiles $packageInfoPath } |
            Should Throw
    }

    It "ignores a failed approval check for an unreleased package" {
        $packageInfo = Get-Content $packageInfoPath -Raw | ConvertFrom-Json
        $packageInfo | Add-Member -NotePropertyName ReleaseStatus -NotePropertyValue Unreleased
        $packageInfo | ConvertTo-Json | Set-Content $packageInfoPath
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = '{"operation_status":"Failed","response_error":"Package is not approved."}'

        $messages = @(& $scriptPath -Language python -PackageInfoFiles $packageInfoPath 6>&1)

        ($messages -join [Environment]::NewLine) | Should Match "azure-test 1.0.0 is not marked for release. Ignoring approval check failure"
        $global:CapturedAzSdkInvocations.Count | Should Be 1
    }

    It "fails when the response contract is missing the result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded"}'

        { & $scriptPath -Language python -PackageInfoFiles $packageInfoPath } |
            Should Throw
    }

    It "fails when the approval decision is not Boolean" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":"false"}}'

        { & $scriptPath -Language python -PackageInfoFiles $packageInfoPath } |
            Should Throw
    }

    It "checks every explicitly supplied package-info file" {
        $secondPackageInfoPath = Join-Path $TestDrive "azure-test-two.json"
        @{
            Name = "azure-test-two"
            Version = "2.0.0"
            ApiHash = "def456"
        } | ConvertTo-Json | Set-Content $secondPackageInfoPath

        & $scriptPath -Language python -PackageInfoFiles @($packageInfoPath, $secondPackageInfoPath)

        $global:CapturedAzSdkInvocations.Count | Should Be 2
        ($global:CapturedAzSdkInvocations[0] -join "|") | Should Match "--package-name\|azure-test\|--package-version\|1.0.0"
        ($global:CapturedAzSdkInvocations[1] -join "|") | Should Match "--package-name\|azure-test-two\|--package-version\|2.0.0.*--api-hash\|def456"
    }

    It "continues checking valid packages after invalid package info" {
        $invalidPackageInfoPath = Join-Path $TestDrive "invalid.json"
        Set-Content $invalidPackageInfoPath "not json"

        { & $scriptPath -Language python -PackageInfoFiles @($invalidPackageInfoPath, $packageInfoPath) } |
            Should Throw

        $global:CapturedAzSdkInvocations.Count | Should Be 1
    }
}