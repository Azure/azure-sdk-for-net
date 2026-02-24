# Changelog for Azure Resource Management Batch Client

## 1.0.0-beta.1 (TBD)

### Features Added

- Initial release of Azure Resource Management Batch Client
- Support for ARM Batch Operations API (2025-08-01-preview)
- `BatchClient` class with the following operations:
  - `InvokeAtSubscriptionScopeAsync()` / `InvokeAtSubscriptionScope()` - Execute batch requests at subscription scope
  - `InvokeAtResourceGroupScopeAsync()` / `InvokeAtResourceGroupScope()` - Execute batch requests at resource group scope
- Full Long Running Operation (LRO) support with proper async/await patterns
- Comprehensive error handling and retry policies
- Built on Azure.Core and Azure.ResourceManager foundations
- Supports both synchronous and asynchronous execution patterns
- Proper cancellation token support throughout

### API Reference

- **Namespace:** `Azure.ResourceManager.Batch`
- **Main Class:** `BatchClient`
- **Service Version:** 2025-08-01-preview
- **Target Framework:** .NET Standard 2.0, .NET 6.0+

### Dependencies

- Azure.Core (>= 1.35.0) 
- Azure.ResourceManager (>= 1.9.0)
- System.Text.Json (>= 6.0.0)