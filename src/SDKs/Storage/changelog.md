## Microsoft.Azure.Management.Storage release notes

### Changes in 7.1.0-preview

- Support Create or Upgrade Storage Account with kind StorageV2

### Changes in 7.0.0-preview

**Breaking changes**

- When updating storage virtual networks, NetworkRuleSet is used instead of NetworkAcl.

**Notes**

- When updating storage virtual networks, virtualNetworkResourceId is limited to be resource ID of a subnet.
- Added Skus.list() operation, which could list all the available skus for the subscription. 