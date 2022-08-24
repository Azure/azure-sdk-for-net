Import-Module -Name ./eng/scripts/X509Certificate2 -Verbose

$cert = New-X509Certificate2 -SubjectName 'E=opensource@microsoft.com, CN=Azure SDK, OU=Azure SDK, O=Microsoft, L=Frisco, S=TX, C=US' -ValidDays 3652

$pem = Format-X509Certificate2 -Certificate $cert
$templateFileParameters['ConfidentialLedgerPrincipalPEM'] = $pem -replace "\\r\\n", ""

$pemPk = Format-X509Certificate2 -Type Pkcs8 -Certificate $cert
$templateFileParameters['ConfidentialLedgerPrincipalPEMPK'] = $pemPk -replace "\\r\\n", ""
