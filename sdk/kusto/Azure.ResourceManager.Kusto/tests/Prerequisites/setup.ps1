Import-Module Az.Kusto

az login

$sdkRgs = az group list --tag DeleteAfter --query "[? contains(name,'sdkRg')][].{name:name}" --output tsv
$sdkRgs | ForEach-Object -Parallel { echo Deleting $_; az group delete --name $_ --yes; echo Deleted $_ }

$RootDirectory = (Get-Item $PSScriptRoot).parent.parent.parent.parent.parent
$TestResourcesDirectory = Join-Path -Path $RootDirectory -ChildPath eng\common\TestResources

$subscriptionId = az account list --query "[?name=='Kusto_Dev_Kusto_Ilay_04_Test'].id" --output tsv

$appId = az ad app list --show-mine --query "[?displayName=='kusto C# sdk tests'].appId" --output tsv
$appSecret = az ad app credential reset --id $appId --years 2 --query "password" --output tsv
$applicationOId = az ad sp show --id $appId --query "id" --output tsv

$id = [string](Get-Random -Minimum 0 -Maximum 999)

& $TestResourcesDirectory\New-TestResources.ps1 `
    -SubscriptionId $subscriptionId `
    -TestApplicationId $appId `
    -TestApplicationSecret $appSecret `
    -TestApplicationOid $applicationOId `
    -ServiceDirectory 'kusto' `
    -ResourceGroupName  "sdkRg${id}" `
    -Location 'eastus2' `
    -DeleteAfterHours 1 `
    -ArmTemplateParameters @{ 'id' = $id; 'app_id' = $appId } `
    -OutFile
