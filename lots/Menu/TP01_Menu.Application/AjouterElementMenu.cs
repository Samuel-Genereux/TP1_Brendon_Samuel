using Menu.Domaine;

namespace Menu.Application;

public sealed class AjouterElementMenu
{
    private readonly IDepotMenu m_depotMenu;

    public AjouterElementMenu(IDepotMenu depotMenu)
    {
        ArgumentNullException.ThrowIfNull(depotMenu);
        m_depotMenu = depotMenu;
    }

    // TODO : orchestrer l'ajout et laisser les invariants au domaine.

    public Result<ElementMenu> Creer(int numero, string nom, decimal prix)
    {
        if (numero <= 0)
            return Result<ElementMenu>.Echec("Le numéro doit être plus que 0");

        if (string.IsNullOrWhiteSpace(nom))
            return Result<ElementMenu>.Echec("Le nom peut pas être vide");

        if (prix < 0)
            return Result<ElementMenu>.Echec("Le prix peut pas être négatif");

        if (m_depotMenu.Obtenir(numero) is not null)
            return Result<ElementMenu>.Echec("Numéro doublon");

        ElementMenu element = new(numero, nom, prix, true);
        m_depotMenu.Ajouter(element);

        return Result<ElementMenu>.Succes(element);
    }
}
