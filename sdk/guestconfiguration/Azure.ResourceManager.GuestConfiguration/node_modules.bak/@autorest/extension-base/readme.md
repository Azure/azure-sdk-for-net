# Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

# AutoRest Extension Base

Allows to easily create an AutoRest extension.
See https://github.com/azure/autorest-extension-helloworld for an example of how to reference and use this package. We recommend using _that_ as a starting point.

## Usage

```JavaScript
import { AutoRestExtension } from "@autorest/extension-base";

const extension = new AutoRestExtension();

extension.Add("plugin-name", async autoRestApi => {
  // plugin implementation
  // Available functions:
  // * Information retrieval:
  //       autoRestApi.ListInputs
  //       autoRestApi.ReadFile
  //       autoRestApi.GetValue
  // * Information submission:
  //       autoRestApi.WriteFile
  //       autoRestApi.Message
});

extension.Run();
```
