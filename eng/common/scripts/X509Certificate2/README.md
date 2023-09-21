Powershell module for generating self-signed x509 certificates

Usage:

```powershell
Import-Module -Name ./eng/common/scripts/X509Certificate2 # assumes $PWD is repo root

$cert1 = New-X509Certificate2 -SubjectName 'E=opensource@microsoft.com, CN=Azure SDK, OU=Azure SDK, O=Microsoft, L=Redmond, S=WA, C=US' -ValidDays 3652

$CaPublicKeyBase64 = $cert1 | Format-X509Certificate2 -Type CertificateBase64
$CaPrivateKeyPem = $cert1 | Format-X509Certificate2 -Type Pkcs1
$CaKeyPairPkcs12Base64 = $cert1 | Format-X509Certificate2 -Type Pkcs12Base64
```

With V3 extensions

```powershell
Import-Module -Name eng/scripts/X509Certificate2.psm1 # assumes $PWD is repo root

$cert2 = New-X509Certificate2 -SubjectName 'CN=Azure SDK' -SubjectAlternativeNames (New-X509Certificate2SubjectAlternativeNames -EmailAddress azuresdk@microsoft.com) -KeyUsageFlags KeyEncipherment, NonRepudiation, DigitalSignature -CA -TLS -ValidDays 3652

$PemCertificateWithV3Extensions = ($cert2 | Format-X509Certificate2 -Type Certificate) + "`n" + ($cert2 | Format-X509Certificate2 -Type Pkcs8)
$CertificateWithV3ExtensionsBase64 = $cert2 | Format-X509Certificate2 -Type CertificateBase64
 ```
