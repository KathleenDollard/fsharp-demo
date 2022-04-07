namespace FSharpDemo

namespace Models

type Person =
    { Id: int
      GivenName: string
      FamilyName: string }

type PersonClass(name: string) =
    member this.Name = name

