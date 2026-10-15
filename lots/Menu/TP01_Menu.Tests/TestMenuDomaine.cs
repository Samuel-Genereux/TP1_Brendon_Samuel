using Menu.Domaine;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TP01_Menu.Tests
{
    public class TestMenuDomaine
    {
        [Fact]
        public void Constructeur_ValeursValides_CreeObjet()
        {
            ElementMenu element = new ElementMenu(1, "AAA", 10.00m, true);

            Assert.Equal(1, element.m_id);
            Assert.Equal("AAA", element.m_nom);
            Assert.Equal(10.00m, element.m_prix);
            Assert.True(element.m_estDisponible);
        }

        [Fact]
        public void Constructeur_IdNegatif_LanceException()
        {
            Assert.Throws<ArgumentException>(() => new ElementMenu(-1, "AAA", 10.00m, true));
        }
        [Fact]
        public void Constructeur_NomVide_LanceException()
        {
            Assert.Throws<ArgumentException>(() => new ElementMenu(1, "", 10.00m, true));
        }

        [Fact]
        public void Constructeur_PrixNegatif_LanceException()
        {
            Assert.Throws<ArgumentException>(() => new ElementMenu(1, "AAA", -1.00m, true));
        }

        [Fact]
        public void Retirer_ElementDisponible_DevientIndisponible()
        {
            ElementMenu element = new ElementMenu(1, "AAA", 10.00m, true);

            element.Retirer();

            Assert.False(element.m_estDisponible);
        }
        [Fact]
        public void RendreDisponible_ElementIndiponible_DevientDisponible()
        {
            ElementMenu element = new ElementMenu(1, "AAA", 10.00m, false);

            element.RendreDisponible();

            Assert.True(element.m_estDisponible);
        }
        [Fact]
        public void ChangerPrix_PrixValide_ChangeLePrix()
        {
            ElementMenu element = new ElementMenu(1, "AAA", 10.00m, true);

            element.ChangerPrix(15.00m);

            Assert.Equal(15m, element.m_prix);
        }
        [Fact]
        public void ChangerPrix_PrixNegatif_LanceException()
        {
            ElementMenu element = new ElementMenu(1, "AAA", 10.00m, true);

            Assert.Throws<ArgumentException>(() => element.ChangerPrix(-1.00m));
        }
    }
}
