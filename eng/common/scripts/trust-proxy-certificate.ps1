. $PSScriptRoot/common.ps1

if ($TestProxyTrustCertFn -and (Test-Path "Function:$TestProxyTrustCertFn"))
{
    &$TestProxyTrustCertFn
}
else {
    Write-Host "No implementation of Import-Dev-Cert-<language> provided in eng/scripts/Language-Settings.ps1."
}