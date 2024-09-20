Describe 'Tool Version' {
    It 'Should have the correct version' {
        # Arrange
        $expectedPackageVersion = '6.31.2'

        # Act
        $actual = &"$PSScriptRoot/../spelling/Invoke-Cspell.ps1" `
            -JobType '--version'

        # Assert
        $actual | Should -Be $expectedPackageVersion
    }
}
