import { serializeJsonPointer } from "../json-pointer/json-pointer";
import { walk } from "./traverse";

describe("Traverse", () => {
  describe("walk", () => {
    const obj = {
      id: 123,
      user: {
        name: "Foo",
        address: {
          city: "Seattle",
        },
      },
    };

    it("walk nested object", () => {
      const visited: Record<string, any> = {};
      walk(obj, (value, path) => {
        visited[serializeJsonPointer(path)] = value;
        return "visit-children";
      });
      expect(Object.keys(visited).length).toEqual(6);
      expect(visited[""]).toEqual(obj);
      expect(visited["/id"]).toEqual(123);
      expect(visited["/user"]).toEqual(obj.user);
      expect(visited["/user/name"]).toEqual(obj.user.name);
      expect(visited["/user/address"]).toEqual(obj.user.address);
      expect(visited["/user/address/city"]).toEqual(obj.user.address.city);
    });

    it("stop walking when asked to", () => {
      const visited: Record<string, any> = {};
      walk(obj, (value: any, path) => {
        visited[serializeJsonPointer(path)] = value;
        return value.city ? "stop" : "visit-children";
      });
      expect(Object.keys(visited).length).toEqual(5);
      expect(visited["/id"]).toEqual(123);
      expect(visited["/user"]).toEqual(obj.user);
      expect(visited["/user/name"]).toEqual(obj.user.name);
      expect(visited["/user/address"]).toEqual(obj.user.address);
      expect(visited["/user/address/city"]).toBeUndefined();
    });
  });
});
