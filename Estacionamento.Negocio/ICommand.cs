using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Representa uma transação completa
    /// </summary>
    public interface ICommand<TEntrada, TSaida>
    {
        /// <summary>
        /// Argumento de entrada
        /// </summary>
        TEntrada Argumento { get; set; }

        /// <summary>
        /// Mensagem com o resultado da operação
        /// </summary>
        TSaida Resultado { get; set; }

        /// <summary>
        /// Valida se a operação pode ser executada com o argumento apresentadao
        /// </summary>
        /// <returns>Verdadeiro somente se a operação for possível com o argumento informado</returns>
        bool Validar();

        /// <summary>
        /// Executa a operação utiliando o Argumento de entrada e alimenta a saída em Resultado
        /// </summary>
        void Executar();
    }
}
