# TypeSpec Client Customizations Reference

## Quick Setup

### 1. Project Structure

```
project/
├── main.tsp          # Your service definition
├── client.tsp        # Client customizations
└── tspconfig.yaml    # Compiler configuration
```

### 2. Basic client.tsp Template

```typespec
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

// Your customizations here
```

## Client Customizations Namespace

`client.tsp` should have a file-level namespace if types (e.g. models, interfaces, operations, etc) are defined in `client.tsp`.
Do not add a file-level namespace if one already exists. They are only required when types are defined in `client.tsp`.

```typespec
import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

namespace ClientCustomizations;

// Your customizations here
```

## Universal Scope Parameter

**IMPORTANT**: All Azure.ClientGenerator.Core decorators support an optional `scope` parameter as their final parameter to target specific language emitters.

### Scope Syntax

```typespec
@decoratorName(/* decorator-specific params */, scope?: string)
```

### Scope Patterns

#### Target Specific Languages

```typespec
// Single language
@@clientName(Foo, "Bar", "python")
@@access(Foo.get, Access.internal, "csharp")

// Multiple languages (comma-separated)
@@clientName(Foo, "Bar", "python, javascript")
```

#### Exclude Languages (Negation)

```typespec
// Exclude one language
@@clientName(Foo, "Bar", "!csharp") // All languages EXCEPT C#

// Exclude multiple languages
@@clientName(Foo, "Bar", "!python, !go") // All languages EXCEPT python and go
```

#### Language Identifiers

- `"csharp"` - C#/.NET
- `"python"` - Python
- `"java"` - Java
- `"javascript"` - TypeScript/JavaScript
- `"go"` - Go
- `"rust"` - Rust

### Scope Best Practices

#### DO: Use negation for single language exclusions

```typespec
// Good: Exclude only C#
@@clientName(get, "getFoo", "!csharp")

// Bad: List all other languages
@@clientName(get, "getFoo", "python, java, javascript, go")
```

#### DO: Combine scopes when logic is identical

```typespec
// Good: Same customization for multiple languages
@@clientName(name, "sharedName", "python, go")

// Avoid: Duplicate decorators
@@clientName(name, "sharedName", "python")
@@clientName(name, "sharedName", "go")
```

#### DON'T: Overuse scopes without clear need

```typespec
// Bad: Unnecessary scope for universal customization
@@clientName(MyService, "MyClient", "csharp, python, java, javascript, go")

// Good: No scope means all languages
@@clientName(MyService, "MyClient")
```

## Core Decorators

### @access

**Purpose**: Control visibility of types and operations in generated clients.
**Syntax**: `@access(value: Access.public | Access.internal, scope?: string)`
**Usage**:

```typespec
// Hide internal operations
@@access(getFoo, Access.internal)

// Make models referenced by internal operations public
@@access(Foo, Access.public)

// Language-specific access
@@access(getFoo, Access.internal, "csharp")
```

**Propagation Rules**:

- Operations marked `Access.internal` make their models internal
- Operations marked `Access.public` make their models public
- Namespace access propagates to contained types
- Model access propagates to properties and inheritance hierarchy

### @client

**Purpose**: Define root clients in the SDK.
**Restrictions**: Cannot be used with `@clientLocation` decorator. Cannot be used as an augmentation (`@@`) decorator.
**Important**: `@client` has to be used on a type defined in `client.tsp`, so a file-level namespace (e.g. `namespace ClientCustomizations;`) should be added if one does not exist.
**Syntax**: `@client(options: ClientOptions, scope?: string)`
**Usage**:

```typespec
// Basic client
@client({ service: MyService })
interface MyClient {}

// Named client
@client({ service: MyService, name: "CustomClient" })
interface MyClient {}

// Split operations into multiple clients
@client({ service: PetStore, name: "FoodClient" })
interface FoodClient {
  feed is PetStore.feed;
}

@client({ service: PetStore, name: "PetClient" })
interface PetClient {
  pet is PetStore.pet;
}
```

### @operationGroup

**Purpose**: Define sub-clients (operation groups).
**Restrictions**: Cannot be used with `@clientLocation` decorator. Cannot be used as an augmentation (`@@`) decorator.
**Important**: `@operationGroup` has to be used on a type defined in `client.tsp`, so a file-level namespace (e.g. `namespace ClientCustomizations;`) should be added if one does not exist.
**Syntax**: `@operationGroup(scope?: string)`
**Usage**:

```typespec
@client({ service: MyService })
namespace MyClient;

@operationGroup
interface Pets {
  list is MyService.listPets;
  get is MyService.getPet;
}

@operationGroup
interface Users {
  list is MyService.listUsers;
  create is MyService.createUser;
}
```

### @clientLocation

**Purpose**: Move operations between clients without restructuring.
**Restrictions**: Cannot be used with `@client` or `@operationGroup` decorators.
**Syntax**: `@clientLocation(target: Interface | Namespace | string, scope?: string)`
**Usage**:

```typespec
// Move to existing client
@@clientLocation(MyService.upload, AdminOperations);

// Move to new client
@@clientLocation(MyService.archive, "ArchiveClient");

// Move to root client
@@clientLocation(MyService.SubClient.health, MyService);

// Move parameter to client initialization
@@clientLocation(MyService.upload.subscriptionId, MyService);
```

### @clientName

**Purpose**: Override generated names for SDK elements. Takes precedence over all other naming mechanisms.
**Important**: Always use PascalCase or camelCase for the rename parameter to make it easier to combine language scopes. SDKs will apply language-specific naming conventions automatically.
**Syntax**: `@clientName(rename: string, scope?: string)`
**Usage**:

```typespec
// Rename Type
@@clientName(PetStore, "PetStoreClient");

// Language-specific names
@@clientName(foo, "pythonicFoo", "python")
@@clientName(foo, "csharpicFoo", "csharp")
```

### @clientNamespace

**Purpose**: Change the namespace/package of generated types in the client SDK.
**Syntax**: `@clientNamespace(rename: string, scope?: string)`
**Usage**:

```typespec
// Change client namespace
@@clientNamespace(MyService, "MyClient");

// Move model to different namespace
@@clientNamespace(MyService.MyModel, "MyClient.Models")
```

### @clientInitialization

**Purpose**: Add custom parameters to client initialization.
**Important**: When `@clientInitialization` references a model defined in `client.tsp`, a file-level namespace (e.g. `namespace ClientCustomizations;`) should be added if one does not exist.
**Syntax**: `@clientInitialization(options: ClientInitializationOptions, scope?: string)`
**Usage**:

```typespec
// Add initialization parameters
model MyClientOptions {
  connectionString: string;
}

@@clientInitialization(MyService, { parameters: MyClientOptions });

// With parameter aliasing
model MyClientOptions {
  @paramAlias("subscriptionId")
  subId: string;
}

@@clientInitialization(MyService, { parameters: MyClientOptions });
```

### @alternateType

**Purpose**: Replace types in generated clients.
**Syntax**: `@alternateType(alternate: Type | ExternalType, scope?: string)`
**Usage**:

```typespec
// Change property type
@@alternateType(Foo.date, string);

// Language-specific alternates
@@alternateType(Foo.date, string, "python")

// External type replacement
@@alternateType(uri, {
  identity: "System.Uri",
  package: "System",
}, "csharp")
```

### @override

**Purpose**: Customize method signatures in generated clients.
**Restrictions**: Only operation parameter signatures can be customized.
**Important**: When `@override` references an operation defined in `client.tsp`, a file-level namespace (e.g. `namespace ClientCustomizations;`) should be added if one does not exist.
**Syntax**: `@override(override: Operation, scope?: string)`

**Usage**:

```typespec
// main.tsp
// Original operation
op myOperation(foo: string, bar: string): void;

// client.tsp
// Custom signature - combine into options
model MyOperationOptions {
  foo: string;
  bar: string;
}

op myOperationCustom(options: MyOperationOptions): void;

@@override(myOperation, myOperationCustom);
```

### @scope

**Purpose**: Include/exclude operations from specific languages.
**Usage**:

```typespec
@@scope(Foo.create, "!csharp")      // All languages except C#

@@scope(Foo.create, "python")       // Python only

@@scope(Foo.create, "java, go")     // Java and Go only
```

### @usage

**Purpose**: Add usage information to models and enums.
**Note**: The usages provided are _additive_.
**Usage**:

```typespec
// Add input and output usage to type
@@usage(MyModel, Usage.input | Usage.output)
```

**Usage Values**:

- `Usage.input`: Used in request
- `Usage.output`: Used in response
- `Usage.json`: Used with JSON content type
- `Usage.xml` Used with XML content type

### @clientDoc

**Purpose**: Override documentation for client libraries.
**Usage**:

```typespec
// Replace type documentation with client documentation
@@clientDoc(myOperation, "Client-specific documentation", DocumentationMode.replace)

// Append type documentation with client documentation - for only python
@@clientDoc(myModel, "Additional client notes", DocumentationMode.append, "python")
```

## Language-specific Customizations

### @useSystemTextJsonConverter (C# only)

**Purpose**: Use custom JSON converter for backward compatibility.
**Usage**:

```typespec
@@useSystemTextJsonConverter(MyModel, "csharp")
```

## Best Practices

### Do's

- Use `client.tsp` for all customizations
- Use scope parameter for language-specific customizations
- Prefer scope negation (`"!csharp"`) when excluding single languages
- Combine scopes (`"python, java"`) when logic is identical across languages
- Use a file-level namespace (e.g. `namespace ClientCustomizations;`) in `client.tsp` if any types are defined in `client.tsp`.

### Don'ts

- Mix `@clientLocation` with `@client`/`@operationGroup`
- Over-customize - prefer defaults when possible
- Use legacy decorators for new services
- Rename without considering breaking changes
- Forget to specify scope for language-specific customizations

## Common Scenarios

### Scenario 1: Move Operations to Root Client

```typespec
// Before: Operations in interfaces become sub-clients
interface Pets { feed(): void; }
interface Users { login(): void; }

// After: All operations on root client
@@clientLocation(Pets.feed, MyService);
@@clientLocation(Users.login, MyService);
```

### Scenario 2: Rename for Consistency

```typespec
// Standardize naming across languages
@@clientName(MyService, "MyServiceClient");
@@clientName(getUserInfo, "GetUserInformation");

// Language-specific naming
@@clientName(uploadFile, "UploadFile", "csharp, python");
```

### Scenario 3: Add Client Parameters

```typespec
// Elevate common parameters to client
model MyServiceOptions {
  subscriptionId: string;
  resourceGroup: string;
}

@@clientInitialization(MyService, { parameters: MyServiceOptions });
```

### Scenario 4: Multi-Client Architecture

```typespec
// Separate admin and user operations
@client({ service: MyService, name: "AdminClient" })
interface AdminClient {
  deleteUser is MyService.deleteUser;
  manageRoles is MyService.manageRoles;
}

@client({ service: MyService, name: "UserClient" })
interface UserClient {
  getProfile is MyService.getProfile;
  updateProfile is MyService.updateProfile;
}
```

### Scenario 5: Language-specific clients

```typespec
// Different client names for Java and others
@client({ service: MyService, name: "Foo.MyServiceClient" }, "java")
@client({ service: MyService, name: "MyServiceClient" }, "!java")
interface MyServiceClient {
  getAllData is MyService.getAllData;
}

// Different clients for python and Go
@client({ service: MyService, name: "MyClient" }, "python")
interface MyClientPython {
  fetchData is MyService.fetchData;
}
@client({ service: MyService, name: "MyClient" }, "go")
interface MyClientGo {
  fetchStream is MyService.fetchStream;
}
```

### Scenario 6: Rename custom client operations

```typespec
// Create a client with operation names changed
@client({ service: MyService, name: "MyClient" })
interface MyClient {
  getFoo is MyService.getFooData;
}
```

This reference provides the essential patterns and decorators for TypeSpec client customizations. Focus on the core decorators (`@client`, `@operationGroup`, `@@clientLocation`, `@@clientName`, `@@access`) for most scenarios, and use advanced features selectively.
