using GameEngine;
using System;
using System.Collections.Generic;

namespace ConsoleInterface
{
    internal class Program
    {
        private static List<Equipe> EquipeList { get; set; }

        private static List<Personnage> PersHeroList { get; set; }

        private static List<Personnage> PersMonstreList { get; set; }

        private static List<Personnage> DeadPersList { get; set; }

        private static void Main(string[] args)
        {
            EquipeList = new List<Equipe>();
            PersHeroList = new List<Personnage>();
            PersMonstreList = new List<Personnage>();
            DeadPersList = new List<Personnage>();

            PersHeroList.AddRange(new List<Personnage> { new Hero("Lancelot", 30, new Epee("Gridur", 5, 10)),
                                                     new Hero("Arthur", 30, new Epee("Excalibur", 15, 20)),
                                                     new Hero("Karadoc", 20, new Epee("Couteau a saucisson", 23, 4)),
                                                     new Hero("Perceval", 30, new Epee("Bah j'lai oubliée", 16, 2)),
                                                     new Hero("Léodagan", 30, new Epee("MA MAIN", 15, 2)),
                                                    });
            PersMonstreList.AddRange(new List<Personnage> { new Monstre("Troll", 30, new Gourdin("Masse", 5, 10)),
                                                     new Monstre("Gobelin", 30, new Gourdin("Hache", 15, 20)),
                                                     new Monstre("Cthulhu", 15, new Gourdin("Ta peur", 20, 4)),
                                                     new Monstre("Orque", 11, new Gourdin("Fléau", 10, 2)),
                                                     new Monstre("Dragon", 11, new Gourdin("Flamme", 10, 2)),
                                                    });
            foreach (Personnage p in PersHeroList)
            {
                p.Attacking += P_Attacking;
                p.Killing += P_Killing;
            }
            foreach (Personnage p in PersMonstreList)
            {
                p.Attacking += P_Attacking;
                p.Killing += P_Killing;
            }
            EquipeList.Add(new Equipe("Les Gentils", PersHeroList));
            EquipeList.Add(new Equipe("Les Mechants", PersMonstreList));

            foreach (Equipe e in EquipeList)
            {
                e.MeetAdversaire += Program_MeetAdversaire;
                e.TeamWon += E_TeamWon;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_-==Bienvenue a Kaamelott==-_");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(PrintData(EquipeList));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Appuyez sur une touche pour démarrer ");
            Console.ResetColor();
            Console.ReadKey();
            foreach (Equipe e in EquipeList)
            {
                e.Rencontre(EquipeList, PersHeroList, PersMonstreList);
            }
        }

        private static void E_TeamWon(object sender, WinningEventArgrs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("L'équipe {0} à gagné", e.wTeam);
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void P_Killing(object sender, AdversaireKilledEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} est mort", e.AdvKilled.NomPers);
            Console.ResetColor();
            e.AdvKilled.isDead = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (e.AdvKilled is Hero)
            {
                PersHeroList.Remove(e.AdvKilled);

                Console.WriteLine("il reste {0} Héros", PersHeroList.Count.ToString());
            }
            else
            {
                PersMonstreList.Remove(e.AdvKilled);
                Console.WriteLine("il reste {0} Monstres", PersMonstreList.Count.ToString());
            }
            Console.ResetColor();
            foreach (Equipe eq in EquipeList)
            {
                eq.LPersonnage.Remove(e.AdvKilled);
                DeadPersList.Add(e.AdvKilled);
            }
            Console.ReadKey();
            Console.ResetColor();
        }

        private static void P_Attacking(object sender, AttackEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} attaque {1}", e.Attaquant.NomPers, e.Defenseur.NomPers);
            e.Defenseur.PvPers = e.Defenseur.PvPers - e.Attaquant.WpPers.DmgPointArme;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} perd {1} il lui reste {2} PV", e.Defenseur.NomPers, e.Attaquant.WpPers.DmgPointArme, e.Defenseur.PvPers);
            Console.ResetColor();
            if (e.Defenseur.PvPers <= 0)
            {
                e.Attaquant.Killed(e.Defenseur);
            }
            Console.ResetColor();
        }

        private static void Program_MeetAdversaire(object sender, AdversaireMeetEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("RENCONTRE: \n {0} \n {1} ", e.p1.ToString(), e.p2.ToString());
            Console.ResetColor();
            Personnage PersAttaquant = Equipe.chooseRandomAttacker(new List<Personnage> { e.p1, e.p2 });
            if (PersAttaquant.Equals(e.p1))
            {
                PersAttaquant.Attaque(e.p2);
            }
            else
            {
                PersAttaquant.Attaque(e.p1);
            }
        }

        private static string PrintData(List<Equipe> _EquipeList)
        {
            string _ret = "Equipe et Personnages:\n";
            foreach (Equipe e in _EquipeList)
            {
                _ret += "--" + e.ToString();
            }
            return _ret;
        }
    }
}