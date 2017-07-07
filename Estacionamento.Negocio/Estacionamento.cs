using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Repositório do estacionamento
    /// </summary>
    internal sealed class Estacionamento
    {
        /// <summary>
        /// Total de vagas do estacionamento
        /// </summary>
        private const int VAGAS_TOTAIS = 15;

        /// <summary>
        /// Carros estacionados
        /// </summary>
        private static Dictionary<string, EntradaEstacionamento> _entradas = new Dictionary<string, EntradaEstacionamento>();

        /// <summary>
        /// Recupera a quantidade de vagas disponiveis
        /// </summary>
        public int VagasDisponiveis { get => VAGAS_TOTAIS - _entradas.Count; }

        /// <summary>
        /// Adiciona uma entrada no estacionamento
        /// </summary>
        /// <param name="entrada">Dados do carro e da entrada</param>
        public void AdicionarEntrada(EntradaEstacionamento entrada)
        {
            _entradas.Add(entrada.Carro.Placa, entrada);
        }

        /// <summary>
        /// Recupera uma entrada do estacionamento
        /// </summary>
        /// <param name="placa">Placa do carro da entrada</param>
        /// <returns>Entrada do estacionamento</returns>
        public EntradaEstacionamento BuscarEntrada(string placa)
        {
            if (!_entradas.TryGetValue(placa, out var carro))
                return null;
            return carro;
        }

        /// <summary>
        /// Remove a entrada com a placa informada do estacionamento
        /// </summary>
        /// <param name="placa">Placa do carro</param>
        /// <returns>Se a entrada foi removida</returns>
        public bool RemoverEntrada(string placa)
        {
            return _entradas.Remove(placa);
        }
    }
}
