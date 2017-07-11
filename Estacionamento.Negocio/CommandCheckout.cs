using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Transação de saída do estacionamento
    /// </summary>
    public class CommandCheckout : ICommand<string, string>
    {
        private Estacionamento _estacionamento = new Estacionamento();
        
        /// <summary>
        /// Placa do carro
        /// </summary>
        public string Argumento { get; set; }

        /// <summary>
        /// Mensagem com o resultado da operação
        /// </summary>
        public string Resultado { get; set; }

        /// <summary>
        /// Calcula o valor e executa a baixa de um veículo
        /// </summary>
        public void Executar()
        {
            if (!this.Validar())
                return;

            var entrada = _estacionamento.BuscarEntrada(this.Argumento);
            var valor = CalcularValorEstacionamento(entrada.Entrada, DateTime.Now);
        }

        /// <summary>
        /// Valida se a placa é válida e o carro está no estacionamento
        /// </summary>
        /// <returns>Verdadeiro caso todas validações sejam atendidas</returns>
        public bool Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Argumento))
                    throw new Exception("Placa inválida.");

                if (_estacionamento.BuscarEntrada(this.Argumento) == null)
                    throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", this.Argumento));
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calcula o valor com base no tempo de permanência
        /// </summary>
        private static double CalcularValorEstacionamento(DateTime entrada, DateTime saida)
        {
            var permanencia = saida.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo
        }
    }
}
