param(
    $ProjectFile = './SmokeTest.csproj',
    $FeedName = 'NightlyFeed'
)

$PACKAGE_EXCLUSIONS = @{
    'Azure.Security.Keyvault.Secrets' = @{
        '4.1.0-dev.20191102.1' = $true;
        '4.1.0-dev.20191103.1' = $true;
        '4.1.0-dev.20191104.1' = $true;
        '4.1.0-dev.20191105.1' = $true;
        '4.1.0-dev.20191106.1' = $true;
        '4.1.0-dev.20191107.1' = $true;
        '4.1.0-dev.20191108.1' = $true;
        '4.1.0-dev.20191109.2' = $true;
        '4.1.0-dev.20191110.1' = $true;
        '4.1.0-dev.20191111.1' = $true;
        '4.1.0-dev.20191112.1' = $true;
        '4.1.0-dev.20191113.1' = $true;
        '4.1.0-dev.20191114.1' = $true;
        '4.1.0-dev.20191115.1' = $true;
        '4.1.0-dev.20191116.1' = $true;
        '4.1.0-dev.20191117.1' = $true;
        '4.1.0-dev.20191118.1' = $true;
        '4.1.0-dev.20191119.1' = $true;
        '4.1.0-dev.20191120.1' = $true;
        '4.1.0-dev.20191121.1' = $true;
        '4.1.0-dev.20191122.1' = $true;
        '4.1.0-dev.20191123.1' = $true;
        '4.1.0-dev.20191124.1' = $true;
        '4.1.0-dev.20191125.1' = $true;
        '4.1.0-dev.20191127.1' = $true;
        '4.1.0-dev.20191128.1' = $true;
        '4.1.0-dev.20191129.1' = $true;
        '4.1.0-dev.20191130.1' = $true;
        '4.1.0-dev.20191201.1' = $true;
        '4.1.0-dev.20191202.1' = $true;
        '4.1.0-dev.20191203.1' = $true;
        '4.1.0-dev.20191204.1' = $true;
        '4.1.0-dev.20191205.1' = $true;
        '4.1.0-dev.20191206.1' = $true;
        '4.1.0-dev.20191207.1' = $true;
        '4.1.0-dev.20191208.1' = $true;
        '4.1.0-dev.20191209.1' = $true;
        '4.1.0-dev.20191210.1' = $true;
        '4.1.0-dev.20191211.1' = $true;
        '4.1.0-dev.20191212.1' = $true;
        '4.1.0-dev.20191213.1' = $true;
        '4.1.0-dev.20191214.1' = $true;
        '4.1.0-dev.20191215.1' = $true;
        '4.1.0-dev.20191216.1' = $true;
        '4.1.0-dev.20191217.1' = $true;
        '4.1.0-dev.20191218.1' = $true;
        '4.1.0-dev.20191219.1' = $true;
        '4.1.0-dev.20191220.3' = $true;
        '4.1.0-dev.20191221.1' = $true;
        '4.1.0-dev.20191222.1' = $true;
        '4.1.0-dev.20191223.1' = $true;
        '4.1.0-dev.20191224.1' = $true;
        '4.1.0-dev.20191225.1' = $true;
        '4.1.0-dev.20191226.1' = $true;
        '4.1.0-dev.20191227.1' = $true;
        '4.1.0-dev.20191228.1' = $true;
        '4.1.0-dev.20191229.1' = $true;
        '4.1.0-dev.20191230.1' = $true;
        '4.1.0-dev.20191231.1' = $true;
        '4.1.0-dev.20200101.1' = $true;
        '4.1.0-dev.20200102.1' = $true;
        '4.1.0-dev.20200103.1' = $true;
        '4.1.0-dev.20200104.1' = $true;
        '4.1.0-dev.20200105.1' = $true;
        '4.1.0-dev.20200106.1' = $true;
        '4.1.0-dev.20200107.1' = $true;
        '4.1.0-dev.20200108.1' = $true;
        '5.0.0-dev.20190625.1' = $true;
        '5.0.0-dev.20190626.1' = $true;
        '5.0.0-dev.20190627.1' = $true;
    }
}

$PACKAGE_REFERENCE_XPATH = '//Project/ItemGroup/PackageReference'

# List all packages from the source specified by $FeedName. Packages are sorted
# ascending by version according to semver rules (e.g. 4.0.0-preview.1 comes
# before 4.0.0) not lexicographically.
# Packages cannot be filtered at this stage because the sleet feed to which they
# are published does not support filtering by name. 
$allPackages = Find-Package -Source $FeedName -AllVersion -AllowPrereleaseVersions

# For each PackageReferecne in the csproj, find the latest version of that
# package from the dev feed which is not in the excluded list.
$projectFilePath = Resolve-Path -Path $ProjectFile
[xml]$csproj = Get-Content $ProjectFile
$csproj |
    Select-XML $PACKAGE_REFERENCE_XPATH |
    Where-Object { $_.Node.HasAttribute('Version') } |
    ForEach-Object {
        $packageName = $_.Node.Include

        # This assumes that the versions coming back from Find-Package are
        # sorted ascending. It excludes any version that is in the corresponding
        # $PACKAGE_EXCLUSIONS entry
        $targetVersion = ($allPackages |
            Where-Object { $_.Name -eq $packageName } |
            Where-Object { -not ( $PACKAGE_EXCLUSIONS.ContainsKey($packageName) -and $PACKAGE_EXCLUSIONS[$packageName].ContainsKey($_.Version)) } |
            Select-Object -Last 1).Version

        if ($targetVersion -eq $null) {
            return
        }

        Write-Host "Setting $packageName to $targetVersion"
        $_.Node.Version = "$targetVersion"
    }

$csproj.Save($projectFilePath)
