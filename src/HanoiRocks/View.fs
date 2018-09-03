namespace HanoiRocks

module View =
    open Fable.Helpers.React
    open Fulma


    type Model = {
        nDisks : int
        nBuzz : int
        hello : string
    }

    type Msg = 
        | More 
        | Less
        | Hello of string

    let navbar =
        Navbar.navbar [ Navbar.Color Color.IsPrimary ] [
            Navbar.Item.div [] [ Heading.h4 [
                 Heading.Modifiers [ Modifier.TextColor IsWhite ]
            ] [ str "FizzBuz with Hanoi Rocks" ] ]
        ]

    let footer =
        Footer.footer [] [
            Content.content [
                Content.Modifiers [
                    Modifier.TextAlignment
                        (Screen.All, TextAlignment.Centered)
                ]
            ] [ h4 [] [ str "May the foo be with you!" ] ]
        ]

    let col4 = 
        Column.column [
            Column.Width (Screen.All, Column.Is4) 
        ] 

    let orientalBeat =
        function
        | (s : string) when s.ToLower () = "oriental beat" -> 
            Image.image [ Image.Is128x128 ] [ 
                img [ Props.Src <| "Images/Hanoi-Rocks.jpg" ] 
            ]
        | x -> h4 [] [ str x ]
        

    let hanoiBuzz (model : Model) (dispatch : Msg -> unit) =
        Content.content [] [
        h2 [] [ str "What?" ]
        Control.div [] [
            Input.text [ 
                Input.Placeholder "Echo"
                Input.OnChange <| fun e -> dispatch <| Hello e.Value
            ]
            br []
            orientalBeat model.hello
        ]
        h2 [] [ str "Tower of FizzBuzz" ] 
        Button.button [
            Button.Color IsPrimary
            Button.OnClick (fun _ -> dispatch More)
        ] [str "More!" ]
        Button.button [
            Button.Color IsWarning
            Button.OnClick (fun _ -> dispatch Less)
        ] [str "Less"]
        br []
        Box.box' [] [
            Columns.columns [] [
                col4 [
                ul [] (
                    FsHanoi.TowerOfHanoi.moveTower model.nDisks 
                    |> List.map (fun (n, f, t) -> 
                        li [] [ str <| sprintf "Move %d from %d to %d" n f t])
                    )
                ]
                col4 [
                    ul [] (
                        FsHanoi.Fizz.fizzbuzz model.nBuzz 
                        |> List.map (fun s -> li [] [ str s ])
                    )
                ] 
            ]
        ]
        br []
    ]