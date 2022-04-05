using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Business.Interface;
using backend.EF;
using backend.Model;
using reposbackend.Business.Interface;
using reposbackend.Domain;

namespace reposbackend.Business.Service
{
    public class VendaService : IVendaService
    {
        private readonly Context _context;
        private readonly IProdutoService _produtoService;
        
        public VendaService(Context _context){
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public async Task Gerar(NovaVendaDto dto){
            try{

                var valorTotal = await CalcValorTotal(dto.Produtos);

                var novaVenda = new Venda{
                    ClienteId = dto.ClienteId,
                    DataCriacao = DateTime.Now,
                    UsuarioId = dto.UsuarioId,
                    Produtos = dto.Produtos.Select(s => new VendaProduto{
                        ProdutoId = s.ProdutoId,
                    }).ToList(),
                    ValorTotal = valorTotal
                };

                _context.Venda.Add(novaVenda);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }

        private async Task<decimal> CalcValorTotal(List<ProdutoVendaDto> dto){
            try{
                var valorTotal = decimal.Zero;

                foreach(var prod in dto)
                {
                    var valor = await _produtoService.Recuperar(prod.ProdutoId);
                    valorTotal += valor.Valor * prod.Quantidade;
                }

                return valorTotal;
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}