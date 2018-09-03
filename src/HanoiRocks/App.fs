namespace HanoiRocks

module Hanoi =
    open Fable.Helpers.React
    open Elmish
    open Elmish.React
    open Fulma
    open View

    let init () : Model * Cmd<Msg> =
        { nDisks = 3; nBuzz = 15; hello = "" }, Cmd.none

    let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
        match msg with
        | More -> 
            let model' = 
                { model with
                    nDisks = model.nDisks + 1
                    nBuzz = model.nBuzz + 5
                }
            model', Cmd.none
        | Less -> 
            let model' = 
                { model with
                    nDisks = if model.nDisks > 0 then model.nDisks - 1 else 0
                    nBuzz = if model.nBuzz > 5 then model.nBuzz - 5 else 5
                }
            model', Cmd.none
        | Hello s -> {model with hello = s}, Cmd.none

    let view (model : Model) (dispatch : Msg -> unit) =
        div [] [ 
            View.navbar 
            Container.container [] [
                hanoiBuzz model dispatch
            ]
            View.footer
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