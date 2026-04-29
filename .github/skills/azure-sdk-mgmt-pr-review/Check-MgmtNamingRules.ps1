<#
.SYNOPSIS
    Scans Azure Management SDK API surface files for naming rule violations.

.DESCRIPTION
    Checks all naming conventions defined in the azure-sdk-mgmt-pr-review skill:
      - Type suffix rules (Parameter, Request, Options, Response, Data, Definition, Operation, Collection)
      - Property naming (bool prefix, DateTimeOffset suffix, TTL, string-typed IDs)
      - Acronym casing
      - Contextual/ambiguous type names
      - Enum plural names
      - ListOperations methods

.PARAMETER PackagePath
    Path to the SDK package directory (e.g., sdk/compute/Azure.ResourceManager.Compute).
    Can be absolute or relative to the repo root.

.PARAMETER ApiFilePath
    Direct path to an API surface file. Overrides PackagePath-based discovery.

.PARAMETER BaselineApiFilePath
    Path to the baseline (previously released) API surface file. When provided, only violations
    on types/members that are new or changed compared to the baseline will be reported.
    This enables deterministic filtering without relying on LLM judgment.

.PARAMETER ExcludeRules
    Array of rule IDs to skip (e.g., 'SUFFIX001', 'BOOL001').

.EXAMPLE
    .\Check-MgmtNamingRules.ps1 -PackagePath sdk/compute/Azure.ResourceManager.Compute
    .\Check-MgmtNamingRules.ps1 -ApiFilePath sdk/compute/Azure.ResourceManager.Compute/api/Azure.ResourceManager.Compute.net10.0.cs
    .\Check-MgmtNamingRules.ps1 -ApiFilePath current-api.cs -BaselineApiFilePath baseline-api.cs
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $false)]
    [string]$PackagePath,

    [Parameter(Mandatory = $false)]
    [string]$ApiFilePath,

    [Parameter(Mandatory = $false)]
    [string]$BaselineApiFilePath,

    [Parameter(Mandatory = $false)]
    [string[]]$ExcludeRules = @()
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

#region --- Helpers ---

class NamingViolation {
    [string]$RuleId
    [string]$Severity     # Error, Warning
    [string]$Category
    [string]$TypeName
    [string]$MemberName
    [string]$Message
    [string]$Suggestion
    [int]$Line

    NamingViolation([string]$ruleId, [string]$severity, [string]$category,
                    [string]$typeName, [string]$memberName, [string]$message,
                    [string]$suggestion, [int]$line) {
        $this.RuleId    = $ruleId
        $this.Severity  = $severity
        $this.Category  = $category
        $this.TypeName  = $typeName
        $this.MemberName = $memberName
        $this.Message   = $message
        $this.Suggestion = $suggestion
        $this.Line      = $line
    }
}

#endregion

#region --- Resolve API file ---

if (-not $ApiFilePath -and -not $PackagePath) {
    throw "Specify either -PackagePath or -ApiFilePath."
}

if (-not $ApiFilePath) {
    # Prefer net10.0, then net8.0, then netstandard2.0
    $apiDir = Join-Path $PackagePath 'api'
    if (-not (Test-Path $apiDir)) {
        throw "API directory not found: $apiDir"
    }
    $candidates = @('net10.0', 'net8.0', 'netstandard2.0')
    foreach ($tfm in $candidates) {
        $files = @(Get-ChildItem $apiDir -Filter "*.$tfm.cs" -ErrorAction SilentlyContinue)
        if ($files.Count -gt 0) {
            $ApiFilePath = $files[0].FullName
            break
        }
    }
    if (-not $ApiFilePath) {
        $allCs = @(Get-ChildItem $apiDir -Filter '*.cs' -ErrorAction SilentlyContinue)
        if ($allCs.Count -gt 0) {
            $ApiFilePath = $allCs[0].FullName
        } else {
            throw "No API surface files found in $apiDir"
        }
    }
}

if (-not (Test-Path $ApiFilePath)) {
    throw "API file not found: $ApiFilePath"
}

Write-Host "Scanning: $ApiFilePath" -ForegroundColor Cyan
$lines = Get-Content $ApiFilePath
$totalLines = $lines.Count

# Load baseline API file for filtering (if provided)
$baselineLines = @{}
if ($BaselineApiFilePath) {
    if (-not (Test-Path $BaselineApiFilePath)) {
        throw "Baseline API file not found: $BaselineApiFilePath"
    }
    Write-Host "Baseline: $BaselineApiFilePath" -ForegroundColor Cyan
    # Store each non-empty trimmed line in a HashSet for fast lookup
    foreach ($bline in (Get-Content $BaselineApiFilePath)) {
        $trimmed = $bline.Trim()
        if ($trimmed) {
            $baselineLines[$trimmed] = $true
        }
    }
}

#endregion

#region --- Parse API surface ---

# We track: current namespace, type declarations (class/struct/enum), properties, methods.

$violations = [System.Collections.Generic.List[NamingViolation]]::new()
$currentNamespace = ''
$currentTypeName = ''
$currentTypeKind = ''   # class, struct, enum, interface
$currentBasesRaw = ''
$braceDepth = 0
$typeStartDepth = 0

# Collected type info for cross-referencing
$typeInfos = @{}  # short name -> @{ Kind; Bases; Namespace; Line }

# First pass: collect all type declarations and their base types.
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*namespace\s+([\w.]+)') {
        $currentNamespace = $Matches[1]
        continue
    }

    # Match type declarations: public partial class Foo : Bar, IBaz
    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?<kind>class|struct|enum|interface)\s+(?<name>\w+)(?:<[^>]+>)?\s*(?::\s*(?<bases>.+?))?\s*$') {
        $shortName = $Matches['name']
        $kind = $Matches['kind']
        $bases = if ($Matches['bases']) { $Matches['bases'].Trim() } else { '' }
        $typeInfos[$shortName] = @{
            Kind      = $kind
            Bases     = $bases
            Namespace = $currentNamespace
            Line      = $i + 1
        }
    }
}

# Helper: check if a type inherits from a given base (word-boundary match in bases)
function Test-InheritsFrom([string]$typeName, [string]$baseName) {
    $info = $typeInfos[$typeName]
    if (-not $info) { return $false }
    return $info.Bases -match "\b$([regex]::Escape($baseName))\b"
}

# Derive RP prefix from namespace for contextual naming checks
# e.g., Azure.ResourceManager.Compute -> "Compute"
function Get-RpPrefix([string]$ns) {
    if ($ns -match 'Azure\.ResourceManager\.(.+?)(?:\.Models)?$') {
        return $Matches[1]
    }
    return ''
}

function Get-PascalCaseTokens([string]$name) {
    if ([string]::IsNullOrWhiteSpace($name)) {
        return @()
    }

    return @([regex]::Matches($name, '[A-Z]+(?![a-z])|[A-Z]?[a-z]+|\d+') | ForEach-Object { $_.Value })
}

#endregion

#region --- Rule Checks ---

# =====================================================
# RULE: SUFFIX - Bad type name suffixes
# =====================================================
$badSuffixes = @(
    @{ Suffix = 'Parameters'; Id = 'SUFFIX001'; Suggestion = "Rename to '*Content' or '*Patch'" }
    @{ Suffix = 'Parameter';  Id = 'SUFFIX002'; Suggestion = "Rename to '*Content' or '*Patch'" }
    @{ Suffix = 'Request';    Id = 'SUFFIX003'; Suggestion = "Rename to '*Content'" }
    @{ Suffix = 'Response';   Id = 'SUFFIX005'; Suggestion = "Rename to '*Result'" }
    @{ Suffix = 'Update';     Id = 'SUFFIX010'; Suggestion = "Rename to '*Patch' (PATCH body convention) or '*Content'" }
)

foreach ($typeName in $typeInfos.Keys) {
    $info = $typeInfos[$typeName]
    if ($info.Kind -eq 'interface') { continue }

    foreach ($rule in $badSuffixes) {
        if ($typeName.EndsWith($rule.Suffix) -and $ExcludeRules -notcontains $rule.Id) {
            $violations.Add([NamingViolation]::new(
                $rule.Id, 'Error', 'Type Suffix',
                $typeName, '',
                "Type '$typeName' uses forbidden suffix '$($rule.Suffix)'.",
                $rule.Suggestion,
                $info.Line
            ))
        }
    }

    # Options suffix (except ClientOptions)
    if ($typeName.EndsWith('Options') -and $typeName -ne 'ClientOptions' -and
        -not (Test-InheritsFrom $typeName 'ClientPipelineOptions') -and
        -not (Test-InheritsFrom $typeName 'ClientOptions') -and
        $ExcludeRules -notcontains 'SUFFIX004') {
        $violations.Add([NamingViolation]::new(
            'SUFFIX004', 'Error', 'Type Suffix',
            $typeName, '',
            "Type '$typeName' uses suffix 'Options'. This suffix is reserved for ClientOptions subclasses.",
            "Rename to '*Config'.",
            $info.Line
        ))
    }

    # Data suffix (except ResourceData/TrackedResourceData derivatives)
    if ($typeName.EndsWith('Data') -and $info.Kind -eq 'class' -and
        -not (Test-InheritsFrom $typeName 'ResourceData') -and
        -not (Test-InheritsFrom $typeName 'TrackedResourceData') -and
        $ExcludeRules -notcontains 'SUFFIX006') {
        $violations.Add([NamingViolation]::new(
            'SUFFIX006', 'Warning', 'Type Suffix',
            $typeName, '',
            "Type '$typeName' uses suffix 'Data' but does not inherit ResourceData/TrackedResourceData.",
            "Remove 'Data' suffix or rename.",
            $info.Line
        ))
    }

    # Definition suffix
    if ($typeName.EndsWith('Definition') -and $ExcludeRules -notcontains 'SUFFIX007') {
        $violations.Add([NamingViolation]::new(
            'SUFFIX007', 'Warning', 'Type Suffix',
            $typeName, '',
            "Type '$typeName' uses suffix 'Definition'. Remove unless needed to avoid conflict with another resource.",
            "Remove 'Definition' suffix.",
            $info.Line
        ))
    }

    # Operation suffix (except Operation<T> derivatives)
    if ($typeName.EndsWith('Operation') -and $info.Kind -eq 'class' -and
        -not (Test-InheritsFrom $typeName 'Operation') -and
        $ExcludeRules -notcontains 'SUFFIX008') {
        $violations.Add([NamingViolation]::new(
            'SUFFIX008', 'Warning', 'Type Suffix',
            $typeName, '',
            "Type '$typeName' uses suffix 'Operation' but does not inherit Operation<T>.",
            "Rename to '*Data' or '*Info'.",
            $info.Line
        ))
    }

    # Collection suffix (except ArmCollection derivatives and well-known domain terms)
    $domainCollections = @('MongoDBCollection', 'CosmosDBSqlCollection', 'CassandraCollection')
    if ($typeName.EndsWith('Collection') -and $info.Kind -eq 'class' -and
        -not (Test-InheritsFrom $typeName 'ArmCollection') -and
        -not ($domainCollections | Where-Object { $typeName.EndsWith($_) }) -and
        $ExcludeRules -notcontains 'SUFFIX009') {
        $violations.Add([NamingViolation]::new(
            'SUFFIX009', 'Warning', 'Type Suffix',
            $typeName, '',
            "Type '$typeName' uses suffix 'Collection' but does not inherit ArmCollection.",
            "Rename to '*Group' or '*List'.",
            $info.Line
        ))
    }
}

# =====================================================
# RULE: BOOL - Boolean properties must start with Is/Can/Has
# =====================================================
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    # Match bool/bool? properties
    if ($currentTypeName -and $ExcludeRules -notcontains 'BOOL001' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*(?:bool|System\.Boolean)(\?)?\s+(\w+)\s*\{') {
        $propName = $Matches[2]
        if ($propName -notmatch '^(Is|Can|Has|Does|Should|Allow|Enable|Disable|Use|Support)') {
            $violations.Add([NamingViolation]::new(
                'BOOL001', 'Error', 'Property Naming',
                $currentTypeName, $propName,
                "Boolean property '$propName' does not start with a verb prefix (Is, Can, Has, Does, Should, Allow, Enable, Disable, Use, Support).",
                "Rename to 'Is$propName', 'Can$propName', 'Has$propName', or another accepted verb prefix.",
                $i + 1
            ))
        }
    }
}

# =====================================================
# RULE: DATE - DateTimeOffset properties should end with "On"
# =====================================================
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    if ($currentTypeName -and $ExcludeRules -notcontains 'DATE001' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*System\.DateTimeOffset(\?)?\s+(\w+)\s*\{') {
        $propName = $Matches[2]
        if ($propName -notmatch 'On$' -and $propName -notmatch 'At$') {
            $violations.Add([NamingViolation]::new(
                'DATE001', 'Warning', 'Property Naming',
                $currentTypeName, $propName,
                "DateTimeOffset property '$propName' does not end with 'On'.",
                "Rename to '${propName}On' (e.g., 'CreatedOn', 'ExpireOn').",
                $i + 1
            ))
        }
    }
}

# =====================================================
# RULE: TYPE - String-typed properties that should use strong types
# =====================================================
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    if (-not $currentTypeName) { continue }

    # string properties ending in "Id" that might be ARM resource IDs -> ResourceIdentifier
    # Focus on properties explicitly named *ResourceId or containing known ARM patterns
    if ($ExcludeRules -notcontains 'TYPE001' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*string\s+(\w+)\s*\{') {
        $propName = $Matches[1]
        # Known non-ARM IDs to exclude
        $nonArmIdPatterns = @(
            'ClientId', 'TenantId', 'ObjectId', 'PrincipalId', 'ApplicationId',
            'AppId', 'SessionId', 'CorrelationId', 'RequestId', 'TrackingId',
            'UniqueId', 'RunId', 'JobId', 'TaskId', 'OperationId', 'TransactionId',
            'ReservationId', 'InstanceId', 'LeaseId', 'SequenceId', 'MessageId',
            'PublisherId', 'OfferId', 'PlanId', 'SkuId', 'ImageId', 'OAuthId'
        )
        if ($propName -cmatch 'ResourceId$' -and $propName -notin $nonArmIdPatterns) {
            $violations.Add([NamingViolation]::new(
                'TYPE001', 'Warning', 'Type Formatting',
                $currentTypeName, $propName,
                "String property '$propName' ends with 'ResourceId' and likely holds an ARM resource ID. It should be typed as ResourceIdentifier.",
                "Change type to Azure.Core.ResourceIdentifier.",
                $i + 1
            ))
        }
    }

    # string etag property -> should be ETag
    if ($ExcludeRules -notcontains 'TYPE002' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*string\s+(ETag|Etag|ETagValue)\s*\{') {
        $propName = $Matches[1]
        $violations.Add([NamingViolation]::new(
            'TYPE002', 'Error', 'Type Formatting',
            $currentTypeName, $propName,
            "Property '$propName' is typed as string but should use the ETag type.",
            "Change type to Azure.ETag.",
            $i + 1
        ))
    }

    # string location/Location property -> should consider AzureLocation
    # Only match 'Location' as a PascalCase word (capital L), not as a suffix of words like
    # Allocation, Deallocation, Collocation, Relocation where 'location' is lowercase.
    if ($ExcludeRules -notcontains 'TYPE003' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*string\s+(\w*Location)\s*\{') {
        $propName = $Matches[1]
        # Exclude words where "location" is part of a different English word (lowercase 'l')
        if ($propName -cnotmatch '[a-z]location') {
            $violations.Add([NamingViolation]::new(
                'TYPE003', 'Warning', 'Type Formatting',
                $currentTypeName, $propName,
                "String property '$propName' may represent an Azure location and should use AzureLocation type.",
                "Change type to Azure.Core.AzureLocation.",
                $i + 1
            ))
        }
    }
}

# =====================================================
# RULE: ACRONYM - Multi-letter acronyms should be PascalCase
# =====================================================
# Common acronyms that should NOT appear in ALL-CAPS form inside identifiers
$acronymPatterns = @(
    @{ AllCaps = 'HTTP';  PascalCase = 'Http';  Id = 'ACRONYM001' }
    @{ AllCaps = 'HTTPS'; PascalCase = 'Https'; Id = 'ACRONYM001' }
    @{ AllCaps = 'TCP';   PascalCase = 'Tcp';   Id = 'ACRONYM001' }
    @{ AllCaps = 'UDP';   PascalCase = 'Udp';   Id = 'ACRONYM001' }
    @{ AllCaps = 'SSL';   PascalCase = 'Ssl';   Id = 'ACRONYM001' }
    @{ AllCaps = 'TLS';   PascalCase = 'Tls';   Id = 'ACRONYM001' }
    @{ AllCaps = 'AES';   PascalCase = 'Aes';   Id = 'ACRONYM001' }
    @{ AllCaps = 'CPU';   PascalCase = 'Cpu';   Id = 'ACRONYM001' }
    @{ AllCaps = 'GPU';   PascalCase = 'Gpu';   Id = 'ACRONYM001' }
    @{ AllCaps = 'URL';   PascalCase = 'Url';   Id = 'ACRONYM001' }
    @{ AllCaps = 'URI';   PascalCase = 'Uri';   Id = 'ACRONYM001' }
    @{ AllCaps = 'API';   PascalCase = 'Api';   Id = 'ACRONYM001' }
    @{ AllCaps = 'DNS';   PascalCase = 'Dns';   Id = 'ACRONYM001' }
    @{ AllCaps = 'VPN';   PascalCase = 'Vpn';   Id = 'ACRONYM001' }
    @{ AllCaps = 'NAT';   PascalCase = 'Nat';   Id = 'ACRONYM001' }
    @{ AllCaps = 'NFS';   PascalCase = 'Nfs';   Id = 'ACRONYM001' }
    @{ AllCaps = 'SKU';   PascalCase = 'Sku';   Id = 'ACRONYM001' }
    @{ AllCaps = 'SSD';   PascalCase = 'Ssd';   Id = 'ACRONYM001' }
    @{ AllCaps = 'HDD';   PascalCase = 'Hdd';   Id = 'ACRONYM001' }
    @{ AllCaps = 'NIC';   PascalCase = 'Nic';   Id = 'ACRONYM001' }
    @{ AllCaps = 'SSH';   PascalCase = 'Ssh';   Id = 'ACRONYM001' }
    @{ AllCaps = 'SQL';   PascalCase = 'Sql';   Id = 'ACRONYM001' }
    @{ AllCaps = 'AAD';   PascalCase = 'Aad';   Id = 'ACRONYM001' }
)

# NOTE: Potential future enhancement: consider enforcing "ID" -> "Id" and "VM" -> "Vm"
#       with appropriate exceptions (e.g., when standalone or after a lowercase letter).

foreach ($typeName in $typeInfos.Keys) {
    $info = $typeInfos[$typeName]
    if ($ExcludeRules -contains 'ACRONYM001') { continue }

    foreach ($acr in $acronymPatterns) {
        # Check if the ALL-CAPS version appears as a substring in the type name
        # but not as the PascalCase version.
        # The lookahead ensures we match the end of the all-caps run: next char must be
        # uppercase-then-lowercase (new PascalCase word), non-letter, or end-of-string.
        # This prevents "HTTP" from matching inside "HTTPS".
        if ($typeName -cmatch "(?<![A-Z])$($acr.AllCaps)(?=[A-Z][a-z]|[^a-zA-Z]|$)") {
            $violations.Add([NamingViolation]::new(
                $acr.Id, 'Error', 'Acronym Casing',
                $typeName, '',
                "Type '$typeName' contains '$($acr.AllCaps)' in all-caps. Use PascalCase '$($acr.PascalCase)' instead.",
                "Rename '$($acr.AllCaps)' to '$($acr.PascalCase)' in the type name.",
                $info.Line
            ))
        }
    }
}

# Also scan property names and enum members for acronym issues
# NOTE: The acronym regex may produce rare false positives on names that coincidentally
# contain the letter sequence (e.g., NIC check could flag "UnicodeProperty"). These cases
# are unlikely in Azure SDK naming but worth being aware of.
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct|enum)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    if (-not $currentTypeName -or $ExcludeRules -contains 'ACRONYM001') { continue }

    # Extract property or enum member name
    $memberName = $null
    if ($line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*\S+\s+(\w+)\s*\{') {
        $memberName = $Matches[1]
    } elseif ($line -match '^\s*(\w+)\s*=\s*') {
        # enum member
        $memberName = $Matches[1]
    }

    if ($memberName) {
        foreach ($acr in $acronymPatterns) {
            if ($memberName -cmatch "(?<![A-Z])$($acr.AllCaps)(?=[A-Z][a-z]|[^a-zA-Z]|$)") {
                $violations.Add([NamingViolation]::new(
                    'ACRONYM001', 'Error', 'Acronym Casing',
                    $currentTypeName, $memberName,
                    "Member '$memberName' contains '$($acr.AllCaps)' in all-caps. Use PascalCase '$($acr.PascalCase)'.",
                    "Rename '$($acr.AllCaps)' to '$($acr.PascalCase)' in the member name.",
                    $i + 1
                ))
            }
        }
    }
}

# =====================================================
# RULE: ACRONYM002 - Generic 3+ letter all-caps run inside a type name
# Catches NNI, IPV, BFD, etc. that aren't in the curated list above.
# Only flags when the run is followed by a PascalCase-style boundary
# (next char is uppercase-then-lowercase or a digit). All-caps runs at the
# very end of an identifier are intentionally NOT flagged here, because we
# can't tell from the name alone whether the trailing run is a meaningful
# acronym or a wholly capitalised single token.
# =====================================================
foreach ($typeName in $typeInfos.Keys) {
    if ($ExcludeRules -contains 'ACRONYM002') { continue }
    $info = $typeInfos[$typeName]
    foreach ($m in [regex]::Matches($typeName, '(?<![A-Z])[A-Z]{3,}(?=[A-Z][a-z]|\d)')) {
        $val = $m.Value
        # skip already-handled curated acronyms
        if ($acronymPatterns | Where-Object { $_.AllCaps -eq $val }) { continue }
        $pascal = $val.Substring(0,1) + $val.Substring(1).ToLowerInvariant()
        $renamed = $typeName.Substring(0, $m.Index) + $pascal + $typeName.Substring($m.Index + $m.Length)
        $violations.Add([NamingViolation]::new(
            'ACRONYM002', 'Warning', 'Acronym Casing',
            $typeName, '',
            "Type '$typeName' contains the all-caps run '$val'. .NET conventions require 3+ letter acronyms to be PascalCase.",
            "Rename to '$renamed'.",
            $info.Line
        )) | Out-Null
    }
}

# =====================================================
# RULE: ARMCOMMON - Do not redefine ARM common types
# =====================================================
$armCommonTypes = @{
    'OperationStatusResult'         = 'Use Azure.ResourceManager.Models.ArmOperationStatus / ArmOperation pattern instead of redefining.'
    'ManagedServiceIdentity'        = 'Use Azure.ResourceManager.Models.ManagedServiceIdentity from Azure.ResourceManager.'
    'ManagedServiceIdentityType'    = 'Use Azure.ResourceManager.Models.ManagedServiceIdentityType from Azure.ResourceManager.'
    'ManagedServiceIdentityPatch'   = 'Reuse the patch model from Azure.ResourceManager rather than redefining.'
    'TagsUpdate'                    = 'Use the Tags update pattern provided by Azure.ResourceManager (or rename to a service-prefixed *Patch model that only carries Tags).'
    'TagsPatch'                     = 'Use the Tags update pattern provided by Azure.ResourceManager.'
    'ErrorResponse'                 = 'Use Azure.ResponseError; do not redefine ErrorResponse on the public surface.'
    'ErrorDetail'                   = 'Use Azure.ResponseError / ErrorDetail from Azure.ResourceManager.Models; do not redefine.'
    'UserAssignedIdentity'          = 'Use Azure.ResourceManager.Models.UserAssignedIdentity.'
    'SystemData'                    = 'SystemData is exposed via ResourceData.SystemData; do not redefine.'
    'TrackedResource'               = 'Inherit TrackedResourceData instead of defining a new TrackedResource model.'
}
foreach ($typeName in $typeInfos.Keys) {
    if ($ExcludeRules -contains 'ARMCOMMON001') { continue }
    if ($armCommonTypes.ContainsKey($typeName)) {
        $info = $typeInfos[$typeName]
        $violations.Add([NamingViolation]::new(
            'ARMCOMMON001', 'Error', 'ARM Common Type',
            $typeName, '',
            "Type '$typeName' duplicates an ARM common type. $($armCommonTypes[$typeName])",
            "Remove this type and reuse the corresponding type from Azure.ResourceManager / Azure.Core.",
            $info.Line
        )) | Out-Null
    }
}

# =====================================================
# RULE: RESINFIX - 'Resource' before Data/Collection suffix
# =====================================================
foreach ($typeName in $typeInfos.Keys) {
    if ($ExcludeRules -contains 'RESINFIX001') { continue }
    $info = $typeInfos[$typeName]
    if (($typeName -like '*ResourceData' -or $typeName -like '*ResourceCollection') -and
        $typeName -notlike '*PrivateLinkResource*') {
        $renamed = $typeName -replace 'Resource(Data|Collection)$','$1'
        $violations.Add([NamingViolation]::new(
            'RESINFIX001', 'Warning', 'Resource Infix',
            $typeName, '',
            "Type '$typeName' includes 'Resource' before '$($typeName -replace '.*Resource','')'. Mgmt convention drops the 'Resource' infix on Data/Collection types (PrivateLinkResource is the only exception).",
            "Rename to '$renamed'.",
            $info.Line
        )) | Out-Null
    }
}

# =====================================================
# Contextual / generic naming is intentionally NOT enforced by this script.
# =====================================================
# Naming context is too case-by-case to encode reliably in regex/allowlists -
# any rule we tried was either too noisy (flagging legitimate ARM patterns) or
# too narrow (missing real offenders). Reviewers (human or AI) make this call
# based on the type's role in the API and the surrounding namespace, guided by
# the "Contextual Naming for Types" section in SKILL.md.

# =====================================================
# RULE: ENUM - Plural enum names should be singular
# =====================================================
foreach ($typeName in $typeInfos.Keys) {
    $info = $typeInfos[$typeName]
    if ($info.Kind -ne 'enum') { continue }
    if ($ExcludeRules -contains 'ENUM001') { continue }

    # Detect Flags enums heuristically: API surface files (api/*.cs) do not include
    # attribute annotations like [Flags], so we cannot check for the attribute directly.
    # Instead, check if the enum member values are powers of 2 (0, 1, 2, 4, 8, ...),
    # which strongly indicates a flags enum.
    $lineIdx = $info.Line - 1  # 0-based
    $hasFlagsAttr = $false

    # Scan forward from the enum declaration to collect member values
    $enumValues = @()
    for ($j = $lineIdx + 1; $j -lt $totalLines; $j++) {
        $eline = $lines[$j]
        if ($eline -match '^\s*\}') { break }
        if ($eline -match '^\s*\w+\s*=\s*(-?\d+)') {
            $enumValues += [long]$Matches[1]
        }
    }
    # A flags enum typically has at least 2 members with values that are all powers of 2 (or 0)
    if ($enumValues.Count -ge 2) {
        $allPowersOfTwo = $true
        foreach ($val in $enumValues) {
            if ($val -lt 0) { $allPowersOfTwo = $false; break }
            if ($val -ne 0 -and ($val -band ($val - 1)) -ne 0) {
                $allPowersOfTwo = $false
                break
            }
        }
        if ($allPowersOfTwo) {
            $hasFlagsAttr = $true
        }
    }

    if (-not $hasFlagsAttr -and $typeName -match 's$' -and $typeName -notmatch '(ss|us|is|as|os|Status|Access|Address|Series|Alias|Atlas|Chaos|Canvas)$') {
        $violations.Add([NamingViolation]::new(
            'ENUM001', 'Warning', 'Enum Naming',
            $typeName, '',
            "Enum '$typeName' has a plural name. Non-[Flags] enums should use singular names.",
            "Rename to singular form.",
            $info.Line
        ))
    }
}

# =====================================================
# RULE: METHOD - ListOperations methods should be removed
# =====================================================
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    if ($currentTypeName -and $ExcludeRules -notcontains 'METHOD001' -and
        $line -match '\s+(ListOperations|ListOperationsAsync)\s*\(') {
        $methodName = $Matches[1]
        $violations.Add([NamingViolation]::new(
            'METHOD001', 'Error', 'Method',
            $currentTypeName, $methodName,
            "Method '$methodName' should be removed. SDK exposes operations via public APIs.",
            "Remove this method.",
            $i + 1
        ))
    }
}

# =====================================================
# RULE: TTL - TTL properties should be TimeToLiveIn<Unit>
# =====================================================
$currentTypeName = ''
for ($i = 0; $i -lt $totalLines; $i++) {
    $line = $lines[$i]

    if ($line -match '^\s*public\s+(?:partial\s+|abstract\s+|static\s+|sealed\s+)*(?:class|struct)\s+(\w+)') {
        $currentTypeName = $Matches[1]
        continue
    }

    if ($currentTypeName -and $ExcludeRules -notcontains 'TTL001' -and
        $line -match '^\s*public\s+(?:(?:new|override|virtual|abstract|static|sealed)\s+)*\S+\s+(\w*(?:Ttl|TTL)\w*)\s*\{') {
        $propName = $Matches[1]
        # Exclude false positives like "Throttle" containing "ttl"
        if ($propName -notmatch 'Throttle|Bottl|Settle|Little|Battle|Cattle|Subtle' -and
            $propName -notmatch 'TimeToLiveIn') {
            $violations.Add([NamingViolation]::new(
                'TTL001', 'Warning', 'Property Naming',
                $currentTypeName, $propName,
                "TTL property '$propName' should follow the 'TimeToLiveIn<Unit>' naming pattern.",
                "Rename to 'TimeToLiveInSeconds' or similar.",
                $i + 1
            ))
        }
    }
}

#endregion

#region --- Baseline Filtering ---

# If a baseline API file was provided, filter out violations for types/members that
# existed unchanged in the baseline. This ensures only new or changed API surface is reported.
if ($BaselineApiFilePath -and $baselineLines.Count -gt 0) {
    $filteredViolations = [System.Collections.Generic.List[NamingViolation]]::new()
    foreach ($v in $violations) {
        # For type-level violations, check if the type declaration line exists in baseline
        # For member-level violations, check if the member line exists in baseline
        $violationLine = $lines[$v.Line - 1].Trim()
        if (-not $baselineLines.ContainsKey($violationLine)) {
            $filteredViolations.Add($v)
        }
    }
    $removedCount = $violations.Count - $filteredViolations.Count
    if ($removedCount -gt 0) {
        Write-Host "Filtered out $removedCount violation(s) present in baseline." -ForegroundColor DarkGray
    }
    $violations = $filteredViolations
}

#endregion

#region --- Output ---

if ($violations.Count -eq 0) {
    Write-Host "`n✅ No naming violations found." -ForegroundColor Green
    return
}

# Group by category
$grouped = $violations | Group-Object Category | Sort-Object Name

$errorCount   = @($violations | Where-Object { $_.Severity -eq 'Error' }).Count
$warningCount = @($violations | Where-Object { $_.Severity -eq 'Warning' }).Count

Write-Host "`n========================================" -ForegroundColor Yellow
Write-Host " Naming Rule Violations Report" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Yellow
Write-Host " File: $(Split-Path $ApiFilePath -Leaf)"
Write-Host " Errors:   $errorCount" -ForegroundColor Red
Write-Host " Warnings: $warningCount" -ForegroundColor DarkYellow
Write-Host "========================================`n" -ForegroundColor Yellow

foreach ($group in $grouped) {
    Write-Host "── $($group.Name) ($($group.Count) issues) ──" -ForegroundColor Magenta
    foreach ($v in $group.Group) {
        $color = if ($v.Severity -eq 'Error') { 'Red' } else { 'DarkYellow' }
        $icon  = if ($v.Severity -eq 'Error') { '❌' } else { '⚠️' }

        $member = if ($v.MemberName) { ".$($v.MemberName)" } else { '' }
        Write-Host "  $icon [$($v.RuleId)] Line $($v.Line): $($v.TypeName)$member" -ForegroundColor $color
        Write-Host "     $($v.Message)" -ForegroundColor Gray
        Write-Host "     💡 $($v.Suggestion)" -ForegroundColor DarkCyan
        Write-Host ""
    }
}

Write-Host "----------------------------------------"
Write-Host "Total: $($violations.Count) violations ($errorCount errors, $warningCount warnings)"
Write-Host "----------------------------------------"

#endregion
