Param([switch] $WhatIf) 

# You can set up these values to your desired test environment,
# or leave them blank to be prompted
$subscriptionName = ""
$batchAcctName = ""
$storageAcctName = ""
$storageAcctRG = ""

# You only need to change this if testing against an environment
# other than public Azure.
$managementUrl = "https://management.azure.com/"

$promptKeys = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()"  # there are undoubtedly cleaner ways to do this, but not worth investing in for a quick setup script

function SetEnv([string] $name, [string] $value)
{
    if ($WhatIf)
    {
        [Console]::WriteLine("{0} => {1}", $name, $value)
    }
    else
    {
        [Environment]::SetEnvironmentVariable($name, $value, "User")
    }
}

function PromptSelect($resourceType, $values, $getName)
{
    if ($values.Count -le $promptKeys.Length)
    {
        # this mutates the values which is not great but should not be an issue for this script
        $choices_ = $values `
                    | foreach {$i=0} {$_ | Add-Member PromptKey ($promptKeys[$i++]) -PassThru -Force} `
                    | ForEach-Object { `
                      New-Object System.Management.Automation.Host.ChoiceDescription([String]::Format("&{0}: {1}", $_.PromptKey, $getName.Invoke($_)[0]), $getName.Invoke($_)[0])}
        $choices = [System.Management.Automation.Host.ChoiceDescription[]]($choices_)
        $selectedIndex = $host.ui.PromptForChoice("Choose the " + $resourceType + " to use", "", $choices, 0)
        $values[$selectedIndex]
    }
    else
    {
        throw "Too many " + $resourceType + " objects to prompt from - set the relevant script variable instead"
    }
}

Login-AzureRmAccount

if ([String]::IsNullOrEmpty($subscriptionName))
{
    $subs = Get-AzureRmSubscription
    $sub = PromptSelect "subscription" $subs { Param($s) $s.Name }
    $subscriptionName = $sub.Name
}
Select-AzureRmSubscription -SubscriptionName $subscriptionName

if ([String]::IsNullOrEmpty($batchAcctName))
{
    $bas = Get-AzureRmBatchAccount
    $batchAcct_ = PromptSelect "Batch account" $bas { Param($b) [String]::Format("{0}/{1}", $b.AccountName, $b.Location) }
    $batchAcct = Get-AzureRmBatchAccountKeys $batchAcct_.AccountName -ResourceGroupName $batchAcct_.ResourceGroupName
}
else
{
    $batchAcct = Get-AzureRmBatchAccountKeys $batchAcctName
}

if ([String]::IsNullOrEmpty($storageAcctName))
{
    $sas = Get-AzureRmStorageAccount
    $storageAcct = PromptSelect "Storage account" $sas { Param($s) $s.StorageAccountName }
    $storageAcctName = $storageAcct.StorageAccountName
    $storageAcctRG = $storageAcct.ResourceGroupName
}
else
{
    $storageAcct = Get-AzureRmStorageAccount $storageAcctRG $storageAcctName
}
$storageKeys = Get-AzureRmStorageAccountKey $storageAcctRG $storageAcctName
$blobEndpoint = $storageAcct.PrimaryEndpoints.Blob

SetEnv "MABOM_BatchAccountSubscriptionId" $batchAcct.Subscription
SetEnv "MABOM_BatchManagementEndpoint" $managementUrl

SetEnv "MABOM_BatchAccountName" $batchAcct.AccountName
SetEnv "MABOM_BatchAccountKey" $batchAcct.PrimaryAccountKey
SetEnv "MABOM_BatchAccountEndpoint" $batchAcct.TaskTenantUrl
SetEnv "MABOM_BatchAccountResourceGroupName" $batchAcct.ResourceGroupName

SetEnv "MABOM_StorageAccount" $storageAcctName
SetEnv "MABOM_StorageKey" $storageKeys[0].Value
SetEnv "MABOM_BlobEndpoint" $blobEndpoint
SetEnv "MABOM_StorageAccountResourceGroupName" $storageAcctRG

Write-Output ""
Write-Output "User environment variables created. These will be available only to new"
Write-Output "processes - if Visual Studio is running then restart it for them to take effect."
