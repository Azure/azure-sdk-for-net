[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory
)

$root = "$PSScriptRoot/../../sdk/$ServiceDirectory"

foreach ($projectDirName in Get-ChildItem -Directory $root -Filter "Azure.*")
{
    $sampleReadmePath = $root + '/' + $projectDirName + '/samples/README.md';
    if (Test-Path $sampleReadmePath) {
        $content = Get-Content -Path $sampleReadmePath
        $matches = $content | Select-String -Pattern ".md\)"
        foreach ($match in $matches)
        {
            $relLink = $match | Select-String -NotMatch "\(http"
            if ($relLink)
            {
                LogError "Absolute links to GitHub should be used in the samples readme file: $sampleReadmePath, link: $relLink"
            }
        }
    }
}
