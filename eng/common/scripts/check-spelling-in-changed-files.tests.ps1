Describe 'Spell checking' {
    BeforeAll {
        $workingDirectory = Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName())

        Write-Host "Create test temp dir: $workingDirectory"
        New-Item -ItemType Directory -Force -Path $workingDirectory | Out-Null

        Push-Location $workingDirectory | Out-Null
        git init

        New-Item -ItemType Directory -Force -Path "./excluded"
        New-Item -ItemType Directory -Force -Path "./included"
        New-Item -ItemType Directory -Force -Path "./.vscode"

        "Placeholder" > "./excluded/placeholder.txt"
        "Placeholder" > "./included/placeholder.txt"

        $configJsonContent = @"
{
    "version": "0.2",
    "language": "en",
    "ignorePaths": [
        ".vscode/cspell.json",
        "excluded/**"
    ]
}
"@
        $configJsonContent > "./.vscode/cspell.json"

        git add -A
        git commit -m "Init"
    }

    AfterAll {
        Pop-Location | Out-Null
        Write-Host "Remove  test temp dir: $workingDirectory"
        Remove-Item -Path $workingDirectory -Recurse -Force | Out-Null
    }

    BeforeEach {
        $initCommit = git rev-parse HEAD
    }

    AfterEach {
        # Empty out the working tree
        git checkout .
        git clean -xdf

        $revCount = git rev-list --count HEAD
        if ($revCount -gt 1) {
            # Reset N-1 changes so there is only the initial commit
            $revisionsToReset = $revCount - 1
            git reset --hard HEAD~$revisionsToReset
        }
    }


    It 'Exits 0 when all files are excluded' {
        # Arrange
        "sepleing errrrrorrrrr" > ./excluded/excluded-file.txt
        git add -A
        git commit -m "One change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -ExitWithError `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $initCommit

        # Assert
        $LASTEXITCODE | Should -Be 0
    }

    It 'Exits 1 when included file has spelling error' {
        # Arrange
        "sepleing errrrrorrrrr" > ./included/included-file.txt
        git add -A
        git commit -m "One change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -ExitWithError `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $initCommit

        # Assert
        $LASTEXITCODE | Should -Be 1
    }

    It 'Exits 0 when included file has no spelling error' {
        # Arrange
        "correct spelling" > ./included/included-file.txt
        git add -A
        git commit -m "One change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -ExitWithError `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $initCommit

        # Assert
        $LASTEXITCODE | Should -Be 0
    }

    It 'Exits 1 when changed file already has spelling error' {
        # Arrange
        "sepleing errrrrorrrrr" > ./included/included-file.txt
        git add -A
        git commit -m "First change"

        "A statement without spelling errors" >> ./included/included-file.txt
        git add -A
        git commit -m "Second change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -ExitWithError `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $initCommit

        # Assert
        $LASTEXITCODE | Should -Be 1
    }

    It 'Exits 0 when unaltered file has spelling error' {
        # Arrange
        "sepleing errrrrorrrrr" > ./included/included-file-1.txt
        git add -A
        git commit -m "One change"

        # Use baseCommit instead of initCommit to simulate a scenario where the
        # file with the spelling error is already checked in.
        $baseCommit = git rev-parse HEAD

        "A statement without spelling errors" > ./included/included-file-2.txt
        git add -A
        git commit -m "Second change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -ExitWithError `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $baseCommit

        # Assert
        $LASTEXITCODE | Should -Be 0
    }

    It 'Exits 0 when spelling errors and no ExitWithError' {
        # Arrange
        "sepleing errrrrorrrrr" > ./included/included-file-1.txt
        git add -A
        git commit -m "One change"

        # Act
        &"$PSScriptRoot/check-spelling-in-changed-files.ps1" `
            -CspellConfigPath "./.vscode/cspell.json" `
            -SpellCheckRoot "./" `
            -SourceCommittish (git rev-parse HEAD) `
            -TargetCommittish $initCommit

        # Assert
        $LASTEXITCODE | Should -Be 0
    }
}