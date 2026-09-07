---
title: 'Supported @@clientOption keys'
---

# Supported `@@clientOption` Keys

The Azure provisioning C# emitter recognizes `@@clientOption` keys that allow
spec authors to provide provisioning-specific resource metadata. These options
use the TCGC
[`@@clientOption`](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@clientOption)
decorator and are scoped to `"csharp"`.

## `provisioning-resource-name`

Customizes the C# class name of a generated provisioning resource projection.

Provisioning collapses detected resources that share the same resource model
and ARM resource type into one projection. Use this option when:

- one TypeSpec resource model backs multiple ARM resource types that need
  different generated class names; or
- resource entries collapsed into one projection provide different resource
  names and the model-based fallback name is not the intended public API.

**Target:** ARM resource model shared by the projections.

**Value:** A record mapping complete ARM resource type strings to desired C#
resource class names.

**Example:**

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "Provisioning resource names"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Provisioning resource names"
@@clientOption(PublishingPolicy, "provisioning-resource-name", #{
  `Microsoft.Web/sites/basicPublishingCredentialsPolicies`: "WebSiteFtpPublishingCredentialsPolicy",
  `Microsoft.Web/sites/slots/basicPublishingCredentialsPolicies`: "WebSiteSlotFtpPublishingCredentialsPolicy",
}, "csharp");
```

ARM resource type keys are matched case-insensitively. Keys and values must be
non-empty strings.

The override is applied after resource entries are grouped, so each mapping
names a complete projection rather than one resource path or singleton variant.
It changes only the generated provisioning class and file name. It does not
change:

- the ARM resource type;
- resource ID patterns or singleton names;
- parent relationships;
- operations or serialization;
- management SDK names.

Do not use this option to combine different ARM resource types or to compensate
for an incorrectly modeled resource identity.

## Suppressions

Until the client-option diagnostics recognize these provisioning-specific keys,
include suppressions for `client-option` and
`client-option-requires-scope`, as shown in the example.
