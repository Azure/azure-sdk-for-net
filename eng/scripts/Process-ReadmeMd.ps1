[CmdletBinding()]
param(
  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $InputMd,

  [Parameter()]
  [ValidateNotNullOrEmpty()]
  [string] $OutputMd
)

$text = (Get-Content $InputMd -Raw);

#remove comments
$text = $text -replace '\<\!--.*?-->'

#remove impressions
$text = $text -replace '\!\[Impressions\]\(.*?\)'

$text | Out-File $OutputMd