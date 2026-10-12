BeforeAll {
    Import-Module powershell-yaml -MinimumVersion 0.4.7 -ErrorAction Stop
    $scriptPath = Join-Path $PSScriptRoot ".." "Verify-RestApiSpecLocation.ps1"
    $parseErrors = $null
    $ast = [System.Management.Automation.Language.Parser]::ParseFile($scriptPath, [ref]$null, [ref]$parseErrors)
    if ($parseErrors.Count -gt 0) {
        throw "Failed to parse ${scriptPath}: $parseErrors"
    }
    # Load only the functions, without running the release workflow or installing modules.
    foreach ($function in $ast.FindAll({
        param($node)
        $node -is [System.Management.Automation.Language.FunctionDefinitionAst]
    }, $false)) {
        . ([scriptblock]::Create($function.Extent.Text))
    }
    function LogError([string]$message) {
        throw $message
    }
    function Search-GitHubCommit {}
    $ServiceDirectory = "storage"
    $PackageName = "azdatalake"
    $GitHubPat = "test-token"

    function Write-TestLocation([string]$directory, [string]$content) {
        New-Item -Path $directory -ItemType Directory -Force | Out-Null
        $path = Join-Path $directory "tsp-location.yaml"
        Set-Content -LiteralPath $path -Value $content
        return $path
    }
}

Describe "Verify-TspLocation" {
    BeforeEach {
        Mock Search-GitHubCommit { return @{ total_count = 1 } }
        $rootPath = Join-Path $TestDrive "tsp-location.yaml"
        $validYaml = "repo: Azure/azure-rest-api-specs`ncommit: main"
    }

    It "preserves validation of a non-batch location" {
        Verify-TspLocation ($validYaml | ConvertFrom-Yaml) $rootPath
        Should -Invoke Search-GitHubCommit -Times 0
    }

    It "validates every child in a batch, resolving paths relative to the YAML file" {
        $firstCommit = "a" * 40
        $secondCommit = "b" * 40
        $firstPath = Write-TestLocation (Join-Path $TestDrive "internal" "generated") "repo: Azure/azure-rest-api-specs`ncommit: $firstCommit"
        $secondPath = Write-TestLocation (Join-Path $TestDrive "internal" "generated_blob") "repo: Azure/azure-rest-api-specs`ncommit: $secondCommit"
        $location = "batch:`n  - ./internal/generated`n  - ./internal/generated_blob" | ConvertFrom-Yaml

        Mock Verify-CommitFromMainBranch {}
        Verify-TspLocation $location $rootPath

        Should -Invoke Verify-CommitFromMainBranch -Times 2 -Exactly
        Should -Invoke Verify-CommitFromMainBranch -Times 1 -Exactly -ParameterFilter {
            $commit -eq $firstCommit -and $configFilePath -eq $firstPath
        }
        Should -Invoke Verify-CommitFromMainBranch -Times 1 -Exactly -ParameterFilter {
            $commit -eq $secondCommit -and $configFilePath -eq $secondPath
        }
    }

    It "follows nested batches relative to each containing file" {
        Write-TestLocation (Join-Path $TestDrive "nested") "batch:`n  - ./leaf" | Out-Null
        $leafPath = Write-TestLocation (Join-Path $TestDrive "nested" "leaf") $validYaml
        Mock Verify-CommitFromMainBranch {}

        Verify-TspLocation (@{ batch = @("./nested") }) $rootPath

        Should -Invoke Verify-CommitFromMainBranch -Times 1 -Exactly -ParameterFilter {
            $commit -eq "main" -and $configFilePath -eq $leafPath
        }
    }

    It "rejects an invalid repo in a later batch entry and reports the child path" {
        Write-TestLocation (Join-Path $TestDrive "first") $validYaml | Out-Null
        $badPath = Write-TestLocation (Join-Path $TestDrive "second") "repo: Other/azure-rest-api-specs`ncommit: main"

        { Verify-TspLocation (@{ batch = @("./first", "./second") }) $rootPath } |
            Should -Throw "*Invalid repo setting*$badPath*"
    }

    It "rejects an invalid commit in a batch entry" {
        $badPath = Write-TestLocation (Join-Path $TestDrive "invalid-commit") "repo: Azure/azure-rest-api-specs`ncommit: feature-branch"

        { Verify-TspLocation (@{ batch = @("./invalid-commit") }) $rootPath } |
            Should -Throw "*Invalid commit hash or branch name*$badPath*"
    }

    It "rejects a child commit that is not on main" {
        Write-TestLocation (Join-Path $TestDrive "off-main") "repo: Azure/azure-rest-api-specs`ncommit: $('c' * 40)" | Out-Null
        Mock Search-GitHubCommit { return @{ total_count = 0 } }

        { Verify-TspLocation (@{ batch = @("./off-main") }) $rootPath } |
            Should -Throw "*doesn't exist in 'main' branch*"
    }

    It "fails when a referenced location file is missing" {
        { Verify-TspLocation (@{ batch = @("./missing") }) $rootPath } | Should -Throw "*does not exist*"
    }

    It "fails when a referenced location file contains malformed YAML" {
        Write-TestLocation (Join-Path $TestDrive "malformed") "batch: [unclosed" | Out-Null

        { Verify-TspLocation (@{ batch = @("./malformed") }) $rootPath } | Should -Throw
    }

    It "rejects an empty child configuration" {
        $emptyPath = Write-TestLocation (Join-Path $TestDrive "empty") ""

        { Verify-TspLocation (@{ batch = @("./empty") }) $rootPath } |
            Should -Throw "*Invalid TypeSpec location configuration*$emptyPath*"
    }

    It "rejects invalid batch values" -ForEach @(
        @{ batchValue = "./child" }
        @{ batchValue = @() }
        @{ batchValue = $null }
        @{ batchValue = @{ child = "./child" } }
    ) {
        { Verify-TspLocation (@{ batch = $batchValue }) $rootPath } |
            Should -Throw "*batch must be a non-empty array*"
    }

    It "rejects invalid batch entries" -ForEach @(
        @{ entry = "" }
        @{ entry = " " }
        @{ entry = $null }
        @{ entry = 123 }
        @{ entry = @{ directory = "./child" } }
    ) {
        { Verify-TspLocation (@{ batch = @($entry) }) $rootPath } |
            Should -Throw "*batch entries must be non-empty directory paths*"
    }

    It "rejects a batch mixed with a direct location" {
        { Verify-TspLocation (@{ batch = @("./child"); repo = "Azure/azure-rest-api-specs" }) $rootPath } |
            Should -Throw "*batch configuration cannot have repo, commit, or directory*"
    }

    It "rejects circular batch references" {
        Write-TestLocation (Join-Path $TestDrive "cycle") "batch:`n  - ." | Out-Null

        { Verify-TspLocation (@{ batch = @("./cycle") }) $rootPath } |
            Should -Throw "*Circular TypeSpec batch reference*"
    }

    It "allows multiple references to the same child outside the ancestor chain" {
        Write-TestLocation (Join-Path $TestDrive "shared") $validYaml | Out-Null
        Mock Verify-CommitFromMainBranch {}

        Verify-TspLocation (@{ batch = @("./shared", "./shared") }) $rootPath

        Should -Invoke Verify-CommitFromMainBranch -Times 2 -Exactly
    }
}

Describe "Verify-RestApiSpecLocation release workflow" {
    BeforeAll {
        $fixtureScripts = Join-Path $TestDrive "scripts"
        $fixtureHelpers = Join-Path $fixtureScripts "Helpers"
        New-Item -Path $fixtureHelpers -ItemType Directory -Force | Out-Null
        $fixtureScript = Join-Path $fixtureScripts "Verify-RestApiSpecLocation.ps1"
        Copy-Item -LiteralPath $scriptPath -Destination $fixtureScript
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot ".." "SemVer.ps1") -Destination $fixtureScripts
        $commonStub = {
            $RepoRoot = Split-Path $PSScriptRoot -Parent
            $Language = "go"
            . (Join-Path $PSScriptRoot "SemVer.ps1")
            function LogError([string]$message) {
                Write-Host "ERROR: $message"
            }
        }
        Set-Content -LiteralPath (Join-Path $fixtureScripts "common.ps1") -Value $commonStub.ToString()
        $moduleStub = {
            function Install-ModuleIfNotInstalled {
                return "powershell-yaml"
            }
        }
        Set-Content -LiteralPath (Join-Path $fixtureHelpers "PSModule-Helpers.ps1") -Value $moduleStub.ToString()
        $packageInfoDirectory = Join-Path $TestDrive "PackageInfo"
        New-Item -Path $packageInfoDirectory -ItemType Directory -Force | Out-Null
        @{
            Version = "1.0.0"
            SdkType = "data"
            ReleaseStatus = "Unreleased"
            DirectoryPath = "package"
        } | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $packageInfoDirectory "azdatalake.json")
        $hostExecutable = (Get-Process -Id $PID).Path
    }

    It "returns the expected exit code for <scenario>" -ForEach @(
        @{ scenario = "a valid batch"; childYaml = "repo: Azure/azure-rest-api-specs`ncommit: main"; expectedExitCode = 0; expectedOutput = "Branch is main" }
        @{ scenario = "an invalid child repo"; childYaml = "repo: Other/azure-rest-api-specs`ncommit: main"; expectedExitCode = 1; expectedOutput = "Invalid repo setting" }
        @{ scenario = "a missing child file"; childYaml = $null; expectedExitCode = 1; expectedOutput = "Failed to validate spec location" }
        @{ scenario = "malformed child YAML"; childYaml = "batch: [unclosed"; expectedExitCode = 1; expectedOutput = "Failed to validate spec location" }
    ) {
        $packageDirectory = Join-Path $TestDrive "package"
        Write-TestLocation $packageDirectory "batch:`n  - ./child" | Out-Null
        $childDirectory = Join-Path $packageDirectory "child"
        $childPath = Join-Path $childDirectory "tsp-location.yaml"
        if ($null -ne $childYaml) {
            Write-TestLocation $childDirectory $childYaml | Out-Null
        }
        elseif (Test-Path -LiteralPath $childPath) {
            Remove-Item -LiteralPath $childPath
        }

        $output = & $hostExecutable -NoProfile -File $fixtureScript -ServiceDirectory storage -PackageName azdatalake -GitHubPat test-token -PackageInfoDirectory $packageInfoDirectory 2>&1
        $LASTEXITCODE | Should -Be $expectedExitCode
        ($output -join "`n") | Should -Match $expectedOutput
    }
}
