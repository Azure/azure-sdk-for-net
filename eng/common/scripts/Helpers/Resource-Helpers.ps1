# Add 'AzsdkResourceType' member to outputs since actual output types have changed over the years.

#Requires -Modules @{ModuleName='Az.KeyVault'; ModuleVersion='3.4.1'}

function Get-PurgeableGroupResources {
  param (
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $ResourceGroupName
  )

  $purgeableResources = @()

  # Discover Managed HSMs first since they are a premium resource.
  Write-Verbose "Retrieving deleted Managed HSMs from resource group $ResourceGroupName"

  # Get any Managed HSMs in the resource group, for which soft delete cannot be disabled.
  $deletedHsms = @(Get-AzKeyVaultManagedHsm -ResourceGroupName $ResourceGroupName -ErrorAction Ignore `
    | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Managed HSM' -PassThru `
    | Add-Member -MemberType AliasProperty -Name AzsdkName -Value VaultName -PassThru)

  if ($deletedHsms) {
    Write-Verbose "Found $($deletedHsms.Count) deleted Managed HSMs to potentially purge."
    $purgeableResources += $deletedHsms
  }

  Write-Verbose "Retrieving deleted Key Vaults from resource group $ResourceGroupName"

  # Get any Key Vaults that will be deleted so they can be purged later if soft delete is enabled.
  $deletedKeyVaults = @(Get-AzKeyVault -ResourceGroupName $ResourceGroupName -ErrorAction Ignore | ForEach-Object {
      # Enumerating vaults from a resource group does not return all properties we required.
      Get-AzKeyVault -VaultName $_.VaultName -ErrorAction Ignore | Where-Object { $_.EnableSoftDelete } `
      | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Key Vault' -PassThru `
      | Add-Member -MemberType AliasProperty -Name AzsdkName -Value VaultName -PassThru
    })

  if ($deletedKeyVaults) {
    Write-Verbose "Found $($deletedKeyVaults.Count) deleted Key Vaults to potentially purge."
    $purgeableResources += $deletedKeyVaults
  }

  return $purgeableResources
}

function Get-PurgeableResources {
  $purgeableResources = @()
  $subscriptionId = (Get-AzContext).Subscription.Id

  # Discover Managed HSMs first since they are a premium resource.
  Write-Verbose "Retrieving deleted Managed HSMs from subscription $subscriptionId"

  # Get deleted Managed HSMs for the current subscription.
  $response = Invoke-AzRestMethod -Method GET -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/deletedManagedHSMs?api-version=2023-02-01" -ErrorAction Ignore
  if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300 -and $response.Content) {
    $content = $response.Content | ConvertFrom-Json

    $deletedHsms = @()
    foreach ($r in $content.value) {
      $deletedHsms += [pscustomobject] @{
        AzsdkResourceType     = 'Managed HSM'
        AzsdkName             = $r.name
        Id                    = $r.id
        Name                  = $r.name
        Location              = $r.properties.location
        DeletionDate          = $r.properties.deletionDate -as [DateTime]
        ScheduledPurgeDate    = $r.properties.scheduledPurgeDate -as [DateTime]
        EnablePurgeProtection = $r.properties.purgeProtectionEnabled
      }
    }

    if ($deletedHsms) {
      Write-Verbose "Found $($deletedHsms.Count) deleted Managed HSMs to potentially purge."
      $purgeableResources += $deletedHsms
    }
  }

  Write-Verbose "Retrieving deleted Key Vaults from subscription $subscriptionId"

  # TODO: Remove try/catch handler for Get-AzKeyVault - https://github.com/Azure/azure-sdk-tools/issues/5315
  # This is a temporary workaround since Az module >= 9.2.0 uses a more recent API
  # version than is supported in the dogfood cloud environment:
  #
  #   | The resource type 'deletedVaults' could not be found in the namespace 'Microsoft.KeyVault' for api version '2022-07-01'. The supported api-versions are
  #   | '2016-10-01,2018-02-14-preview,2018-02-14,2019-09-01,2021-04-01-preview,2021-06-01-preview,2021-10-01,2021-11-01-preview'.
  try {
    # Get deleted Key Vaults for the current subscription.
    $deletedKeyVaults = @(Get-AzKeyVault -InRemovedState `
      | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Key Vault' -PassThru `
      | Add-Member -MemberType AliasProperty -Name AzsdkName -Value VaultName -PassThru)

    if ($deletedKeyVaults) {
      Write-Verbose "Found $($deletedKeyVaults.Count) deleted Key Vaults to potentially purge."
      $purgeableResources += $deletedKeyVaults
    }
  }
  catch { }

  return $purgeableResources
}

# A filter differs from a function by teating body as -process {} instead of -end {}.
# This allows you to pipe a collection and process each item in the collection.
filter Remove-PurgeableResources {
  param (
    [Parameter(Position = 0, ValueFromPipeline = $true)]
    [object[]] $Resource,

    [Parameter()]
    [ValidateRange(1, [int]::MaxValue)]
    [int] $Timeout = 30,

    [Parameter()]
    [switch] $PassThru
  )

  if (!$Resource) {
    return
  }

  $subscriptionId = (Get-AzContext).Subscription.Id

  foreach ($r in $Resource) {
    Log "Attempting to purge $($r.AzsdkResourceType) '$($r.AzsdkName)'"
    switch ($r.AzsdkResourceType) {
      'Key Vault' {
        if ($r.EnablePurgeProtection) {
          # We will try anyway but will ignore errors.
          Write-Warning "Key Vault '$($r.VaultName)' has purge protection enabled and may not be purged until $($r.ScheduledPurgeDate)"
        }

        # Use `-AsJob` to start a lightweight, cancellable job and pass to `Wait-PurgeableResoruceJob` for consistent behavior.
        Remove-AzKeyVault -VaultName $r.VaultName -Location $r.Location -InRemovedState -Force -ErrorAction Continue -AsJob `
        | Wait-PurgeableResourceJob -Resource $r -Timeout $Timeout -PassThru:$PassThru
      }

      'Managed HSM' {
        if ($r.EnablePurgeProtection) {
          # We will try anyway but will ignore errors.
          Write-Warning "Managed HSM '$($r.Name)' has purge protection enabled and may not be purged until $($r.ScheduledPurgeDate)"
        }

        # Use `GetNewClosure()` on the `-Action` ScriptBlock to make sure variables are captured.
        Invoke-AzRestMethod -Method POST -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/locations/$($r.Location)/deletedManagedHSMs/$($r.Name)/purge?api-version=2023-02-01" -ErrorAction Ignore -AsJob `
        | Wait-PurgeableResourceJob -Resource $r -Timeout $Timeout -PassThru:$PassThru -Action {
          param ( $response )
          if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300) {
            Write-Warning "Successfully requested that Managed HSM '$($r.Name)' be purged, but may take a few minutes before it is actually purged."
          }
          elseif ($response.Content) {
            $content = $response.Content | ConvertFrom-Json
            if ($content.error) {
              $err = $content.error
              Write-Warning "Failed to deleted Managed HSM '$($r.Name)': ($($err.code)) $($err.message)"
            }
          }
        }.GetNewClosure()
      }

      default {
        Write-Warning "Cannot purge $($r.AzsdkResourceType) '$($r.AzsdkName)'. Add support to https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/scripts/Helpers/Resource-Helpers.ps1."
      }
    }
  }
}

# The Log function can be overridden by the sourcing script.
function Log($Message) {
  Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

function Wait-PurgeableResourceJob {
  param (
    [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
    $Job,

    # The resource is used for logging and to return if `-PassThru` is specified
    # so we can easily see all resources that may be in a bad state when the script has completed.
    [Parameter(Mandatory = $true)]
    $Resource,

    # Optional ScriptBlock should define params corresponding to the associated job's `Output` property.
    [Parameter()]
    [scriptblock] $Action,

    [Parameter()]
    [ValidateRange(1, [int]::MaxValue)]
    [int] $Timeout = 30,

    [Parameter()]
    [switch] $PassThru
  )

  $null = Wait-Job -Job $Job -Timeout $Timeout

  if ($Job.State -eq 'Completed' -or $Job.State -eq 'Failed') {
    $result = Receive-Job -Job $Job -ErrorAction Continue

    if ($Action) {
      $null = $Action.Invoke($result)
    }
  }
  else {
    Write-Warning "Timed out waiting to purge $($Resource.AzsdkResourceType) '$($Resource.AzsdkName)'. Cancelling job."
    $Job.Cancel()

    if ($PassThru) {
      $Resource
    }
  }
}

# Helper function for removing storage accounts with WORM that sometimes get leaked from live tests not set up to clean
# up their resource policies
function Remove-WormStorageAccounts() {
  [CmdletBinding(SupportsShouldProcess = $True)]
  param(
    [string]$GroupPrefix,
    [switch]$CI
  )

  $ErrorActionPreference = 'Stop'

  # Be a little defensive so we don't delete non-live test groups via naming convention
  # DO NOT REMOVE THIS
  # We call this script from live test pipelines as well, and a string mismatch/error could blow away
  # some static storage accounts we rely on
  if (!$groupPrefix -or ($CI -and !$GroupPrefix.StartsWith('rg-'))) {
    throw "The -GroupPrefix parameter must not be empty, or must start with 'rg-' in CI contexts"
  }

  $groups = Get-AzResourceGroup | Where-Object { $_.ResourceGroupName.StartsWith($GroupPrefix) } | Where-Object { $_.ProvisioningState -ne 'Deleting' }

  foreach ($group in $groups) {
    Write-Host "========================================="
    $accounts = Get-AzStorageAccount -ResourceGroupName $group.ResourceGroupName
    if ($accounts) {
      foreach ($account in $accounts) {
        if ($WhatIfPreference) {
          Write-Host "What if: Removing $($account.StorageAccountName) in $($account.ResourceGroupName)"
        }
        else {
          Write-Host "Removing $($account.StorageAccountName) in $($account.ResourceGroupName)"
        }

        $hasContainers = ($account.Kind -ne "FileStorage")

        # If it doesn't have containers then we can skip the explicit clean-up of this storage account
        if (!$hasContainers) { continue }

        $ctx = New-AzStorageContext -StorageAccountName $account.StorageAccountName

        $immutableBlobs = $ctx `
        | Get-AzStorageContainer `
        | Where-Object { $_.BlobContainerProperties.HasImmutableStorageWithVersioning } `
        | Get-AzStorageBlob
        try {
          foreach ($blob in $immutableBlobs) {
            Write-Host "Removing legal hold - blob: $($blob.Name), account: $($account.StorageAccountName), group: $($group.ResourceGroupName)"
            $blob | Set-AzStorageBlobLegalHold -DisableLegalHold | Out-Null
          }
        }
        catch {
          Write-Warning "User must have 'Storage Blob Data Owner' RBAC permission on subscription or resource group"
          Write-Error $_
          throw
        }
        # Sometimes we get a 404 blob not found but can still delete containers,
        # and sometimes we must delete the blob if there's a legal hold.
        # Try to remove the blob, but keep running regardless.
        $succeeded = $false
        for ($attempt = 0; $attempt -lt 2; $attempt++) {
          if ($succeeded) {
            break
          }

          try {
            Write-Host "Removing immutability policies - account: $($ctx.StorageAccountName), group: $($group.ResourceGroupName)"
            $null = $ctx | Get-AzStorageContainer | Get-AzStorageBlob | Remove-AzStorageBlobImmutabilityPolicy
          }
          catch {}

          try {
            $ctx | Get-AzStorageContainer | Get-AzStorageBlob | Remove-AzStorageBlob -Force
            $succeeded = $true
          }
          catch {
            Write-Warning "Failed to remove blobs - account: $($ctx.StorageAccountName), group: $($group.ResourceGroupName)"
            Write-Warning $_
          }
        }

        try {
          # Use AzRm cmdlet as deletion will only work through ARM with the immutability policies defined on the blobs
          $ctx | Get-AzStorageContainer | ForEach-Object { Remove-AzRmStorageContainer -Name $_.Name -StorageAccountName $ctx.StorageAccountName -ResourceGroupName $group.ResourceGroupName -Force }
        }
        catch {
          Write-Warning "Container removal failed. Ignoring the error and trying to delete the storage account."
          Write-Warning $_
        }
        Remove-AzStorageAccount -StorageAccountName $account.StorageAccountName -ResourceGroupName $account.ResourceGroupName -Force
      }
    }
    if ($WhatIfPreference) {
      Write-Host "What if: Removing resource group $($group.ResourceGroupName)"
    }
    else {
      Remove-AzResourceGroup -ResourceGroupName $group.ResourceGroupName -Force -AsJob
    }
  }
}

function SetResourceNetworkAccessRules([string]$ResourceGroupName, [array]$AllowIpRanges, [switch]$CI) {
  SetStorageNetworkAccessRules -ResourceGroupName $ResourceGroupName -AllowIpRanges $AllowIpRanges -CI:$CI
}

function SetStorageNetworkAccessRules([string]$ResourceGroupName, [array]$AllowIpRanges, [switch]$CI, [switch]$Override) {
  $clientIp = $null
  $storageAccounts = Retry { Get-AzResource -ResourceGroupName $ResourceGroupName -ResourceType "Microsoft.Storage/storageAccounts" }
  # Add client IP to storage account when running as local user. Pipeline's have their own vnet with access
  if ($storageAccounts) {
    $appliedRule = $false
    foreach ($account in $storageAccounts) {
      $properties = Get-AzStorageAccount -ResourceGroupName $ResourceGroupName -AccountName $account.Name
      $rules = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $ResourceGroupName -AccountName $account.Name

      if ($properties.AllowBlobPublicAccess) {
        Write-Host "Restricting public blob access in storage account '$($account.Name)'"
        Set-AzStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $account.Name -AllowBlobPublicAccess $false
      }

      if ($rules -and ($Override -or $rules.DefaultAction -eq "Allow")) {
        Write-Host "Restricting network rules in storage account '$($account.Name)' to deny access by default"
        Retry { Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $ResourceGroupName -Name $account.Name -DefaultAction Deny }
        if ($CI -and $env:PoolSubnet) {
          Write-Host "Enabling access to '$($account.Name)' from pipeline subnet $($env:PoolSubnet)"
          Retry { Add-AzStorageAccountNetworkRule -ResourceGroupName $ResourceGroupName -Name $account.Name -VirtualNetworkResourceId $env:PoolSubnet }
          $appliedRule = $true
        }
        elseif ($AllowIpRanges) {
          Write-Host "Enabling access to '$($account.Name)' to $($AllowIpRanges.Length) IP ranges"
          $ipRanges = $AllowIpRanges | ForEach-Object {
            @{ Action = 'allow'; IPAddressOrRange = $_ }
          }
          Retry { Update-AzStorageAccountNetworkRuleSet -ResourceGroupName $ResourceGroupName -Name $account.Name -IPRule $ipRanges | Out-Null }
          $appliedRule = $true
        }
        elseif (!$CI) {
          Write-Host "Enabling access to '$($account.Name)' from client IP"
          $clientIp ??= Retry { Invoke-RestMethod -Uri 'https://icanhazip.com/' }  # cloudflare owned ip site
          $clientIp = $clientIp.Trim()
          $ipRanges = Get-AzStorageAccountNetworkRuleSet -ResourceGroupName $ResourceGroupName -Name $account.Name
          if ($ipRanges) {
            foreach ($range in $ipRanges.IpRules) {
              if (DoesSubnetOverlap $range.IPAddressOrRange $clientIp) {
                return
              }
            }
          }
          Retry { Add-AzStorageAccountNetworkRule -ResourceGroupName $ResourceGroupName -Name $account.Name -IPAddressOrRange $clientIp | Out-Null }
          $appliedRule = $true
        }
      }
    }
    if ($appliedRule) {
      Write-Host "Sleeping for 15 seconds to allow network rules to take effect"
      Start-Sleep 15
    }
  }
}

function DoesSubnetOverlap([string]$ipOrCidr, [string]$overlapIp) {
  [System.Net.IPAddress]$overlapIpAddress = $overlapIp
  $parsed = $ipOrCidr -split '/'
  [System.Net.IPAddress]$baseIp = $parsed[0]
  if ($parsed.Length -eq 1) {
    return $baseIp -eq $overlapIpAddress
  }

  $subnet = $parsed[1]
  $subnetNum = [int]$subnet

  $baseMask = [math]::pow(2, 31)
  $mask = 0
  for ($i = 0; $i -lt $subnetNum; $i++) {
    $mask = $mask + $baseMask;
    $baseMask = $baseMask / 2
  }

  return $baseIp.Address -eq ($overlapIpAddress.Address -band ([System.Net.IPAddress]$mask).Address)
}
