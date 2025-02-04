// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { NoTarget, Program, Tracer } from "@typespec/compiler";
import { getTracer, reportDiagnostic } from "./lib.js";
import { LoggerLevel } from "./log-level.js";

export class Logger {
  private static instance: Logger;
  private initialized: boolean = false;
  private tracer: Tracer;
  private level: LoggerLevel;
  private program: Program;

  private constructor(program: Program, level: LoggerLevel) {
    this.tracer = getTracer(program);
    this.level = level;
    this.program = program;
  }

  static initialize(program: Program, level: LoggerLevel): void {
    if (!Logger.instance) {
      Logger.instance = new Logger(program, level);
      Logger.instance.initialized = true;
    }
  }

  static getInstance(): Logger {
    if (!Logger.instance) {
      throw new Error("Logger is not initialized. Call initialize() first.");
    }
    return Logger.instance;
  }

  info(message: string): void {
    if (!this.initialized) {
      throw new Error("Logger is not initialized. Call initialize() first.");
    }
    if (
      this.level === LoggerLevel.INFO ||
      this.level === LoggerLevel.DEBUG ||
      this.level === LoggerLevel.VERBOSE
    ) {
      this.tracer.trace(LoggerLevel.INFO, message);
    }
  }

  debug(message: string): void {
    if (!this.initialized) {
      throw new Error("Logger is not initialized. Call initialize() first.");
    }
    if (this.level === LoggerLevel.DEBUG || this.level === LoggerLevel.VERBOSE) {
      this.tracer.trace(LoggerLevel.DEBUG, message);
    }
  }

  verbose(message: string): void {
    if (!this.initialized) {
      throw new Error("Logger is not initialized. Call initialize() first.");
    }
    if (this.level === LoggerLevel.VERBOSE) {
      this.tracer.trace(LoggerLevel.VERBOSE, message);
    }
  }

  warn(message: string): void {
    reportDiagnostic(this.program, {
      code: "general-warning",
      format: { message: message },
      target: NoTarget,
    });
  }

  error(message: string): void {
    reportDiagnostic(this.program, {
      code: "general-error",
      format: { message: message },
      target: NoTarget,
    });
  }
}
