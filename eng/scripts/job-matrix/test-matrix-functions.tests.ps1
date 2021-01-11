Import-Module Pester

BeforeAll {
    . $PSScriptRoot/test-matrix-functions.ps1

    $matrixConfig = @"
{
    "displayNames": {
        "--enableFoo": "withfoo"
    },
    "matrix": {
        "operatingSystem": [
          "windows-2019",
          "ubuntu-18.04",
          "macOS-10.15"
        ],
        "framework": [
          "net461",
          "netcoreapp2.1"
        ],
        "additionalArguments": [
            "",
            "--enableFoo"
        ]
    },
    "include": [
        {
            "operatingSystem": "windows-2019",
            "framework": ["net461", "netcoreapp2.1", "net50"],
            "additionalArguments": "--enableWindowsFoo"
        }
    ],
    "exclude": [
        {
            "operatingSystem": "windows-2019",
            "framework": "net461"
        },
        {
            "operatingSystem": "macOS-10.15",
            "framework": "netcoreapp2.1"
        },
        {
            "operatingSystem": ["macOS-10.15", "ubuntu-18.04"],
            "additionalArguments": "--enableFoo"
        }
    ]
}
"@
    $config = $matrixConfig | ConvertFrom-Json -AsHashtable
}

Describe "Matrix-Lookup" -Tag "lookup" {
    It "Should navigate a 2d matrix: <row> <col>" -TestCases @(
         @{ row = 0; col = 0; expected = 1 },
         @{ row = 0; col = 1; expected = 2 },
         @{ row = 1; col = 0; expected = 3 },
         @{ row = 1; col = 1; expected = 4 }
    ) {
        $dimensions = @(2, 2)
        $matrix = @(
           1, 2, 3, 4
        )
        GetNdMatrixElement @($row, $col) $matrix $dimensions | Should -Be $expected
    }

    It "Should navigate a 3d matrix: <z> <row> <col>" -TestCases @(
         @{ z = 0; row = 0; col = 0; expected = 1 }
         @{ z = 0; row = 0; col = 1; expected = 2 }
         @{ z = 0; row = 1; col = 0; expected = 3 }
         @{ z = 0; row = 1; col = 1; expected = 4 }
         @{ z = 1; row = 0; col = 0; expected = 5 }
         @{ z = 1; row = 0; col = 1; expected = 6 }
         @{ z = 1; row = 1; col = 0; expected = 7 }
         @{ z = 1; row = 1; col = 1; expected = 8 }
    ) {
        $dimensions = @(2, 2, 2)
        $matrix = @(
           1, 2, 3, 4, 5, 6, 7, 8
        )
        GetNdMatrixElement @($z, $row, $col) $matrix $dimensions | Should -Be $expected
    }

    It "Should navigate a 4d matrix: <t> <z> <row> <col>" -TestCases @(
         @{ t = 0; z = 0; row = 0; col = 0; expected = 1 }
         @{ t = 0; z = 0; row = 0; col = 1; expected = 2 }
         @{ t = 0; z = 0; row = 1; col = 0; expected = 3 }
         @{ t = 0; z = 0; row = 1; col = 1; expected = 4 }
         @{ t = 0; z = 1; row = 0; col = 0; expected = 5 }
         @{ t = 0; z = 1; row = 0; col = 1; expected = 6 }
         @{ t = 0; z = 1; row = 1; col = 0; expected = 7 }
         @{ t = 0; z = 1; row = 1; col = 1; expected = 8 }
         @{ t = 1; z = 0; row = 0; col = 0; expected = 9 }
         @{ t = 1; z = 0; row = 0; col = 1; expected = 10 }
         @{ t = 1; z = 0; row = 1; col = 0; expected = 11 }
         @{ t = 1; z = 0; row = 1; col = 1; expected = 12 }
         @{ t = 1; z = 1; row = 0; col = 0; expected = 13 }
         @{ t = 1; z = 1; row = 0; col = 1; expected = 14 }
         @{ t = 1; z = 1; row = 1; col = 0; expected = 15 }
         @{ t = 1; z = 1; row = 1; col = 1; expected = 16 }
    ) {
        $dimensions = @(2, 2, 2, 2)
        $matrix = @(
           1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
        )
        GetNdMatrixElement @($t, $z, $row, $col) $matrix $dimensions | Should -Be $expected
    }

    It "Should navigate a 4d matrix: <t> <z> <row> <col>" -TestCases @(
         @{ t = 0; z = 0; row = 0; col = 0; expected = 1 }
         @{ t = 0; z = 0; row = 0; col = 1; expected = 2 }
         @{ t = 0; z = 0; row = 0; col = 2; expected = 3 }
         @{ t = 0; z = 0; row = 0; col = 3; expected = 4 }

         @{ t = 0; z = 0; row = 1; col = 0; expected = 5 }
         @{ t = 0; z = 0; row = 1; col = 1; expected = 6 }
         @{ t = 0; z = 0; row = 1; col = 2; expected = 7 }
         @{ t = 0; z = 0; row = 1; col = 3; expected = 8 }

         @{ t = 0; z = 1; row = 0; col = 0; expected = 9 }
         @{ t = 0; z = 1; row = 0; col = 1; expected = 10 }
         @{ t = 0; z = 1; row = 0; col = 2; expected = 11 }
         @{ t = 0; z = 1; row = 0; col = 3; expected = 12 }

         @{ t = 0; z = 1; row = 1; col = 0; expected = 13 }
         @{ t = 0; z = 1; row = 1; col = 1; expected = 14 }
         @{ t = 0; z = 1; row = 1; col = 2; expected = 15 }
         @{ t = 0; z = 1; row = 1; col = 3; expected = 16 }
    ) {
        $dimensions = @(1, 2, 2, 4)
        $matrix = @(
           1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
        )
        GetNdMatrixElement @($t, $z, $row, $col) $matrix $dimensions | Should -Be $expected
    }

    # Skipping since by default wrapping behavior on indexing is disabled.
    # Keeping here in case we want to enable it.
    It -Skip "Should handle index wrapping: <row> <col>" -TestCases @(
         @{ row = 2; col = 2; expected = 1 }
         @{ row = 2; col = 3; expected = 2 }
         @{ row = 4; col = 4; expected = 1 }
         @{ row = 4; col = 5; expected = 2 }
    ) {
        $dimensions = @(2, 2)
        $matrix = @(
           1, 2, 3, 4
        )
        GetNdMatrixElement @($row, $col) $matrix $dimensions | Should -Be $expected
    }
}

Describe "Matrix-Reverse-Lookup" -Tag "lookup" {
    It "Should lookup a 2d matrix index: <index>" -TestCases @(
         @{ index = 0; expected = @(0,0) }
         @{ index = 1; expected = @(0,1) }
         @{ index = 2; expected = @(1,0) }
         @{ index = 3; expected = @(1,1) }
    ) {
        $dimensions = @(2, 2)
        $matrix = @(1, 2, 3, 4)
        GetNdMatrixElement $expected $matrix $dimensions | Should -Be $matrix[$index]
        GetNdMatrixIndex $index $dimensions | Should -Be $expected
    }

    It "Should lookup a 3d matrix index: <index>" -TestCases @(
         @{ index = 0; expected = @(0,0,0) }
         @{ index = 1; expected = @(0,0,1) }
         @{ index = 2; expected = @(0,1,0) }
         @{ index = 3; expected = @(0,1,1) }

         @{ index = 4; expected = @(1,0,0) }
         @{ index = 5; expected = @(1,0,1) }
         @{ index = 6; expected = @(1,1,0) }
         @{ index = 7; expected = @(1,1,1) }
    ) {
        $dimensions = @(2, 2, 2)
        $matrix = @(0, 1, 2, 3, 4, 5, 6, 7)
        GetNdMatrixElement $expected $matrix $dimensions | Should -Be $matrix[$index]
        GetNdMatrixIndex $index $dimensions | Should -Be $expected
    }

    It "Should lookup a 3d matrix index: <index>" -TestCases @(
         @{ index = 0; expected = @(0,0,0) }
         @{ index = 1; expected = @(0,0,1) }
         @{ index = 2; expected = @(0,0,2) }

         @{ index = 3; expected = @(0,1,0) }
         @{ index = 4; expected = @(0,1,1) }
         @{ index = 5; expected = @(0,1,2) }

         @{ index = 6; expected = @(1,0,0) }
         @{ index = 7; expected = @(1,0,1) }
         @{ index = 8; expected = @(1,0,2) }

         @{ index = 9; expected = @(1,1,0) }
         @{ index = 10; expected = @(1,1,1) }
         @{ index = 11; expected = @(1,1,2) }
    ) {
        $dimensions = @(2, 2, 3)
        $matrix = @(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)
        GetNdMatrixElement $expected $matrix $dimensions | Should -Be $matrix[$index]
        GetNdMatrixIndex $index $dimensions | Should -Be $expected
    }

    It "Should lookup a 3d matrix index: <index>" -TestCases @(
         @{ index = 0; expected = @(0,0,0) }
         @{ index = 1; expected = @(0,0,1) }
         @{ index = 2; expected = @(0,1,0) }
         @{ index = 3; expected = @(0,1,1) }

         @{ index = 4; expected = @(1,0,0) }
         @{ index = 5; expected = @(1,0,1) }
         @{ index = 6; expected = @(1,1,0) }
         @{ index = 7; expected = @(1,1,1) }

         @{ index = 8; expected = @(2,0,0) }
         @{ index = 9; expected = @(2,0,1) }
         @{ index = 10; expected = @(2,1,0) }
         @{ index = 11; expected = @(2,1,1) }
    ) {
        $dimensions = @(3, 2, 2)
        $matrix = @(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)
        GetNdMatrixElement $expected $matrix $dimensions | Should -Be $matrix[$index]
        GetNdMatrixIndex $index $dimensions | Should -Be $expected
    }

    It "Should lookup a 4d matrix index: <index>" -TestCases @(
         @{ index = 0; expected = @(0,0,0,0) }
         @{ index = 1; expected = @(0,0,0,1) }
         @{ index = 2; expected = @(0,0,0,2) }
         @{ index = 3; expected = @(0,0,0,3) }
                      
         @{ index = 4; expected = @(0,0,1,0) }
         @{ index = 5; expected = @(0,0,1,1) }
         @{ index = 6; expected = @(0,0,1,2) }
         @{ index = 7; expected = @(0,0,1,3) }
                      
         @{ index = 8; expected = @(0,1,0,0) }
         @{ index = 9; expected = @(0,1,0,1) }
         @{ index = 10; expected = @(0,1,0,2) }
         @{ index = 11; expected = @(0,1,0,3) }
                      
         @{ index = 12; expected = @(0,1,1,0) }
         @{ index = 13; expected = @(0,1,1,1) }
         @{ index = 14; expected = @(0,1,1,2) }
         @{ index = 15; expected = @(0,1,1,3) }
    ) {
        $dimensions = @(1, 2, 2, 4)
        $matrix = @(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)
        GetNdMatrixElement $expected $matrix $dimensions | Should -Be $matrix[$index]
        GetNdMatrixIndex $index $dimensions | Should -Be $expected
    }
}

Describe 'Matrix-Set' -Tag "set" {
    It "Should set a matrix element" -TestCases @(
        @{ value = "set"; index = @(0,0,0,0); arrayIndex = 0 }
        @{ value = "ones"; index = @(0,1,1,1); arrayIndex = 13 }
    ) {
        $dimensions = @(1, 2, 2, 4)
        $matrix = @(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)

        SetNdMatrixElement $value $index $matrix $dimensions
        $matrix[$arrayIndex] | Should -Be $value
    }
}

Describe "Platform Matrix Generation" -Tag "generate" {
    BeforeEach {
        $matrixConfig = @"
{
    "displayNames": {
        "--enableFoo": "withfoo"
    },
    "matrix": {
        "operatingSystem": [
          "windows-2019",
          "ubuntu-18.04",
          "macOS-10.15"
        ],
        "framework": [
          "net461",
          "netcoreapp2.1"
        ],
        "additionalArguments": [
            "",
            "--enableFoo"
        ]
    }
}
"@
        $config = $matrixConfig | ConvertFrom-Json -AsHashtable
    }

    It "Should get matrix dimensions from Nd parameters" {
        GetMatrixDimensions $config.matrix | Should -Be 3, 2, 2
    }

    It "Should use name overrides from displayNames" {
        $matrix, $dimensions = GenerateFullMatrix $config.matrix $config.displayNames

        $element = GetNdMatrixElement @(0, 0, 0) $matrix $dimensions
        $element.name | Should -Be "macOS1015_net461"

        $element = GetNdMatrixElement @(1, 1, 1) $matrix $dimensions
        $element.name | Should -Be "ubuntu1804_withFoo_netcoreapp21"

        $element = GetNdMatrixElement @(2, 1, 1) $matrix $dimensions
        $element.name | Should -Be "windows2019_withFoo_netcoreapp21"
    }

    It "Should enforce valid display name format" {
        $config.displayNames["net461"] = '_123.Some.456.Invalid_format-name$(foo)'
        $config.displayNames["netcoreapp2.1"] = (New-Object string[] 150) -join "a"
        $matrix, $dimensions = GenerateFullMatrix $config.matrix $config.displayNames

        $element = GetNdMatrixElement @(0, 0, 0) $matrix $dimensions
        $element.name | Should -Be "macOS1015_some456invalid_formatnamefoo"

        $element = GetNdMatrixElement @(1, 1, 1) $matrix $dimensions
        $element.name.Length | Should -Be 100
        $element.name | Should -BeLike "ubuntu1804_withFoo_aaaaaaaaaaaaaaaaa*"
    }


    It "Should initialize an N-dimensional matrix from all parameter permutations" {
        $matrix, $dimensions = GenerateFullMatrix $config.matrix $config.displayNames
        $matrix.Count | Should -Be 12

        $element = $matrix[0].parameters
        $element.operatingSystem | Should -Be "macOS-10.15"
        $element.framework | Should -Be "net461"
        $element.additionalArguments | Should -Be ""

        $element = GetNdMatrixElement @(1, 1, 1) $matrix $dimensions
        $element.parameters.operatingSystem | Should -Be "ubuntu-18.04"
        $element.parameters.framework | Should -Be "netcoreapp2.1"
        $element.parameters.additionalArguments | Should -Be "--enableFoo"

        $element = GetNdMatrixElement @(2, 1, 1) $matrix $dimensions
        $element.parameters.operatingSystem | Should -Be "windows-2019"
        $element.parameters.framework | Should -Be "netcoreapp2.1"
        $element.parameters.additionalArguments | Should -Be "--enableFoo"
    }

    It "Should initialize a sparse matrix of X length from an N-dimensional matrix" -TestCases @(
        @{ size = 3; i = 0; name = "macOS1015_net461"; operatingSystem = "macOS-10.15"; framework = "net461"; additionalArguments = ""; }
        @{ size = 5; i = 0; name = "macOS1015_net461"; operatingSystem = "macOS-10.15"; framework = "net461"; additionalArguments = ""; }
        @{ size = 4; i = 1; name = "ubuntu1804_withFoo_netcoreapp21"; operatingSystem = "ubuntu-18.04"; framework = "netcoreapp2.1"; additionalArguments = "--enableFoo"; }
        @{ size = 5; i = 2; name = "windows2019_net461"; operatingSystem = "windows-2019"; framework = "net461"; additionalArguments = ""; }
        @{ size = 5; i = 4; name = "ubuntu1804_net461"; operatingSystem = "ubuntu-18.04"; framework = "net461"; additionalArguments = ""; }
    ) {
        $sparseMatrix = GenerateSparseMatrix $config.matrix $config.displayNames $size
        $sparseMatrix.Count | Should -Be $size

        $sparseMatrix[$i].name | Should -Be $name
        $element = $sparseMatrix[$i].parameters
        $element.operatingSystem | Should -Be $operatingSystem
        $element.framework | Should -Be $framework
        $element.additionalArguments | Should -Be $additionalArguments
    }

    It "Should generate a sparse matrix from an N-dimensional matrix config" {
        $sparseMatrix = GenerateMatrix $config "sparse"
        $sparseMatrix.Length | Should -Be 3
    }

    It "Should initialize a full matrix from an N-dimensional matrix config" {
        $matrix = GenerateMatrix $config "all"
        $matrix.Length | Should -Be 12
    }
}

Describe "Matrix sort" -Tag "sort" {
    It "Should sort matrix parameters by length first, then name and values alphabetically" {
        $matrix = @{
            "bbb" = @("b", "a", "c")
            "aaa" = @("d", "b", "c")
            "zzz"  = @("d", "b", "c", "a")
        }
        $expected = @(
            @{ Name = "zzz"; Value = @("a", "b", "c", "d") }
            @{ Name = "aaa"; Value = @("b", "c", "d") }
            @{ Name = "bbb"; Value = @("a", "b", "c") }
        )
        $sorted = SortMatrix $matrix

        for ($i = 0; $i -lt $matrix.Count; $i++) {
            $sorted[$i].Name | Should -Be $expected[$i].Name
            $sorted[$i].Value | Should -Be $expected[$i].Value
        }
    }

    It "Should sort matrix dimensions descending" {
        $matrix = @{
            "bbb" = @("b", "a", "c")
            "aaa" = @("d", "b", "c")
            "zzz"  = @("d", "b", "c", "a")
        }
        GetMatrixDimensions $matrix | Should -Be @(4,3,3)
    }

    It "Should sort matrix output array by display name" {
        $output = GenerateMatrix $config "all"

        for ($i = 0; $i -lt $output.Length-1; $i++) {
            $output[$i].name | Should -BeLessThan $output[$i+1].name
        }
    }
}

Describe "Platform Matrix Post Transformation" -Tag "transform" {
    It "Should match partial matrix elements" -TestCases @(
        @{ source = @{ a = 1; b = 2; }; target = @{ a = 1 }; expected = $true }
        @{ source = @{ a = 1; b = 2; }; target = @{ a = 1; b = 2 }; expected = $true }
        @{ source = @{ a = 1; b = 2; }; target = @{ a = 1; b = 2; c = 3 }; expected = $false }
        @{ source = @{ a = 1; b = 2; }; target = @{ }; expected = $false }
        @{ source = @{ }; target = @{ a = 1; b = 2; }; expected = $false }
    ) {
        MatrixElementMatch $source $target | Should -Be $expected
    }

    It "Should convert singular elements" {
        $matrix = ConvertToMatrixArrayFormat @{ a = 1; b = 2 }
        $matrix.a.Length | Should -Be 1
        $matrix.b.Length | Should -Be 1

        $matrix = ConvertToMatrixArrayFormat @{ a = 1; b = @(1, 2) }
        $matrix.a.Length | Should -Be 1
        $matrix.b.Length | Should -Be 2

        $matrix = ConvertToMatrixArrayFormat @{ a = @(1, 2); b = @() }
        $matrix.a.Length | Should -Be 2
        $matrix.b.Length | Should -Be 0
    }

    It "Should remove matrix elements based on exclude filters" {
        $matrix, $dimensions = GenerateFullMatrix $config.matrix $config.displayNames
        $withExclusion = ProcessExcludes $matrix $config.exclude
        $withExclusion.Length | Should -Be 5

        $dimensions = GetMatrixDimensions $config.matrix
        $size = $dimensions[0]
        $matrix, $dimensions = GenerateSparseMatrix $config.matrix $config.displayNames $size
        [array]$withExclusion = ProcessExcludes $matrix $config.exclude
        $withExclusion.Length | Should -Be 1
    }

    It "Should add matrix elements based on include elements" {
        $matrix, $dimensions = GenerateFullMatrix $config.matrix $config.displayNames
        $withInclusion = ProcessIncludes $matrix $config.include $config.displayNames
        $withInclusion.Length | Should -Be 15
    }

    It "Should include and exclude values with a matrix" {
        [Array]$matrix = GenerateMatrix $config "all"
        $matrix.Length | Should -Be 8

        $matrix[0].name | Should -Be "macOS1015_net461"
        $matrix[0].parameters.operatingSystem | Should -Be "macOS-10.15"
        $matrix[0].parameters.framework | Should -Be "net461"
        $matrix[0].parameters.additionalArguments | Should -Be ""

        # Includes should get sorted along with base matrix
        # The naming segment hierarchy is different because the includes
        # get sorted differently, since parameter lengths are different
        # (e.g. operatingSystem.Length = 1 vs. 3)

        $matrix[1].name | Should -Be "net461_enableWindowsFoo_windows2019"
        $matrix[1].parameters.operatingSystem | Should -Be "windows-2019"
        $matrix[1].parameters.framework | Should -Be "net461"
        $matrix[1].parameters.additionalArguments | Should -Be "--enableWindowsFoo"

        $matrix[2].name | Should -Be "net50_enableWindowsFoo_windows2019"
        $matrix[2].parameters.framework | Should -Be "net50"
        $matrix[2].parameters.operatingSystem | Should -Be "windows-2019"
        $matrix[2].parameters.additionalArguments | Should -Be "--enableWindowsFoo"

        $matrix[5].name | Should -Be "ubuntu1804_netcoreapp21"
        $matrix[5].parameters.framework | Should -Be "netcoreapp2.1"
        $matrix[5].parameters.operatingSystem | Should -Be "ubuntu-18.04"
        $matrix[5].parameters.additionalArguments | Should -Be ""

        $matrix[7].name | Should -Be "windows2019_withFoo_netcoreapp21"
        $matrix[7].parameters.framework | Should -Be "netcoreapp2.1"
        $matrix[7].parameters.operatingSystem | Should -Be "windows-2019"
        $matrix[7].parameters.additionalArguments | Should -Be "--enableFoo"
    }
}
