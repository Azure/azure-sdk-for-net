# Add 'AzsdkResourceType' member to outputs since actual output types have changed over the years.

#Requires -Modules @{ModuleName='Az.KeyVault'; ModuleVersion='3.4.1'}

function Get-PurgeableGroupResources {
  param (
    [Parameter(Mandatory=$true, Position=0)]
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
  $response = Invoke-AzRestMethod -Method GET -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/deletedManagedHSMs?api-version=2021-04-01-preview" -ErrorAction Ignore
  if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300 -and $response.Content) {
    $content = $response.Content | ConvertFrom-Json

    $deletedHsms = @()
    foreach ($r in $content.value) {
      $deletedHsms += [pscustomobject] @{
        AzsdkResourceType = 'Managed HSM'
        AzsdkName = $r.name
        Id = $r.id
        Name = $r.name
        Location = $r.properties.location
        DeletionDate = $r.properties.deletionDate -as [DateTime]
        ScheduledPurgeDate = $r.properties.scheduledPurgeDate -as [DateTime]
        EnablePurgeProtection = $r.properties.purgeProtectionEnabled
      }
    }

    if ($deletedHsms) {
      Write-Verbose "Found $($deletedHsms.Count) deleted Managed HSMs to potentially purge."
      $purgeableResources += $deletedHsms
    }
  }

  Write-Verbose "Retrieving deleted Key Vaults from subscription $subscriptionId"

  # Get deleted Key Vaults for the current subscription.
  $deletedKeyVaults = @(Get-AzKeyVault -InRemovedState `
    | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Key Vault' -PassThru `
    | Add-Member -MemberType AliasProperty -Name AzsdkName -Value VaultName -PassThru)

  if ($deletedKeyVaults) {
    Write-Verbose "Found $($deletedKeyVaults.Count) deleted Key Vaults to potentially purge."
    $purgeableResources += $deletedKeyVaults
  }

  return $purgeableResources
}

# A filter differs from a function by teating body as -process {} instead of -end {}.
# This allows you to pipe a collection and process each item in the collection.
filter Remove-PurgeableResources {
  param (
    [Parameter(Position=0, ValueFromPipeline=$true)]
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
          Write-Warning "Key Vault '$($r.VaultName)' has purge protection enabled and may not be purged for $($r.SoftDeleteRetentionInDays) days"
        }

        # Use `-AsJob` to start a lightweight, cancellable job and pass to `Wait-PurgeableResoruceJob` for consistent behavior.
        Remove-AzKeyVault -VaultName $r.VaultName -Location $r.Location -InRemovedState -Force -ErrorAction Continue -AsJob `
          | Wait-PurgeableResourceJob -Resource $r -Timeout $Timeout -PassThru:$PassThru
      }

      'Managed HSM' {
        if ($r.EnablePurgeProtection) {
          # We will try anyway but will ignore errors.
          Write-Warning "Managed HSM '$($r.Name)' has purge protection enabled and may not be purged for $($r.SoftDeleteRetentionInDays) days"
        }

        # Use `GetNewClosure()` on the `-Action` ScriptBlock to make sure variables are captured.
        Invoke-AzRestMethod -Method POST -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/locations/$($r.Location)/deletedManagedHSMs/$($r.Name)/purge?api-version=2021-04-01-preview" -ErrorAction Ignore -AsJob `
          | Wait-PurgeableResourceJob -Resource $r -Timeout $Timeout -PassThru:$PassThru -Action {
              param ( $response )
              if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300) {
                Write-Warning "Successfully requested that Managed HSM '$($r.Name)' be purged, but may take a few minutes before it is actually purged."
              } elseif ($response.Content) {
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
    [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
    $Job,

    # The resource is used for logging and to return if `-PassThru` is specified
    # so we can easily see all resources that may be in a bad state when the script has completed.
    [Parameter(Mandatory=$true)]
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
  } else {
    Write-Warning "Timed out waiting to purge $($Resource.AzsdkResourceType) '$($Resource.AzsdkName)'. Cancelling job."
    $Job.Cancel()

    if ($PassThru) {
      $Resource
    }
  }
}
