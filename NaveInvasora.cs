namespace SpaceInvader
{
    internal class NaveInvasora : NaveAutomatica
    {

        public NaveInvasora(int x, int y) : base(x, y)
        {

        }
        protected override char ObtenerChar()
        {
            return '#';
        }
        public static void CrearInvasoras(List<NaveInvasora> listaInvasoras, int filas, int columnas)//static para podes llamarlo sin tener que tener una nave ya creada
        {
            for (int i = 0; i < columnas; i++)//X
            {
                for (int j = 0; j < filas; j++)//Y
                {
                    listaInvasoras.Add(new NaveInvasora(2 + i * 2, 2 + j * 2));
                }
            }
        }
        public static bool direccion = true;//true = derecha, false = izquierda
        public static bool choque = false;
        public static void Direccion(List<NaveInvasora> listaInvasoras)
        {
            choque = false;
            for (int i = 0; i < listaInvasoras.Count; i++)//X
            {

                if (listaInvasoras[i].X >= Console.WindowWidth - 3)//pared derecha
                {
                    direccion = false;//va a la izquierda
                    choque = true;
                }
                else if (listaInvasoras[i].X <= 1)// pared izquierda
                {
                    direccion = true;//va a la derecha
                    choque = true;
                }
            }
        }

        public override void Mover()
        {
            Borrar();
            if (direccion)
            {
                this.X++;//mueve derecha
            }
            else
            {
                this.X--;//mueve izquierda
            }
            if (choque)//baja una linea
            {
                this.Y++;
            }

            Imprimir();
        }
        public bool TieneAliadaAbajo(List<NaveInvasora> invasoras)//logica que comprueva si hay un aliado debajo de una invasora
        {
            return invasoras.Any(inv => inv.X == this.X && (inv.Y > this.Y));

        }
        public NaveProyectil Disparar()
        {
            NaveProyectil naveProyectil = new(this.X, this.Y + 1, false);//false apra que baje el proyectil
            return naveProyectil;
        }
        public static void NaveEliminada(List<NaveInvasora> invasoras, List<NaveProyectil> proyectiles) // elimino los proyectiles que impactaron
        {
            for (int i = invasoras.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < proyectiles.Count; j++)
                {

                    if (proyectiles[j].direccion == true &&
                        proyectiles[j].X == invasoras[i].X &&
                        proyectiles[j].Y == invasoras[i].Y)
                    {
                        invasoras[i].Borrar();
                        invasoras.RemoveAt(i);
                        proyectiles[j].Borrar();
                        proyectiles.RemoveAt(j); // remuevo el proyectil que dio el impacto
                        break;
                    }
                }
            }
        }
    }
}
