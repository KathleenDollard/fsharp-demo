module Tests

open System
open Xunit
open Models

[<Fact>]
let ``Can create a person`` () =
    let fred = Person.Create 4 "Fred" "Jones"

    Assert.Equal(fred.GivenName, "Fred")

[<Fact>]
let ``Two persons with same data are equal`` () =
    let data1 = Person.Create 1 "Fred" "Jones"
    let data2 = Person.TestData[0]

    Assert.Equal(data1, data2)

[<Fact>]
let ``Two lists with same persons are equal`` () =
    let data1 = 
        [ Person.Create 1 "Fred" "Jones"
          Person.Create 2 "Sally" "Smith" ]
    let data2 = Person.TestData

    Assert.Equal<Person>(data1, data2)

[<Fact>]
let ``Lists of differnt length are not equal`` () =
    let data1 = 
        [ Person.Create 3 "George" "Jones"
          for p in Person.TestData do p ]

    Assert.NotEqual<Person>(data1, Person.TestData)        
