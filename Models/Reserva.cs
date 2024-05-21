namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                var capacidade = Suite.Capacidade;
                var qtdHospedes = hospedes.Count;

                if (qtdHospedes <= capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new Exception($"A suíte não comporta {qtdHospedes} hóspedes.");
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            var qtdHospedes = Hospedes.Count;

            return qtdHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                double aux = 10.0/100;
                var total = Convert.ToDouble(valor) - (aux * Convert.ToDouble(valor));
                return Convert.ToDecimal(total);
            }
            return 0;
        }
    }
}