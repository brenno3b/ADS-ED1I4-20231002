using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_ED1I4_20231002
{
    internal class Lote
    {
        private readonly int _id;
        private readonly int _qtde;
        private readonly DateTime _venc;

        public int Id { get { return _id; } }
        public int Qtde { get { return _qtde; } }
        public DateTime Venc { get { return _venc; } }

        public Lote()
        {
            _id = -1;
            _qtde = -1;
            _venc = DateTime.Now;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            _id = id;
            _qtde = qtde;
            _venc = venc;
        }

        public override string? ToString()
        {
            return $"{_id}-{_qtde}-{_venc}";
        }
    }
}
