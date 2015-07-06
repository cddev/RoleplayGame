namespace GameEngine
{
    public class Hero : Personnage
    {
        public Hero(string nom, int pv, Arme wp) : base(nom, pv, wp)
        {
            base.NomPers = nom;
            base.PvPers = pv;
            base.WpPers = wp;
        }

        public override string ToString()
        {
            return "Héro: " + base.NomPers + " PV:" + base.PvPers.ToString() + "\n---" + base.WpPers.ToString();
        }
    }
}