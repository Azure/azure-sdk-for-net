
Function Update-AADApplicationWithCertificate
{
    #SPN: PsAutoTestADAppUsingSPN
    #AppType: Web app/Api

    #AppId: b8a1058e-25e8-4b08-b40b-d8d871dda591
    #ObjectId: 676e21d1-cd49-41d7-9eb3-b8fd76ba7e67

    #HomePage: http://www.PsAutoTestADAppUsingSPN.com
    #AppId Uri: http://PsAutoTestADAppUsingSPN

    $localCert = Get-CertFromLocalStore

    $rawCertData = $localCert.GetRawCertData()

    $binaryAsciiCertData = [System.Convert]::ToBase64String($rawCertData)

    $startDate = Get-Date
    $endDate = [DateTime]::Parse($localCert.GetExpirationDateString())
                        
    #AD app does not exists, create one
    #$psAutoADApp = New-AzureRmADApplication -DisplayName "PsAutoTestADAppUsingSPN" -HomePage "http://www.PsAutoTestADAppUsingSPN.com" -IdentifierUris "http://www.PsAutoTestADAppUsingSPN.com" -CertValue $binaryAsciiCertData -StartDate $startDate -EndDate $endDate
    $psAutoADApp = New-AzureRmADApplication -DisplayName "PsAutoTestADAppUsingSPN" -HomePage "http://www.PsAutoTestADAppUsingSPN.com" -IdentifierUris "http://www.PsAutoTestADAppUsingSPN1.com" -CertValue $binaryAsciiCertData -StartDate $startDate -EndDate $endDate
    Log-Info "Updated SPN with local cert"
 }

Function Install-TestCertificateOnMachine([string] $localCertPath)
{
    $certSubject = "CN=TestCertForAuthLib"
    $certLocation = "cert:\CurrentUser\My"

    $cert = Get-CertFromLocalStore

    if($cert -eq $null)
    {
      Log-Info "Creating/Installing new certificate"
      
      #
      $cert = New-SelfSignedCertificate -CertStoreLocation $certLocation -Subject $certSubject -KeyExportPolicy Exportable -NotAfter (Get-Date).AddYears(1) -Type CodeSigningCert -KeySpec Signature
      #$cert = New-SelfSignedCertificate -DnsName "PsAutoTestADAppUsingSPN" -CertStoreLocation $certLocation -KeyExportPolicy Exportable -Provider "Microsoft Enhanced RSA and AES Cryptographic Provider"
      #$cert = New-SelfSignedCertificate -Subject $certSubject -CertStoreLocation $certLocation

      
      if($cert -eq $null)
      {
        $cert = Get-LocalCertifcate
      }
    }

    $certPwdProtectedInBytes = $cert.Export([System.Security.Cryptography.X509Certificates.X509ContentType]::Pkcs12)        
    $pfxLocalFilePath = "SpnAuthTest.cer"
    [System.IO.File]::WriteAllBytes($pfxLocalFilePath, $certPwdProtectedInBytes)

    return $cert
}


Function Get-CertFromLocalStore([string] $certSubject = "CN=TestCertForAuthLib")
{
    #TODO: Handle case whgere we get multiple test certificates with exactly the same subject
    $cert = Get-ChildItem "cert:\CurrentUser\My" | Where-Object {$_.Subject -eq $certSubject}
    if($cert -eq $null)
    {
        Log-Info "Trying to find certificate in LocalMachine"
        $cert = Get-ChildItem 'Cert:\LocalMachine\My' | Where-Object {$_.Subject -eq $certSubject}
    }

    if($cert -eq $null)
    {
        Log-Info "Unable to find locally installed certificate with subject $certSubject"
    }
    else
    {
        Log-Info "Retrieved locally installed certificate with subject $certSubject"
    }

    return $cert
}

Function Delete-LocalCertificate([bool]$deleteLocalCertificate)
{
    $cert = Get-CertFromLocalStore
    if($cert -ne $null -and $deleteLocalCertificate -eq $true)
    {
        $certPath = $cert.PSPath
        Log-Info "Deleting local certificate $certPath"
        Remove-Item $cert.PSPath
    }
}

Function Login-InteractivelyAndSelectTestSubscription()
{
    Log-Info "Logging interactively....."
    $global:gLoggedInCtx = Login-AzureRmAccount
    Log-Info "Selecting '$global:gPsAutoTestSubscriptionId' subscription"
    $global:gLoggedInCtx = Select-AzureRmSubscription -SubscriptionId $global:gPsAutoTestSubscriptionId

    return $global:gLoggedInCtx
}

Function Log-Info([string] $info)
{
    $info = [string]::Format("[INFO]: {0}", $info)
    Write-Host $info -ForegroundColor Yellow
}

Function Log-Error([string] $errorInfo)
{
    $errorInfo = [string]::Format("[INFO]: {0}", $errorInfo)
    Write-Error -Message $errorInfo
}

#Delete-LocalCertificate $true
Install-TestCertificateOnMachine
#Update-AADApplicationWithCertificate