module Databases.StorageFactory

type StorageKinds =
    | Json of fileName: string
    | Simple

let StorageMethods<'t>(kind) =
    match kind with
    | Simple -> 
        let store = SimpleStore<'t>()
        (store.Save, store.LoadAll)
    | Json fileName -> 
        let store = JsonStore<'t>(fileName)
        (store.Save, store.LoadAll)
    | _ -> invalidOp "Unsupported storage type"
