#Requires -Version 7.0
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

# Every push to a PR fires both pull_request and pull_request_target. Same-repo PRs must be
# re-reviewed only under pull_request, and fork PRs only under pull_request_target (fork
# pull_request runs get a read-only token that cannot request Copilot), so each non-draft
# push is re-reviewed exactly once. These tests evaluate the compiled job conditions, which
# combine the workflow's `if:` with gh-aw's own same-repo guard on pull_request.

BeforeDiscovery {
    $routingCases = @(
        @{ Name = 'same-repo push under pull_request runs'; EventName = 'pull_request'; FromFork = $false; Draft = $false; Runs = $true }
        @{ Name = 'fork push under pull_request is skipped'; EventName = 'pull_request'; FromFork = $true; Draft = $false; Runs = $false }
        @{ Name = 'same-repo push under pull_request_target is skipped'; EventName = 'pull_request_target'; FromFork = $false; Draft = $false; Runs = $false }
        @{ Name = 'fork push under pull_request_target runs'; EventName = 'pull_request_target'; FromFork = $true; Draft = $false; Runs = $true }
        @{ Name = 'draft same-repo push is skipped'; EventName = 'pull_request'; FromFork = $false; Draft = $true; Runs = $false }
        @{ Name = 'draft fork push is skipped'; EventName = 'pull_request_target'; FromFork = $true; Draft = $true; Runs = $false }
    )
}

BeforeAll {
    $script:LockLines = [IO.File]::ReadAllLines((Join-Path $PSScriptRoot '..' 'pr-re-review.lock.yml'))

    function Get-YamlSection {
        param([string[]]$Lines, [string]$Key, [int]$Indent)

        $start = [array]::IndexOf($Lines, (' ' * $Indent) + "${Key}:")
        if ($start -lt 0) { throw "The compiled lock file has no '${Key}:' at indent $Indent." }
        $end = $start + 1
        while ($end -lt $Lines.Count -and ([string]::IsNullOrWhiteSpace($Lines[$end]) -or $Lines[$end] -cmatch "^ {$($Indent + 1)}")) { $end++ }
        return ,$Lines[($start + 1)..($end - 1)]
    }

    function Get-JobCondition {
        param([string]$JobName)

        $job = Get-YamlSection (Get-YamlSection $script:LockLines 'jobs' 0) $JobName 2
        $match = [regex]::Match(($job -join "`n") + "`n", '(?m)^ {4}if: (.*)\n((?: {6}.*\n)*)')
        if (-not $match.Success) { throw "Job '$JobName' has no job-level 'if:'." }
        # gh-aw folds long conditions into a `>` scalar, whose lines YAML joins with single spaces.
        $condition = if ($match.Groups[1].Value -ceq '>') {
            ($match.Groups[2].Value -split "`n" | ForEach-Object Trim | Where-Object { $_ }) -join ' '
        } else {
            $match.Groups[1].Value
        }
        return $condition -replace '^\$\{\{\s*|\s*\}\}$', ''
    }

    # Evaluates only the GitHub Actions expression subset gh-aw emits for these conditions:
    # property paths, string/number/boolean/null literals, !, ==, !=, &&, ||, and parentheses.
    # Anything else (such as a function call) fails the parse, so a gh-aw upgrade that changes
    # the condition's shape is caught rather than silently mis-evaluated.
    function ConvertTo-ExpressionToken {
        param([string]$Expression)

        $pattern = [regex]'\G\s*(?:(?<op>\|\||&&|==|!=|!|\(|\))|''(?<str>(?:[^'']|'''')*)''|(?<num>\d+(?:\.\d+)?)|(?<path>[A-Za-z_][\w-]*(?:\.[A-Za-z_][\w-]*)*))'
        $tokens = [System.Collections.Generic.List[hashtable]]::new()
        $index = 0
        while ($Expression.Substring($index).Trim()) {
            $match = $pattern.Match($Expression, $index)
            if (-not $match.Success) { throw "Unsupported expression syntax at: $($Expression.Substring($index))" }
            $index += $match.Length
            if ($match.Groups['op'].Success) { $tokens.Add(@{ Op = $match.Groups['op'].Value }) }
            elseif ($match.Groups['str'].Success) { $tokens.Add(@{ Value = $match.Groups['str'].Value.Replace("''", "'") }) }
            elseif ($match.Groups['num'].Success) { $tokens.Add(@{ Value = [double]::Parse($match.Groups['num'].Value, [cultureinfo]::InvariantCulture) }) }
            else { $tokens.Add(@{ Path = $match.Groups['path'].Value }) }
        }
        return ,$tokens
    }

    function Test-ExpressionTruthy {
        param($Value)

        if ($null -eq $Value) { return $false }
        if ($Value -is [bool]) { return $Value }
        if ($Value -is [string]) { return $Value.Length -gt 0 }
        if ($Value -is [ValueType]) { return [double]$Value -ne 0 -and -not [double]::IsNaN([double]$Value) }
        return $true
    }

    function ConvertTo-ExpressionNumber {
        param($Value)

        if ($null -eq $Value) { return 0.0 }
        if ($Value -is [bool]) { return [double][int]$Value }
        if ($Value -is [string]) {
            if (-not $Value.Trim()) { return 0.0 }
            $number = 0.0
            if ([double]::TryParse($Value, [Globalization.NumberStyles]::Float, [cultureinfo]::InvariantCulture, [ref]$number)) { return $number }
            return [double]::NaN
        }
        if ($Value -is [ValueType]) { return [double]$Value }
        return [double]::NaN
    }

    # GitHub compares strings case-insensitively and coerces mismatched types to numbers, which is
    # what lets the numeric head.repo.id equal the string github.repository_id.
    function Test-ExpressionEqual {
        param($Left, $Right)

        if ($null -eq $Left -and $null -eq $Right) { return $true }
        if ($null -ne $Left -and $null -ne $Right -and $Left.GetType() -eq $Right.GetType()) {
            if ($Left -is [string]) { return [string]::Equals($Left, $Right, [StringComparison]::OrdinalIgnoreCase) }
            return $Left -eq $Right
        }
        return (ConvertTo-ExpressionNumber $Left) -eq (ConvertTo-ExpressionNumber $Right)
    }

    function Resolve-ExpressionPath {
        param([System.Collections.IDictionary]$Context, [string]$Path)

        $value = $Context
        foreach ($segment in $Path.Split('.')) {
            if ($value -isnot [System.Collections.IDictionary] -or -not $value.Contains($segment)) { return $null }
            $value = $value[$segment]
        }
        return $value
    }

    function Test-WorkflowCondition {
        param([string]$Expression, [System.Collections.IDictionary]$Context)

        $state = @{ Tokens = (ConvertTo-ExpressionToken $Expression); Position = 0 }

        function Test-NextOperator([string]$Operator) {
            $state.Position -lt $state.Tokens.Count -and $state.Tokens[$state.Position].Op -ceq $Operator
        }

        function Read-Token {
            if ($state.Position -ge $state.Tokens.Count) { throw "Unexpected end of expression: $Expression" }
            $token = $state.Tokens[$state.Position]
            $state.Position++
            return $token
        }

        function Read-OrExpression {
            $value = Read-AndExpression
            while (Test-NextOperator '||') {
                $null = Read-Token
                $right = Read-AndExpression
                if (-not (Test-ExpressionTruthy $value)) { $value = $right }
            }
            return $value
        }

        function Read-AndExpression {
            $value = Read-EqualityExpression
            while (Test-NextOperator '&&') {
                $null = Read-Token
                $right = Read-EqualityExpression
                if (Test-ExpressionTruthy $value) { $value = $right }
            }
            return $value
        }

        function Read-EqualityExpression {
            $value = Read-UnaryExpression
            while ((Test-NextOperator '==') -or (Test-NextOperator '!=')) {
                $negate = (Read-Token).Op -ceq '!='
                $value = (Test-ExpressionEqual $value (Read-UnaryExpression)) -ne $negate
            }
            return $value
        }

        function Read-UnaryExpression {
            if (Test-NextOperator '!') {
                $null = Read-Token
                return -not (Test-ExpressionTruthy (Read-UnaryExpression))
            }
            return Read-PrimaryExpression
        }

        function Read-PrimaryExpression {
            $token = Read-Token
            if ($token.Op -ceq '(') {
                $value = Read-OrExpression
                if (-not (Test-NextOperator ')')) { throw "Expected ')' in: $Expression" }
                $null = Read-Token
                return $value
            }
            if ($token.ContainsKey('Value')) { return $token.Value }
            if ($token.ContainsKey('Path')) {
                if (Test-NextOperator '(') { throw "Function calls are not supported: $($token.Path)()" }
                switch -CaseSensitive ($token.Path) {
                    'true' { return $true }
                    'false' { return $false }
                    'null' { return $null }
                }
                return Resolve-ExpressionPath $Context $token.Path
            }
            throw "Unexpected '$($token.Op)' in: $Expression"
        }

        $result = Read-OrExpression
        if ($state.Position -ne $state.Tokens.Count) { throw "Unexpected trailing tokens in: $Expression" }
        return Test-ExpressionTruthy $result
    }

    function New-PushContext {
        param([string]$EventName, [bool]$FromFork, [bool]$Draft)

        return @{
            github = @{
                event_name = $EventName
                # A string in the Actions context, while the webhook payload's repo ids are numbers.
                repository_id = '1000'
                event = @{ pull_request = @{ draft = $Draft; head = @{ repo = @{ id = $(if ($FromFork) { 2000 } else { 1000 }) } } } }
            }
            needs = @{ pre_activation = @{ outputs = @{ activated = 'true' } } }
        }
    }
}

Describe 'pr-re-review trigger routing' {
    It 'triggers only on synchronize under <EventName>' -ForEach @(
        @{ EventName = 'pull_request' }
        @{ EventName = 'pull_request_target' }
    ) {
        $trigger = Get-YamlSection (Get-YamlSection $LockLines 'on' 0) $EventName 2
        $types = (Get-YamlSection $trigger 'types' 4) -cmatch '\S' -replace '^\s*- ', ''
        $types -join ', ' | Should -BeExactly 'synchronize'
    }

    Context '<JobName> condition' -ForEach @(
        @{ JobName = 'pre_activation' }
        @{ JobName = 'activation' }
    ) {
        BeforeAll {
            $condition = Get-JobCondition $JobName
        }

        It '<Name>' -ForEach $routingCases {
            $pushContext = New-PushContext -EventName $EventName -FromFork $FromFork -Draft $Draft
            Test-WorkflowCondition $condition $pushContext | Should -Be $Runs
        }

        It 'replay dispatched without a pull request runs' {
            $dispatchContext = @{
                github = @{ event_name = 'workflow_dispatch'; repository_id = '1000'; event = @{ inputs = @{ pull_request = '1' } } }
                needs = @{ pre_activation = @{ outputs = @{ activated = 'true' } } }
            }
            Test-WorkflowCondition $condition $dispatchContext | Should -BeTrue
        }
    }

    It 'reopens review threads for a pull request but never for a replay' {
        $condition = Get-JobCondition 'unresolve_review_thread'
        # Stand in for the two functions the evaluator does not support: the run is not cancelled, and the agent asked to reopen a thread.
        foreach ($call in '!cancelled()', "contains(needs.agent.outputs.output_types, 'unresolve_review_thread')") {
            $condition.Contains($call, [StringComparison]::Ordinal) | Should -BeTrue -Because 'a changed condition shape means this test needs revisiting'
            $condition = $condition.Replace($call, 'true')
        }
        $needs = @{ agent = @{ result = 'success' }; safe_outputs = @{ result = 'success' } }
        Test-WorkflowCondition $condition @{ github = @{ event_name = 'pull_request' }; needs = $needs } | Should -BeTrue
        Test-WorkflowCondition $condition @{ github = @{ event_name = 'workflow_dispatch' }; needs = $needs } | Should -BeFalse
    }

    It 'starts the agent only when the size gate measured a read set within the limit (within_cap ''<WithinCap>'')' -ForEach @(
        @{ WithinCap = 'true'; Runs = $true }
        @{ WithinCap = 'false'; Runs = $false }
        # A failed or skipped gate leaves the output empty.
        @{ WithinCap = ''; Runs = $false }
    ) {
        $needs = @{ activation = @{ outputs = @{ daily_ai_credits_exceeded = 'false' } }; size_gate = @{ outputs = @{ within_cap = $WithinCap } } }
        Test-WorkflowCondition (Get-JobCondition 'agent') @{ needs = $needs } | Should -Be $Runs
    }

    It 'keys workflow concurrency by event so the skipped twin run never queues behind the real run' {
        $group = (Get-YamlSection $LockLines 'concurrency' 0) -cmatch '^  group: '
        $group | Should -HaveCount 1
        $group | Should -Match '\$\{\{\s*github\.event_name\s*\}\}'
        # A replay has no pull request number, so each one gets its own group instead of queuing behind the others.
        $group | Should -Match '\$\{\{\s*github\.event\.pull_request\.number\s*\|\|\s*github\.run_id\s*\}\}'
    }

    It 'adds the replay instructions to the prompt only for a dispatched replay' {
        $bindings = @($LockLines | ForEach-Object {
            if ($_ -cmatch '^\s+GH_AW_EXPR_[0-9A-F]+: \$\{\{ (?<expr>.*\bgithub\.event\.inputs\..*) \}\}$') { $Matches['expr'] }
        } | Select-Object -Unique)
        $replay = @($bindings | Where-Object { $_.Contains('This run replays', [StringComparison]::Ordinal) })
        $replay | Should -HaveCount 1
        $pullRequestContext = @{ github = @{ event_name = 'pull_request'; event = @{ pull_request = @{ number = 1; head = @{ sha = 'a' * 40 } } } } }
        $dispatchContext = @{ github = @{ event_name = 'workflow_dispatch'; event = @{ inputs = @{ pull_request = '1'; head_sha = 'b' * 40 } } } }
        Test-WorkflowCondition $replay[0] $pullRequestContext | Should -BeFalse
        Test-WorkflowCondition $replay[0] $dispatchContext | Should -BeTrue
        $targets = @($bindings | Where-Object { $_ -cnotin $replay })
        $targets | Should -HaveCount 2
        foreach ($target in $targets) {
            Test-WorkflowCondition $target $pullRequestContext | Should -BeTrue
            Test-WorkflowCondition $target $dispatchContext | Should -BeTrue
        }
    }

    # The pull_request_target path is safe partly because a fork cannot steer the agent through
    # its own instruction files: gh-aw must restore them from the base branch after checking out
    # the PR head.
    It 'restores agent config from the base branch after the PR head checkout' {
        $agent = Get-YamlSection (Get-YamlSection $LockLines 'jobs' 0) 'agent' 2
        $checkout = [array]::IndexOf($agent, '      - name: Checkout PR branch')
        $restore = [array]::IndexOf($agent, '      - name: Restore agent config folders from base branch')
        $checkout | Should -BeGreaterOrEqual 0 -Because 'a removed PR head checkout means this test needs revisiting'
        $restore | Should -BeGreaterThan $checkout -Because 'agent config must be restored after the PR head checkout'
        $step = for ($i = $restore + 1; $i -lt $agent.Count -and $agent[$i] -cmatch '^ {8}'; $i++) { $agent[$i] }
        $step -join "`n" | Should -Match 'GH_AW_AGENT_FOLDERS: ".*\.github.*"'
        $step -join "`n" | Should -Match 'GH_AW_AGENT_FILES: ".*AGENTS\.md.*"'
    }
}
