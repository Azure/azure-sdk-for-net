[CmdletBinding()]
Param(
[Parameter(Mandatory=$False)]
[string]$BasePath,

[Parameter(Mandatory=$False)]
[string]$NuSpecPath,

[Parameter(Mandatory=$False)]
[string]$PackageConfigPath
)

# Function to set parameters
function SetParameter($parameter, $defaultValue)
{
	if ($parameter -eq '' -or $parameter -eq $null) 
	{
		$parameter = $defaultValue
	}
	return $parameter
}

$BasePath = (Get-Location).Path
$NuSpecPath = (Get-Item $BasePath\*.nuspec).FullName
$PackageConfigPath = "$BasePath\packages.config"

# Check files exist
if(!(Test-Path -Path $NuSpecPath )) { throw "$NuSpecPath file does not exist." }
if(!(Test-Path -Path $PackageConfigPath )) { throw "$PackageConfigPath file does not exist." }

[xml]$nuspec = Get-Content $NuSpecPath
[xml]$pkgconfig = Get-Content $PackageConfigPath

ForEach ($dependency in $nuspec.package.metadata.dependencies.dependency) {
	$currentVersion = $dependency.version
	$realVersion = ($pkgconfig.packages.package | where {$_.id -eq $dependency.id}).version
	$newVersion = $currentVersion -replace "([\d\.]{1,7})(,[\d\.]{1,7})?","$($realVersion)`$2"
	echo "Current version " $currentVersion
	echo "Real version" $realVersion
	echo "New version" $newVersion
	$dependency.version = $newVersion
}
[xml]$nuspec.Save($NuSpecPath)