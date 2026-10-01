using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    abstract class Nave
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Nave(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        protected abstract char ObtenerChar();
        public void Borrar()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(' ');
        }
        public void Imprimir()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(ObtenerChar());
        }

    }
}
