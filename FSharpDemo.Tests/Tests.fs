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

[<Fact>]
let ``Can create an instance of PersonClass`` () =
    let fred = PersonClass(
        4, 
        "Fred",
        "Jones" )

    Assert.Equal(fred.GivenName, "Fred")


