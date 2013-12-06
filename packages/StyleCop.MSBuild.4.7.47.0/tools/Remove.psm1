# Copyright (c) Adam Ralph. All rights reserved.

function Remove-Changes
{
    param(
        [parameter(Position = 0, Mandatory = $true)]
        [System.Xml.XmlDocument]$doc,
        
        [parameter(Position = 1, Mandatory = $true)]
        [string]$namespace
    )

    # remove from initial targets (was added in beta releases)
    $initialTargets = $doc.Project.GetAttribute('InitialTargets').Split(";", [System.StringSplitOptions]::RemoveEmptyEntries) | select -uniq | where {$_ -ne 'StyleCopMSBuildCheckTargetsFile'}
    if ($initialTargets)
    {
        $doc.Project.SetAttribute('InitialTargets', [string]::Join(";", $initialTargets))
    }
    else
    {
        $doc.Project.RemoveAttribute('InitialTargets')
    }

    # remove properties (targets were added to BuildDependsOn in beta releases)
    $properties = Select-Xml "//msb:Project/msb:PropertyGroup/msb:PrepareForBuildDependsOn[contains(.,'StyleCopMSBuild')] | //msb:Project/msb:PropertyGroup/msb:BuildDependsOn[contains(.,'StyleCopMSBuild')] | //msb:Project/msb:PropertyGroup/msb:StyleCopMSBuildMessageMissing | //msb:Project/msb:PropertyGroup/msb:StyleCopMSBuildMessagePresent | //msb:Project/msb:PropertyGroup/msb:StyleCopMSBuildMessageRestore | //msb:Project/msb:PropertyGroup/msb:StyleCopMSBuildMessageRestored | //msb:Project/msb:PropertyGroup/msb:StyleCopMSBuildTargetsFile" $doc -Namespace @{msb = $namespace}
    if ($properties)
    {
        foreach ($property in $properties)
        {
            $propertyGroup = $property.Node.ParentNode
            $propertyGroup.RemoveChild($property.Node)
            if (!$propertyGroup.HasChildNodes)
            {
                $propertyGroup.ParentNode.RemoveChild($propertyGroup)
            }
        }
    }
    
    # remove targets
    $targets = Select-Xml "//msb:Project/msb:Target[contains(@Name,'StyleCopMSBuild')]" $doc -Namespace @{msb = $namespace}
    if ($targets)
    {
        foreach ($target in $targets)
        {
            $target.Node.ParentNode.RemoveChild($target.Node)
        }
    }

    # remove imports
    $imports = Select-Xml "//msb:Project/msb:Import[contains(@Project,'\StyleCop.MSBuild.')] | //msb:Project/msb:Import[contains(@Project,'StyleCopMSBuild')]" $doc -Namespace @{msb = $namespace}
    if ($imports)
    {
        foreach ($import in $imports)
        {
            $import.Node.ParentNode.RemoveChild($import.Node)
        }
    }
}