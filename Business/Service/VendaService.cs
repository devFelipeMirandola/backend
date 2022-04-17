using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Business.Interface;
using backend.EF;
using backend.Model;
using reposbackend.Business.Interface;
using reposbackend.Domain;
using reposbackend.Model;

namespace reposbackend.Business.Service
{
    public class VendaService : IVendaService
    {
        private readonly Context _context;
        private readonly IProdutoService _produtoService;
        private readonly IEntregaService _entregaService;
        
        public VendaService(Context _context
        , IProdutoService _produtoService
        , IEntregaService _entregaService){
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
            this._produtoService = _produtoService ?? throw new ArgumentNullException(nameof(_produtoService));
            this._entregaService = _entregaService ?? throw new ArgumentNullException(nameof(_entregaService));
        }

        public async Task Gerar(NovaVendaDto dto){
            try{

                var valorTotal = await CalcValorTotal(dto.Produtos);

                var novaVenda = new Venda{
                    ClienteId = dto.ClienteId,
                    DataCriacao = DateTime.Now,
                    Produtos = dto.Produtos.Select(s => new VendaProduto{
                        ProdutoId = s.ProdutoId,
                        Quantidade = s.Quantidade,
                        Observacao = s.Observacao
                    }).ToList(),
                    UsuarioId = dto.UsuarioId,
                    ValorTotal = valorTotal
                };

                foreach(var prod in dto.Produtos)
                {
                    await _produtoService.SubtrairProdutoEstoque(prod.ProdutoId, prod.Quantidade);
                }

                if(dto.Entrega)
                {
                    var novaEntrega = _entregaService.AgendarEntrega(dto.DadosEntrega);

                    novaVenda.Entrega = novaEntrega;
                }

                _context.Venda.Add(novaVenda);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            { var excpt = ex; throw; }
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
            { var excpt = ex; throw; }
        }
    }
}