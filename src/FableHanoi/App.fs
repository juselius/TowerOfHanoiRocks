module FsHanoi

open Fable.Core
open Fable.Helpers.React
open Elmish
open Elmish.React

type Model = {
    hanoi : string    
    }

type Msg =
    | Run

let init () : Model * Cmd<Msg> =
    { hanoi = "" }, Cmd.none

let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    model, Cmd.none

let view (model : Model) (dispatch : Msg -> unit) =
    div [] []

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