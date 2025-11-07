[CmdletBinding()]
param()

$repoRoot = Resolve-Path "$PSScriptRoot/../..";
. ${repoRoot}\eng\common\scripts\SemVer.ps1
. ${repoRoot}\eng\common\scripts\ChangeLog-Operations.ps1


Get-ChildItem "$repoRoot/sdk" -Filter CHANGELOG.md -Recurse | Sort-Object -Property Name | % {
    
    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $_ 
    $package = $_.Directory.Name
    $serviceDirectory = $_.Directory.Parent.Name

    foreach ($changeLogEntry in $changeLogEntries.Values)
    {
        if ($changeLogEntry.ReleaseStatus -eq "(Unreleased)")
        {
            $matters = ""
            $changeLogEntry.ReleaseContent | %{
                if ($_ -notmatch "^((#+.*)|(\s*)|(.*N\/A.*))`$")
                {
                    $matters += "$_`r`n"
                }
            }

            if ($matters.Length -gt 0)
            {
                Write-Host $package -Foreground Green
                Write-Verbose $matters

                break;
            }
        }
    }
}
