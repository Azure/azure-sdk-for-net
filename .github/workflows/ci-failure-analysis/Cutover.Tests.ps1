#Requires -Version 7.5
#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.3.3' }

# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

BeforeAll {
    $script:GitHubRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..')).Path
    $script:SkillRoot = Join-Path $GitHubRoot 'skills' 'code-review'
    $script:SchemaHelper = Join-Path $SkillRoot 'scripts' 'Get-ProvisioningSchema.ps1'
}

Describe 'SDK review ownership cutover' {
    It 'retires management and provisioning dispatchers, sources, and compiled endpoints together' {
        foreach ($prefix in @('mgmt-review', 'provisioning-review')) {
            foreach ($suffix in @('-trigger.yml', '.md', '.lock.yml')) {
                $name = "$prefix$suffix"
                Test-Path (Join-Path $GitHubRoot 'workflows' $name) | Should -BeFalse -Because "$name must not remain dispatchable"
            }
        }
        Test-Path (Join-Path $GitHubRoot 'workflows' 'shared' 'review-execution-status.md') | Should -BeFalse
    }

    It 'routes provisioning packages through the shared skill and compiled re-review rules' {
        $skill = Get-Content (Join-Path $SkillRoot 'SKILL.md') -Raw
        $rules = Get-Content (Join-Path $SkillRoot 'references' 'repository-rules.md') -Raw
        $workflow = Get-Content (Join-Path $GitHubRoot 'workflows' 'pr-re-review.md') -Raw
        $compiled = Get-Content (Join-Path $GitHubRoot 'workflows' 'pr-re-review.lock.yml') -Raw

        $skill | Should -Match 'Azure\.Provisioning'
        $skill | Should -Match 'Provisioning Libraries'
        $rules | Should -Match '## Provisioning Libraries'
        $rules | Should -Match '\.github/skills/code-review/scripts/Get-ProvisioningSchema\.ps1'
        $rules | Should -Match 'trusted base-branch'
        $workflow | Should -Match '/\.github/skills/code-review/references/repository-rules\.md'
        $compiled | Should -Match '## Provisioning Libraries'
        $compiled | Should -Match '\.github/skills/code-review/scripts/Get-ProvisioningSchema\.ps1'
    }

    It 'keeps CI failure analysis independent of the retired provisioning endpoint' {
        $analysis = Get-Content (Join-Path $GitHubRoot 'workflows' 'ci-failure-analysis.md') -Raw
        $analysis | Should -Not -Match 'provisioning-review'
        $analysis | Should -Match 'sole automatic CI failure-analysis owner'
        Test-Path (Join-Path $GitHubRoot 'workflows' 'ci-failure-analysis-trigger.yml') | Should -BeTrue
    }

    It 'runs guard tests when the shared review skill or schema helper changes' {
        foreach ($name in @('ci-failure-analysis-tests.yml', 'pr-re-review-tests.yml')) {
            Get-Content (Join-Path $GitHubRoot 'workflows' $name) -Raw |
                Should -Match ([regex]::Escape('.github/skills/code-review/**'))
        }
    }
}

Describe 'Relocated provisioning schema helper' {
    BeforeAll {
        $script:PackagePath = Join-Path $TestDrive 'Azure.Provisioning.Example'
        $generated = Join-Path $PackagePath 'src' 'Generated'
        $custom = Join-Path $PackagePath 'src' 'Custom'
        New-Item -ItemType Directory -Path $generated, $custom -Force | Out-Null
        @'
public partial class ExampleResource : ProvisionableResource
{
    public ExampleResource(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Example/resources", resourceVersion ?? "2026-01-01")
    {
        throw new Exception("Schema extraction must never execute this constructor");
    }
    public BicepValue<string> Name
    {
        get { return _name; }
    }
    public BicepValue<string> Status
    {
        get { return _status; }
    }
    protected override void DefineProvisionableProperties()
    {
        _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isRequired: true, defaultValue: "default");
        _status = DefineProperty<string>(nameof(Status), new string[] { "properties", "status" }, isOutput: true);
    }
    public static readonly string V2026_01_01 = "2026-01-01";
}
'@ | Set-Content -LiteralPath (Join-Path $generated 'ExampleResource.cs')
        @'
public partial class ExampleResource
{
    public BicepValue<string> DisplayName
    {
        get { return _displayName; }
        set { _displayName.Assign(value); }
    }
    public ProvisionableResource Scope
    {
        get { return _scope; }
        set { _scope.Assign(value); }
    }
    partial void DefineAdditionalProperties()
    {
        _displayName = DefineProperty<string>(nameof(DisplayName), new string[] { "properties", "displayName" });
        _scope = DefineResource<ProvisionableResource>(nameof(Scope), new string[] { "scope" });
    }
}
'@ | Set-Content -LiteralPath (Join-Path $custom 'ExampleResource.cs')
    }

    It 'parses generated and custom source, setters, singleton defaults, and scope metadata without executing source' {
        $schema = & $SchemaHelper -PackagePath $PackagePath -Format Json | ConvertFrom-Json
        $schema.ResourceCount | Should -Be 1
        $resource = $schema.Resources[0]
        $resource.ResourceType | Should -Be 'Microsoft.Example/resources'
        $resource.DefaultApiVersion | Should -Be '2026-01-01'
        $resource.ApiVersions | Should -Contain '2026-01-01'
        $resource.AdditionalSourcePaths.Count | Should -Be 1

        $name = $resource.Properties | Where-Object Name -EQ 'Name'
        $name.IsRequired | Should -BeTrue
        $name.IsSettable | Should -BeFalse
        $name.DefaultValue | Should -Be '"default"'

        $displayName = $resource.Properties | Where-Object Name -EQ 'DisplayName'
        $displayName.IsSettable | Should -BeTrue
        $displayName.SerializedPath -join '.' | Should -Be 'properties.displayName'

        $scope = $resource.Properties | Where-Object Name -EQ 'Scope'
        $scope.IsMetadata | Should -BeTrue
        $scope.Kind | Should -Be 'Resource'
    }

    It 'retains the Markdown inventory and public-setter columns' {
        $schema = & $SchemaHelper -PackagePath $PackagePath -Format Markdown
        $schema | Should -Match '# Provisioning Resource Schema'
        $schema | Should -Match 'Microsoft\.Example/resources'
        $schema | Should -Match '\| Property \| Path \| Kind \| Type \| Required \| Settable \| Default \| Metadata \|'
        $schema | Should -Match '\| `Name` \| `name` \| Property \| `BicepValue<string>` \| True \| False \| `"default"` \| False \|'
    }
}
