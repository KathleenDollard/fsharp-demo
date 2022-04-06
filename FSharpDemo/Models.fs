namespace FSharpDemo

namespace Models

type Person =
    { Id: int
      GivenName: string
      FamilyName: string
      IsFamilyNameFirst: bool }

    member this.FullName =
        if this.IsFamilyNameFirst then
            $"{this.FamilyName} {this.GivenName}"
        else
            $"{this.GivenName} {this.FamilyName}"

    static member Create id givenName familyName =
        { Id = id
          GivenName = givenName
          FamilyName = familyName
          IsFamilyNameFirst= false }

    static member TestData =
        [ Person.Create 1 "Fred" "Jones"
          Person.Create 2 "Sally" "Smith" ]