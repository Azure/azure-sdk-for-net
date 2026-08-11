# ARM provider schema analysis notes

This file tracks the manual root-cause analysis for libraries reviewed after generating the schema comparison reports. It starts from the libraries reviewed in the earlier validation PR and records how the current Azure/typespec-azure#4851 package compares.

## Current run compared with previous PR

The previous report covered 195 libraries. This run covers 217 libraries, including 194 overlapping libraries, 23 additional libraries, and 1 previous-only library (`Azure.ResourceManager.VirtualEnclaves`).

| Signal | Previous overlap | Current overlap | Delta |
| --- | ---: | ---: | ---: |
| Libraries processed | 194 | 194 | 0 |
| No requested-axis differences after path-variable normalization | 82 | 89 | +7 |
| Normalized resource ID pattern coverage differences | 46 | 47 | +1 |
| Raw resource ID differences removed by variable-name normalization | 4 | 4 | 0 |
| Resource type / hierarchy differences after normalization | 11 | 0 | -11 |
| Resource model differences after normalization | 5 | 4 | -1 |
| CRUD operation differences after normalization | 41 | 33 | -8 |
| List/action operation differences after normalization | 82 | 76 | -6 |
| Non-resource method differences after normalization | 51 | 44 | -7 |

## Reviewed libraries from previous validation

| Library | Previous status | Current delta | Current notes | Follow-up |
| --- | --- | --- | --- | --- |
| `Azure.ResourceManager.Advisor` | Good | normalized mismatches 0 -> 0 (0); list/action-diff libraries count axis 1 -> 1 (0) | Legacy and resolveArmResources remain nearly identical. resolveArmResources has one extra subscription-scoped list operation; still acceptable. | No issue needed. |
| `Azure.ResourceManager.Network` | resolveArmResources bug | normalized mismatches 140 -> 140 (0); list/action-diff libraries count axis 0 -> 0 (0) | Previously resolveArmResources returned 0 resources because Network uses converted legacy/custom resource bases. Current result is unchanged on resource coverage. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.DevTestLabs` | Resource ID reconstruction mismatch | normalized mismatches 0 -> 0 (0); list/action-diff libraries count axis 2 -> 1 (-1) | Previously raw mismatches were path variable names only after normalization, with remaining list/action and non-resource-method differences. Current result is materially unchanged. | No root-cause issue opened; lower priority than real resource identity mismatches. |
| `Azure.ResourceManager.Automation` | Spec modeling issue | normalized mismatches 9 -> 8 (-1); list/action-diff libraries count axis 5 -> 5 (0) | Previously resolveArmResources promoted operation/status-like reads into child resources. Current run improves normalized resource ID coverage by one mismatch, but the same class remains. | Covered by linter/design follow-up in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.NetApp` | Version/projection mismatch | normalized mismatches 9 -> 9 (0); list/action-diff libraries count axis 3 -> 3 (0) | Previously resolveArmResources detected resources outside the SDK-selected projection/version. Current normalized coverage is unchanged. | Tracked by Azure/typespec-azure#4800. |
| `Azure.ResourceManager.RecoveryServicesBackup` | Projection/scope mismatch plus operation-result modeling issue | normalized mismatches 9 -> 15 (+6); list/action-diff libraries count axis 1 -> 1 (0) | Previously operation-result/status endpoints and singleton paths caused differences. Current normalized coverage regresses and needs renewed review, though the remaining mismatches still appear related to the same projection/status/singleton classes. | Related to Azure/typespec-azure#4793 and Azure/typespec-azure#4802. |
| `Azure.ResourceManager.TrafficManager` | resolveArmResources bug | normalized mismatches 7 -> 7 (0); list/action-diff libraries count axis 0 -> 0 (0) | Previously resolveArmResources returned 0 resources due to converted legacy/custom resource bases. Current result is unchanged on resource coverage. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.HDInsight` | Projection/scope mismatch plus action/status modeling issue | normalized mismatches 6 -> 6 (0); list/action-diff libraries count axis 1 -> 2 (+1) | Previously resolveArmResources promoted C#-scoped-out action/status endpoints into resources. Current normalized coverage is unchanged. | Covered by Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Monitor.Workspaces` | Legacy/TCGC projection miss for removed-version resources | normalized mismatches 6 -> 6 (0); list/action-diff libraries count axis 1 -> 1 (0) | Previously resolveArmResources saw removed-version resources not present in C# projection. Current normalized coverage is unchanged. | Related to version-aware resolver/output design in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Resources.DeploymentStacks` | Scope representation mismatch | normalized mismatches 6 -> 6 (0); list/action-diff libraries count axis 0 -> 0 (0) | Previously resolveArmResources double-counted concrete scope expansions in addition to generic /{scope} resources. Current normalized coverage is unchanged. | Related to projection/language-aware filtering in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.SecurityCenter` | Mixed singleton/projection and unresolved legacy-only resources | normalized mismatches 6 -> 5 (-1); list/action-diff libraries count axis 12 -> 12 (0) | Previously singleton/default-name and same-version legacy-only resources differed. Current normalized coverage improves substantially but still has one remaining coverage mismatch plus method-axis differences. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793. |
| `Azure.ResourceManager.FrontDoor` | resolveArmResources bug | normalized mismatches 6 -> 6 (0); list/action-diff libraries count axis 0 -> 0 (0) | Previously resolveArmResources returned 0 resources due to converted legacy/custom resource bases. Current result is unchanged on resource coverage. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.ResilienceManagement` | Legacy/TCGC projection miss for removed-version resources | normalized mismatches 5 -> 5 (0); list/action-diff libraries count axis 4 -> 4 (0) | Previously resolveArmResources saw removed-version job child resources not present in C# projection. Current normalized coverage is unchanged. | Related to version-aware resolver/output design in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Sql` | Mixed legacy/projection/singleton issues | normalized mismatches 5 -> 5 (0); list/action-diff libraries count axis 12 -> 12 (0) | Previously legacy/custom resource handling, operation-result/private-endpoint modeling, and non-default singleton parsing caused differences. Current normalized coverage is unchanged and method-axis differences remain. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793; still needs separate follow-up. |
| `Azure.ResourceManager.Storage` | Singleton/projection and operation-classification issues | normalized mismatches 5 -> 5 (0); list/action-diff libraries count axis 2 -> 2 (0) | Previously singleton fixed names, out-of-version resources, and parent-action classification caused differences. Current normalized coverage is unchanged and method-axis differences remain. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793. |
| `Azure.ResourceManager.CosmosDB` | Mixed real misses and false/projection resources | normalized mismatches 5 -> 13 (+8); list/action-diff libraries count axis 2 -> 11 (+9) | Previously soft-deleted SQL resources and Cassandra backup/command endpoints differed. Current normalized coverage regresses sharply with many more resolve-only normalized resource IDs. | Needs separate follow-up before treating this as safe. |

## Triage summary

On the 194 overlapping libraries, normalized resource-ID coverage improved in 6, regressed in 8, and stayed unchanged in 180.

Largest improvements are listed in `arm-provider-schema-comparison-summary.md`. The largest current regressions by normalized coverage are `Azure.ResourceManager.Dns`, `Azure.ResourceManager.CosmosDB`, `Azure.ResourceManager.PrivateDns`, `Azure.ResourceManager.RecoveryServicesBackup`, and `Azure.ResourceManager.Quota`. These should be reviewed before using the new resolver as the default in the .NET management emitter.
