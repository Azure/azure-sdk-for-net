Import-Module Az.Kusto

$SubscriptionId = "e8257c73-24c5-4791-94dc-8b7901c90dbf" # Kusto_Dev_Kusto_Ilay_04_Test
$ResourseGroupPrefix = 'CSharpSDKRG'
$Location = 'eastus2'
$DeleteAfterHours = 1 # currently this is just a tag that is added to the RG, there no actual delete

Write-Host "Creating new resources for test" -ForegroundColor Green
az login
az account set --name $SubscriptionId

Write-Host "Getting App information" -ForegroundColor Green
$AppId = "cb0005b7-8722-4741-b183-4fa8bc3bf70f"
$AppSecret = az ad app credential reset --id $AppId --years 2 --query "password" --output tsv
$ApplicationOId = az ad sp show --id $AppId --query "id" --output tsv

$Id = [string](Get-Random -Minimum 0 -Maximum 999)

$RootDirectory = (Get-Item $PSScriptRoot).parent.parent.parent.parent.parent.parent
$TestResourcesDirectory = Join-Path -Path $RootDirectory -ChildPath eng\common\TestResources

Write-Host "Triggering New-TestResources script to create all required resources" -ForegroundColor Green
& $TestResourcesDirectory\New-TestResources.ps1 `
    -SubscriptionId $SubscriptionId `
    -TestApplicationId $AppId `
    -TestApplicationSecret $AppSecret `
    -TestApplicationOid $ApplicationOId `
    -ServiceDirectory 'kusto' `
    -ResourceGroupName  ($ResourseGroupPrefix + $Id) `
    -Location $Location `
    -DeleteAfterHours $DeleteAfterHours `
    -ArmTemplateParameters @{ 'id' = $Id; 'app_id' = $AppId; } `
    -OutFile

Write-Host "Created all required resources" -ForegroundColor Green



