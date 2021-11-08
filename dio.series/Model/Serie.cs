using System;

namespace dio.series.Model
{
    public class Serie : Base
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }

        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }


        public int retornarId()
        {
            return this.Id;
        }

        public bool retornarExcluido()
        {

            return this.Excluido;
        }

        public void excluir()
        {
            this.Excluido = true; ;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido " + this.Excluido;
            return retorno;
        }

    }
}