#Requires -Version 7.0

BeforeAll {
    . (Join-Path $PSScriptRoot ".." "automation" "GenerateAndBuildLib.ps1")
}

Describe "Get-SpecPullRequestValidationPlan" {
    It "uses one package-scoped Release pack with API compatibility" {
        $plan = Get-SpecPullRequestValidationPlan `
            -srcPath "/repo/sdk/network/Azure.ResourceManager.Network/src" `
            -projectFolder "/repo/sdk/network/Azure.ResourceManager.Network" `
            -sdkRootPath "/repo"

        $plan.PackArguments | Should -Be @(
            "pack"
            "/repo/sdk/network/Azure.ResourceManager.Network/src"
            "--configuration"
            "Release"
            "/p:ValidateRunApiCompat=true"
            "/p:IncludeTests=false"
            "/p:IncludeSamples=false"
            "/p:IncludePerf=false"
            "/p:IncludeStress=false"
            "/p:IncludeIntegrationTests=false"
        )
        $plan.ArtifactPackArguments | Should -Be @(
            "pack"
            "/repo/sdk/network/Azure.ResourceManager.Network/src"
            "--configuration"
            "Release"
            "/p:RunApiCompat=false"
            "/p:IncludeTests=false"
            "/p:IncludeSamples=false"
            "/p:IncludePerf=false"
            "/p:IncludeStress=false"
            "/p:IncludeIntegrationTests=false"
        )
        $plan.ApiExportArguments.PackagePath | Should -Be "/repo/sdk/network/Azure.ResourceManager.Network"
        $plan.ApiExportArguments.SdkRepoPath | Should -Be "/repo"
    }
}
