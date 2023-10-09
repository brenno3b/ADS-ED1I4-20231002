using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231002
{
    internal class Medicamentos
    {
        private List<Medicamento> _listaMedicamentos;

        public List<Medicamento> ListaMedicamentos { get { return _listaMedicamentos; } }

        public Medicamentos()
        {
            _listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            _listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            if (medicamento.QtdeDisponivel() != 0) return false;

            int index = _listaMedicamentos.FindIndex((e) => e.Id == medicamento.Id);

            if (index == -1) return false;

            _listaMedicamentos.RemoveAt(index);

            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            int index = _listaMedicamentos.FindIndex((e) => e.Id == medicamento.Id);

            if (index == -1) return new Medicamento();

            return _listaMedicamentos.ElementAt(index);
        }
    }
}
