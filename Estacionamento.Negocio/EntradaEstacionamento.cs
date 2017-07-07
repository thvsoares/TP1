using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Representa uma entrada do estacionamento
    /// </summary>
    internal sealed class EntradaEstacionamento
    {
        /// <summary>
        /// Carro que deu entrada no estacionamento
        /// </summary>
        public Carro Carro { get; set; }

        /// <summary>
        /// Data da entrada do carro
        /// </summary>
        public DateTime Entrada { get; set; }
    }
}
