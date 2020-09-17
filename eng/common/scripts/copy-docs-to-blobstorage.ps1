# Note, due to how `Expand-Archive` is leveraged in this script,
# powershell core is a requirement for successful execution.
param (
  $AzCopy,
  $DocLocation,
  $SASKey,
  $Language,
  $BlobName,
  $ExitOnError=1,
  $UploadLatest=1,
  $PublicArtifactLocation = "",
  $RepoReplaceRegex = "(https://github.com/.*/(?:blob|tree)/)master"
)

. (Join-Path $PSScriptRoot common.ps1)

$Language = $Language.ToLower()

# Regex inspired but simplified from https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
$SEMVER_REGEX = "^(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-?(?<prelabel>[a-zA-Z-]*)(?:\.?(?<prenumber>0|[1-9]\d*))?)?$"

function ToSemVer($version){
    if ($version -match $SEMVER_REGEX)
    {
        if(-not $matches['prelabel']) {
            # artifically provide these values for non-prereleases to enable easy sorting of them later than prereleases.
            $prelabel = "zzz"
            $prenumber = 999;
            $isPre = $false;
        }
        else {
            $prelabel = $matches["prelabel"]
            $prenumber = 0

            # some older packages don't have a prenumber, should handle this
            if($matches["prenumber"]){
                $prenumber = [int]$matches["prenumber"]
            }

            $isPre = $true;
        }

        New-Object PSObject -Property @{
            Major = [int]$matches['major']
            Minor = [int]$matches['minor']
            Patch = [int]$matches['patch']
            PrereleaseLabel = $prelabel
            PrereleaseNumber = $prenumber
            IsPrerelease = $isPre
            RawVersion = $version
        }
    }
    else
    {
        if ($ExitOnError)
        {
            throw "Unable to convert $version to valid semver and hard exit on error is enabled. Exiting."
        }
        else
        {
            return $null
        }
    }
}

function SortSemVersions($versions)
{
    return $versions | Sort -Property Major, Minor, Patch, PrereleaseLabel, PrereleaseNumber -Descending
}

function Sort-Versions
{
    Param (
        [Parameter(Mandatory=$true)] [string[]]$VersionArray
    )

    # standard init and sorting existing
    $versionsObject = New-Object PSObject -Property @{
        OriginalVersionArray = $VersionArray
        SortedVersionArray = @()
        LatestGAPackage = ""
        RawVersionsList = ""
        LatestPreviewPackage = ""
    }

    if ($VersionArray.Count -eq 0)
    {
        return $versionsObject
    }

    $versionsObject.SortedVersionArray = @(SortSemVersions -versions ($VersionArray | % { ToSemVer $_}))
    $versionsObject.RawVersionsList = $versionsObject.SortedVersionArray | % { $_.RawVersion }

    # handle latest and preview
    # we only want to hold onto the latest preview if its NEWER than the latest GA.
    # this means that the latest preview package either A) has to be the latest value in the VersionArray
    # or B) set to nothing. We'll handle the set to nothing case a bit later.
    $versionsObject.LatestPreviewPackage = $versionsObject.SortedVersionArray[0].RawVersion
    $gaVersions = $versionsObject.SortedVersionArray | ? { !$_.IsPrerelease }

    # we have a GA package
    if ($gaVersions.Count -ne 0)
    {
        # GA is the newest non-preview package
        $versionsObject.LatestGAPackage = $gaVersions[0].RawVersion

        # in the case where latest preview == latestGA (because of our default selection earlier)
        if ($versionsObject.LatestGAPackage -eq $versionsObject.LatestPreviewPackage)
        {
            # latest is newest, unset latest preview
            $versionsObject.LatestPreviewPackage = ""
        }
    }

    return $versionsObject
}

function Get-Existing-Versions
{
    Param (
        [Parameter(Mandatory=$true)] [String]$PkgName
    )
    $versionUri = "$($BlobName)/`$web/$($Language)/$($PkgName)/versioning/versions"
    Write-Host "Heading to $versionUri to retrieve known versions"

    try {
        return ((Invoke-RestMethod -Uri $versionUri -MaximumRetryCount 3 -RetryIntervalSec 5) -Split "\n" | % {$_.Trim()} | ? { return $_ })
    }
    catch {
        # Handle 404. If it's 404, this is the first time we've published this package.
        if ($_.Exception.Response.StatusCode.value__ -eq 404){
            Write-Host "Version file does not exist. This is the first time we have published this package."
        }
        else {
            # If it's not a 404. exit. We don't know what's gone wrong.
            Write-Host "Exception getting version file. Aborting"
            Write-Host $_
            exit(1)
        }
    }
}

function Update-Existing-Versions
{
    Param (
        [Parameter(Mandatory=$true)] [String]$PkgName,
        [Parameter(Mandatory=$true)] [String]$PkgVersion,
        [Parameter(Mandatory=$true)] [String]$DocDest
    )
    $existingVersions = @(Get-Existing-Versions -PkgName $PkgName)

    Write-Host "Before I update anything, I am seeing $existingVersions"

    if (!$existingVersions)
    {
        $existingVersions = @()
        $existingVersions += $PkgVersion
        Write-Host "No existing versions. Adding $PkgVersion."
    }
    else
    {
        $existingVersions += $pkgVersion
        Write-Host "Already Existing Versions. Adding $PkgVersion."
    }

    $existingVersions = $existingVersions | Select-Object -Unique

    # newest first
    $sortedVersionObj = (Sort-Versions -VersionArray $existingVersions)

    Write-Host $sortedVersionObj
    Write-Host $sortedVersionObj.LatestGAPackage
    Write-Host $sortedVersionObj.LatestPreviewPackage

    # write to file. to get the correct performance with "actually empty" files, we gotta do the newline
    # join ourselves. This way we have absolute control over the trailing whitespace.
    $sortedVersionObj.RawVersionsList -join "`n" | Out-File -File "$($DocLocation)/versions" -Force -NoNewLine
    $sortedVersionObj.LatestGAPackage | Out-File -File "$($DocLocation)/latest-ga" -Force -NoNewLine
    $sortedVersionObj.LatestPreviewPackage | Out-File -File "$($DocLocation)/latest-preview" -Force -NoNewLine

    & $($AzCopy) cp "$($DocLocation)/versions" "$($DocDest)/$($PkgName)/versioning/versions$($SASKey)"
    & $($AzCopy) cp "$($DocLocation)/latest-preview" "$($DocDest)/$($PkgName)/versioning/latest-preview$($SASKey)"
    & $($AzCopy) cp "$($DocLocation)/latest-ga" "$($DocDest)/$($PkgName)/versioning/latest-ga$($SASKey)"

    return $sortedVersionObj
}

function Upload-Blobs
{
    Param (
        [Parameter(Mandatory=$true)] [String]$DocDir,
        [Parameter(Mandatory=$true)] [String]$PkgName,
        [Parameter(Mandatory=$true)] [String]$DocVersion,
        [Parameter(Mandatory=$false)] [String]$ReleaseTag
    )
    #eg : $BlobName = "https://azuresdkdocs.blob.core.windows.net"
    $DocDest = "$($BlobName)/`$web/$($Language)"

    Write-Host "DocDest $($DocDest)"
    Write-Host "PkgName $($PkgName)"
    Write-Host "DocVersion $($DocVersion)"
    Write-Host "DocDir $($DocDir)"
    Write-Host "Final Dest $($DocDest)/$($PkgName)/$($DocVersion)"
    Write-Host "Release Tag $($ReleaseTag)"

    # Use the step to replace master link to release tag link 
    if ($ReleaseTag) {
        foreach ($htmlFile in (Get-ChildItem $DocDir -include *.html -r)) 
        {
            $fileContent = Get-Content -Path $htmlFile
            $updatedFileContent = $fileContent -replace $RepoReplaceRegex, "`${1}$ReleaseTag"
            if ($updatedFileContent -ne $fileContent) {
                Set-Content -Path $htmlFile -Value $updatedFileContent
            }
        }
    } 
    else {
        Write-Warning "Not able to do the master link replacement, since no release tag found for the release. Please manually check."
    } 
   
    Write-Host "Uploading $($PkgName)/$($DocVersion) to $($DocDest)..."
    & $($AzCopy) cp "$($DocDir)/**" "$($DocDest)/$($PkgName)/$($DocVersion)$($SASKey)" --recursive=true

    Write-Host "Handling versioning files under $($DocDest)/$($PkgName)/versioning/"
    $versionsObj = (Update-Existing-Versions -PkgName $PkgName -PkgVersion $DocVersion -DocDest $DocDest)

    # we can safely assume we have AT LEAST one version here. Reason being we just completed Update-Existing-Versions
    $latestVersion = ($versionsObj.SortedVersionArray | Select-Object -First 1).RawVersion

    if ($UploadLatest -and ($latestVersion -eq $DocVersion))
    {
        Write-Host "Uploading $($PkgName) to latest folder in $($DocDest)..."
        & $($AzCopy) cp "$($DocDir)/**" "$($DocDest)/$($PkgName)/latest$($SASKey)" --recursive=true
    }
}

&$PublishGithubIODocsFn -DocLocation $DocLocation -PublicArtifactLocation $PublicArtifactLocation