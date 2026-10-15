using Menu.Application;
using Menu.Domaine;

namespace Menu.Infrastructure;

public sealed class DepotMenuMemoire : IDepotMenu
{
    // TODO : choisir une collection privée et protéger ses accès.
    private readonly Dictionary<int, ElementMenu> m_elements = new();
    public void Ajouter(ElementMenu element)
    {
        ArgumentNullException.ThrowIfNull(element);

        if (!m_elements.TryAdd(element.m_id, element))
        {
            throw new InvalidOperationException("Numéro doublon");
        }
    }

    public ElementMenu? Obtenir(int numero)
    {
        if (numero <= 0)
            throw new ArgumentException("Un numero peut pas être négatif");
        

        return m_elements.GetValueOrDefault(numero);
    }

    public IReadOnlyCollection<ElementMenu> ObtenirToutes()
    {
        return m_elements.Values.ToArray();
    }

    public IReadOnlyCollection<ElementMenu> Rechercher(string fragment)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fragment);

        List<ElementMenu> resultat = new();

        foreach (ElementMenu element in m_elements.Values)
        {
            if (element.m_nom.Contains(fragment, StringComparison.OrdinalIgnoreCase))
            {
                resultat.Add(element);
            }
        }

        return resultat;
    }
}
