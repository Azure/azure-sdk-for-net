# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Shared identity resolution from a resource group before mutation' {
    BeforeEach {
        $script:identityGroup = 'rg-azsdk-identities-westus3-102826_164519'
        $script:resolutionPlan = @{
            schemaVersion = 1; definitionId = $(if ($env:SYSTEM_DEFINITIONID) { $env:SYSTEM_DEFINITIONID } else { '8392' })
            buildId = $(if ($env:BUILD_BUILDID) { $env:BUILD_BUILDID } else { '12345' }); jobAttempt = '1'; queueName = 'q1'
            subscriptionId = '11111111-1111-1111-1111-111111111111'; tenantId = '22222222-2222-2222-2222-222222222222'
            ownerToken = '0123456789abcdef0123456789abcdef'; identityResourceGroup = $script:identityGroup
            identityResolution = 'Pending'; sharedIdentities = @{}; location = ''
        }
        $script:resolutionPlan.resourceGroup = 'azsdk-samples-{0}-{1}-q1-1-01234567' -f $script:resolutionPlan.definitionId,$script:resolutionPlan.buildId
        $script:metadataIdentities = @(foreach ($purpose in @('project','account','search','function')) {
            @{
                id = "/subscriptions/$($script:resolutionPlan.subscriptionId)/resourcegroups/$($script:identityGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mi-azsdk-sample-${purpose}-westus3-102826_164519"
                name = "mi-azsdk-sample-${purpose}-westus3-102826_164519"; type = 'Microsoft.ManagedIdentity/userAssignedIdentities'; location = 'westus3'
                properties = @{ tenantId = $script:resolutionPlan.tenantId; principalId = [guid]::NewGuid().ToString() }
                tags = @{ purpose = 'azsdk-sample-identities'; 'sample-ci-retention' = 'permanent'; 'sample-ci-owner' = 'abcdef0123456789abcdef0123456789'; 'sample-ci-identity' = $purpose }
            }
        })
        $script:resolutionNextLink = $null
        $script:listUri = "https://management.azure.com/subscriptions/$($script:resolutionPlan.subscriptionId)/resourceGroups/$($script:identityGroup)/providers/Microsoft.ManagedIdentity/userAssignedIdentities"
        Mock Invoke-SampleAzure {
            param($Arguments,$Sensitive)
            if (-not $Sensitive -or $Arguments[0] -cne 'rest' -or $Arguments[2] -cne 'get' -or
                $Arguments[4] -cne $script:resolutionPlan.subscriptionId -or
                $Arguments[6] -cne ($script:listUri + '?api-version=2023-01-31')) { throw 'Only protected identity-group listing GETs are allowed.' }
            return @{ value = $script:metadataIdentities; nextLink = $script:resolutionNextLink }
        }
    }

    It 'binds the -purpose- identities found in the resource group without changing the pending intent' {
        $original = $script:resolutionPlan | ConvertTo-Json -Depth 20 -Compress
        $resolved = Resolve-SampleIdentitySelection -Plan $script:resolutionPlan
        $resolved.identityResolution | Should BeExactly 'Resolved'
        $resolved.location | Should BeExactly 'westus3'
        $resolved.sharedIdentities.Count | Should Be 4
        foreach ($identity in $script:metadataIdentities) {
            $purpose = $identity.tags['sample-ci-identity']
            $resolved.sharedIdentities[$purpose] | Should BeExactly $identity.id
            $resolved.identityPrincipalIds[$purpose] | Should BeExactly $identity.properties.principalId
        }
        ($script:resolutionPlan | ConvertTo-Json -Depth 20 -Compress) | Should BeExactly $original
        Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
    }

    It 'fails closed for missing, duplicate or untrusted metadata: <Fault>' -TestCases @(
        @{ Fault = 'missing' }, @{ Fault = 'duplicate' }, @{ Fault = 'different group' }, @{ Fault = 'different subscription' },
        @{ Fault = 'different tenant' }, @{ Fault = 'mixed region' }, @{ Fault = 'mixed owner' }, @{ Fault = 'wrong purpose' },
        @{ Fault = 'zero principal' }, @{ Fault = 'malformed principal' }, @{ Fault = 'foreign pagination' }, @{ Fault = 'cycle' },
        @{ Fault = 'wrong API pagination' }, @{ Fault = 'filtered pagination' }, @{ Fault = 'subscription-wide pagination' }
    ) {
        param($Fault)
        switch ($Fault) {
            'missing' { $script:metadataIdentities = @($script:metadataIdentities[0..2]) }
            'duplicate' { $script:metadataIdentities += $script:metadataIdentities[0] }
            'different group' { $script:metadataIdentities[1].id = $script:metadataIdentities[1].id.Replace("/$($script:identityGroup)/",'/other-rg/') }
            'different subscription' { $script:metadataIdentities[1].id = $script:metadataIdentities[1].id.Replace($script:resolutionPlan.subscriptionId,'99999999-9999-9999-9999-999999999999') }
            'different tenant' { $script:metadataIdentities[1].properties.tenantId = '99999999-9999-9999-9999-999999999999' }
            'mixed region' { $script:metadataIdentities[1].location = 'uksouth' }
            'mixed owner' { $script:metadataIdentities[1].tags['sample-ci-owner'] = '0123456789abcdef0123456789abcdef' }
            'wrong purpose' { $script:metadataIdentities[1].tags['sample-ci-identity'] = 'project' }
            'zero principal' { $script:metadataIdentities[1].properties.principalId = '00000000-0000-0000-0000-000000000000' }
            'malformed principal' { $script:metadataIdentities[1].properties.principalId = 'not-an-object-id' }
            'foreign pagination' { $script:resolutionNextLink = 'https://example.invalid/next' }
            'cycle' { $script:resolutionNextLink = "$($script:listUri)?api-version=2023-01-31" }
            'wrong API pagination' { $script:resolutionNextLink = "$($script:listUri)?api-version=2020-01-01" }
            'filtered pagination' { $script:resolutionNextLink = "$($script:listUri)?api-version=2023-01-31&`$filter=anything" }
            'subscription-wide pagination' { $script:resolutionNextLink = "https://management.azure.com/subscriptions/$($script:resolutionPlan.subscriptionId)/providers/Microsoft.ManagedIdentity/userAssignedIdentities?api-version=2023-01-31" }
        }
        { Resolve-SampleIdentitySelection -Plan $script:resolutionPlan } | Should Throw
        $script:resolutionPlan.identityResolution | Should BeExactly 'Pending'
        $script:resolutionPlan.sharedIdentities.Count | Should Be 0
        Assert-MockCalled Invoke-SampleAzure -Times 0 -Exactly -Scope It -ParameterFilter { $Arguments -contains 'create' -or $Arguments -contains 'delete' }
    }

    It 'ignores unrelated identities in the group but not an ambiguous second match' {
        $other = @{ id = $script:metadataIdentities[0].id.Replace('-project-', '-unrelated-'); name = 'mi-azsdk-sample-unrelated-westus3-102826_164519' }
        $script:metadataIdentities += $other
        $resolved = Resolve-SampleIdentitySelection -Plan $script:resolutionPlan
        $resolved.sharedIdentities.Count | Should Be 4
        $script:metadataIdentities += @{ id = $script:metadataIdentities[0].id.Replace('-project-', '-project-2-'); name = 'mi-azsdk-sample-project-2-westus3-102826_164519' }
        { Resolve-SampleIdentitySelection -Plan $script:resolutionPlan } | Should Throw 'exactly one managed identity'
    }

    It 'rejects a principal changed after admission before provisioning resources' {
        $resolved = Resolve-SampleIdentitySelection -Plan $script:resolutionPlan
        $script:metadataIdentities[0].properties.principalId = [guid]::NewGuid().ToString()
        Mock Invoke-SampleAzure {
            param($Arguments,$Sensitive)
            $identity = @($script:metadataIdentities | Where-Object { $Arguments[-1] -ceq ('https://management.azure.com' + $_.id + '?api-version=2023-01-31') })
            if ($identity.Count -ne 1 -or -not $Sensitive) { throw 'Only exact identity metadata GETs expected.' }
            return $identity[0]
        }
        { Get-SampleSharedIdentities -Plan $resolved } | Should Throw 'resolved identity generation changed'
    }
}