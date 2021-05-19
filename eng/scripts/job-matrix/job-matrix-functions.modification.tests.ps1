Import-Module Pester


BeforeAll {
    . ./job-matrix-functions.ps1

    function CompareMatrices([Array]$matrix, [Array]$expected) {
        $matrix.Length | Should -Be $expected.Length

        for ($i = 0; $i -lt $matrix.Length; $i++) {
            foreach ($entry in $matrix[$i]) {
                $expected[$i].name | Should -Be $entry.name
                foreach ($param in $entry.parameters.GetEnumerator()) {
                    $expected[$i].parameters[$param.Name] | Should -Be $param.Value
                }
            }
        }
    }
}

Describe "Platform Matrix nonSparse" -Tag "nonsparse" {
    BeforeEach {
        $matrixJson = @'
{
    "matrix": {
        "testField1": [ 1, 2 ],
        "testField2": [ 1, 2, 3 ],
        "testField3": [ 1, 2, 3, 4 ],
    }
}
'@
        $config = GetMatrixConfigFromJson $matrixJson
    }

    It "Should process nonSparse parameters" {
        $parameters, $nonSparse = ProcessNonSparseParameters $config.orderedMatrix "testField1","testField3"
        $parameters.Count | Should -Be 1
        $parameters["testField2"] | Should -Be 1,2,3
        $nonSparse.Count | Should -Be 2
        $nonSparse["testField1"] | Should -Be 1,2
        $nonSparse["testField3"] | Should -Be 1,2,3,4

        $parameters, $nonSparse = ProcessNonSparseParameters $config.orderedMatrix "testField3"
        $parameters.Count | Should -Be 2
        $parameters.Contains("testField3") | Should -Be $false
        $nonSparse.Count | Should -Be 1
        $nonSparse["testField3"] | Should -Be 1,2,3,4
    }

    It "Should ignore nonSparse with all selection" {
        $matrix = GenerateMatrix $config "all" -nonSparseParameters "testField3"
        $matrix.Length | Should -Be 24
    }

    It "Should combine sparse matrix with nonSparse parameters" {
        $matrix = GenerateMatrix $config "sparse" -nonSparseParameters "testField3"
        $matrix.Length | Should -Be 12
    }

    It "Should combine with multiple nonSparse fields" {
        $matrixJson = @'
{
    "matrix": {
        "testField1": [ 1, 2 ],
        "testField2": [ 1, 2 ],
        "testField3": [ 31, 32 ],
        "testField4": [ 41, 42 ]
    }
}
'@
        $config = GetMatrixConfigFromJson $matrixJson

        $matrix = GenerateMatrix $config "all" -nonSparseParameters "testField3","testField4"
        $matrix.Length | Should -Be 16

        $matrix = GenerateMatrix $config "sparse" -nonSparseParameters "testField3","testField4"
        $matrix.Length | Should -Be 8
    }
}

Describe "Platform Matrix Import" -Tag "import" {
    It "Should generate a matrix with nonSparseParameters and an imported sparse matrix" {
        $matrixJson = @'
{
    "matrix": {
        "$IMPORT": "./test-import-matrix.json",
        "testField": [ "test1", "test2" ]
    }
}
'@
        $importConfig = GetMatrixConfigFromJson $matrixJson
        $matrix = GenerateMatrix $importConfig "sparse" -nonSparseParameters "testField"

        $matrix.Length | Should -Be 6

        $matrix[0].name | Should -Be test1_foo1_bar1
        $matrix[0].parameters.testField | Should -Be "test1"
        $matrix[0].parameters.Foo | Should -Be "foo1"
        $matrix[2].name | Should -Be test1_importedBaz
        $matrix[2].parameters.testField | Should -Be "test1"
        $matrix[2].parameters.Baz | Should -Be "importedBaz"
        $matrix[4].name | Should -Be test2_foo2_bar2
        $matrix[4].parameters.testField | Should -Be "test2"
        $matrix[4].parameters.Foo | Should -Be "foo2"
    }

    It "Should generate a sparse matrix with an imported a sparse matrix" {
        $matrixJson = @'
{
    "matrix": {
        "$IMPORT": "./test-import-matrix.json",
        "testField1": [ "test11", "test12" ],
        "testField2": [ "test21", "test22" ]
    }
}
'@

        $expectedMatrix = @'
[
  {
    "parameters": { "testField1": "test11", "testField2": "test21", "Foo": "foo1", "Bar": "bar1" },
    "name": "test11_test21_foo1_bar1"
  },
  {
    "parameters": { "testField1": "test11", "testField2": "test21", "Foo": "foo2", "Bar": "bar2" },
    "name": "test11_test21_foo2_bar2"
  },
  {
    "parameters": { "testField1": "test11", "testField2": "test21", "Baz": "importedBaz" },
    "name": "test11_test21_importedBaz"
  },
  {
    "parameters": { "testField1": "test12", "testField2": "test22", "Foo": "foo1", "Bar": "bar1" },
    "name": "test12_test22_foo1_bar1"
  },
  {
    "parameters": { "testField1": "test12", "testField2": "test22", "Foo": "foo2", "Bar": "bar2" },
    "name": "test12_test22_foo2_bar2"
  },
  {
    "parameters": { "testField1": "test12", "testField2": "test22", "Baz": "importedBaz" },
    "name": "test12_test22_importedBaz"
  }
]
'@

        $importConfig = GetMatrixConfigFromJson $matrixJson
        $matrix = GenerateMatrix $importConfig "sparse"
        $expected = $expectedMatrix | ConvertFrom-Json -AsHashtable

        $matrix.Length | Should -Be 6
        CompareMatrices $matrix $expected
    }

    It "Should import a sparse matrix with import, include, and exclude" {
        $matrixJson = @'
{
    "matrix": {
        "$IMPORT": "./test-import-matrix.json",
        "testField": [ "test1", "test2", "test3" ],
    },
    "include": [
      {
        "testImportIncludeName": [ "testInclude1", "testInclude2" ]
      }
    ],
    "exclude": [
      {
        "testField": "test1"
      },
      {
        "testField": "test3",
        "Baz": "importedBaz"
      }
    ]
}
'@

        $expectedMatrix = @'
[
  {
    "parameters": { "testField": "test2", "Foo": "foo1", "Bar": "bar1" },
    "name": "test2_foo1_bar1"
  },
  {
    "parameters": { "testField": "test2", "Foo": "foo2", "Bar": "bar2" },
    "name": "test2_foo2_bar2"
  },
  {
    "parameters": { "testField": "test2", "Baz": "importedBaz" },
    "name": "test2_importedBaz"
  },
  {
    "parameters": { "testField": "test3", "Foo": "foo1", "Bar": "bar1" },
    "name": "test3_foo1_bar1"
  },
  {
    "parameters": { "testField": "test3", "Foo": "foo2", "Bar": "bar2" },
    "name": "test3_foo2_bar2"
  },
  {
    "parameters": { "testImportIncludeName": "testInclude1" },
    "name": "testInclude1"
  },
  {
    "parameters": { "testImportIncludeName": "testInclude2" },
    "name": "testInclude2"
  }
]
'@

        $importConfig = GetMatrixConfigFromJson $matrixJson
        $matrix = GenerateMatrix $importConfig "sparse"
        $expected = $expectedMatrix | ConvertFrom-Json -AsHashtable

        $matrix.Length | Should -Be 7
        CompareMatrices $matrix $expected
    }
}
