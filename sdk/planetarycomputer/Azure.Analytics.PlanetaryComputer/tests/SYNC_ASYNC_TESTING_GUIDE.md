# Sync/Async Testing Guide for Azure Planetary Computer SDK

## Overview

All tests in the Azure Planetary Computer SDK now support both **synchronous** and **asynchronous** execution modes. This approach maximizes code coverage by ensuring both sync and async code paths are tested.

## Changes Made

### 1. Removed `[AsyncOnly]` Attribute
- **Before**: Test classes were marked with `[AsyncOnly]`, meaning they only ran in async mode
- **After**: All test classes now run in both sync and async modes automatically

### 2. Added Setup Method to Base Class
The `PlanetaryComputerTestBase` class now includes a `[SetUp]` method that logs whether the test is running in sync or async mode. This helps with debugging and understanding test execution.

### 3. Test Naming Convention
- **Async tests** will appear in test explorer as: `TestClassName(true)`
- **Sync tests** will appear in test explorer as: `TestClassName(false)`

## Recording Tests

### Recording Order (IMPORTANT!)

To respect the logical order of commands and ensure proper recordings, **always record sync tests first, then async tests**:

```powershell
# Step 1: Record SYNC tests first
$env:AZURE_TEST_MODE = "Record"
dotnet test tests/Azure.Analytics.PlanetaryComputer.Tests.csproj --framework net8.0 --filter "FullyQualifiedName~(false)" --logger "console;verbosity=normal"

# Step 2: Record ASYNC tests second
$env:AZURE_TEST_MODE = "Record"
dotnet test tests/Azure.Analytics.PlanetaryComputer.Tests.csproj --framework net8.0 --filter "FullyQualifiedName~(true)" --logger "console;verbosity=normal"
```

### Recording Specific Test Classes

If you only want to record specific test classes:

```powershell
# Sync tests for Test01 (STAC Collections)
$env:AZURE_TEST_MODE = "Record"
dotnet test --filter "FullyQualifiedName~TestPlanetaryComputer01StacCollectionTests&FullyQualifiedName~(false)"

# Async tests for Test01 (STAC Collections)
$env:AZURE_TEST_MODE = "Record"
dotnet test --filter "FullyQualifiedName~TestPlanetaryComputer01StacCollectionTests&FullyQualifiedName~(true)"
```

### Recording by Category

You can also record by category if needed:

```powershell
# Record all STAC tests (sync)
$env:AZURE_TEST_MODE = "Record"
dotnet test --filter "Category=STAC&FullyQualifiedName~(false)"

# Record all STAC tests (async)
$env:AZURE_TEST_MODE = "Record"
dotnet test --filter "Category=STAC&FullyQualifiedName~(true)"
```

## Running Tests in Playback Mode

After recording, verify both sync and async tests work in playback:

```powershell
# Run all tests in playback mode
$env:AZURE_TEST_MODE = "Playback"
dotnet test tests/Azure.Analytics.PlanetaryComputer.Tests.csproj --framework net8.0

# Run only sync tests in playback
$env:AZURE_TEST_MODE = "Playback"
dotnet test --filter "FullyQualifiedName~(false)"

# Run only async tests in playback
$env:AZURE_TEST_MODE = "Playback"
dotnet test --filter "FullyQualifiedName~(true)"
```

## Test Recording Files

### File Naming Convention

The test framework automatically creates separate recording files for sync and async tests:

- **Async recordings**: `TestMethodName**Async**.json`
- **Sync recordings**: `TestMethodName.json` (no suffix)

### Example Structure

```
SessionRecords/
├── TestPlanetaryComputer01StacCollectionTests(false)/
│   ├── Test01_01_ListCollections.json
│   ├── Test01_03_GetCollection.json
│   └── ...
└── TestPlanetaryComputer01StacCollectionTests(true)/
    ├── Test01_01_ListCollectionsAsync.json
    ├── Test01_03_GetCollectionAsync.json
    └── ...
```

## Benefits of Sync/Async Testing

1. **Maximum Code Coverage**: Both sync and async code paths are tested
2. **Regression Detection**: Catches issues that might only appear in one mode
3. **API Consistency**: Ensures sync and async APIs behave identically
4. **Better Debugging**: Can debug sync code paths which are often simpler

## Test Categories

All tests maintain their existing categories, plus the implicit sync/async categorization:

- `STAC` - STAC specification tests
- `Collections` - Collection operations
- `Tiler` - Tiler operations
- `Mosaics` - Mosaic-specific tests
- `Legends` - Map legend tests
- `Lifecycle` - Collection lifecycle tests
- And more...

You can combine categories with sync/async filters:

```powershell
# Run only sync STAC tests
dotnet test --filter "Category=STAC&FullyQualifiedName~(false)"

# Run only async Tiler tests
dotnet test --filter "Category=Tiler&FullyQualifiedName~(true)"
```

## Troubleshooting

### Issue: Tests are taking too long

**Solution**: Run sync and async tests separately, or run specific test classes only.

### Issue: Recording mismatches in playback

**Solution**: Ensure you recorded sync tests BEFORE async tests. If recordings were done in the wrong order, delete the SessionRecords folder and re-record in the correct order.

### Issue: Some tests fail in sync mode but not async

**Solution**: This indicates a genuine issue with the sync implementation. Investigate the sync code path for the failing operation.

## Best Practices

1. ✅ Always record sync tests first, then async tests
2. ✅ Run both modes in playback before pushing code
3. ✅ Use categories to organize and filter tests
4. ✅ Check test duration - sync tests should generally be faster
5. ✅ Review both sets of recordings after recording
6. ✅ Delete old recordings before re-recording to avoid confusion

## CI/CD Considerations

In CI/CD pipelines, both sync and async tests will run automatically. The total test count will effectively double (one for sync, one for async version of each test method).

Expected test count per test class:
- Each test method = 2 test executions (1 sync + 1 async)
- Example: 10 test methods = 20 test executions total
