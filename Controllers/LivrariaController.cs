using Gestão_Livraria.ClassesLivraria;
using Microsoft.AspNetCore.Mvc;

namespace Gestão_Livraria.Controllers;
public class LivrariaController : ControllerBase
{
    [HttpPost]
    [Route("CriarLivro")]
    public IActionResult CriarLivros(NovoLivroViewModel livro)
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();

        var resultado = estoqueLivros.AdicinarLivros(livro);
        return Ok(new { idLivro = resultado });
    }

    [HttpGet]
    [Route("VisualizarLivros")]
    public IActionResult VisualizarTodosLivros()
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();
        var verTodosLivros = estoqueLivros.VerLivrosEstoque();
        return Ok(verTodosLivros);
    }

    [HttpGet]
    [Route("VisualizarLivroEspecifico")]
    public IActionResult VisualizarLivroEspecifico(int IDLivro)
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();
        var verLivros = estoqueLivros.VerLivrosPorID(IDLivro);

        if (verLivros is null)
            return NotFound($"O Livro com ID ({IDLivro}) não foi encontrado.");

        return Ok(verLivros);
    }

    [HttpGet]
    [Route("QuantidadeLivros")]
    public IActionResult QuantidadeLivrosEstoque()
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();
        var quantidadeLivroEstoque = estoqueLivros.QuantidadeLivrosEstoque();

        return Ok(quantidadeLivroEstoque);
    }

    [HttpPut]
    [Route("Atualizarinformacoes")]
    public IActionResult AtualizarLivros(int IDLivro, AtualizarInformacoesViewModel livroAtualizado)
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();
        var livroAtualizadoSucesso = estoqueLivros.AtualizarInfoLivro(IDLivro, livroAtualizado);

        if (livroAtualizadoSucesso is null)
            return NotFound($" Livro com ID: {IDLivro} não foi encontrado.");

        return NoContent();
    }

    [HttpDelete]
    [Route("ExcluirLivro")]
    public IActionResult DeletarLivros(int IDLivro)
    {
        EstoqueLivros estoqueLivros = new EstoqueLivros();
        var livroRemovido = estoqueLivros.DeletarLivro(IDLivro);

        if (livroRemovido is null)
            return NotFound($" Livro com ID: {IDLivro} não foi encontrado.");

        return NoContent();
    }
}

