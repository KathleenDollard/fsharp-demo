namespace Databases

open Models

type SimpleStore() =
    let mutable store: Person list = []

    member _.Save data = 
        store <- data

    member _.LoadAll() = store

