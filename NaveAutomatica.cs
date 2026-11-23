using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceInvader
{
    abstract class NaveAutomatica : Nave
    {
        
        protected NaveAutomatica(int x, int y) : base(x, y)
        {
        }
        public abstract void Mover();
    }
}
