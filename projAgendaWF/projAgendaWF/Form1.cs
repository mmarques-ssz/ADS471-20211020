using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projAgendaWF
{
    public partial class Form1 : Form
    {
        private ListaContatos agenda;

        public Form1()
        {
            InitializeComponent();
            agenda = new ListaContatos();
            agenda.recuperar();
            
        }

        private void limparInterface(string email, string nome, string fone)
        {
            txtEmail.Text = email;
            txtNome.Text = nome;
            txtFone.Text = fone;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparInterface("", "", "");
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Contato contatoPesquisado = new Contato(txtEmail.Text, "", "");
            contatoPesquisado = agenda.pesquisar(contatoPesquisado);
            if (contatoPesquisado.Email == "")
            {
                agenda.incluir(new Contato(txtEmail.Text,
                    txtNome.Text,
                    txtFone.Text));
            }
            else
            {
                agenda.alterar(new Contato(txtEmail.Text,
                    txtNome.Text,
                    txtFone.Text));
            }
            MessageBox.Show("Contato gravado");
            limparInterface("", "", "");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Contato contatoPesquisado = new Contato(txtEmail.Text, "", "");
            contatoPesquisado = agenda.pesquisar(contatoPesquisado);
            if (contatoPesquisado.Email == "")
            {
                MessageBox.Show("Contato não encontrado");
            }
            else
            {
                limparInterface(contatoPesquisado.Email, 
                    contatoPesquisado.Nome, 
                    contatoPesquisado.Fone);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Contato contatoPesquisado = new Contato(txtEmail.Text, "", "");
            contatoPesquisado = agenda.pesquisar(contatoPesquisado);
            if (contatoPesquisado.Email == "")
            {
                MessageBox.Show("Contato não encontrado");
            }
            else
            {
                agenda.remover(contatoPesquisado);
                MessageBox.Show("Contato excluído");
                limparInterface("", "", "");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            BindingList<Contato> lista = new BindingList<Contato>(agenda.MeusContatos);
            dgContatos.DataSource = lista;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            agenda.gravar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
