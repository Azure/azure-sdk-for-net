[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0, ValueFromPipeline=$true)]
[string]$BasePath
)

if ($BasePath -eq '' -or $BasePath -eq $null) { $BasePath = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)\..\src" }

$ErrorActionPreference = "Stop"

# Function to update nuspec file
function SyncNuspecFile([string]$FolderPath)
{
	Write-Debug "folder: $FolderPath"

	# Check files exist
	if(!(Test-Path -Path $FolderPath\*.nuspec) -or !(Test-Path -Path $FolderPath\packages.config)) { 
		echo "Packages.config or *.nuspec files were not found. Skipping..." 
		return
	}
	
	ForEach ($NuSpecFile in Get-Item $FolderPath\*.nuspec) {
		$NuSpecPath = $NuSpecFile.FullName
		$PackageConfigPath = "$FolderPath\packages.config"
	
		# Check files exist
		if(!(Test-Path -Path $NuSpecPath )) { 
			echo "$NuSpecPath file does not exist. Skipping..." 
			return
		}
		if(!(Test-Path -Path $PackageConfigPath )) { 
			echo "$PackageConfigPath file does not exist. Skipping..." 
			return
		}
		
		Write-Debug "nuspec file: $NuSpecPath"
		Write-Debug "package file: $PackageConfigPath"

		[xml]$nuspec = New-Object System.Xml.XmlDataDocument
		#$nuspec.psbase.PreserveWhitespace = $true
		$nuspec.Load($NuSpecPath)
		[xml]$pkgconfig = Get-Content $PackageConfigPath

		ForEach ($dependency in $nuspec.package.metadata.dependencies.dependency) {
			$currentVersion = $dependency.version
			$realVersion = ($pkgconfig.packages.package | where {$_.id -eq $dependency.id}).version
			$newVersion = $currentVersion -replace "([\d\.]{1,7})(,[\d\.]{1,7})?","$($realVersion)`$2"
			if ($realVersion -eq $null -or $realVersion -eq '') {
				echo "Version in packages.config $realVersion"
				echo "Skipping $((Get-Location | Get-Item).Name)..."
			} else {
				echo "Updating $((Get-Location | Get-Item).Name)..."
				echo "Current nuspec version $currentVersion"
				echo "Version in packages.config $realVersion"
				echo "New nuspec version $newVersion"
				$dependency.version = $newVersion
			}
		}

		$Utf8Encoding = New-Object System.Text.UTF8Encoding($False)
		$stringWriter = New-Object System.IO.StringWriter
		$xmlWriter = New-Object System.Xml.XmlTextWriter($stringWriter) 
		Try {
			$xmlWriter.Formatting = [System.Xml.Formatting]::Indented 
			$nuspec.WriteContentTo($xmlWriter) 
			[System.IO.File]::WriteAllLines($NuSpecPath, $stringWriter.ToString(), $Utf8Encoding)
		} Finally {
			$xmlWriter.Dispose()
			$stringWriter.Dispose()
		}
	}
}

$subFolders = Get-ChildItem -Directory -Path $BasePath
ForEach ($subFolder in $subFolders) {
	SyncNuspecFile $subFolder.FullName
}

