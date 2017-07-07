using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CommandCheckin : ICommand<Carro, string>
    {
        private Estacionamento _estacionamento = new Estacionamento();

        /// <summary>
        /// DTO Representado o carro
        /// </summary>
        public Carro Argumento { get; set; }

        /// <summary>
        /// Mensagem informando se o resultado da operação
        /// </summary>
        public string Resultado { get; set; }

        /// <summary>
        /// Tenta executar o checkin do veículo em Argumento e armazena o resultado em Resultado
        /// </summary>
        public void Executar()
        {
            if (!Validar())
                return;

            _estacionamento.AdicionarEntrada(new EntradaEstacionamento() { Carro = Argumento, Entrada = DateTime.Now });
        }

        /// <summary>
        /// Valida se é possível realizar o checkin
        /// </summary>
        /// <returns>Verdadeiro apenas todas validações forem atendidas</returns>
        public bool Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(Argumento?.Placa))
                    throw new Exception("Placa inválida.");

                if (_estacionamento.VagasDisponiveis == 0)
                    throw new Exception("Estacionamento cheio!");

                if (_estacionamento.BuscarEntrada(Argumento.Placa) != null)
                    throw new Exception(String.Format("Carro placa '{0} já existe!", Argumento.Placa));
            }
            catch (Exception ex)
            {
                Resultado = ex.Message;
                return false;
            }
            return true;
        }
    }
}
