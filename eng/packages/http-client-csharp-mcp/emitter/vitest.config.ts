import { defineConfig } from "vitest/config";

export default defineConfig({
  test: {
    environment: "node",
    include: ["emitter/test/**/*.test.ts"],
    coverage: {
      reporter: ["cobertura", "json", "text"]
    },
    outputFile: {
      junit: "./test-results.xml"
    }
  }
});
