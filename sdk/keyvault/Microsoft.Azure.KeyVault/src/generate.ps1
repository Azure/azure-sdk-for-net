Start-AutoRestCodeGeneration -ResourceProvider "keyvault/data-plane" -AutoRestVersion "latest" -SpecsRepoBranch "keyvault_preview" -SdkGenerationDirectory "$PSScriptRoot\Generated"

# Delete the generated JsonWebKey models as these are in the Microsoft.Azure.KeyVault.WebKey package
Get-ChildItem "$PSScriptRoot\Generated\Models\" JsonWebKey*.cs | Remove-Item

# Update references to JsonWebKey* to use the namespace qualified type name
Get-ChildItem "$PSScriptRoot\Generated" *.cs -rec |
ForEach-Object {
    $path = Convert-Path $_.PSPath
    $content = ([System.IO.File]::ReadAllText($path) -replace "JsonWebKey", "Microsoft.Azure.KeyVault.WebKey.JsonWebKey")
    [System.IO.File]::WriteAllText($path, $content)
}
