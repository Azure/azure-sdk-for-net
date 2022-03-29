# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

* [Fix shared RoleName/RoleInstance between Trace and Log Exporter](https://github.com/Azure/azure-sdk-for-net/pull/26438)

### Other Changes

## 1.0.0-beta.3 (2021-10-04)

* [Update SdkVersion to include pre-release part](https://github.com/Azure/azure-sdk-for-net/pull/24290)
* [Remove otel.status_code from custom properties](https://github.com/Azure/azure-sdk-for-net/pull/24250)
* [Update Request operation name to use http.route/http.url path](https://github.com/Azure/azure-sdk-for-net/pull/24222)
* [Update Http Dependency name to httpUrl path and target for Db dependency](https://github.com/Azure/azure-sdk-for-net/pull/24211)
* [Rename EventSource](https://github.com/Azure/azure-sdk-for-net/pull/24176)
* [Update Request Name to match Operation Name](https://github.com/Azure/azure-sdk-for-net/pull/24059)
* [Fix success field logic for request and dependency](https://github.com/Azure/azure-sdk-for-net/pull/23757)
* [Default cloud_RoleInstance to HostName](https://github.com/Azure/azure-sdk-for-net/pull/23592)
* [Add InProc dependency type and update Db target mapping](https://github.com/Azure/azure-sdk-for-net/pull/23541)
* [Add ai.location.ip and ai.user.userAgent mapping](https://github.com/Azure/azure-sdk-for-net/pull/23524)
* [Operation name mapping for ActivityKind = SERVER](https://github.com/Azure/azure-sdk-for-net/pull/23448)
* [Update Dependency Type and Target mapping for Http and Db](https://github.com/Azure/azure-sdk-for-net/pull/23330)
* [Update Http Request mapping](https://github.com/Azure/azure-sdk-for-net/pull/23206)
* [Add ActivityLinks Support](https://github.com/Azure/azure-sdk-for-net/pull/23110)
* [Update OpenTelemetry Package versions](https://github.com/Azure/azure-sdk-for-net/pull/23059)

## 1.0.0-beta.2 (2021-03-04)

* [Set Remote Dependency Telemetry semantics](https://github.com/Azure/azure-sdk-for-net/issues/17026)
* [Supports sending EventSource and Telemetry output to the debug trace](https://github.com/Azure/azure-sdk-for-net/issues/16893)

## 1.0.0-beta.1 (2020-11-06)

* Initial release of Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet)

This is a beta version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).
