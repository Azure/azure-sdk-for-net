# Customizing the generated code

## Before You Customize

Before customizing generated code, consider whether your change should be made in TypeSpec (`client.tsp`) instead. TypeSpec customizations allow you to apply changes to multiple languages at once, are more discoverable for other languages, and live right near the spec bringing us more to a single source of truth. See the [TypeSpec Client Customizations Reference](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/knowledge/customizing-client-tsp.md) for available decorators like `@@clientName`, `@@access`, etc.

Use C# code customizations (partial classes) when TypeSpec cannot express the behavior you need.

## Make a model internal

Define a class with the same namespace and name as generated model and use the desired accessibility.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    internal partial class Model { }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
-    public partial class Model { }
+    internal partial class Model { }
}
```

</details>

## Rename a model class

Define a class with a desired name and mark it with `[CodeGenType("OriginalName")]`

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (NewModelClassName.cs)**

```C#
namespace Azure.Service.Models
{
    [CodeGenType("Model")]
    public partial class NewModelClassName { }
}
```

**Generated code after (Generated/Models/NewModelClassName.cs):**

```diff
namespace Azure.Service.Models
{
-    public partial class Model { }
+    public partial class NewModelClassName { }
}
```

</details>

## Change a model or client namespace

Define a class with a desired namespace and mark it with `[CodeGenType("OriginalName")]`.

The same works for a client, if marked with `[CodeGenType("ClientName")]`.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (NewModelClassName.cs)**

```C#
namespace Azure.Service
{
    [CodeGenType("Model")]
    public partial class Model { }
}
```

**Generated code after (Generated/Models/NewModelClassName.cs):**

```diff
- namespace Azure.Service.Models
+ namespace Azure.Service
{
    public partial class Model { }
}
```

</details>

## Make model property internal

Define a class with a property matching a generated property name but with desired accessibility.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        internal string Property { get; }
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
    }
}
```

</details>

## Rename a model property

Define a partial class with a new property name and mark it with `[CodeGenMember("OriginalName")]` attribute.

**NOTE:** you can also change a property to a field using this mapping.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        [CodeGenMember("Property")]
        public string RenamedProperty { get; }
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
+        // All original Property usages would reference a RenamedProperty
    }
}
```

</details>

## Change a model property type

:warning:

**NOTE: This is supported for a narrow set of cases where the underlying serialized type doesn't change**

Scenarios that would work:

1. String <-> TimeSpan (both represented as string in JSON)
2. Float <-> Int (both are numbers)
3. String <-> Enums (both strings)
4. String -> Uri

Won't work:

1. String <-> Bool (different json type)
2. Changing model kinds

If you think you have a valid re-mapping scenario that's not supported file an issue.

:warning:

Define a property with different type than the generated one.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public DateTime Property { get; }
    }
}
```

**Generated code after (Generated/Models/Model.Serializer.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
+        // Serialization code now reads and writes DateTime value instead of string
    }
}
```

</details>

## Preserve raw Json value of a property

Use the [Change a model property type](#Change-a-model-property-type) approach to change property type to `JsonElement`.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public JsonElement Property { get; }
    }
}
```

**Generated code after (Generated/Models/Model.Serializer.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public string Property { get; }
+        // Serialization code now reads and writes JsonElement value instead of string
    }
}
```

</details>

## Changing member doc comment

Redefine a member in partial class with a new doc comment.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        /// Subpar doc comment
        public string Property { get; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        /// Great doc comment
        public string Property { get; }
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        /// Subpar doc comment
-        public string Property { get; }
    }
}
```

</details>

## Customize serialization/deserialization methods

Changing how a property serializes or deserializes is done by `CodeGenSerialization` attribute. This attribute can be applied to a class or struct with a property name to change the serialization/deserialization method of the property.

### Change the serialized name of a property

If you want to change the property name that serializes into the JSON or deserializes from the JSON, you could define your own partial class with the `CodeGenMemberSerialization` attribute.

<details>

For instance, we have a model class `Cat` with property `Name` and `Color`:

**Generated code before:**

```C#
// Generated/Models/Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        /* omit the ctors for brevity */
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
```

**Add customized model:**

```C#
// Cat.cs
namespace Azure.Service.Models
{
    [CodeGenSerialization(nameof(Name), "catName")] // add the property name, and the new serialized name
    public partial class Cat
    {
    }
}
```

**Generated code after:**

```diff
// Generated/Models/Cat.cs - no change

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
-           writer.WritePropertyName("name"u8);
+           writer.WritePropertyName("catName"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("color"u8);
            writer.WriteStringValue(Color);
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
            foreach (var property in element.EnumerateObject())
            {
-               if (property.NameEquals("name"u8))
+               if (property.NameEquals("catName"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color);
        }
    }
}
```

### Change the hierarchy of a property in the serialized JSON

If you want to change the layer of the property in the json, you can add all the elements in the json path of your property to the attribute using an array, the generator will generate the property into the JSON in the correct hierarchy.

**NOTE: Introducing extra layers in serialized JSON only works for MPG and HLC models, does not work for DPG models.**

For instance, we want to move `Name` property in the model `Cat` to make it serialized under property `properties` and rename to `catName`.

**Generated code before:**

```C#
// Generated/Models/Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        /* omit the ctors for brevity */
        public string Name { get; set; }
        public string Color { get; set; }
    }
}

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("color"u8);
            writer.WriteStringValue(Color);
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color);
        }
    }
}
```

**Add customized model:**

```C#
// Cat.cs
namespace Azure.Service.Models
{
    [CodeGenSerialization(nameof(Name), new string[] { "properties", "catName" })]
    public partial class Cat
    {
    }
}
```

**Generated code after:**

```diff
// Generated/Models/Cat.cs - no change

// Generated/Models/Model.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
-           writer.WritePropertyName("name"u8);
+           writer.WritePropertyName("properties"u8);
+           writer.WriteStartObject();
+           writer.WritePropertyName("catName"u8);
            writer.WriteStringValue(Name);
+           writer.WriteEndObject();
            writer.WritePropertyName("color"u8);
            writer.WriteStringValue(Color);
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
-               if (property.NameEquals("name"u8))
+               if (property.NameEquals("properties"u8))
+               {
+                   foreach (var property in element.EnumerateObject())
+                   {
+                       if (property.NameEquals("catName"u8))
                        {
                            meow = property.Value.GetString();
                            continue;
                        }
+                   }
+                   continue;
+               }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color);
        }
    }
}
```

</details>

### Change the implementation of serialization/deserialization method of a property

If you want to change the implementation of serialization/deserialization method of a property, you could define your own hook methods and assign them to the `CodeGenSerialization` attribute.

The custom serialization method for this property is assigned by the `SerializationValueHook` property of the `CodeGenSerialization` attribute, and the custom deserialization method for this property is assigned by the `DeserializationValueHook` property of the `CodeGenSerialization` attribute.

The `SerializationValueHook` and `DeserializationValueHook` here are hook method names, and these methods should have the signature as below:

```C#
// serialization hook and serialization value hook
[MethodImpl(MethodImplOptions.AggressiveInlining)]
internal void SerializationMethodHook(Utf8JsonWriter writer)
{
    // write your own serialization logic here
}

// deserialization hook for required property
[MethodImpl(MethodImplOptions.AggressiveInlining)]
internal static void DeserializeSizeProperty(JsonProperty property, ref TypeOfTheProperty name)
{
    // write your own deserialization logic here
}
// deserialization hook for optional property
[MethodImpl(MethodImplOptions.AggressiveInlining)]
internal static void DeserializeSizeProperty(JsonProperty property, ref Optional<TypeOfTheProperty> name)
{
    // write your own deserialization logic here
}
```

Please use the `nameof` expression to avoid typo in the attribute. Also you could leave both the serialization value hook unassigned if you do not want to change the serialization logic, similar you could leave deserialization hook unassigned if you do not want to change the deserialization logic.

The `[MethodImpl(MethodImplOptions.AggressiveInlining)]` attribute is recommended for your hook methods to get optimized performance.

Please note that the generator will not check the signature of the hook methods you assigned to the attribute, therefore if the signature is not compatible, the generated library might not compile.

<details>

For instance, we have a model class `Cat` with property `Name` and `Color`, and we would like to change the way how `Name` property is serialized and deserialized.

**Generated code before:**

```C#
// Generated/Models/Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        /* omit the ctors for brevity */
        public string Name { get; set; }
        public string Color { get; set; }
    }
}

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("color"u8);
            writer.WriteStringValue(Color);
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color);
        }
    }
}
```

**Add customized model:**

```C#
// Cat.cs
namespace Azure.Service.Models
{
    [CodeGenSerialization(nameof(Name), SerializationValueHook = nameof(SerializeNameValue), DeserializationValue = nameof(DeserializeNameValue))]
    public partial class Cat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeNameValue(Utf8JsonWriter writer)
        {
            // this is the logic we would like to have for the value serialization
            writer.WriteStringValue(Name.ToUpper());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void DeserializeNameValue(JsonProperty property, ref string name) // the type here is string since name is required
        {
            // this is the logic we would like to have for the value deserialization
            name = property.Value.GetString().ToLower();
        }
    }
}
```

**Generated code after:**

```diff
// Generated/Models/Cat.cs - no change

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
-           writer.WriteStringValue(Name);
+           SerializeNameValue(writer);
            if (Optional.IsDefined(Color))
            {
                writer.WritePropertyName("color"u8);
                writer.WriteStringValue(Color);
            }
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
-                   meow = property.Value.GetString();
+                   DeserializeNameValue(property, ref name);
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color, size);
        }
    }
}
```

</details>

### Add a new property to the model with serialization/deserialization

If you want to add a new property to the model and also add the property into the serialization/deserialization methods, you could also use the `CodeGenSerialization` attribute to change its default serialized name, and serialization/deserialization methods.

<details>

**Generated code before:**

```C#
// Generated/Models/Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        /* omit the ctors for brevity */
        public string Name { get; set; }
        public string Color { get; set; }
    }
}

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("color"u8);
            writer.WriteStringValue(Color);
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    color = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(name, color);
        }
    }
}
```

**Add customized model:**

```C#
[CodeGenSerialization(nameof(Size), "size")]
public partial class Cat
{
    public int? Size { get; set; }
}
```

**Generated code after:**

```diff
// Generated/Models/Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        /* omit other ctors for brevity */
-       internal Cat(string name, string color)
+       internal Cat(string name, string color, int? size)
        {
            Name = name;
            Color = color;
+           Size = size;
        }

        public string Name { get; set; }
        public string Color { get; set; }
    }
}

// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Color))
            {
                writer.WritePropertyName("color"u8);
                writer.WriteStringValue(Color);
            }
+           if (Optional.IsDefined(Size))
+           {
+               writer.WritePropertyName("size"u8);
+               writer.WriteNumberValue(Size);
+           }
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            Optional<string> color = default;
+           Optional<int> size = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    meow = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("color"u8))
                {
                    meow = property.Value.GetString();
                    continue;
                }
+               if (property.NameEquals("size"u8))
+               {
+                   size = property.Value.GetInt32();
+                   continue;
+               }
            }
            return new Cat(name);
        }
    }
}
```

You could also add the `CodeGenSerialization` attribute to the property to have your own serialization/deserialization logic of the new property. You might have to do this if the type of your new property is an object type or any type that our generator does not natively support.

**NOTE: Adding property to serialization/deserialization methods currently only works for DPG.**

</details>

#### Replace the entire serialization/deserialization method

If you want to replace the entire serialization/deserialization method, please use the [Replace any generated member](#replace-any-generated-member) approach to replace serialization/deserialization method with a custom implementation.

<details>

**Generated code before:**

```C#
// Generated/Models/Cat.Serialization.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(Color))
            {
                writer.WritePropertyName("color"u8);
                writer.WriteStringValue(Color);
            }
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            string color = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("color"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    color = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
            }
            return new Cat(id, name);
        }
    }
}
```

**Add customized model:**

```C#
// Cat.cs
namespace Azure.Service.Models
{
    public partial class Cat
    {
        // currently we have to use a full name to ensure this could be replaced
        void global:Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            // WORKAROUND: server never needs color, remove it in the customization code
            writer.WriteEndObject();
        }

        internal static Cat DeserializeCat(JsonElement element)
        {
            string color = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
            }
            // WORKAROUND: server never sends color, default to black
            color = "black";
            return new Cat(name, color);
        }
    }
}
```

**Generated code after:**

Generated code won't contain the `IUtf8JsonSerializable.Write` or `DeserializeCat` method and the custom one would be used for deserialization.

</details>

## Renaming an enum

Redefine an enum with a new name and all the members mark it with `[CodeGenType("OriginEnumName")]`.

**NOTE: because enums can't be partial all values have to be copied**

<details>

**Generated code before (Generated/Models/Colors.cs):**

```C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        Blue
    }
}
```

**Add customized model (WallColors.cs)**

```C#
namespace Azure.Service.Models
{
    [CodeGenType("Colors")]
    public enum WallColors
    {
        Red,
        Green,
        Blue
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
-namespace Azure.Service.Models
-{
-    public enum Colors
-    {
-        Red,
-        Green,
-        Blue
-    }
-}
+// Serialization code uses the new WallColors type name
```

</details>

### Renaming an enum member

Redefine an enum with the same name and all the members, mark renamed member with `[CodeGenMember("OriginEnumMemberName")]`.

**NOTE: because enums can't be partial all values have to be copied but only the ones being renamed should be marked with an attributes**

<details>

**Generated code before (Generated/Models/Colors.cs):**

```C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        Blue
    }
}
```

**Add customized model (Colors.cs)**

```C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green,
        [CodeGenMember("Blue")]
        SkyBlue
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
-namespace Azure.Service.Models
-{
-    public enum Colors
-    {
-        Red,
-        Green,
-        Blue
-    }
-}
+// Serialization code uses the new SkyBlue member name
```

</details>

## Changing an enum to an extensible enum

Redefine an enum into an extensible enum by creating an empty struct with the same name as original enum.

<details>

**Generated code before (Generated/Models/Colors.cs):**

```C#
namespace Azure.Service.Models
{
    public enum Colors
    {
        Red,
        Green
    }
}
```

**Add customized model (Colors.cs)**

```C#
namespace Azure.Service.Models
{
    public partial struct Colors
    {
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
-    public enum Colors
-    {
-        Red,
-        Green
-    }
+    public readonly partial struct Colors : IEquatable<Colors>
+    {
+        private readonly string _value;

+        public Colors(string value)
+        {
+            _value = value ?? throw new ArgumentNullException(nameof(value));
+        }

+        private const string Red = "red";
+        private const string Green = "green";

+        public static Colors Red { get; } = new Colors(Red);
+        public static Colors Green { get; } = new Colors(Green);
+        public static bool operator ==(Colors left, Colors right) => left.Equals(right);
         ...
}
```

</details>

## Make a client internal

Define a class with the same namespace and name as generated client and use the desired accessibility.

<details>

**Generated code before (Generated/Operations/ServiceClient.cs):**

```C#
namespace Azure.Service.Operations
{
    public partial class ServiceClient { }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Operations
{
    internal partial class ServiceClient { }
}
```

**Generated code after (Generated/Operations/ServiceClient.cs):**

```diff
namespace Azure.Service.Operations
{
-    public partial class ServiceClient { }
+    internal partial class ServiceClient { }
}
```

</details>

## Rename a client

Define a partial client class with a new name and mark it with `[CodeGenType("OriginalName")]`

<details>

**Generated code before (Generated/Operations/ServiceClient.cs):**

```C#
namespace Azure.Service.Operations
{
    public partial class ServiceClient {}
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Operations
{
    [CodeGenType("ServiceClient")]
    public partial class TableClient { }
}
```

**Generated code after (Generated/Operations/ServiceClient.cs):**

```diff
namespace Azure.Service.Operations
{
-    public partial class ServiceClient { }
+    public partial class TableClient { }
}
```

</details>

## Replace any generated member

Works for model and client properties, methods, constructors etc.

Define a partial class with member with the same name and for methods same parameters.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public Model()
        {
            Property = "a";
        }

        public string Property { get; set; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        internal Model()
        {
            Property = "b";
        }
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public Model()
-        {
-            Property = "a";
-        }
    }
}
```

</details>

## Remove any generated member

Works for model and client properties, methods, constructors etc.

Define a partial class with `[CodeGenSuppress("NameOfMember", typeof(Parameter1Type), typeof(Parameter2Type))]` attribute.

<details>

**Generated code before (Generated/Models/Model.cs):**

```C#
namespace Azure.Service.Models
{
    public partial class Model
    {
        public Model()
        {
            Property = "a";
        }

        public Model(string property)
        {
            Property = property;
        }

        public string Property { get; set; }
    }
}
```

**Add customized model (Model.cs)**

```C#
namespace Azure.Service.Models
{
    [CodeGenSuppress("Model", typeof(string))]
    public partial class Model
    {
    }
}
```

**Generated code after (Generated/Models/Model.cs):**

```diff
namespace Azure.Service.Models
{
    public partial class Model
    {
-        public Model(string property)
-        {
-            Property = property;
-        }
    }
}
```

</details>

## Extending a model with additional constructors

<details>

As with most customization, you can define a partial class for Models and extend them with methods and constructors.

**Generated code before (Generated/Models/Model.cs):**

```csharp
namespace Azure.Service.Models
{
    public partial class Model { }
}
```

**Add customized model (Model.cs)**

```csharp
namespace Azure.Service.Models
{
    public partial class Model {
        public Model(int x)
        {
        }
    }
}
```

</details>
