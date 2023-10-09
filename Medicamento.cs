using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231002
{
    internal class Medicamento
    {
        private int _id;
        private String _nome;
        private String _laboratorio;
        private Queue<Lote> _lotes;

        public int Id { get { return _id; }  }
        public String Nome { get { return _nome; } }
        public String Laboratorio { get { return _laboratorio; } }
        public Queue<Lote> Lotes { get {  return _lotes; } }

        public Medicamento()
        {
            _id = -1;
            _nome = "";
            _laboratorio = "";
            _lotes = new Queue<Lote>();
        }

        public Medicamento(int id)
        {
            _id = id;
            _nome = "";
            _laboratorio = "";
            _lotes = new Queue<Lote>();
        }

        public Medicamento(int id, string nome, string laboratorio)
        {
            _id = id;
            _nome = nome;
            _laboratorio = laboratorio;
            _lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            int sum = 0;

            foreach (Lote lote in _lotes)
            {
                sum += lote.Qtde;
            }

            return sum;
        }

        public void Comprar(Lote lote)
        {
            _lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (qtde > _lotes.Count) return false;

            for (int i = 0; i < qtde; i++)
            {
                _lotes.Dequeue();
            }

            return true;
        }
        public override string? ToString()
        {
            return $"{_id}-{_nome}-{_laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Medicamento medicamento &&
                   _id == medicamento._id;
        }
    }
}
