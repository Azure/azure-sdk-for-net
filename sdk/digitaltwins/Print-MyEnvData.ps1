param(
    [Parameter()]
    [string] $fileName = "test-resources.json.env"
)
([System.Text.Encoding]::UTF8).GetString([Security.Cryptography.ProtectedData]::Unprotect([IO.File]::ReadAllBytes((Resolve-path $fileName)), $null, [Security.Cryptography.DataProtectionScope]::CurrentUser))