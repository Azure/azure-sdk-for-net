$TestDependsOnDependency="Azure.Core"
$ArtifactStaging="C:/repo/azure-sdk-for-net/artifact-staging"
$OutputProjectFilePath="$ArtifactStaging/projects.txt"

mkdir -P $ArtifactStaging

dotnet build /t:ProjectDependsOn ./eng/service.proj `
  /p:TestDependsOnDependency="$TestDependsOnDependency" `
  /p:IncludeSrc=false /p:IncludeStress=false /p:IncludeSamples=false  `
  /p:IncludePerf=false /p:RunApiCompat=false `
  /p:InheritDocEnabled=false /p:BuildProjectReferences=false `
  /p:OutputProjectFilePath="$OutputProjectFilePath"

./eng/scripts/splittestdependencies/Generate-Dependency-Test-References.ps1 `
-ProjectListFilePath $OutputProjectFilePath `
-ProjectFilesOutputFolder "$ArtifactStaging" `
-NumOfTestProjectsPerJob 20 `
-MatrixConfigsFile "eng/pipelines/templates/stages/platform-matrix.json" `
-ProjectFileConfigName "ProjectListOverrideFile" `
-ExcludeTargetTestProjects: $true `
-ServiceDirectoryToExclude "core"

# proposal for adjustment

# replace usage of Save-Package-Properties with Save-Package-Properties.yml
# update the default generatePR Matrix to honor the new save-package-properties
# update the dependency.tests.yml to use the new save-package-properties, then resolve the dependency groups from
# there. Currently it generates the project list if TestsOnDependency is set, but we need to move that
# list to the script that is being called


