import { singular } from "pluralize";

export function lastWordToSingular(str: string): string {
  const words = firstCharToUpperCase(str).split(/(?=[A-Z])/);
  const lastWord = words[words.length - 1];
  return words.slice(0, -1).join("") + singular(lastWord);
}

function firstCharToUpperCase(str: string): string {
  if (!str) return str;
  return str[0].toUpperCase() + str.substring(1);
}

export function escapeRegex(str: string) {
  return str.replace(/\\/g, "\\\\");
}
