param (
    [Parameter(Mandatory = $true)][string] $rgName,
    [Parameter(Mandatory = $true)][securestring] $vmPassword
)

New-AzResourceGroupDeployment `
    -ResourceGroupName $rgName `
    -TemplateFile "test-resources.bicep" `
    -Name "deployVM" `
    -adminPassword $vmPassword