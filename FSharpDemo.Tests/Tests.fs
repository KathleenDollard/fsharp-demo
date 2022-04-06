module Tests

open System
open Xunit
open Models
open Databases

//let store = SimpleStore()
//let save = store.Save
//let load = store.LoadAll

//// this is a temporary hack
//let storeEmployee = SimpleStore<Employee>()
//let saveEmployee = storeEmployee.Save
//let loadEmployee = storeEmployee.LoadAll

let Storage<'t> = 
    let store = SimpleStore<'t>()
    store.Save, store.LoadAll


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


[<Fact>]
let ``Can create an employee`` () =

    let emp = Employee (Person.Create 1 "Fred" "Jones")

    Assert.Equal((Employee.Person emp).GivenName, "Fred")

[<Fact>]
let ``Can create an employee that is a manager`` () =
    let manager = Manager (Person.TestData[1], [])

    Assert.Equal((Employee.Person manager).GivenName, "Sally")

[<Fact>]
let ``Can create an manager with employees`` () =
    let manager = Manager (Person.TestData[1], 
        [ Employee (Person.TestData[0])
          Employee (Person.Create 3 "Ben" "Brown")])

    Assert.Equal((Employee.Person manager).GivenName, "Sally")


[<Fact>]
let ``Can save and load persons`` () =
    let persons = Person.TestData

    let save, load = Storage<Person>
    save persons
    let reloaded = load()

    Assert.Equal<Person>(persons, reloaded)


[<Fact>]
let ``Can save and load employees`` () =
    let emps = 
        [ for p in Person.TestData do 
            Employee p ]

    let save, load = Storage<Employee>
    save emps
    let reloaded = load()

    Assert.Equal<Employee>(emps, reloaded)


[<Fact>]
let ``Can save and load persons via Json`` () =
    let persons = Person.TestData

    save persons
    let reloaded = load()

    Assert.Equal<Person>(persons, reloaded)


[<Fact>]
let ``Can save and load employees via Json`` () =
    let emps = 
        [ for p in Person.TestData do 
            Employee p ]

    save emps
    let reloaded = load()

    Assert.Equal<Employee>(emps, reloaded)
