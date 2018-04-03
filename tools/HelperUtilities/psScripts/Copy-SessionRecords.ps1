# ---------------------------------------------------------------------------------- 
    # Copyright (c) Microsoft Corporation. All rights reserved.
    # Licensed under the MIT License. See License.txt in the project root for
    # license information.
# ---------------------------------------------------------------------------------- 

<#

.SYNOPSIS
    Powershell script that copies newly recorded session records from source to destination

.DESCRIPTION
    This script copies newly recorded session records from source to destination

.PARAMETER SourceRootDirectory
    Full path to directory where session records are (usually the bin directory of recorded test)

.PARAMETER DestinationRootDirectory
    Location where to copy the files
#>

[cmdletbinding(SupportsShouldProcess=$True)]
Param(
    [Parameter(Mandatory = $true)]
    [string] $SourceRootDirectory,
    [Parameter(Mandatory = $true)]
    [string] $DestinationRootDirectory
)

Begin {
    if (-not $PSBoundParameters.ContainsKey('Confirm')) {
        $ConfirmPreference = $PSCmdlet.SessionState.PSVariable.GetValue('ConfirmPreference')
    }
    if (-not $PSBoundParameters.ContainsKey('WhatIf')) {
        $WhatIfPreference = $PSCmdlet.SessionState.PSVariable.GetValue('WhatIfPreference')
    }
    Write-Verbose ('[{0}] Confirm={1} ConfirmPreference={2} WhatIf={3} WhatIfPreference={4}' -f $MyInvocation.MyCommand, $Confirm, $ConfirmPreference, $WhatIf, $WhatIfPreference)
}

Process
{
    $srcFiles = (Get-ChildItem -Path $SourceRootDirectory -Recurse) | Where-Object {$_ -is [System.IO.FileInfo]}
    $destFiles = (Get-ChildItem -Path $DestinationRootDirectory -Recurse) | Where-Object {$_ -is [System.IO.FileInfo]}

    foreach($srcFile in $srcFiles)
    {
        foreach($destFile in $destFiles)
        {
            if($srcFile.Name -eq $destFile.Name)
            {
                if($srcFile.LastWriteTime -gt $destFile.LastWriteTime)
                {
                    Write-Verbose "Source file last modified: $($srcFile.LastWriteTime)"
                    Write-Verbose "Destination file last modified: $($destFile.LastWriteTime)"
                    Write-Host "Copying source file: $($srcFile.FullName)"
                    Write-Host "To destination: $($destFile.FullName)"
                    
                    if ($WhatIfPreference -eq $True) {
                        Copy-item -Path $srcFile.FullName -Destination $destFile.FullName -WhatIf
                    } 
                    elseif($ConfirmPreference -ne "High")
                    {
                        Copy-item -Path $srcFile.FullName -Destination $destFile.FullName -Confirm
                    }
                    else
                    {
                        Copy-item -Path $srcFile.FullName -Destination $destFile.FullName -Force
                    }
                }
            }
        }
    }
}