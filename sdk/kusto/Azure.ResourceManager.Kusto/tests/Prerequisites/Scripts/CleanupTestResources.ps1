Import-Module Az.Kusto

$SubscriptionId = "e8257c73-24c5-4791-94dc-8b7901c90dbf" # Kusto_Dev_Kusto_Ilay_04_Test

Write-Host "Cleaning up old test resources" -ForegroundColor Green
az login
az account set --name $SubscriptionId

Write-Host "Starting clean up remainings from previous test run" -ForegroundColor Green
$OldResourceGroups = az group list --tag DeleteAfter --query "[? contains(name,'CSharpSDKRG')][].{name:name}" --output tsv
$OldResourceGroups | ForEach-Object -Parallel { echo Deleting $_; az group delete --name $_ --yes; echo Deleted $_ }
Write-Host "Done clean up remainings from previous test run" -ForegroundColor Green
