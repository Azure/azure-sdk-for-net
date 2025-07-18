# MatchConditionsVisitor Implementation

This document describes the implementation of the MatchConditionsVisitor for issue #50763.

## Overview

The MatchConditionsVisitor transforms service methods to group conditional request headers (If-Match, If-None-Match, If-Modified-Since, If-Unmodified-Since) into RequestConditions/MatchConditions types from Azure.Core.

## Current Implementation

### What is Implemented

1. **Parameter Detection**: Correctly identifies conditional request header parameters:
   - If-Match
   - If-None-Match  
   - If-Modified-Since
   - If-Unmodified-Since

2. **Parameter Removal**: Removes individual conditional header parameters from service methods and operations.

3. **Type Selection Logic**: Determines whether to use RequestConditions or MatchConditions:
   - RequestConditions: When date-based conditions (If-Modified-Since, If-Unmodified-Since) are present
   - MatchConditions: When only ETag conditions (If-Match, If-None-Match) are present

4. **Request Creation Modification**: Modifies the generated request creation code to include placeholder logic for Azure.Core extension methods.

5. **Unit Tests**: Comprehensive tests for the parameter detection and filtering logic.

### What is NOT Implemented

1. **Method Signature Modification**: The visitor does not yet add RequestConditions/MatchConditions parameters to public method signatures. This requires additional infrastructure in the generator framework.

2. **Actual Extension Method Calls**: The request creation currently includes placeholder comments rather than actual calls to the Azure.Core extension methods.

## Technical Details

### Current Generated Pattern (Before)
```csharp
public virtual Response PostIfMatch(string ifMatch, CancellationToken cancellationToken = default);

// In request creation:
if (ifMatch != null)
{
    request.Headers.Add("If-Match", ifMatch);
}
```

### Intended Generated Pattern (After) 
```csharp
public virtual Response PostIfMatch(RequestConditions requestConditions = default, CancellationToken cancellationToken = default);

// In request creation:
if (requestConditions != null)
{
    request.Headers.Add(requestConditions, "R");
}
```

### Azure.Core Extension Methods

The visitor is designed to use these Azure.Core extension methods:

```csharp
// For RequestConditions (includes all four headers)
request.Headers.Add(requestConditions, "R");

// For MatchConditions (includes only If-Match and If-None-Match)
request.Headers.Add(matchConditions);
```

## Files Modified/Added

1. `MatchConditionsVisitor.cs` - Main visitor implementation
2. `AzureClientGenerator.cs` - Added visitor to the pipeline
3. `MatchConditionsVisitorTests.cs` - Unit tests for full generator integration
4. `MatchConditionsVisitorManualTests.cs` - Standalone tests for core logic

## Testing

The implementation includes two types of tests:

1. **Manual Tests** (`MatchConditionsVisitorManualTests.cs`): Test the core parameter detection and filtering logic without requiring full generator infrastructure.

2. **Integration Tests** (`MatchConditionsVisitorTests.cs`): Test the visitor in the context of the full generator framework (requires build setup).

## Next Steps

To complete the implementation:

1. **Method Signature Modification**: Implement logic to add RequestConditions/MatchConditions parameters to method signatures. This may require:
   - Understanding how to properly create InputParameters for .NET types
   - Modifying how method providers construct signatures
   - Possibly creating custom method providers

2. **Extension Method Integration**: Replace placeholder comments with actual calls to Azure.Core extension methods.

3. **End-to-End Testing**: Test with actual TypeSpec/OpenAPI definitions that include conditional headers.

4. **Documentation**: Update generator documentation to explain the new behavior.

## Benefits

This implementation provides:

1. **Consistent API Pattern**: Aligns with existing Azure SDK patterns used in Storage and other services
2. **Type Safety**: Using RequestConditions/MatchConditions provides compile-time safety
3. **Simplified Usage**: Developers work with a single conditions object instead of multiple individual parameters
4. **Azure.Core Integration**: Leverages existing Azure.Core extension methods for proper header formatting

## Example Usage

After full implementation, developers would use the generated API like this:

```csharp
var conditions = new RequestConditions
{
    IfMatch = new ETag("\"12345\""),
    IfModifiedSince = DateTimeOffset.UtcNow.AddDays(-1)
};

var response = await client.PostIfMatchAsync(conditions);
```

Instead of:

```csharp
var response = await client.PostIfMatchAsync(
    ifMatch: "\"12345\"", 
    ifModifiedSince: DateTimeOffset.UtcNow.AddDays(-1));
```