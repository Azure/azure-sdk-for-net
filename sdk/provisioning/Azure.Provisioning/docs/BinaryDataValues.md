# BinaryData provisioning values

Azure.Provisioning resource models use `BicepValue<BinaryData>` for free-form
properties whose schema is not known when the SDK is generated. The
`BinaryData.MediaType` determines whether the value is compiled as JSON or as
an explicitly supplied Bicep expression.

## Supported media types

| `BinaryData.MediaType` | Interpretation | Generated Bicep |
| --- | --- | --- |
| `null` | JSON | `json('<serialized JSON>')` |
| `application/json` | JSON | `json('<serialized JSON>')` |
| `application/json; charset=utf-8` | JSON | `json('<serialized JSON>')` |
| `text/vnd.microsoft.bicep` | Raw UTF-8 Bicep expression | The supplied expression |
| `text/vnd.microsoft.bicep; charset=utf-8` | Raw UTF-8 Bicep expression | The supplied expression |

Media types and the optional `charset=utf-8` parameter are
case-insensitive. Other media types and parameters are rejected.

`text/vnd.microsoft.bicep` is an Azure.Provisioning convention, not an
official or IANA-registered Bicep media type.

## JSON values

Use `BinaryData.FromObjectAsJson` for CLR values. Azure.Provisioning validates
the serialized JSON and emits it through Bicep's `json` function.

```C# Snippet:BinaryDataJsonProvisioningValue
ArmApplication application = new("application")
{
    Name = "sample-application",
    Kind = "ServiceCatalog",
    Location = AzureLocation.WestUS2,
    Parameters = BinaryData.FromObjectAsJson(new
    {
        enabled = true,
        threshold = 3,
        items = new[] { "a", "b" }
    })
};

Infrastructure infrastructure = new();
infrastructure.Add(application);
string bicep = infrastructure.Build().Compile().Single().Value;
```

Use `BinaryData.FromString` only when the string already contains a complete
JSON document:

```C#
application.Parameters = BinaryData.FromString(
    """{"enabled":true,"threshold":3}""");
```

A CLR string and a serialized JSON string are different:

```C#
// JSON string value: "enabled"
BinaryData jsonString = BinaryData.FromObjectAsJson("enabled");

// JSON object value: { "enabled": true }
BinaryData jsonObject = BinaryData.FromString("""{"enabled":true}""");
```

Invalid JSON throws `JsonException` when the value is compiled. It does not
fall back to raw Bicep.

## Raw Bicep expressions

Tag UTF-8 source with `text/vnd.microsoft.bicep` when a free-form property
must contain a Bicep expression that cannot be represented as JSON.

```C# Snippet:BinaryDataRawBicepProvisioningValue
BinaryData rawBicep = BinaryData.FromString(
    "union({ enabled: true }, { retries: 3 })",
    "text/vnd.microsoft.bicep");

ArmApplication application = new("application")
{
    Name = "sample-application",
    Kind = "ServiceCatalog",
    Location = AzureLocation.WestUS2,
    Parameters = rawBicep
};

Infrastructure infrastructure = new();
infrastructure.Add(application);
string bicep = infrastructure.Build().Compile().Single().Value;
```

Raw Bicep is emitted verbatim. Azure.Provisioning verifies that the bytes are
valid UTF-8, but it does not parse, type-check, escape, or rewrite the
expression. Treat the expression as source code:

- Use only trusted input.
- Ensure referenced symbols exist in the generated template.
- Expect syntax and type errors to be reported by the Bicep compiler.
- Remember that valid resource references participate in normal Bicep
  dependency inference.

## Base64-formatted properties

Some generated `BicepValue<BinaryData>` properties declare their wire format
as `base64`. Those properties always encode the original bytes as Base64.
Their generated format takes precedence over `BinaryData.MediaType`.

## Structured object expressions

JSON cannot contain provisioning expressions. When a free-form object mixes
literal values with parameters, variables, or resource references, construct a
`BicepDictionary<object>` and explicitly compile it for the
`BicepValue<BinaryData>` property:

```C# Snippet:BinaryDataBicepDictionaryProvisioningValue
ProvisioningParameter featureFlag = new("featureFlag", typeof(bool));
BicepDictionary<object> parameters = new()
{
    ["enabled"] = featureFlag,
    ["retryCount"] = 3,
    ["environment"] = "production"
};

ArmApplication application = new("application")
{
    Name = "sample-application",
    Kind = "ServiceCatalog",
    Location = AzureLocation.WestUS2,
    Parameters = parameters.Compile()
};

Infrastructure infrastructure = new();
infrastructure.Add(featureFlag);
infrastructure.Add(application);
string bicep = infrastructure.Build().Compile().Single().Value;
```

This produces a native Bicep object expression rather than a serialized JSON
value, so nested expressions remain part of the generated Bicep syntax and
participate in normal dependency analysis.

Implicit conversions from heterogeneous `BicepDictionary` or `BicepList`
instances to `BicepValue<BinaryData>` are not provided. Call `Compile()`
explicitly to make the structured-expression behavior clear.
