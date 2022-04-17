using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.EF;
using Microsoft.EntityFrameworkCore;
using reposbackend.Business.Interface;
using reposbackend.Domain;
using reposbackend.Model;

namespace reposbackend.Business.Service
{
    public class EntregaService : IEntregaService
    {
        private readonly Context _context;

        public EntregaService(Context _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }

        public Entrega AgendarEntrega(EntregaDto entrega){
            try{

                var novaEntrega = new Entrega{
                    Anotacoes = entrega.Anotacoes,
                    DataAgendada = entrega.DataEntrega,
                    Endereco = entrega.Endereco,
                    StatusId = StatusEntregaEnum.Aguardando,
                };

                return novaEntrega;
            }
            catch(Exception ex)
            { throw ex; }
        }

        public async Task RecuperarEntregas(){
            try {
                var entregas = await _context.Entrega
                .Where(w => w.StatusId == StatusEntregaEnum.Aguardando || w.StatusId == StatusEntregaEnum.EmRota)
                .Select(s => new RetornoEntregaDto {
                    Anotacoes = s.Anotacoes,
                    DataAgendada = s.DataAgendada,
                    Endereco = s.Endereco,
                    Produtos = s.Venda.Produtos.Select(p => new ProdutosEntregaDto{
                        Observacao = p.Observacao,
                        Produto = p.Produto.Nome,
                        Quantidade = p.Quantidade
                    }).ToList()
                })
                .ToListAsync();
            }
            catch(Exception ex)
            { throw ex; }
        }
    }
}