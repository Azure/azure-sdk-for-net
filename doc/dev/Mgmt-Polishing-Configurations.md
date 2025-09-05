# Azure SDK for .NET - Management Plane SDK Polishing Configurations

To ensure the quality of the Azure SDK for .NET and adherence to the [naming conventions](https://github.com/Azure/azure-sdk-for-net/tree/main/doc/dev/Mgmt-Naming-Conventions.md), the CSharp CodeGen offers flexible configurations. These configurations allow for changes to the names of classes, methods, properties, and parameters, as well as the data types of properties and parameters.

# Guidelines for Data Type Changes

In the API specifications, many properties and parameters are defined as string types but have special formats in .NET. We need to correct these types in the Azure .NET SDK.

- The data type of a property should be `Guid` if its name is end of `Id` / `Guid` and value is really a uuid.

- The data type of a property should be `ResourceIdentifier` if its name is end of `Id` and value is really an ARM resource identifier.

- The data type of a property should be `ResourceType` if its name is `ResourceType` or end with `Type` and the value is really an ARM resource type (for example `Microsoft.xxxxx/xxxx`).

- The data type of a property should be `ETag` if its name is `etag` and the value is really a ETag. The property name should be `ETag` if possible.

- The data type of a property might be `AzureLocation` if its name is end with `location` / `locations` .

- (Optional) Pay attention to models similar to common type models and confirm whether they really can't be replaced by the common types from ResourceManager. 

# Guidelines for Operation Changes

- Put / patch operation, optional body parameter should be changed to required.

- All `ListOperations` and `GetOperationStatus` method should be removed because it's not useful in SDK and the SDK itself can show all the available operations in it through public APIs. 

# Configuration for Generating SDK from TypeSpec Specifications

For SDKs generated from TypeSpec specifications, we can update the `client.tsp` file located in the same folder as the `main.tsp` to address APIView review comments in the .NET SDK.

## Using the correct namespace

Before starting, please ensure that the correct namespace is used at the beginning of the `client.tsp` file, as shown below:

```tsp
using Microsoft.DeviceRegistry;

You can typically find the namespace in the `main.tsp` file.

## Rename models

To change the name of a model, use the [@clientname](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@Azure.ClientGenerator.Core.clientName) decorator as shown below:

```js
@@clientName(Asset, "DeviceRegistryAsset", "csharp");
```

This renames the name of model `Asset` to `DeviceRegistryAsset`.

## Rename properties

To change the name of a properties, use the [@clientname](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@Azure.ClientGenerator.Core.clientName) decorator as shown below:

```js
@@clientName(ExtendedLocation.type, "ExtendedLocationType", "csharp");
```

This changes the property name from `type` to `ExtendedLocationType`.

## Remove operations

To remove an operation, use the [@scope](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@Azure.ClientGenerator.Core.scope) decorator as shown below:

```js
@@scope(OperationStatus.get, "!csharp");
```

This removes the `OperationStatus.get` operation from the generated .NET SDK.

## Change data type of a property

To change the data type of a property, use the [@alternateType](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@Azure.ClientGenerator.Core.alternateType) decorator as shown below:

```js
@@alternateType(AssetProperties.documentationUri, url, "csharp");
@@alternateType(BillingContainer.etag, Azure.Core.eTag, "csharp");
```

The data type of `AssetProperties.documentationUri` has been updated to `url`, and the data type of `BillingContainer.etag` has been updated to `eTag`.

# Configurations for Generating SDK from OpenAPI Specifications

For SDKs generated from OpenAPI specifications, we can update the autorest.md file located in the src folder to address APIView review comments in the .NET SDK.

## Acronym mapping

A mechanism of acronym mapping is introduced in the generator to unify the casing of acronyms.

```yaml
acronym-mapping:
  Ip: IP
  Ips: IPs
```

The above configuration will search case sensitively in the public API of generated resources/collections/models, and replace the occurrences to the corresponding value to keep the casing of some acronyms unified across the generated SDK.

The `acronym-mapping` configuration also supports parameter name because in some cases the default logic to get the variable name form from a property name might be problematic. For instance, we usually could have a class like this:
```csharp
public partial class PublicIPAddress
{
    public PublicIPAddress()
    {
    }

    internal PublicIPAddress(IReadOnlyList<string> iPs)
    {
        IPs = iPs;
    }

    public IReadOnlyList<string> IPs { get; }
}
```
The default logic to create a variable name from a property name is usually lower case the first letter. But this introduces a weird combination of `iPs` in the internal constructor. To fix this, you could manually assign a variable version of the replaced key:
```yaml
acronym-mapping:
  Ip: IP
  Ips: IPs|ips
```
and after applying this configuration and regenerating, you should see the following differences:
```diff
public partial class PublicIPAddress
{
    public PublicIPAddress()
    {
    }

-   internal PublicIPAddress(IReadOnlyList<string> iPs)
+   internal PublicIPAddress(IReadOnlyList<string> ips)
    {
        IPs = ips;
    }

    public IReadOnlyList<string> IPs { get; }
}
```

## Change format by name rules

This is a bulk update rule to change property's format by its name which this name demonstrates a specific type implicitly. This is a convenient configuration to replace using directive change the property format attribute.

```yaml
format-by-name-rules:
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
```

The key is the name of property, and the value is the data type.

The name match supports 3 patterns: full, start-with, and end-with. And it’s case sensitive compare. 
For example, in the above configuration, the `ETag` and `location` are full match, `*Uri` and `*Uris` are end-with match.

Here is list of the format we support:
| Format | Data type |
| :--- | :--- |
| arm-id | [ResourceIdentifier](https://docs.microsoft.com/dotnet/api/azure.core.resourceidentifier?view=azure-dotnet) |
| azure-location | [AzureLocation](https://docs.microsoft.com/dotnet/api/azure.core.azurelocation?view=azure-dotnet) |
| datetime | [DateTimeOffset](https://docs.microsoft.com/dotnet/api/system.datetimeoffset?view=net-6.0) |
| duration-constant | [TimeSpan](https://docs.microsoft.com/dotnet/api/system.timespan) |
| etag | [ETag](https://docs.microsoft.com/dotnet/api/azure.etag?view=azure-dotnet) |
| ip-address | [IPAddress](https://docs.microsoft.com/dotnet/api/system.net.ipaddress?view=net-6.0) |
| object | [Object](https://docs.microsoft.com/dotnet/api/system.object?view=net-6.0) |
| resource-type | [ResourceType](https://docs.microsoft.com/dotnet/api/azure.core.resourcetype?view=azure-dotnet) |
| content-type | [ContentType](https://docs.microsoft.com/dotnet/api/azure.core.contenttype?view=azure-dotnet) |
| uri | [Uri](https://docs.microsoft.com/dotnet/api/system.uri?view=net-6.0) |
| uuid | [Guid](https://docs.microsoft.com/dotnet/api/system.guid?view=net-6.0) |

## Rename mapping

To rename an element in the generated SDK, like a type name, a property name, you could do that by writing `directive`s which autorest supports. You could refer [this document](https://github.com/Azure/autorest/blob/main/docs/generate/directives.md) for more details and usages.

But this configuration provides a simpler syntax for you to change the name of a type or a property.

This configuration also allows you to assign a custom type format if it is a property. For valid format values, please refer to the [change format by name rules](#change-format-by-name-rules) section.

### Rename a type

To rename a type (models and enumerations included), you could just use this syntax:
```yaml
rename-mapping:
  OriginalName: NewName
```
where the `OriginalName` is the original name of this model in the swagger. **Please be sure the name is its original swagger name**, because our generator will dynamically change names of some models from their context and roles inside the SDK. About how to get their original name of a model, please refer to [`How to get original name` section](#how-to-get-original-name).

After applying this configuration, you will see the following changes:
```diff
-public partial class OriginalName
+public partial class NewName
{
    /* other things inside the class */
}
```

### Rename a property in a class

To rename a property in a class, you could just use this syntax:
```yaml
rename-mapping:
  Model.oldProperty: NewProperty
```
where the `Model` is the original name of this model in the **swagger**, and the `oldProperty` is its original name of this property in the **swagger**. About how to get their original name of a property in model, please refer to [`How to get original name` section](#how-to-get-original-name).

After applying this configuration, you will see the following changes:
```diff
public partial class Model
{
    /* other things inside the class */

-    public string OldProperty { get; set; }
+    public string NewProperty { get; set; }

    /* other things inside the class */
}
```

### Change the format of a property

To assign a new format to a property, you could use this syntax:
```yaml
rename-mapping:
  Model.oldProperty: NewProperty|resource-type
```
This will rename this property to its new name, and change its format to `resource-type`:
```diff
public partial class Model
{
    /* other things inside the class */

-    public string OldProperty { get; set; }
+    public ResourceType? NewProperty { get; set; }

    /* other things inside the class */
}
```

If only the type of this property needs change, you could omit its new name, like
```yaml
rename-mapping:
  Model.oldProperty: -|resource-type
```
Please note that the dash and slash `-|` here are mandatory as a placeholder for the property name. The generator uses this symbol to separate the part for property name and its format.

About how to get their original name of a property in model, please refer to [`How to get original name` section](#how-to-get-original-name).

### Rename an enumeration value in an enumeration type

The generator regards the enumeration values as static properties, therefore you could use basically the same syntax as renaming a property to rename an enumeration value:
```yaml
rename-mapping:
  EnumType.enum_value: NewValue
```
where the `EnumType` is the original name of the enumeration type in the **swagger**, and `enum_value` is the original name of the enumeration value in the **swagger**. In case we have spaces or other special character, you might need to use quotes to enclosing the key in this mapping to ensure everything is good without compile errors. About how to get their original name of enum classes or enum values, please refer to [`How to get original name` section](#how-to-get-original-name).

### How to get original name

The `rename-mapping` configuration requires an "original name" as its key to rename an element (model name, property name, enum name, enum value name or format of a property) in the generated SDK. We have a debug flag to show the original names of those elements that support to rename.

Add the following configuration to your `autorest.md` and regenerate the SDK:
```yaml
mgmt-debug:
  show-serialized-names: true
```
You will see changes like this:
```diff
    /// <summary>
    /// A class representing the Image data model.
    /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
+   /// Serialized Name: Image
    /// </summary>
    public partial class ImageData : TrackedResourceData
```
or on a property:
```diff
    /// <summary>
    /// Specifies the storage settings for the virtual machine disks.
+   /// Serialized Name: Image.properties.storageProfile
    /// </summary>
    public ImageStorageProfile StorageProfile { get; set; }
```
or on an enum and its values:
```diff
    /// <summary>
    /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
+   /// Serialized Name: CachingTypes
    /// </summary>
    public enum CachingType
    {
        /// <summary>
        /// None
+       /// Serialized Name: CachingTypes.None
        /// </summary>
        None,
        /// <summary>
        /// ReadOnly
+       /// Serialized Name: CachingTypes.ReadOnly
        /// </summary>
        ReadOnly,
        /// <summary>
        /// ReadWrite
+       /// Serialized Name: CachingTypes.ReadWrite
        /// </summary>
        ReadWrite
    }
```
The content after `Serialized Name:` is the "original name" you would like to use as keys in `rename-mapping`.

Because this configuration adds quite a few extra content to the xml documents, it is not recommended to have this flag on an official SDK, be sure to remove the configuration and regenerate the SDK after all the rename work is done.

## Rename a parameter in an operation

There is a configuration that allows you to change the parameter names in an operation. For instance,
```yaml
parameter-rename-mapping:
  VirtualMachines_CreateOrUpdate:
    name: vmName
```
This configuration is a two-level dictionary. The key of the first level dictionary is the operation id you would like to change. In the above sample, the generator will change the parameter names that match in the operation with operation id `VirtualMachines_CreateOrUpdate`.

The value of the first level dictionary of this configuration is another dictionary, the original parameter name as its keys, and the desired parameter name as its value. In the above sample, the generator will rename the parameter `name` to `vmName` in the operation `VirtualMachines_CreateOrUpdate`.

If the parameter name specified does not exist in the specified operation, nothing will happen.

## Irregular Plural Words

The generator needs to convert word into its plural form or convert it back to its singular form in some circumstances. Our generator uses the [Humanizer](https://github.com/Humanizr/Humanizer) to do that. It has a dictionary of irregular words and if a word is not in the dictionary, it will use some built-in rules to convert the word.

We might have some new words that are not in the dictionary of Humanizer, and plurality rules applied on them might output wrong result, when this happens, you could use the `irregular-plural-words` configuration to add new word to the dictionary.

```yaml
irregular-plural-words:
  redis: redis
```
This configuration adds a new irregular word into the dictionary that the plural form of `redis` is still `redis`.

## Keep Plural Enums

According to the [.NET Framework Design Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations), we will use a singular type name for an enumeration unless its values are bit fields. This is also implemented with the help of [Humanizer](https://github.com/Humanizr/Humanizer) and sometimes the result might be strange. For example, `ContainerRegistryOS` will become `ContainerRegistryO`, which doesn't make sense and will lose its true meaning. In such cases, you can use `keep-plural-enums` configuration to suppress this conversion.

```yaml
keep-plural-enums:
  ContainerRegistryOS
```

## Suppress Abstract Base Class

The generator will add an `abstract` modifier to the base class when its has a discriminator. This could help the user understand that it is the derived classes that really work as the base class isn't allowed to be instantiated. However, we also provide the configuration to suppress this feature, you can use `suppress-abstract-base-class` with the corresponding class name to remove the `abstract` modifier. In particular, it should be noted that there is difference between the original model name in swagger and the name in the final generated SDK and this configuration requires the finalized model name in SDK.

**[Note]:** The class names specified under `suppress-abstract-base-class` are **original names**, not the names changed after applying renaming directives.

```yaml
suppress-abstract-base-class:
  DeliveryRuleAction
```
