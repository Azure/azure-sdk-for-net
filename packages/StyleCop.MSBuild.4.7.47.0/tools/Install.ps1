# Copyright (c) Adam Ralph. All rights reserved.

param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Remove.psm1")

function Append-TextElement($doc, $namespace, $parent, $elementName, $condition, $text)
{
    $element = $doc.CreateElement($elementName, $namespace)
    $element.SetAttribute('Condition', $condition)
    $element.SetAttribute('Text', $text)
    $parent.AppendChild($element)
}

function Append-Property($doc, $namespace, $propertyGroup, $propertyName, $value)
{
    $property = $doc.CreateElement($propertyName, $namespace)
    $property.AppendChild($doc.CreateTextNode($value))
    $propertyGroup.AppendChild($property)
}

# remove content hook from project and delete file
$hookName = "StyleCop.MSBuild.ContentHook.txt"
$project.ProjectItems.Item($hookName).Remove()
Split-Path $project.FullName -parent | Join-Path -ChildPath $hookName | Remove-Item

# save removal of content hook and any other unsaved changes to project before we start messing about with project file
$project.Save()

# load project XML
$doc = New-Object System.Xml.XmlDocument
$doc.Load($project.FullName)
$namespace = 'http://schemas.microsoft.com/developer/msbuild/2003'

# remove previous changes - executed here for safety, in case for some reason Uninstall.ps1 hasn't been executed
Remove-Changes $doc $namespace

# add targets file property
$absolutePath = Join-Path $toolsPath "StyleCop.targets"
$absoluteUri = New-Object -typename System.Uri -argumentlist $absolutePath
$projectUri = New-Object -typename System.Uri -argumentlist $project.FullName
$relativeUri = $projectUri.MakeRelativeUri($absoluteUri)
$relativePath = [System.URI]::UnescapeDataString($relativeUri.ToString()).Replace([System.IO.Path]::AltDirectorySeparatorChar, [System.IO.Path]::DirectorySeparatorChar)
$propertyGroup = $doc.CreateElement('PropertyGroup', $namespace)
Append-Property $doc $namespace $propertyGroup 'StyleCopMSBuildTargetsFile' $relativePath
$doc.Project.AppendChild($propertyGroup)

# add import
$import = $doc.CreateElement('Import', $namespace)
$import.SetAttribute('Condition', "Exists('`$(StyleCopMSBuildTargetsFile)')")
$import.SetAttribute('Project', '$(StyleCopMSBuildTargetsFile)')
$doc.Project.AppendChild($import)

# add message properties
$propertyGroup = $doc.CreateElement('PropertyGroup', $namespace)
Append-Property $doc $namespace $propertyGroup 'StyleCopMSBuildMessageMissing' "Failed to import StyleCop.MSBuild targets from '`$(StyleCopMSBuildTargetsFile)'. The StyleCop.MSBuild package was either missing or incomplete when the project was loaded. Ensure that the package is present and then restart the build. If you are using an IDE (e.g. Visual Studio), reload the project before restarting the build."
Append-Property $doc $namespace $propertyGroup 'StyleCopMSBuildMessagePresent' "Failed to import StyleCop.MSBuild targets from '`$(StyleCopMSBuildTargetsFile)'. The StyleCop.MSBuild package was either missing or incomplete when the project was loaded (but is now present). To fix this, restart the build. If you are using an IDE (e.g. Visual Studio), reload the project before restarting the build."
Append-Property $doc $namespace $propertyGroup 'StyleCopMSBuildMessageRestore' "Failed to import StyleCop.MSBuild targets from '`$(StyleCopMSBuildTargetsFile)'. The StyleCop.MSBuild package was either missing or incomplete when the project was loaded. To fix this, restore the package and then restart the build. If you are using an IDE (e.g. Visual Studio), you may need to reload the project before restarting the build. Note that regular NuGet package restore (during build) does not work with this package because the package needs to be present before the project is loaded. If this is an automated build (e.g. CI server), you may want to ensure that the build process restores the StyleCop.MSBuild package before the project is built."
Append-Property $doc $namespace $propertyGroup 'StyleCopMSBuildMessageRestored' "Failed to import StyleCop.MSBuild targets from '`$(StyleCopMSBuildTargetsFile)'. The StyleCop.MSBuild package was either missing or incomplete when the project was loaded (but is now present). To fix this, restart the build. If you are using an IDE (e.g. Visual Studio), reload the project before restarting the build. Note that when using regular NuGet package restore (during build) the package will not be available for the initial build because the package needs to be present before the project is loaded. If package restore executes successfully in the initial build then the package will be available for subsequent builds. If this is an automated build (e.g. CI server), you may want to ensure that the build process restores the StyleCop.MSBuild package before the initial build."
$doc.Project.AppendChild($propertyGroup)

# add target
$target = $doc.CreateElement('Target', $namespace)
$target.SetAttribute('Name', 'StyleCopMSBuildTargetsNotFound')
Append-TextElement $doc $namespace $target 'Warning' "!Exists('`$(StyleCopMSBuildTargetsFile)') And `$(RestorePackages)!=true And `$(StyleCopTreatErrorsAsWarnings)!=false" '$(StyleCopMSBuildMessageMissing)'
Append-TextElement $doc $namespace $target 'Warning' "Exists('`$(StyleCopMSBuildTargetsFile)')  And `$(RestorePackages)!=true And `$(StyleCopTreatErrorsAsWarnings)!=false" '$(StyleCopMSBuildMessagePresent)'
Append-TextElement $doc $namespace $target 'Warning' "!Exists('`$(StyleCopMSBuildTargetsFile)') And `$(RestorePackages)==true And `$(StyleCopTreatErrorsAsWarnings)!=false" '$(StyleCopMSBuildMessageRestore)'
Append-TextElement $doc $namespace $target 'Warning' "Exists('`$(StyleCopMSBuildTargetsFile)')  And `$(RestorePackages)==true And `$(StyleCopTreatErrorsAsWarnings)!=false" '$(StyleCopMSBuildMessageRestored)'
Append-TextElement $doc $namespace $target 'Error'   "!Exists('`$(StyleCopMSBuildTargetsFile)') And `$(RestorePackages)!=true And `$(StyleCopTreatErrorsAsWarnings)==false" '$(StyleCopMSBuildMessageMissing)'
Append-TextElement $doc $namespace $target 'Error'   "Exists('`$(StyleCopMSBuildTargetsFile)')  And `$(RestorePackages)!=true And `$(StyleCopTreatErrorsAsWarnings)==false" '$(StyleCopMSBuildMessagePresent)'
Append-TextElement $doc $namespace $target 'Error'   "!Exists('`$(StyleCopMSBuildTargetsFile)') And `$(RestorePackages)==true And `$(StyleCopTreatErrorsAsWarnings)==false" '$(StyleCopMSBuildMessageRestore)'
Append-TextElement $doc $namespace $target 'Error'   "Exists('`$(StyleCopMSBuildTargetsFile)')  And `$(RestorePackages)==true And `$(StyleCopTreatErrorsAsWarnings)==false" '$(StyleCopMSBuildMessageRestored)'
$doc.Project.AppendChild($target)

# inject target into build
$propertyGroup = $doc.CreateElement('PropertyGroup', $namespace)
$dependsOn = $doc.CreateElement('PrepareForBuildDependsOn', $namespace)
$dependsOn.SetAttribute('Condition', "!Exists('`$(StyleCopMSBuildTargetsFile)')")
$dependsOn.AppendChild($doc.CreateTextNode('StyleCopMSBuildTargetsNotFound;$(PrepareForBuildDependsOn)'))
$propertyGroup.AppendChild($dependsOn)
$doc.Project.AppendChild($propertyGroup)

# save changes
$doc.Save($project.FullName)