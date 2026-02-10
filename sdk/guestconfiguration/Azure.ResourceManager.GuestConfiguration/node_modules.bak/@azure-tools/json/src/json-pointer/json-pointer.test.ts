import { getFromJsonPointer, parseJsonPointer, serializeJsonPointer } from "./json-pointer";

describe("Json Pointer", () => {
  it("serialize simple json path", () => {
    expect(serializeJsonPointer(["path", "to", "prop"])).toEqual("/path/to/prop");
  });

  it("serialize json path with / characters", () => {
    expect(serializeJsonPointer(["path", "/this/is/here", "prop"])).toEqual("/path/~1this~1is~1here/prop");
  });

  it("serialize json path with ~ characters", () => {
    expect(serializeJsonPointer(["path", "this~is~here", "prop"])).toEqual("/path/this~0is~0here/prop");
  });

  it("parse simple json path", () => {
    expect(parseJsonPointer("/path/to/prop")).toEqual(["path", "to", "prop"]);
  });

  it("parse json path with / characters", () => {
    expect(parseJsonPointer("/path/~1this~1is~1here/prop")).toEqual(["path", "/this/is/here", "prop"]);
  });

  it("parse json path with ~ characters", () => {
    expect(parseJsonPointer("/path/this~0is~0here/prop")).toEqual(["path", "this~is~here", "prop"]);
  });

  describe("getFromJsonPointer()", () => {
    const examples = {
      foo: ["bar", "baz"],
      bar: { baz: 10 },
      "": 0,
      "a/b": 1,
      "c%d": 2,
      "e^f": 3,
      "g|h": 4,
      "i\\j": 5,
      'k"l': 6,
      " ": 7,
      "m~n": 8,
    };

    const expectedValues = {
      "": examples,
      "/foo": examples.foo,
      "/foo/0": "bar",
      "/bar": examples.bar,
      "/bar/baz": 10,
      "/": 0,
      "/a~1b": 1,
      "/c%d": 2,
      "/e^f": 3,
      "/g|h": 4,
      "/i\\j": 5,
      '/k"l': 6,
      "/ ": 7,
      "/m~0n": 8,
    };

    it("should work for root element", () => {
      const obj = {};
      expect(getFromJsonPointer(obj, "")).toEqual(obj);
    });

    it("should do examples", () => {
      for (const [key, expectedValue] of Object.entries(expectedValues)) {
        expect(getFromJsonPointer(examples, key)).toEqual(expectedValue);
      }
    });
  });
});
