namespace Databases

open Models

type SimpleStore<'t>() =
    let mutable store: 't list = []

    member _.Save data = 
        store <- data

    member _.LoadAll() = store

