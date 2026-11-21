# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

function Assert-DotNetSampleAssignment {
    param([Parameter(Mandatory)] [System.Collections.IDictionary] $Assignment, [Parameter(Mandatory)] [string] $QueueName)

    if ($QueueName -cnotmatch '^q[1-4]$' -or $Assignment.schemaVersion -ne 1 -or $Assignment.queueName -cne $QueueName) {
        throw 'Invalid .NET sample assignment schema or queue.'
    }
    if ($Assignment.selectedTests -isnot [array] -or $Assignment.selectedTests.Count -eq 0) {
        throw 'A .NET sample assignment must contain at least one selected test.'
    }
    if ($Assignment.filter -isnot [string] -or [string]::IsNullOrWhiteSpace($Assignment.filter)) {
        throw 'A .NET sample assignment must contain a test filter.'
    }
    $names = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($test in $Assignment.selectedTests) {
        if ($test -isnot [System.Collections.IDictionary] -or [string]::IsNullOrWhiteSpace($test.package) -or
            [string]::IsNullOrWhiteSpace($test.name) -or [string]::IsNullOrWhiteSpace($test.fullName) -or
            -not $names.Add($test.fullName)) {
            throw 'A .NET sample assignment must contain package and name metadata and nonempty unique test IDs.'
        }
    }
}
