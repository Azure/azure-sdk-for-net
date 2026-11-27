# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

Set-StrictMode -Version Latest

function Invoke-SampleAzure {
    [CmdletBinding()]
    param([Parameter(Mandatory)] [string[]] $Arguments, [switch] $Sensitive)

    if ($Sensitive) {
        # Capture both streams in memory. Only parsed error codes may leave a failed secret-bearing request.
        $output = & az @Arguments --only-show-errors --output json 2>&1
    } else {
        $output = & az @Arguments --only-show-errors --output json
    }
    $exitCode = $LASTEXITCODE
    if ($exitCode -ne 0) {
        $message = "Azure operation '$($Arguments[0]) $($Arguments[1])' failed (exit $exitCode)."
        if ($Sensitive) {
            $codes = @(Get-SampleAzureCliErrorCodes -Text ($output -join [Environment]::NewLine))
            if ($codes.Count -gt 0) { $message += ' ARM error codes: ' + ($codes -join ', ') + '.' }
        }
        throw $message
    }
    $text = $output -join [Environment]::NewLine
    if (-not [string]::IsNullOrWhiteSpace($text)) {
        try {
            return ($text | ConvertFrom-Json -AsHashtable -ErrorAction Stop)
        } catch {
            if ($Sensitive) { throw 'Azure operation returned invalid protected JSON; response content was suppressed.' }
            throw
        }
    }
}

function Get-SampleStandardTemplate {
    param([Parameter(Mandatory)] [string] $OutputDirectory)

    $sourceLock = Get-Content -LiteralPath (Join-Path $PSScriptRoot 'infra/standard-setup.lock.json') -Raw | ConvertFrom-Json -AsHashtable
    if ($sourceLock.repository -cne 'microsoft-foundry/foundry-samples' -or $sourceLock.commit -notmatch '^[a-f0-9]{40}$') {
        throw 'Invalid official Standard setup source pin.'
    }
    $baseUri = 'https://raw.githubusercontent.com/{0}/{1}/{2}/' -f $sourceLock.repository, $sourceLock.commit, $sourceLock.path
    $client = [Net.Http.HttpClient]::new()
    try {
        foreach ($entry in $sourceLock.files.GetEnumerator()) {
            if ($entry.Key -notmatch '^(main\.bicep|modules-standard/[a-z-]+\.bicep)$' -or $entry.Value -notmatch '^[a-f0-9]{64}$') {
                throw 'Invalid Bicep source path or checksum in the source pin.'
            }
            $bytes = $client.GetByteArrayAsync($baseUri + $entry.Key).GetAwaiter().GetResult()
            $checksum = [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($bytes)).ToLowerInvariant()
            if ($checksum -cne $entry.Value) { throw "Official Bicep source checksum mismatch: $($entry.Key)" }
            $destination = Join-Path $OutputDirectory $entry.Key
            $null = New-Item -ItemType Directory -Path (Split-Path -Parent $destination) -Force
            [IO.File]::WriteAllBytes($destination, $bytes)
        }
    } finally {
        $client.Dispose()
    }
    Write-Host ('Verified {0} official Standard setup Bicep files at commit {1}.' -f $sourceLock.files.Count, $sourceLock.commit)
    return (Join-Path $OutputDirectory 'main.bicep')
}

function Get-SampleBicepEnvironmentNames {
    param([Parameter(Mandatory)] [string] $BicepPath)

    # Text scan keeps planning offline; Test-BicepTemplates.ps1 asserts parity with the compiled template.
    $block = [regex]::Match((Get-Content -LiteralPath $BicepPath -Raw), '(?ms)^output environment object = \{\s*\r?\n(?<body>.*?)^\}')
    $names = @()
    if ($block.Success) {
        $names = @([regex]::Matches($block.Groups['body'].Value, '(?m)^  (?<name>[A-Z][A-Z0-9_]*):') |
            ForEach-Object { $_.Groups['name'].Value })
    }
    if ($names.Count -eq 0) { throw "Cannot read the 'environment' output names from '$BicepPath'." }
    return $names
}

function Get-SampleEnvironmentNames {
    $names = @(@(Get-SampleBicepEnvironmentNames -BicepPath (Join-Path $PSScriptRoot 'infra/main.bicep')) +
        @('AZURE_SUBSCRIPTION_ID', 'AZURE_TENANT_ID', 'AZURE_RESOURCE_GROUP') | Sort-Object -Unique)
    if (@($names | Where-Object { $_ -match '(^|_)(PAT|SECRET|KEY|TOKEN|PASSWORD|CREDENTIALS?)(_|$)' }).Count -gt 0) {
        throw 'Infrastructure environment outputs must not contain secret-looking bindings.'
    }
    return $names
}

function Assert-SampleEnvironment {
    param([Parameter(Mandatory)] [System.Collections.IDictionary] $Environment,
        [Parameter(Mandatory)] [string[]] $Names)

    $unexpected = @($Environment.Keys | Where-Object { $_ -cnotin $Names })
    $missing = @($Names | Where-Object {
        -not $Environment.Contains($_) -or $Environment[$_] -isnot [string] -or [string]::IsNullOrWhiteSpace($Environment[$_])
    })
    if ($unexpected.Count -gt 0 -or $missing.Count -gt 0 -or
        @($Names | Where-Object { $_ -cnotmatch '^[A-Z][A-Z0-9_]*$' -or
            $_ -match '(^|_)(PAT|SECRET|KEY|TOKEN|PASSWORD|CREDENTIALS?)(_|$)' }).Count -gt 0) {
        throw 'Deployment outputs must match the declared non-secret environment bindings; values were suppressed.'
    }
}

function Get-SampleSubscriptionId {
    param([AllowNull()] [AllowEmptyString()] [string] $SubscriptionId = $env:AZURE_SUBSCRIPTION_ID)

    if ($SubscriptionId -notmatch '^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$') {
        throw 'Set AZURE_SUBSCRIPTION_ID to the target Azure subscription GUID; no resources were changed.'
    }
    return ([guid] $SubscriptionId).ToString('D')
}

function Get-SampleTenantId {
    param([AllowNull()] [AllowEmptyString()] [string] $TenantId = $env:AZURE_TENANT_ID)

    if ($TenantId -notmatch '^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$') {
        throw 'Set AZURE_TENANT_ID to the target Azure tenant GUID; no resources were changed.'
    }
    return ([guid] $TenantId).ToString('D')
}

function Set-SampleSubscriptionContext {
    param([Parameter(Mandatory)] [hashtable] $Plan)

    $subscription = Get-SampleSubscriptionId
    $tenant = Get-SampleTenantId
    Assert-SampleRunPlan -Plan $Plan
    if ($subscription -ine $Plan.subscriptionId) {
        throw 'AZURE_SUBSCRIPTION_ID does not match the deployment plan; no resources were changed.'
    }
    if ($tenant -ine $Plan.tenantId) {
        throw 'AZURE_TENANT_ID does not match the deployment plan; no resources were changed.'
    }
    $active = Invoke-SampleAzure -Arguments @('account', 'show') -Sensitive
    if ($active['user']['type'] -ne 'servicePrincipal') {
        throw 'An authorized Azure service connection application is required, not a personal login.'
    }
    try {
        $target = Invoke-SampleAzure -Arguments @('account', 'show', '--subscription', $subscription) -Sensitive
    } catch {
        throw 'The authorized service connection cannot access AZURE_SUBSCRIPTION_ID; no resources were changed. Use an approved connection for the target subscription.'
    }
    if ($target['id'] -ine $subscription -or $target['state'] -ne 'Enabled' -or
        $target['tenantId'] -ine $tenant -or $active['tenantId'] -ine $tenant -or
        $target['user']['type'] -ne 'servicePrincipal' -or
        $target['user']['name'] -ine $active['user']['name']) {
        throw 'The target subscription must be enabled and accessible by the same application and tenant specified by AZURE_TENANT_ID; no resources were changed.'
    }
    $identity = Get-SampleRunnerIdentity -SubscriptionId $subscription
    if ($identity.tenantId -ine $tenant -or $identity.clientId -ine $target['user']['name']) {
        throw 'The target subscription application identity does not match the authorized connection; no resources were changed.'
    }
    # Select only a subscription already accessible to this application. Never log in or change identities.
    if ($active['id'] -ine $subscription) {
        $null = Invoke-SampleAzure -Arguments @('account', 'set', '--subscription', $subscription) -Sensitive
    }
    $confirmed = Invoke-SampleAzure -Arguments @('account', 'show') -Sensitive
    if ($confirmed['id'] -ine $subscription -or $confirmed['tenantId'] -ine $identity.tenantId -or
        $confirmed['user']['type'] -ne 'servicePrincipal' -or $confirmed['user']['name'] -ine $identity.clientId) {
        throw 'Could not confirm the requested subscription application identity; no resources were changed.'
    }
    Write-Host ('Subscription preflight: AZURE_SUBSCRIPTION_ID={0}; AZURE_TENANT_ID={1}.' -f $subscription, $tenant)
    return $identity
}

function Assert-SampleRunPlan {
    param([Parameter(Mandatory)] [hashtable] $Plan, [string] $QueueName = $env:SAMPLE_QUEUE_NAME)

    if ($Plan['schemaVersion'] -ne 1 -or $Plan['definitionId'] -notmatch '^\d+$' -or $Plan['buildId'] -notmatch '^\d+$' -or
        $Plan['jobAttempt'] -notmatch '^\d+$' -or $Plan['ownerToken'] -notmatch '^[a-f0-9]{32}$' -or
        $Plan['queueName'] -cnotmatch '^q[1-4]$') {
        throw 'Invalid CI run ownership metadata.'
    }
    if ($QueueName -and $QueueName -cne $Plan.queueName) {
        throw 'The deployment plan belongs to a different test queue; no resources were changed.'
    }
    $expectedName = 'azsdk-samples-{0}-{1}-{2}-{3}-{4}' -f $Plan.definitionId, $Plan.buildId, $Plan.queueName, $Plan.jobAttempt, $Plan.ownerToken.Substring(0, 8)
    if ($Plan['resourceGroup'] -cne $expectedName) {
        throw 'Resource group does not match the run-owned ephemeral naming convention.'
    }
    $null = Get-SampleSubscriptionId -SubscriptionId $Plan['subscriptionId']
    $null = Get-SampleTenantId -TenantId $Plan['tenantId']
    if ($Plan.ContainsKey('identityResourceGroup')) {
        $null = Get-SampleIdentityResourceGroup -Name $Plan['identityResourceGroup']
        if ($Plan['identityResolution'] -cnotin @('Pending', 'Resolved')) { throw 'Invalid shared identity resolution metadata.' }
        if ($Plan['identityResolution'] -ceq 'Pending') {
            if ($Plan['location'] -cne '' -or $Plan['sharedIdentities'] -isnot [System.Collections.IDictionary] -or
                $Plan.sharedIdentities.Count -ne 0) { throw 'Pending identity selection must not invent resource IDs or a region.' }
        } else {
            Assert-SampleResolvedIdentityBindings -Plan $Plan
        }
    }
    foreach ($binding in @(@('SYSTEM_DEFINITIONID', 'definitionId'), @('BUILD_BUILDID', 'buildId'))) {
        $current = [Environment]::GetEnvironmentVariable($binding[0])
        if (-not [string]::IsNullOrWhiteSpace($current) -and $current -cne [string] $Plan[$binding[1]]) {
            throw 'The deployment plan belongs to a different pipeline run.'
        }
    }
}

function Get-SampleOwnershipTags {
    param([Parameter(Mandatory)] [hashtable] $Plan)

    Assert-SampleRunPlan -Plan $Plan
    return @{
        'purpose' = 'azure-ai-projects-sample-ci'
        'sample-ci-run' = '{0}-{1}-{2}-{3}' -f $Plan.definitionId, $Plan.buildId, $Plan.queueName, $Plan.jobAttempt
        'sample-ci-owner' = $Plan.ownerToken
        'sample-ci-queue' = $Plan.queueName
    }
}

function Assert-SampleResourceGroupOwnership {
    param(
        [Parameter(Mandatory)] [hashtable] $Plan,
        [Parameter(Mandatory)] [hashtable] $ResourceGroup,
        [Parameter(Mandatory)] [string] $SubscriptionId
    )

    $expectedId = '/subscriptions/{0}/resourceGroups/{1}' -f $SubscriptionId, $Plan.resourceGroup
    if ($Plan['subscriptionId'] -ine $SubscriptionId -or $ResourceGroup['id'] -ine $expectedId -or
        $ResourceGroup['tags'] -isnot [System.Collections.IDictionary]) {
        throw 'Refusing a resource group outside the deployment state or without ownership tags.'
    }
    $tags = Get-SampleOwnershipTags -Plan $Plan
    foreach ($key in $tags.Keys) {
        if ($ResourceGroup.tags[$key] -cne $tags[$key]) {
            throw 'Refusing a resource group without all exact CI ownership tags.'
        }
    }
}

function Assert-SampleMcpPat {
    # No PAT command-line parameter, .env import, or secret-bearing return value.
    if ([string] $env:MCP_GITHUB_PAT -notmatch '^(github_pat_[A-Za-z0-9_]+|ghp_[A-Za-z0-9]+)$') {
        throw 'Set MCP_GITHUB_PAT as an ADO secret containing the complete GitHub PAT (github_pat_... or ghp_...).'
    }
}

function Get-SampleIdentityResourceGroup {
    param([AllowNull()] [AllowEmptyString()] [string] $Name)

    # Azure resource group rules: 1-90 characters, no trailing period.
    if ($Name -cnotmatch '\A[A-Za-z0-9_().-]{1,90}\z' -or $Name.EndsWith('.')) {
        throw 'Invalid shared identity resource group name; supply the existing resource group that contains the shared identities.'
    }
    return $Name
}

function Get-SampleIdentityPurposeFromName {
    param([AllowNull()] [string] $Name)

    # Identities created by Deploy-Identities.ps1 carry the purpose as a -{purpose}- name segment.
    $found = @(@('project', 'account', 'search', 'function') | Where-Object { $Name -imatch ('-{0}-' -f $_) })
    if ($found.Count -eq 1) { return $found[0] }
    return $null
}

function Assert-SampleResolvedIdentityBindings {
    param([hashtable] $Plan)

    if ($Plan['location'] -cnotmatch '\A[a-z][a-z0-9]{0,29}\z' -or
        $Plan['identityOwner'] -cnotmatch '\A[a-f0-9]{32}\z' -or
        $Plan['sharedIdentities'] -isnot [System.Collections.IDictionary] -or $Plan.sharedIdentities.Count -ne 4 -or
        $Plan['identityPrincipalIds'] -isnot [System.Collections.IDictionary] -or $Plan.identityPrincipalIds.Count -ne 4) {
        throw 'The deployment plan must bind the four bootstrap-owned shared identities and verified region.'
    }
    foreach ($purpose in @('project', 'account', 'search', 'function')) {
        $id = $Plan.sharedIdentities[$purpose]
        $binding = [regex]::Match([string]$id, '(?i)\A/subscriptions/(?<sub>[a-f0-9-]{36})/resourceGroups/(?<rg>[^/]+)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/(?<name>[^/]+)\z')
        if (-not $binding.Success -or $binding.Groups['sub'].Value -ine $Plan.subscriptionId -or
            (Get-SampleIdentityPurposeFromName -Name $binding.Groups['name'].Value) -cne $purpose -or
            $Plan.identityPrincipalIds[$purpose] -notmatch '\A[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}\z' -or
            $Plan.identityPrincipalIds[$purpose] -eq '00000000-0000-0000-0000-000000000000') { throw 'Unexpected shared identity binding.' }
        if ($binding.Groups['rg'].Value -ine $Plan.identityResourceGroup) { throw 'All shared identities must belong to the selected identity resource group.' }
    }
}

function Resolve-SampleIdentitySelection {
    param([Parameter(Mandatory)] [hashtable] $Plan)

    Assert-SampleRunPlan -Plan $Plan
    if ($Plan['identityResolution'] -cne 'Pending') { throw 'Identity selection has already been resolved; do not overwrite its bindings.' }
    $identityGroup = Get-SampleIdentityResourceGroup -Name $Plan['identityResourceGroup']
    $path = '/subscriptions/' + $Plan.subscriptionId + '/resourceGroups/' + $identityGroup + '/providers/Microsoft.ManagedIdentity/userAssignedIdentities'
    $uri = 'https://management.azure.com' + $path + '?api-version=2023-01-31'
    $all = @(); $seen = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    do {
        $parsed = [uri] $uri
        if ($parsed.Scheme -cne 'https' -or $parsed.Host -ine 'management.azure.com' -or $parsed.Port -ne 443 -or
            $parsed.UserInfo -or $parsed.Fragment -or $parsed.AbsolutePath -ine $path -or -not $seen.Add($uri) -or $seen.Count -gt 1000) {
            throw 'Unexpected identity metadata pagination target.'
        }
        $query = @{}
        foreach ($part in $parsed.Query.TrimStart('?').Split('&')) {
            $pair = $part.Split('=',2); $key = [uri]::UnescapeDataString($pair[0])
            if ($pair.Count -ne 2 -or $key -cnotin @('api-version','$skiptoken','skiptoken') -or $query.ContainsKey($key)) {
                throw 'Unexpected identity metadata pagination query.'
            }
            $query[$key] = [uri]::UnescapeDataString($pair[1])
        }
        if ($query['api-version'] -cne '2023-01-31') { throw 'Unexpected identity metadata pagination API version.' }
        $page = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $Plan.subscriptionId, '--url', $uri) -Sensitive
        if ($page -isnot [System.Collections.IDictionary] -or $page['value'] -isnot [System.Collections.IList] -or
            ($page.Contains('error') -and $null -ne $page['error']) -or
            ($null -ne $page['nextLink'] -and $page['nextLink'] -isnot [string])) { throw 'Cannot verify identity metadata listing.' }
        $all += @($page.value); $uri = [string] $page['nextLink']
    } while ($uri)
    $ids = @{}; $principals = @{}; $location = $null; $owner = $null
    foreach ($purpose in @('project', 'account', 'search', 'function')) {
        $candidates = @($all | Where-Object { $_ -is [System.Collections.IDictionary] -and (Get-SampleIdentityPurposeFromName -Name ([string] $_['name'])) -ceq $purpose })
        if ($candidates.Count -ne 1) { throw "The identity resource group must contain exactly one managed identity with a -$purpose- name segment; missing or duplicate matches are not allowed." }
        $identity = $candidates[0]
        $expectedId = '/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{2}' -f $Plan.subscriptionId, $identityGroup, $identity['name']
        if ($identity['id'] -ine $expectedId -or $identity['properties'] -isnot [System.Collections.IDictionary] -or
            $identity['tags'] -isnot [System.Collections.IDictionary] -or $identity['type'] -ine 'Microsoft.ManagedIdentity/userAssignedIdentities' -or
            $identity['properties']['tenantId'] -ine $Plan.tenantId -or $identity['location'] -cnotmatch '\A[a-z][a-z0-9]{0,29}\z' -or
            $identity['tags']['purpose'] -cne 'azsdk-sample-identities' -or $identity['tags']['sample-ci-retention'] -cne 'permanent' -or
            $identity['tags']['sample-ci-identity'] -cne $purpose -or $identity['tags']['sample-ci-owner'] -cnotmatch '\A[a-f0-9]{32}\z') {
            throw 'Cannot verify the bootstrap-owned shared identity metadata.'
        }
        if ($location -and $location -cne $identity.location) { throw 'All shared identities must have one verified region.' }
        if ($owner -and $owner -cne $identity.tags['sample-ci-owner']) { throw 'All shared identities must belong to one bootstrap-owned set.' }
        $location = $identity.location; $owner = $identity.tags['sample-ci-owner']
        $ids[$purpose] = $identity.id; $principals[$purpose] = $identity.properties.principalId
    }
    $resolved = @{} + $Plan
    $resolved.identityResolution = 'Resolved'; $resolved.location = $location
    $resolved.sharedIdentities = $ids; $resolved.identityPrincipalIds = $principals; $resolved.identityOwner = $owner
    Assert-SampleRunPlan -Plan $resolved
    return $resolved
}

function Get-SampleSharedIdentities {
    param([Parameter(Mandatory)] [hashtable] $Plan)

    Assert-SampleRunPlan -Plan $Plan
    if ($Plan['identityResolution'] -cne 'Resolved') { throw 'Resolve the shared identities from the identity resource group before provisioning.' }
    if ($Plan['sharedIdentities'] -isnot [System.Collections.IDictionary] -or $Plan.sharedIdentities.Count -ne 4) {
        throw 'The deployment plan must bind the four bootstrap-owned shared identities.'
    }
    $identities = @{}
    $identityOwner = $null
    foreach ($purpose in @('project', 'account', 'search', 'function')) {
        $expected = $Plan.sharedIdentities[$purpose]
        $identity = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $Plan.subscriptionId, '--url',
            ('https://management.azure.com{0}?api-version=2023-01-31' -f $expected)) -Sensitive
        if ($identity -isnot [System.Collections.IDictionary] -or
            $identity['properties'] -isnot [System.Collections.IDictionary] -or $identity['tags'] -isnot [System.Collections.IDictionary] -or
            $identity['id'] -ine $expected -or $identity['type'] -ine 'Microsoft.ManagedIdentity/userAssignedIdentities' -or
            $identity['location'] -cne $Plan.location -or $identity['properties']['tenantId'] -ine $Plan.tenantId -or
            $identity['properties']['principalId'] -notmatch '^[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}$' -or
            $identity['properties']['principalId'] -eq '00000000-0000-0000-0000-000000000000' -or
            $identity['tags']['purpose'] -cne 'azsdk-sample-identities' -or
            $identity['tags']['sample-ci-owner'] -cnotmatch '^[a-f0-9]{32}$' -or
            $identity['tags']['sample-ci-retention'] -cne 'permanent' -or
            $identity['tags']['sample-ci-identity'] -cne $purpose) {
            throw 'Cannot verify the bootstrap-owned shared identity; no resources were changed.'
        }
        if ($identityOwner -and $identityOwner -cne $identity.tags['sample-ci-owner']) {
            throw 'The four shared identities do not belong to one bootstrap-owned set.'
        }
        $identityOwner = $identity.tags['sample-ci-owner']
        if ($Plan.identityOwner -cne $identityOwner -or
            $Plan.identityPrincipalIds[$purpose] -ine $identity.properties.principalId) { throw 'The resolved identity generation changed; no resources were changed.' }
        $identities[$purpose] = @{ resourceId = $identity.id; principalId = $identity.properties.principalId }
    }
    return $identities
}

function Publish-SampleFunctionApp {
    param([Parameter(Mandatory)] [hashtable] $Plan,
        [Parameter(Mandatory)] [ValidatePattern('^[a-zA-Z0-9][a-zA-Z0-9-]{0,58}[a-zA-Z0-9]$')] [string] $FunctionAppName,
        [string] $SourceDirectory = (Join-Path $PSScriptRoot 'function_app'))

    Assert-SampleRunPlan -Plan $Plan
    $files = @('function_app.py', 'host.json', 'requirements.txt')
    foreach ($file in $files) {
        if (-not (Test-Path -LiteralPath (Join-Path $SourceDirectory $file) -PathType Leaf)) {
            throw "Missing Function App source file '$file'; no code was published."
        }
    }
    $zipPath = Join-Path ([IO.Path]::GetTempPath()) ('sample-function-' + [guid]::NewGuid().ToString('N') + '.zip')
    try {
        $archive = [IO.Compression.ZipFile]::Open($zipPath, [IO.Compression.ZipArchiveMode]::Create)
        try {
            foreach ($file in $files) {
                $entry = $archive.CreateEntry($file)
                $entry.LastWriteTime = [DateTimeOffset]::new(2000, 1, 1, 0, 0, 0, [TimeSpan]::Zero)
                $entryStream = $entry.Open()
                try {
                    $sourceStream = [IO.File]::OpenRead((Join-Path $SourceDirectory $file))
                    try { $sourceStream.CopyTo($entryStream) } finally { $sourceStream.Dispose() }
                } finally { $entryStream.Dispose() }
            }
        } finally { $archive.Dispose() }
        $null = Invoke-SampleAzure -Arguments @('functionapp', 'deployment', 'source', 'config-zip',
            '--name', $FunctionAppName, '--resource-group', $Plan.resourceGroup, '--subscription', $Plan.subscriptionId,
            '--src', $zipPath, '--build-remote', 'true', '--timeout', '1200') -Sensitive
        for ($attempt = 1; $attempt -le 30; $attempt++) {
            $functions = @(Invoke-SampleAzure -Arguments @('functionapp', 'function', 'list', '--name', $FunctionAppName,
                '--resource-group', $Plan.resourceGroup, '--subscription', $Plan.subscriptionId, '--query', '[].name') -Sensitive)
            if (@($functions | Where-Object { ($_ -split '/')[-1] -ceq 'queue_trigger' }).Count -eq 1) {
                return
            }
            if ($attempt -lt 30) {
                Write-Host ('Waiting for queue_trigger indexing after publication (check {0}/30).' -f $attempt)
                Start-Sleep -Seconds 10
            }
        }
        throw 'The published Function App did not index queue_trigger after 30 checks; sample execution is disabled.'
    } finally {
        if (Test-Path -LiteralPath $zipPath) { Remove-Item -LiteralPath $zipPath -Force }
    }
}

function Assert-SampleBatchCapacity {
    param([Parameter(Mandatory)] [hashtable[]] $Plans)

    if ($Plans.Count -lt 1 -or $Plans.Count -gt 4 -or @($Plans.queueName | Sort-Object -Unique).Count -ne $Plans.Count -or
        @($Plans.resourceGroup | Sort-Object -Unique).Count -ne $Plans.Count) {
        throw 'A test batch must contain one to four distinct queue plans.'
    }
    $first = $Plans[0]
    foreach ($plan in $Plans) {
        Assert-SampleRunPlan -Plan $plan -QueueName $plan.queueName
        foreach ($key in @('subscriptionId', 'tenantId', 'definitionId', 'buildId', 'location', 'identityResourceGroup')) {
            if ($plan[$key] -cne $first[$key]) { throw 'Test queues must share one explicit target and pipeline run.' }
        }
        foreach ($purpose in @('project', 'account', 'search', 'function')) {
            if ($plan['sharedIdentities'][$purpose] -cne $first['sharedIdentities'][$purpose]) {
                throw 'All test queues must use the same shared identity set.'
            }
            if ($plan.ContainsKey('identityPrincipalIds') -and
                $plan.identityPrincipalIds[$purpose] -cne $first.identityPrincipalIds[$purpose]) { throw 'All test queues must use the same verified identity generation.' }
        }
        if ($plan.ContainsKey('identityOwner') -and $plan.identityOwner -cne $first.identityOwner) { throw 'All test queues must use the same verified identity generation.' }
        if (($plan.sampleModel | ConvertTo-Json -Compress) -cne ($first.sampleModel | ConvertTo-Json -Compress)) {
            # Compare fields, not Hashtable property ordering.
            foreach ($key in @('name', 'version', 'sku', 'capacity')) {
                if ($plan.sampleModel[$key] -cne $first.sampleModel[$key]) { throw 'Test queues must use the same sample model configuration.' }
            }
        }
    }
    $leftovers = @(Invoke-SampleAzure -Arguments @('group', 'list', '--subscription', $first.subscriptionId,
        '--query', "[?tags.purpose=='azure-ai-projects-sample-ci'].{id:id,name:name}" ) -Sensitive)
    if ($leftovers.Count -gt 0) { throw 'Temporary sample RGs from another attempt still exist; reconcile cleanup before admitting another batch.' }
    Assert-SampleRegionAvailability -SubscriptionId $first.subscriptionId -Location $first.location
    $usages = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'usage', 'list', '--location', $first.location, '--subscription', $first.subscriptionId))
    $null = Get-SampleQuotaAvailable -Usages $usages -UsageName 'AccountCount' -Unit 'Count' -RequiredCapacity $Plans.Count -Description 'batch Foundry account quota'
    $searchUsage = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $first.subscriptionId, '--url',
        ('https://management.azure.com/subscriptions/{0}/providers/Microsoft.Search/locations/{1}/usages?api-version=2025-05-01' -f $first.subscriptionId, $first.location)) -Sensitive
    $null = Get-SampleQuotaAvailable -Usages @($searchUsage['value']) -UsageName 'standard' -Unit 'Count' -RequiredCapacity $Plans.Count -Description 'batch Search S1 quota'
    $catalog = @(Invoke-SampleAzure -Arguments @('cognitiveservices', 'model', 'list', '--location', $first.location, '--subscription', $first.subscriptionId))
    $model = Resolve-SampleModel -Catalog $catalog -Name $first.sampleModel.name -Version $first.sampleModel.version -Sku $first.sampleModel.sku -Capacity $first.sampleModel.capacity
    $null = Get-SampleQuotaAvailable -Usages $usages -UsageName $model.usageName -RequiredCapacity ($Plans.Count * $model.capacity) -Description 'batch sample-model quota'
    Write-Host ('Admission passed for {0} fresh RGs. No cross-run lock or capacity reservation: wait for all cleanup before another run.' -f $Plans.Count)
}

function Resolve-SampleModel {
    param(
        [Parameter(Mandatory)] [object[]] $Catalog,
        [Parameter(Mandatory)] [string] $Name,
        [Parameter(Mandatory)] [string] $Version,
        [Parameter(Mandatory)] [string] $Sku,
        [Parameter(Mandatory)] [int] $Capacity
    )

    $candidates = @($Catalog | Where-Object { $_.model.name -ceq $Name -and $_.model.format -eq 'OpenAI' })
    if ($Version -eq 'auto') {
        $versions = @($candidates | Where-Object { $_.model.isDefaultVersion } | ForEach-Object { $_.model.version } | Sort-Object -Unique)
        if ($versions.Count -ne 1) {
            throw "Cannot resolve exactly one default version of '$Name'; set an explicit model version."
        }
        $Version = $versions[0]
    }
    $skuDetails = @($candidates | Where-Object { $_.model.version -ceq $Version } | ForEach-Object { $_.model.skus } |
        Where-Object { $_.name -ceq $Sku })
    if ($skuDetails.Count -eq 0) {
        throw "Model '$Name' version '$Version' with SKU '$Sku' is unavailable in the selected region."
    }
    $limits = $skuDetails[0]['capacity']
    if ($Capacity -lt 1 -or ($null -ne $limits['minimum'] -and $Capacity -lt $limits['minimum']) -or
        ($null -ne $limits['maximum'] -and $Capacity -gt $limits['maximum']) -or
        ($null -ne $limits['step'] -and $limits['step'] -gt 0 -and ($Capacity % $limits['step']) -ne 0)) {
        throw "Capacity $Capacity does not satisfy model '$Name' SKU limits."
    }
    return @{ name = $Name; version = $Version; sku = $Sku; capacity = $Capacity; usageName = $skuDetails[0]['usageName'] }
}

function Get-SampleQuotaAvailable {
    param(
        [Parameter(Mandatory)] [AllowEmptyCollection()] [object[]] $Usages,
        [Parameter(Mandatory)] [ValidateNotNullOrEmpty()] [string] $UsageName,
        [Parameter(Mandatory)] [string] $Description,
        [ValidateRange(1, 1000000)] [int] $RequiredCapacity = 1,
        [string] $Unit = ''
    )

    $quota = @($Usages | Where-Object {
        $_ -is [System.Collections.IDictionary] -and $_['name'] -is [System.Collections.IDictionary] -and
        $_['name']['value'] -ceq $UsageName
    })
    if ($quota.Count -ne 1) {
        throw "Cannot verify $Description; no resources were created."
    }
    $usage = $quota[0]
    foreach ($key in @('currentValue', 'limit')) {
        $value = $usage[$key]
        if (($value -isnot [int] -and $value -isnot [long] -and $value -isnot [double] -and $value -isnot [decimal]) -or
            -not [double]::IsFinite([double] $value) -or $value -lt 0) {
            throw "Cannot verify $Description; no resources were created."
        }
    }
    if ($Unit -and $usage['unit'] -cne $Unit) {
        throw "Cannot verify $Description; no resources were created."
    }
    $available = $usage.limit - $usage.currentValue
    if ($available -lt $RequiredCapacity -or $usage['status'] -in @('Blocked', 'InOverage', 'Unknown')) {
        $message = 'Insufficient {0} ({1}: {2}/{3}, status: {4}).' -f `
            $Description, $UsageName, $usage.currentValue, $usage.limit, $usage['status']
        throw ($message + ' No resources were created. Choose a region with available account quota or ask an administrator to review quota; ' +
            'existing accounts will not be deleted.')
    }
    return $available
}

function Assert-SampleAccountQuota {
    param(
        [Parameter(Mandatory)] [AllowEmptyCollection()] [object[]] $Usages,
        [Parameter(Mandatory)] [string] $Location
    )

    # Account creation has a separate quota from model deployment capacity.
    $available = Get-SampleQuotaAvailable -Usages $Usages -UsageName 'AccountCount' -Unit 'Count' `
        -Description "Cognitive Services account quota in '$Location'"
    Write-Host ('Account preflight: {0}, AccountCount available slots: {1}.' -f $Location, $available)
}

function Assert-SampleRegionAvailability {
    param(
        [Parameter(Mandatory)] [string] $SubscriptionId,
        [Parameter(Mandatory)] [ValidatePattern('^[a-z0-9]+$')] [string] $Location
    )

    $subscription = Get-SampleSubscriptionId -SubscriptionId $SubscriptionId
    $root = 'https://management.azure.com'
    $scope = "$root/subscriptions/$subscription/providers"
    $offerings = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $subscription, '--url',
        "$root/providers/Microsoft.Search/offerings?api-version=2025-02-01-preview") -Sensitive
    $searchRegions = @($offerings['value'] | Where-Object { ($_['regionName'] -replace '\s', '') -ieq $Location })
    if ($searchRegions.Count -ne 1) { throw "Cannot verify AI Search offerings in '$Location'; no resources were created." }
    $searchSkus = @($searchRegions[0]['skus'] | Where-Object {
        $_['name'] -ceq 'standard' -or ($_['sku'] -and $_['sku']['name'] -ceq 'standard')
    })
    if ($searchSkus.Count -ne 1) { throw "AI Search S1 is not offered in '$Location'; no resources were created." }
    $searchUsage = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $subscription, '--url',
        "$scope/Microsoft.Search/locations/$Location/usages?api-version=2025-05-01") -Sensitive
    $null = Get-SampleQuotaAvailable -Usages @($searchUsage['value']) -UsageName 'standard' -Unit 'Count' `
        -Description "AI Search S1 service quota in '$Location'"

    $cosmosLocations = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $subscription, '--url',
        "$scope/Microsoft.DocumentDB/locations?api-version=2025-04-15") -Sensitive
    $cosmosRegions = @($cosmosLocations['value'] | Where-Object { ($_['name'] -replace '\s', '') -ieq $Location })
    if ($cosmosRegions.Count -ne 1) { throw "Cannot verify Cosmos DB regional access in '$Location'; no resources were created." }
    $access = $cosmosRegions[0]['properties']['isSubscriptionRegionAccessAllowedForRegular']
    if ($access -isnot [bool] -or -not $access) {
        throw "Cosmos DB account creation is not allowed for this subscription in '$Location'; no resources were created."
    }

    # Match the deployed local shared-identity template, not the upstream
    # reference's regional GRS fallback. Never approve a different SKU's evidence.
    $storageSku = 'Standard_ZRS'
    $storageSkus = Invoke-SampleAzure -Arguments @('rest', '--method', 'get', '--subscription', $subscription, '--url',
        "$scope/Microsoft.Storage/skus?api-version=2023-05-01") -Sensitive
    $storage = @($storageSkus['value'] | Where-Object {
        $_['name'] -ceq $storageSku -and $_['kind'] -ceq 'StorageV2' -and
        $Location -iin @($_['locations'] | ForEach-Object { $_ -replace '\s', '' })
    })
    if ($storage.Count -ne 1) { throw "Cannot verify StorageV2 $storageSku in '$Location'; no resources were created." }
    foreach ($restriction in @($storage[0]['restrictions'] | Where-Object { $null -ne $_ })) {
        $restricted = @($restriction['values'] | ForEach-Object { $_ -replace '\s', '' })
        if ($restriction['type'] -ine 'Location' -or $restricted.Count -eq 0 -or $Location -iin $restricted) {
            throw "StorageV2 $storageSku is restricted in '$Location'; no resources were created."
        }
    }
    Write-Host ('Regional dependency preflight: {0}, Search S1, Cosmos DB and StorageV2 {1} are eligible.' -f $Location, $storageSku)
}

function Get-SampleRunnerIdentity {
    param([string] $SubscriptionId = '')

    $runnerTokenResponse = $null
    $runnerAccessToken = $null
    $claims = $null
    try {
        $tokenArguments = @('account', 'get-access-token', '--resource', 'https://management.azure.com/')
        if ($SubscriptionId) { $tokenArguments += @('--subscription', (Get-SampleSubscriptionId -SubscriptionId $SubscriptionId)) }
        $runnerTokenResponse = Invoke-SampleAzure -Arguments $tokenArguments -Sensitive
        $runnerAccessToken = [string] $runnerTokenResponse.accessToken
        $payload = $runnerAccessToken.Split('.')[1].Replace('-', '+').Replace('_', '/')
        $payload = $payload.PadRight($payload.Length + ((4 - $payload.Length % 4) % 4), '=')
        $claims = [Text.Encoding]::UTF8.GetString([Convert]::FromBase64String($payload)) | ConvertFrom-Json -AsHashtable
        $clientId = if ($claims['appid']) { [string] $claims['appid'] } else { [string] $claims['azp'] }
        if ($claims['oid'] -notmatch '^[a-fA-F0-9-]{36}$' -or $claims['tid'] -notmatch '^[a-fA-F0-9-]{36}$' -or
            $clientId -notmatch '^[a-fA-F0-9-]{36}$' -or $claims['idtyp'] -notin @($null, 'app') -or $claims.ContainsKey('scp')) {
            throw 'An Azure service connection application identity is required.'
        }
        # Metadata only: never return or persist the token, authorization headers, or other claims.
        return @{ principalId = [string] $claims.oid; clientId = $clientId; tenantId = [string] $claims.tid }
    } catch {
        throw 'Could not identify the Azure service-connection application; token and raw response were suppressed.'
    } finally {
        $runnerAccessToken = $null
        $runnerTokenResponse = $null
        $claims = $null
    }
}

function Save-SampleInventory {
    param([Parameter(Mandatory)] [hashtable] $State, [Parameter(Mandatory)] [string] $OutputPath)

    $exists = Invoke-SampleAzure -Arguments @('group', 'exists', '--name', $State.plan.resourceGroup, '--subscription', $State.subscriptionId)
    $resources = @()
    if ($exists) {
        $resources = @(Invoke-SampleAzure -Arguments @('resource', 'list', '--resource-group', $State.plan.resourceGroup,
            '--subscription', $State.subscriptionId, '--query', '[].{id:id,name:name,type:type,location:location}'))
    }
    ConvertTo-Json -InputObject $resources -Depth 5 | Set-Content -LiteralPath $OutputPath -Encoding utf8
}

function Get-SampleAzureErrorCodes {
    param([AllowNull()] [object] $ErrorDetails)

    # Traverse only ARM error envelopes, never message, request, parameter or credential fields.
    $codes = @()
    if ($ErrorDetails -is [System.Collections.IDictionary]) {
        $code = $ErrorDetails['code']
        if ($code -is [string] -and $code -cmatch '^[A-Za-z][A-Za-z0-9_.-]{0,127}$' -and
            $code -notmatch '^(github_pat_|ghp_|eyJ)') {
            $codes += $code
        }
        foreach ($key in @('error', 'details')) {
            if ($ErrorDetails.Contains($key)) { $codes += @(Get-SampleAzureErrorCodes -ErrorDetails $ErrorDetails[$key]) }
        }
    } elseif ($ErrorDetails -is [System.Collections.IEnumerable] -and $ErrorDetails -isnot [string]) {
        foreach ($detail in $ErrorDetails) { $codes += @(Get-SampleAzureErrorCodes -ErrorDetails $detail) }
    }
    return @($codes | Sort-Object -Unique)
}

function Get-SampleAzureCliErrorCodes {
    param([AllowEmptyString()] [string] $Text)

    $codes = @()
    foreach ($line in ($Text -split '\r?\n')) {
        $json = $line.Trim() -replace '^ERROR:\s*', ''
        if ($json.StartsWith('{') -and $json.EndsWith('}')) {
            try {
                $details = $json | ConvertFrom-Json -AsHashtable -ErrorAction Stop
                $codes += @(Get-SampleAzureErrorCodes -ErrorDetails $details)
            } catch { }
        } elseif ($line -cmatch '^ERROR:\s*\((?<armCode>[A-Za-z][A-Za-z0-9_.-]{0,127})\)') {
            $codes += @(Get-SampleAzureErrorCodes -ErrorDetails @{ code = $Matches.armCode })
        }
    }
    return @($codes | Sort-Object -Unique)
}
