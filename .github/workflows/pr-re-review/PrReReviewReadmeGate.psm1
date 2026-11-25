#Requires -Version 7.5

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ErrorActionPreference = 'Stop'

function Invoke-PrReReviewGit {
    param([string]$RepositoryPath, [string[]]$Arguments)

    $start = [System.Diagnostics.ProcessStartInfo]::new('git')
    $start.UseShellExecute = $false
    $start.RedirectStandardOutput = $true
    $start.RedirectStandardError = $true
    $start.ArgumentList.Add('-C')
    $start.ArgumentList.Add($RepositoryPath)
    foreach ($argument in $Arguments) { $start.ArgumentList.Add($argument) }
    $process = [System.Diagnostics.Process]::Start($start)
    try {
        $output = $process.StandardOutput.ReadToEndAsync()
        $errors = $process.StandardError.ReadToEndAsync()
        $process.WaitForExit()
        if ($process.ExitCode -ne 0) { throw "git failed: $($errors.GetAwaiter().GetResult())" }
        return $output.GetAwaiter().GetResult()
    } finally {
        $process.Dispose()
    }
}

function Test-PrReReviewReadmeOnlyChanges {
    param(
        [Parameter(Mandatory)][string]$RepositoryPath,
        [Parameter(Mandatory)][string]$Baseline,
        [Parameter(Mandatory)][string]$Head
    )

    try {
        if ($Baseline -cnotmatch '^[0-9a-f]{40}$' -or $Head -cnotmatch '^[0-9a-f]{40}$' -or $Baseline -ceq $Head) { return $false }
        $null = Invoke-PrReReviewGit $RepositoryPath @('merge-base', '--is-ancestor', $Baseline, $Head)
        $lines = (Invoke-PrReReviewGit $RepositoryPath @('rev-list', '--first-parent', '--parents', "$Baseline..$Head")).Trim() -split "`n"
        $expected = $Head
        foreach ($line in $lines) {
            $parts = $line.Trim() -split ' '
            # Refuse merges, shallow boundaries, and incomplete or unexpected history.
            if ($parts.Count -ne 2 -or $parts[0] -cne $expected -or $parts[1] -cnotmatch '^[0-9a-f]{40}$') { return $false }
            $raw = Invoke-PrReReviewGit $RepositoryPath @('diff-tree', '--raw', '--no-commit-id', '--no-abbrev', '--no-renames', '--no-ext-diff', '--no-textconv', '-r', '-z', $parts[1], $parts[0])
            $fields = @($raw -split "`0" | Where-Object { $_ -cne '' })
            if ($fields.Count -eq 0 -or $fields.Count % 2 -ne 0) { return $false }
            for ($i = 0; $i -lt $fields.Count; $i += 2) {
                # Only normal, non-executable files. A type or mode change is not a simple doc update.
                if ($fields[$i] -cnotmatch '^:(?:000000|100644) (?:000000|100644) [0-9a-f]{40} [0-9a-f]{40} [ADM]$') { return $false }
                if ([IO.Path]::GetFileName($fields[$i + 1]) -ine 'README.md') { return $false }
            }
            $expected = $parts[1]
        }
        return $expected -ceq $Baseline
    } catch {
        Write-Verbose "Cannot prove README-only history: $_"
        return $false
    }
}

function New-PrReReviewReceipt {
    param(
        [Parameter(Mandatory)][System.Collections.IDictionary]$Context,
        [Parameter(Mandatory)][array]$Items,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Review,
        [Parameter(Mandatory)][string]$ServerUrl
    )

    if ($Context.Repository -cnotmatch '^[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+$' -or
        $Context.Head -cnotmatch '^[0-9a-f]{40}$' -or $Context.Base -cnotmatch '^[0-9a-f]{40}$' -or $Context.BaseTip -cnotmatch '^[0-9a-f]{40}$' -or $Context.WorkflowSha -cnotmatch '^[0-9a-f]{40}$' -or
        $Context.Number -isnot [int] -or $Context.Number -le 0 -or
        $Context.RunId -isnot [long] -and $Context.RunId -isnot [int] -or $Context.RunId -le 0 -or
        $Context.Attempt -ne 1 -or $Context.Event -cnotin @('pull_request', 'pull_request_target') -or
        [string]::IsNullOrWhiteSpace($Context.BaseRef) -or
        ($Context.Event -ceq 'pull_request_target' -and $Context.WorkflowSha -cne $Context.BaseTip)) { throw 'Invalid receipt context.' }
    # The successful safe-output processor supplies the exact published review ID. Its
    # configured token may be a GitHub App or PAT, not necessarily github-actions[bot].
    $reviews = @($Items | Where-Object { $_.type -ceq 'submit_pull_request_review' })
    if ($reviews.Count -ne 1) { throw 'Exactly one processed review is required.' }
    $item = $reviews[0]
    if ($item.repo -cne $Context.Repository -or $item.number -ne $Context.Number -or
        $item.id -le 0 -or $item.metadata.review_id -ne $item.id -or
        $item.metadata.review_event -cne 'COMMENT' -or $item.metadata.review_state -cne 'COMMENTED') {
        throw 'Processed review does not match the target pull request.'
    }
    $url = "$($ServerUrl.TrimEnd('/'))/$($Context.Repository)/actions/runs/$($Context.RunId)"
    $footer = '> Re-reviewed by Pull Request Re-Review: ' + $url
    if ($Review.id -ne $item.id -or $Review.state -cne 'COMMENTED' -or
        $Review.commit_id -cne $Context.Head -or [string]$Review.user.login -cnotmatch '^[A-Za-z0-9][A-Za-z0-9-]*(?:\[bot\])?$' -or
        [string]$Review.user.id -cnotmatch '^[1-9][0-9]*$' -or [string]::IsNullOrWhiteSpace($Review.submitted_at) -or
        @($Review.body -split '\r?\n' | Where-Object { $_ -ceq $footer }).Count -ne 1) {
        throw 'The published review does not match the completed run.'
    }
    return @{
        version = 1; repository = $Context.Repository; number = $Context.Number; head = $Context.Head
        base = $Context.Base; base_tip = $Context.BaseTip; base_ref = $Context.BaseRef; workflow_sha = $Context.WorkflowSha; run_id = $Context.RunId; attempt = 1
        event = $Context.Event; review_id = $item.id; publisher = $Review.user.login; publisher_id = $Review.user.id
    }
}

function Test-PrReReviewBaseline {
    param(
        [Parameter(Mandatory)][System.Collections.IDictionary]$Expected,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Receipt,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Run,
        [Parameter(Mandatory)][array]$Jobs,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Review,
        [Parameter(Mandatory)][string]$ServerUrl
    )
    try {
        if ($Receipt.version -ne 1 -or $Receipt.repository -cne $Expected.repository -or
            $Receipt.number -ne $Expected.number -or $Receipt.base -cne $Expected.base -or $Receipt.base_tip -cne $Expected.base_tip -or
            $Receipt.base_ref -cne $Expected.base_ref -or $Receipt.event -cne $Expected.event -or
            $Receipt.attempt -ne 1 -or $Run.id -ne $Receipt.run_id -or $Run.run_attempt -ne 1 -or
            $Run.status -cne 'completed' -or $Run.conclusion -cne 'success' -or
            $Run.event -cne $Receipt.event -or $Run.head_sha -cne $Receipt.head -or
            $Run.path -cne '.github/workflows/pr-re-review.lock.yml' -or
            $Review.user.login -cne $Receipt.publisher -or $Review.user.id -ne $Receipt.publisher_id) { return $false }
        foreach ($name in @('agent', 'detection', 'safe_outputs', 'validate_agent_output', 'baseline-receipt')) {
            $matching = @($Jobs | Where-Object { $_.name -ceq $name -and $_.conclusion -ceq 'success' })
            if ($matching.Count -ne 1 -or @($Jobs | Where-Object { $_.name -ceq $name }).Count -ne 1) { return $false }
            $requiredSteps = if ($name -ceq 'baseline-receipt') { @('Upload verified baseline', 'Confirm baseline upload') }
                elseif ($name -ceq 'safe_outputs') { @('Require complete re-review coverage before publishing', 'Process Safe Outputs', 'Upload Safe Outputs Items') }
                else { @() }
            foreach ($stepName in $requiredSteps) {
                $steps = @($matching[0].steps | Where-Object { $_.name -ceq $stepName -and $_.conclusion -ceq 'success' })
                if ($steps.Count -ne 1) { return $false }
            }
        }
        $context = @{
            Repository = $Receipt.repository; Number = [int]$Receipt.number; Head = $Receipt.head; Base = $Receipt.base
            BaseRef = $Receipt.base_ref; BaseTip = $Receipt.base_tip; WorkflowSha = $Receipt.workflow_sha; RunId = [long]$Receipt.run_id; Attempt = [int]$Receipt.attempt; Event = $Receipt.event
        }
        $item = @{ type = 'submit_pull_request_review'; repo = $Receipt.repository; number = $Receipt.number; id = $Receipt.review_id
            metadata = @{ review_id = $Receipt.review_id; review_event = 'COMMENT'; review_state = 'COMMENTED' } }
        $null = New-PrReReviewReceipt -Context $context -Items @($item) -Review $Review -ServerUrl $ServerUrl
        return $true
    } catch { return $false }
}

Export-ModuleMember -Function Test-PrReReviewReadmeOnlyChanges, New-PrReReviewReceipt, Test-PrReReviewBaseline
