import { CreateSdkContextOptions } from "@azure-tools/typespec-client-generator-core";

export let defaultSDKContextOptions: CreateSdkContextOptions = {
  versioning: {
    previewStringRegex: /$/,
  },
  additionalDecorators: [],
};

export function setSDKContextOptions(options: CreateSdkContextOptions) {
  defaultSDKContextOptions = {
    versioning: options.versioning ?? defaultSDKContextOptions.versioning,
    additionalDecorators: appendAdditionalDecoratorsInContextOptions(options),
  };
}

function appendAdditionalDecoratorsInContextOptions(options: CreateSdkContextOptions) {
  if (options.additionalDecorators) {
    if (defaultSDKContextOptions.additionalDecorators) {
      return [...defaultSDKContextOptions.additionalDecorators, ...options.additionalDecorators];
    } else {
      return options.additionalDecorators;
    }
  } else {
    return defaultSDKContextOptions.additionalDecorators;
  }
}
