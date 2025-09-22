# JsonPatch

This is a new experimental type for applying JSON patches to a model that includes this as a property
or for dealing with raw UTF8 JSON directly.  The examples in this document show using outside
of being attached to a model for simplicity.

There are 5 main APIs for library users, `Set`, `Append`, `Get`, `Remove`, `SetNull`.  Each of these have overloads for different
value types to get in and out of the JsonPatch object.

All of these APIs take in `ReadOnlySpan<byte>` which should be UTF8 representation of a single target JSON Path following [RFC 9535](https://www.rfc-editor.org/rfc/rfc9535).
Even if a filter selector results in single target they are currently not supported such as `$.x.y[?@.name='foo']` where the array at y only contains one element with the name foo.

This type is intended to follow [RFC 6902](https://www.rfc-editor.org/rfc/rfc6902) although currently does not have Move, Copy, or Test implemented.
The default `ToString` implementation will print in RFC 6902 format, but will take an
optional format string to print in other formats in the future.  The only other format currently supported is `J` which will print the current model state
after applying the patches in RFC 8259 format.

## Library user APIs

### Set

```c#
JsonPatch jp = new();
jp.Set("$.x"u8, 5);
Console.WriteLine(jp); // [{"op":"add","path":"/x","value":5}]
Console.WriteLine(jp.ToString("J")); // {"x":5}
```

Set will project the json structure from the path so that users do not have to set each layer one by one

```c#
JsonPatch jp = new();
jp.Set("$.x.y[2].z"u8, 5);
Console.WriteLine(jp); // [{"op":"add","path":"/x","value":{"y":[null,null,{"z":5}]}}]
Console.WriteLine(jp.ToString("J")); // {"x":{"y":[null,null,{"z":5}]}}
```

The nulls are inserted to fill up to the index in the path if it doesn't exist yet.

You can also pass json structures yourself to Set if you already have a json byte array

```c#
JsonPatch jp = new();
jp.Set("$.x"u8, "{\"y\":[null,null,{\"z\":5}]}"u8);
Console.WriteLine(jp); // [{"op":"add","path":"/x","value":{"y":[null,null,{"z":5}]}}]
Console.WriteLine(jp.ToString("J")); // {"x":{"y":[null,null,{"z":5}]}}
```

### Append

Append will add to an existing array.

```c#
JsonPatch jp = new("[1,2,3]"u8.ToArray());
jp.Append("$"u8, 4);
Console.WriteLine(jp); // [{"op":"add","path":"/-","value":4}]
Console.WriteLine(jp.ToString("J")); // [1,2,3,4]
```

Append will also utilize json projection if the path doesn't exist yet.

```c#
JsonPatch jp = new();
jp.Append("$.x[1]", 1);
Console.WriteLine(jp); // [{"op":"add","path":"/x","value":[null,[1]]}]
Console.WriteLine(jp.ToString("J")); // {"x":[null,[1]]}
```

### Get

Get allows a user to pull information from the patches that have been inserted so far or from the
original json used to construct the JsonPatch.

Get allows you to pull primitive values as well as raw json.  For the primitive values it has an overload GetNullableValue to allow for things like int?.

```c#
JsonPatch jp = new("{\"x\":{\"y\":[null,null,{\"z\":5}]}}"u8.ToArray();
int value = jp.GetInt32("$.x.y[2].z"u8);
Console.WriteLine(value); // 5

BinaryData json = jp.GetJson("$.x.y");
Console.WriteLine(json); // [null,null,{"z":5}]
```

### Remove

Remove deletes a path from the payload which is distinct from setting something to null.

```c#
JsonPatch jp = new("{\"x\":{\"y\":[null,null,{\"z\":5}]}}"u8.ToArray();
jp.Remove("$.x.y[1]"u8);
Console.WriteLine(jp); // [{"op":"remove","path","/x/y/1"}]
Console.WriteLine(jp.ToString("J")); // {"x":{"y":[null,{"z":5}]}}
```

### SetNull

Sets explicit null at a specific json path.  The reason this is separate from Set is in order to accept `null` we would need an
overload with object which introduces lots of failure cases where a library user might try to pass in a random object which
we cannot deal with generically.

```c#
JsonPatch jp = new("{\"x\":{\"y\":[null,null,{\"z\":5}]}}"u8.ToArray();
jp.SetNull("$.x.y[2]"u8);
Console.WriteLine(jp); // [{"op":"replace","path":"/x/y/2","value":null}]
Console.WriteLine(jp.ToString("J")); // {"x":{"y":[null,null,null]}}
```
