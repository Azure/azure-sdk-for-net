[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $ServiceDirectory
)

&"$PSScriptRoot/Update-Snippets.ps1" $ServiceDirectory
&"$PSScriptRoot/Export-API.ps1" $ServiceDirectory