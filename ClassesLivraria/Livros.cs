using Gestão_Livraria.Enums;
using Microsoft.VisualBasic;

namespace Gestão_Livraria.ClassesLivraria;

public class Livros
{
    public int IDLivro {  get; set; }

    public string TituloLivro { get; set; }

    public string AutorLivro { get; set; }

     public EnumGenero Genero { get; set; }
    public string DesricaoGenero { get; set; }
    public double PrecoLivro { get; set; }

}
