module Tests

open System
open Xunit
open Models

[<Fact>]
let ``Can create a person`` () =
    let fred = Person.Create 4 "Fred" "Jones"

    Assert.Equal(fred.GivenName, "Fred")


