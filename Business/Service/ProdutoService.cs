using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Business.Interface;
using backend.Domain;
using backend.EF;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.Business.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly Context _context;

        public ProdutoService(Context _context){
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task Cadastrar(ProdutoDto dto){
            try{

                var novoProduto = new Produto{
                    Nome = dto.Nome,
                    Ativo = true,
                    CategoriaId = dto.CategoriaId,
                    Valor = dto.Valor,
                    Estoque = dto.Estoque,
                    DataCriacao = DateTime.Now,
                    Imagem = dto.Imagem,
                };

                _context.Produto.Add(novoProduto);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

        public async Task Editar(ProdutoDto dto){
            try{
                var produto = await _context.Produto.Where(w => w.Id == dto.Id).FirstOrDefaultAsync();
                
                if(dto.Nome != produto.Nome) { produto.Nome = dto.Nome; }
                if(dto.Imagem != produto.Imagem) { produto.Imagem = dto.Imagem; }
                if(dto.Estoque != produto.Estoque) { produto.Estoque = dto.Estoque; }
                if(dto.Valor != produto.Valor) { produto.Valor = dto.Valor; }
                if(dto.CategoriaId != produto.CategoriaId) { produto.CategoriaId = dto.CategoriaId; }
                if(dto.Ativo != produto.Ativo) { produto.Ativo = dto.Ativo; }
                
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

        public async Task Remover(int produtoId){
            try{
                var produto = await _context.Produto.Where(w => w.Id == produtoId).FirstOrDefaultAsync();
                produto.Ativo = false;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

        public async Task<ProdutoDto> Recuperar(int produtoId){
            try{
                return await _context.Produto.Where(w => w.Id == produtoId && w.Ativo).Select(s => new ProdutoDto{
                    Id = s.Id,
                    CategoriaId = s.CategoriaId,
                    Ativo = s.Ativo,
                    DataCriacao = s.DataCriacao,
                    Estoque = s.Estoque,
                    Imagem = s.Imagem,
                    Nome = s.Nome,
                    Valor = s.Valor
                }).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

        public async Task<List<ProdutoDto>> RecuperarTodos(bool somenteAtivos = true){
            try{
                return await _context.Produto.Where(w => somenteAtivos ? w.Ativo : w.Id > 0).Select(s => new ProdutoDto{
                    Id = s.Id,
                    CategoriaId = s.CategoriaId,
                    Ativo = s.Ativo,
                    DataCriacao = s.DataCriacao,
                    Estoque = s.Estoque,
                    Imagem = s.Imagem,
                    Nome = s.Nome,
                    Valor = s.Valor
                }).ToListAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

        public async Task SubtrairProdutoEstoque(int produtoId, int quantidade){
            try{
                var produto = await _context.Produto.Where(w => w.Id == produtoId).FirstOrDefaultAsync();

                if(produto is null)
                { throw new Exception($"Produto [{produtoId}] não encontrado na base."); }

                produto.Estoque = produto.Estoque - quantidade;
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
        }

    }
}