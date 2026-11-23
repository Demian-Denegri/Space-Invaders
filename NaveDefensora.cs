namespace SpaceInvader
{
    internal class NaveDefensora : Nave
    {
        public NaveDefensora(int x, int y) : base(x, y)
        {
        }
        protected override char ObtenerChar()//icono de la nave
        {
            return 'A';

        }
        public void MoverIzquierda()
        {
            if (this.X > 3)
            {
                this.X--;
            }

        }
        public void MoverDerecha()
        {
            if (this.X < Console.WindowWidth - 3)
            {
                this.X++;
            }

        }
        public NaveProyectil Disparar()
        {
            NaveProyectil naveProyectil = new(this.X, this.Y - 1, true);// ture apra que suba el proyectil
            return naveProyectil;
        }
        public void Muerte(int proyectilX, int proyectilY)
        {
            if ((proyectilX == this.X) && (proyectilY == this.Y))
            {
                throw new Exception("error");
            }

        }


    }
}
