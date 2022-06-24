Import-Module -Name ./eng/scripts/X509Certificate2 -Verbose

$cert = New-X509Certificate2 -SubjectName 'E=opensource@microsoft.com, CN=Azure SDK, OU=Azure SDK, O=Microsoft, L=Frisco, S=TX, C=US' -ValidDays 3652
$templateFileParameters['ConfidentialLedgerPrincipalPEM'] = Format-X509Certificate2 -Certificate $cert
$templateFileParameters['ConfidentialLedgerPrincipalPEMPK'] = Format-X509Certificate2 -Type Pkcs8 -Certificate $cert
