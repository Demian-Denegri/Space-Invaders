using SpaceInvader;

NaveDefensora naveDefensora = new NaveDefensora((Console.WindowWidth / 2) - 1, Console.WindowHeight - 1);
bool salir = false;

while (!salir)
{
    

    naveDefensora.Imprimir();
    ConsoleKeyInfo teclado = Console.ReadKey(true);
    switch (teclado.Key)
    {
        case ConsoleKey.D:
            naveDefensora.Borrar();
            naveDefensora.MoverDerecha();
            break;
        case ConsoleKey.A:
            naveDefensora.Borrar();
            naveDefensora.MoverIzquierda();
            break;
        case ConsoleKey.Escape: 
            salir = true;
            break;
    }

    
}