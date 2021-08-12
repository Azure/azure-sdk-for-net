# Add 'AzsdkResourceType' member to outputs since actual output types have changed over the years.

function Get-PurgeableGroupResources {
    param (
        [Parameter(Mandatory=$true, Position=0)]
        [string] $ResourceGroupName
    )

    # Get any Key Vaults that will be deleted so they can be purged later if soft delete is enabled.
    Get-AzKeyVault @PSBoundParameters | ForEach-Object {
        # Enumerating vaults from a resource group does not return all properties we required.
        Get-AzKeyVault -VaultName $_.VaultName | Where-Object { $_.EnableSoftDelete } `
            | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Key Vault' -PassThru
    }

    # Get any Managed HSMs in the resource group, for which soft delete cannot be disabled.
    Get-AzKeyVaultManagedHsm @PSBoundParameters `
        | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Managed HSM' -PassThru
}

function Get-PurgeableResources {
    $subscriptionId = (Get-AzContext).Subscription.Id

    # Get deleted Key Vaults for the current subscription.
    Get-AzKeyVault -InRemovedState `
        | Add-Member -MemberType NoteProperty -Name AzsdkResourceType -Value 'Key Vault' -PassThru

    # Get deleted Managed HSMs for the current subscription.
    $response = Invoke-AzRestMethod -Method GET -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/deletedManagedHSMs?api-version=2021-04-01-preview" -ErrorAction Ignore
    if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300 -and $response.Content) {
        $content = $response.Content | ConvertFrom-Json
        foreach ($r in $content.value) {
            [pscustomobject] @{
                AzsdkResourceType = 'Managed HSM'
                Id = $r.
                Name = $r.name
                Location = $r.properties.location
                DeletionDate = $r.properties.deletionDate -as [DateTime]
                ScheduledPurgeDate = $r.properties.scheduledPurgeDate -as [DateTime]
                EnablePurgeProtection = $r.properties.purgeProtectionEnabled
            }
        }
    }
}

function Remove-PurgeableResources {
    param (
        [Parameter(Mandatory=$true, Position=0, ValueFromPipeline=$true)]
        [psobject[]] $Resource
    )

    $subscriptionId = (Get-AzContext).Subscription.Id

    foreach ($r in $Resource) {
        Log "Attempting to purge $($r.AzsdkResourceType) '$($r.VaultName)'"

        switch ($r.AzsdkResourceType) {
            'Key Vault' {
                if ($r.EnablePurgeProtection) {
                    # We will try anyway but will ignore errors
                    Write-Warning "Key Vault '$($r.VaultName)' has purge protection enabled and may not be purged for $($r.SoftDeleteRetentionInDays) days"
                }
            
                Remove-AzKeyVault -VaultName $r.VaultName -Location $r.Location -InRemovedState -Force -ErrorAction Continue
            }

            'Managed HSM' {
                if ($r.EnablePurgeProtection) {
                    # We will try anyway but will ignore errors
                    Write-Warning "Managed HSM '$($r.Name)' has purge protection enabled and may not be purged for $($r.SoftDeleteRetentionInDays) days"
                }
            
                $response = Invoke-AzRestMethod -Method POST -Path "/subscriptions/$subscriptionId/providers/Microsoft.KeyVault/locations/$($r.Location)/deletedManagedHSMs/$($r.Name)/purge?api-version=2021-04-01-preview" -ErrorAction Ignore
                if ($response.StatusCode -ge 200 -and $response.StatusCode -lt 300) {
                    Write-Warning "Successfully requested that Managed HSM '$($r.Name)' be purged, but may take a few minutes before it is actually purged."
                } elseif ($response.Content) {
                    $content = $response.Content | ConvertFrom-Json
                    if ($content.error) {
                        $err = $content.error
                        Write-Warning "Failed to deleted Managed HSM '$($r.Name)': ($($err.code)) $($err.message)"
                    }
                }
            }

            default {
                Write-Warning "Cannot purge resource type $($r.AzsdkResourceType). Add support to https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/scripts/Helpers/Resource-Helpers.ps1."
            }
        }
    }
}

# The Log function can be overridden by the sourcing script.
function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}
