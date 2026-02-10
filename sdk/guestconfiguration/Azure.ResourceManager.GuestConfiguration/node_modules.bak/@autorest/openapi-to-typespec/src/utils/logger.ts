import { getSession } from "../autorest-session";

export interface Logger {
  info: (message: string) => void;
  error: (message: string) => void;
  warning: (message: string) => void;
  debug: (message: string) => void;
  verbose: (message: string) => void;
}

export function getLogger(scope: string) {
  const session = getSession();
  const { error, warning, debug, verbose } = session;

  return {
    info: function (message: string) {
      session.info(`${scope}: ${message}`);
    },
    error: (message: string) => error(`${scope}: ${message}`, []),
    warning: (message: string) => warning(`${scope}: ${message}`, []),
    debug: (message: string) => debug(`${scope}: ${message}`),
    verbose: (message: string) => verbose(`${scope}: ${message}`),
  };
}
