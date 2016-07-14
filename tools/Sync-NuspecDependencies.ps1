[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[string]$Folder,
[Parameter(Mandatory=$False, Position=1)]
[bool]$Sync
)

$ErrorActionPreference = "Stop"

# Function to update nuspec file
function SyncNuspecFile([string]$FolderPath, [bool]$IsSync)
{
    Write-Debug "folder: $FolderPath"
    echo "folder: $FolderPath"
    
    # Try updating Assembly
    if((Test-Path -Path $FolderPath\*.nuget.proj) -and (Test-Path -Path $FolderPath\Properties\AssemblyInfo.cs)) { 
        echo "Updating AssemblyInfo.cs"
        $folderName = (Get-Item $FolderPath).Name
        [xml]$nuproj = $null
        if ($folderName -eq "Common") {
            [xml]$nuproj = Get-Content (Get-Item $FolderPath\*.Common.nuget.proj)
        } else {
            [xml]$nuproj = Get-Content (Get-Item $FolderPath\*.nuget.proj | select -First 1)
        }

        $assemblyContent = Get-Content $FolderPath\Properties\AssemblyInfo.cs
        $currentContent = $assemblyContent | Out-String

        #Getting AssemblyFileVersion
        $packageVersion = $nuproj.Project.ItemGroup.SdkNuGetPackage.PackageVersion
        $packageVersion = ([regex]"[\d\.]+").Match($packageVersion).Value
        $tokens = $packageVersion.split(".")
        if ($tokens.Length -ne 3) {
            Throw "Invalid package version from $nuproj"
        }
        $majorVersion = $tokens[0]
        $assemblyFileVersion = "$packageVersion.0" 

        if ($IsSync)
        {
            Write-Debug "Updating AssemblyFileVersion and AssemblyVersion"
            echo "Updating AssemblyFileVersion and AssemblyVersion"

            #Updating AssemblyFileVersion
            $assemblyContent = $assemblyContent -replace "\[assembly\:\s*AssemblyFileVersion\s*\(\s*`"[\d\.\s]+`"\s*\)\s*\]","[assembly: AssemblyFileVersion(`"$assemblyFileVersion`")]"

            #Updating AssemblyVersion
            $assemblyVersion = "$majorVersion.0.0.0"
            if ($majorVersion -eq "0") {
                $assemblyVersion = "0.9.0.0"
            }
            $assemblyContent = $assemblyContent -replace "\[assembly\:\s*AssemblyVersion\s*\(\s*`"[\d\.\s]+","[assembly: AssemblyVersion(`"$assemblyVersion"
            $newContent = $assemblyContent | Out-String

            if ($currentContent.CompareTo($newContent)  -ne 0) {
                # due to file access confliction with other process such as VS, retry several times
                $retry = 1
                while($true){
                    Try {
                        Set-Content -Path $FolderPath\Properties\AssemblyInfo.cs -Value $assemblyContent
                        break
                    }
                    Catch {
                        $ErrorMessage = $_.Exception.Message
                        if ($retry -eq 20) {
                            Throw $ErrorMessage
                        } else {
                            Write-Debug "Failed to update assemblyinfo.cs due to error: $ErrorMessage. Will retry."
                            $retry++
                            Start-Sleep -s 2
                        }
                    }
                }
            } else {
                echo "No content change. Skipping...."
            }
        } else {
            Write-Debug "Checking if AssemblyFileVersion and AssemblyVersion match between nuget project and AssemblyInfo"
            echo "Checking if AssemblyFileVersion and AssemblyVersion match between nuget project and AssemblyInfo"

            #Checking AssemblyFileVersion
            $assemblyFileVersionLine = $assemblyContent -match "\[assembly\:\s*AssemblyFileVersion\s*\(\s*`"[\d\.\s]+`"\s*\)\s*\]"
            $actualAssemblyFileVersion = $assemblyFileVersionLine.Split("`"")[1]

            if ($assemblyFileVersion -ne $actualAssemblyFileVersion)
            {
                Throw "Assembly File Versions between nuget project and AssemblyInfo don't match"
            }

            #Checking AssemblyVersion
            $assemblyVersionLine = $assemblyContent -match "\[assembly\:\s*AssemblyVersion\s*\(\s*`"[\d\.\s]+"
            $actualAssemblyMajorVersion = $assemblyVersionLine.Split("`"")[1].Split(".")[0];

            if ($majorVersion -ne $actualAssemblyMajorVersion)
            {
                Throw "Assembly Versions between nuget project and AssemblyInfo don't match"
            }
        }

    }

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
        $nuspec.Load($NuSpecPath)
        [xml]$pkgconfig = Get-Content $PackageConfigPath

        ForEach ($dependency in $nuspec.package.metadata.dependencies.dependency) {
            $currentVersion = $dependency.version
            $realVersion = ($pkgconfig.packages.package | where {$_.id -eq $dependency.id}).version
            $newVersion = $currentVersion -replace "((?:\d{1,5}\.?){1,5})(?:-\w+)?(,[\d\.]{1,20})?","$($realVersion)`$2"
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

SyncNuspecFile $Folder $Sync