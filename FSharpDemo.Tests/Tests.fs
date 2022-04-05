module Tests

open System
open Xunit
open Models

[<Fact>]
let ``Can create a person`` () =
    let fred = 
        { Id = 4
          GivenName = "Fred"
          FamilyName = "Jones" }

    Assert.Equal(fred.GivenName, "Fred")


