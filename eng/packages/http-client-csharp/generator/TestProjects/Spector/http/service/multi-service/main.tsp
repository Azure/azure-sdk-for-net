import "@typespec/versioning";
import "@typespec/http";
import "@typespec/spector";

using Versioning;
using Http;
using Spector;

namespace Service.MultiService;

/*
 * First service definition in a multi-service package with versioning
 */
@scenarioService("/service/multi-service/service-a")
@versioned(VersionsA)
namespace ServiceA {
  enum VersionsA {
    av1,
    av2,
  }

  model FooModel {
    fooProp: string;
  }

  @route("foo")
  interface Foo {
    @scenario
    @route("/test")
    test(@query("api-version") apiVersion: VersionsA): FooModel;
  }
}

/**
 * Second service definition in a multi-service package with versioning
 */
@scenarioService("/service/multi-service/service-b")
@versioned(VersionsB)
namespace ServiceB {
  enum VersionsB {
    bv1,
    bv2,
  }

  model BarModel {
    barProp: string;
  }

  @route("bar")
  interface Bar {
    @route("/test")
    test(@query("api-version") apiVersion: VersionsB): BarModel;
  }
}