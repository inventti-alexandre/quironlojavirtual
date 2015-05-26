using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(
                    _emailConfiguracoes.Usuario, 
                    _emailConfiguracoes.ServidorSmtp);
                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                var body = new StringBuilder()
                .AppendLine("Novo Pedido:")
                .AppendLine("------")
                .AppendLine("Itens");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subTotal = (item.Produto.Preco * item.Quantidade);
                    body.AppendFormat("{0} x {1} subtotal: {2:c}", item.Quantidade, item.Produto.Nome, subTotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Bairro ?? "")
                    .AppendLine(pedido.Estado ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("------")
                    .AppendFormat("para prestente: {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                var message = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo pedido",
                    body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    message.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                // envia o email
                smtpClient.Send(message);
            }
        }
    }
}
