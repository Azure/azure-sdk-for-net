# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

function ConvertTo-SampleSelectionTree {
    param([Parameter(Mandatory)] [string] $Selection)

    $tokens = [System.Collections.Generic.List[object]]::new()
    $position = 0
    while ($position -lt $Selection.Length) {
        $match = [regex]::Match($Selection.Substring($position),
            '^\s*(?:(?<group>[()&|])|(?<property>FullyQualifiedName|Name)\s*(?<operator>!=|!~|=|~)\s*(?<value>(?:\\.|[^()&|])+))')
        if (-not $match.Success) {
            throw "Unsupported sample filter at position $position. Use FullyQualifiedName or Name with =, !=, ~, !~, parentheses, & and |."
        }
        if ($match.Groups['group'].Success) {
            $tokens.Add(@{ kind = $match.Groups['group'].Value })
        } else {
            $value = $match.Groups['value'].Value.Trim()
            if ([string]::IsNullOrWhiteSpace($value)) { throw 'Sample filter values cannot be empty.' }
            $tokens.Add(@{
                kind = 'match'; property = $match.Groups['property'].Value
                operator = $match.Groups['operator'].Value
                value = [regex]::Replace($value, '\\(.)', '$1')
            })
        }
        $position += $match.Length
        if ([string]::IsNullOrWhiteSpace($Selection.Substring($position))) { break }
    }

    $state = @{ index = 0; tokens = $tokens }
    $tree = Read-SampleSelectionExpression -State $state
    if ($state.index -ne $tokens.Count) { throw 'Unexpected token in sample filter.' }
    return $tree
}

function Read-SampleSelectionExpression {
    param([hashtable] $State, [int] $Precedence = 0)

    if ($State.index -ge $State.tokens.Count) { throw 'Incomplete sample filter.' }
    $left = $State.tokens[$State.index++]
    if ($left.kind -eq '(') {
        $left = Read-SampleSelectionExpression -State $State
        if ($State.index -ge $State.tokens.Count -or $State.tokens[$State.index++].kind -ne ')') {
            throw 'Unbalanced sample filter parentheses.'
        }
    } elseif ($left.kind -ne 'match') {
        throw 'Expected a sample filter comparison.'
    }
    while ($State.index -lt $State.tokens.Count) {
        $operator = $State.tokens[$State.index].kind
        $nextPrecedence = switch ($operator) { '|' { 1 } '&' { 2 } default { 0 } }
        if ($nextPrecedence -le $Precedence) { break }
        $State.index++
        $right = Read-SampleSelectionExpression -State $State -Precedence $nextPrecedence
        $left = @{ kind = $operator; left = $left; right = $right }
    }
    return $left
}

function Test-SampleSelection {
    param([hashtable] $Tree, [hashtable] $Test)

    if ($Tree.kind -eq '&') {
        return (Test-SampleSelection $Tree.left $Test) -and (Test-SampleSelection $Tree.right $Test)
    }
    if ($Tree.kind -eq '|') {
        return (Test-SampleSelection $Tree.left $Test) -or (Test-SampleSelection $Tree.right $Test)
    }
    $actual = if ($Tree.property -eq 'Name') { $Test.name } else { $Test.fullName }
    $comparison = [StringComparison]::OrdinalIgnoreCase
    switch ($Tree.operator) {
        '=' { return [string]::Equals($actual, $Tree.value, $comparison) }
        '!=' { return -not [string]::Equals($actual, $Tree.value, $comparison) }
        '~' { return $actual.IndexOf($Tree.value, $comparison) -ge 0 }
        '!~' { return $actual.IndexOf($Tree.value, $comparison) -lt 0 }
        default { throw 'Unsupported sample comparison.' }
    }
}

function New-SampleQueuePlan {
    param(
        [Parameter(Mandatory)] [hashtable[]] $Tests,
        [ValidateRange(1, 4)] [int] $QueueCount = 4,
        [Parameter(Mandatory)] [string] $Pool,
        [Parameter(Mandatory)] [string] $Image
    )

    if ($Tests.Count -eq 0) { throw 'No runnable samples matched the selection.' }
    $byName = [System.Collections.Generic.Dictionary[string, object]]::new([StringComparer]::Ordinal)
    foreach ($test in $Tests) {
        if ([string]::IsNullOrWhiteSpace($test.fullName) -or $byName.ContainsKey($test.fullName)) {
            throw 'Sample planning requires nonempty unique test IDs.'
        }
        $byName.Add($test.fullName, $test)
    }
    [string[]] $names = @($byName.Keys)
    [Array]::Sort($names, [StringComparer]::Ordinal)
    $active = [Math]::Min($QueueCount, $names.Count)
    $queues = [ordered]@{}
    $matrix = [ordered]@{}
    for ($index = 0; $index -lt $active; $index++) {
        $queueName = "q$($index + 1)"
        $selected = @(
            for ($offset = $index; $offset -lt $names.Count; $offset += $active) {
                $byName[$names[$offset]]
            }
        )
        $filters = @($selected | ForEach-Object {
            $escaped = [regex]::Replace($_.fullName, '([\\()&|=!~])', '\$1')
            "FullyQualifiedName=$escaped"
        })
        $filter = '(' + ($filters -join '|') + ')'
        $queues[$queueName] = @{ schemaVersion = 1; queueName = $queueName; selectedTests = $selected; filter = $filter }
        $matrix[$queueName] = @{
            SampleQueueName = $queueName
            OSVmImage = $Image; Pool = $Pool
            TestTargetFramework = 'net10.0'; BuildConfiguration = 'Debug'
            AdditionalTestArguments = '/p:UseProjectReferenceToAzureClients=false'
        }
    }
    return @{ queues = $queues; matrix = $matrix }
}
