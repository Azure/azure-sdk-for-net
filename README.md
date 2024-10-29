# Azure SDK Assets

This repository is used for resources that the Azure SDK team does not wish to be confined within any of our language-specific repositories.

These language-specific repos are located at:

- [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net)
- [Azure/azure-sdk-for-js](https://github.com/Azure/azure-sdk-for-js)
- [Azure/azure-sdk-for-python](https://github.com/Azure/azure-sdk-for-python)
- [Azure/azure-sdk-for-java](https://github.com/Azure/azure-sdk-for-java)
- [Azure/azure-sdk-for-android](https://github.com/Azure/azure-sdk-for-android)
- [Azure/azure-sdk-for-ios](https://github.com/Azure/azure-sdk-for-ios)
- [Azure/azure-sdk-for-go](https://github.com/Azure/azure-sdk-for-go)
- [Azure/azure-sdk-for-cpp](https://github.com/Azure/azure-sdk-for-cpp)
- [Azure/azure-sdk-for-c](https://github.com/Azure/azure-sdk-for-c)

This list is subject to addition.

The repository currently contains:

- Test Recordings

This list will expand as necessary.

## Usage of this repo

As part of a greater engineering effort to re-use components, the azure-sdk team uses the [`test-proxy`](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md) as an out-of-process record/playback solution. Each language will need a small shim to call into the proxy (which is hosted as an http server locally), but other than that, we save the effort of maintaining a record/playback framework for _each language_.

This common record/playback server also has the ability to restore and retrieve recordings from an external source. This repository functions as that external source.

For usage of the azure-sdk `test-proxy` to store and retrieve recordings, please reference [this readme](https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy/documentation/asset-sync#asset-sync-retrieve-external-test-recordings).

For detailed reading on _why_ the azure-sdk team is storing their assets in an external repository, please read [this document](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/documentation/test-proxy/initial-investigation.md) for additional detail.

## Contributing

This repository has tags created automatically by the [`test-proxy` tool](https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy/documentation/asset-sync#asset-sync-retrieve-external-test-recordings) as part of the `push` mechanism. As this repository will only ever contain resources for external usage, normal contribution from MS employees or OSS devs is unlikely.

In the case an enterprising user has suggestions, please file an issue under the label `question`.


