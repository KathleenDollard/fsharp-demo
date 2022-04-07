namespace FSharpDemo

namespace Models

type Person =
    { Id: int
      GivenName: string
      FamilyName: string }

type PersonClass(id: int, givenName: string,familyName: string) =
    member _.Id = id
    member this.GivenName = givenName
    member this.FamilyName = familyName

