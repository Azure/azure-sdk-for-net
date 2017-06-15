param (
    [Parameter(Mandatory=$true)][string]$pfxFileName,
	[Parameter(Mandatory=$true)][string]$cerFileName,
    [Parameter(Mandatory=$true)][string]$pfxPassword,
    [Parameter(Mandatory=$true)][string]$domainName
)

. ./New-SelfSignedCertificateEx.ps1

#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
New-SelfsignedCertificateEx -Subject "CN=*.$($domainName)" -EKU "1.3.6.1.5.5.7.3.1" -Path ".\$($pfxFileName)" -Password (ConvertTo-SecureString $pfxPassword -AsPlainText -Force) -Exportable
$pfxPath = Join-Path $pwd.Path $pfxFileName
Write-Host "pfxPath: $pfxPath"
$cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$cert.Import($pfxPath, $pfxPassword,'DefaultKeySet')
Write-Host "exporting to CERT"
Export-Certificate -Cert $cert -FilePath $cerFileName -Type CERT