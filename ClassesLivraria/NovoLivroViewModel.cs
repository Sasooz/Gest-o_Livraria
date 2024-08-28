using Gestão_Livraria.Enums;

namespace Gestão_Livraria.ClassesLivraria;

public class NovoLivroViewModel
{
    public string TituloLivro { get; set; }

    public string AutorLivro { get; set; }

    public EnumGenero Genero { get; set; }
    public double PrecoLivro { get; set; }

}
