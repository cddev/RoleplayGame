using System;

namespace GameEngine
{
    public class AdversaireKilledEventArgs : EventArgs
    {
        public Personnage AdvKilled { get; set; }

        public AdversaireKilledEventArgs(Personnage _advkilled)
        {
            AdvKilled = _advkilled;
        }
    }
}