#####################################################################
# New-SelfSignedCertificateEx.ps1
# Version 1.2
#
# Creates self-signed certificate. This tool is a base replacement
# for deprecated makecert.exe
#
# Vadims Podans (c) 2013 - 2016
# http://en-us.sysadmins.lv/
#####################################################################
#requires -Version 2.0

function New-SelfSignedCertificateEx {
<#
.Synopsis
	This cmdlet generates a self-signed certificate.
.Description
	This cmdlet generates a self-signed certificate with the required data.
.Parameter Subject
	Specifies the certificate subject in a X500 distinguished name format.
	Example: CN=Test Cert, OU=Sandbox
.Parameter NotBefore
	Specifies the date and time when the certificate become valid. By default previous day
	date is used.
.Parameter NotAfter
	Specifies the date and time when the certificate expires. By default, the certificate is
	valid for 1 year.
.Parameter SerialNumber
	Specifies the desired serial number in a hex format.
	Example: 01a4ff2
.Parameter ProviderName
	Specifies the Cryptography Service Provider (CSP) name. You can use either legacy CSP
	and Key Storage Providers (KSP). By default "Microsoft Enhanced Cryptographic Provider v1.0"
	CSP is used.
.Parameter AlgorithmName
	Specifies the public key algorithm. By default RSA algorithm is used. RSA is the only
	algorithm supported by legacy CSPs. With key storage providers (KSP) you can use CNG
	algorithms, like ECDH. For CNG algorithms you must use full name:
	ECDH_P256
	ECDH_P384
	ECDH_P521
	
	In addition, KeyLength parameter must be specified explicitly when non-RSA algorithm is used.
.Parameter KeyLength
	Specifies the key length to generate. By default 2048-bit key is generated.
.Parameter KeySpec
	Specifies the public key operations type. The possible values are: Exchange and Signature.
	Default value is Exchange.
.Parameter EnhancedKeyUsage
	Specifies the intended uses of the public key contained in a certificate. You can
	specify either, EKU friendly name (for example 'Server Authentication') or
	object identifier (OID) value (for example '1.3.6.1.5.5.7.3.1').
.Parameter KeyUsages
	Specifies restrictions on the operations that can be performed by the public key contained in the certificate.
	Possible values (and their respective integer values to make bitwise operations) are:
	EncipherOnly
	CrlSign
	KeyCertSign
	KeyAgreement
	DataEncipherment
	KeyEncipherment
	NonRepudiation
	DigitalSignature
	DecipherOnly
	
	you can combine key usages values by using bitwise OR operation. when combining multiple
	flags, they must be enclosed in quotes and separated by a comma character. For example,
	to combine KeyEncipherment and DigitalSignature flags you should type:
	"KeyEncipherment, DigitalSignature".
	
	If the certificate is CA certificate (see IsCA parameter), key usages extension is generated
	automatically with the following key usages: Certificate Signing, Off-line CRL Signing, CRL Signing.
.Parameter SubjectAlternativeName
	Specifies alternative names for the subject. Unlike Subject field, this extension
	allows to specify more than one name. Also, multiple types of alternative names
	are supported. The cmdlet supports the following SAN types:
	RFC822 Name
	IP address (both, IPv4 and IPv6)
	Guid
	Directory name
	DNS name
.Parameter IsCA
	Specifies whether the certificate is CA (IsCA = $true) or end entity (IsCA = $false)
	certificate. If this parameter is set to $false, PathLength parameter is ignored.
	Basic Constraints extension is marked as critical.
.PathLength
	Specifies the number of additional CA certificates in the chain under this certificate. If
	PathLength parameter is set to zero, then no additional (subordinate) CA certificates are
	permitted under this CA.
.CustomExtension
	Specifies the custom extension to include to a self-signed certificate. This parameter
	must not be used to specify the extension that is supported via other parameters. In order
	to use this parameter, the extension must be formed in a collection of initialized
	System.Security.Cryptography.X509Certificates.X509Extension objects.
.Parameter SignatureAlgorithm
	Specifies signature algorithm used to sign the certificate. By default 'SHA1'
	algorithm is used.
.Parameter FriendlyName
	Specifies friendly name for the certificate.
.Parameter StoreLocation
	Specifies the store location to store self-signed certificate. Possible values are:
	'CurrentUser' and 'LocalMachine'. 'CurrentUser' store is intended for user certificates
	and computer (as well as CA) certificates must be stored in 'LocalMachine' store.
.Parameter StoreName
	Specifies the container name in the certificate store. Possible container names are:
	AddressBook
	AuthRoot
	CertificateAuthority
	Disallowed
	My
	Root
	TrustedPeople
	TrustedPublisher
.Parameter Path
	Specifies the path to a PFX file to export a self-signed certificate.
.Parameter Password
	Specifies the password for PFX file.
.Parameter AllowSMIME
	Enables Secure/Multipurpose Internet Mail Extensions for the certificate.
.Parameter Exportable
	Marks private key as exportable. Smart card providers usually do not allow
	exportable keys.
.Example
	New-SelfsignedCertificateEx -Subject "CN=Test Code Signing" -EKU "Code Signing" -KeySpec "Signature" `
	-KeyUsage "DigitalSignature" -FriendlyName "Test code signing" -NotAfter $([datetime]::now.AddYears(5))
	
	Creates a self-signed certificate intended for code signing and which is valid for 5 years. Certificate
	is saved in the Personal store of the current user account.
.Example
	New-SelfsignedCertificateEx -Subject "CN=www.domain.com" -EKU "Server Authentication", "Client authentication" `
	-KeyUsage "KeyEcipherment, DigitalSignature" -SAN "sub.domain.com","www.domain.com","192.168.1.1" `
	-AllowSMIME -Path C:\test\ssl.pfx -Password (ConvertTo-SecureString "P@ssw0rd" -AsPlainText -Force) -Exportable `
	-StoreLocation "LocalMachine"
	
	Creates a self-signed SSL certificate with multiple subject names and saves it to a file. Additionally, the
	certificate is saved in the Personal store of the Local Machine store. Private key is marked as exportable,
	so you can export the certificate with a associated private key to a file at any time. The certificate
	includes SMIME capabilities.
.Example
	New-SelfsignedCertificateEx -Subject "CN=www.domain.com" -EKU "Server Authentication", "Client authentication" `
	-KeyUsage "KeyEcipherment, DigitalSignature" -SAN "sub.domain.com","www.domain.com","192.168.1.1" `
	-StoreLocation "LocalMachine" -ProviderName "Microsoft Software Key Storae Provider" -AlgorithmName ecdh_256 `
	-KeyLength 256 -SignatureAlgorithm sha256
	
	Creates a self-signed SSL certificate with multiple subject names and saves it to a file. Additionally, the
	certificate is saved in the Personal store of the Local Machine store. Private key is marked as exportable,
	so you can export the certificate with a associated private key to a file at any time. Certificate uses
	Ellyptic Curve Cryptography (ECC) key algorithm ECDH with 256-bit key. The certificate is signed by using
	SHA256 algorithm.
.Example
	New-SelfsignedCertificateEx -Subject "CN=Test Root CA, OU=Sandbox" -IsCA $true -ProviderName `
	"Microsoft Software Key Storage Provider" -Exportable
	
	Creates self-signed root CA certificate.
#>
[OutputType('[System.Security.Cryptography.X509Certificates.X509Certificate2]')]
[CmdletBinding(DefaultParameterSetName = '__store')]
	param (
		[Parameter(Mandatory = $true, Position = 0)]
		[string]$Subject,
		[Parameter(Position = 1)]
		[datetime]$NotBefore = [DateTime]::Now.AddDays(-1),
		[Parameter(Position = 2)]
		[datetime]$NotAfter = $NotBefore.AddDays(365),
		[string]$SerialNumber,
		[Alias('CSP')]
		[string]$ProviderName = "Microsoft Enhanced Cryptographic Provider v1.0",
		[string]$AlgorithmName = "RSA",
		[int]$KeyLength = 2048,
		[validateSet("Exchange","Signature")]
		[string]$KeySpec = "Exchange",
		[Alias('EKU')]
		[Security.Cryptography.Oid[]]$EnhancedKeyUsage,
		[Alias('KU')]
		[Security.Cryptography.X509Certificates.X509KeyUsageFlags]$KeyUsage,
		[Alias('SAN')]
		[String[]]$SubjectAlternativeName,
		[bool]$IsCA,
		[int]$PathLength = -1,
		[Security.Cryptography.X509Certificates.X509ExtensionCollection]$CustomExtension,
		[ValidateSet('MD5','SHA1','SHA256','SHA384','SHA512')]
		[string]$SignatureAlgorithm = "SHA1",
		[string]$FriendlyName,
		[Parameter(ParameterSetName = '__store')]
		[Security.Cryptography.X509Certificates.StoreLocation]$StoreLocation = "CurrentUser",
		[Parameter(Mandatory = $true, ParameterSetName = '__file')]
		[Alias('OutFile','OutPath','Out')]
		[IO.FileInfo]$Path,
		[Parameter(Mandatory = $true, ParameterSetName = '__file')]
		[Security.SecureString]$Password,
		[switch]$AllowSMIME,
		[switch]$Exportable
	)
	$ErrorActionPreference = "Stop"
	if ([Environment]::OSVersion.Version.Major -lt 6) {
		$NotSupported = New-Object NotSupportedException -ArgumentList "Windows XP and Windows Server 2003 are not supported!"
		throw $NotSupported
	}
	$ExtensionsToAdd = @()

#region constants
	# contexts
	New-Variable -Name UserContext -Value 0x1 -Option Constant
	New-Variable -Name MachineContext -Value 0x2 -Option Constant
	# encoding
	New-Variable -Name Base64Header -Value 0x0 -Option Constant
	New-Variable -Name Base64 -Value 0x1 -Option Constant
	New-Variable -Name Binary -Value 0x3 -Option Constant
	New-Variable -Name Base64RequestHeader -Value 0x4 -Option Constant
	# SANs
	New-Variable -Name OtherName -Value 0x1 -Option Constant
	New-Variable -Name RFC822Name -Value 0x2 -Option Constant
	New-Variable -Name DNSName -Value 0x3 -Option Constant
	New-Variable -Name DirectoryName -Value 0x5 -Option Constant
	New-Variable -Name URL -Value 0x7 -Option Constant
	New-Variable -Name IPAddress -Value 0x8 -Option Constant
	New-Variable -Name RegisteredID -Value 0x9 -Option Constant
	New-Variable -Name Guid -Value 0xa -Option Constant
	New-Variable -Name UPN -Value 0xb -Option Constant
	# installation options
	New-Variable -Name AllowNone -Value 0x0 -Option Constant
	New-Variable -Name AllowNoOutstandingRequest -Value 0x1 -Option Constant
	New-Variable -Name AllowUntrustedCertificate -Value 0x2 -Option Constant
	New-Variable -Name AllowUntrustedRoot -Value 0x4 -Option Constant
	# PFX export options
	New-Variable -Name PFXExportEEOnly -Value 0x0 -Option Constant
	New-Variable -Name PFXExportChainNoRoot -Value 0x1 -Option Constant
	New-Variable -Name PFXExportChainWithRoot -Value 0x2 -Option Constant
#endregion
	
#region Subject processing
	# http://msdn.microsoft.com/en-us/library/aa377051(VS.85).aspx
	$SubjectDN = New-Object -ComObject X509Enrollment.CX500DistinguishedName
	$SubjectDN.Encode($Subject, 0x0)
#endregion

#region Extensions

#region Enhanced Key Usages processing
	if ($EnhancedKeyUsage) {
		$OIDs = New-Object -ComObject X509Enrollment.CObjectIDs
		$EnhancedKeyUsage | ForEach-Object {
			$OID = New-Object -ComObject X509Enrollment.CObjectID
			$OID.InitializeFromValue($_.Value)
			# http://msdn.microsoft.com/en-us/library/aa376785(VS.85).aspx
			$OIDs.Add($OID)
		}
		# http://msdn.microsoft.com/en-us/library/aa378132(VS.85).aspx
		$EKU = New-Object -ComObject X509Enrollment.CX509ExtensionEnhancedKeyUsage
		$EKU.InitializeEncode($OIDs)
		$ExtensionsToAdd += "EKU"
	}
#endregion

#region Key Usages processing
	if ($KeyUsage -ne $null) {
		$KU = New-Object -ComObject X509Enrollment.CX509ExtensionKeyUsage
		$KU.InitializeEncode([int]$KeyUsage)
		$KU.Critical = $true
		$ExtensionsToAdd += "KU"
	}
#endregion

#region Basic Constraints processing
	if ($PSBoundParameters.Keys.Contains("IsCA")) {
		# http://msdn.microsoft.com/en-us/library/aa378108(v=vs.85).aspx
		$BasicConstraints = New-Object -ComObject X509Enrollment.CX509ExtensionBasicConstraints
		if (!$IsCA) {$PathLength = -1}
		$BasicConstraints.InitializeEncode($IsCA,$PathLength)
		$BasicConstraints.Critical = $IsCA
		$ExtensionsToAdd += "BasicConstraints"
	}
#endregion

#region SAN processing
	if ($SubjectAlternativeName) {
		$SAN = New-Object -ComObject X509Enrollment.CX509ExtensionAlternativeNames
		$Names = New-Object -ComObject X509Enrollment.CAlternativeNames
		foreach ($altname in $SubjectAlternativeName) {
			$Name = New-Object -ComObject X509Enrollment.CAlternativeName
			if ($altname.Contains("@")) {
				$Name.InitializeFromString($RFC822Name,$altname)
			} else {
				try {
					$Bytes = [Net.IPAddress]::Parse($altname).GetAddressBytes()
					$Name.InitializeFromRawData($IPAddress,$Base64,[Convert]::ToBase64String($Bytes))
				} catch {
					try {
						$Bytes = [Guid]::Parse($altname).ToByteArray()
						$Name.InitializeFromRawData($Guid,$Base64,[Convert]::ToBase64String($Bytes))
					} catch {
						try {
							$Bytes = ([Security.Cryptography.X509Certificates.X500DistinguishedName]$altname).RawData
							$Name.InitializeFromRawData($DirectoryName,$Base64,[Convert]::ToBase64String($Bytes))
						} catch {$Name.InitializeFromString($DNSName,$altname)}
					}
				}
			}
			$Names.Add($Name)
		}
		$SAN.InitializeEncode($Names)
		$ExtensionsToAdd += "SAN"
	}
#endregion

#region Custom Extensions
	if ($CustomExtension) {
		$count = 0
		foreach ($ext in $CustomExtension) {
			# http://msdn.microsoft.com/en-us/library/aa378077(v=vs.85).aspx
			$Extension = New-Object -ComObject X509Enrollment.CX509Extension
			$EOID = New-Object -ComObject X509Enrollment.CObjectId
			$EOID.InitializeFromValue($ext.Oid.Value)
			$EValue = [Convert]::ToBase64String($ext.RawData)
			$Extension.Initialize($EOID,$Base64,$EValue)
			$Extension.Critical = $ext.Critical
			New-Variable -Name ("ext" + $count) -Value $Extension
			$ExtensionsToAdd += ("ext" + $count)
			$count++
		}
	}
#endregion

#endregion

#region Private Key
	# http://msdn.microsoft.com/en-us/library/aa378921(VS.85).aspx
	$PrivateKey = New-Object -ComObject X509Enrollment.CX509PrivateKey
	$PrivateKey.ProviderName = $ProviderName
	$AlgID = New-Object -ComObject X509Enrollment.CObjectId
	$AlgID.InitializeFromValue(([Security.Cryptography.Oid]$AlgorithmName).Value)
	$PrivateKey.Algorithm = $AlgID
	# http://msdn.microsoft.com/en-us/library/aa379409(VS.85).aspx
	$PrivateKey.KeySpec = switch ($KeySpec) {"Exchange" {1}; "Signature" {2}}
	$PrivateKey.Length = $KeyLength
	# key will be stored in current user certificate store
	switch ($PSCmdlet.ParameterSetName) {
		'__store' {
			$PrivateKey.MachineContext = if ($StoreLocation -eq "LocalMachine") {$true} else {$false}
		}
		'__file' {
			$PrivateKey.MachineContext = $false
		}
	}
	$PrivateKey.ExportPolicy = if ($Exportable) {1} else {0}
	$PrivateKey.Create()
#endregion

	# http://msdn.microsoft.com/en-us/library/aa377124(VS.85).aspx
	$Cert = New-Object -ComObject X509Enrollment.CX509CertificateRequestCertificate
	if ($PrivateKey.MachineContext) {
		$Cert.InitializeFromPrivateKey($MachineContext,$PrivateKey,"")
	} else {
		$Cert.InitializeFromPrivateKey($UserContext,$PrivateKey,"")
	}
	$Cert.Subject = $SubjectDN
	$Cert.Issuer = $Cert.Subject
	$Cert.NotBefore = $NotBefore
	$Cert.NotAfter = $NotAfter
	foreach ($item in $ExtensionsToAdd) {$Cert.X509Extensions.Add((Get-Variable -Name $item -ValueOnly))}
	if (![string]::IsNullOrEmpty($SerialNumber)) {
		if ($SerialNumber -match "[^0-9a-fA-F]") {throw "Invalid serial number specified."}
		if ($SerialNumber.Length % 2) {$SerialNumber = "0" + $SerialNumber}
		$Bytes = $SerialNumber -split "(.{2})" | Where-Object {$_} | ForEach-Object{[Convert]::ToByte($_,16)}
		$ByteString = [Convert]::ToBase64String($Bytes)
		$Cert.SerialNumber.InvokeSet($ByteString,1)
	}
	if ($AllowSMIME) {$Cert.SmimeCapabilities = $true}
	$SigOID = New-Object -ComObject X509Enrollment.CObjectId
	$SigOID.InitializeFromValue(([Security.Cryptography.Oid]$SignatureAlgorithm).Value)
	$Cert.SignatureInformation.HashAlgorithm = $SigOID
	# completing certificate request template building
	$Cert.Encode()
	
	# interface: http://msdn.microsoft.com/en-us/library/aa377809(VS.85).aspx
	$Request = New-Object -ComObject X509Enrollment.CX509enrollment
	$Request.InitializeFromRequest($Cert)
	$Request.CertificateFriendlyName = $FriendlyName
	$endCert = $Request.CreateRequest($Base64)
	$Request.InstallResponse($AllowUntrustedCertificate,$endCert,$Base64,"")
	switch ($PSCmdlet.ParameterSetName) {
		'__file' {
			$PFXString = $Request.CreatePFX(
				[Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($Password)),
				$PFXExportEEOnly,
				$Base64
			)
			Set-Content -Path $Path -Value ([Convert]::FromBase64String($PFXString)) -Encoding Byte
		}
	}
	[Byte[]]$CertBytes = [Convert]::FromBase64String($endCert)
	New-Object Security.Cryptography.X509Certificates.X509Certificate2 @(,$CertBytes)
}
# SIG # Begin signature block
# MIIcgAYJKoZIhvcNAQcCoIIccTCCHG0CAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCAmMWwZnveROeiP
# Okrv0onByV5n94ickqih9JS7E9E/HKCCF4owggUTMIID+6ADAgECAhABn3Jtjtqs
# sQ4D4Fge9iqaMA0GCSqGSIb3DQEBCwUAMHIxCzAJBgNVBAYTAlVTMRUwEwYDVQQK
# EwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5jb20xMTAvBgNV
# BAMTKERpZ2lDZXJ0IFNIQTIgQXNzdXJlZCBJRCBDb2RlIFNpZ25pbmcgQ0EwHhcN
# MTUxMjE4MDAwMDAwWhcNMTYxMjIyMTIwMDAwWjBQMQswCQYDVQQGEwJMVjENMAsG
# A1UEBxMEUmlnYTEYMBYGA1UEChMPU3lzYWRtaW5zIExWIElLMRgwFgYDVQQDEw9T
# eXNhZG1pbnMgTFYgSUswggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDo
# UVviPttwGnu8WAEbA2zvYj3+eJLxrpWtcokvyZALEd8hf7m19yCIruChB3b3Cszt
# OMjgV+a4MoPNEjMdnbFVstO+nCxbh/J1W6ArjqEIaYX6H4ZJNwfFD7S22JNeKHW7
# /Z//jdsPSTRvSugWuGFzix0DxdfTDATuq10J6ivi1Tk9DZJpMfEKMnz6ze24UfJU
# FX1XxcbeDgTdK2nd1RGAMKnxYQhn4Gzv+TrbLJWs976aLR/tJ8td4UqtlK/BE0PB
# S3G7Xb4dNjm4e1nVFz7FNf6DqQQ34ZDk+XgVVQINxNbB2WmkOMEJFX2G3+F539d4
# V6EfRAF0+v1U9Ofm1m6TAgMBAAGjggHFMIIBwTAfBgNVHSMEGDAWgBRaxLl7Kgqj
# pepxA8Bg+S32ZXUOWDAdBgNVHQ4EFgQU/3BF2aoFQv5rK3jP1wW8I1t/uoMwDgYD
# VR0PAQH/BAQDAgeAMBMGA1UdJQQMMAoGCCsGAQUFBwMDMHcGA1UdHwRwMG4wNaAz
# oDGGL2h0dHA6Ly9jcmwzLmRpZ2ljZXJ0LmNvbS9zaGEyLWFzc3VyZWQtY3MtZzEu
# Y3JsMDWgM6Axhi9odHRwOi8vY3JsNC5kaWdpY2VydC5jb20vc2hhMi1hc3N1cmVk
# LWNzLWcxLmNybDBMBgNVHSAERTBDMDcGCWCGSAGG/WwDATAqMCgGCCsGAQUFBwIB
# FhxodHRwczovL3d3dy5kaWdpY2VydC5jb20vQ1BTMAgGBmeBDAEEATCBhAYIKwYB
# BQUHAQEEeDB2MCQGCCsGAQUFBzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20w
# TgYIKwYBBQUHMAKGQmh0dHA6Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2Vy
# dFNIQTJBc3N1cmVkSURDb2RlU2lnbmluZ0NBLmNydDAMBgNVHRMBAf8EAjAAMA0G
# CSqGSIb3DQEBCwUAA4IBAQBRqP0FyPMXdmGf4C+ubIeHSeFRcunS6kFdyokn8tKK
# HFqAvea8QCmdFqMPTTet0WK/2O8RiiscWADDbmyHTC9KMNOufeabWtNCbwwaBeg0
# xir8eo2deX1JVWfji4ZdwHTlqJR5hnCM+i1iD60zWOx7+8WAF6toCs5O1+CDqt5P
# hvv0Re0Y17DeFWe9NNanOdy/t+cpTuJZmX3TR5dhRZJTMZZnTdzi4qTWIAaRX4m/
# fUehKfBwd5pzoZwlZ0RC/5RnRMpdUtankwKPdrSjLPSObJwDwxoZvZwpAKhwm1wa
# 49Rv1bHg/r090IrClnAUA6Os1PJAYRWMU8ayMMQuM496MIIFMDCCBBigAwIBAgIQ
# BAkYG1/Vu2Z1U0O1b5VQCDANBgkqhkiG9w0BAQsFADBlMQswCQYDVQQGEwJVUzEV
# MBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNlcnQuY29t
# MSQwIgYDVQQDExtEaWdpQ2VydCBBc3N1cmVkIElEIFJvb3QgQ0EwHhcNMTMxMDIy
# MTIwMDAwWhcNMjgxMDIyMTIwMDAwWjByMQswCQYDVQQGEwJVUzEVMBMGA1UEChMM
# RGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNlcnQuY29tMTEwLwYDVQQD
# EyhEaWdpQ2VydCBTSEEyIEFzc3VyZWQgSUQgQ29kZSBTaWduaW5nIENBMIIBIjAN
# BgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA+NOzHH8OEa9ndwfTCzFJGc/Q+0WZ
# sTrbRPV/5aid2zLXcep2nQUut4/6kkPApfmJ1DcZ17aq8JyGpdglrA55KDp+6dFn
# 08b7KSfH03sjlOSRI5aQd4L5oYQjZhJUM1B0sSgmuyRpwsJS8hRniolF1C2ho+mI
# LCCVrhxKhwjfDPXiTWAYvqrEsq5wMWYzcT6scKKrzn/pfMuSoeU7MRzP6vIK5Fe7
# SrXpdOYr/mzLfnQ5Ng2Q7+S1TqSp6moKq4TzrGdOtcT3jNEgJSPrCGQ+UpbB8g8S
# 9MWOD8Gi6CxR93O8vYWxYoNzQYIH5DiLanMg0A9kczyen6Yzqf0Z3yWT0QIDAQAB
# o4IBzTCCAckwEgYDVR0TAQH/BAgwBgEB/wIBADAOBgNVHQ8BAf8EBAMCAYYwEwYD
# VR0lBAwwCgYIKwYBBQUHAwMweQYIKwYBBQUHAQEEbTBrMCQGCCsGAQUFBzABhhho
# dHRwOi8vb2NzcC5kaWdpY2VydC5jb20wQwYIKwYBBQUHMAKGN2h0dHA6Ly9jYWNl
# cnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RDQS5jcnQwgYEG
# A1UdHwR6MHgwOqA4oDaGNGh0dHA6Ly9jcmw0LmRpZ2ljZXJ0LmNvbS9EaWdpQ2Vy
# dEFzc3VyZWRJRFJvb3RDQS5jcmwwOqA4oDaGNGh0dHA6Ly9jcmwzLmRpZ2ljZXJ0
# LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RDQS5jcmwwTwYDVR0gBEgwRjA4Bgpg
# hkgBhv1sAAIEMCowKAYIKwYBBQUHAgEWHGh0dHBzOi8vd3d3LmRpZ2ljZXJ0LmNv
# bS9DUFMwCgYIYIZIAYb9bAMwHQYDVR0OBBYEFFrEuXsqCqOl6nEDwGD5LfZldQ5Y
# MB8GA1UdIwQYMBaAFEXroq/0ksuCMS1Ri6enIZ3zbcgPMA0GCSqGSIb3DQEBCwUA
# A4IBAQA+7A1aJLPzItEVyCx8JSl2qB1dHC06GsTvMGHXfgtg/cM9D8Svi/3vKt8g
# VTew4fbRknUPUbRupY5a4l4kgU4QpO4/cY5jDhNLrddfRHnzNhQGivecRk5c/5Cx
# GwcOkRX7uq+1UcKNJK4kxscnKqEpKBo6cSgCPC6Ro8AlEeKcFEehemhor5unXCBc
# 2XGxDI+7qPjFEmifz0DLQESlE/DmZAwlCEIysjaKJAL+L3J+HNdJRZboWR3p+nRk
# a7LrZkPas7CM1ekN3fYBIM6ZMWM9CBoYs4GbT8aTEAb8B4H6i9r5gkn3Ym6hU/oS
# lBiFLpKR6mhsRDKyZqHnGKSaZFHvMIIGajCCBVKgAwIBAgIQAwGaAjr/WLFr1tXq
# 5hfwZjANBgkqhkiG9w0BAQUFADBiMQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGln
# aUNlcnQgSW5jMRkwFwYDVQQLExB3d3cuZGlnaWNlcnQuY29tMSEwHwYDVQQDExhE
# aWdpQ2VydCBBc3N1cmVkIElEIENBLTEwHhcNMTQxMDIyMDAwMDAwWhcNMjQxMDIy
# MDAwMDAwWjBHMQswCQYDVQQGEwJVUzERMA8GA1UEChMIRGlnaUNlcnQxJTAjBgNV
# BAMTHERpZ2lDZXJ0IFRpbWVzdGFtcCBSZXNwb25kZXIwggEiMA0GCSqGSIb3DQEB
# AQUAA4IBDwAwggEKAoIBAQCjZF38fLPggjXg4PbGKuZJdTvMbuBTqZ8fZFnmfGt/
# a4ydVfiS457VWmNbAklQ2YPOb2bu3cuF6V+l+dSHdIhEOxnJ5fWRn8YUOawk6qhL
# LJGJzF4o9GS2ULf1ErNzlgpno75hn67z/RJ4dQ6mWxT9RSOOhkRVfRiGBYxVh3lI
# RvfKDo2n3k5f4qi2LVkCYYhhchhoubh87ubnNC8xd4EwH7s2AY3vJ+P3mvBMMWSN
# 4+v6GYeofs/sjAw2W3rBerh4x8kGLkYQyI3oBGDbvHN0+k7Y/qpA8bLOcEaD6dpA
# oVk62RUJV5lWMJPzyWHM0AjMa+xiQpGsAsDvpPCJEY93AgMBAAGjggM1MIIDMTAO
# BgNVHQ8BAf8EBAMCB4AwDAYDVR0TAQH/BAIwADAWBgNVHSUBAf8EDDAKBggrBgEF
# BQcDCDCCAb8GA1UdIASCAbYwggGyMIIBoQYJYIZIAYb9bAcBMIIBkjAoBggrBgEF
# BQcCARYcaHR0cHM6Ly93d3cuZGlnaWNlcnQuY29tL0NQUzCCAWQGCCsGAQUFBwIC
# MIIBVh6CAVIAQQBuAHkAIAB1AHMAZQAgAG8AZgAgAHQAaABpAHMAIABDAGUAcgB0
# AGkAZgBpAGMAYQB0AGUAIABjAG8AbgBzAHQAaQB0AHUAdABlAHMAIABhAGMAYwBl
# AHAAdABhAG4AYwBlACAAbwBmACAAdABoAGUAIABEAGkAZwBpAEMAZQByAHQAIABD
# AFAALwBDAFAAUwAgAGEAbgBkACAAdABoAGUAIABSAGUAbAB5AGkAbgBnACAAUABh
# AHIAdAB5ACAAQQBnAHIAZQBlAG0AZQBuAHQAIAB3AGgAaQBjAGgAIABsAGkAbQBp
# AHQAIABsAGkAYQBiAGkAbABpAHQAeQAgAGEAbgBkACAAYQByAGUAIABpAG4AYwBv
# AHIAcABvAHIAYQB0AGUAZAAgAGgAZQByAGUAaQBuACAAYgB5ACAAcgBlAGYAZQBy
# AGUAbgBjAGUALjALBglghkgBhv1sAxUwHwYDVR0jBBgwFoAUFQASKxOYspkH7R7f
# or5XDStnAs0wHQYDVR0OBBYEFGFaTSS2STKdSip5GoNL9B6Jwcp9MH0GA1UdHwR2
# MHQwOKA2oDSGMmh0dHA6Ly9jcmwzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3Vy
# ZWRJRENBLTEuY3JsMDigNqA0hjJodHRwOi8vY3JsNC5kaWdpY2VydC5jb20vRGln
# aUNlcnRBc3N1cmVkSURDQS0xLmNybDB3BggrBgEFBQcBAQRrMGkwJAYIKwYBBQUH
# MAGGGGh0dHA6Ly9vY3NwLmRpZ2ljZXJ0LmNvbTBBBggrBgEFBQcwAoY1aHR0cDov
# L2NhY2VydHMuZGlnaWNlcnQuY29tL0RpZ2lDZXJ0QXNzdXJlZElEQ0EtMS5jcnQw
# DQYJKoZIhvcNAQEFBQADggEBAJ0lfhszTbImgVybhs4jIA+Ah+WI//+x1GosMe06
# FxlxF82pG7xaFjkAneNshORaQPveBgGMN/qbsZ0kfv4gpFetW7easGAm6mlXIV00
# Lx9xsIOUGQVrNZAQoHuXx/Y/5+IRQaa9YtnwJz04HShvOlIJ8OxwYtNiS7Dgc6aS
# wNOOMdgv420XEwbu5AO2FKvzj0OncZ0h3RTKFV2SQdr5D4HRmXQNJsQOfxu19aDx
# xncGKBXp2JPlVRbwuwqrHNtcSCdmyKOLChzlldquxC5ZoGHd2vNtomHpigtt7BIY
# vfdVVEADkitrwlHCCkivsNRu4PQUCjob4489yq9qjXvc2EQwggbNMIIFtaADAgEC
# AhAG/fkDlgOt6gAK6z8nu7obMA0GCSqGSIb3DQEBBQUAMGUxCzAJBgNVBAYTAlVT
# MRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5j
# b20xJDAiBgNVBAMTG0RpZ2lDZXJ0IEFzc3VyZWQgSUQgUm9vdCBDQTAeFw0wNjEx
# MTAwMDAwMDBaFw0yMTExMTAwMDAwMDBaMGIxCzAJBgNVBAYTAlVTMRUwEwYDVQQK
# EwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5jb20xITAfBgNV
# BAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMTCCASIwDQYJKoZIhvcNAQEBBQAD
# ggEPADCCAQoCggEBAOiCLZn5ysJClaWAc0Bw0p5WVFypxNJBBo/JM/xNRZFcgZ/t
# LJz4FlnfnrUkFcKYubR3SdyJxArar8tea+2tsHEx6886QAxGTZPsi3o2CAOrDDT+
# GEmC/sfHMUiAfB6iD5IOUMnGh+s2P9gww/+m9/uizW9zI/6sVgWQ8DIhFonGcIj5
# BZd9o8dD3QLoOz3tsUGj7T++25VIxO4es/K8DCuZ0MZdEkKB4YNugnM/JksUkK5Z
# ZgrEjb7SzgaurYRvSISbT0C58Uzyr5j79s5AXVz2qPEvr+yJIvJrGGWxwXOt1/HY
# zx4KdFxCuGh+t9V3CidWfA9ipD8yFGCV/QcEogkCAwEAAaOCA3owggN2MA4GA1Ud
# DwEB/wQEAwIBhjA7BgNVHSUENDAyBggrBgEFBQcDAQYIKwYBBQUHAwIGCCsGAQUF
# BwMDBggrBgEFBQcDBAYIKwYBBQUHAwgwggHSBgNVHSAEggHJMIIBxTCCAbQGCmCG
# SAGG/WwAAQQwggGkMDoGCCsGAQUFBwIBFi5odHRwOi8vd3d3LmRpZ2ljZXJ0LmNv
# bS9zc2wtY3BzLXJlcG9zaXRvcnkuaHRtMIIBZAYIKwYBBQUHAgIwggFWHoIBUgBB
# AG4AeQAgAHUAcwBlACAAbwBmACAAdABoAGkAcwAgAEMAZQByAHQAaQBmAGkAYwBh
# AHQAZQAgAGMAbwBuAHMAdABpAHQAdQB0AGUAcwAgAGEAYwBjAGUAcAB0AGEAbgBj
# AGUAIABvAGYAIAB0AGgAZQAgAEQAaQBnAGkAQwBlAHIAdAAgAEMAUAAvAEMAUABT
# ACAAYQBuAGQAIAB0AGgAZQAgAFIAZQBsAHkAaQBuAGcAIABQAGEAcgB0AHkAIABB
# AGcAcgBlAGUAbQBlAG4AdAAgAHcAaABpAGMAaAAgAGwAaQBtAGkAdAAgAGwAaQBh
# AGIAaQBsAGkAdAB5ACAAYQBuAGQAIABhAHIAZQAgAGkAbgBjAG8AcgBwAG8AcgBh
# AHQAZQBkACAAaABlAHIAZQBpAG4AIABiAHkAIAByAGUAZgBlAHIAZQBuAGMAZQAu
# MAsGCWCGSAGG/WwDFTASBgNVHRMBAf8ECDAGAQH/AgEAMHkGCCsGAQUFBwEBBG0w
# azAkBggrBgEFBQcwAYYYaHR0cDovL29jc3AuZGlnaWNlcnQuY29tMEMGCCsGAQUF
# BzAChjdodHRwOi8vY2FjZXJ0cy5kaWdpY2VydC5jb20vRGlnaUNlcnRBc3N1cmVk
# SURSb290Q0EuY3J0MIGBBgNVHR8EejB4MDqgOKA2hjRodHRwOi8vY3JsMy5kaWdp
# Y2VydC5jb20vRGlnaUNlcnRBc3N1cmVkSURSb290Q0EuY3JsMDqgOKA2hjRodHRw
# Oi8vY3JsNC5kaWdpY2VydC5jb20vRGlnaUNlcnRBc3N1cmVkSURSb290Q0EuY3Js
# MB0GA1UdDgQWBBQVABIrE5iymQftHt+ivlcNK2cCzTAfBgNVHSMEGDAWgBRF66Kv
# 9JLLgjEtUYunpyGd823IDzANBgkqhkiG9w0BAQUFAAOCAQEARlA+ybcoJKc4HbZb
# Ka9Sz1LpMUerVlx71Q0LQbPv7HUfdDjyslxhopyVw1Dkgrkj0bo6hnKtOHisdV0X
# FzRyR4WUVtHruzaEd8wkpfMEGVWp5+Pnq2LN+4stkMLA0rWUvV5PsQXSDj0aqRRb
# poYxYqioM+SbOafE9c4deHaUJXPkKqvPnHZL7V/CSxbkS3BMAIke/MV5vEwSV/5f
# 4R68Al2o/vsHOE8Nxl2RuQ9nRc3Wg+3nkg2NsWmMT/tZ4CMP0qquAHzunEIOz5HX
# J7cW7g/DvXwKoO4sCFWFIrjrGBpN/CohrUkxg0eVd3HcsRtLSxwQnHcUwZ1PL1qV
# CCkQJjGCBEwwggRIAgEBMIGGMHIxCzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdp
# Q2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5jb20xMTAvBgNVBAMTKERp
# Z2lDZXJ0IFNIQTIgQXNzdXJlZCBJRCBDb2RlIFNpZ25pbmcgQ0ECEAGfcm2O2qyx
# DgPgWB72KpowDQYJYIZIAWUDBAIBBQCggYQwGAYKKwYBBAGCNwIBDDEKMAigAoAA
# oQKAADAZBgkqhkiG9w0BCQMxDAYKKwYBBAGCNwIBBDAcBgorBgEEAYI3AgELMQ4w
# DAYKKwYBBAGCNwIBFTAvBgkqhkiG9w0BCQQxIgQgCCPKt4WoiY1sbAfnZKmxtY0e
# oDPZ+qZBOsAu+KHmiGQwDQYJKoZIhvcNAQEBBQAEggEAwBaoh3PcM+OcihX5zILU
# 8lE2Ph0f3sEPqmr/5Tzs/S6XDZqy2ux/Uh3sDLcsdk9gywFhBOr2g0G4AFucN+N/
# E6LFPKPS1po34+wK6w7Z8mcRU+7vNyxPxc7Lycm2HzefwYaFcSA6xbAhHvNiNLd+
# 1/BumSqlJPBwdDr9H4Ri86CSYj7xRDpafZ6WncqgAMaXsYWsTiwbbiekIcExvZgg
# BnQ3fEDNBdmK0WZCdZX93DZEYKLdSH6r6lSWRW5IHgzlCWL5OP415GzkHgxthx2m
# utxvJHuF+LpZfDACQswPX61XwGo61Y6qX+l7g4clG5SeFoK8wbgrR12P4EgECKzy
# 66GCAg8wggILBgkqhkiG9w0BCQYxggH8MIIB+AIBATB2MGIxCzAJBgNVBAYTAlVT
# MRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5j
# b20xITAfBgNVBAMTGERpZ2lDZXJ0IEFzc3VyZWQgSUQgQ0EtMQIQAwGaAjr/WLFr
# 1tXq5hfwZjAJBgUrDgMCGgUAoF0wGAYJKoZIhvcNAQkDMQsGCSqGSIb3DQEHATAc
# BgkqhkiG9w0BCQUxDxcNMTYwOTExMTkwMzE5WjAjBgkqhkiG9w0BCQQxFgQUBFvE
# Qx3Ondofr5v3IdqidXufRVUwDQYJKoZIhvcNAQEBBQAEggEANXU9soYMqHDm1v0E
# QcIMRTYPkv2xB/xDIc4JmhfFKMO3SUDA1m6lS2w6WWbhNu0GRTFT2Bed712y8qXI
# t9uO1BDTxDyl0lBYAKjUDnWI17cZpHEcx5snT1D2CYv29TfOpH9/+gzlddWrdB9q
# VTcEo1/hFH0B4ffgE8YNcw4jg+e7b3nKpGjBDwr6SqMWwTZv37qj/xvLubtzEKEi
# i1g6VG4tnvWcH2TD5bGmtzLZ8N1fyktdju8B5oscnSYeiX/Z26ZM2JN8coHNSW1k
# krCJqqlTJrihEOvqs/NiDKyq1lBh3Es/o6LaNxYDeHr/8ntIqfMpbI6ZB+7RW0XC
# B6o+Cw==
# SIG # End signature block
