namespace SpaceInvader
{
    internal class NaveProyectil : NaveAutomatica
    {
        public bool direccion { get; set; }
        public NaveProyectil(int x, int y, bool direccion) : base(x, y)
        {
            this.direccion = direccion;
        }
        public override void Mover()
        {
            if (this.Y > 0 && this.direccion == true)//sube
            {
                Borrar();
                this.Y--;
                Imprimir();
            }
            else if (this.Y < Console.WindowHeight - 1 && this.direccion == false)//baja
            {
                Borrar();
                this.Y++;
                Imprimir();
            }


        }

        protected override char ObtenerChar()
        {
            return '|';
        }
        public static void borrarProyectil(List<NaveProyectil> proyectiles, int ultimaFila) // borra de la lista los proyectiles que exeden el tamaño de pantalla
        {
            for (int i = 0; i < proyectiles.Count; i++)// borrar proyectiles que no dieron a nada
            {
                if (proyectiles[i].Y == 0 || proyectiles[i].Y == ultimaFila)
                {
                    Console.SetCursorPosition(proyectiles[i].X, proyectiles[i].Y);
                    Console.Write(' ');
                    proyectiles.RemoveAt(i);
                }

            }
        }
    }
}

