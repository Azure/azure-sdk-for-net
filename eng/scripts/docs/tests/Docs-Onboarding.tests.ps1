Import-Module Pester 

BeforeAll { 
    . $PSScriptRoot/../Docs-Onboarding.ps1
}

Describe 'GetPropertyString' { 
    It 'returns <expected> when given (<inputValue>)' -ForEach @(
        @{ inputValue = @{}; expected = '' },
        @{ inputValue = @{ test = 'value' }; expected = 'test=value' },
        @{ inputValue = [ordered]@{ test = 'value'; test2 = 'value2' }; expected = 'test=value;test2=value2' }
    ) {
        $result = GetPropertyString $inputValue
        $result | Should -Be $expected
    }
}

Describe 'Get-DocsCiLine2' { 
    It 'returns <expected> when given <inputValue>' -ForEach @(
        @{ inputValue = @{ Id = 'id'; Name = 'name' }; expected = 'id,name' },
        @{ inputValue = @{ Id = 'id'; Name = 'name'; Version = 'version' }; expected = 'id,name,version' },
        @{ inputValue = @{ Id = 'id'; Name = 'name'; DocsCiConfigProperties = @{ test = 'value' } }; expected = 'id,[test=value]name' },
        @{ inputValue = @{ Id = 'id'; Name = 'name'; DocsCiConfigProperties = @{ test = 'value' }; Version = 'version' }; expected = 'id,[test=value]name,version' }
    ) {
        $result = Get-DocsCiLine2 $inputValue
        $result | Should -Be $expected
    }
}

Describe 'SetDocsCiConfigProperties' { 
    It 'sets isPrerelease=true when moniker is preview' { 
        $package = @{ Id = 'id'; Name = 'name'; Version = 'version' }
        $result = SetDocsCiConfigProperties $package 'preview'

        $result.DocsCiConfigProperties['isPrerelease'] | Should -Be 'true'
    }

    It 'sets custom source when there is DevVersion and packageSourceOverride' { 
        $package = @{ Id = 'id'; Name = 'name'; Version = 'version'; DevVersion = 'DevVersionIsSet' }
        $result = SetDocsCiConfigProperties $package 'preview' 'https://packageSourceOverride/'

        $result.DocsCiConfigProperties['isPrerelease'] | Should -Be 'true'
        $result.DocsCiConfigProperties['customSource'] | Should -Be 'https://packageSourceOverride/'
    }

    It 'combines existing properties with with isPrerelease when moniker is preview' { 
        $package = @{ Id = 'id'; Name = 'name'; Version = 'version'; DocsCiConfigProperties = @{ test = 'value' } }
        $result = SetDocsCiConfigProperties $package 'preview'

        $result.DocsCiConfigProperties['isPrerelease'] | Should -Be 'true'
        $result.DocsCiConfigProperties['test'] | Should -Be 'value'
    }
}

Describe 'GetCiConfigPath' {
    It 'returns <expected> when given <inputValue>' -ForEach @(
        @{ inputValue = 'preview'; expected = './bundlepackages/azure-dotnet-preview.csv' },
        @{ inputValue = 'legacy'; expected = './bundlepackages/azure-dotnet-legacy.csv' },
        @{ inputValue = 'default'; expected = './bundlepackages/azure-dotnet.csv' }
    ) {
        $result = GetCiConfigPath '.' $inputValue
        $result | Should -Be $expected
    }

    It 'returns latest by default' {
        $result = GetCiConfigPath '.' 'some random value'
        $result | Should -Be './bundlepackages/azure-dotnet.csv'
    }
}

Describe 'GetPackageId' { 
    It 'returns <expected> when given <inputValue>' -ForEach @(
        @{ inputValue = 'Name.With.Dot.Separators'; expected = 'namewithdotseparators' },
        @{ inputValue = 'Name.With.Dots-and-dashes'; expected = 'namewithdots-and-dashes' }
    ) {
        $result = GetPackageId $inputValue
        $result | Should -Be $expected
    }
}
