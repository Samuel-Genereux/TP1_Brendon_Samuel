using Menu.Application;
using Menu.Domaine;
using Menu.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TP01_Menu.Tests
{
    public class TestMenuApplication
    {
        [Fact]
        public void Creer_DonneesValides_RetourneSucces()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);

            Result<ElementMenu> resultat = service.Creer(1, "Soupe", 6.50m);

            Assert.True(resultat.EstSucces);
        }
        [Fact]
        public void Creer_PrixZero_RetourneSucces()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);

            Result<ElementMenu> resultat = service.Creer(3, "Eau", 0m);

            Assert.True(resultat.EstSucces);
        }

        [Fact]
        public void Creer_NumeroZero_RetourneEchec()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);

            Result<ElementMenu> resultat = service.Creer(0, "Soupe", 6.50m);

            Assert.False(resultat.EstSucces);
        }
        [Fact]
        public void Creer_NomVide_RetourneEchec()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);

            Result<ElementMenu> resultat = service.Creer(1, " ", 6.50m);

            Assert.False(resultat.EstSucces);
        }

        [Fact]
        public void Creer_PrixNegatif_RetourneEchec()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);

            Result<ElementMenu> resultat = service.Creer(1, "Soupe", -0.01m);

            Assert.False(resultat.EstSucces);
        }
        [Fact]
        public void Creer_NumeroDejaUtilise_RetourneEchec()
        {
            DepotMenuMemoire depot = new();
            AjouterElementMenu service = new(depot);
            Result<ElementMenu> premier = service.Creer(1, "Soupe", 6.50m);

            Result<ElementMenu> deuxieme = service.Creer(1, "Sandwich", 9.00m);

            Assert.False(deuxieme.EstSucces);
        }
    }
}
