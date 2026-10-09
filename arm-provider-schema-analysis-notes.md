# ARM provider schema analysis notes

This file tracks the manual root-cause analysis for libraries reviewed after generating the schema comparison reports. This version reflects the TCGC-filtered `resolveArmResources` snapshots.

## Filtered run compared with unfiltered run

| Signal | Unfiltered overlap | Filtered overlap | Delta |
| --- | ---: | ---: | ---: |
| Libraries processed | 217 | 217 | 0 |
| No requested-axis differences after path-variable normalization | 103 | 142 | +39 |
| Normalized resource ID pattern coverage differences | 51 | 38 | -13 |
| Raw resource ID differences removed by variable-name normalization | 5 | 5 | 0 |
| Resource type / hierarchy differences after normalization | 0 | 0 | 0 |
| Resource model differences after normalization | 4 | 0 | -4 |
| CRUD operation differences after normalization | 33 | 19 | -14 |
| List/action operation differences after normalization | 83 | 59 | -24 |
| Non-resource method differences after normalization | 51 | 27 | -24 |

## Filtered run compared with previous validation PR

The previous report covered 195 libraries. This filtered run covers 217 libraries, including 194 overlapping libraries, 23 additional libraries, and 1 previous-only library (`Azure.ResourceManager.VirtualEnclaves`).

| Signal | Previous overlap | Current filtered overlap | Delta |
| --- | ---: | ---: | ---: |
| Libraries processed | 194 | 194 | 0 |
| No requested-axis differences after path-variable normalization | 82 | 126 | +44 |
| Normalized resource ID pattern coverage differences | 46 | 35 | -11 |
| Raw resource ID differences removed by variable-name normalization | 4 | 4 | 0 |
| Resource type / hierarchy differences after normalization | 11 | 0 | -11 |
| Resource model differences after normalization | 5 | 0 | -5 |
| CRUD operation differences after normalization | 41 | 19 | -22 |
| List/action operation differences after normalization | 82 | 54 | -28 |
| Non-resource method differences after normalization | 51 | 20 | -31 |

## Reviewed libraries from previous validation

| Library | Previous status | Filter impact | Current notes | Follow-up |
| --- | --- | --- | --- | --- |
| `Azure.ResourceManager.Advisor` | Good | old PR 0 -> unfiltered 0 -> filtered 0; filter delta 0 | Legacy and resolveArmResources remain nearly identical. resolveArmResources has one extra subscription-scoped list operation; still acceptable. | No issue needed. |
| `Azure.ResourceManager.Network` | resolveArmResources bug | old PR 140 -> unfiltered 140 -> filtered 140; filter delta 0 | Still unchanged by TCGC filtering because the resource models/methods exist in TCGC; the resolver still returns 0 resources for converted legacy/custom resource bases. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.DevTestLabs` | Resource ID reconstruction mismatch | old PR 0 -> unfiltered 0 -> filtered 0; filter delta 0 | Still mainly path-variable reconstruction noise plus method-axis differences. TCGC filtering does not materially change it. | No root-cause issue opened; lower priority than real resource identity mismatches. |
| `Azure.ResourceManager.Automation` | Spec modeling issue | old PR 9 -> unfiltered 8 -> filtered 8; filter delta 0 | The current PR package is one mismatch better than the old validation, but TCGC filtering itself does not change this library. The remaining differences are modeled action/status endpoints that exist in TCGC and can still appear as resources. | Covered by linter/design follow-up in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.NetApp` | Version/projection mismatch | old PR 9 -> unfiltered 9 -> filtered 0; filter delta -9 | TCGC filtering removes all previous normalized resource-ID coverage mismatches because the extra resources were not present in the TCGC code model. | Tracked by Azure/typespec-azure#4800. |
| `Azure.ResourceManager.RecoveryServicesBackup` | Projection/scope mismatch plus operation-result modeling issue | old PR 9 -> unfiltered 15 -> filtered 12; filter delta -3 | TCGC filtering partially removes version/projection noise, but this library remains worse than the previous validation and should be reviewed separately. | Related to Azure/typespec-azure#4793 and Azure/typespec-azure#4802. |
| `Azure.ResourceManager.TrafficManager` | resolveArmResources bug | old PR 7 -> unfiltered 7 -> filtered 7; filter delta 0 | Still unchanged by TCGC filtering because the missing resources are a resolver recognition issue, not version/projection noise. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.HDInsight` | Projection/scope mismatch plus action/status modeling issue | old PR 6 -> unfiltered 6 -> filtered 6; filter delta 0 | TCGC filtering does not change the normalized coverage count, so the remaining differences are not just absent-from-TCGC version/projection noise. | Covered by Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Monitor.Workspaces` | Legacy/TCGC projection miss for removed-version resources | old PR 6 -> unfiltered 6 -> filtered 0; filter delta -6 | TCGC filtering removes the previous resolve-only health model resources from the filtered validation output. | Related to version-aware resolver/output design in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Resources.DeploymentStacks` | Scope representation mismatch | old PR 6 -> unfiltered 6 -> filtered 6; filter delta 0 | TCGC filtering does not change the normalized coverage count; the generic-scope vs concrete-scope representation mismatch remains. | Related to projection/language-aware filtering in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.SecurityCenter` | Mixed singleton/projection and unresolved legacy-only resources | old PR 6 -> unfiltered 5 -> filtered 5; filter delta 0 | TCGC filtering does not materially change the remaining coverage mismatch count, so these are not just version/projection noise. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793. |
| `Azure.ResourceManager.FrontDoor` | resolveArmResources bug | old PR 6 -> unfiltered 6 -> filtered 6; filter delta 0 | Still unchanged by TCGC filtering because the missing resources are a resolver recognition issue, not version/projection noise. | Tracked by Azure/typespec-azure#4798. |
| `Azure.ResourceManager.ResilienceManagement` | Legacy/TCGC projection miss for removed-version resources | old PR 5 -> unfiltered 5 -> filtered 0; filter delta -5 | TCGC filtering removes the previous resolve-only job child resources from the filtered validation output. | Related to version-aware resolver/output design in Azure/typespec-azure#4793. |
| `Azure.ResourceManager.Sql` | Mixed legacy/projection/singleton issues | old PR 5 -> unfiltered 5 -> filtered 3; filter delta -2 | TCGC filtering removes one resolve-only projection/resource mismatch; same-path method and singleton issues remain. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793; still needs separate follow-up. |
| `Azure.ResourceManager.Storage` | Singleton/projection and operation-classification issues | old PR 5 -> unfiltered 5 -> filtered 4; filter delta -1 | TCGC filtering removes version/projection noise but leaves legacy-only singleton/operation-classification mismatches that exist in TCGC. | Related to Azure/typespec-azure#4802 and Azure/typespec-azure#4793. |
| `Azure.ResourceManager.CosmosDB` | Mixed real misses and false/projection resources | old PR 5 -> unfiltered 13 -> filtered 3; filter delta -10 | TCGC filtering removes the sharp unfiltered regression. The remaining coverage is slightly better than the older validation PR. | Still worth spot-reviewing Cassandra/soft-delete cases, but no longer looks like a broad regression after filtering. |

## Triage summary

On the 217 libraries overlapping with the unfiltered run, normalized resource-ID coverage improved in 20, regressed in 2, and stayed unchanged in 195.

Against the older validation PR #60620, 6 overlapping libraries still have worse normalized resource-ID coverage after filtering. The largest remaining coverage regressions are listed in `arm-provider-schema-comparison-summary.md`.

The filter removes major version/projection noise in CosmosDB, NetApp, Discovery, Monitor.Workspaces, ResilienceManagement, KeyVault, and several smaller libraries; RecoveryServicesBackup also improves but remains worse than the previous validation. Dns and PrivateDns remain regressions after filtering, so they should be reviewed as likely non-versioning issues. Remaining large mismatches are dominated by converted legacy/custom-resource handling such as Network/TrafficManager/FrontDoor.