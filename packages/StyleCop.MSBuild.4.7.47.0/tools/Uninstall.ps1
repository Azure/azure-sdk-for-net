# Copyright (c) Adam Ralph. All rights reserved.

param($installPath, $toolsPath, $package, $project)

Import-Module (Join-Path $toolsPath "Remove.psm1")

# save any unsaved changes before we start messing about with the project file
$project.Save()

# load project XML
$doc = New-Object System.Xml.XmlDocument
$doc.Load($project.FullName)
$namespace = 'http://schemas.microsoft.com/developer/msbuild/2003'

# remove changes
Remove-Changes $doc $namespace

# save changes
$doc.Save($project.FullName)