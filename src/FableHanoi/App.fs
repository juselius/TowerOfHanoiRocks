namespace FsHanoi

module Hanoi =
    open Fable.Core
    open Fable.Helpers.React
    open Elmish
    open Elmish.React
    open TowerOfHanoi
    open Fulma

    type Model = {
        nDisks : int    
        nFizz : int    
        }

    type Msg =
        | More
        | Less

    let init () : Model * Cmd<Msg> =
        let model = { 
            nDisks = 3 
            nFizz = 20
            }
        model, Cmd.none

    let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
        match msg with
        | More -> 
            let model' = {
                nDisks = model.nDisks + 1
                nFizz = model.nFizz + 5
            }
            model', Cmd.none
        | Less -> 
            let model' = {
                nDisks = if model.nDisks > 0 then model.nDisks - 1 else 0
                nFizz = if model.nFizz > 5 then model.nFizz - 5 else 0
            }
            model', Cmd.none

    let view (model : Model) (dispatch : Msg -> unit) =
        div [] [
            Views.navbar
            Container.container [] [
                Content.content [] [
                    h2 [] [ str "Hello Hanoi!" ]
                    ul [] ( 
                        moveTower model.nDisks |> List.map (fun (n, f, t) -> 
                            li [] [ 
                                sprintf "Move %d from %d to %d" n f t |> str 
                            ])
                    )
                    h2 [] [ str "Hello Fizzbuzz!" ]
                    Box.box' [] [
                        ul [] ( 
                            fizzbuzz model.nFizz |> List.map (fun s -> 
                                li [] [ str s ])
                        )
                    ]
                ]
                Button.button [ 
                    Button.OnClick (fun _ -> dispatch More) 
                    Button.Color IsPrimary
                    ] [ str "More!"] 
                str " "
                Button.button [ 
                    Button.OnClick (fun _ -> dispatch Less) 
                    Button.Color IsWarning
                    ] [ str "Less"] 
                br []
            ]
            Views.footer
        ]

    #if DEBUG
    open Elmish.Debug
    open Elmish.HMR
    #endif

    Program.mkProgram init update view
    #if DEBUG
    |> Program.withConsoleTrace
    |> Program.withHMR
    #endif
    |> Program.withReact "elmish-app"
    #if DEBUG
    |> Program.withDebugger
    #endif
    |> Program.run