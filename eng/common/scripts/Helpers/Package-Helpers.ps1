function GetPackageKey($pkg) {
  $pkgKey = $pkg.Package
  $groupId = $null

  if ($pkg.PSObject.Members.Name -contains "GroupId") {
    $groupId = $pkg.GroupId
  }

  if ($groupId) {
    $pkgKey = "${groupId}:${pkgKey}"
  }

  return $pkgKey
}

# Different language needs a different way to index the package. Build a map in convienice to lookup the package.
# E.g. <groupId>:<packageName> is the package key in java.
function GetPackageLookup($packageList) {
  $packageLookup = @{}

  foreach ($pkg in $packageList) {
    $pkgKey = GetPackageKey $pkg

    # We want to prefer updating non-hidden packages but if there is only
    # a hidden entry then we will return that
    if (!$packageLookup.ContainsKey($pkgKey) -or $packageLookup[$pkgKey].Hide -eq "true") {
      $packageLookup[$pkgKey] = $pkg
    }
    else {
      # Warn if there are more then one non-hidden package
      if ($pkg.Hide -ne "true") {
        Write-Host "Found more than one package entry for $($pkg.Package) selecting the first non-hidden one."
      }
    }
  }
  return $packageLookup
}

# For deprecated packages, add "(deprecated)" besides of display name.
function GetDocsTocDisplayName($pkg) {
  $displayName = $pkg.DisplayName
  if ('deprecated' -eq $pkg.Support) {
    LogWarning "The pkg $($pkg.Package) is deprecated. Adding 'deprecated' beside the display name."
    $displayName += " (deprecated)"
  }
  return $displayName
}

<#
.SYNOPSIS
This function is a safe wrapper around `yq` and `ConvertFrom-Yaml` to convert YAML content to a PowerShell HashTable object

.DESCRIPTION
This function wraps `yq` and `ConvertFrom-Yaml` to convert YAML content to a PowerShell HashTable object. The reason this function exists is
because while on a local user's machine, installing a module from the powershell gallery is an easy task, in pipelines we often have failures
to install modules from the gallery. This function will attempt to use the `yq` command if it is available on the machine, and only will install
the yaml module if `yq` is not available. This means that for the majority of runs on CI machines, the yaml module will not be installed.

.PARAMETER Content
The content to convert from YAML to a PowerShell HashTable object. Accepted as named argument or from the pipeline.

.EXAMPLE
CompatibleConvertFrom-Yaml -Content (Get-Content -Raw path/to/file.yml)

.EXAMPLE
Get-Content -Raw path/to/file.yml | CompatibleConvertFrom-Yaml
#>
function CompatibleConvertFrom-Yaml {
  param(
    [Parameter(Mandatory = $true, ValueFromPipeline = $true)]
    [string]$Content
  )

  if (!($Content)) {
    throw "Content to parse is a required input."
  }

  . (Join-Path $PSScriptRoot PSModule-Helpers.ps1)
  InstallAndImport-ModuleIfNotInstalled "powershell-yaml" "0.4.7"

  return ConvertFrom-Yaml $content
}

<#
.SYNOPSIS
Common function that will verify that the YmlFile being loaded exists, load the raw file and
return the results of CompatibleConvertFrom-Yaml or report an exception and return null if
there's a problem loading the yml file. The return is the PowerShell HashTable object.

.DESCRIPTION
Common function that will verify that the YmlFile being loaded exists, load the raw file and
return the results of CompatibleConvertFrom-Yaml or report an exception and return null if
there's a problem loading the yml file. This is just to save anyone needing to load yml from
having to deal with checking the file's existence and ensure that the CompatibleConvertFrom-Yaml
is made within a try/catch. The return is the PowerShell HashTable object from the
CompatibleConvertFrom-Yaml call or $null if there was an issue with the convert.

.PARAMETER YmlFile
The full path of the yml file to load.

.EXAMPLE
LoadFrom-Yaml -YmlFile path/to/file.yml
#>
function LoadFrom-Yaml {
  param(
    [Parameter(Mandatory = $true)]
    [string]$YmlFile
  )
  if (Test-Path -Path $YmlFile) {
    try {
      return Get-Content -Raw -Path $YmlFile | CompatibleConvertFrom-Yaml
    }
    catch {
      Write-Host "LoadFrom-Yaml::Exception while parsing yml file $($YmlFile): $_"
    }
  }
  else {
    Write-Host "LoadFrom-Yaml::YmlFile '$YmlFile' does not exist."
  }
  return $null
}

<#
.SYNOPSIS
Given the Hashtable contents of a Yml file and an array of strings representing the keys
return the value if it exist or null if it doesn't.

.DESCRIPTION
The Yaml file needs to be loaded via CompatibleConvertFrom-Yaml which returns the file as
as hashtable. The Keys are basically the path in the yaml file whose value to return, or
null if it doesn't exist. This function safely traverses the path, outputting an error
if there's an issue or returning the object representing the result if successful. This
function loops through the Keys safely trying to get values, checking each piece of the
path to ensure it exists. Normally one would just do
$Yml["extends"]["parameters"]["artifacts"]
but if something was off it would throw. Doing it this way allows more succinct error
reporting if a piece of the path didn't exist

.PARAMETER YamlContentAsHashtable
The hashtable representing the yaml file contents loaded through LoadFrom-Yaml
or CompatibleConvertFrom-Yaml, which is what LoadFrom-Yaml calls.

.PARAMETER Keys
String array representation of the path in the yaml file whose value we're trying to retrieve.

.EXAMPLE
GetValueSafelyFrom-Yaml -YamlContentAsHashtable $YmlFileContent -Keys @("extends", "parameters", "Artifacts")
#>
function GetValueSafelyFrom-Yaml {
  param(
    [Parameter(Mandatory = $true)]
    $YamlContentAsHashtable,
    [Parameter(Mandatory = $true)]
    [string[]]$Keys
  )
  $current = $YamlContentAsHashtable
  foreach ($key in $Keys) {
    if ($current -is [HashTable] -and ($current.ContainsKey($key) -or $current[$key])) {
      $current = $current[$key]
    }
    else {
      return $null
    }
  }

  return [object]$current
}

function Get-ObjectKey {
  param (
    [Parameter(Mandatory = $true)]
    [object]$Object
  )

  if (-not $Object) {
    return "unset"
  }

  if ($Object -is [hashtable] -or $Object -is [System.Collections.Specialized.OrderedDictionary]) {
    $sortedEntries = $Object.GetEnumerator() | Sort-Object Name
    $hashString = ($sortedEntries | ForEach-Object { "$($_.Key)=$(Get-ObjectKey $_.Value)" }) -join ";"
    return $hashString.GetHashCode()
  }

  elseif ($Object -is [PSCustomObject]) {
    $sortedProperties = $Object.PSObject.Properties | Sort-Object Name
    $propertyString = ($sortedProperties | ForEach-Object { "$($_.Name)=$(Get-ObjectKey $_.Value)" }) -join ";"
    return $propertyString.GetHashCode()
  }

  elseif ($Object -is [array]) {
    $arrayString = ($Object | ForEach-Object { Get-ObjectKey $_ }) -join ";"
    return $arrayString.GetHashCode()
  }

  else {
    $parsedBool = $null
    if ([bool]::TryParse($Object, [ref]$parsedBool)) {
      return $parsedBool.GetHashCode()
    } else {
      return $Object.GetHashCode()
    }
  }
}

function Group-ByObjectKey {
  param (
    [Parameter(Mandatory)]
    [array]$Items,

    [Parameter(Mandatory)]
    [string]$GroupByProperty
  )

  $groupedDictionary = @{}

  foreach ($item in $Items) {
    # if the item is an array, we need to group by each element in the array
    # however if it's an empty array we want to treat it as a single item
    if ($item."$GroupByProperty" -and $item."$GroupByProperty" -is [array]) {
      foreach ($GroupByPropertyValue in $item."$GroupByProperty") {
        $key = Get-ObjectKey $GroupByPropertyValue

        if (-not $groupedDictionary.ContainsKey($key)) {
          $groupedDictionary[$key] = @()
        }

        $groupedDictionary[$key] += $item
      }
    }
    else {
      if ($item."$GroupByProperty") {
        $key = Get-ObjectKey $item."$GroupByProperty"
      }
      else {
        $key = "unset"
      }

      if (-not $groupedDictionary.ContainsKey($key)) {
        $groupedDictionary[$key] = @()
      }

      $groupedDictionary[$key] += $item
    }
  }

  return $groupedDictionary
}

function Split-ArrayIntoBatches {
  param (
    [Parameter(Mandatory = $true)]
    [Object[]]$InputArray,

    [Parameter(Mandatory = $true)]
    [int]$BatchSize
  )

  $batches = @()

  for ($i = 0; $i -lt $InputArray.Count; $i += $BatchSize) {
    $batch = $InputArray[$i..[math]::Min($i + $BatchSize - 1, $InputArray.Count - 1)]

    $batches += , $batch
  }

  return , $batches
}

# Get the full package name based on packageInfo properties
# Returns Group+ArtifactName if Group exists and has a value, otherwise returns Name
# If UseColonSeparator switch is enabled, returns Group:ArtifactName format (colon separator)
function Get-FullPackageName {
    param (
        [Parameter(Mandatory=$true)]
        [PSCustomObject]$PackageInfo,
        [switch]$UseColonSeparator
    )
    
    if ($PackageInfo.PSObject.Members.Name -contains "Group") {
        $groupId = $PackageInfo.Group
        if ($groupId) {
            if ($UseColonSeparator) {
                return "${groupId}:$($PackageInfo.ArtifactName)"
            }
            return "${groupId}+$($PackageInfo.ArtifactName)"
        }
    }
    return $PackageInfo.Name
}
