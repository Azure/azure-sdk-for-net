# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

. (Join-Path $PSScriptRoot '../SampleCiHelpers.ps1')

Describe 'Strict model and dependency quota values' {
    BeforeEach {
        $script:quota = @{ name = @{ value = 'fixture-model-quota' }; currentValue = 90; limit = 100 }
    }

    It 'accepts exactly the requested remaining model capacity' {
        Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' -RequiredCapacity 10 | Should Be 10
    }

    It 'rejects insufficient model capacity' {
        $script:quota.currentValue = 91
        { Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' -RequiredCapacity 10 } | Should Throw 'Insufficient'
    }

    It 'rejects invalid numeric evidence: <Label>' -TestCases @(
        @{ Label = 'null'; Value = $null },
        @{ Label = 'negative'; Value = -1 },
        @{ Label = 'string'; Value = '90' },
        @{ Label = 'boolean'; Value = $false },
        @{ Label = 'infinity'; Value = [double]::PositiveInfinity },
        @{ Label = 'NaN'; Value = [double]::NaN }
    ) {
        param($Label, $Value)
        $script:quota.currentValue = $Value
        { Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' -RequiredCapacity 10 } | Should Throw 'Cannot verify'
    }

    It 'rejects a missing limit' {
        $script:quota.Remove('limit')
        { Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' } | Should Throw 'Cannot verify'
    }

    It 'rejects duplicate matching quota entries' {
        { Get-SampleQuotaAvailable -Usages @($script:quota, $script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' } | Should Throw 'Cannot verify'
    }

    It 'uses only the exact catalog quota name' {
        { Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'a-different-quota' `
            -Description 'fixture model quota' } | Should Throw 'Cannot verify'
    }

    It 'does not accept capacity from blocked model quota' {
        $script:quota.status = 'Blocked'
        { Get-SampleQuotaAvailable -Usages @($script:quota) -UsageName 'fixture-model-quota' `
            -Description 'fixture model quota' } | Should Throw 'status: Blocked'
    }
}

Describe 'Subscription-specific Standard dependency eligibility' {
    BeforeEach {
        $script:regionalSubscription = '11111111-1111-1111-1111-111111111111'
        $script:searchOfferings = @{ value = @(@{ regionName = 'West US 3'; skus = @(@{ name = 'standard' }) }) }
        $script:searchUsage = @{ value = @(@{ name = @{ value = 'standard' }; currentValue = 0; limit = 12; unit = 'Count' }) }
        $script:cosmosLocations = @{ value = @(@{
            name = 'West US 3'; properties = @{ isSubscriptionRegionAccessAllowedForRegular = $true }
        }) }
        $script:storageSkus = @{ value = @(@{
            name = 'Standard_ZRS'; kind = 'StorageV2'; locations = @('westus3'); restrictions = @()
        }) }
        Mock Invoke-SampleAzure {
            param($Arguments, $Sensitive)
            if (-not $Sensitive -or $Arguments[0] -cne 'rest' -or $Arguments[2] -cne 'get' -or
                $Arguments[$Arguments.IndexOf('--subscription') + 1] -cne $script:regionalSubscription) {
                throw 'Only protected read-only calls in the explicit subscription are allowed.'
            }
            $uri = $Arguments[-1]
            if ($uri -match '/Microsoft.Search/offerings\?') { return $script:searchOfferings }
            if ($uri -match '/Microsoft.Search/locations/[^/]+/usages\?') { return $script:searchUsage }
            if ($uri -match '/Microsoft.DocumentDB/locations\?') { return $script:cosmosLocations }
            if ($uri -match '/Microsoft.Storage/skus\?') { return $script:storageSkus }
            throw 'Unexpected API in regional preflight.'
        }
    }

    It 'accepts the complete bundle using only subscription-bound read-only calls' {
        @(Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3').Count | Should Be 0
        Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
    }

    It 'also supports the documented nested Search SKU shape' {
        $script:searchOfferings.value[0].skus = @(@{ sku = @{ name = 'standard' } })
        Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3'
    }

    It 'rejects Search regions with no offered S1 capacity' {
        $script:searchOfferings.value[0].skus = @()
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'not offered'
        Assert-MockCalled Invoke-SampleAzure -Times 1 -Exactly -Scope It
    }

    It 'rejects an absent region rather than using another region' {
        $script:searchOfferings.value[0].regionName = 'Elsewhere'
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'Cannot verify'
    }

    It 'rejects ambiguous Search region evidence' {
        $script:searchOfferings.value += $script:searchOfferings.value[0]
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'Cannot verify'
    }

    It 'rejects exhausted Search service quota even when S1 is offered' {
        $script:searchUsage.value[0].currentValue = 12
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'AI Search S1 service quota'
    }

    It 'requires explicit boolean Cosmos subscription access: <Label>' -TestCases @(
        @{ Label = 'denied'; Value = $false },
        @{ Label = 'missing'; Value = $null },
        @{ Label = 'string'; Value = 'true' }
    ) {
        param($Label, $Value)
        $script:cosmosLocations.value[0].properties.isSubscriptionRegionAccessAllowedForRegular = $Value
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'not allowed'
    }

    It 'rejects ambiguous Cosmos region evidence' {
        $script:cosmosLocations.value += $script:cosmosLocations.value[0]
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'Cannot verify Cosmos DB'
    }

    It 'requires the exact StorageV2 SKU in the selected region' {
        $script:storageSkus.value[0].locations = @('swedencentral')
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'Cannot verify StorageV2'
    }

    It 'rejects a restriction applying to the selected Storage region' {
        $script:storageSkus.value[0].restrictions = @(@{ type = 'Location'; values = @('West US 3') })
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'restricted'
    }

    It 'does not confuse a restriction elsewhere with a target-region restriction' {
        $script:storageSkus.value[0].restrictions = @(@{ type = 'Location'; values = @('swedencentral') })
        Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3'
    }

    It 'rejects unverifiable Storage restrictions' {
        $script:storageSkus.value[0].restrictions = @(@{ type = 'Unknown'; values = @() })
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location 'westus3' } |
            Should Throw 'restricted'
    }

    It 'rejects GRS-only evidence where the local template still deploys ZRS: <Region>' -TestCases @(
        @{ Region = 'southindia' }, @{ Region = 'westus' }
    ) {
        param($Region)
        $script:searchOfferings.value[0].regionName = $Region
        $script:cosmosLocations.value[0].name = $Region
        $script:storageSkus.value[0].name = 'Standard_GRS'
        $script:storageSkus.value[0].locations = @($Region)
        { Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location $Region } |
            Should Throw 'Cannot verify StorageV2 Standard_ZRS'
        Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
    }

    It 'checks the deployed ZRS SKU without a regional fallback: <Region>' -TestCases @(
        @{ Region = 'southindia' }, @{ Region = 'westus' }, @{ Region = 'uksouth' }
    ) {
        param($Region)
        $script:searchOfferings.value[0].regionName = $Region
        $script:cosmosLocations.value[0].name = $Region
        $script:storageSkus.value[0].locations = @($Region)
        Assert-SampleRegionAvailability -SubscriptionId $script:regionalSubscription -Location $Region
        Assert-MockCalled Invoke-SampleAzure -Times 4 -Exactly -Scope It
    }
}