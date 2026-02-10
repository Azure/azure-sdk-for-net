import { Language, Languages } from "@autorest/codemodel";

export function getLanguageMetadata(languages: Languages): Language {
  return languages.typescript || languages.javascript || languages.default;
}
