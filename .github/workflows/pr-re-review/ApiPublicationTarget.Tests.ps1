# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    Import-Module (Join-Path $PSScriptRoot 'PrReReviewGuard.psm1') -Force
    function New-ApiTargetExpected {
        return @{
            Scope = 'api'; Repository = 'Azure/azure-sdk-for-net'; Number = 123
            AnalyzedHeadSha = 'a' * 40; HeadSha = 'a' * 40; ChangedFiles = 1; ChangedApiFiles = 1
            ApiFilePaths = @('sdk/widgets/Azure.Widgets/api/Azure.Widgets.cs')
            InlineTargets = @(@{path = 'sdk/widgets/Azure.Widgets/src/Generated/Widget.cs'; lineRanges = @(@{start = 10; end = 12})})
        }
    }
    function New-ApiTargetReview {
        return @{type = 'submit_pull_request_review'; event = 'COMMENT'; body = 'API coverage: 1/1 API files reviewed'; pull_request_number = 123; repo = 'Azure/azure-sdk-for-net'}
    }
}

Describe 'API publication remains bound to the triggering PR' {
    It 'accepts an explicitly matching repository and pull request' {
        {Assert-PrReReviewOutput @{errors = @(); items = @((New-ApiTargetReview))} (New-ApiTargetExpected)} | Should -Not -Throw
    }
    It 'rejects a review redirected to another pull request' {
        $review = New-ApiTargetReview
        $review.pull_request_number = 124
        {Assert-PrReReviewOutput @{errors = @(); items = @($review)} (New-ApiTargetExpected)} | Should -Throw '*pull request*'
    }
    It 'rejects an inline comment redirected to another pull request even when its source anchor is valid' {
        $inline = @{type = 'create_pull_request_review_comment'; body = 'API finding'; path = 'sdk/widgets/Azure.Widgets/src/Generated/Widget.cs'; line = 11; pull_request_number = 124}
        {Assert-PrReReviewOutput @{errors = @(); items = @($inline, (New-ApiTargetReview))} (New-ApiTargetExpected)} | Should -Throw '*pull request*'
    }
    It 'rejects a repository override instead of validating against the wrong PR snapshot' {
        $review = New-ApiTargetReview
        $review.repo = 'Azure/another-repository'
        {Assert-PrReReviewOutput @{errors = @(); items = @($review)} (New-ApiTargetExpected)} | Should -Throw '*repository*'
    }
}
