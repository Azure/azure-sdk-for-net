# List of diagnostics produced by ModelReaderWriterContextGenerator

## SCM0001

### Cause

The source generator found multiple partial classes inheriting from `ModelReaderWriterContext` in the same assembly.
Only one context class is allowed per assembly.

### How to fix violation

Remove the additional partial class definitions that inherit from `ModelReaderWriterContext`.

### Example of a violation

#### Description

The following code defines two partial classes inheriting from `ModelReaderWriterContext` in the same assembly, which causes a violation of SCM0001.

#### Code

```c#
public partial class MyContext : ModelReaderWriterContext { }
public partial class MyOtherContext : ModelReaderWriterContext { } // This will cause SCM0001
```

### Example of how to fix

#### Description

Remove either `MyContext` or `MyOtherContext` to ensure that only one partial class inherits from `ModelReaderWriterContext` in the assembly.

#### Code

```diff
public partial class MyContext : ModelReaderWriterContext { }
- public partial class MyOtherContext : ModelReaderWriterContext { } // This will cause SCM0001
```

## SCM0002

### Cause

The source generator found a class which inherits from `ModelReaderWriterContext` but does not have the `partial` keyword.  The `partial` keyword is necessary so that the source generator can provide part of the implementation automatically.

### How to fix violation

Add the `partial` keyword to the class inheriting from `ModelReaderWriterContext`.

### Example of a violation

#### Description

The following code defines a class inheriting from `ModelReaderWriterContext` which does not have the `partial` keyword and causes a violation of SCM0002.

#### Code

```c#
public class MyContext : ModelReaderWriterContext { } // This will cause SCM0002
```

### Example of how to fix

#### Description

Add the `partial` keyword to the class definition.

#### Code

```diff
- public class MyContext: ModelReaderWriterContext { } // This will cause SCM0002
+ public partial class MyContext: ModelReaderWriterContext { }
```

## SCM0003

### Cause

The source generator found the `ModelReaderWriterBuildableAttribute` applied to a class which does not inherit from `ModelReaderWriterContext`.

### How to fix violation

Move the attribute usage to a partial class inheriting from `ModelReaderWriterContext`.

### Example of a violation

#### Description

The following code adds the `ModelReaderWriterBuildableAttribute` to a class which doesn't inherit from `ModelReaderWriterContext`.

#### Code

```c#
[ModelReaderWriterBuildable(typeof(List<MyPersistableModel>))]
public class MyClass { } // This will cause SCM0003
```

### Example of how to fix

#### Description

Move the attribute usage to a partial class inheriting from `ModelReaderWriterContext`.

#### Code

```diff
[ModelReaderWriterBuildable(typeof(List<MyPersistableModel>))]
- public class MyClass { } // This will cause SCM0003
+ public partial class MyContext : ModelReaderWriterContext { }
```

## SCM0004

### Cause

The source generator found an `IPersistableModel` that was abstract and didn't have a `PersistableModelAttribute` applied to it.

### How to fix violation

Add a `PersistableModelAttribute` to the abstract class and set the ProxyType parameter to the type of the class that will be used to create instances of the abstract class.

### Example of a violation

#### Description

The following code defines an abstract class that implements `IPersistableModel` but does not have a `PersistableModelAttribute` applied to it.

#### Code

```c#
public abstract class MyClass : IPersistableModel<MyClass> { } // This will cause SCM0004
```

### Example of how to fix

#### Description

Add a proxy class that can be used to create instances of the abstract class and add a `PersistableModelAttribute` to the abstract class.

#### Code

```diff
+ [PersistableModelAttribute(typeof(ProxyClass))]
public abstract class MyClass : IPersistableModel<MyClass> { }
+ public class MyClassProxy : IPersistableModel<MyClass> { }
```

## SCM0005

### Cause

Types that implement IPersistableModel and do not have a `PersistableModelProxyAttribute` must have a public or internal parameterless constructor.

### How to fix violation

Add a public or internal parameterless constructor to the class.

### Example of a violation

#### Description

The following code defines a class that implements `IPersistableModel` but does not have a `PersistableModelProxyAttribute` applied to it
or a public or internal parameterless constructor.

#### Code

```c#
public class MyClass : IPersistableModel<MyClass>
{
    private MyClass() { } // This will cause SCM0005
}
```

### Example of how to fix

#### Description

Add a proxy class that can be used to create instances of the class or add a `PersistableModelAttribute` to the class.

#### Code

```diff
public class MyClass : IPersistableModel<MyClass>
{
    private MyClass() { }
+   internal MyClass() { }
}
```

OR

```diff
+ [PersistableModelAttribute(typeof(ProxyClass))]
public class MyClass : IPersistableModel<MyClass>
{
    private MyClass() { }
}
+ public class MyClassProxy : IPersistableModel<MyClass> { }
```
