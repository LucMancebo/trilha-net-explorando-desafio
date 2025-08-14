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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
            if (hospedes == null || hospedes.Count == 0) throw new Exception("Lista de hóspedes não pode ser nula ou vazia.");
            if (DiasReservados <= 0) throw new Exception("Número de dias reservados deve ser maior que zero.");
            if (Suite == null) throw new Exception("Nenhuma suíte cadastrada.");
            if (hospedes.Count > Suite.Capacidade) throw new Exception("Capacidade insuficiente para o número de hóspedes.");
            Hospedes = hospedes;
        }

        

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null) throw new Exception("Nenhuma suíte cadastrada.");
            if (DiasReservados <= 0) throw new Exception("Número de dias reservados deve ser maior que zero.");

            decimal valor = DiasReservados * Suite.ValorDiaria;
            valor = DiasReservados >= 10 ? valor * 0.9m : valor;

            return valor;
        }
    }
}