import { CodeModel } from "@autorest/codemodel";
import { Session } from "@autorest/extension-base";
import { getSession } from "./autorest-session";
import { TypespecOptions } from "./interfaces";

export let options: TypespecOptions;

export function getOptions(): TypespecOptions {
  if (!options) {
    updateOptions();
  }

  return options;
}

export function updateOptions() {
  const session = getSession();
  options = {
    isAzureSpec: getIsAzureSpec(session),
    namespace: getNamespace(session),
    guessResourceKey: getGuessResourceKey(session),
    removeOperationId: getRemoveOperationId(session),
    isArm: getIsArm(session),
    isFullCompatible: getIsFullCompatible(session),
    isTest: getIsTest(session),
  };
}

function getRemoveOperationId(session: Session<CodeModel>) {
  return session.configuration["removeOperationId"] ?? false;
}

export function getGuessResourceKey(session: Session<CodeModel>) {
  const shouldGuess = session.configuration["guessResourceKey"] ?? false;
  return shouldGuess !== false;
}

export function getIsArm(session: Session<CodeModel>) {
  if (session.configuration["isArm"] !== undefined) {
    // If isArm is explicitly set, use it.
    return Boolean(session.configuration["isArm"]);
  }

  const inputs = session.configuration["inputFileUris"] as string[];

  for (const input of inputs) {
    if (input.includes("resource-manager")) {
      return true;
    }
  }

  // by default is isArm is not explicitly set, we assume it is DataPlane.
  return false;
}

export function getIsAzureSpec(session: Session<CodeModel>) {
  return session.configuration["isAzureSpec"] !== false;
}

export function getNamespace(session: Session<CodeModel>) {
  return session.configuration["namespace"];
}

export function getIsFullCompatible(session: Session<CodeModel>) {
  const isFullCompatible = session.configuration["isFullCompatible"] ?? false;
  return isFullCompatible !== false;
}

export function getIsTest(session: Session<CodeModel>) {
  return session.configuration["isTest"] === true;
}
