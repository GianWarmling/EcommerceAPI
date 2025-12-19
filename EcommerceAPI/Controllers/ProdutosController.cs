using AutoMapper;
using EcommerceAPI.Data;
using EcommerceAPI.DTOs;
using EcommerceAPI.Models;
using EcommerceAPI.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProdutosController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/produtos
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return Ok(ApiResponse<IEnumerable<ProdutoDto>>.Ok(produtosDto, "Lista de produtos carregada com sucesso"));
        }

        // GET: api/produtos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var produto = await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
                return NotFound(ApiResponse<string>.Falha("Produto não encontrado!"));

            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(ApiResponse<ProdutoDto>.Ok(produtoDto, "Produto carregado com sucesso!"));
        }
        [Authorize]
        // POST: api/produtos
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CriarProdutoDto criarDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.Falha("Dados inválidos!"));

            var produto = _mapper.Map<Produto>(criarDto);
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(ApiResponse<ProdutoDto>.Ok(produtoDto, "Produto criado com sucesso!"));
        }
        [Authorize]
        // PUT: api/produtos/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] AtualizarProdutoDto dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound(ApiResponse<string>.Falha("Produto não encontrado!"));

            _mapper.Map(dto, produto);
            await _context.SaveChangesAsync();

            var produtoDto = _mapper.Map<ProdutoDto>(produto);

            return Ok(ApiResponse<ProdutoDto>.Ok(produtoDto, "Produto atualizado com sucesso!"));
        }
        [Authorize]
        // DELETE: api/produtos/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound(ApiResponse<string>.Falha("Produto não encontrado!"));

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse<string>.Ok("Produto removido com sucesso!"));
        }
    }
}
