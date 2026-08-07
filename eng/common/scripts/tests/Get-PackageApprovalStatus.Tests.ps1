Describe "Get-PackageApprovalStatus.ps1" {
    BeforeAll {
        $scriptPath = Join-Path (Join-Path $PSScriptRoot "..") "Get-PackageApprovalStatus.ps1"

        function global:azsdk {
            param (
                [Parameter(ValueFromRemainingArguments = $true)]
                [object[]] $Arguments
            )

            $global:CapturedAzSdkArguments = @($Arguments)
            $global:LASTEXITCODE = $global:AzSdkExitCode
            return $global:AzSdkOutput
        }
    }

    AfterAll {
        Remove-Item Function:\azsdk -ErrorAction SilentlyContinue
        Remove-Variable AzSdkExitCode, AzSdkOutput, CapturedAzSdkArguments -Scope Global -ErrorAction SilentlyContinue
    }

    BeforeEach {
        $global:AzSdkExitCode = 0
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":true,"finalSource":"reviewHub","reason":"approved"}}'
        $global:CapturedAzSdkArguments = @()
    }

    It "passes package coordinates, API hash, and repository owner to azsdk" {
        & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 -ApiHash abc123 -RepoOwner Contoso

        ($global:CapturedAzSdkArguments -join "|") | Should Be (@(
            "api-review", "get-approval-status",
            "--language", "python",
            "--package-name", "azure-test",
            "--package-version", "1.0.0",
            "--output", "json",
            "--api-hash", "abc123",
            "--repo-owner", "Contoso"
        ) -join "|")
    }

    It "omits the API hash when it is unavailable" {
        & $scriptPath -Language java -PackageName azure-test -PackageVersion 1.0.0

        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--api-hash"
        ($global:CapturedAzSdkArguments -join "|") | Should Not Match "--repo-owner"
    }

    It "fails when azsdk returns a nonzero exit code" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = '{"operation_status":"Failed","response_error":"distinct raw command output"}'

        try {
            & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0
        }
        catch {
            $_.Exception.Message | Should Match "distinct raw command output"
        }
    }

    It "logs a reproducible command invocation" {
        $messages = @(& $scriptPath -Language python -PackageName "azure test" -PackageVersion 1.0.0 6>&1)

        ($messages -join [Environment]::NewLine) | Should Match 'Command: azsdk api-review get-approval-status --language python --package-name "azure test" --package-version 1.0.0 --output json'
    }

    It "shows Review Hub and APIView results before the overall result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":true,"finalSource":"APIView","reason":"approved","reviewHub":{"isApproved":false,"reason":"repositoryNotSupported","statusCode":200},"apiView":{"isApproved":true,"reason":"approved","statusCode":200,"details":["API review is approved."]}}}'

        $messages = @(& $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 6>&1) |
            ForEach-Object { "$_" }

        [Array]::IndexOf($messages, "API Review Hub") | Should BeLessThan ([Array]::IndexOf($messages, "APIView"))
        [Array]::IndexOf($messages, "APIView") | Should BeLessThan ([Array]::IndexOf($messages, "Overall"))
        ($messages -join [Environment]::NewLine) | Should Match "Overall\r?\n  Status: APPROVED\r?\n  Source: APIView\r?\n  Reason: approved"
    }

    It "includes raw output when azsdk returns malformed output" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = "distinct raw command output"

        try {
            & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0
        }
        catch {
            $_.Exception.Message | Should Match "distinct raw command output"
        }
    }

    It "fails when the response is malformed" {
        $global:AzSdkOutput = "not json"

        { & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 } |
            Should Throw
    }

    It "fails when a successful CLI invocation reports an unapproved result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":false,"finalSource":"none","reason":"pending"}}'

        { & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 } |
            Should Throw
    }

    It "fails when the response contract is missing the result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded"}'

        { & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 } |
            Should Throw
    }

    It "fails when the approval decision is not Boolean" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","result":{"isApproved":"false"}}'

        { & $scriptPath -Language python -PackageName azure-test -PackageVersion 1.0.0 } |
            Should Throw
    }
}