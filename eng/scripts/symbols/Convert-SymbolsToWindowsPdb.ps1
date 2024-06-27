[CmdletBinding()]
param (
    [Parameter(Mandatory=$true, HelpMessage='Path to the Pdb2Pdb tool')]
    [ValidateScript({Test-Path $_ -PathType 'Leaf'}, ErrorMessage='PdbToolPath does not exist or is not a file')]
    [string]
    $PdbToolPath,

    [Parameter(Mandatory=$true, HelpMessage='Path to the directory containing the symbols packages')]
    [ValidateScript({Test-Path $_ -PathType 'Container'}, ErrorMessage='{0} must be a valid directory')]
    [string]
    $PackagesPath,

    [Parameter(Mandatory=$true)]
    [string]
    $OutputPath
)

$PdbToolPath = Resolve-Path $PdbToolPath
$PackagesPath = Resolve-Path $PackagesPath
if (-not (Test-Path $OutputPath)) {
    New-Item -ItemType Directory -Path $OutputPath | Out-Null
}
$OutputPath = Resolve-Path $OutputPath

$symbolsPackages = Get-ChildItem -Path $PackagesPath -Filter '*.symbols.nupkg'

$tempFolder = Join-Path ([IO.Path]::GetTempPath()) $([IO.Path]::GetRandomFileName())
New-Item -ItemType Directory -Path $tempFolder -Force | Out-Null
Push-Location
try {
    foreach ($symbolsPackage in $symbolsPackages) {
        $outDirectory = Join-Path $OutputPath $symbolsPackage.BaseName

        Write-Host "Extracting $symbolsPackage to $outDirectory"
        Expand-Archive -Path $symbolsPackage -DestinationPath $outDirectory -Force
        Set-Location $outDirectory

        $dllFiles = Get-ChildItem -Path . -Filter '*.dll' -Recurse
        
        foreach ($dllFile in $dllFiles) {
            $pdbFile = Join-Path $dllFile.Directory "$($dllFile.BaseName).pdb"
            if (-not (Test-Path $pdbFile)) {
                Write-Host "PDB file not found for $dllFile"
                continue
            }
            
            Write-Host "Converting $pdbFile to Windows PDB format"
            & $PdbToolPath $dllFile /out "$pdbFile.out"

            if ($LASTEXITCODE -ne 0) {
                exit $LASTEXITCODE
            }

            Move-Item -Path "$pdbFile.out" -Destination $pdbFile -Force
        }
    }
}
finally {
    Pop-Location
    Remove-Item $tempFolder -Recurse -Force
}
