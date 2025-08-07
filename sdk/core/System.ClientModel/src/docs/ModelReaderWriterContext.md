# ModelReaderWriterContext

## Overview

The [ModelReaderWriterContext](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/ModelReaderWriter/ModelReaderWriterContext.cs) class
 provides type information necessary for [ModelReaderWriter](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/ModelReaderWriter/ModelReaderWriter.cs)
 to work with [AOT (Ahead of Time)](https://learn.microsoft.com/dotnet/core/deploying/native-aot/) compilation.
It also provides a performance boost vs using ModelReaderWriter without the context class.  It is considered
an advanced scenario and is not necessary to work with ModelReaderWriter. However, if you are using AOT compilation or need to optimize
performance for reading and writing large models, using a ModelReaderWriterContext can be beneficial.

To take advantage of this you will need to create a public partial class that inherits from `ModelReaderWriterContext`.

```C# Snippet:ModelReaderWriterContext_Example
public partial class MyProjectContext : ModelReaderWriterContext { }
```

Then you can use the new overloads to `ModelReaderWriter.Read` and `ModelReaderWriter.Write`
that take in a ModelReaderWriterContext by passing in your new context class.

```C# Snippet:ModelReaderWriterContext_Usage
ModelReaderWriter.Write<MyPersistableModel>(myObject, ModelReaderWriterOptions.Json, MyProjectContext.Default);
```

## SourceGeneration

System.ClientModel provides a source generator that will automatically fill in your ModelReaderWriterContext for your assembly.
It will create all necessary [ModelReaderWriterTypeBuilder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/ModelReaderWriter/ModelReaderWriterTypeBuilder.cs)
classes for any types used in a [ModelReaderWriterBuildableAttribute](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/ModelReaderWriter/ModelReaderWriterBuildableAttribute.cs)
on your context class.

### Context class

You can set the name and visibility of the context class through your partial class inheriting from ModelReaderWriterContext.

```C# Snippet:ModelReaderWriterContext_ContextClass
public partial class MyContext : ModelReaderWriterContext { }
```

Now you can reference it with `MyContext.Default`.

- **Note:** Only 1 context class can be created per assembly.
 If you have multiple partial classes inheriting from ModelReaderWriterContext you will get a compilation error [SCM0001](https://aka.ms/system-clientmodel/diagnostics#scm0001).
- **Note:** If the `partial` keyword is left off you will get a compilation error [SCM0002](https://aka.ms/system-clientmodel/diagnostics#scm0002).

### Supported Collection Types

The source generator will not automatically make type builders for all collection types.
The list of supported collection types includes:
- `List<T>`
- `Dictionary<string, TValue>`
- `ReadOnlyMemory<T>`
- `T[]`
- `T[][]` (jagged arrays)
- `T[,]` (multidimensional arrays)

It will also support any nested combinations of the above types, such as `List<T[]>` or `Dictionary<string, List<T>>`

### ModelReaderWriterBuildableAttribute

The source generator will only build type builders for types that are used in a [ModelReaderWriterBuildableAttribute](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/src/ModelReaderWriter/ModelReaderWriterBuildableAttribute.cs).
The type used in the attribute must be a collection type that is supported by the source generator or a type that implements `IPersistableModel<T>`.

```C# Snippet:ModelReaderWriterContext_AttributeUsage
[ModelReaderWriterBuildable(typeof(List<MyPersistableModel>))]
[ModelReaderWriterBuildable(typeof(MyOtherPersistableModel))]
public partial class MyContext : ModelReaderWriterContext { }
```

- **Note:** only works for the supported collection types listed above.
- **Note:** This attribute can only be applied to classes that inherit from ModelReaderWriterContext.
If it is applied to other types it will be ignored and a compiler warning [SCM0003](https://aka.ms/system-clientmodel/diagnostics#scm0003) will be generated.

### Custom Type Builders

If you're using a collection type that isn't supported by the source generator you need to
implement a custom ModelReaderWriterTypeBuilder by providing an implementation to the partial method AddAdditionalFactories in your context class:

```C# Snippet:ModelReaderWriterContext_CustomBuilder
public partial class MyContext : ModelReaderWriterContext
{
    partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
    {
        factories.Add(typeof(CustomCollection<MyPersistableModel>), () => new CustomCollection_MyType_Builder());
    }

    private class CustomCollection_MyType_Builder : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(CustomCollection<MyPersistableModel>);

        protected override Type ItemType => typeof(MyPersistableModel);

        protected override object CreateInstance() => new CustomCollection<MyPersistableModel>();

        protected override void AddItem(object collection, object? item)
            => ((CustomCollection<MyPersistableModel>)collection).Add((MyPersistableModel)item!);
    }
}
```

## No ModelReaderWriterTypeBuilder found

If you encounter an error message like "No ModelReaderWriterTypeBuilder found for [Name]", it means that ModelReaderWriter attempted to read or write
 a type for which no appropriate ModelReaderWriterTypeBuilder exists in your context.

Troubleshooting Steps

1. Ensure you have the System.ClientModel.SourceGeneration analyzers installed. In general simply adding
a package reference to System.ClientModel will do this but you can verify in your project dependencies that you see the reference.
2. Ensure you have a public partial class that inherits from [ModelReaderWriterContext](#context-class).
3. If the type is one of the [supported collections](#supported-collection-types) then add the [ModelReaderWriterBuildableAttribute](#modelreaderwriterbuildableattribute) for your missing type.
4. If the type is not one of the [supported collections](#supported-collection-types) then add a [custom type builder](#custom-type-builders) for your missing type.

## Additional Examples

You can find examples of type builder implementations for many collection types in [this folder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/System.ClientModel/tests/ModelReaderWriterTests/Models/AvailabilitySetDatas).
These examples cover a wide range of collection types and can serve as templates for your own implementations.
