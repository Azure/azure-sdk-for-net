Set-StrictMode -Version "4.0"

function CreateDisplayName {
    param([string]$parameter, [hashtable]$displayNames)

    $name = $parameter

    if ($displayNames[$parameter]) {
        $name = $displayNames[$parameter]
    }

    return $name -replace "[\-\._]", ""
}

function GenerateMatrix {
    param([HashTable]$config, [string]$selectFromMatrixType)

    if ($selectFromMatrixType -eq "sparse") {
        [Array]$dimensions = GetMatrixDimensions $config.matrix
        $size = $dimensions[0]
        [Array]$matrix = GenerateSparseMatrix $config.matrix $config.displayNames $size
    } elseif ($selectFromMatrixType -eq "all") {
        [Array]$matrix, $_ = GenerateFullMatrix $config.matrix $config.displayNames
    } else {
        throw "Matrix generator not implemented for selectFromMatrix: $($platform.selectFromMatrix)"
    }

    if ($config["exclude"]) {
        [Array]$matrix = ProcessExcludes $matrix $config.exclude
    }
    if ($config["include"]) {
        [Array]$matrix = ProcessIncludes $matrix $config.include $config.displayNames
    }

    return $matrix | Sort-Object -Property name
}

function ProcessExcludes {
    param([Array]$matrix, [Array]$excludes)

    $deleteKey = "%DELETE%"
    $exclusionMatrix = @()

    foreach ($exclusion in $excludes) {
        $converted = ConvertToMatrixArrayFormat $exclusion
        $full, $_ = GenerateFullMatrix $converted
        $exclusionMatrix += $full
    }

    foreach ($element in $matrix) {
        foreach ($exclusion in $exclusionMatrix) {
            $match = MatrixElementMatch $element.parameters $exclusion.parameters
            if ($match) {
                $element.parameters[$deleteKey] = $true
            }
        }
    }

    return $matrix | Where-Object { !$_.parameters.Contains($deleteKey) }
}

function ProcessIncludes {
    param([Array]$matrix, [Array]$includes, [HashTable]$displayNames)

    foreach ($inclusion in $includes) {
        $converted = ConvertToMatrixArrayFormat $inclusion
        $full, $_ = GenerateFullMatrix $converted $displayNames
        $matrix += $full
    }

    return $matrix
}

function MatrixElementMatch {
    param([HashTable]$source, [HashTable]$target)

    if ($target.Count -eq 0) {
        return $false
    }

    foreach ($key in $target.Keys) {
        if ($source[$key] -ne $target[$key]) {
            return $false
        }
    }

    return $true
}

function ConvertToMatrixArrayFormat {
    param([HashTable]$matrix)

    $converted = @{}

    foreach ($key in $matrix.Keys) {
        if ($matrix[$key] -isnot [Array]) {
            $converted[$key] = ,$matrix[$key]
        } else {
            $converted[$key] = $matrix[$key]
        }
    }

    return $converted
}

function SerializePipelineMatrix {
    param([Array]$matrix)

    $matrix = $matrix | Sort-Object -Property name
    $pipelineMatrix = [ordered]@{}
    foreach ($entry in $matrix) {
        $pipelineMatrix.Add($entry.name, [ordered]@{})
        foreach ($key in $entry.parameters.Keys) {
            $pipelineMatrix[$entry.name].Add($key, $entry.parameters[$key])
        }
    }

    return @{
        compressed = $pipelineMatrix | ConvertTo-Json -Compress ;
        pretty = $pipelineMatrix | ConvertTo-Json;
    }
}

function GenerateSparseMatrix {
    param([HashTable]$parameters, [HashTable]$displayNames, [int]$count)

    [Array]$matrix, [Array]$dimensions = GenerateFullMatrix $parameters $displayNames
    $sparseMatrix = @()

    # With full matrix, retrieve items by doing diagonal lookups across the matrix N times.
    # For example, given a matrix with dimensions 3, 2, 2:
    # 0, 0, 0
    # 1, 1, 1
    # 2, 2, 2
    # 3, 0, 0 <- 3, 3, 3 wraps to 3, 0, 0 given the dimensions
    for ($i = 0; $i -lt $count; $i++) {
        $idx = @()
        for ($j = 0; $j -lt $dimensions.Length; $j++) {
            $idx += $i % $dimensions[$j]
        }
        $sparseMatrix += GetNdMatrixElement $idx $matrix $dimensions
    }

    return $sparseMatrix
}

function GenerateFullMatrix {
    param([HashTable]$parameters, [HashTable]$displayNames = @{})

    $sortedParameters = SortMatrix $parameters

    $matrix = [System.Collections.ArrayList]::new()
    InitializeMatrix $sortedParameters $displayNames $matrix

    return $matrix.ToArray(), (GetMatrixDimensions $parameters)
}

# SortMatrix sorts a matrix by three properties:
# 1. Descending element length or parameters
# 2. Ascending parameter names alphabetically
# 3. Ascending parameter values alphabetically
#
# The matrix must be sorted in order to have a deterministic layout.
# This guarantees that a sparse matrix will always be generated with the
# same set of elements given the same input.
#
# Additionally, parameter value arrays should be sorted, so that the azure pipelines
# matrix yaml gets generated consistently.
function SortMatrix {
    param([HashTable]$parameters)

    $sortedParameters = $parameters.GetEnumerator() `
        | Sort-Object -Property `
            @{ Expression = { $_.Value.Length }; Descending=$true }, `
            @{ Expression = { $_.Name }; Descending=$false }

    for ($i = 0; $i -lt $sortedParameters.Length; $i++) {
        $sortedParameters[$i].Value = $sortedParameters[$i].Value | Sort-Object
    }

    return $sortedParameters
}

function CreateMatrixEntry {
    param([System.Collections.Specialized.OrderedDictionary]$permutation, [HashTable]$displayNames = @{})

    $names = @()
    foreach ($key in $permutation.Keys) {
        $nameSegment = CreateDisplayName $permutation[$key] $displayNames
        if ($nameSegment) {
            $names += $nameSegment
        }
    }
    return @{
        name = $names -join "_"
        parameters = $permutation
    }
}

function InitializeMatrix {
    param(
        [Array]$parameters,
        [HashTable]$displayNames,
        [System.Collections.ArrayList]$permutations,
        [System.Collections.Specialized.OrderedDictionary]$permutation = @{}
    )

    if (!$parameters) {
        $entry = CreateMatrixEntry $permutation $displayNames
        $permutations.Add($entry) | Out-Null
        return
    }

    $head, $tail = $parameters
    foreach ($value in $head.value) {
        $newPermutation = [ordered]@{}
        foreach ($element in $permutation.GetEnumerator()) {
            $newPermutation[$element.Name] = $element.Value
        }
        $newPermutation[$head.name] = $value
        InitializeMatrix $tail $displayNames $permutations $newPermutation
    }
}

function GetMatrixDimensions {
    param([HashTable]$parameters)

    $dimensions = @()
    foreach ($param in $parameters.GetEnumerator()) {
        $dimensions += $param.Value.Length
    }

    return $dimensions | Sort-Object -Descending
}

function SetNdMatrixElement {
    param(
        $element,
        [ValidateNotNullOrEmpty()]
        [Array]$idx,
        [ValidateNotNullOrEmpty()]
        [Array]$matrix,
        [ValidateNotNullOrEmpty()]
        [Array]$dimensions
    )

    if ($idx.Length -ne $dimensions.Length) {
        throw "Matrix index query $($idx.Length) must be the same length as its dimensions $($dimensions.Length)"
    }

    $arrayIndex = GetNdMatrixArrayIndex $idx $dimensions
    $matrix[$arrayIndex] = $element
}

function GetNdMatrixArrayIndex {
    param(
        [ValidateNotNullOrEmpty()]
        [Array]$idx,
        [ValidateNotNullOrEmpty()]
        [Array]$dimensions
    )

    if ($idx.Length -ne $dimensions.Length) {
        throw "Matrix index query length ($($idx.Length)) must be the same as dimension length ($($dimensions.Length))"
    }

    $stride = 1
    # Commented out does lookup with wrap handling
    # $index = $idx[$idx.Length-1] % $dimensions[$idx.Length-1]
    $index = $idx[$idx.Length-1]

    for ($i = $dimensions.Length-1; $i -ge 1; $i--) {
        $stride *= $dimensions[$i]
        # Commented out does lookup with wrap handling
        # $index += ($idx[$i-1] % $dimensions[$i-1]) * $stride
        $index += $idx[$i-1] * $stride
    }

    return $index
}

function GetNdMatrixElement {
    param(
        [ValidateNotNullOrEmpty()]
        [Array]$idx,
        [ValidateNotNullOrEmpty()]
        [Array]$matrix,
        [ValidateNotNullOrEmpty()]
        [Array]$dimensions
    )

    $arrayIndex = GetNdMatrixArrayIndex $idx $dimensions
    return $matrix[$arrayIndex]
}

function GetNdMatrixIndex {
    param(
        [int]$index,
        [ValidateNotNullOrEmpty()]
        [Array]$dimensions
    )

    $matrixIndex = @()
    $stride = 1

    for ($i = $dimensions.Length-1; $i -ge 1; $i--) {
        $stride *= $dimensions[$i]
        $page = [math]::floor($index / $stride) % $dimensions[$i-1]
        $matrixIndex = ,$page + $matrixIndex
    }
    $col = $index % $dimensions[$dimensions.Length-1]
    $matrixIndex += $col

    return $matrixIndex
}

# # # # # # # # # # # # # # # # # # # # # # # # # # # #
# The below functions are non-dynamic examples that   #
# help explain the above N-dimensional algorithm      #
# # # # # # # # # # # # # # # # # # # # # # # # # # # #
function Get4dMatrixElement {
    param([Array]$idx, [Array]$matrix, [Array]$dimensions)

    $stride1 = $idx[0] * $dimensions[1] * $dimensions[2] * $dimensions[3]
    $stride2 = $idx[1] * $dimensions[2] * $dimensions[3]
    $stride3 = $idx[2] * $dimensions[3]
    $stride4 = $idx[3]

    return $matrix[$stride1 + $stride2 + $stride3 + $stride4]
}

function Get4dMatrixIndex {
    param([int]$index, [Array]$dimensions)

    $stride1 = $dimensions[3]
    $stride2 = $dimensions[2]
    $stride3 = $dimensions[1]
    $page1 = [math]::floor($index / $stride1) % $dimensions[2]
    $page2 = [math]::floor($index / ($stride1 * $stride2)) % $dimensions[1]
    $page3 = [math]::floor($index / ($stride1 * $stride2 * $stride3)) % $dimensions[0]
    $remainder = $index % $dimensions[3]

    return @($page3, $page2, $page1, $remainder)
}

