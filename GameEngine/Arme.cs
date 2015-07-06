namespace GameEngine
{
    public abstract class Arme
    {
        public string NomArme { get; set; }

        public int DmgPointArme { get; set; }

        //public int AssetArme { get; set; }

        public Arme()
        {
            DmgPointArme = 0;
            //AssetArme = 0;
        }

        public Arme(string _nomArme, int _damPointArme /*,int _assetArme*/)
        {
            NomArme = _nomArme;
            DmgPointArme = _damPointArme;
            // AssetArme = _assetArme;
        }

        public override string ToString()
        {
            return " " + base.ToString() + " Nom: " + NomArme + " Dmg: " + DmgPointArme.ToString();
        }
    }
}