[CmdletBinding()]
param()

. (Join-Path $PSScriptRoot common.ps1)

$allPackageProps = Get-AllPkgProperties

foreach ($packageProp in $allPackageProps) {
    $changeLogEntries = Get-ChangeLogEntries -ChangeLogLocation $packageProp.ChangeLogPath
    $package = $packageProp.Name
    $serviceDirectory = $packageProp.ServiceDirectory

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
