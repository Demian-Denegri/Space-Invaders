using SpaceInvader;

NaveDefensora naveDefensora = new NaveDefensora((Console.WindowWidth / 2) - 1, Console.WindowHeight - 1);
bool salir = false;
List<NaveProyectil> proyectiles = new();//creo lista de proyectiles(aliados y enemigos)
List<NaveInvasora> invasoras = new();//creo lista de naves invasoras
int columnas = 2;
int filas = 20;
NaveInvasora.CrearInvasoras(invasoras, columnas, filas);//creo el ggrupo de naves
int cuadros = 30;
int fpsInvasora = 80;
int fpsProyectiles = 80;
int ultimaFila = Console.WindowHeight - 1;
while (!salir)
{
    cuadros++;

    NaveInvasora.Direccion(invasoras);
    if ((cuadros % fpsInvasora) == 0)//fps de movimiento de las naves invasoras
    {
        for (int i = 0; i < invasoras.Count; i++)//recorro lista de navesInvasoras
        {
            invasoras[i].Mover();//muestro y muevo naves invasoras

            Random random = new();
            int num = random.Next(1, 50);
            int dispara = num % 15;
            if ((!invasoras[i].TieneAliadaAbajo(invasoras) && dispara == 0))// condicion para cuando se dispara o no
            {
                proyectiles.Add(invasoras[i].Disparar());//disparo individual
            }


        }

    }

    naveDefensora.Imprimir();
    if (Console.KeyAvailable)
    {
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
            case ConsoleKey.Spacebar:
                proyectiles.Add(naveDefensora.Disparar());
                break;
            case ConsoleKey.Escape:
                salir = true;
                break;
        }
    }

    if ((cuadros % fpsProyectiles) == 0)
    {
        foreach (NaveProyectil proyectil in proyectiles)// mover los proyectiles y dibujar
        {
            proyectil.Mover();//mueve un proyectil individual
            naveDefensora.Muerte(proyectil.X, proyectil.Y);// termina el juego cunado impacta un proyectil
        }
        NaveProyectil.borrarProyectil(proyectiles, ultimaFila);// borra los proyectiles que lelgan al final de la pantalla
        NaveInvasora.NaveEliminada(invasoras, proyectiles);
    }

}