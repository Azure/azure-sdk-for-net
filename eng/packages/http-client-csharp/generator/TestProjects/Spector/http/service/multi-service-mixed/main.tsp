import "@typespec/versioning";
import "@typespec/http";
import "@typespec/spector";

using Versioning;
using Http;
namespace Service.MultiService;


/*
 * First service definition in a multi-service package with versioning
 */
@versioned(VersionsA)
namespace ServiceA {
  enum VersionsA {
    av1,
    av2,
  }

  model FooModel {
    fooProp: string;
  }

  @route("/test")
  op testA(@query("api-version") apiVersion: VersionsA): FooModel;

  @route("foo")
  interface Foo {
    @route("/test")
    testB(@query("api-version") apiVersion: VersionsA): FooModel;
  }
}

/**
 * Second service definition in a multi-service package with versioning
 */
@versioned(VersionsB)
namespace ServiceB {
  enum VersionsB {
    bv1,
    bv2,
  }

  model BarModel {
    barProp: string;
  }

  @route("/test")
  op testC(@query("api-version") apiVersion: VersionsB): BarModel;

  @route("bar")
  interface Bar {
    @route("/test")
    testD(@query("api-version") apiVersion: VersionsB): BarModel;
  }
}