#Requires -Version 7.0
<#
.SYNOPSIS
    Validates upstream C# emitter dependency pins before installing packages.
.DESCRIPTION
    Accepts exact versions approved by the emitter package descriptors, including
    previous approvals in canonical main history. Feed availability and version
    ordering are not evidence of approval. Older publications without a recorded
    approval must be explicitly approved before use.

    CI must fetch canonical main into origin/main before running this script.
    No registry queries, package installation, or dashboard generation are required.
#>
[CmdletBinding()]
param(
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot "../../..")).Path,
    [ValidateSet("eng/packages/http-client-csharp", "eng/packages/http-client-csharp-mgmt")]
    [string]$EmitterPackagePath = "eng/packages/http-client-csharp"
)

$ErrorActionPreference = "Stop"

function Get-EmitterApprovalHistory([string]$RepoRoot, [string]$DescriptorPath, [string]$Dependency, [string]$Version) {
    # Only first-parent main approvals count, never pins in PR/feature history.
    # Stop at the most recent matching approval change, or at the descriptor's creation.
    $pin = '"' + [regex]::Escape($Dependency) + '"[[:space:]]*:[[:space:]]*"' + [regex]::Escape($Version) + '"'
    $history = git -C $RepoRoot log --first-parent --follow --max-count=1 --format= --no-ext-diff -p -G $pin refs/remotes/origin/main -- $DescriptorPath 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "Unable to establish approval history from canonical origin/main: $($history | Out-String). Fetch main history and retry."
    }
    # Either side of a first-parent diff is a descriptor state that existed on main.
    $pattern = '^[+-]\s*"' + [regex]::Escape($Dependency) + '"\s*:\s*"' + [regex]::Escape($Version) + '"'
    foreach ($line in $history) {
        if ($line -cmatch $pattern) {
            return $Version
        }
    }
}

function Assert-EmitterDependencies([string]$RepoRoot, [string]$EmitterPackagePath) {
    $descriptors = @{
        "@typespec/http-client-csharp" = "eng/http-client-csharp-emitter-package.json"
        "@azure-typespec/http-client-csharp" = "eng/azure-typespec-http-client-csharp-emitter-package.json"
    }
    $dependencies = @("@typespec/http-client-csharp")
    if ($EmitterPackagePath -eq "eng/packages/http-client-csharp-mgmt") {
        $dependencies += "@azure-typespec/http-client-csharp"
    }

    $directory = Join-Path $RepoRoot $EmitterPackagePath
    $manifest = Get-Content (Join-Path $directory "package.json") -Raw | ConvertFrom-Json -AsHashtable
    $lock = Get-Content (Join-Path $directory "package-lock.json") -Raw | ConvertFrom-Json -AsHashtable
    $consumer = "$($manifest.name) ($EmitterPackagePath)"

    foreach ($dependency in $dependencies) {
        $referenced = if ($manifest.dependencies) { $manifest.dependencies[$dependency] } else { "" }
        $context = "$consumer dependency '$dependency' referenced version '$referenced'"
        $guidance = "Select an official main publication approved in '$($descriptors[$dependency])' (or its canonical main history), then run npm install --package-lock-only in '$directory' and commit both manifests."
        $version = $null
        if (-not [System.Management.Automation.SemanticVersion]::TryParse($referenced, [ref]$version)) {
            throw "${context}: an exact version pin is required; ranges, tags, aliases, and local packages cannot establish publication approval. $guidance"
        }
        if ($lock.lockfileVersion -notin @(2, 3) -or -not $lock.packages) {
            throw "${context}: package-lock.json must contain npm lockfileVersion 2 or 3 package resolutions. $guidance"
        }
        $lockRoot = $lock.packages['']
        $lockReference = if ($lockRoot.dependencies) { $lockRoot.dependencies[$dependency] } else { "" }
        if ($lockReference -cne $referenced) {
            throw "${context}: package-lock.json root reference '$lockReference' does not match package.json. $guidance"
        }
        $directPath = "node_modules/$dependency"
        $direct = $lock.packages[$directPath]
        if (-not $direct -or $direct.version -cne $referenced) {
            throw "${context}: direct package-lock.json resolved version '$($direct.version)' does not match the manifest pin. $guidance"
        }

        $descriptorPath = $descriptors[$dependency]
        try {
            $descriptor = Get-Content (Join-Path $RepoRoot $descriptorPath) -Raw | ConvertFrom-Json -AsHashtable
        }
        catch {
            throw "${context}: unable to establish approval from '$descriptorPath': $($_.Exception.Message) $guidance"
        }
        $approved = if ($descriptor.dependencies) { $descriptor.dependencies[$dependency] } else { "" }
        $approvedVersion = $null
        if (-not [System.Management.Automation.SemanticVersion]::TryParse($approved, [ref]$approvedVersion)) {
            throw "${context}: unable to establish approval; '$descriptorPath' has no exact approved version for '$dependency'. $guidance"
        }
        $historicalApprovals = @{}
        $resolutionPattern = '(^|/)node_modules/' + [regex]::Escape($dependency) + '$'
        foreach ($entry in $lock.packages.GetEnumerator() | Where-Object { $_.Key -cmatch $resolutionPattern }) {
            $resolved = $entry.Value.version
            $resolutionContext = "$context, resolved version '$resolved' at '$($entry.Key)'"
            $archive = [regex]::Escape("$dependency/-/$($dependency.Split('/')[-1])-$resolved.tgz")
            $registryPattern = '^https://(registry\.npmjs\.org/|packagefeedproxy\.microsoft\.io/npm/|pkgs\.dev\.azure\.com/azure-sdk/public/_packaging/azure-sdk-for-js/npm/registry/)' + $archive + '$'
            if ($entry.Value.link -or $entry.Value.resolved -cnotmatch $registryPattern -or -not $entry.Value.integrity) {
                throw "${resolutionContext}: cannot establish an official package resolution; require an integrity-pinned archive from npm or the Azure SDK public feed, not a link or alternate source. $guidance"
            }
            if ($resolved -ceq $approved) {
                continue
            }
            if (-not $historicalApprovals.ContainsKey($resolved)) {
                try {
                    $historicalApprovals[$resolved] = $resolved -cin @(Get-EmitterApprovalHistory $RepoRoot $descriptorPath $dependency $resolved)
                }
                catch {
                    throw "${resolutionContext}: unable to establish approval/provenance. $($_.Exception.Message) $guidance"
                }
            }
            if (-not $historicalApprovals[$resolved]) {
                throw "${resolutionContext}: no recorded official main approval in '$descriptorPath'; current approval is '$approved'. Being published or numerically older is not proof of origin. PR/feature/regeneration-preview packages are not approved. If history is shallow, fetch complete canonical main history and retry. $guidance"
            }
        }
        Write-Host "$context validated, including all lockfile resolutions."
    }
}

if ($MyInvocation.InvocationName -ne ".") {
    Assert-EmitterDependencies $RepoRoot $EmitterPackagePath
}
