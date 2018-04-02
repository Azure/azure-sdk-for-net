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

.PARAMETER Source
    Full path to directory where session records are (usually the bin directory of recorded test)

.PARAMETER Destination
    Location where to copy the files
#>

Param(
    [Parameter(Mandatory = $true)]
    [string] $Source,
    [Parameter(Mandatory = $true)]
    [string] $Destination
)

$srcFiles = (Get-ChildItem -Path $Source -Recurse) | Where-Object {$_ -is [System.IO.FileInfo]}
$destFiles = (Get-ChildItem -Path $Destination -Recurse) | Where-Object {$_ -is [System.IO.FileInfo]}

foreach($srcFile in $srcFiles)
{
    foreach($destFile in $destFiles)
    {
        if($srcFile.Name -eq $destFile.Name)
        {
            if($srcFile.LastWriteTime -lt $destFile.LastWriteTime)
            {
                Write-Verbose "Source file last modified: $($srcFile.LastWriteTime)"
                Write-Verbose "Destination file last modified: $($destFile.LastWriteTime)"
                Write-Host "Copying source file: $($srcFile.FullName)"
                Write-Host "To destination: $($destFile.FullName)"
                Copy-item -Path $srcFile.FullName -Destination $destFile.FullName -Force
            }
        }
    }
}