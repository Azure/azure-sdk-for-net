[CmdletBinding()]
param(
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $Input,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $Output,
)


Get-Content $input -Raw