using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estacionamento.Negocio;

namespace Estacionamento.Apresentacao
{
    public partial class EstacionamentoForm : Form
    {
        private ICommand<Carro, string> _commandCheckin;

        private ICommand<string, string> _commandCheckout;

        public EstacionamentoForm()
        {
            InitializeComponent();
            _commandCheckin = new CommandCheckin();
            _commandCheckout = new CommandCheckout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;
            var dto = new Carro() { Placa = placa };

            _commandCheckin.Argumento = dto;

            if (_commandCheckin.Validar())
            {
                _commandCheckin.Executar();
                MessageBox.Show(_commandCheckin.Resultado);
            }
            else
            {
                MessageBox.Show(_commandCheckin.Resultado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;

            _commandCheckout.Argumento = placa;

            if (_commandCheckout.Validar())
            {
                _commandCheckout.Executar();
                MessageBox.Show(_commandCheckout.Resultado);
            }
            else
            {
                MessageBox.Show(_commandCheckout.Resultado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}