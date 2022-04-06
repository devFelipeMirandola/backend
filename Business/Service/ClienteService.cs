using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.EF;
using backend.Model;
using Microsoft.EntityFrameworkCore;
using reposbackend.Business.Interface;
using reposbackend.CrossCutting;
using reposbackend.Domain;

namespace reposbackend.Business.Service
{
    public class ClienteService : IClienteService
    {
        private readonly Context _context;

        public ClienteService(Context _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
    
        public async Task Cadastrar(ClienteDto dto){
            try{
                var cpfTratado = dto.Cpf.OnlyNumbers();

                if(await _context.Cliente.AnyAsync(a => a.Cpf == cpfTratado)) 
                { throw new Exception($"Já existe um cliente com o cpf informado."); }
                
                var novoCliente = new Cliente{
                    Ativo = true,
                    DataCriacao = DateTime.Now,
                    Cpf = cpfTratado,
                    Nome = dto.Nome,
                    Telefone = dto.Telefone
                };

                _context.Cliente.Add(novoCliente);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task<List<ClienteDto>> RecuperarTodos(bool somenteAtivos = true){
            try{
                return await _context.Cliente.Where(w => somenteAtivos ? w.Ativo : w.Id > 0).Select(s => new ClienteDto{
                    Id = s.Id,
                    Ativo = s.Ativo,
                    Cpf = s.Cpf,
                    Nome = s.Nome,
                    Telefone = s.Telefone
                }).ToListAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task<ClienteDto> Recuperar(int clienteId){
            try{
                return await _context.Cliente.Where(w => w.Id == clienteId).Select(s => new ClienteDto{
                    Id = s.Id,
                    Ativo = s.Ativo,
                    Cpf = s.Cpf,
                    Nome = s.Nome,
                    Telefone = s.Telefone
                }).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task Editar(ClienteDto dto){
            try{
                if(!dto.Id.HasValue) 
                { throw new Exception("Não foi possível identificar o cliente."); }

                var cliente = await _context.Cliente.Where(w => w.Id == dto.Id.Value).FirstOrDefaultAsync();
            
                if(cliente is null) 
                { throw new Exception($"Não foi possivel encontrar o cliente: [{dto.Id}]"); }

                if (cliente.Nome != dto.Nome) { cliente.Nome = dto.Nome; }
                if (cliente.Cpf != dto.Cpf) { cliente.Cpf = dto.Cpf; }
                if (cliente.Telefone != dto.Telefone) { cliente.Telefone = dto.Telefone; }

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task Remover(int clienteId){
            try{
                var cliente = await _context.Cliente.Where(w => w.Id == clienteId).FirstOrDefaultAsync();
                
                if(cliente is null) 
                { throw new Exception($"Não foi possivel encontrar o cliente: [{clienteId}]"); }

                cliente.Ativo = false;

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}