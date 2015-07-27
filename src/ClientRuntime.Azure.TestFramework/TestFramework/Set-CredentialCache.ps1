Add-Type -Path Microsoft.Rest.ClientRuntime.Azure.TestFramework.dll
$cache = New-Object Microsoft.Rest.ClientRuntime.Azure.TestFramework.Authentication.CredManCache "SpecTestSupport"
$credential = Get-Credential
$cache[$credential.UserName] = $credential.GetNetworkCredential().Password