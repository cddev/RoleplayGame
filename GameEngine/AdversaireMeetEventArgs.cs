using System;

namespace GameEngine
{
    public class AdversaireMeetEventArgs : EventArgs
    {
        public Personnage p1 { get; set; }

        public Personnage p2 { get; set; }

        public AdversaireMeetEventArgs(Personnage _p1, Personnage _p2)
        {
            p1 = _p1;
            p2 = _p2;
        }
    }
}