# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'
$directory = Join-Path ([IO.Path]::GetTempPath()) ('multi-tenant-gate-tests-' + [guid]::NewGuid().ToString('N'))
$null = New-Item -ItemType Directory -Path $directory
$gate = Join-Path $PSScriptRoot 'Assert-LiveTestResults.ps1'
$scenarios = @('RoutesTracesAndLogsToTheirOwnResources', 'ReplaysTracesAndLogsAfterOneEndpointRecovers')

try {
    foreach ($case in @('passed', 'failed', 'skipped', 'missing', 'empty', 'unrelated')) {
        $document = [xml] '<TestRun xmlns="http://microsoft.com/schemas/VisualStudio/TeamTest/2010"><TestDefinitions/><Results/></TestRun>'
        foreach ($isAsync in @('False', 'True')) {
            foreach ($scenario in $scenarios) {
                if ($case -eq 'empty' -or ($case -eq 'missing' -and $scenario -eq $scenarios[1])) { continue }
                $id = [guid]::NewGuid().ToString()
                $definition = $document.CreateElement('UnitTest', $document.DocumentElement.NamespaceURI)
                $definition.SetAttribute('id', $id)
                $method = $document.CreateElement('TestMethod', $document.DocumentElement.NamespaceURI)
                $className = "Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.MultiTenantExportLiveTests($isAsync)"
                if ($case -eq 'unrelated') { $className = 'UnrelatedFixture' }
                $method.SetAttribute('className', $className)
                $null = $definition.AppendChild($method)
                $null = $document.SelectSingleNode('//*[local-name()="TestDefinitions"]').AppendChild($definition)
                $result = $document.CreateElement('UnitTestResult', $document.DocumentElement.NamespaceURI)
                $result.SetAttribute('testId', $id)
                $result.SetAttribute('testName', $scenario)
                $outcome = 'Passed'
                if ($isAsync -eq 'True' -or $case -eq 'skipped') { $outcome = 'NotExecuted' }
                elseif ($case -eq 'failed' -and $scenario -eq $scenarios[1]) { $outcome = 'Failed' }
                $result.SetAttribute('outcome', $outcome)
                $null = $document.SelectSingleNode('//*[local-name()="Results"]').AppendChild($result)
            }
        }
        $document.Save((Join-Path $directory 'fixture.trx'))
        $rejected = $false
        try { & $gate -ResultsDirectory $directory }
        catch {
            if ($_.Exception.Message -notlike 'Required live scenario did not pass*') { throw }
            $rejected = $true
        }
        if ($rejected -ne ($case -ne 'passed')) { throw "Unexpected TRX gate result for fixture: $case" }
    }
    Write-Host 'Six synthetic TRX gate cases passed; no Azure tests were run.'
}
finally {
    Remove-Item -LiteralPath $directory -Recurse -Force
}