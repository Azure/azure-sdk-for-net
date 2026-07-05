# Discovers all service directories containing a library with tsp-location.yaml
# pointing to eng/http-client-csharp-emitter-package.json and runs CodeChecks for each.

$tspLocations = Get-ChildItem -Path "./sdk" -Filter "tsp-location.yaml" -Recurse
$serviceDirectories = @()

foreach ($tspLocation in $tspLocations) {
    $content = Get-Content $tspLocation.FullName -Raw
    if ($content -match "eng/http-client-csharp-emitter-package.json") {
        $relativePath = $tspLocation.DirectoryName -replace ".*[\\/]sdk[\\/]", ""
        $serviceDirectory = $relativePath -replace "[\\/].*", ""
        if ($serviceDirectories -notcontains $serviceDirectory) {
            $serviceDirectories += $serviceDirectory
        }
    }
}

foreach ($serviceDirectory in $serviceDirectories) {
    Write-Host "Running CodeChecks for service directory: $serviceDirectory"
    ./eng/scripts/CodeChecks.ps1 -ServiceDirectory $serviceDirectory
}

