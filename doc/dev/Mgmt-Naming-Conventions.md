# Azure SDK for .NET - Management Plane SDK Naming Conventions

This document describes the naming conventions for the Azure Management Plane SDK for .NET.
In addition to adhering to the [General Naming Conventions of .NET](https://learn.microsoft.com/dotnet/standard/design-guidelines/general-naming-conventions), there are specific guidelines related to the naming of classes, properties, and methods. These include rules for using abbreviations and acronyms, as well as recommendations for avoiding Azure-specific names.

## General Guidelines

**DO** Use Pascal case which capital case for the first letter only.

**DO** Two-letter acronyms are special and should be all-uppercased if it is not part of longer compound identifiers, but still have some exceptions like `Vm`, `Id` and etc. 

**DO** Use a singular type name for an `enum` type if it does not have the `[Flags]` attribute. Use a plural type name for an `enum` type if it has `[Flags]` attribute. For more details, please check [C# enumeration naming convention](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).

**DO** The name of PATCH operation's body parameter should be: `[Model]Patch`.  For the model of a property in the `[Model]Patch`, if you need to rename the suffix, use `Content` instead of `Patch` since properties are not patchable, they will be set as the property model is.

**DO** The name of PUT / POST operation's body parameter should be: `[Model]Content` or  `[Model]Data`.

**DO** Start property or parameter names of type bool with a verb, like `Is`, `Can`, `Has` prefix.

**DO** End property or parameter names of type DateTime with `On`.

  - Use the original verb form for active voice, like `StartOn` and `EndOn`.

  - Use the passive verb form for passive voice, like `CreatedOn`, `EstablishedOn`. 

**DO** End property or parameter names of type integer that represent intervals or durations with units, for example: `MonitoringInterval` -> `MonitoringIntervalInSeconds`.

**DO** If a property or parameter name ends with `Interval` or `Duration` and its value is not in ISO 8601 duration format (e.g., P1DT2H59M59S) or ISO 8601 time format (e.g., 2.2:59:59.5000000), rename the property or parameter to remove the `Interval` or `Duration` suffix.

**DO** Consider renaming TTL properties or parameters to `TimeToLiveIn<Unit>`. 

**DO** Avoid using single-word class names. Instead, use more descriptive names after consulting with the service development team.

**DO** Rename `CheckNameAvailability` operation:

  - The method name should be `Check[Resource/RP name]NameAvailability`.

  - The parameter / response model name should be `[Resource/RP name]NameAvailabilityXXX`.

  - If there is a `Reason` property which is used to represent the unavailable reason code, and its type is an `enum` then the name of this `enum` should be `[Resource/RP name]NameUnavailableReason`.

**DO NOT** Duplicate names across different RPs. Additionally, ensure that the data plane is covered (if applicable).

## Guidelines for model prefixes

We should avoid using `Microsoft`, `Azure` prefixes for any models or classes.

## Guidelines for model suffixes

We should avoid using the following suffixes for any models or classes.

- Parameter(s)

  It should be changed to either `Content` or `Patch` based on the context of its usage.

- Request

  It should be changed to `Content` based on the context of its usage.
 
- Options

  It should be changed to `Config`, unless it's a `ClientOptions`.

- Response

  It should be changed to `Result`.

- Resource:  
        
  - For a resource name (under `src/Generated` and you'll have `XXResourceData`, `XXResourceCollection`), if removing the word `Resource` leaves a descriptive enough noun, then remove it. Only keep `Resource` if removing it makes the noun no longer descriptive enough (e.g., `GenericResource` would become `Generic`). 

  - For a model name (under `src/Generated/Models`), if removing the `Resource` suffix makes it no longer descriptive or reduces it to a single word, append `Data` if it inherits from `ResourceData` or `TrackedResourceData`, otherwise append `Info`. 
        
  - Entity names that still have `Resource` suffix: `GenericResource`, `PrivateLinkServiceResource`.

- Collection

  Rename to `Group` or `List` when it makes sense and does not conflict with existing model names.
  For some resource name, it may be difficult to find a replacement and developers of that domain are familiar with the collection terminology like `MongoDBCollection`. It's **okay** to keep the suffix in such cases.

- Data

  Remove it unless the model derives from `ResourceData` or `TrackedResourceData`.

- Operation

  Remove it unless the model derives from `Operation<T>` or `Operation`.  Append `Data` or `Info` suffix if it's hard to rename with other words.

## Guidelines for Expanding Acronyms

If an acronym can be clearly explained on the first page of search results without needing a context word or with just one well-known context word, then there's no need to expand it. Otherwise, spell it out.

For Cryptographic (or other) algorithm names follow the same Pascal case acronym naming conventions:

- Advanced Encryption Standard (AES) is `Aes`.

- Elliptic Curve Digital Signature Algorithm (ECDSA) is `ECDsa` (two-letter acronym followed by a three-letter acronym).

- Elliptic Curve Diffie-Hellman (ECDH) is `ECDiffieHellman` (avoiding the four concurrent capital letters required by a two-letter acronym following a two-letter acronym). 
