# Run tests:
#   Install-Module -Name Pester -Force -SkipPublisherCheck
#   Invoke-Pester -Passthru $PSScriptRoot/Verify-Links.Tests.ps1

BeforeAll {
  # Load only the functions we need by dot-sourcing the script with a dummy param block.
  # We source the script file and then override Invoke-RestMethod / Invoke-WebRequest
  # inside each test via Mock so no real network calls are made.

  # Stub out logging functions that the script depends on but are defined in logging.ps1
  function LogWarning($msg) { Write-Warning $msg }
  function LogError($msg) { Write-Error $msg }
  function LogGroupStart($msg) {}
  function LogGroupEnd {}

  # Source only the function definitions (stop before the script-body runs)
  # by dot-sourcing within a script block that replaces the parameter-driven
  # body with a no-op after loading.
  $scriptPath = (Resolve-Path "$PSScriptRoot/../Verify-Links.ps1").Path

  # Extract and invoke only the function definitions by parsing the AST
  $ast = [System.Management.Automation.Language.Parser]::ParseFile($scriptPath, [ref]$null, [ref]$null)
  $functionDefs = $ast.FindAll({ $args[0] -is [System.Management.Automation.Language.FunctionDefinitionAst] }, $false)
  foreach ($fn in $functionDefs) {
    Invoke-Expression $fn.Extent.Text
  }

  # Script-scope variables referenced inside the functions
  $script:userAgent = "TestAgent/1.0"
  $script:requestTimeoutSec = 15
}

Describe "ProcessNpmLink" {
  Context "Unparseable URL" {
    It "Returns true and skips verification for a URL that does not match npmjs.com package pattern" {
      $result = ProcessNpmLink ([System.Uri]"https://npmjs.com/browse/keyword/azure")
      $result | Should -Be $true
    }
  }

  Context "Non-versioned URL - package found in ADO upstream" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{
          value = @(
            @{ version = "1.0.0" },
            @{ version = "2.0.0" }
          )
        }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Returns true when package has upstream versions" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents")
      $result | Should -Be $true
    }

    It "Encodes scoped package name correctly in the API URL" {
      ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents") | Out-Null
      Should -Invoke Invoke-RestMethod -ParameterFilter {
        $Uri -like "*%40azure%2Fai-agents*"
      } -Times 1 -Exactly
    }

    It "Calls the ADO feed upstream API, not registry.npmjs.org or npmjs.com" {
      ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/core-http") | Out-Null
      Should -Invoke Invoke-RestMethod -ParameterFilter {
        $Uri -like "https://pkgs.dev.azure.com/azure-sdk/public/_apis/packaging/feeds/azure-sdk-for-js/npm/packages/*"
      } -Times 1 -Exactly
    }
  }

  Context "Non-versioned URL - package not found (no upstream versions)" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{ value = @() }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Returns false when the package has no upstream versions" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/nonexistent-package")
      $result | Should -Be $false
    }
  }

  Context "Non-versioned URL - package not found (ADO returns 404)" {
    BeforeEach {
      Mock Invoke-RestMethod {
        $response = [System.Net.HttpWebResponse]::new.Invoke(@())
        throw [System.Net.WebException]::new(
          "The remote server returned an error: (404) Not Found.",
          $null,
          [System.Net.WebExceptionStatus]::ProtocolError,
          $null
        )
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Propagates exception (to be handled by CheckLink caller)" {
      { ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/nonexistent-package") } | Should -Throw
    }
  }

  Context "Versioned URL - correct version present in ADO upstream" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{
          value = @(
            @{ version = "1.0.0" },
            @{ version = "1.1.0" },
            @{ version = "2.0.0" }
          )
        }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Returns true when the specific version exists in upstream" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents/v/1.1.0")
      $result | Should -Be $true
    }

    It "Encodes scoped package name correctly for versioned URLs" {
      ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents/v/1.1.0") | Out-Null
      Should -Invoke Invoke-RestMethod -ParameterFilter {
        $Uri -like "*%40azure%2Fai-agents*"
      } -Times 1 -Exactly
    }
  }

  Context "Versioned URL - version not present in ADO upstream" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{
          value = @(
            @{ version = "1.0.0" },
            @{ version = "2.0.0" }
          )
        }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Returns false when the specific version does not exist in upstream" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents/v/9.9.9")
      $result | Should -Be $false
    }
  }

  Context "Versioned URL - unscoped package" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{
          value = @(
            @{ version = "3.2.1" }
          )
        }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Handles unscoped package names in versioned URLs" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/typescript/v/3.2.1")
      $result | Should -Be $true
    }

    It "Returns false when unscoped versioned package version is missing" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/typescript/v/99.0.0")
      $result | Should -Be $false
    }
  }

  Context "Query parameters and fragments are excluded from package name" {
    BeforeEach {
      Mock Invoke-RestMethod {
        return @{
          value = @(
            @{ version = "1.0.0" }
          )
        }
      } -ParameterFilter { $Uri -like "*upstreamVersions*" }
    }

    It "Strips query string from non-versioned URL when extracting package name" {
      $result = ProcessNpmLink ([System.Uri]"https://www.npmjs.com/package/@azure/ai-agents?activeTab=readme")
      $result | Should -Be $true
      Should -Invoke Invoke-RestMethod -ParameterFilter {
        $Uri -like "*%40azure%2Fai-agents*" -and $Uri -notlike "*activeTab*"
      } -Times 1 -Exactly
    }
  }
}
