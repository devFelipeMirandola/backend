using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.EF;
using backend.Model;
using Microsoft.EntityFrameworkCore;
using reposbackend.Business.Interface;
using reposbackend.Domain;

namespace reposbackend.Business.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly Context _context;

        public CategoriaService(Context _context){
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task<List<CategoriaDto>> RecuperarTodos(bool apenasAtivos = true){
            try{
                return await _context.Categoria.Where(w => apenasAtivos ? w.Ativo : w.Id > 0).Select(s => new CategoriaDto{
                    Id = s.Id,
                    Descricao = s.Descricao,
                    Ativo = s.Ativo
                }).ToListAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task<CategoriaDto> Recuperar(int categoriaId){
            try{
                return await _context.Categoria.Where(w => w.Id == categoriaId).Select(s => new CategoriaDto{
                    Id = s.Id,
                    Ativo = s.Ativo,
                    Descricao = s.Descricao
                }).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task Remover(int categoriaId){
            try{
                var categoria = await _context.Categoria.Where(w => w.Id == categoriaId).FirstOrDefaultAsync();

                categoria.Ativo = false;

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task Editar(CategoriaDto dto){
            try{
                var categoria = await _context.Categoria.Where(w => w.Id == dto.Id).FirstOrDefaultAsync();

                if(categoria.Descricao != dto.Descricao) { categoria.Descricao = dto.Descricao; }
                if(categoria.Ativo != dto.Ativo) { categoria.Ativo = dto.Ativo; }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task Adicionar(string categoria){
            try{
                var novaCategoria = new Categoria{
                    Ativo = true,
                    Descricao = categoria
                };

                _context.Categoria.Add(novaCategoria);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}