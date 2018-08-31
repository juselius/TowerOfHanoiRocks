namespace FsHanoi 

module Widgets =
    open Fable.Helpers.React
    open Fulma

    let navbar = 
        Navbar.navbar [ Navbar.Color Color.IsPrimary ] [ 
            Navbar.Item.div [] [ Heading.h4 [ 
                 Heading.Modifiers [ Modifier.TextColor IsWhite ]
            ] [ str "FizzBuz in Hanoi" ] ] 
        ]

    let footer =
        Footer.footer [] [ 
            Content.content [ 
                Content.Modifiers [ 
                    Modifier.TextAlignment 
                        (Screen.All, TextAlignment.Centered) 
                ] 
            ] [ str "May the foo be with you!" ] 
        ] 