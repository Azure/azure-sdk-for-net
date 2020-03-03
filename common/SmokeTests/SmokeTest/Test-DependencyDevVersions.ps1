param(
    $ProjectFile = './SmokeTest.csproj'
)

$PACKAGE_REFERENCE_XPATH = '//Project/ItemGroup/PackageReference'

# Match the dev.yyyymmdd portion of the version string
$DEV_DATE_REGEX = 'dev\.(\d{8})'

$baselineVersionDate = $null;
$exitCode = 0

[xml]$csproj = Get-Content $ProjectFile
$csproj |
    Select-XML $PACKAGE_REFERENCE_XPATH |
    Where-Object { $_.Node.HasAttribute('Version') } |
    ForEach-Object {
        if ($_.Node.Version -match $DEV_DATE_REGEX) {
            if ($baselineVersionDate -eq $null) {
                Write-Host "Setting baseline version date to: $($matches[1])"
                $baselineVersionDate = $matches[1]
            }

            if ($baselineVersionDate -ne $matches[1]) {
                Write-Host "ERROR: $($_.Node.Include) uses invalid version: $($_.Node.Version)"
                $exitCode = 1
            }
        }
    }

exit $exitCode