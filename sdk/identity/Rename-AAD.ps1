# Define the old and new terminology
$terminology = @(
    @{ Key = 'Azure AD External Identities'; Value = 'Microsoft Entra External ID' },
    @{ Key = 'Azure AD Identity Governance'; Value = 'Microsoft Entra ID Governance' },
    @{ Key = 'Azure AD Verifiable Credentials'; Value = 'Microsoft Entra Verified ID' },
    @{ Key = 'Azure AD Workload Identities'; Value = 'Microsoft Entra Workload ID' },
    @{ Key = 'Azure AD Workload Identity'; Value = 'Microsoft Entra Workload ID' },
    @{ Key = 'Azure AD Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'Azure AD access token authentication'; Value = 'Microsoft Entra access token authentication' },
    @{ Key = 'Azure AD admin center'; Value = 'Microsoft Entra admin center' },
    @{ Key = 'Azure AD portal'; Value = 'Microsoft Entra portal' },
    @{ Key = 'Azure AD token'; Value = 'Microsoft Entra token' },
    @{ Key = 'Azure AD application proxy'; Value = 'Microsoft Entra application proxy' },
    @{ Key = 'Azure AD authentication'; Value = 'Microsoft Entra authentication' },
    @{ Key = 'Azure AD Conditional Access'; Value = 'Microsoft Entra Conditional Access' },
    @{ Key = 'Azure AD cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'Azure AD Connect'; Value = 'Microsoft Entra Connect' },
    @{ Key = 'AD Connect'; Value = 'Microsoft Entra Connect' },
    @{ Key = 'AD Connect Sync'; Value = 'Microsoft Entra Connect Sync' },
    @{ Key = 'Azure AD Connect Sync'; Value = 'Microsoft Entra Connect Sync' },
    @{ Key = 'Azure AD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure AD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure AD Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'Azure AD Enterprise Applications'; Value = 'Microsoft Entra enterprise applications' },
    @{ Key = 'Azure AD federation services'; Value = 'Active Directory Federation Services' },
    @{ Key = 'Azure AD hybrid identities'; Value = 'Microsoft Entra hybrid identities' },
    @{ Key = 'Azure AD identities'; Value = 'Microsoft Entra identities' },
    @{ Key = 'Azure AD role'; Value = 'Microsoft Entra role' },
    @{ Key = 'Azure Active Directory (Azure AD)'; Value = 'Microsoft Entra ID (ME-ID)' },
    @{ Key = 'Azure AD'; Value = 'Microsoft Entra ID' },
    @{ Key = 'AAD'; Value = 'ME-ID' },
    @{ Key = 'Azure AD auth'; Value = 'Microsoft Entra auth' },
    @{ Key = 'Azure AD-only auth'; Value = 'Microsoft Entra-only auth' },
    @{ Key = 'Azure AD object'; Value = 'Microsoft Entra object' },
    @{ Key = 'Azure AD identity'; Value = 'Microsoft Entra identity' },
    @{ Key = 'Azure AD schema'; Value = 'Microsoft Entra schema' },
    @{ Key = 'Azure AD seamless single sign-on'; Value = 'Microsoft Entra seamless single sign-on' },
    @{ Key = 'Azure AD self-service password reset'; Value = 'Microsoft Entra self-service password reset' },
    @{ Key = 'Azure AD SSPR'; Value = 'Microsoft Entra SSPR' },
    @{ Key = 'Azure AD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure AD group'; Value = 'Microsoft Entra group' },
    @{ Key = 'Azure AD login'; Value = 'Microsoft Entra login' },
    @{ Key = 'Azure AD managed'; Value = 'Microsoft Entra managed' },
    @{ Key = 'Azure AD entitlement'; Value = 'Microsoft Entra entitlement' },
    @{ Key = 'Azure AD access review'; Value = 'Microsoft Entra access review' },
    @{ Key = 'Azure AD Identity Protection'; Value = 'Microsoft Entra ID Protection' },
    @{ Key = 'Azure AD pass-through'; Value = 'Microsoft Entra pass-through' },
    @{ Key = 'Azure AD password'; Value = 'Microsoft Entra password' },
    @{ Key = 'Azure AD Privileged Identity Management'; Value = 'Microsoft Entra Privilegd Identity Management' },
    @{ Key = 'Azure AD registered'; Value = 'Microsoft Entra registered' },
    @{ Key = 'Azure AD reporting and monitoring'; Value = 'Microsoft Entra reporting and monitoring' },
    @{ Key = 'Azure AD enterprise app'; Value = 'Microsoft Entra enterprise app' },
    @{ Key = 'Azure AD cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'Cloud Knox'; Value = 'Microsoft Entra Permissions Management' },
    @{ Key = 'Azure AD Premium P1'; Value = 'Microsoft Entra ID P1' },
    @{ Key = 'AD Premium P1'; Value = 'Microsoft Entra ID P1' },
    @{ Key = 'Azure AD Premium P2'; Value = 'Microsoft Entra ID P2' },
    @{ Key = 'AD Premium P2'; Value = 'Microsoft Entra ID P2' },
    @{ Key = 'Azure AD F2'; Value = 'Microsoft Entra ID F2' },
    @{ Key = 'Azure AD Free'; Value = 'Microsoft Entra ID Free' },
    @{ Key = 'Azure AD for education'; Value = 'Microsoft Entra ID for education' },
    @{ Key = 'Azure AD work or school account'; Value = 'Microsoft Entra work or school account' },
    @{ Key = 'federated with Azure AD'; Value = 'federated with Microsoft Entra' },
    @{ Key = 'Hybrid Azure AD Join'; Value = 'Microsoft Entra hybrid join' },
    @{ Key = 'Azure Active Directory External Identities'; Value = 'Microsoft Entra External ID' },
    @{ Key = 'Azure Active Directory Identity Governance'; Value = 'Microsoft Entra ID Governance' },
    @{ Key = 'Azure Active Directory Verifiable Credentials'; Value = 'Microsoft Entra Verified ID' },
    @{ Key = 'Azure Active Directory Workload Identities'; Value = 'Microsoft Entra Workload ID' },
    @{ Key = 'Azure Active Directory Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'Azure Active Directory access token authentication'; Value = 'Microsoft Entra access token authentication' },
    @{ Key = 'Azure Active Directory admin center'; Value = 'Microsoft Entra admin center' },
    @{ Key = 'Azure Active Directory portal'; Value = 'Microsoft Entra portal' },
    @{ Key = 'Azure Active Directory application proxy'; Value = 'Microsoft Entra application proxy' },
    @{ Key = 'Azure Active Directory authentication'; Value = 'Microsoft Entra authentication' },
    @{ Key = 'Azure Active Directory Conditional Access'; Value = 'Microsoft Entra Conditional Access' },
    @{ Key = 'Azure Active Directory cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'Azure Active Directory Connect'; Value = 'Microsoft Entra Connect' },
    @{ Key = 'Azure Active Directory Connect Sync'; Value = 'Microsoft Entra Connect Sync' },
    @{ Key = 'Azure Active Directory domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure Active Directory domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure Active Directory Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'Azure Active Directory Enterprise Applications'; Value = 'Microsoft Entra enterprise applications' },
    @{ Key = 'Azure Active Directory federation services'; Value = 'Active Directory Federation Services' },
    @{ Key = 'Azure Active Directory hybrid identities'; Value = 'Microsoft Entra hybrid identities' },
    @{ Key = 'Azure Active Directory identities'; Value = 'Microsoft Entra identities' },
    @{ Key = 'Azure Active Directory role'; Value = 'Microsoft Entra role' },
    @{ Key = 'Azure Active Directory'; Value = 'Microsoft Entra ID' },
    @{ Key = 'Azure Active Directory auth'; Value = 'Microsoft Entra auth' },
    @{ Key = 'Azure Active Directory-only auth'; Value = 'Microsoft Entra-only auth' },
    @{ Key = 'Azure Active Directory object'; Value = 'Microsoft Entra object' },
    @{ Key = 'Azure Active Directory identity'; Value = 'Microsoft Entra identity' },
    @{ Key = 'Azure Active Directory schema'; Value = 'Microsoft Entra schema' },
    @{ Key = 'Azure Active Directory seamless single sign-on'; Value = 'Microsoft Entra seamless single sign-on' },
    @{ Key = 'Azure Active Directory self-service password reset'; Value = 'Microsoft Entra self-service password reset' },
    @{ Key = 'Azure Active Directory SSPR'; Value = 'Microsoft Entra SSPR' },
    @{ Key = 'Azure Active Directory SSPR'; Value = 'Microsoft Entra SSPR' },
    @{ Key = 'Azure Active Directory domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'Azure Active Directory group'; Value = 'Microsoft Entra group' },
    @{ Key = 'Azure Active Directory login'; Value = 'Microsoft Entra login' },
    @{ Key = 'Azure Active Directory managed'; Value = 'Microsoft Entra managed' },
    @{ Key = 'Azure Active Directory entitlement'; Value = 'Microsoft Entra entitlement' },
    @{ Key = 'Azure Active Directory access review'; Value = 'Microsoft Entra access review' },
    @{ Key = 'Azure Active Directory Identity Protection'; Value = 'Microsoft Entra ID Protection' },
    @{ Key = 'Azure Active Directory pass-through'; Value = 'Microsoft Entra pass-through' },
    @{ Key = 'Azure Active Directory password'; Value = 'Microsoft Entra password' },
    @{ Key = 'Azure Active Directory Privileged Identity Management'; Value = 'Microsoft Entra Privilegd Identity Management' },
    @{ Key = 'Azure Active Directory registered'; Value = 'Microsoft Entra registered' },
    @{ Key = 'Azure Active Directory reporting and monitoring'; Value = 'Microsoft Entra reporting and monitoring' },
    @{ Key = 'Azure Active Directory enterprise app'; Value = 'Microsoft Entra enterprise app' },
    @{ Key = 'Azure Active Directory cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'Azure Active Directory Premium P1'; Value = 'Microsoft Entra ID P1' },
    @{ Key = 'Azure Active Directory Premium P2'; Value = 'Microsoft Entra ID P2' },
    @{ Key = 'Azure Active Directory F2'; Value = 'Microsoft Entra ID F2' },
    @{ Key = 'Azure Active Directory Free'; Value = 'Microsoft Entra ID Free' },
    @{ Key = 'Azure Active Directory for education'; Value = 'Microsoft Entra ID for education' },
    @{ Key = 'Azure Active Directory work or school account'; Value = 'Microsoft Entra work or school account' },
    @{ Key = 'federated with Azure Active Directory'; Value = 'federated with Microsoft Entra' },
    @{ Key = 'Hybrid Azure Active Directory Join'; Value = 'Microsoft Entra hybrid join' },
    @{ Key = 'AAD External Identities'; Value = 'Microsoft Entra External ID' },
    @{ Key = 'AAD Identity Governance'; Value = 'Microsoft Entra ID Governance' },
    @{ Key = 'AAD Verifiable Credentials'; Value = 'Microsoft Entra Verified ID' },
    @{ Key = 'AAD Workload Identities'; Value = 'Microsoft Entra Workload ID' },
    @{ Key = 'AAD Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'AAD access token authentication'; Value = 'Microsoft Entra access token authentication' },
    @{ Key = 'AAD admin center'; Value = 'Microsoft Entra admin center' },
    @{ Key = 'AAD portal'; Value = 'Microsoft Entra portal' },
    @{ Key = 'AAD application proxy'; Value = 'Microsoft Entra application proxy' },
    @{ Key = 'AAD authentication'; Value = 'Microsoft Entra authentication' },
    @{ Key = 'AAD Conditional Access'; Value = 'Microsoft Entra Conditional Access' },
    @{ Key = 'AAD cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'AAD Connect'; Value = 'Microsoft Entra Connect' },
    @{ Key = 'AAD Connect Sync'; Value = 'Microsoft Entra Connect Sync' },
    @{ Key = 'AAD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'AAD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'AAD Domain Services'; Value = 'Microsoft Entra Domain Services' },
    @{ Key = 'AAD Enterprise Applications'; Value = 'Microsoft Entra enterprise applications' },
    @{ Key = 'AAD federation services'; Value = 'Active Directory Federation Services' },
    @{ Key = 'AAD hybrid identities'; Value = 'Microsoft Entra hybrid identities' },
    @{ Key = 'AAD identities'; Value = 'Microsoft Entra identities' },
    @{ Key = 'AAD role'; Value = 'Microsoft Entra role' },
    @{ Key = 'AAD'; Value = 'Microsoft Entra ID' },
    @{ Key = 'AAD auth'; Value = 'Microsoft Entra auth' },
    @{ Key = 'AAD-only auth'; Value = 'Microsoft Entra-only auth' },
    @{ Key = 'AAD object'; Value = 'Microsoft Entra object' },
    @{ Key = 'AAD identity'; Value = 'Microsoft Entra identity' },
    @{ Key = 'AAD schema'; Value = 'Microsoft Entra schema' },
    @{ Key = 'AAD seamless single sign-on'; Value = 'Microsoft Entra seamless single sign-on' },
    @{ Key = 'AAD self-service password reset'; Value = 'Microsoft Entra self-service password reset' },
    @{ Key = 'AAD SSPR'; Value = 'Microsoft Entra SSPR' },
    @{ Key = 'AAD SSPR'; Value = 'Microsoft Entra SSPR' },
    @{ Key = 'AAD domain'; Value = 'Microsoft Entra domain' },
    @{ Key = 'AAD group'; Value = 'Microsoft Entra group' },
    @{ Key = 'AAD login'; Value = 'Microsoft Entra login' },
    @{ Key = 'AAD managed'; Value = 'Microsoft Entra managed' },
    @{ Key = 'AAD entitlement'; Value = 'Microsoft Entra entitlement' },
    @{ Key = 'AAD access review'; Value = 'Microsoft Entra access review' },
    @{ Key = 'AAD Identity Protection'; Value = 'Microsoft Entra ID Protection' },
    @{ Key = 'AAD pass-through'; Value = 'Microsoft Entra pass-through' },
    @{ Key = 'AAD password'; Value = 'Microsoft Entra password' },
    @{ Key = 'AAD Privileged Identity Management'; Value = 'Microsoft Entra Privilegd Identity Management' },
    @{ Key = 'AAD registered'; Value = 'Microsoft Entra registered' },
    @{ Key = 'AAD reporting and monitoring'; Value = 'Microsoft Entra reporting and monitoring' },
    @{ Key = 'AAD enterprise app'; Value = 'Microsoft Entra enterprise app' },
    @{ Key = 'AAD cloud-only identities'; Value = 'Microsoft Entra cloud-only identities' },
    @{ Key = 'AAD Premium P1'; Value = 'Microsoft Entra ID P1' },
    @{ Key = 'AAD Premium P2'; Value = 'Microsoft Entra ID P2' },
    @{ Key = 'AAD F2'; Value = 'Microsoft Entra ID F2' },
    @{ Key = 'AAD Free'; Value = 'Microsoft Entra ID Free' },
    @{ Key = 'AAD for education'; Value = 'Microsoft Entra ID for education' },
    @{ Key = 'AAD work or school account'; Value = 'Microsoft Entra work or school account' },
    @{ Key = 'federated with AAD'; Value = 'federated with Microsoft Entra' },
    @{ Key = 'Hybrid AAD Join'; Value = 'Microsoft Entra hybrid join' }
)

$postTransforms = @(
    @{ Key = 'Microsoft Entra ID B2C'; Value = 'Azure AD B2C' },
    @{ Key = 'Microsoft Entra ID B2B'; Value = 'Microsoft Entra B2B' },
    @{ Key = 'ME-ID B2C'; Value = 'AAD B2C' },
    @{ Key = 'ME-ID B2B'; Value = 'Microsoft Entra B2B' },
    @{ Key = 'ME-IDSTS'; Value = 'AADSTS' },
    @{ Key = 'ME-ID Connect'; Value = 'Microsoft Entra Connect' }
    @{ Key = 'Microsoft Entra ID tenant'; Value = 'Microsoft Entra tenant' }
    @{ Key = 'Microsoft Entra ID organization'; Value = 'Microsoft Entra tenant' }
    @{ Key = 'Microsoft Entra ID account'; Value = 'Microsoft Entra account' }
    @{ Key = 'Microsoft Entra ID resources'; Value = 'Microsoft Entra resources' }
    @{ Key = 'Microsoft Entra ID admin'; Value = 'Microsoft Entra admin' }
    @{ Key = ' an Microsoft Entra'; Value = ' a Microsoft Entra' }
    @{ Key = '>An Microsoft Entra'; Value = '>A Microsoft Entra' }
    @{ Key = ' an ME-ID'; Value = ' a ME-ID' }
    @{ Key = '>An ME-ID'; Value = '>A ME-ID' }
    @{ Key = 'Microsoft Entra ID administration portal'; Value = 'Microsoft Entra administration portal' }
    @{ Key = 'Microsoft Entra ID Advanced Threat'; Value = 'Azure Advanced Threat' }
    @{ Key = 'Entra ID hybrid join'; Value = 'Entra hybrid join' }
    @{ Key = 'Microsoft Entra ID join'; Value = 'Microsoft Entra join' }
    @{ Key = 'ME-ID join'; Value = 'Microsoft Entra join' }
    @{ Key = 'Microsoft Entra ID service principal'; Value = 'Microsoft Entra service principal' }
    @{ Key = 'Download Microsoft Entra Connector'; Value = 'Download connector' }
    @{ Key = 'Microsoft Microsoft'; Value = 'Microsoft' }
)

# Sort the replacements by the length of the keys in descending order
$terminology = $terminology.GetEnumerator() | Sort-Object -Property { $_.Key.Length } -Descending
$postTransforms = $postTransforms.GetEnumerator() | Sort-Object -Property { $_.Key.Length } -Descending

# Get all resx files in the current directory and its subdirectories, ignoring .gitignored files.
Write-Host "Getting all resx files in the current directory and its subdirectories, ignoring .gitignored files."
$gitIgnoreFiles = Get-ChildItem -Path . -Filter .gitignore -Recurse
$targetFiles = Get-ChildItem -Path . -Include "*.md" -Recurse

$filteredFiles = @()
foreach ($file in $targetFiles) {
    $ignoreFile = $gitIgnoreFiles | Where-Object { $_.DirectoryName -eq $file.DirectoryName }
    if ($ignoreFile) {
        $excludedPatterns = Get-Content $ignoreFile.FullName | Select-String -Pattern '^(?!#).*' | ForEach-Object { $_.Line }
        if ($excludedPatterns -notcontains $file.Name) {
            $filteredFiles += $file
        }
    }
    else {
        $filteredFiles += $file
    }
}

$scriptPath = $MyInvocation.MyCommand.Path
$filteredFiles = $filteredFiles | Where-Object { $_.FullName -ne $scriptPath }

# This command will get all the files with the extensions .resx in the current directory and its subdirectories, and then filter out those that match the patterns in the .gitignore file. The Resolve-Path cmdlet will find the full path of the .gitignore file, and the Get-Content cmdlet will read its content as a single string. The -notmatch operator will compare the full name of each file with the .gitignore content using regular expressions, and return only those that do not match.
Write-Host "Found $($filteredFiles.Count) files."

function Update-Terminology {
    param (
        [Parameter(Mandatory = $true)]
        [ref]$Content,
        [Parameter(Mandatory = $true)]
        [object[]]$Terminology
    )

    foreach ($item in $Terminology.GetEnumerator()) {
        $old = [regex]::Escape($item.Key)
        $new = $item.Value
        $toReplace = '(?<!(name=\"[^$]{1,100}|https?://aka.ms/[a-z0-9/-]{1,100}))' + $($old)

        # Replace the old terminology with the new one
        $Content.Value = $Content.Value -creplace $toReplace, $new
    }
}

# Loop through each file
foreach ($file in $filteredFiles) {
    # Read the content of the file
    $content = Get-Content $file.FullName

    Write-Host "Processing $file"

    Update-Terminology -Content ([ref]$content) -Terminology $terminology
    Update-Terminology -Content ([ref]$content) -Terminology $postTransforms

    $newContent = $content -join "`n"
    if ($newContent -ne (Get-Content $file.FullName -Raw)) {
        Write-Host "Updating $file"
        # Write the updated content back to the file
        Set-Content -Path $file.FullName -Value $newContent
    }
}