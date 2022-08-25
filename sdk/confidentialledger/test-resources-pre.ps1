Import-Module -Name ./eng/scripts/X509Certificate2 -Verbose

$cert = New-X509Certificate2 -SubjectName 'E=opensource@microsoft.com, CN=Azure SDK, OU=Azure SDK, O=Microsoft, L=Frisco, S=TX, C=US' -ValidDays 365

$pem = (Format-X509Certificate2 -Certificate $cert)
$pem = [string]::join("",($pem.Split("`n")))
$templateFileParameters['ConfidentialLedgerPrincipalPEM'] = $pem
$pemPk = (Format-X509Certificate2 -Type Pkcs8 -Certificate $cert)
$pemPk = [string]::join("",($pemPk.Split("`n")))
$templateFileParameters['ConfidentialLedgerPrincipalPEMPK'] = $pemPk
