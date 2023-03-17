. $PSScriptRoot/common.ps1

if ($TestProxyTrustCertFn -and (Test-Path "Function:$TestProxyTrustCertFn"))
{
    &$TestProxyTrustCertFn
}
else {
    Write-Host "No implementation of TestProxyTrustCertFn provided in eng/scripts/Language-Settings.ps1"
}