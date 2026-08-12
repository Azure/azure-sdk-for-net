Describe "Mark-PackageReleased.ps1" {
    BeforeAll {
        $scriptPath = Join-Path (Join-Path $PSScriptRoot "..") "Mark-PackageReleased.ps1"

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
        $global:AzSdkOutput = '{"operation_status":"Succeeded","api_review_hub":{"packageVersionId":"version123","isReleased":true},"api_view":{"revisionId":"revision456","isReleased":true}}'
        $global:CapturedAzSdkArguments = @()
    }

    It "passes supported release inputs to azsdk" {
        & $scriptPath `
            -Language python `
            -PackageName azure-test `
            -PackageVersion 1.0.0 `
            -ApiHash abc123 `
            -RepoOwner Azure

        ($global:CapturedAzSdkArguments -join "|") | Should Be (@(
            "pkg", "mark-released",
            "--language", "python",
            "--package-name", "azure-test",
            "--package-version", "1.0.0",
            "--api-hash", "abc123",
            "--output", "json",
            "--dry-run",
            "--repo-owner", "Azure"
        ) -join "|")
    }

    It "omits optional release inputs" {
        & $scriptPath `
            -Language java `
            -PackageName azure-test `
            -PackageVersion 1.0.0 `
            -ApiHash abc123

        $arguments = $global:CapturedAzSdkArguments -join "|"
        $arguments | Should Not Match "--repo-owner"
        $arguments | Should Match "--dry-run"
    }

    It "shows both backend results" {
        $messages = @(& $scriptPath `
            -Language python `
            -PackageName azure-test `
            -PackageVersion 1.0.0 `
            -ApiHash abc123 6>&1) | ForEach-Object { "$_" }

        [Array]::IndexOf($messages, "API Review Hub") | Should BeLessThan ([Array]::IndexOf($messages, "APIView"))
        ($messages -join [Environment]::NewLine) | Should Match '"packageVersionId":"version123"'
        ($messages -join [Environment]::NewLine) | Should Match '"revisionId":"revision456"'
    }

    It "surfaces partial backend failure details from azsdk" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = '{"operation_status":"Failed","api_review_hub":{"packageVersionId":"version123"},"api_view":null,"response_errors":["APIView: APIView failed"]}'

        try {
            & $scriptPath `
                -Language python `
                -PackageName azure-test `
                -PackageVersion 1.0.0 `
                -ApiHash abc123
        }
        catch {
            $_.Exception.Message | Should Match "APIView: APIView failed"
        }
    }

    It "includes raw output when azsdk returns malformed output" {
        $global:AzSdkExitCode = 1
        $global:AzSdkOutput = "distinct raw command output"

        try {
            & $scriptPath `
                -Language python `
                -PackageName azure-test `
                -PackageVersion 1.0.0 `
                -ApiHash abc123
        }
        catch {
            $_.Exception.Message | Should Match "distinct raw command output"
        }
    }

    It "accepts a successful response with a missing backend result" {
        $global:AzSdkOutput = '{"operation_status":"Succeeded","api_review_hub":{"packageVersionId":"version123"},"api_view":null}'

        { & $scriptPath `
            -Language python `
            -PackageName azure-test `
            -PackageVersion 1.0.0 `
            -ApiHash abc123 } | Should Not Throw
    }
}
