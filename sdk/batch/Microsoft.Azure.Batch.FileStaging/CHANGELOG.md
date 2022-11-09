# Release History

## 9.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 9.0.0 (2022-08-18)

### Breaking Changes

- The changes incorporated in this version are the product of migrating from the deprecated WindowsAzure .NET Storage SDK to the current Azure.Storage SDK. The only **Breaking** change is that this project now relies on the Azure.Storage SDK and any reference to the legacy WindowsAzure .NET SDK has been removed. As a result, support of the following target frameworks has been dropped as they are not supported by the current Azure.Storage SDK:
  - netstandard1.4,
  - netstandard1.5,
  - netstandard1.6,
  - net452,
  - net46
