// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import { describe, expect, it } from "vitest";
import {
  $lib,
  $onEmit,
  AspNetServerEmitterOptionsSchema
} from "../src/index.js";

describe("@azure-typespec/http-server-csharp-aspnet", () => {
  describe("$lib", () => {
    it("registers the expected library name", () => {
      expect($lib.name).toBe("@azure-typespec/http-server-csharp-aspnet");
    });

    it("includes diagnostics inherited from the upstream emitter", () => {
      // The upstream emitter contributes at least one diagnostic; we re-export
      // them so generator authors get consistent diagnostic codes.
      expect(Object.keys($lib.diagnostics).length).toBeGreaterThan(0);
    });

    it("exposes the emitter options schema", () => {
      expect($lib.emitter?.options).toBe(AspNetServerEmitterOptionsSchema);
    });
  });

  describe("AspNetServerEmitterOptionsSchema", () => {
    it("declares the upstream CSharp emitter options as properties", () => {
      const props = AspNetServerEmitterOptionsSchema.properties as Record<
        string,
        unknown
      >;
      // Sanity check that the pass-through schema preserved the upstream
      // option keys; we don't pin the exact set so this stays robust against
      // upstream additions.
      expect(props).toBeDefined();
      expect(Object.keys(props).length).toBeGreaterThan(0);
    });
  });

  describe("$onEmit", () => {
    it("is exported as a function", () => {
      expect(typeof $onEmit).toBe("function");
    });
  });
});
