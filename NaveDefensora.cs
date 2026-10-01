using System;
using System.Collections.Generic;
using System.Text;

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
            this.X--;
        }
        public void MoverDerecha()
        {
            this.X++;
        }
        public void Disparara()
        {

        }


    }
}
