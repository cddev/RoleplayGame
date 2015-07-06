using System;

namespace GameEngine
{
    public class AttackEventArgs : EventArgs
    {
        public Personnage Attaquant { get; set; }

        public Personnage Defenseur { get; set; }

        public AttackEventArgs(Personnage _attaq, Personnage _def)
        {
            Attaquant = _attaq;
            Defenseur = _def;
        }
    }
}