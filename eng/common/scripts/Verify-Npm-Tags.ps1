param (
  [Parameter(mandatory = $true)]
  $originalDistTags,
  [Parameter(mandatory = $true)]
  $intendedTag,
  [Parameter(mandatory = $true)]
  $intendedTagVersion,
  [Parameter(mandatory = $true)]
  $packageName,
  [Parameter(mandatory = $true)]
  $npmToken
)

$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

Write-Host "Verify npm tag versions for package $packageName"

$parsedOriginalDistTags = $originalDistTags | ConvertFrom-Json

$npmPkgProp = npm view $packageName --json | ConvertFrom-Json
$packageDistTags = $npmPkgProp."dist-tags"

Write-Host "Original dist-tag: $parsedOriginalDistTags"
Write-Host "Current dist-tag: $packageDistTags"
Write-Host "Intend to add tag $intendedTag to version $intendedTagVersion"

if (!$intendedTag) {
  Write-Host "No tags were specified, defaulting to latest tag."
  $intendedTag = "latest"
}

if ($packageDistTags."$intendedTag" -ne $intendedTagVersion) {
  Write-Warning "Tag not correctly set, current $intendedTag tag is version $($packageDistTags."$intendedTag") instead of $intendedTagVersion."
  $correctDistTags = $parsedOriginalDistTags
  $correctDistTags | Add-Member -MemberType NoteProperty -Name $intendedTag -Value $intendedTagVersion -Force

  Write-Host "Setting AuthToken Deployment"
  $regAuth = "//registry.npmjs.org/"
  $env:NPM_TOKEN = $npmToken
  npm config set $regAuth`:_authToken=`$`{NPM_TOKEN`}

  foreach ($tag in $correctDistTags.PSObject.Properties) {
    Write-Host "npm dist-tag add $packageName@$($tag.value) $($tag.Name)"
    npm dist-tag add $packageName@$($tag.value) $($tag.Name)
  }
  $npmPkgProp = npm view $packageName --json | ConvertFrom-Json
  $packageDistTags = $npmPkgProp."dist-tags"
  Write-Host "Corrected dist tags to: $packageDistTags"
}
else {
  Write-Host "Tag verified."
}
