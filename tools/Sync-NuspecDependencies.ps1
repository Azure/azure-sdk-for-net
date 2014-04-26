[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0, ValueFromPipeline=$true)]
[string]$BasePath,

[Parameter(Mandatory=$False)]
[string]$NuSpecPath,

[Parameter(Mandatory=$False)]
[string]$PackageConfigPath
)

$ErrorActionPreference = "Stop"

# Function to set parameters
function SetParameter($parameter, $defaultValue)
{
	if ($parameter -eq '' -or $parameter -eq $null) 
	{
		$parameter = $defaultValue
	}
	return $parameter
}

$BasePath = SetParameter $BasePath "."

# Check files exist
if(!(Test-Path -Path $BasePath\*.nuspec) -or !(Test-Path -Path $BasePath\packages.config)) { 
	echo "Packages.config or *.nuspec files were not found. Aborting the script." 
	break
}

$NuSpecPath = SetParameter $NuSpecPath (Get-Item $BasePath\*.nuspec).FullName
$PackageConfigPath = SetParameter $PackageConfigPath "$BasePath\packages.config"

# Check files exist
if(!(Test-Path -Path $NuSpecPath )) { 
	echo "$NuSpecPath file does not exist. Aborting the script." 
	break
}
if(!(Test-Path -Path $PackageConfigPath )) { 
	echo "$PackageConfigPath file does not exist. Aborting the script." 
	break
}

[xml]$nuspec = New-Object System.Xml.XmlDataDocument
#$nuspec.psbase.PreserveWhitespace = $true
$nuspec.Load($NuSpecPath)
[xml]$pkgconfig = Get-Content $PackageConfigPath

ForEach ($dependency in $nuspec.package.metadata.dependencies.dependency) {
	$currentVersion = $dependency.version
	$realVersion = ($pkgconfig.packages.package | where {$_.id -eq $dependency.id}).version
	$newVersion = $currentVersion -replace "([\d\.]{1,7})(,[\d\.]{1,7})?","$($realVersion)`$2"
	echo "Updating $((Get-Location | Get-Item).Name)..."
	echo "Current nuspec version $currentVersion"
	echo "Version in packages.config $realVersion"
	echo "New nuspec version $newVersion"
	$dependency.version = $newVersion
}

$Utf8Encoding = New-Object System.Text.UTF8Encoding($False)
$stringWriter = New-Object System.IO.StringWriter
$xmlWriter = New-Object System.Xml.XmlTextWriter($stringWriter) 
$xmlWriter.Formatting = [System.Xml.Formatting]::Indented 
$nuspec.WriteContentTo($xmlWriter) 
[System.IO.File]::WriteAllLines($NuSpecPath, $stringWriter.ToString(), $Utf8Encoding)
