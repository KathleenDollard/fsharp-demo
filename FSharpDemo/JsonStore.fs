namespace Databases


open System.Text.Json.Serialization
open System.Text.Json
open Models

type JsonStore<'t>(fileName) =
    let options = 
         let o = JsonSerializerOptions()
         o.Converters.Add(JsonFSharpConverter())
         o

    let  path = System.IO.Path.Combine(System.Environment.CurrentDirectory, fileName)

    member _.Save data = 
        JsonSerializer.Serialize(data, options)
        |> fun s -> System.IO.File.WriteAllText(path, s)

    member _.LoadAll () =
        JsonSerializer.Deserialize(System.IO.File.ReadAllText path, options)
