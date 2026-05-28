<#
```
Invoke-Pester -Output Detailed $PSScriptRoot\tests\Generate-Dependency-Test-References.Tests.ps1
```
#>

Import-Module Pester

BeforeAll {
    . $PSScriptRoot/../generate-dependency-functions.ps1
    function Backup-File($targetPath, $backupFolder) {
        $fileName = (Split-Path $targetPath -leaf)
        $backupFile = "$backupFolder/temp-$fileName"
        $null = New-Item $backupFile -ItemType "file" -Force
        $null = Copy-Item $targetPath -Destination $backupFile
    }
    function Reset-File($targetPath, $backupFolder) {
        $fileName = (Split-Path $targetPath -leaf)
        $null = Copy-Item "$backupFolder/temp-$fileName" -Destination $targetPath
    }
}

AfterAll {
    Remove-Item "$PSScriptRoot/testFolder*" -Recurse
}
# Test plan:
# 1. Tests on Split-Project-File-To-Groups. Expect the right num of groups. 
# 2. Tests on Write-Test-Dependency-Group-To-Files. Expect the right xml of the output, right number of output files.
# 3. Tests on Write-Project-Files-To-Matrix. Expect the right property addition on both include and matrix
# 4. Integration test on calling the entire script. Expect on right property on platform-matrix.json
Describe "Split-Project-File-To-Groups" -Tag "UnitTest" {
    # Passed cases
    It "Split project list into groups" -TestCases @(
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; excludeTargetService=$true ; NumOfTestProjectsPerJob = 20; length = 9 }
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; excludeTargetService=$false ; NumOfTestProjectsPerJob = 20; length = 10 }
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; excludeTargetService=$true ; NumOfTestProjectsPerJob = 180; length = 1 }
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; excludeTargetService=$true ; NumOfTestProjectsPerJob = 178; length = 1 }
    ) {
        $projGroups = Split-Project-File-To-Groups -ProjectFile $projectFile -NumberOfTestsPerJob $NumOfTestProjectsPerJob `
            -ExcludeService $excludeTargetService -ServiceDirToExclude "core" 
        $projGroups.Length | Should -Be $length
    }
    # Failed cases
    It "Zero test projects per job" -TestCases @(
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; NumOfTestProjectsPerJob = 0}
        @{ projectFile = "$PSScriptRoot/inputs/empty_projects.txt"}
    ) {
        {Split-Project-File-To-Groups -ProjectFile $projectFile -NumberOfTestsPerJob $NumOfTestProjectsPerJob `
            -ExcludeService $true -ServiceDirToExclude "core"} | Should -Throw -ExceptionType ([System.Management.Automation.RuntimeException])
    }
}

Describe "Write-Test-Dependency-Group-To-Files" -Tag "UnitTest" {
    # passed cases
    It "Split project group array to prop xml files " -TestCases @(
        @{ projGroupArray = @(@("1", "2"), @("3", "4")); length = 2; expectOutput = @("$PSScriptRoot/expectOutputs/1-1.xml", "$PSScriptRoot/expectOutputs/1-2.xml")}
        @{ projGroupArray = ,@("1", "2"); length = 1; expectOutput = @("$PSScriptRoot/expectOutputs/2-1.xml")}
    ) {
        $outputFiles = Write-Test-Dependency-Group-To-Files -ProjectGroups $projGroupArray -MatrixOutputFolder "$PSScriptRoot/testFolder" 
        $outputFiles.Length | Should -Be $length
        for ($i = 0; $i -lt $length; $i++) {
            Get-Content "$PSScriptRoot\testFolder\$($outputFiles[$i])" | Should -Be (Get-Content $expectOutput[$i])
        }
    }
    # Failed cases
    It "Empty project array" -TestCases @(
        @{ projGroupArray = ,@(); }
        @{ projGroupArray = @(); }
    ) {
        { Write-Test-Dependency-Group-To-Files -ProjectGroups $projGroupArray -MatrixOutputFolder "$PSScriptRoot/testFolder" }
            | Should -Throw -ExceptionType ([System.Management.Automation.RuntimeException])
    }
}

Describe "Write-Project-Files-To-Matrix" -Tag "UnitTest" {
    # Passed cases
    It "Write project files into matrix property" -TestCases @(
        @{ TestFolderName = "$PSScriptRoot/testFolder1"; ProjectFiles = "1.txt", "2.txt"; MatrixJsonPath = "$PSScriptRoot/inputs/platform-matrix1.json"; expectOutput="$PSScriptRoot/expectOutputs/expect-matrix1.json" }
        @{ TestFolderName = "$PSScriptRoot/testFolder2"; ProjectFiles = "1.txt", "2.txt", "3.txt"; MatrixJsonPath = "$PSScriptRoot/inputs/platform-matrix1.json"; expectOutput="$PSScriptRoot/expectOutputs/expect-matrix2.json" }
        @{ TestFolderName = "$PSScriptRoot/testFolder3"; ProjectFiles = "1.txt", "2.txt", "3.txt"; MatrixJsonPath = "$PSScriptRoot/inputs/platform-matrix2.json"; expectOutput="$PSScriptRoot/expectOutputs/expect-matrix3.json" }
    ) {
        Backup-File -targetPath $MatrixJsonPath -backupFolder $TestFolderName
        try {
            Write-Project-Files-To-Matrix -ProjectFiles $ProjectFiles -MatrixJsonPath $MatrixJsonPath -MatrixOutputFolder $TestFolderName -ProjectFileConfigName "OverrideFiles"
            Get-Content $MatrixJsonPath | Should -Be (Get-Content $expectOutput)
        }
        finally {
            Reset-File -targetPath $MatrixJsonPath -backupFolder $TestFolderName
        }
    }
}

Describe "Generate-Dependency-Test-References" -Tag "IntegrationTest" {
    # Passed cases
    It "Populate the project file properties into matrix json" -TestCases @(
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; TestFolderName = "$PSScriptRoot/testFolder4"; MatrixInputJsonFile = "$PSScriptRoot/inputs/sync-platform-matrix.json"; NumOfTestProjectsPerJob = 20; ExpectMatrixPropertyLength = 9}
        @{ projectFile = "$PSScriptRoot/inputs/projects.txt"; TestFolderName = "$PSScriptRoot/testFolder5"; MatrixInputJsonFile = "$PSScriptRoot/inputs/sync-platform-matrix.json"; NumOfTestProjectsPerJob = 89; ExpectMatrixPropertyLength = 2}
    ) {
        Backup-File -targetPath $MatrixInputJsonFile -backupFolder $TestFolderName
        & "$PSScriptRoot/../Generate-Dependency-Test-References.ps1" -ProjectListFilePath $projectFile -NumOfTestProjectsPerJob $NumOfTestProjectsPerJob `
            -ExcludeTargetTestProjects $true -ServiceDirectoryToExclude "core" -ProjectFilesOutputFolder $TestFolderName `
            -MatrixConfigsFile $MatrixInputJsonFile -ProjectFileConfigName "ProjectListOverrideFile"
        $outputFileJson = Get-Content "$TestFolderName/sync-platform-matrix.json" | ConvertFrom-Json
        ($outputFileJson.matrix.OverrideFiles.PSObject.Properties | Measure-Object).Count | Should -Be $ExpectMatrixPropertyLength
        ($outputFileJson.include.OverrideFiles.PSObject.Properties | Measure-Object).Count | Should -Be 1
        Reset-File -targetPath $MatrixInputJsonFile -backupFolder $TestFolderName
    }
    # Failed cases
    It "Validate on invalid parameters" -TestCases @(
        @{ projectFile = "$PSScriptRoot/projects.txt"; MatrixInputJsonFile = "$PSScriptRoot/inputs/sync-platform-matrix.json"; projectFileConfigName = ""}
        @{ projectFile = ""; MatrixInputJsonFile = "$PSScriptRoot/inputs/sync-platform-matrix.json"; projectFileConfigName = "test"}
        @{ projectFile = "$PSScriptRoot/projects.txt"; MatrixInputJsonFile = ""; projectFileConfigName = "test"}
    ) {
        { & "$PSScriptRoot/../Generate-Dependency-Test-References.ps1" -ProjectListFilePath $projectFile -NumOfTestProjectsPerJob 20 `
            -ExcludeTargetTestProjects $true -ServiceDirectoryToExclude "core" -ProjectFilesOutputFolder "$PSScriptRoot/testFolder4" `
            -MatrixConfigsFile $MatrixInputJsonFile -ProjectFileConfigName $projectFileConfigName }
                | Should -Throw -ExceptionType ([System.Management.Automation.RuntimeException])
    }
}