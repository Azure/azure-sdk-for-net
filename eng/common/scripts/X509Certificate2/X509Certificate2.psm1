#Requires -Version 6.0

using namespace System.Security.Cryptography
using namespace System.Security.Cryptography.X509Certificates
using namespace System.Text

<#
.Synopsis
Generate an X509 v3 certificate.

.Description
Generates an [X509Certificate2] from either a subject name, or individual X500 distinguished names.

.Parameter SubjectName
The entire X500 subject name.

.Parameter Country
The country e.g., "US".

.Parameter State
The state or province e.g., "WA".

.Parameter City
The city or locality e.g., "Redmond".

.Parameter Organization
The organization e.g., "Microsoft".

.Parameter Department
The department e.g., "Azure SDK".

.Parameter CommonName
A common name e.g., "www.microsoft.com".

.Parameter SubjectAlternativeNames
Additional subject names from New-X509Certificate2SubjectAlternativeNames.

.Parameter KeySize
Size of the RSA key.

.Parameter KeyUsageFlags
Additional key usage flags.

.Parameter CA
Create self-signed certificate authority.

.Parameter TLS
Create self-signed certificate suitable for TLS.

.Parameter NotBefore
The start date when the certificate is valid. The default is the current time.

.Parameter ValidDays
How many days from NotBefore until the certificate expires.

.Example
New-X509Certificate2 -SubjectName 'E=opensource@microsoft.com, CN=Azure SDK, OU=Azure SDK, O=Microsoft, L=Redmond, S=WA, C=US' -ValidDays 3652

Create a self-signed certificate valid for 10 years from now.

.Example
New-X509Certificate2 -SubjectName 'CN=Azure SDK' -SubjectAlternativeNames (New-X509Certificate2SubjectAlternativeNames -EmailAddress azuresdk@microsoft.com) -KeyUsageFlags KeyEncipherment, NonRepudiation, DigitalSignature -CA -TLS -ValidDays 3652

Create a self-signed certificate valid for 10 years from now with an alternative name, additional key usages including TLS connections, and that can sign other certificate requests.
#>
function New-X509Certificate2 {
    [CmdletBinding(DefaultParameterSetName='SubjectName')]
    [OutputType([System.Security.Cryptography.X509Certificates.X509Certificate2])]
    param (
        [Parameter(ParameterSetName='SubjectName', Mandatory=$true, Position=0)]
        [string] $SubjectName,

        [Parameter(ParameterSetName='Builder', HelpMessage='Country Name (2 letter code)')]
        [Alias('C')]
        [string] $Country,

        [Parameter(ParameterSetName='Builder', HelpMessage='State or Province Name (full name)')]
        [Alias('S', 'Province')]
        [string] $State,

        [Parameter(ParameterSetName='Builder', HelpMessage='Locality Name (eg, city)')]
        [Alias('L', 'Locality')]
        [string] $City,

        [Parameter(ParameterSetName='Builder', HelpMessage='Organization Name (eg, company)')]
        [Alias('O')]
        [string] $Organization,

        [Parameter(ParameterSetName='Builder', HelpMessage='Organizational Unit Name (eg, section)')]
        [Alias('OU')]
        [string] $Department,

        [Parameter(ParameterSetName='Builder', HelpMessage='Common Name (e.g. server FQDN or YOUR name)')]
        [Alias('CN')]
        [string] $CommonName,

        [Parameter()]
        [ValidateNotNull()]
        [SubjectAlternativeNameBuilder] $SubjectAlternativeNames,

        [Parameter()]
        [ValidateSet(1024, 2048, 4096)]
        [int] $KeySize = 2048,

        [Parameter()]
        [X509KeyUsageFlags] $KeyUsageFlags,

        [Parameter()]
        [switch] $CA,

        [Parameter()]
        [switch] $TLS,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [DateTimeOffset] $NotBefore = [DateTimeOffset]::Now,

        [Parameter()]
        [ValidateRange(1, [int]::MaxValue)]
        [int] $ValidDays = 365
    )

    if ($PSCmdlet.ParameterSetName -eq 'Builder') {
        $sb = [StringBuilder]::new()
        if ($Country) { $null = $sb.Append("C=$Country,") }
        if ($State) { $null = $sb.Append("S=$State, ") }
        if ($City) { $null = $sb.Append("L=$City, ") }
        if ($Organization) { $null = $sb.Append("O=$Organization, ") }
        if ($Department) { $null = $sb.Append("OU=$Department, ") }
        if ($CommonName) { $null = $sb.Append("CN=$CommonName, ") }

        $SubjectName = [X500DistinguishedName]::new($sb.ToString()).Format($false)
    }

    $rsa = [RSA]::Create($KeySize)
    try {
        $req = [CertificateRequest]::new(
            [string] $SubjectName,
            $rsa,
            [HashAlgorithmName]::SHA256,
            [RSASignaturePadding]::Pkcs1
        )

        $req.CertificateExtensions.Add(
            [X509BasicConstraintsExtension]::new(
                $CA,
                $false,
                0,
                $true
            )
        )

        if ($SubjectAlternativeNames) {
            $req.CertificateExtensions.Add(
                $SubjectAlternativeNames.Build($false)
            )
        }

        if ($KeyUsageFlags) {
            $req.CertificateExtensions.Add(
                [X509KeyUsageExtension]::new(
                    $KeyUsageFlags,
                    $true
                )
            )
        }

        if ($TLS) {
            $oids = [OidCollection]::new()
            $null = $oids.Add([Oid]::new('1.3.6.1.5.5.7.3.1'))

            $req.CertificateExtensions.Add(
                [X509EnhancedKeyUsageExtension]::new(
                    $oids,
                    $false
                )
            )
        }

        $req.CreateSelfSigned($NotBefore, $NotBefore.AddDays($ValidDays))
    }
    finally {
        $rsa.Dispose()
    }
}

<#
.Synopsis
Create subject alternative names for New-X509Certificate2.

.Description
Subject alternative names include DNS names, email addresses, and IP addresses for which a certificate may also authenticate connections.

.Parameter DnsName
One or more DNS names e.g., "www.microsoft.com".

.Parameter EmailAddress
One or more email addresses e.g., "opensource@microsoft.com".

.Parameter IpAddress
One or more IP addresses.

.Parameter Uri
Additional URIs not covered by other options.

.Parameter UserPrincipalName
Additional user names not covered by other options.
#>
function New-X509Certificate2SubjectAlternativeNames {
    [CmdletBinding()]
    [OutputType([System.Security.Cryptography.X509Certificates.SubjectAlternativeNameBuilder])]
    param (
        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string[]] $DnsName,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string[]] $EmailAddress,

        [Parameter()]
        [ValidateScript({[System.Net.IPAddress]::TryParse($_, [ref] $null)})]
        [string[]] $IpAddress,

        [Parameter()]
        [ValidateScript({[System.Uri]::TryParse($_, [ref] $null)})]
        [string[]] $Uri,

        [Parameter()]
        [ValidateNotNullOrEmpty()]
        [string[]] $UserPrincipalName
    )

    $subjectAlternativeNames = [SubjectAlternativeNameBuilder]::new()

    foreach ($value in $DnsName) {
        $subjectAlternativeNames.AddDnsName($value)
    }

    foreach ($value in $EmailAddress) {
        $subjectAlternativeNames.AddEmailAddress($value)
    }

    foreach ($value in $IpAddress) {
        $subjectAlternativeNames.AddIpAddress($value)
    }

    foreach ($value in $Uri) {
        $subjectAlternativeNames.AddUri($value)
    }

    foreach ($value in $UserPrincipalName) {
        $subjectAlternativeNames.AddUserPrincipalName($value)
    }

    $subjectAlternativeNames
}

<#
.Synopsis
Exports a certificate to a file.

.Description
Exports an X509Certificate2 to a file in one of the given formats.

.Parameter Path
The path to the file to save.

.Parameter Type
The type of encoding for the file to save.

.Parameter Certificate
The certificate to save.
#>
function Export-X509Certificate2 {
    [CmdletBinding()]
    param (
        [Parameter(Mandatory=$true, Position=0)]
        [string] $Path,

        [Parameter(Position=1)]
        [ValidateSet('Certificate', 'CertificateBase64', 'Pfx', 'Pkcs1', 'Pkcs12', 'Pkcs12Base64', 'Pkcs8', 'PrivateKey')]
        [string] $Type = 'Pfx',

        [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
        [X509Certificate2] $Certificate
    )

    if ($Type -in 'Pfx', 'Pkcs12') {
        $Certificate.Export([X509ContentType]::Pfx) | Set-Content $Path -AsByteStream
    } else {
        Format-X509Certificate2 -Type $Type -Certificate $Certificate | Set-Content $Path -Encoding ASCII
    }
}

<#
.Synopsis
Formats a certificate.

.Description
Formats a certificate and prints it to the output buffer e.g., console. Useful for piping to clip.exe in Windows and pasting into code (additional formatting may be required).

.Parameter Type
The type of encoding for the output.

.Parameter Certificate
The certificate to format.
#>
function Format-X509Certificate2 {
    [CmdletBinding()]
    param (
        [Parameter(Position=0)]
        [ValidateSet('Certificate', 'CertificateBase64', 'Pkcs1', 'Pkcs12Base64', 'Pkcs8', 'PrivateKey')]
        [string] $Type = 'Certificate',

        [Parameter(Mandatory=$true, ValueFromPipeline=$true)]
        [X509Certificate2] $Certificate
    )

    function ConvertTo-Pem($tag, $data) {
        @"
-----BEGIN $tag-----
$([Convert]::ToBase64String($data, 'InsertLineBreaks'))
-----END $tag-----
"@
    }

    if ($Type -eq 'Certificate') {
        ConvertTo-Pem 'CERTIFICATE' $Certificate.RawData
    } elseif ($Type -eq 'CertificateBase64') {
        [Convert]::ToBase64String($Certificate.RawData, 'InsertLineBreaks')
    } elseif ($Type -eq 'Pkcs1') {
        ConvertTo-Pem 'RSA PRIVATE KEY' $Certificate.PrivateKey.ExportRSAPrivateKey()
    } elseif ($Type -eq 'Pkcs12Base64') {
        [Convert]::ToBase64String($Certificate.Export([X509ContentType]::Pfx), 'InsertLineBreaks')
    } elseif ($Type -in 'Pkcs8', 'PrivateKey') {
        ConvertTo-Pem 'PRIVATE KEY' $Certificate.PrivateKey.ExportPkcs8PrivateKey()
    }
}
