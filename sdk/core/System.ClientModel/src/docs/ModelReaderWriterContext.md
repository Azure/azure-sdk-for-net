# ModelReaderWriterContext

## Overview

The ModelReaderWriterContext class provides type information necessary for ModelReaderWriter to work with AOT (Ahead of Time) compilation.
It also provides a performance boost vs using ModelReaderWriter without the context class.  It is considered
an advanced scenario and is not necessary to work with ModelReaderWriter. However, if you are using AOT compilation or need to optimize
performance for reading and writing large models, using a ModelReaderWriterContext can be beneficial.

To take advantage of this you can use the new overloads to ModelReaderWriter.Read and ModelReaderWriter.Write
that take in a ModelReaderWriterContext by passing in a new automatically generated class in your assembly.

```C#
namespace MyProject;

ModelReaderWriter.Write<MyPersistableType>(myObject, ModelReaderWriterOptions.Json, MyProjectContext.Default);
```

## SourceGeneration

System.ClientModel provides a source generator that will automatically create a ModelReaderWriterContext for your assembly.
It will also create all necessary ModelReaderWriterTypeBuilder classes for any types in your assembly that
implement IPersistableModel<T> as well as any `T` used in direct calls to `ModelReaderWriter.Read<T>()` and `ModelReaderWriter.Write<T>()`.

### Context class

The default name of the context class that is created is `[AssemblyName]Context.Default`.
You can change the name and visibility of this by adding a partial class inheriting from ModelReaderWriterContext.

```C#
public partial class MyContext : ModelReaderWriterContext { }
```

Now you can reference it with `MyContext.Default`.

- **Note:** only 1 context class can be created per assembly.
 If you have multiple partial classes inheriting from ModelReaderWriterContext you will get a compilation error SCM0001.
- **Note:** If the partial keyword is left off you will get a compilation error SCM0002.

### Supported Collection Types

The source generator will not automatically make type builders for all collection types.
The list of supported collection types includes:
- `List<T>`
- `Dictionary<string, TValue>`
- `ReadOnlyMemory<T>`
- `T[]`
- `T[][]` (jagged arrays)
- `T[,]` (multidimensional arrays)

### Supported Invocations

The source generator will find all invocations to ModelReaderWriter.Read and ModelReaderWriter.Write in your assembly.
For each of those it will attempt to determine what type was passed in.  For simple invocations this will work but in some cases
it is unable to determine the concrete type.  In these cases you can add an attribute to your partial context
class to instruct the generator to include a type builder for that specific type.

```C#
[ModelReaderWriterBuildable(typeof(List<MyPersistableModel>))]
public partial class MyContext : ModelReaderWriterContext
{
}
```

- **Note:** only works for the supported collection types listed above.
- **Note:** This attribute can only be applied to classes that inherit from ModelReaderWriterContext.
If it is applied to other types it will be ignored and a compiler warning SCM0003 will be generated.

### Custom Type Builders

If you're using a collection type that isn't automatically supported, implement a custom ModelReaderWriterTypeBuilder by providing an implementation to the AddAdditionalFactories partial method in your context class:

```C#
   public partial class YourContext : ModelReaderWriterContext
   {
       partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
       {
           factories.Add(typeof(CustomCollection<MyType>), () => new CustomCollection_MyType_Builder());
       }
       
       private class CustomCollection_MyType_Builder : ModelReaderWriterTypeBuilder
       {
           protected override Type BuilderType => typeof(CustomCollection<MyType>);

           protected override Type ItemType => typeof(MyType);

           protected override object CreateInstance() => new CustomCollection<MyType>();

           protected override void AddItem(object collection, object? item)
               => ((CustomCollection<MyType>)collection).Add((MyType)item!);
       }
   }
```

## No ModelReaderWriterTypeBuilder found

If you encounter an error message like "No ModelReaderWriterTypeBuilder found for [Name]", it means that ModelReaderWriter attempted to read or write
 a type for which no appropriate ModelReaderWriterTypeBuilder exists in your context.

Troubleshooting Steps

1. Ensure you have the System.ClientModel.SourceGeneration analyzers installed
2. If the type is one of the [supported collections](#supported-collection-types) then add the [ModelReaderWriterBuildable attribute](#supported-invocations) for your missing type.
3. If the type is not one of the [supported collections](#supported-collection-types) then add a [custom type builder](#custom-type-builders) for your missing type.

## Additional Examples

You can find examples of type builder implementations for many collection types in [this folder](../../tests/ModelReaderWriterTests/Models/AvailabilitySetDatas).
These examples cover a wide range of collection types and can serve as templates for your own implementations.
