Import-Module Az.Kusto

az login

$RootDirectory = (get-item $PSScriptRoot).parent.parent
$TestResourcesDirectory = Join-Path -Path $RootDirectory -ChildPath eng\common\TestResources

$subscriptionId = az account list --query "[?name=='Kusto_Dev_Kusto_Ilay_04_Test'].id" --output tsv

& $TestResourcesDirectory\Remove-TestResources.ps1 `
    -SubscriptionId $subscriptionId `
    -ResourceGroupName 'sdkRg' `
    -Force

$appId = az ad app list --show-mine --query "[?displayName=='kusto C# sdk tests'].appId" --output tsv
$appSecret = az ad app credential reset --id $appId --years 2 --query "password" --output tsv
$applicationOId = az ad sp show --id $appId --query "id" --output tsv

& $TestResourcesDirectory\New-TestResources.ps1 `
    -SubscriptionId $subscriptionId `
    -TestApplicationId $appId `
    -TestApplicationSecret $appSecret `
    -TestApplicationOid $applicationOId `
    -ServiceDirectory 'kusto' `
    -ResourceGroupName  'sdkRg' `
    -Location 'eastus2' `
    -DeleteAfterHours 24 `
    -ArmTemplateParameters @{ 'id' = [string](Get-Random -Minimum 1000 -Maximum 9999); 'app_id' = $appId } `
    -OutFile
