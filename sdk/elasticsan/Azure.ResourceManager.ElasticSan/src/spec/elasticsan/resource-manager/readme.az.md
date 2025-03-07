## AZ

These settings apply only when `--az` is specified on the command line.

``` yaml $(az)
az:
    extensions: diskpool
    namespace: azure.mgmt.storagepool
    package-name: azure-mgmt-storagepool
az-output-folder: $(azure-cli-extension-folder)/src/diskpool
python-sdk-output-folder: "$(az-output-folder)/azext_diskpool/vendored_sdks/storagepool"
# add additinal configuration here specific for Azure CLI
# refer to the faq.md for more details
```

## Az.DiskPool

``` yaml
cli:
  cli-directive:
      - where:
          param: disks
        set:
          positional: true
          positionalKeys:
            - id
      - where:
          group: DiskPools
          parameter: additionalCapabilities
        alias:
          - additional_capabilities
          - a

```