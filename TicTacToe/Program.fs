open System


let board = Array2D.create 3 3 ' ' // Tablero del juego
let mutable turn = 1 // Lleva cuenta del turno actual (X = 1, O = 2)
let mutable gameEnd = false // Indica si el juego ha terminado o no
let mutable stop = false // Indica si el jugador debe repetir su jugada
let mutable row = 0
let mutable col= 0

let DrawBoard () =
    Console.Clear ()
    printfn " %c | %c | %c " board.[0, 0] board.[0, 1] board.[0, 2]
    printfn "---+---+---"
    printfn " %c | %c | %c " board.[1, 0] board.[1, 1] board.[1, 2]
    printfn "---+---+---"
    printfn " %c | %c | %c " board.[2, 0] board.[2, 1] board.[2, 2]
    printfn ""


let CheckWin () =
    let mutable sw = 0
    // Verificar filas
    for i = 0 to 2 do
        if board.[i, 0] = board.[i, 1] && board.[i, 1] = board.[i, 2] && board.[i, 0] <> ' ' then
            sw <- 1

    // Verificar columnas
    for j = 0 to 2 do
        if board.[0, j] = board.[1, j] && board.[1, j] = board.[2, j] && board.[0, j] <> ' ' then
            sw <- 1

    // Verificar diagonal principal
    if board.[0, 0] = board.[1, 1] && board.[1, 1] = board.[2, 2] && board.[0, 0] <> ' ' then
        sw <- 1

    // Verificar diagonal secundaria
    if board.[0, 2] = board.[1, 1] && board.[1, 1] = board.[2, 0] && board.[0, 2] <> ' ' then
        sw <- 1

    
    if sw = 1 then
        // Si hay ganador, retornar true
        true
    else
        // Si no hay ganador, retornar false
        false

let CheckTie () =
    let mutable sw = 0
    for i = 0 to 2 do
        for j = 0 to 2 do
            if board.[i, j] = ' ' then
                sw <- 1
    if sw = 0 then
        true
    else
        false

let GetData () =
     printfn "Es el turno de %s" (if turn = 1 then "X" else "O")
     printf "Ingrese la fila (0-2): "
     row <- Int32.Parse(Console.ReadLine())
     printf "Ingrese la columna (0-2): "
     col <- Int32.Parse(Console.ReadLine())


let switchShift () =
    if not gameEnd then
        turn <- if turn = 1 then 2 else 1


for i = 0 to 2 do
    for j = 0 to 2 do
        board.[i, j] <- ' '

// Ciclo principal del juego
while not gameEnd do
  
    if not stop then
        DrawBoard() // Dibujar el tablero
        GetData()

        // Validar la jugada 
        if row < 0 || row > 2 || col < 0 || col > 2 then
            stop <- true
            printfn "Jugada inválida. Intente de nuevo."
            ()
        elif board.[row,col] <> ' ' then
            stop <- true
            printfn "Casilla ocupada. Intente de nuevo."
            ()

        // Registrar la jugada
        if not stop then
            board.[row,col] <- if turn = 1 then 'X' else 'O'

            stop <- false
            if CheckWin() then
                DrawBoard()
                printfn "¡%s ha ganado!" (if turn = 1 then "X" else "O")
                gameEnd <- true
            elif CheckTie() then
                DrawBoard()
                printfn "¡Empate!"
                gameEnd <- true
                else 
                switchShift()
        elif stop then
            GetData()
            stop <- false


   
   



