namespace GameEngine
{
    public class Monstre : Personnage
    {
        public Monstre(string nom, int pv, Arme wp) : base(nom, pv, wp)
        {
        }

        public override string ToString()
        {
            return "Monstre: " + base.NomPers + " PV: " + base.PvPers.ToString() + "\n---" + base.WpPers.ToString(); ;
        }
    }
}