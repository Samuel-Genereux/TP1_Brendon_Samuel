namespace Menu.Domaine;

public sealed class ElementMenu
{
    // TODO : définir l'identité, les invariants et les comportements d'un élément.

    public int m_id { get; }
    public string m_nom { get; private set; }
    public decimal m_prix { get; private set; }
    public bool m_estDisponible { get; private set; }

    public ElementMenu(int id, string nom, decimal prix, bool estDisponible)
    {
        if (id <= 0)
            throw new ArgumentException("Id peut pas être négatif");

        if (string.IsNullOrWhiteSpace(nom))
            throw new ArgumentException("Un nom peut pas être vide");

        if (prix < 0)
            throw new ArgumentException("Un prix peut pas être négatif");

        m_id = id;
        m_prix = prix;
        m_nom = nom;
        m_estDisponible = estDisponible;

    }

    public void Retirer()
    {
        m_estDisponible = false;
    }

    public void RendreDisponible()
    {
        m_estDisponible = true;
    }

    public void ChangerPrix(decimal prix)
    {
        if (prix < 0)
            throw new ArgumentException("Prix peut pas être négatif");

        m_prix = prix;
    }
}
