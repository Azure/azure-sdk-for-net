param(
    $framework = 'netcoreapp2.1' # 'netcoreapp2.1' or 'net461'
)

$PACKAGE_PATTERN = [Regex]::new('>\s(.*?)\s')

$rawDependencies = dotnet list package --framework $framework
$packageNames = $PACKAGE_PATTERN.Matches($rawDependencies) |
    ForEach-Object { $_.Groups[1].Value }

Write-Host Project Packages:
$packageNames | ForEach-Object { Write-Host $_ }

$availablePackagesList = Find-Package -Source NightlyFeed -AllowPrereleaseVersions
$availablePackages = @{}
$availablePackagesList | ForEach-Object { $availablePackages[$_.Name] = $_ }

$packageNames | ForEach-Object {
    if (-not $availablePackages.ContainsKey($_)) {
        return;
    }
    $targetPackage = $availablePackages[$_]
    Write-Host "Adding Package $($targetPackage.Name) @ $($targetPackage.Version)"
    dotnet add package $targetPackage.Name --version $targetPackage.Version
}

Write-Host === CSPROJ CONTENT ===
Get-Content SmokeTest.csproj | Write-Host

Write-Host Restoring packages...
dotnet restore