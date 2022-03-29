. $PSScriptRoot/common.ps1

if ($TestProxyTrustCertFn -and (Test-Path "Function:$TestProxyTrustCertFn"))
{
    &$TestProxyTrustCertFn
}