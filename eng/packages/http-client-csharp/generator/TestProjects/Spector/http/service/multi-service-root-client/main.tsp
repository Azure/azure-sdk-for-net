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
  op testOne(@query("api-version") apiVersion: VersionsA): FooModel;
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
  op testTwo(@query("api-version") apiVersion: VersionsB): BarModel;
}