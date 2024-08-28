using Gestão_Livraria.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography.Xml;
using static Gestão_Livraria.ClassesLivraria.AtualizarInformacoesViewModel;

namespace Gestão_Livraria.ClassesLivraria;

public class EstoqueLivros
{

    public static List<Livros> ListaLivros = new List<Livros>();
    private static int proximoIdLivro = 1;
    public int AdicinarLivros(NovoLivroViewModel novoLivro)
    {

        int idNovoLivro = proximoIdLivro++;

        ListaLivros.Add(new Livros()
        {
            IDLivro = idNovoLivro,
            AutorLivro = novoLivro.AutorLivro,
            DesricaoGenero = GetEnumDescription(novoLivro.Genero),
            Genero = novoLivro.Genero,
            PrecoLivro = novoLivro.PrecoLivro,
            TituloLivro = novoLivro.TituloLivro

        });

        return idNovoLivro;
    }

    public Livros? VerLivrosPorID(int IDLivro)
    {

        var livroPesquisado = ListaLivros.Where(a => a.IDLivro == IDLivro).FirstOrDefault();


        return livroPesquisado;

    }
    public EstoqueLivroViewModel QuantidadeLivrosEstoque()
    {
        var quantidadeEstoque = ListaLivros.Count();
        var quantidadeLivrosEstoque = new EstoqueLivroViewModel
        {
            quantidadeLivrosEstoque = quantidadeEstoque,
        };

        return quantidadeLivrosEstoque;

    }
    public List<Livros> VerLivrosEstoque()
    {
        var verLivrosEstoque = ListaLivros;

        return verLivrosEstoque;
    }
    public Livros DeletarLivro(int IDLivro)
    {
        var livroRemovido = ListaLivros.Where(a => a.IDLivro == IDLivro).FirstOrDefault();
        ListaLivros.Remove(livroRemovido);

        return livroRemovido;
    }
    public Livros AtualizarInfoLivro(int IDLivro, AtualizarInformacoesViewModel livroAtualizado)
    {
        Livros livros = new Livros();
        var livroPesquisado = ListaLivros.Where(a => a.IDLivro == IDLivro).FirstOrDefault();

        livros.DesricaoGenero = GetEnumDescription(livroAtualizado.Genero);

        livroPesquisado.DesricaoGenero = livros.DesricaoGenero;
        livroPesquisado.TituloLivro = livroAtualizado.TituloLivro;
        livroPesquisado.AutorLivro = livroAtualizado.AutorLivro;
        livroPesquisado.PrecoLivro = livroAtualizado.PrecoLivro;
        livroPesquisado.Genero = livroAtualizado.Genero;

        return livroPesquisado;
    }
    public static string GetEnumDescription(EnumGenero value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        if (attributes != null && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}
