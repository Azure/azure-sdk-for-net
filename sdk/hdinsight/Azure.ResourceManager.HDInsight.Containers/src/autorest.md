# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
input-file: https://github.com/Azure/azure-rest-api-specs/blob/f09aacf4c6b63be416212cb182f6b31e8bc6d545/specification/hdinsight/resource-manager/Microsoft.HDInsight/HDInsightOnAks/preview/2023-06-01-preview/hdinsight.json
library-name: HDInsight
namespace: Azure.ResourceManager.HDInsight.Containers
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
mgmt-debug:
  show-request-path: true

```