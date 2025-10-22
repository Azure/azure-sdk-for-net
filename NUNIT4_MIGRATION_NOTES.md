# NUnit 4.x Migration Notes

## Completed Work

### Package Upgrades ✅
- NUnit upgraded from 3.13.2 to 4.4.0 across all configuration files
- NUnit.Analyzers 4.5.0 added to test frameworks for transitive inclusion
- All package references updated in:
  - `eng/Packages.Data.props`
  - `sdk/core/Azure.Core.TestFramework/src/Azure.Core.TestFramework.csproj`
  - `sdk/core/Microsoft.ClientModel.TestFramework/src/Microsoft.ClientModel.TestFramework.csproj`

### Assertion Migrations ✅
Converted classic assertions to constraint-based syntax:
- `Assert.AreEqual(expected, actual)` → `Assert.That(actual, Is.EqualTo(expected))`
- `Assert.IsTrue(condition)` → `Assert.That(condition, Is.True)`
- `Assert.IsFalse(condition)` → `Assert.That(condition, Is.False)`
- `Assert.IsNull(obj)` → `Assert.That(obj, Is.Null)`
- `Assert.IsNotNull(obj)` → `Assert.That(obj, Is.Not.Null)`

Files migrated include:
- Core test frameworks
- Azure.AI.Projects tests
- Azure.Data.Tables tests
- Communication shared test code
- Storage stress test infrastructure

## Remaining Work

### Additional Test Projects
Some test projects may still have classic assertions that need conversion. To complete:

1. Run format on remaining projects:
   ```bash
   cd /path/to/azure-sdk-for-net
   find sdk -name "*.Tests.csproj" -type f | while read proj; do
       dotnet format analyzers "$proj" --severity info --no-restore
   done
   ```

2. Build and test to identify any remaining issues:
   ```bash
   dotnet build <project>.csproj
   ```

3. Manually fix any files that dotnet format couldn't handle

### Known Patterns That May Need Manual Updates

#### StringAssert
- `StringAssert.Contains(substring, actual)` → `Assert.That(actual, Does.Contain(substring))`
- `StringAssert.StartsWith(prefix, actual)` → `Assert.That(actual, Does.StartWith(prefix))`

#### CollectionAssert
- `CollectionAssert.AreEqual(expected, actual)` → `Assert.That(actual, Is.EqualTo(expected))`
- `CollectionAssert.Contains(collection, item)` → `Assert.That(collection, Does.Contain(item))`

#### Assert.Throws
- Pattern remains similar but verify syntax: `Assert.Throws<ExceptionType>(() => code)`

### Testing Recommendations

1. **Build verification**: Run builds on representative projects from different SDK areas
2. **Test execution**: Run actual tests to ensure behavior is preserved
3. **CI/CD validation**: Monitor CI pipelines for any test failures

## Migration Guide Reference

Full NUnit 4.0 migration documentation:
https://docs.nunit.org/articles/nunit/release-notes/Nunit4.0-MigrationGuide.html

## Key Benefits of NUnit 4.x

- Modern constraint-based assertion model (more readable and maintainable)
- Better error messages and diagnostics
- Improved performance
- Active maintenance and support
- Compatibility with latest .NET versions
