using Menu.Domaine;
using Menu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TP01_Menu.Tests
{
    public class TestMenuInfrastructure
    {

        [Fact]
        public void ObtenirToutes_ApresAjout_RestePareil()
        {
            DepotMenuMemoire depot = new();
            depot.Ajouter(new ElementMenu(1, "Soupe", 6.50m, true));
            var depotCopie = depot.ObtenirToutes();

            depot.Ajouter(new ElementMenu(2, "Sandwich", 9.00m, true));

            Assert.Equal(1, depotCopie.Count);
        }

        [Fact]
        public void Rechercher_FragmentPasComplet_RetourneBonElement()
        {
            DepotMenuMemoire depot = new();
            depot.Ajouter(new ElementMenu(1, "Soupe", 6.50m, true));
            depot.Ajouter(new ElementMenu(2, "Sandwich", 9.00m, true));
            depot.Ajouter(new ElementMenu(3, "Eau", 0m, true));

            ElementMenu[] resultat = depot.Rechercher("sOu").ToArray();

            Assert.Equal(1, resultat.Length);
            Assert.Equal("Soupe", resultat[0].m_nom);
        }
        [Fact]
        public void Rechercher_NomPasPresent_RetourneVide()
        {
            DepotMenuMemoire depot = new();
            depot.Ajouter(new ElementMenu(1, "Soupe", 6.50m, true));

            var resultat = depot.Rechercher("Pizza");

            Assert.Equal(0, resultat.Count);
        }

        [Fact]
        public void Ajouter_NumeroDejaPresent_LanceException()
        {
            DepotMenuMemoire depot = new();
            ElementMenu premier = new(1, "Soupe", 6.50m, true);
            depot.Ajouter(premier);

            Assert.Throws<InvalidOperationException>(() => depot.Ajouter(new ElementMenu(1, "Sandwich", 9.00m, true)));
        }
    }
}