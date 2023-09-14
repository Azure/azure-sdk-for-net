# Azure.Variant

`Azure.Variant` is an implementation of a [tagged union](https://en.wikipedia.org/wiki/Tagged_union).  It can hold both reference and value types and can be used to avoid boxing .NET primitives.  The list of value types that Variant can hold without boxing is below.

<details>
<summary>Value types that `Variant` won't box</summary>

- `byte`
- `byte?`
- `sbyte`
- `sbyte?`
- `bool`
- `bool?`
- `char`
- `char?`
- `short`
- `short?`
- `int`
- `int?`
- `long`
- `long?`
- `ushort`
- `ushort?`
- `uint`
- `uint?`
- `ulong`
- `ulong?`
- `float`
- `float?`
- `double`
- `double?`
- `DateTimeOffset`
- `DateTimeOffset?`
- `DateTime`
- `DateTime?`
- Enums

</details>

In principle, `Variant` is similar to `object`, but without boxing as described above.  However, since it's not `object`, there are different APIs needed to achieve some of the same functionality, including:

- [Assigning a value to `Variant`](#assign-a-value-to-variant)
- [Retrieving the value a `Variant` holds](#get-the-value-from-variant)
- [Working with `null` and `Variant`](#handling-nulls)

## Assign a value to Variant

`Variant` has implicit cast operators for each of the primitives listed above.  This means you can assign a value of those types to `Variant` without casting, and a new `Variant` instance holding an unboxed copy of the value will be created.

```csharp
Variant v = 3L;

// v.Type is System.Int64
```

Since you can't have an implicit cast operator from `object`, for reference types, you must create a new instance of `Variant` and pass the value to the `Variant` constructor.

```csharp
MemoryStream s = new();
Variant v = new(s);

// v.Type is System.IO.MemoryStream
```

`Variant` will box value types that aren't on the list above, because it only stores 16 bytes and user-defined value types might exceed this size.  The one exception is for `enum`, which `Variant` can hold without boxing.  Because we can't add implicit cast operators for unknown enum types, you must call the `Create` method to create a `Variant` that holds an enum without boxing.

```csharp
Value v = Value.Create(System.Color.Blue);

// v.Type is System.Color
```

## Get the value from Variant

`Variant` has explicit cast operators for each of the primitives listed above, as well as to `string`.  That means you can assign a `Variant` holding one of these types to a variable of that type with a cast:

```csharp
Variant v = 3;
int i = (int)v;
```

If you don't know the type of the value that a `Variant` is holding, you can read that from the `Variant.Type` property.

```csharp
switch (v.Type)
{
    case Type s when s == typeof(string):
        Console.WriteLine($"string: {v}");
        break;
    case Type i when i == typeof(int):
        Console.WriteLine($"int: {(int)v}");
        break;
}
```

If you do know the type the `Variant` is holding, you can use the `As<T>` method to get its value as that type.

```csharp
MemoryStream s = new();
Variant v = new (s);

MemoryStream streamValue = v.As<MemoryStream>();
```

If you call `Variant.As<T>` and the `Variant` isn't holding the type that you ask for, it will throw an `InvalidCastException`.  To try to retrieve the value without risking an exception being thrown, you can use the `TryGetValue` method instead.

```csharp
if (v.TryGetValue(out string s))
{
    Console.WriteLine($"string: {s}");
}

if (v.TryGetValue(out int i))
{
    Console.WriteLine($"int: {i}");
}
```

## Handling nulls

`Variant` handles nullable primitives without boxing them for value types on the supported list above.  It also supports holding a reference type with a `null` value.  In either of these cases, the variant's `Type` property will return `null`.

Working with nulls with Variant can be a little tricky for the following reasons.  First, since a Variant instance holding `null` has a value (i.e., it's a Variant holding a `null`), any comparison to `null` will return false.  Second, assigning a `Variant` to an instance that holds `null` could require you to call the `Variant` constructor and cast the `null` some type to avoid ambiguous method resolution errors.  Because of this, there are some APIs that make working with `null` and `Variant` a little easier.

To check whether a Variant holds `null`, you can read the `IsNull` property:

```csharp
bool isNull = v.IsNull;
```

To assign the value a Variant holds to `null`, you can set it to `Variant.Null`:

```csharp
Variant v = Variant.IsNull;
```
