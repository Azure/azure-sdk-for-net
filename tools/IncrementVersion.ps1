[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder,
[Parameter(ParameterSetName="Major", Mandatory=$True)]
[Switch]$Major,
[Parameter(ParameterSetName="Minor", Mandatory=$True)]
[Switch]$Minor,
[Parameter(ParameterSetName="Patch", Mandatory=$True)]
[Switch]$Patch
)

$exclusions = @("src", "Common", "Common.Authorization", "Common.NetFramework", "Configuration", "HDInsight")

# Function to update nuspec file
function IncrementVersion([string]$FolderPath)
{
    foreach ($exclusion in $exclusions)
    {
        if ($FolderPath.EndsWith("\" + $exclusion))
        {
            Write-Output "Path $FolderPath is excluded, skip"
            return
        }
    }

    if ($(Get-Item $FolderPath\*.nuget.proj).Count -eq 0)
    {
        Write-Output "Path $FolderPath does not have nuget project, skip"
        return
    }
    
    [xml]$nuproj = Get-Content (Get-Item $FolderPath\*.nuget.proj | select -First 1)
    $packageVersion = $nuproj.Project.ItemGroup.SdkNuGetPackage.PackageVersion
    $version = $packageVersion.Split(".-")
    
    $cMajor = $Major
    $cMinor = $Minor
    $cPatch = $Patch
    
    if ($packageVersion.Contains("-") -and $cPatch -eq $false)
    {
        $cPatch = $cMinor
        $cMinor = $cMajor
        $cMajor = $false
    }
    
    if ($cMajor)
    {
        $version[0] = 1 + $version[0]
        $version[1] = "0"
        $version[2] = "0"
    }
    
    if ($cMinor)
    {
        $version[1] = 1 + $version[1]
        $version[2] = "0"
    }
    
    if ($cPatch)
    {
        $version[2] = 1 + $version[2]
    }
    
    $version = [String]::Join(".", $version)
    if ($packageVersion.Contains("-"))
    {
        $place = $version.LastIndexOf(".")
        $version = $version.Remove($place, 1).Insert($place, "-")
    }
    
    Write-Output "Updating version of $FolderPath from $packageVersion to $version"
    
    $nuproj.Project.ItemGroup.SdkNuGetPackage.PackageVersion = $version
    $Utf8Encoding = New-Object System.Text.UTF8Encoding($False)
    $stringWriter = New-Object System.IO.StringWriter
    $xmlWriter = New-Object System.Xml.XmlTextWriter($stringWriter) 
    Try {
        $xmlWriter.Formatting = [System.Xml.Formatting]::Indented 
        $nuproj.WriteContentTo($xmlWriter) 
        [System.IO.File]::WriteAllLines($(Get-Item $FolderPath\*.nuget.proj).FullName, $stringWriter.ToString(), $Utf8Encoding)
    } Finally {
        $xmlWriter.Dispose()
        $stringWriter.Dispose()
    }
}

if ($Folder -eq '' -or $Folder -eq $null)
{
    $Folder = Resolve-Path "$(Split-Path -parent $MyInvocation.MyCommand.Definition)\..\src"
    Write-Output "Setting the folder path to $Folder"
}

if ($Folder.EndsWith( "src"))
{
    $subFolders = Get-ChildItem -Directory -Path $Folder
    ForEach ($subFolder in $subFolders)
    {
        IncrementVersion($subFolder.FullName)
    }
}
else
{
    IncrementVersion($Folder)
}