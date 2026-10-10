# Exercises the real pipeline script with CLI/HTTP transports mocked and fail-closed.
BeforeAll {
    $script:publisher = Join-Path $PSScriptRoot '../Publish-EvalResults.ps1'
    # Function precedence prevents an unmocked call reaching an installed az executable.
    function az {
        param([Parameter(ValueFromRemainingArguments)] [string[]] $Arguments)
        throw 'Real Azure CLI calls are forbidden in these tests.'
    }
    $claims = @{ tid = '11111111-1111-1111-1111-111111111111'; oid = '22222222-2222-2222-2222-222222222222' }
    $payload = [Convert]::ToBase64String([Text.Encoding]::UTF8.GetBytes(($claims | ConvertTo-Json -Compress))).TrimEnd('=').Replace('+', '-').Replace('/', '_')
    $script:identityToken = "header.$payload.signature"
    $script:owner = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData([Text.Encoding]::UTF8.GetBytes("$($claims.tid):$($claims.oid)"))).ToLowerInvariant()
}
AfterAll { Remove-Variable -Name EvalPublicationFixture -Scope Global -ErrorAction SilentlyContinue }

Describe 'Azure CLI evaluation publication' {
    BeforeEach {
        # Pester mocks can execute in the script-under-test scope. Share one fixture object,
        # not $script: variables whose meaning changes across that scope boundary.
        $id = [Guid]::NewGuid().ToString()
        $script:f = $global:EvalPublicationFixture = @{
            bundle = (Join-Path $TestDrive "$id.zip"); result = (Join-Path $TestDrive "$id.json")
            calls = @(); uploadFails = $false; showFails = $false; storageToken = $script:identityToken
            notifyTokenFails = $false; status = 200; headers = @{}; responseFailures = 0; finalReceiptFails = $false; httpCalls = 0
            name = 'v1/azure-sdk/internal/8255/1001/1/dashboard-bundle.zip'
        }
        $f.bytes = [Text.Encoding]::UTF8.GetBytes('SAVED_ARCHIVE_FIXTURE_NO_EVALUATIONS')
        [IO.File]::WriteAllBytes($f.bundle, $f.bytes)
        $f.hash = (Get-FileHash -LiteralPath $f.bundle -Algorithm SHA256).Hash.ToLowerInvariant()
        @{ blobName = $f.name; sha256 = $f.hash; bytes = $f.bytes.Length } | ConvertTo-Json | Set-Content -LiteralPath "$($f.bundle).json"
        $f.existing = @{ properties = @{ contentLength = $f.bytes.Length }; metadata = @{
            schema = '1'; sha256 = $f.hash; publisher = $script:owner; storedat = '2026-09-21T00:00:00.000Z'
        } }
        $f.arguments = @{ StorageAccountName = 'evaltestsummary'; BundlePath = $f.bundle; ResultPath = $f.result }
        $script:publishArgs = $f.arguments

        Mock az {
            param([string[]] $Arguments)
            $f = $global:EvalPublicationFixture
            $f.calls += ,@($Arguments)
            $global:LASTEXITCODE = 0
            if ($Arguments[0] -eq 'account' -and $Arguments[1] -eq 'get-access-token') {
                if ($Arguments -contains 'https://storage.azure.com/') { return @{ accessToken = $f.storageToken } | ConvertTo-Json -Compress }
                if ($Arguments -notcontains 'api://258998df-81ec-460c-bdd7-56a9bdde1e48') { throw 'Unexpected token destination.' }
                if ($f.notifyTokenFails) { $global:LASTEXITCODE = 1; return 'SECRET_TOKEN_ERROR_MUST_NOT_APPEAR' }
                return '{"accessToken":"fake-notification-token"}'
            }
            if ($Arguments[0] -ne 'storage' -or $Arguments[1] -ne 'blob') { throw 'Unexpected CLI command.' }
            if ($Arguments[2] -eq 'upload') {
                if ($f.uploadFails) { $global:LASTEXITCODE = 1; return 'PRIVATE_UPLOAD_RESPONSE_MUST_NOT_APPEAR' }
                return '{"etag":"fake-etag"}'
            }
            if ($Arguments[2] -eq 'show') {
                if ($f.showFails) { $global:LASTEXITCODE = 1; return 'PRIVATE_STORAGE_RESPONSE_MUST_NOT_APPEAR' }
                return $f.existing | ConvertTo-Json -Depth 5 -Compress
            }
            throw 'Unexpected storage operation; delete/overwrite/container creation is forbidden.'
        }
        Mock Invoke-WebRequest {
            $f = $global:EvalPublicationFixture; $f.httpCalls++
            $receipt = Get-Content -LiteralPath $f.result -Raw | ConvertFrom-Json
            $receipt.status | Should -Be 'stored'; $receipt.notification.status | Should -Be 'pending'
            $Uri | Should -Be 'https://azsdk-eval-bue6a7dwanatgpb3.westus3-01.azurewebsites.net/api/refresh'
            $Headers.Authorization | Should -Be 'Bearer fake-notification-token'
            $MaximumRedirection | Should -Be 0; $ConnectionTimeoutSeconds | Should -Be 180; $SkipHttpErrorCheck | Should -BeTrue
            ([Text.Encoding]::UTF8.GetByteCount($Body) -le 2048) | Should -BeTrue
            $signal = $Body | ConvertFrom-Json -AsHashtable
            @($signal.Keys | Sort-Object) | Should -Be @('blobName', 'sha256')
            $signal.blobName | Should -Be $f.name; $signal.sha256 | Should -Be $f.hash
            if ($f.finalReceiptFails) { New-Item -Path "$($f.result).tmp" -ItemType Directory | Out-Null }
            return [pscustomobject]@{ StatusCode = $f.status; Headers = $f.headers; Content = (@{ status = 'succeeded'; failureCount = $f.responseFailures } | ConvertTo-Json -Compress) }
        }
        Mock Start-Sleep { }
    }

    It 'uploads saved bytes through the logged-in CLI with create-only conditions and metadata' {
        & $script:publisher @script:publishArgs
        $upload = @($f.calls | Where-Object { $_[0] -eq 'storage' -and $_[2] -eq 'upload' })
        $upload.Count | Should -Be 1
        $arguments = $upload[0]
        $arguments[$arguments.IndexOf('--account-name') + 1] | Should -Be 'evaltestsummary'
        $arguments[$arguments.IndexOf('--container-name') + 1] | Should -Be 'vally-results'
        $arguments[$arguments.IndexOf('--file') + 1] | Should -Be $f.bundle
        $arguments[$arguments.IndexOf('--auth-mode') + 1] | Should -Be 'login'
        $arguments[$arguments.IndexOf('--overwrite') + 1] | Should -Be 'false'
        $arguments[$arguments.IndexOf('--if-none-match') + 1] | Should -Be '*'
        $arguments | Should -Contain 'schema=1'; $arguments | Should -Contain "sha256=$($f.hash)"
        $arguments | Should -Contain "publisher=$script:owner"
        ($arguments | Where-Object { $_ -like 'storedat=*' }) | Should -Match 'Z$'
        $receipt = Get-Content $f.result -Raw | ConvertFrom-Json
        $receipt.status | Should -Be 'stored'; $receipt.duplicate | Should -BeFalse; $receipt.notification.status | Should -Be 'succeeded'
        Assert-MockCalled Invoke-WebRequest -Times 1 -Exactly
        (Get-FileHash $f.bundle).Hash.ToLowerInvariant() | Should -Be $f.hash
    }

    It 'adopts an identical existing archive after collision or a lost upload response' {
        $f.uploadFails = $true
        & $script:publisher @script:publishArgs
        $receipt = Get-Content $f.result -Raw | ConvertFrom-Json
        $receipt.duplicate | Should -BeTrue; $receipt.notification.status | Should -Be 'succeeded'
        $f.existing.metadata.storedat | Should -Be '2026-09-21T00:00:00.000Z'
        @($f.calls | Where-Object { $_[0] -eq 'storage' }).Count | Should -Be 2
    }

    It 'never adopts a collision with different <Field>' -ForEach @(
        @{ Field = 'schema'; Value = '2' }, @{ Field = 'sha256'; Value = 'bad' }, @{ Field = 'publisher'; Value = 'other' },
        @{ Field = 'storedat'; Value = $null }, @{ Field = 'storedat'; Value = 'not a date' },
        @{ Field = 'storedat'; Value = '2026-02-30T00:00:00Z' }, @{ Field = 'storedat'; Value = '2026-01-01T24:00:00Z' },
        @{ Field = 'storedat'; Value = '2026-01-01T00:00:00+00:00' }
    ) {
        $f.uploadFails = $true; $f.existing.metadata[$Field] = $Value
        { & $script:publisher @script:publishArgs } | Should -Throw '*submission_conflict*'
        Assert-MockCalled Invoke-WebRequest -Times 0 -Exactly
        @($f.calls | Where-Object { $_[0] -eq 'storage' -and $_[2] -eq 'upload' }).Count | Should -Be 1
    }

    It 'rejects a collision with different size or missing metadata' -ForEach @(@{ Missing = $false }, @{ Missing = $true }) {
        $f.uploadFails = $true
        if ($Missing) { $f.existing.Remove('metadata') } else { $f.existing.properties.contentLength++ }
        { & $script:publisher @script:publishArgs } | Should -Throw '*submission_conflict*'
        Assert-MockCalled Invoke-WebRequest -Times 0 -Exactly
    }

    It 'fails unavailable storage without notifying or logging raw CLI output' {
        $f.uploadFails = $true; $f.showFails = $true
        { & $script:publisher @script:publishArgs } | Should -Throw '*publication_failed*'
        $receipt = Get-Content $f.result -Raw
        $receipt | Should -Not -Match 'PRIVATE_|SECRET_|Bearer'
        ($receipt | ConvertFrom-Json).status | Should -Be 'failed'
        Assert-MockCalled Invoke-WebRequest -Times 0 -Exactly
    }

    It 'does not notify when the first storage receipt cannot be retained' {
        New-Item -Path "$($f.result).tmp" -ItemType Directory | Out-Null
        { & $script:publisher @script:publishArgs } | Should -Throw '*receipt_failed*'
        Assert-MockCalled Invoke-WebRequest -Times 0 -Exactly
        @($f.calls | Where-Object { $_[0] -eq 'storage' -and $_[2] -eq 'upload' }).Count | Should -Be 1
    }

    It 'preserves the first stored receipt when notification status cannot be saved' {
        $f.finalReceiptFails = $true
        & $script:publisher @script:publishArgs -WarningVariable warnings -WarningAction SilentlyContinue
        $receipt = Get-Content $f.result -Raw | ConvertFrom-Json
        $receipt.status | Should -Be 'stored'; $receipt.notification.status | Should -Be 'pending'
        "$warnings" | Should -Match 'original storage receipt is retained'
    }

    It 'treats notification HTTP <Status> as permanent while retaining stored success' -ForEach @(@{ Status = 302 }, @{ Status = 401 }, @{ Status = 403 }) {
        $f.status = $Status
        & $script:publisher @script:publishArgs -WarningAction SilentlyContinue
        $receipt = Get-Content $f.result -Raw | ConvertFrom-Json
        $receipt.status | Should -Be 'stored'; $receipt.notification.status | Should -Be 'failed'
        Assert-MockCalled Invoke-WebRequest -Times 1 -Exactly
        Assert-MockCalled Start-Sleep -Times 0 -Exactly
    }

    It 'bounds transient notification retries to four and honors capped backpressure' {
        $f.status = 429; $f.headers = @{ 'Retry-After' = '9999' }
        & $script:publisher @script:publishArgs -WarningAction SilentlyContinue
        Assert-MockCalled Invoke-WebRequest -Times 4 -Exactly
        Assert-MockCalled Start-Sleep -Times 3 -Exactly -ParameterFilter { $Milliseconds -eq 60000 }
        (Get-Content $f.result -Raw | ConvertFrom-Json).status | Should -Be 'stored'
    }

    It 'ignores non-finite Retry-After values without failing an already-stored build' -ForEach @(@{ Value = 'NaN' }, @{ Value = 'Infinity' }) {
        $f.status = 429; $f.headers = @{ 'Retry-After' = $Value }
        & $script:publisher @script:publishArgs -WarningAction SilentlyContinue
        Assert-MockCalled Invoke-WebRequest -Times 4 -Exactly
        Assert-MockCalled Start-Sleep -Times 3 -Exactly
        (Get-Content $f.result -Raw | ConvertFrom-Json).status | Should -Be 'stored'
    }

    It 'accepts a later successful signal without re-uploading' {
        Mock Invoke-WebRequest {
            $f = $global:EvalPublicationFixture; $f.httpCalls++
            return [pscustomobject]@{ StatusCode = $(if ($f.httpCalls -eq 1) { 503 } else { 200 }); Headers = @{}; Content = '{"status":"succeeded","failureCount":0}' }
        }
        & $script:publisher @script:publishArgs
        Assert-MockCalled Invoke-WebRequest -Times 2 -Exactly
        @($f.calls | Where-Object { $_[0] -eq 'storage' -and $_[2] -eq 'upload' }).Count | Should -Be 1
        (Get-Content $f.result -Raw | ConvertFrom-Json).notification.status | Should -Be 'succeeded'
    }

    It 'does not count an import-failure response as notification success' {
        $f.responseFailures = 1
        & $script:publisher @script:publishArgs -WarningAction SilentlyContinue
        Assert-MockCalled Invoke-WebRequest -Times 4 -Exactly
        (Get-Content $f.result -Raw | ConvertFrom-Json).notification.status | Should -Be 'failed'
    }

    It 'notification token failure cannot erase stored success or leak the token error' {
        $f.notifyTokenFails = $true
        & $script:publisher @script:publishArgs -WarningVariable warnings -WarningAction SilentlyContinue
        Assert-MockCalled Invoke-WebRequest -Times 0 -Exactly
        $receipt = Get-Content $f.result -Raw
        ($receipt | ConvertFrom-Json).status | Should -Be 'stored'
        $receipt + "$warnings" | Should -Not -Match 'SECRET_|fake-notification-token'
    }

    It 'validates storage identity before upload' {
        $f.storageToken = 'bad-token'
        { & $script:publisher @script:publishArgs } | Should -Throw '*storage_identity*'
        @($f.calls | Where-Object { $_[0] -eq 'storage' }).Count | Should -Be 0
    }

    It 'rejects invalid account names before calling Azure CLI' -ForEach @(
        @{ Account = 'https://other.example' }, @{ Account = 'bad;command' }, @{ Account = 'a' }, @{ Account = 'name with spaces' }
    ) {
        $f.arguments.StorageAccountName = $Account
        { & $script:publisher @script:publishArgs } | Should -Throw
        Assert-MockCalled az -Times 0 -Exactly
    }

    It 'checks saved checksum, identity and size before token acquisition' -ForEach @(
        @{ Field = 'sha256'; Value = 'bad' }, @{ Field = 'blobName'; Value = '../escape' }, @{ Field = 'bytes'; Value = 0 }
    ) {
        $descriptor = Get-Content "$($f.bundle).json" -Raw | ConvertFrom-Json -AsHashtable
        $descriptor[$Field] = $Value
        $descriptor | ConvertTo-Json | Set-Content "$($f.bundle).json"
        { & $script:publisher @script:publishArgs } | Should -Throw '*invalid_bundle*'
        Assert-MockCalled az -Times 0 -Exactly
    }

    It 'refuses a receipt path that replaces the archive or descriptor' -ForEach @(@{ Suffix = '' }, @{ Suffix = '.json' }) {
        $f.arguments.ResultPath = "$($f.bundle)$Suffix"
        { & $script:publisher @script:publishArgs } | Should -Throw '*invalid_bundle*'
        Assert-MockCalled az -Times 0 -Exactly
        (Get-FileHash $f.bundle).Hash.ToLowerInvariant() | Should -Be $f.hash
    }
}