using System.Collections.Generic;
using dio.series.Interface;
using dio.series.Model;

namespace dio.series.Entity
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie[id].excluir();
        }

        public void Inserir(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public System.Collections.Generic.List<Serie> Listar()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornarId(int id)
        {
            return listaSerie[id];
        }
    }
}