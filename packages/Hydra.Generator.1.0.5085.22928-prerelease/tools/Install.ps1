param($installPath, $toolsPath, $package, $project)
    # This is the MSBuild targets file to add
    $targetsFile = [System.IO.Path]::Combine($toolsPath, 'BuildPackages.targets')

    # Need to load MSBuild assembly if it's not loaded yet.
    Add-Type -AssemblyName 'Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'

    # Grab the loaded MSBuild project for the project
    $msbuild = [Microsoft.Build.Evaluation.ProjectCollection]::GlobalProjectCollection.GetLoadedProjects($project.FullName) | Select-Object -First 1

    # Add import of GenerateCode.props. Must be done before the targets file that was automatically loaded
    $targetsImport = $msbuild.Xml.Imports | Where-Object { $_.Project.EndsWith('Hydra.Generator.targets') } | Select-Object -First 1
    $msbuild.Xml.InsertBeforeChild($msbuild.Xml.CreateImportElement("GenerateCode.props"), $targetsImport)

    # Add BeforeBuild target to run the code generation
    $target = $msbuild.Xml.AddTarget("BeforeBuild")
    $target.DependsOnTargets = "RestorePackages;GenerateCodeFromSpecs"

    $project.Save()
