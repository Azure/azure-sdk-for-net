# Azure.Communication.ShortCodes

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
input-file:
    -  $(this-folder)/swagger/2021-10-25-preview/swagger.json
payload-flattening-threshold: 3
generation1-convenience-client: true
```

### Customizations
#### Recurrence type
The `MessageDetails` type has a property named `Recurrence`. "Recurrence" is a very common name, and there's an analyzer that emits an `AZC0012 - Avoid single word type names`. The swagger changes the name of this type to `MessageRecurrence`.

#### MessageDetails.OptInMessage
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.

#### MessageDetails.ConfirmationMessage
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.

#### USProgramBrief.ProgramDetails
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.

#### USProgramBrief.CompanyInformation
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.

#### USProgramBrief.MessageDetails
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.

#### USProgramBrief.TrafficDetails
Added a generic comment because the original swagger was missing it, causing the compiler to emit a `CS1591 - Missing XML comment for publicly visible type or member 'Type_or_Member'`.
