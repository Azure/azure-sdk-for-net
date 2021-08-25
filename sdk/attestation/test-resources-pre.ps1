# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# IMPORTANT: Do not invoke this file directly. Please instead run eng/New-TestResources.ps1 from the repository root.

#Requires -Version 6.0
#Requires -PSEdition Core

using namespace System.Security.Cryptography
using namespace System.Security.Cryptography.X509Certificates

# Use same parameter names as declared in eng/New-TestResources.ps1 (assume validation therein).
[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments
)

$ServiceRegionMap = @{
    "east asia" = "EastAsia";
    "southeast asia" = "SoutheastAsia";
    "east us" = "EastUS";
    "east us 2" = "EastUS2";
    "west us" = "WestUS";
    "west us 2" = "WestUS2";
    "central us" = "CentralUS";
    "north central us" = "NorthCentralUS";
    "south central us" = "SouthCentralUS";
    "north europe" = "NorthEurope";
    "west europe" = "WestEurope";
    "japan east" = "JapanEast";
    "japan west" = "JapanWest";
    "brazil south" = "BrazilSouth";
    "australia east" = "AustraliaEast";
    "australia southeast" = "AustraliaSoutheast";
    "central india" = "CentralIndia";
    "south india" = "SouthIndia";
    "west india" = "WestIndia";
    "china east" = "ChinaEast";
    "china north" = "ChinaNorth";
    "us gov iowa" = "USGovIowa";
    "usgov virginia" = "USGovVirginia";
    "germany central" = "GermanyCentral";
    "germany northeast" = "GermanyNortheast";
    "uk south" = "UKSouth";
    "canada east" = "CanadaEast";
    "canada central" = "CanadaCentral";
    "canada west" = "CanadaWest";
    "central us euap" = "CentralUSEUAP";
}
$AbbreviatedRegionMap = @{
    "eastasia" = "easia";
    "southeastasia" = "sasia";
    "eastus" = "eus";
    "eastus2" = "eus2";
    "westus" = "wus";
    "westus2" = "wus2";
    "centralus" = "cus";
    "northcentralus" = "ncus";
    "southcentralus" = "scus";
    "northeurope" = "neu";
    "westeurope" = "weu";
    "japaneast" = "ejp";
    "japanwest" = "wjp";
    "brazilsouth" = "sbr";
    "australiaeast" = "eau";
    "australiasoutheast" = "sau";
    "centralindia" = "cin";
    "southindia" = "sin";
    "westindia" = "win";
    "chinaeast" = "ecn";
    "chinanorth" = "ncn";
    "usgoviowa" = "iusg";
    "usgovvirginia" = "vusg";
    "germanycentral" = "cde";
    "germanynortheast" = "nde";
    "uksouth" = "uks";
    "canadaeast" = "cae";
    "canadacentral" = "cac";
    "canadawest" = "caw";
    "centraluseuap" = "cuse";
}

# By default stop for any error.
if (!$PSBoundParameters.ContainsKey('ErrorAction')) {
    $ErrorActionPreference = 'Stop'
}

function Log($Message) {
    Write-Host ('{0} - {1}' -f [DateTime]::Now.ToLongTimeString(), $Message)
}

function New-X509Certificate2([RSA] $rsa, [string] $SubjectName) {

    try {
        $req = [CertificateRequest]::new(
            [string] $SubjectName,
            $rsa,
            [HashAlgorithmName]::SHA256,
            [RSASignaturePadding]::Pkcs1
        )

        # TODO: Add any KUs necessary to $req.CertificateExtensions

        $req.CertificateExtensions.Add([X509BasicConstraintsExtension]::new($true, $false, 0, $false))

        $NotBefore = [DateTimeOffset]::Now.AddDays(-1)
        $NotAfter = $NotBefore.AddDays(365)

        $req.CreateSelfSigned($NotBefore, $NotAfter)
    }
    finally {
    }
}

function Export-X509Certificate2([string] $Path, [X509Certificate2] $Certificate) {

    $Certificate.Export([X509ContentType]::Pfx) | Set-Content $Path -AsByteStream
}

function Export-X509Certificate2PEM([string] $Path, [X509Certificate2] $Certificate) {

@"
-----BEGIN CERTIFICATE-----
$([Convert]::ToBase64String($Certificate.RawData, 'InsertLineBreaks'))
-----END CERTIFICATE-----
"@ > $Path

}

Log "Running PreConfig script".

$shortLocation = $AbbreviatedRegionMap.Get_Item($Location.ToLower())
Log "Mapped long location name ${Location} to short name: ${shortLocation}"

try {
   $isolatedKey = [RSA]::Create(2048)
   $isolatedCertificate = New-X509Certificate2 $isolatedKey "CN=AttestationIsolatedManagementCertificate"

   $EnvironmentVariables["isolatedSigningCertificate"] = $([Convert]::ToBase64String($isolatedCertificate.RawData, 'None'))
   $templateFileParameters.isolatedSigningCertificate = $([Convert]::ToBase64String($isolatedCertificate.RawData, 'None'))

   $EnvironmentVariables["isolatedSigningKey"] = $([Convert]::ToBase64String($isolatedKey.ExportPkcs8PrivateKey()))
   $EnvironmentVariables["serializedIsolatedSigningKey"] = $isolatedKey.ToXmlString($True)
}
finally {
   $isolatedKey.Dispose()
}

$EnvironmentVariables["locationShortName"] = $shortLocation
$templateFileParameters.locationShortName = $shortLocation

Log 'Creating 3 X509 certificates which can be used to sign policies.'
$wrappingFiles = foreach ($i in 0..2) {
    try {
        $certificateKey = [RSA]::Create(2048)
        $certificate = New-X509Certificate2 $certificateKey "CN=AttestationCertificate$i"

        $EnvironmentVariables["policySigningCertificate$i"] = $([Convert]::ToBase64String($certificate.RawData))

        $EnvironmentVariables["policySigningKey$i"] = $([Convert]::ToBase64String($certificateKey.ExportPkcs8PrivateKey()))
        $EnvironmentVariables["serializedPolicySigningKey$i"] = $certificateKey.ToXmlString($True)

        $baseName = "$PSScriptRoot\attestation-certificate$i"
        Export-X509Certificate2 "$baseName.pfx" $certificate
    }
    finally {
        $certificateKey.Dispose()
    }
}
