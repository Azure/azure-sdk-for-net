import { parseJsonRef, stringifyJsonRef, updateJsonRefs } from "./refs";

describe("JsonSchema Refs", () => {
  describe("parseJsonRef", () => {
    it("parse path only when there is no file in ref", () => {
      expect(parseJsonRef("#/definitions/Foo")).toEqual({ path: "/definitions/Foo" });
    });

    it("parse file and path", () => {
      expect(parseJsonRef("bar.json#/definitions/Foo")).toEqual({ file: "bar.json", path: "/definitions/Foo" });
    });

    it("parse file only", () => {
      expect(parseJsonRef("bar.json")).toEqual({ file: "bar.json" });
    });

    it("parse with path containing url encoded", () => {
      expect(parseJsonRef("#/definitions/%24Foo")).toEqual({ path: "/definitions/$Foo" });
    });
  });

  describe("stringifyJsonRef", () => {
    it("parse path only when there is no file in ref", () => {
      expect(stringifyJsonRef({ path: "/definitions/Foo" })).toEqual("#/definitions/Foo");
    });

    it("parse file and path", () => {
      expect(stringifyJsonRef({ file: "bar.json", path: "/definitions/Foo" })).toEqual("bar.json#/definitions/Foo");
    });

    it("parse file only", () => {
      expect(stringifyJsonRef({ file: "bar.json" })).toEqual("bar.json");
    });
  });

  describe("updateJsonRefs", () => {
    const testUpdateRef = (document: any) => {
      return updateJsonRefs(document, (x) => (x += "Bar"));
    };

    it("update string refs nested in objects", () => {
      expect(testUpdateRef({ foo: { bar: { $ref: "#/definitions/Foo" } } })).toEqual({
        foo: { bar: { $ref: "#/definitions/FooBar" } },
      });
    });

    it("update string refs nested in array", () => {
      expect(testUpdateRef([{ $ref: "#/definitions/Foo" }])).toEqual([
        {
          $ref: "#/definitions/FooBar",
        },
      ]);
    });

    it("doesn't change $ref used as a property", () => {
      expect(testUpdateRef([{ $ref: { name: "refProperty" } }])).toEqual([{ $ref: { name: "refProperty" } }]);
    });
  });
});
